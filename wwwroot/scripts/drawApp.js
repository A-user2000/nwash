// js/app.js

var app = app || {};
var ENTER_KEY = 13;
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
    app.writeStatusMessage = function (savedStatus)
    {
        var cssClass = "bg-danger";
        var target = "status_message_" + app.messageCounter;
        if (savedStatus.success)
        {
            cssClass = "bg-success";
        }
        var message = '<p id="' + target + '" class="' + cssClass + '" style="text-align:center;"><strong>' + savedStatus.message + '</strong></p>';
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

    app.config.push({
        label: "Project",
        layerId: 'project',
        selectable: true,
        visibility: true,
        type: 'Point',
        legend: 'project-legend',
        collection: app.PointCollection,
        model: app.ProjectModel,
        view: app.ProjectView,
        url: site_url + "draw/project/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/project.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
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
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
//                console.log(resolution);
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/project.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
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
    });

    app.config.push({
        label: "Pipe",
        layerId: 'geocanal',
        selectable: true,
        visibility: true,
        type: 'LineString',
        legend: 'pipe-legend',
        collection: app.LineCollection,
        model: app.GeoCanalModel,
        view: app.GeoCanalView,
        url: site_url + "draw/geocanal/" + pid,
        style: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                stroke: new ol.style.Stroke({
                    color: 'blue',
                    width: 3
                }),
                fill: new ol.style.Fill({
                    color: 'rgba(0, 0, 255, 0.1)'
                })
            })
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
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
                        var coordinates = feature.getGeometry().getCoordinates();
                        return new ol.geom.MultiPoint(coordinates);
                    }
                })
            ];
            return style;
        }
    });
    app.config.push({
        label: "Reservoir",
        layerId: 'reservoir',
        selectable: true,
        visibility: true,
        type: 'Point',
        legend: 'reservoir-legend',
        collection: app.PointCollection,
        model: app.ReservoirModel,
        view: app.ReservoirView,
        url: site_url + "draw/reservoir/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/reservoir.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 10,
                    offsetY: -10,
                    rotation: 0
                })
            })
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
//                console.log(resolution);
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/reservoir.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 10,
                    offsetY: -10,
                    rotation: 0
                })
            })
            return [style];
        }
    });

    app.config.push({
        label: "Tap",
        layerId: 'tap',
        selectable: true,
        visibility: true,
        type: 'Point',
        legend: 'tap-legend',
        collection: app.PointCollection,
        model: app.TapModel,
        view: app.TapView,
        url: site_url + "draw/tap/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/tap.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 10,
                    offsetY: -10,
                    rotation: 0
                })
            })
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
//                console.log(resolution);
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/tap-.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 10,
                    offsetY: -10,
                    rotation: 0
                })
            })
            return [style];
        }
    });

    app.config.push({
        label: "Junction",
        layerId: 'junction',
        selectable: true,
        visibility: true,
        type: 'Point',
        legend: 'junction-legend',
        collection: app.PointCollection,
        model: app.JunctionModel,
        view: app.JunctionView,
        url: site_url + "draw/junction/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/junction.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 10,
                    offsetY: -10,
                    rotation: 0
                })
            })
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/junction.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 10,
                    offsetY: -10,
                    rotation: 0
                })
            })
            return [style];
        }
    });
    app.config.push({
        label: "Project Coverage",
        layerId: 'coverage',
        selectable: true,
        visibility: true,
        type: 'Polygon',
        legend: 'coverage-legend',
        collection: app.PolygonCollection,
        model: app.coverageModel,
        view: app.coverageView,
        url: site_url + "draw/coverage/" + pid,
        style: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                stroke: new ol.style.Stroke({
                    color: 'yellow',
                    width: 3
                }),
                fill: new ol.style.Fill({
                    color: 'rgba(0, 0, 255, 0.1)'
                })
            });
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
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
    app.config.push({
        label: "Water Source",
        layerId: 'source',
        selectable: true,
        visibility: true,
        type: 'Point',
        legend: 'water-source-legend',
        collection: app.PointCollection,
        model: app.SourceModel,
        view: app.SourceView,
        url: site_url + "draw/source/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/source.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#0000FF'
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
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
//                console.log(resolution);
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/source.png',
                    imgSize: [25, 25]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
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
    });

    app.config.push({
        label: "Structure",
        layerId: 'structure',
        selectable: true,
        visibility: true,
        type: 'Point',
        legend: 'structure-legend',
        collection: app.PointCollection,
        model: app.StructureModel,
        view: app.StructureView,
        url: site_url + "draw/structure/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/structure.png',
                    imgSize: [25, 21]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 10,
                    offsetY: -10,
                    rotation: 0
                })
            })
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
//                console.log(resolution);
            }
            var style = new ol.style.Style({
                image: new ol.style.RegularShape({
                    fill: null,
                    stroke: new ol.style.Stroke({
                        color: '#33cc33',
                        width: 2
                    }),
                    points: 4,
                    radius: 10,
                    angle: Math.PI / 4
                }),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 10,
                    offsetY: -10,
                    rotation: 0
                })
            })
            return [style];
        }
    });
    app.originalCollection = new app.LayerCollection();
    app.config1.push({
        label: "Pipe Drawn Alignment",
        layerId: 'pipeDrawnalignment',
        selectable: false,
        visibility: true,
        type: 'LineString',
        legend: 'pipe-drawn-legend',
        collection: app.LineCollection,
        model: app.pipeDrawnalignmentModel,
        view: app.pipeDrawnalignmentView,
        url: site_url + "draw/pipe_drawn_alignment/" + pid,
        style: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                stroke: new ol.style.Stroke({
                    color: 'brown',
                    width: 3
                }),
                fill: new ol.style.Fill({
                    color: 'rgba(165, 89, 89,0.1)'
                })
            })
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
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
                        var coordinates = feature.getGeometry().getCoordinates();
                        return new ol.geom.MultiPoint(coordinates);
                    }
                })
            ];
            return style;
        }
    });

    app.config1.push({
        label: "Pipe Route Point",
        layerId: 'pipeRoutepoint',
        selectable: false,
        visibility: true,
        type: 'Point',
        legend: 'pipe-route-legend',
        collection: app.PointCollection,
        model: app.pipeRoutepointModel,
        view: app.pipeRoutepointView,
        url: site_url + "draw/pipe_route_point/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/pipeRoutepoint.png',
                    imgSize: [25, 30]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#0000FF'
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
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
//                console.log(resolution);
            }
            var style = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchorOrigin: 'bottom-left',
                    anchor: [12.5, 12.5],
                    anchorXUnits: 'pixels',
                    anchorYUnits: 'pixels',
                    src: base_url + 'assets/img/pipeRoutepoint.png',
                    imgSize: [25, 30]
                })),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
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
    });
    _.each(app.config1, function (configItem, key, object) {
        app.collection = new configItem.collection(configItem.layerId, configItem.model, configItem.view, configItem.url, configItem.visibility, configItem.selectable, configItem.style, configItem.selectedStyle);
        app.originalCollection.add(
                new app.LayerModel({
                    layer: app.collection,
                    type: "overlay",
                    name: configItem.layerId,
                    label: configItem.label
                }));
    });

    app.layerCollection = new app.LayerCollection();
    _.each(app.config, function (configItem, key, object) {
        app.collection = new configItem.collection(configItem.layerId, configItem.model, configItem.view, configItem.url, configItem.visibility, configItem.selectable, configItem.style, configItem.selectedStyle);
        app.layerCollection.add(
                new app.LayerModel({
                    layer: app.collection,
                    type: "overlay",
                    name: configItem.layerId,
                    label: configItem.label,
                    legend: configItem.legend
                }));
    });
    app.drawView.renderLayersView();
});
var getText = function (feature, resolution) {
    //var type = dom.text.value;
    var maxResolution = 0.6;
    var text = feature.name;
    if (resolution > maxResolution || text === null) {
        text = '';
    }
    /*else if (type == 'hide') {
     text = '';
     } else if (type == 'shorten') {
     text = text.trunc(12);
     } else if (type == 'wrap') {
     text = stringDivider(text, 16, '\n');
     }*/

    return text;
};

app.refresh = function ()
{
    if (app.drawView.countUnsavedItems() > 0)
    {
        if (confirm("There are still unsaved items. Your changes will be lost if you refresh this page without saving. Do you still want to Refresh?"))
        {
            window.location = window.location.href;
        }
    } else
    {
        window.location = window.location.href;
    }
}

