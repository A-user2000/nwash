app.LineLayerModel = app.LineModel.fullExtend({
    defaults: {
    },
    initialize: function () {
        this.parent = app.ChildCollection.__super__;
        this.parent.initialize.call(this);
        this.listenTo(this, 'change', this.modelChanged);
    },
    sync: function (method, model, options) {
        options = options || {};
        var success = options.success;
        options.success = function (resp) {
            success && success(resp);
            model.hasChangedSinceLastSync = false;
            var message = {"layer": "Road", "success": true, "message": "Saved Successfully."};
            app.writeStatusMessage(message);
            app.drawView.updateUnsavedItems();
        };
        options.error = function (resp)
        {
            var message = {"layer": "Road", "success": false, "message": "Error Saving."};
            app.writeStatusMessage(message);
        }
        return Backbone.sync(method, model, options);
    },
    setFeatureAttributes: function (feature)
    {
        feature.setId(this.cid);
        //console.log(this.collection.layerId);
        //if (this.collection.layerId == "existing_projects.pipe") {
        //    var kk = this.attributes["pipe_no"];
        //}
        feature.name = this.get('feature_name');
            var kk = this.attributes["pipe_name"];
            feature.setStyle(function (feature, resolution) {
                if (!resolution) {
                    resolution = feature;
                    feature = this;
                }
                if (resolution < 1.5) {
                    var style = new ol.style.Style({
                        stroke: new ol.style.Stroke({
                            color: 'rgba(0,0,255, 1)',
                            width: 2,
                        }),
                        text: new ol.style.Text({
                            textAlign: 'left',
                            textBaseline: 'middle',
                            font: '10px Arial',
                            text: kk,
                            fill: new ol.style.Fill({
                                color: '#000000'
                            }),
                            stroke: new ol.style.Stroke({
                                color: '#ffffff',
                                width: 2
                            }),
                            offsetX: 10,
                            offsetY: 0,
                            rotation: 0
                        })
                    })
                    return [style];
                }
                else
                {
                    var style = new ol.style.Style({
                        stroke: new ol.style.Stroke({
                            color: 'rgba(0,0,255, 1)',
                            width: 2,
                        }),
                    })
                    return [style];
                }
            })
    /*-------------------------------------------------------------------------------------------------------*/
    /*----------------------------------setting style to structure-----------------------------*/
    /*-------------------------------------------------------------------------------------------------------*/
        //if (this.attributes["road_class"] == "NH") {
        //    feature.setStyle(function (feature, resolution) {
        //        //console.log(feature);
        //        if (!resolution) {
        //            resolution = feature;
        //            feature = this;
        //        }
        //        var style = new ol.style.Style({
        //            stroke: new ol.style.Stroke({
        //                //color: 'rgba(170, 1, 20, 1)',rgb(183,109,72,1)
        //                color: 'rgba(206,123,81, 1)',
        //                width: 3,
        //            })
        //        })
        //        return [style];
        //    })
        //}
        //else if (this.attributes["road_class"] == "PH") {
        //    feature.setStyle(function (feature, resolution) {
        //        //console.log(feature);
        //        if (!resolution) {
        //            resolution = feature;
        //            feature = this;
        //        }
        //        var style = new ol.style.Style({
        //            stroke: new ol.style.Stroke({
        //                color: 'rgba(240,240,43, 1)',
        //                //color: 'rgba(10, 10, 255, 1)',
        //                width: 3,
        //            })

        //        })
        //        return [style];
        //    })
        //}
        //else if (this.attributes["road_class"] == "PR") {
        //    feature.setStyle(function (feature, resolution) {
        //        //console.log(feature);
        //        if (!resolution) {
        //            resolution = feature;
        //            feature = this;
        //        }
        //        var style = new ol.style.Style({
        //            stroke: new ol.style.Stroke({
        //                color: 'rgba(153,153,153, 1)',
        //                //color: 'rgba(158, 115, 35, 1)',
        //                width: 3,
        //            })

        //        })
        //        return [style];
        //    })
        //}
        //else if (this.attributes["road_class"] == "LRN") {
        //    feature.setStyle(function (feature, resolution) {
        //        //console.log(feature);
        //        if (!resolution) {
        //            resolution = feature;
        //            feature = this;
        //        }
        //        var style = new ol.style.Style({
        //            stroke: new ol.style.Stroke({
        //                color: 'rgba(110,198,85, 1)',
        //                //color: 'rgba(54, 143, 27, 1)',
        //                width: 2,
        //            })

        //        })
        //        return [style];
        //    })
        //}
        //else if (this.attributes["road_class"] == "SUR") {
        //    feature.setStyle(function (feature, resolution) {
        //        //console.log(feature);
        //        if (!resolution) {
        //            resolution = feature;
        //            feature = this;
        //        }
        //        var style = new ol.style.Style({
        //            stroke: new ol.style.Stroke({
        //                color: 'rgba(236, 31, 31, 1)',
        //                //color: 'rgba(54, 143, 27, 1)',
        //                width: 3,
        //            }),

        //        })
        //        return [style];
        //    })
        //}
        //else
        //{
        //    feature.setStyle(function (feature, resolution) {
        //        //console.log(feature);
        //        if (!resolution) {
        //            resolution = feature;
        //            feature = this;
        //        }
        //        var style = new ol.style.Style({
        //            stroke: new ol.style.Stroke({
        //                color: 'rgba(10, 10, 25, 0.9)',
        //                width: 3,
        //            }),
        //            fill: new ol.style.Fill({
        //                color: 'rgba(0, 0, 255, 0.1)'
        //            })
        //        })
        //        return [style];
        //    })
        //}
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
                //type: 'DELETE',
                success: function (result) {
                    if (result === "true")
                    {
                        that.delete_vector_and_model();
                        alert("Line deleted.");
                        $("#prop_window").css("visibility","hidden");
                    } else
                    {
                        alert("Failed to delete this line");
                    }
                },
                error: function (e)
                {
                    alert("Please check if you are connected to internet3.");
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