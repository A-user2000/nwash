app.PolygonLayerModel = app.PolygonModel.fullExtend({
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
            var message = {"layer": "hh", "success": true, "message": "Saved Successfully."};
            app.writeStatusMessage(message);
            app.drawView.updateUnsavedItems();
        };
        options.error = function (resp)
        {
            var message = {"layer": "hh", "success": false, "message": "Error  Saving."};
            app.writeStatusMessage(message);
        }
        return Backbone.sync(method, model, options);
    },
    setFeatureAttributes: function (feature)
    {
        feature.setId(this.cid);
    },
    get_defaults: function (merge_obj)
    {
        var attrs = clone(road_attrs);
        for (var attr in merge_obj)
        {
            attrs[attr] = merge_obj[attr];
        }
        return attrs;

    },
    delete_feature: function ()
    {
        var primary_id = document.querySelector('.primary_field').id;
        var that = this;
        if (this.id > 0)
        {
            $.ajax({
                url: siteurl + "Draw/DeleteAttributes",
                type: 'POST',
                data: { 'tbl': identifiedLayerName, 'primary_val': this.id, 'primary_id': primary_id },
                success: function (result) {
                    if (result === "true")
                    {
                        that.delete_vector_and_model();
                        alert("Polygon is deleted.");
                        $("#prop_window").css("visibility","hidden");
                    } else
                    {
                        alert("Failed to delete this polygon");
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
        $('#house a:first').tab('show');
    }


});