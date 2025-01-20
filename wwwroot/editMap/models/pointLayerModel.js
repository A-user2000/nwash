app.PointLayerModel = app.PointModel.fullExtend({
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
        //console.log(this.collection.layerId);
        feature.setId(this.cid);
        //feature.name = this.get('name');
        var icons = this.collection.icon;
        /*-------------------------------------------------------------------------------------------------------*/
        /*----------------------------------setting style to structure-----------------------------*/
        /*-------------------------------------------------------------------------------------------------------*/
        if (this.collection.layerId == "existing_projects.junction") {
            var kk = this.attributes["junc_no"];
        }
        else if (this.collection.layerId == "existing_projects.tap") {
            var kk = this.attributes["tap_no"];
            //var html = '<option value="' + this.attributes["lon"] + ',' + this.attributes["lat"] + '">' + this.attributes["tap_no"] + '</option>';
            //$("#edit_map_search").append(html);            
        }
        else if (this.collection.layerId == "existing_projects.project_details") {
            var kk = this.attributes["pro_name"];
        }
        else if (this.collection.layerId == "existing_projects.reservoir") {
            var kk = this.attributes["rvt_no"];
        }
        else if (this.collection.layerId == "existing_projects.structure") {
            var kk = this.attributes["str_no"];
        }
        else if (this.collection.layerId == "existing_projects.water_source") {
            var kk = this.attributes["sou_name"];
        }
        else if (this.collection.layerId == "existing_projects.leftout_taps") {
            var kk = this.attributes["tap_no"];
        }
            feature.setStyle(function (feature, resolution) {
                if (!resolution) {
                    resolution = feature;
                    feature = this;
                }
                if (resolution < 1.5) {
                    var style = new ol.style.Style({
                        image: new ol.style.Icon(({
                            src: siteurl + 'editMap/img/editor_img/' + icons,
                        })),
                        text: new ol.style.Text({
                            textAlign: 'left',
                            textBaseline: 'middle',
                            font: '10px Arial',
                            //text: "dddd",
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
                        image: new ol.style.Icon(({
                            src: siteurl + 'editMap/img/editor_img/' + icons,
                        }))
                    })
                    return [style];
                }
            })
        
        
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
                        alert("Point is deleted.");
                        $("#prop_window").css("visibility","hidden");
                    } else
                    {
                        alert("Failed to delete this Point");
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