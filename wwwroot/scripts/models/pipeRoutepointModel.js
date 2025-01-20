app.pipeRoutepointModel = app.PointModel.fullExtend({
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
            var message = {"layer": "pipeRoutepoint", "success": true, "message": "Pipe Route Point Saved Successfully."};
            app.writeStatusMessage(message);
            app.drawView.updateUnsavedItems();
        };
        options.error = function (resp)
        {
            console.log(resp);
            var message = {"layer": "pipeRoutepoint", "success": false, "message": "Error  Saving Source."};
            app.writeStatusMessage(message);
        }
        return Backbone.sync(method, model, options);
    },
    setFeatureAttributes: function (feature)
    {
        feature.setId(this.cid);
        feature.name = this.get('pipe_part');
    },
    get_defaults: function (merge_obj)
    {
//        var attrs = clone(pipe_route_point);
//        for (var attr in merge_obj)
//        {
//            attrs[attr] = merge_obj[attr];
//        }
//        return attrs;

    },
    delete_feature: function ()
    {
//        var that = this;
//        var pid = this.get("pro_uuid");
//        if (this.id > 0)
//        {
//            $.ajax({
//                url: base_url + "draw/pipe_route_point/" + pid + "/" + this.id,
//                type: 'DELETE',
//                success: function (result) {
//                    if (result === "true")
//                    {
//                        that.delete_vector_and_model();
//                    } else
//                    {
//                        alert("Failed to delete this Source");
//                    }
//                },
//                error: function (e)
//                {
//                    alert("Please check if you are connected to internet.");
//                }
//            });
//        } else {
//            this.delete_vector_and_model();
//        }
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