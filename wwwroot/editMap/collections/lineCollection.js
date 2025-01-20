var app = app || {};
var _thisline;
app.LineCollection = Backbone.Collection.extend({
    url: null, //set when instiantiate
    initialize: function (layerId, model, view, url, visibility, selectable, style, selectedStyle, layerGroup, layerType) {
        var that = this;
        _thisline = this;
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
        this.layerGroup = layerGroup;
        this.type = layerType
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
    initMapComponent: function () {
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
        //app.snap.on('change:geometry',function(e){alert("hello snap")},this);
    },
    get_last_cid: function () {
        return this.last().cid;
    },
    save: function () {
        this.forEach(function (model) {
            //!model.id means this has never been saved in database before
            if (model.hasChangedSinceLastSync || !model.id) {
                model.save();
            }

        });
    },
    onFetchError: function () {
        alert("fetch Error Occured");
    },
    onFetchComplete: function (e) {
        //alert("fetch complete");
    },
    addDrawFeature: function (collection) {
        if (app.previousDrawInteraction) {
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
    featureDrawn: function (e) {
        $("#road").css({ "border-width": "0px" });
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
                wktier = new ol.format.WKT();
                var _model = new selectedLayerDetail.model();
                var _defaults = _model.get_defaults({
                    id: lastNewId,
                    wkt: wktier.writeFeature(e.feature),
                    pipe_len: Math.round(e.feature.getGeometry().getLength() * 100) / 100,
                    add_by: addBy,
                    add_date: addDate
                });
                _model.set(_defaults);
                selectedLayerDetail.add([_model]);
                e.feature.setId(selectedLayerDetail.get_last_cid());
                lineDrawn = true;
                document.getElementById("road").style.boxShadow = "inset 0px 0px 0px #000000";
            }
        });
    }, /*display fetched model into map*/
    forEachModelFetched: function (model) {
        //console.log(model);
        if (model.get("wkt") != null && model.get("wkt") != "")
        {
        var wktier = new ol.format.WKT();
            var feature = wktier.readFeature(model.get("wkt"));
        /*setting model cid and feature change event on feature*/
        model.setFeatureAttributes(feature);
        _source = this.featureOverlay.getSource();
            _source.addFeature(feature);
        }
    },
    removeHandler: function (e) {
        if (e.get("wkt") != null) {
            var feature = ol3Helper.searchFeatureInCollectionsById(e.collection, e.cid);
            if (feature) {
                e.collection.features.remove(feature);
            }
        }
    }



});
