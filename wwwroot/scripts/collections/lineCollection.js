var app = app || {};
app.LineCollection = Backbone.Collection.extend({
    url: null, //set when instiantiate
    initialize: function (layerId, model, view, url, visibility, selectable, style, selectedStyle) {
        var that = this;
        this.layerId = layerId;
        //injecting model and view into collection from the config
        this.url = url;
        this.selectable = selectable;
        /*setting the model for this collection */
        this.model = model;
        this.view = view;
        this.style = style;
        this.selectedStyle = selectedStyle;
        this.visibility = visibility;
        /*for setting the default attribute*/
        this.is_model_default_attribute_saved = false;
        this.default_attrs = null;
        this.fetch({
            error: this.onFetchError,
            success: function (e) {
                that.onFetchComplete();
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

        var _source = this.featureOverlay.getSource();
        app.snap = new ol.interaction.Snap({
            source: _source
        });
        this.map.addInteraction(app.snap);
        //console.log(app.snap);
        //app.snap.on('change:geometry',function(e){alert("hello snap")},this);
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
        //alert("fetch complete");
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
            type: "LineString"
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
    }, /*display fetched model into map*/
    forEachModelFetched: function (model)
    {
        var wktier = new ol.format.WKT();
        var feature = wktier.readFeature(model.get("wkt"));
        /*setting model cid and feature change event on feature*/
        feature.setId(model.cid);
        _source = this.featureOverlay.getSource();
        _source.addFeature(feature);
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
