// js/app.js
var app = app || {};
var ENTER_KEY = 13;
function ajax11() {
    return $.ajax({
        type: 'POST',
        data: { pName: "nwash", group: layerGroupName },
        url: siteurl + 'Draw/GetGroupLayers',
        dataType: 'json',
        success: function (data) {
            layers_list = data;
        },
        error: function () {
            alert("error1");
        }

    });
}
$.when(ajax11()).done(function (layers_list) {
    $(function () {
        // Kick things off by creating the **App**.
        app.drawView = new app.DrawView();
        app.config = [];
        //for original layer
        app.config1 = [];
        app.savedMessage = [];
        app.messageCounter = 1;
        app.previousDrawInteraction = null;
        app.isCanalMergingOnProcess = false;
        app.selectedCanalButtonId = null;
        app.headCanal = null;
        app.tailCanal = null;
        app.type = "EXISTING_PROJECT";
        app.writeStatusMessage = function (savedStatus) {
            var cssClass = "bg-danger";
            var target = "status_message_" + app.messageCounter;
            if (savedStatus.success) {
                //cssClass = "bg-success";
                cssClass = "alert-success";
            }
            var message = '<p id="' + target + '" class="alert ' + cssClass + '" style="text-align:center;"><strong>' + savedStatus.message + '</strong></p>';
            $("#status_message").append(message);
            app.messageCounter++;
            $("#" + target).fadeOut(7000, function () {
                $(this).remove();
            });
        };
        app.InstanceFactory = function (strClass) {
            var args = Array.prototype.slice.call(arguments, 1);
            var clsClass = eval(strClass);
            function F() {
                return clsClass.apply(this, args);
            }
            F.prototype = clsClass.prototype;
            return new F();
        };

        layers_list.forEach(function (la) {
            //alert(pid);
            if (la.obj_type == 'point') {
                    app.config.push({
                        label: la.layer_display_name,
                        layerGroup: la.layer_group,
                        layerId: la.tbl_name,
                        selectable: true,
                        visibility: true,
                        type: 'Point',
                        icon: la.point_img,
                        legend: la.tbl_name.replace(".", "_") + "-legend",
                        collection: app.PointCollection,
                        model: app.PointLayerModel,
                        view: app.PointLayerView,
                        url: siteurl + "Draw/PointLayers?tblName=" + la.tbl_name +"&pid="+pid,
                        style: function (feature, resolution) {
                            //if called feature.setstyle() it sends only one parameter resolution
                            if (!resolution) {
                                resolution = feature;
                                feature = this;
                            }
                            var style;
                            //if (resolution > 2) {
                                style = new ol.style.Style({
                                    image: new ol.style.Icon(({
                                        src: siteurl + 'editMap/img/editor_img/' + la.point_img,
                                    })),
                                    //text: new ol.style.Text({
                                    //    textAlign: 'left',
                                    //    textBaseline: 'middle',
                                    //    font: '12px Arial',
                                    //    //text: "dddd",
                                    //    text: getText(feature, resolution),
                                    //    fill: new ol.style.Fill({
                                    //        color: '#000000'
                                    //    }),
                                    //    stroke: new ol.style.Stroke({
                                    //        color: '#ffffff',
                                    //        width: 5
                                    //    }),
                                    //    offsetX: 10,
                                    //    offsetY: 0,
                                    //    rotation: 0
                                    //})
                                })
                            //}
                            return [style];
                        },
                        selectedStyle: function (feature, resolution) {
                            if (!resolution) {
                                resolution = feature;
                                feature = this;
                            }
                            var style = new ol.style.Style({
                                image: new ol.style.Circle({
                                    radius: 6,
                                    fill: new ol.style.Fill({
                                        color: 'rgba(47, 226, 250, 0.9)'
                                    })
                                }),
                            })
                            return [style];
                        }
                    });
                
            }
            //---------------------------------------- for polygon ---------------------------------
            else if (la.obj_type == 'polygon') {
                app.config.push({
                    label: la.layer_display_name,
                    layerGroup: la.layer_group,
                    layerId: la.tbl_name,
                    selectable: true,
                    visibility: true,
                    type: 'Polygon',
                    icon: la.point_img,
                    legend: la.tbl_name.replace(".", "_") + "-legend",
                    collection: app.PolygonCollection,
                    model: app.PolygonLayerModel,
                    view: app.PolygonLayerView,
                    url: siteurl + "Draw/PolygonLayers?tblName=" + la.tbl_name + "&pid=" + pid,
                    //        url: site_url + "draw/road/50808",
                    style: function (feature, resolution) {
                        var colorArray = la.obj_color_rgb_opacity.replace("rgb(", "").replace(")", "").split(",");
                        if (!resolution) {
                            resolution = feature;
                            feature = this;
                        }
                        var style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: [colorArray[0], colorArray[1], colorArray[2], colorArray[3]],
                                // color: 'yellow',
                                width: la.line_width,
                            }),
                            fill: new ol.style.Fill({
                                color: 'rgba(0, 0, 255, 0.1)'
                            }),

                        })
                        return [style];
                    },
                    selectedStyle: function (feature, resolution) {
                        if (!resolution) {
                            resolution = feature;
                            feature = this;
                        }
                        var style = [
                            /* We are using two different styles for the polygons:
                             *  - The first style is for the polygons themselves.
                             *  - The second style is to draw the vertices of the polygons.
                             *    In a custom `geometry` function the vertices of a polygon are
                             *    returned as `MultiPoint` geometry, which will be used to render
                             *    the style.
                             */
                            new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: 'green',
                                    width: 3
                                }),
                                fill: new ol.style.Fill({
                                    color: 'rgba(255, 0, 0, 0.1)'
                                })
                            }),
                            new ol.style.Style({
                                image: new ol.style.Circle({
                                    radius: 5,
                                    fill: new ol.style.Fill({
                                        color: 'rgba(255,153,51, 0.7)'
                                    })
                                }),
                                geometry: function (feature) {
                                    // return the coordinates of the first ring of the polygon
                                    var coordinates = feature.getGeometry().getCoordinates()[0];
                                    return new ol.geom.MultiPoint(coordinates);
                                }
                            })
                        ];
                        return style;
                    }
                });
            }
            //---------------------------------------- for line ---------------------------------
            else if (la.obj_type == 'line') {
                app.config.push({
                    label: la.layer_display_name,
                    layerGroup: la.layer_group,
                    layerId: la.tbl_name,
                    selectable: true,
                    visibility: true,
                    type: 'LineString',
                    icon: la.point_img,
                    legend: la.tbl_name.replace(".", "_") + "-legend",
                    collection: app.LineCollection,
                    model: app.LineLayerModel,
                    view: app.LineLayerView,
                    //url: siteurl + "MapEdit/LineLayers?tblName=" + la.tblName + "&basin=" + basin_val + "&subbasin=" + sub_basin_val,
                    url: siteurl + "Draw/LineLayers?tblName=" + la.tbl_name+"&pid="+pid,
                    //        url: site_url + "draw/road/50808",
                    style: function (feature, resolution) {
                        //console.log(feature);
                        var colorArray = la.obj_color_rgb_opacity.replace("rgb(", "").replace(")", "").split(",");
                        if (!resolution) {
                            resolution = feature;
                            feature = this;
                        }
                        var style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: [colorArray[0], colorArray[1], colorArray[2], colorArray[3]],
                                width: la.line_width,
                            }),
                            fill: new ol.style.Fill({
                                color: 'rgba(0, 0, 255, 0.1)'
                            }),

                        })
                        return [style];
                    },
                    selectedStyle: function (feature, resolution) {
                        if (!resolution) {
                            resolution = feature;
                            feature = this;
                        }

                        var style = [
                            new ol.style.Style({
                                fill: new ol.style.Fill({
                                    color: 'rgba(255, 255, 255, 0.2)'
                                }),
                                stroke: new ol.style.Stroke({
                                    color: '#00ff00',
                                    width: 2
                                }),
                            }),
                            new ol.style.Style({
                                image: new ol.style.Circle({
                                    radius: 5,
                                    fill: new ol.style.Fill({
                                        color: 'rgba(255,153,51, 0.7)'
                                    }),
                                }),
                                geometry: function (feature) {
                                    // return the coordinates of the first ring of the polygon
                                    var coordinates = feature.getGeometry().getCoordinates();
                                    return new ol.geom.MultiPoint(coordinates);
                                }
                            })
                        ];
                        return style;
                    }
                });
            }

        });

        //alert(configItem.layerId);
        app.originalCollection = new app.LayerCollection();


        _.each(app.config1, function (configItem, key, object) {
            app.collection = new configItem.collection(configItem.layerId, configItem.model, configItem.view, configItem.url, configItem.visibility, configItem.selectable, configItem.style, configItem.selectedStyle, configItem.layerGroup, configItem.type, configItem.icon);
            app.originalCollection.add(
                new app.LayerModel({
                    layer: app.collection,
                    type: "overlay",
                    name: configItem.layerId,
                    label: configItem.label,
                    layerGroup: configItem.layerGroup,
                    layerType: configItem.type
                }));
        });

        app.layerCollection = new app.LayerCollection();
        _.each(app.config, function (configItem, key, object) {
            app.collection = new configItem.collection(configItem.layerId, configItem.model, configItem.view, configItem.url, configItem.visibility, configItem.selectable, configItem.style, configItem.selectedStyle, configItem.layerGroup, configItem.type, configItem.icon);
            app.layerCollection.add(
                new app.LayerModel({
                    layer: app.collection,
                    type: "overlay",
                    name: configItem.layerId,
                    label: configItem.label,
                    legend: configItem.legend,
                    layerGroup: configItem.layerGroup,
                    layerType: configItem.type
                }));
        });
        app.drawView.renderLayersView();
    });
});

////-------------------------------------------- this is to display text in map point or line-------------------------------------
//var getText = function (feature, resolution) {
//    //console.log(feature);
//    //var type = dom.text.value;
//    var maxResolution = 0.6;
//    var text = feature.name;
//    //var text = "";
//        if (resolution > maxResolution || text === null) {
//            text = '';
//        }
//    //text = '';
//    return text;
//};

app.refresh = function () {
    if (app.drawView.countUnsavedItems() > 0) {
        if (confirm("There are still unsaved items. Your changes will be lost if you refresh this page without saving. Do you still want to Refresh?")) {
            window.location = window.location.href;
        }
    } else {
        window.location = window.location.href;
    }
}