var app = app || {};
app.PolygonCollection = Backbone.Collection.extend({
    initialize: function (layerId, model, view, url, visibility, selectable, style, selectedStyle, layerGroup, layerType) {
        var that = this;
        _thispolygon = this;
        this.layerId = layerId;
        //injecting model and view into collection from the config
        this.url = url;
        this.model = model;
        this.selectable = selectable;
        this.style = style;
        this.selectedStyle = selectedStyle;
        this.visibility = visibility;
        this.layerGroup = layerGroup;
        this.type = layerType
        this.view = view;
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
        this.featureOverlay.set('LayerType', this.layerId);
        this.map.addLayer(this.featureOverlay);
        var _source = this.featureOverlay.getSource();
        app.snap = new ol.interaction.Snap({
            source: _source
        });
        this.map.addInteraction(app.snap);
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
        alert("fetch Error Occured");
    },
    onFetchComplete: function (e)
    {
        this.forEach(function (model) {
            model.hasChangedSinceLastSync = false;
        })
        app.drawView.updateUnsavedItems();
    },
    addDrawFeature: function (collection)
    {
        if (app.previousDrawInteraction)
        {
            this.map.removeInteraction(app.previousDrawInteraction);
        }
        this.collection = collection;
        this.drawFeature = new ol.interaction.Draw({
            features: this.features,
            type: "Polygon"
        });
        this.map.addInteraction(this.drawFeature);
        app.previousDrawInteraction = this.drawFeature;
        this.drawFeature.on('drawend', this.featureDrawn, this);
    },
    featureDrawn: function (e)
    {
        alert("polygon feature drawn");
        selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
        var tbl_name = $('input[name="edit_radio"]:checked').val();
        var lastNewId = 0;
        $.ajax({
            url: siteurl + "Draw/GetLastId",
            type: 'POST',
            data: { 'tbl_name': tbl_name, 'primary_id': "id" },
            //data: formData,
            success: function (data) {
                lastNewId = data + 1;
        //converting feature into WKT
        wktier = new ol.format.WKT();
        var _model = new selectedLayerDetail.model();
        var _defaults = _model.get_defaults({
            id: lastNewId,
            wkt: wktier.writeFeature(e.feature),
            add_by: addBy,
            add_date: addDate
        });
        _model.set(_defaults);
        selectedLayerDetail.add([_model]);
                e.feature.setId(selectedLayerDetail.get_last_cid());
            }
        });
    }, /*display fetched model into map*/
    forEachModelFetched: function (model)
    {
        if (model.get("wkt") != null || model.get("wkt") != "") {
            var wktier = new ol.format.WKT();
            var feature = wktier.readFeature(model.get("wkt"));
            /*setting model cid and feature change event on feature*/
            feature.setId(model.cid);
            _source = this.featureOverlay.getSource();
            _source.addFeature(feature);
        }
    }




});
