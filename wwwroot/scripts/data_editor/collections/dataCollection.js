var editorApp = editorApp || {};
editorApp.DataCollection = Backbone.Collection.extend({
    url: null,
    //model:app.PointModel,
    initialize: function (collection_type, model, view, url) {
        var that = this;
        //injecting model and view into collection from the config
        this.url = url;
        this.collection_type = collection_type;
        this.model = model;
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
        //e is the collection here whose fetch has been just completed
        if (e.models.length > 0)
        {
            /* var model = e.models[0];
             var wktier = new ol.format.WKT();
             var feature = wktier.readFeature(model.get("wkt"));
             var geom = feature.getGeometry();
             //this.map.getView().setCenter(geom.getCoordinates());*/
        }
    },
    /*display fetched model into map*/
    forEachModelFetched: function (model)
    {
        /*var wktier = new ol.format.WKT();
         var feature = wktier.readFeature(model.get("wkt"));
         var geom = feature.getGeometry();
         //this.map.getView().setCenter(geom.getCoordinates());
         
         model.setFeatureAttributes(feature);
         _source = this.featureOverlay.getSource();
         _source.addFeature(feature);*/
        var view = new this.view({model: model});
        view.render();
        //console.log(view.el);
        $("#" + this.collection_type + "_tab .segment").append(view.el);
        $(".accordion").find(".title:first").addClass("active");
        $(".accordion").find(".content:first").addClass("active");
    }
});
