var app = app || {};
app.PointCollection = Backbone.Collection.extend({
    url: null,
    //model:app.PointModel,
    initialize: function (layerId, model, view, url, visibility, selectable, style, selectedStyle) {
        var that = this;
        this.layerId = layerId;
        //injecting model and view into collection from the config
        this.url = url,
                this.model = model;
        this.view = view;
        this.style = style;
        this.selectable = selectable;
        this.visibility = visibility;
        this.selectedStyle = selectedStyle;
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
        this.features = new ol.Collection();
        this.featureOverlay = new ol.layer.Vector({
            source: new ol.source.Vector({
                features: this.features
            }),
            style: this.style
        });
        this.featureOverlay.set('selectable', this.selectable);
        this.featureOverlay.setVisible(this.visibility);
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
        if (e.models.length > 0)
        {
            var model = e.models[0];
            var wktier = new ol.format.WKT();
            var feature = wktier.readFeature(model.get("wkt"));
            var geom = feature.getGeometry();
            //this.map.getView().setCenter(geom.getCoordinates());
        }
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
        //e.feature.on("change",this.featureChanged,this);
        this.map.removeInteraction(this.drawFeature);
        //converting feature into WKT
        wktier = new ol.format.WKT();
        var _model = new this.model();
        var _defaults = _model.get_defaults({
            pro_uuid: pid,
            wkt: wktier.writeFeature(e.feature)
        });
        _model.set(_defaults);
        this.add([_model]);
        e.feature.setId(this.get_last_cid());
        if (typeof _model.snapToCanal == "function")
        {
            var geom = e.feature.getGeometry();
            coordinates = geom.getCoordinates();
            _model.snapToCanal(coordinates);
        }
    },
    /*display fetched model into map*/
    forEachModelFetched: function (model)
    {
        var wktier = new ol.format.WKT();
        var feature = wktier.readFeature(model.get("wkt"));
        var geom = feature.getGeometry();
        //this.map.getView().setCenter(geom.getCoordinates());
        /*setting model cid and feature change event on feature*/
        model.setFeatureAttributes(feature);
        _source = this.featureOverlay.getSource();
        _source.addFeature(feature);
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
            console.log(e);
            var feature = ol3Helper.searchFeatureInCollectionsById(e.collection, e.cid);
            if (feature)
            {
                e.collection.features.remove(feature);
            }
        }
    }
});
