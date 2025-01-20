app.GeoStructureModel = app.PointModel.fullExtend({
    defaults: {},
    initialize: function () {
        this.parent = app.ChildCollection.__super__;
        this.parent.initialize.call(this);
        this.listenTo(this, 'change', this.modelChanged);
    }, sync: function (method, model, options) {
        options = options || {};
        var success = options.success;
        options.success = function (resp) {
            success && success(resp);
            model.hasChangedSinceLastSync = false;
            var message = {"layer": "canal", "success": true, "message": "Structure Saved Successfully."};
            app.writeStatusMessage(message);
            app.drawView.updateUnsavedItems();
        };
        options.error = function (resp)
        {
            console.log(resp);
            var message = {"layer": "canal", "success": false, "message": "Error  Saving Structure."};
            app.writeStatusMessage(message);
        }
        return Backbone.sync(method, model, options);
    },
    setFeatureAttributes: function (feature)
    {
        feature.setId(this.cid);
        feature.name = this.get('str_type');
    },
    get_defaults: function (merge_obj)
    {
        var attrs = clone(geo_struct_attrs);
        for (var attr in merge_obj)
        {
            attrs[attr] = merge_obj[attr];
        }
        return attrs;

    },
    snapToCanal: function (coordinates)
    {
        var layer_model = app.layerCollection.find({name: "geocanal"});
        //bbcollection=backbone collection Don't be confused with OL3 collection
        bbcollection = layer_model.get("layer");
        vectorSource = bbcollection.featureOverlay.getSource();
        canal_feature = vectorSource.getClosestFeatureToCoordinate(coordinates);
        feature_id = canal_feature.getId();
        canal_model = bbcollection.get(feature_id);
        this.set("canal_id", canal_model.get("id"));
        this.set("canal_name", canal_model.get("canal_name"));
    },
    /*modelChanged: function ()
    {
        var _collection = app.drawView.getCollectionInstance(this.cid);
        if (_collection)
        {
            _view = new _collection.view({
                model: this
            });
            $("#prop_window").html(_view.render().el);
            $('#tab a:last').tab('show');
        }
    },*/
    delete_feature: function ()
    {
        var that = this;
        var pcode = this.get("pcode");
        if (this.id > 0)
        {
            $.ajax({
                url: base_url + "draw/geostructure/" + pcode + "/" + this.id,
                type: 'DELETE',
                success: function (result) {
                    if (result === "true")
                    {
                        that.delete_vector_and_model();
                    } else
                    {
                        alert("Failed to delete this command area");
                    }
                },
                error: function (e)
                {
                    alert("Please check if you are connected to internet.");
                }
            });
        } else {
            this.delete_vector_and_model();
        }
    },
    delete_vector_and_model: function ()
    {
        var features_arr = this.collection.features.getArray();
        for (var i = 0; i < features_arr.length; i++)
        {
            var feature = features_arr[i];
            if (feature.getId() == this.cid)
            {
                app.drawView.select.getFeatures().remove(feature);
                this.collection.features.remove(feature);
                break;
            }
        }
        this.collection.remove(this);
        $('#tab a:first').tab('show');
    }

});