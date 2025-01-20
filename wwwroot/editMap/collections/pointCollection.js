var app = app || {};
var _thispoint;
app.PointCollection = Backbone.Collection.extend({
    url: null,
    
    //model:app.PointLayerModel,
    initialize: function (layerId, model, view, url, visibility, selectable, style, selectedStyle, layerGroup, layerType,layerIcon) {
        var that = this;
        _thispoint = this;
        this.layerId = layerId;
        //injecting model and view into collection from the config
        this.url = url,
        this.model = model;
        this.view = view;
        this.style = style;
        this.selectable = selectable;
        this.visibility = visibility;
        this.selectedStyle = selectedStyle;
        this.layerGroup = layerGroup;
        this.type = layerType;
        this.icon = layerIcon;
        //this.createTextStyle=createTextStyle;
        this.fetch({
            error: this.onFetchError,
            success: function (collection, response, options) {
                that.onFetchComplete(collection);
            }
        });
        this.on("add", function (model) {
            //model being added by fetching from database
            if (model.id) {
                this.forEachModelFetched(model);
            }
        });
        this.on("remove", this.removeHandler);
        this.initMapComponent();
    },
    initMapComponent: function ()
    {
        this.map = app.drawView.map;
        //console.log(this.map);
        this.features = new ol.Collection();
        //console.log(this.features);
        this.featureOverlay = new ol.layer.Vector({
            source: new ol.source.Vector({
                features: this.features
            }),
            style: this.style
        });
        //console.log(this);
        this.featureOverlay.setZIndex(10000);
        this.featureOverlay.set('LayerType',this.layerId);
        this.featureOverlay.set('selectable', this.selectable);
        this.featureOverlay.setVisible(this.visibility);
        this.featureOverlay.set('LayerTyp', this.layerType);
        //this.featureOverlay.setMap(this.map);
        this.map.addLayer(this.featureOverlay);
        
        

    },
    get_last_cid: function ()
    {
        return this.last().cid;
    },
    save: function () {
        this.forEach(function (model) {
            //!model.id means this has never been saved in database before
            if (model.hasChangedSinceLastSync || !model.id)
            {
                model.save();
            }
        });
    },
    onFetchError: function ()
    {
//        alert("fetch Error Occured");
    },
    onFetchComplete: function (e)
    {
        //e is the collection here whose fetch has been just completed
        //if (e.models.length > 0)
        //{
        //    var model = e.models[0];
        //    var wktier = new ol.format.WKT();
        //    if (model.get("wkt") == null || model.get("wkt") == "") {
        //        var feature = wktier.readFeature("");
        //        var geom = feature.getGeometry();
        //    }
        //    else
        //    {
        //        var feature = wktier.readFeature(model.get("wkt"));
        //        var geom = feature.getGeometry();
        //    }
        //}
    },
    addDrawFeature: function ()
    {
        if (app.previousDrawInteraction)
        {
            this.map.removeInteraction(app.previousDrawInteraction);
        }
        this.drawFeature = new ol.interaction.Draw({
            features: this.features,
            type: "Point"
        });
        this.map.addInteraction(this.drawFeature);
        app.previousDrawInteraction = this.drawFeature;
        this.drawFeature.on('drawend', this.featureDrawn, this);
    },
    featureDrawn: function (e)
    {
        document.getElementById("add_point").style.boxShadow = "inset 0px 0px 0px #000000";
        selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
        var tbl_name = $('input[name="edit_radio"]:checked').val();
        var lastNewId = 0;
        $.ajax({
            url: siteurl + "Draw/GetLastId",
            type: 'POST',
            data: { 'tbl_name': tbl_name, 'primary_id': "id" },
            success: function (data) {
                lastNewId = data + 1;
        wktier = new ol.format.WKT();
                var _model1 = new selectedLayerDetail.model();
                var Newgeom = e.feature.getGeometry();
                var newcoordinates = Newgeom.getCoordinates();
                var cent = ol.proj.transform(newcoordinates, 'EPSG:3857', 'EPSG:4326');
        var _defaults = _model1.get_defaults({
            id: lastNewId,
            wkt: wktier.writeFeature(e.feature),
            lat: (parseFloat(cent.toString().split(',')[1])).toFixed(7),
            lon: (parseFloat(cent.toString().split(',')[0])).toFixed(7),
            add_by: addBy,
            add_date: addDate
        });
        _model1.set(_defaults);
        selectedLayerDetail.add([_model1]);
                e.feature.setId(selectedLayerDetail.get_last_cid());

                pointDrawn = true;
            }
        });
    },
    /*display fetched model into map*/
    forEachModelFetched: function (model)
    {
        //alert("2");
        //console.log(model.get("wkt"));
        if (model.get("wkt") != null && model.get("wkt") != "") {
            var wktier = new ol.format.WKT();
            var feature = wktier.readFeature(model.get("wkt"));
            var geom = feature.getGeometry();
            /*setting model cid and feature change event on feature*/
            model.setFeatureAttributes(feature);
            _source = this.featureOverlay.getSource();
            _source.addFeature(feature);
        }
    },
    countUnSavedModels: function ()
    {
        var count = 0;
        this.forEach(function (model) {
            if (model.hashasChangedSinceLastSync)
            {
                count++;
            }
        });
        return count;
    },
    removeHandler: function (e)
    {
        if (e.get("wkt") != null)
        {
            //console.log(e);
            var feature = ol3Helper.searchFeatureInCollectionsById(e.collection, e.cid);
            if (feature)
            {
                e.collection.features.remove(feature);
            }
        }
    }
});
