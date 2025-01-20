/* global ol, zoomInToolHelper, zoomOutToolHelper, panToolHelper, identifyToolHelper, googleGroup */

var map;
var markers;
var overlay;
function init() {

    var overlayOpacity = 0.5;
    var maxOpacity = 1;
    var showLegend = false;
    //OpenLayers.ProxyHost = "http://localhost/armp/map/proxy?url=";
    //OpenLayers.ProxyHost = baseurl + "map/proxy?url=";

    // for controls

    //var navigation_control = new ol.control.Navigation({});
    var controls_array = [
        //new OpenLayers.Control.PanZoomBar({}),
        //new ol.control.KeyboardDefaults(),
        new ol.control.ScaleLine()
//        var scaleLineControl = new ol.control.ScaleLine({
//    target:document.getElementById('scale')
//});
    ];

    //var bounds = new OpenLayers.Bounds(-20037508.34, -20037508.34, 20037508.34, 20037508.34);
    //8912260.091123294,3042341.5240906863,9818849.801202029,3561365.832413727);

//    var options = {
//        controls: controls_array,
//        maxExtent: new OpenLayers.Bounds(-20037508.34, -20037508.34, 20037508.34, 20037508.34),
//        //8912260.091123294,3042341.5240906863,9818849.801202029,3561365.832413727),
//        //maxResolution: 'auto',
//        resolutions: [156543.03390625, 78271.516953125, 39135.7584765625, 19567.87923828125, 9783.939619140625, 4891.9698095703125, 2445.9849047851562, 1222.9924523925781, 611.4962261962891, 305.74811309814453, 152.87405654907226, 76.43702827453613, 38.218514137268066, 19.109257068634033, 9.554628534317017, 4.777314267158508, 2.388657133579254, 1.194328566789627, 0.5971642833948135, 0.29858214169740677, 0.14929107084870338, 0.07464553542435169, 0.037322767712175846, 0.018661383856087923, 0.009330691928043961, 0.004665345964021981, 0.0023326729820109904, 0.0011663364910054952, 5.831682455027476E-4, 2.915841227513738E-4, 1.457920613756869E-4],
//        projection: new OpenLayers.Projection('EPSG:900913'),
//        allOverlays: true
//    };
//    
//    
//    var raster = new ol.layer.Tile({
//        source: new ol.source.OSM()
//                ///////////////////////////////////// loading stamen /////////////////////////        
//                //        source: new ol.source.Stamen({
//                //            layer:'watercolor'
//                //        })
//    });
//    var district_line = new ol.layer.Tile({
//        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
//        source: new ol.source.TileWMS({
//            url: 'http://geoserver.aviyaan.com/geoserver/nhydro_01/wms',
//            params: {
//                'LAYERS': 'nhydro_01:District_Boundary_Line_2017_WGS84',
//                'TILED': true,
//            },
//            serverType: 'geoserver',
//            projection: 'EPSG:4269'
//        }),
//        zIndex:25
//        
//    });
    var container = document.getElementById('popup');
    var content = document.getElementById('popup-content');
    var closer = document.getElementById('popup-closer');
    overlay = new ol.Overlay({
        element: container,
        autoPan: true,
        autoPanAnimation: {
            duration: 250
        }
    });

    closer.onclick = function () {
        overlay.setPosition(undefined);
        closer.blur();
        return false;
    };


    var interactions = ol.interaction.defaults({
        shiftDragZoom: false
    });
//interactions.push(new ol.interaction.DragZoom({
//  duration: 200,
//  condition: function(mapBrowserEvent) {
//    var originalEvent = mapBrowserEvent.originalEvent;
//    return (
//      originalEvent.ctrlKey &&
//      !(originalEvent.metaKey || originalEvent.altKey) &&
//      !originalEvent.shiftKey);
//  }
//}));

    map = new ol.Map({
        //layers: [raster, district_line],
        //layers: ,
        //controls: ol.control.defaults().extend([scaleLineControl]),
        overlays: [overlay],
        controls: controls_array,
        interactions: interactions,
        target: 'mapDiv',
        view: new ol.View({
            center: ol.proj.fromLonLat([84.1240, 28.3949]),
            extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
            //maxExtent: new ol.proj.Projection(-20037508.34, -20037508.34, 20037508.34, 20037508.34),
            //center: [84.1240, 28.3949],
            minZoom: 3
        })
    });



    //map = new OpenLayers.Map('mapDiv', options);
//
//    map.on({
//        moveend: function (e) {
//            history_tool.record_screen_extent();
//            if (e.zoomChanged) {
//                $("#scale").html("<strong>Scale: </strong>1:" + Math.round(map.getScale()));
//            }
//
//        },
//        zoomend: function (e) {
//            if ($("#identify-view-draggable").is(":visible"))
//            {
//                var xy = map.getPixelFromLonLat(identifyToolHelper.tool.position);
//                var x = xy.x;
//                var y = xy.y;
//                $("#identify-view-draggable").css("left", x).css("top", y);
//            }
//        }
//    });
    map.on('moveend', function () {
        //record extend
        history_tool.record_screen_extent();

        //get zoom level to display in map
        var vi = map.getView();
        var zoomVal = parseInt(vi.getZoom());
        var zoomInfo = '<strong>Zoom Level : </strong>' + zoomVal;
        $('#zoom').html(zoomInfo);
    });
//    var source = new Proj4js.Proj('EPSG:900913');    //source coordinates will be in Longitude/Latitude
//    var dest = new Proj4js.Proj('EPSG:4326');
    map.on("pointermove", function (e) {
        var position = ol.proj.transform(e.coordinate, 'EPSG:3857', 'EPSG:4326');
        //console.log(Proj4js('EPSG:900913', 'EPSG:4326', position));
        //var position = map.getLonLatFromPixel(e.xy);
        //position.transform("EPSG:900913","EPSG:4326");
        position.x = position[0];
        position.y = position[1];
        //console.log(Proj4js.transform(source, dest, position));
        $("#latlon").html("<strong>Lat, Lon : </strong>" + position.y.toFixed(5) + ', ' + position.x.toFixed(5))
    });

//    markers = new OpenLayers.Layer.Markers("Markers");
//    markers.id = "Markers";
//    map.addLayer(markers);

//    var markers = new ol.layer.Vector({
//       source:new ol.source.Vector({
//           features: [
//             new ol.Feature({
//                 geometry: new ol.geom.Point(ol.proj.fromLonLat([4.35247, 50.84673]))
//             })
//         ]
//       }) 
//    });
//map.addLayer(markers);
//    map.events.register("click", map, function (e) {
//        markers.setZIndex(1442435);
//        //var position = this.events.getMousePosition(e);
//        if (activate === true) {
//            clicked = clicked + 1;
//            if (type === 'line' && clicked > 2) {
//                vec_line.removeAllFeatures();
//                markers.clearMarkers();
//                clicked = 1;
//                length = 0;
//                lat = '';
//                lng = '';
//            }
//            var position = map.getLonLatFromPixel(e.xy);
//            position.x = position.lon;
//            position.y = position.lat;
////            Proj4js.transform(source, dest, position);
//            var size = new OpenLayers.Size(21, 25);
//            var offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);
//            var icon = new OpenLayers.Icon('assets/img/new_marker_red.png', size, offset);
//            var markerslayer = map.getLayer('Markers');
//
//            markerslayer.addMarker(new OpenLayers.Marker(position, icon));
//            calculate(position);
//        }
//    });
    var markerStyle = new ol.style.Style({
        image: new ol.style.Icon(/** @type {olx.style.IconOptions} */ ({
            anchor: [0.5, 1],
            opacity: 1,
            scale: 0.8,
            src: 'assets/img/new_marker_red.png'
        }))
    });

    markers = new ol.layer.Vector({
        source: new ol.source.Vector({
        }),
        style: markerStyle,
        zIndex: 14424

    });
    //markers.set('name',"Markers")
    map.addLayer(markers);

//    function addMarker(coordinate1) {
//
//
//  var iconFeatures = [];
//
//  var iconFeature = new ol.Feature({
//    geometry: new ol.geom.Point(coordinate1),
//    name: 'Markers'
//  });
//
//  markers.getSource().addFeature(iconFeature);
//}


    map.on('click', function (e) {

        //addMarker(e.coordinate);
//        var markers = new ol.layer.Vector({
//       source:new ol.source.Vector({
//           features: [
//             new ol.Feature({
//                 type:new ol.style.Style({
//                    image: new ol.style.Icon({
//                        anchor:[0.5,1],
//                        src:'assets/img/new_marker_red.png'
//                    }) 
//                 }),
//                 geometry: new ol.geom.Point(e.coordinate)
//                 
//             })
//         ]
//       }) 
//    });
        //markers.setZIndex(1442435);
        //map.addLayer(markers);
        //var position = this.events.getMousePosition(e);
        if (activate === true) {
            clicked = clicked + 1;
            if (type === 'line' && clicked > 2) {
                vec_line.getSource().clear();
                markers.getSource().clear();
                $('#line_distance').html('Line Distance');
                clicked = 1;
                length = 0;
                lat = '';
                lng = '';
            }
////            var position = map.getLonLatFromPixel(e.xy);
//            var position = e.coordinate;
////            position.x = position.lon;
////            position.y = position.lat;
////            Proj4js.transform(source, dest, position);
////            var size = new OpenLayers.Size(21, 25);
////            var offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);
////            var icon = new OpenLayers.Icon('assets/img/new_marker_red.png', size, offset);
//            var markerslayer = map.getLayers('Markers');
//////
//            markerslayer.addMarker(e.coordinate);
            var iconFeatures = [];

            var iconFeature = new ol.Feature({
                geometry: new ol.geom.Point(e.coordinate),
                name: 'Markers'
            });

            markers.getSource().addFeature(iconFeature);
            calculate(e.coordinate);
        }
    });

    loadAllThemes();
    map.getView().fit([8912260.091133313, 3042341.524138276, 9818849.801192472, 3561365.8324687113]);
//map.addControl(new ol.control.ZoomToExtent({
//                    extent: [8912260.091133313, 3042341.524138276, 9818849.801192472, 3561365.8324687113]
//                }));
//map.addInteraction(zoomInToolHelper.tool);
    //map.addInteraction(zoomInToolHelper.tool);
    //map.addInteraction(zoomOutToolHelper.tool);
    //map.addInteraction(panToolHelper.tool);
//    map.addControl(identifyToolHelper.tool);
    googleGroup.layerCheckedExclusive(event, 'Open Street Map', this);
}
var lat = '';
var lng = '';
var poly_lat = '';
var poly_lng = '';
var length = 0;
var type = 'line';
var clicked = 0;
var vec_line = new ol.layer.Vector();
var vec_segment = new ol.layer.Vector();
var vec_polygon = new ol.layer.Vector();
var vec_polygon_clo = new ol.layer.Vector();
var coordinates = [];
var activate = false;
var line_feature = false;
var polyline_feature = false;
var polygon_feature = false;
var poly_count = 0;

function calculate(position) {
    if (lat === '' & lng === '')
    {
        lat = parseFloat(position[1].toFixed(5));
        lng = parseFloat(position[0].toFixed(5));
        coordinates[clicked] = [lng, lat];
    } else {
        if (type === 'line')
        {
            var featureLine = new ol.Feature({
                geometry: new ol.geom.LineString([[lng, lat], [position[0].toFixed(5), position[1].toFixed(5)]])
            });
            var vectorLine = new ol.source.Vector({});
            vectorLine.addFeature(featureLine);

            vec_line = new ol.layer.Vector({
                source: vectorLine,
                style: new ol.style.Style({
                    //fill: new ol.style.Fill({color: [204, 120, 0, 1], weight: 4}),
                    stroke: new ol.style.Stroke({color: "#0500bd", width: 3})
                }),
                zIndex: 14424
            });
            map.addLayer(vec_line);
            vec_line.set('name', 'line');

            var line = new ol.geom.LineString([[lng, lat], [position[0].toFixed(5), position[1].toFixed(5)]]);
            length = length + line.getLength();
            line_feature = true;
            $('#line_distance').html((length / 1000).toFixed(2) + ' Km');
        } else if (type === 'Polyline')
        {
            //var p1 = new OpenLayers.Geometry.Point(lng, lat);
            //var p2 = new OpenLayers.Geometry.Point(position.x.toFixed(5), position.y.toFixed(5));
            //length = length + p1.distanceTo(p2);
            //var line = new OpenLayers.Geometry.LineString([p1, p2]);
            //var style = {strokeColor: "#0500bd", strokeWidth: 3};
            //var fea_segment = new OpenLayers.Feature.Vector(line, {}, style);
            //vec_segment.addFeatures([fea_segment]);
            //map.addLayer(vec_segment);
            //polyline_feature = true;

            var featureLine = new ol.Feature({
                geometry: new ol.geom.LineString([[lng, lat], [position[0].toFixed(5), position[1].toFixed(5)]])
            });
            var vectorSegment = new ol.source.Vector({});
            vectorSegment.addFeature(featureLine);

            vec_segment = new ol.layer.Vector({
                source: vectorSegment,
                style: new ol.style.Style({
                    //fill: new ol.style.Fill({color: [204, 120, 0, 1], weight: 4}),
                    stroke: new ol.style.Stroke({color: "#0500bd", width: 3})
                }),
                zIndex: 14424
            });
            map.addLayer(vec_segment);
            vec_segment.set('name', 'seg');

            var line = new ol.geom.LineString([[lng, lat], [position[0].toFixed(5), position[1].toFixed(5)]]);
            length = length + line.getLength();
            polyline_feature = true;

            $('#length').html((length / 1000).toFixed(2) + ' Km');
            $('#segment').html((line.getLength() / 1000).toFixed(2) + ' Km');
            lat = parseFloat(position[1].toFixed(5));
            lng = parseFloat(position[0].toFixed(5));
        } else if (type === 'polygon')
        {
            polygon_feature = true;
//            if (clicked > 2) {
//                var p1 = new OpenLayers.Geometry.Point(poly_lng, poly_lat);
//            } else {
//                var p1 = new OpenLayers.Geometry.Point(lng, lat);
//            }
//            var p2 = new OpenLayers.Geometry.Point(position.x.toFixed(5), position.y.toFixed(5));
//            var line = new OpenLayers.Geometry.LineString([p1, p2]);
//            var style = {strokeColor: "#0500bd", strokeWidth: 3};
//            var fea_polygon = new OpenLayers.Feature.Vector(line, {}, style);
//            vec_polygon.addFeatures([fea_polygon]);
//            map.addLayer(vec_polygon);

            poly_count++;
            if (clicked > 2) {
                var p1 = [poly_lng, poly_lat];
            } else {
                var p1 = [lng, lat];
            }
            var p2 = [position[0].toFixed(5), position[1].toFixed(5)];
            var featureLine = new ol.Feature({
                geometry: new ol.geom.LineString([p1, p2])
            });
            var vectorPolygon = new ol.source.Vector({});
            vectorPolygon.addFeature(featureLine);

            vec_polygon = new ol.layer.Vector({
                source: vectorPolygon,
                style: new ol.style.Style({
                    //fill: new ol.style.Fill({color: [204, 120, 0, 1], weight: 4}),
                    stroke: new ol.style.Stroke({color: "#0500bd", width: 3})
                }),
                zIndex: 14424
            });
            map.addLayer(vec_polygon);
            vec_polygon.set('name', 'poly');
//            vec_polygon.set('id','end'+clicked);







            if (clicked >= 2) {
                poly_lat = parseFloat(position[1].toFixed(5));
                poly_lng = parseFloat(position[0].toFixed(5));
//                poly_lat = position.y.toFixed(5);
//                poly_lng = position.x.toFixed(5);
            }
            coordinates[clicked] = [poly_lng, poly_lat];
            if (clicked > 2) {
                if (clicked > 3) {
                    remove_layers('id', 'end' + (clicked - 1));
                    //vec_polygon_clo.getSource().removeFeatures(vec_polygon_clo.getSource().getFeatureById('end' + (clicked - 1)));
//                    vec_polygon_clo.removeFeatures(vec_polygon_clo.getFeatureById('end' + (clicked - 1)));
                }
                //var p1 = new OpenLayers.Geometry.Point(lng, lat);
                //var p2 = new OpenLayers.Geometry.Point(position.x.toFixed(5), position.y.toFixed(5));
                //var line = new OpenLayers.Geometry.LineString([p1, p2]);
                //var style = {strokeColor: "#0500bd", strokeWidth: 3};
                //var end_polygon = new OpenLayers.Feature.Vector(line, {id: 'end' + clicked}, style);
                //end_polygon.geometry.id = "end";
                //vec_polygon_clo.addFeatures([end_polygon]);
                //map.addLayer(vec_polygon_clo);



                var featureLine = new ol.Feature({
                    id: 'end' + clicked,
                    geometry: new ol.geom.LineString([[lng, lat], [position[0].toFixed(5), position[1].toFixed(5)]])
                });
                var end_polygon = new ol.source.Vector({});
                end_polygon.addFeature(featureLine);

                vec_polygon_clo = new ol.layer.Vector({
                    source: end_polygon,
                    style: new ol.style.Style({
                        //fill: new ol.style.Fill({color: [204, 120, 0, 1], weight: 4}),
                        stroke: new ol.style.Stroke({color: "#0500bd", width: 3})
                    }),
                    zIndex: 14424
                });
                map.addLayer(vec_polygon_clo);
                vec_polygon_clo.set('name', 'poly_clo');
                vec_polygon_clo.set('id', 'end' + clicked);


                var sitePoints = [];
                //var projection = new OpenLayers.Projection("EPSG:900913");
                //var projection = new OpenLayers.Projection("EPSG:900913");
                for (var i in coordinates) {
                    if (coordinates[i].length > 1) {
                        var coord = coordinates[i];
                        var point = [coord[0], coord[1]];
//                        var point = new ol.geom.Point([coord[0], coord[1]]);
                        //console.log(point);
                        //var point = new OpenLayers.Geometry.Point(coord[0], coord[1]);
                        // transform from WGS 1984 to Spherical Mercator
                        //point.transform('EPSG:900913', map.getProjectionObject());
                        sitePoints.push(point);
                    }
                }
                sitePoints.push(sitePoints[0]);
                var siteStyle = {
                    FillColor: "#0500bd"
                };
                //console.log(sitePoints);
//                var linearRing = new ol.geom.LinearRing(sitePoints);
//                console.log(linearRing);
                var geometry = new ol.geom.Polygon([sitePoints]);
//                var linearRing = new OpenLayers.Geometry.LinearRing(sitePoints);
//                var geometry = new OpenLayers.Geometry.Polygon([linearRing]);

                var area = geometry.getArea();
                var kmArea = area / 1000000;
                $('#area').html(kmArea.toFixed(2) + ' km <sup>2</sup>');
            }
        }
    }
}

function remove_layers(filter_type, filter_value) {
    var layersToRemove = [];
    map.getLayers().forEach(function (layer) {
        if (layer.get(filter_type) != undefined && layer.get(filter_type) === filter_value) {
            layersToRemove.push(layer);
        }
    });

    var len = layersToRemove.length;
    for (var i = 0; i < len; i++) {
        map.removeLayer(layersToRemove[i]);
    }
}

//function remove_layers_id(layer_id){
//    var layersToRemove = [];
//                map.getLayers().forEach(function (layer) {
//                    if (layer.get('id') != undefined && layer.get('id') === layer_id) {
//                        layersToRemove.push(layer);
//                    }
//                });
//
//                var len = layersToRemove.length;
//                for (var i = 0; i < len; i++) {
//                    map.removeLayer(layersToRemove[i]);
//                }
//}

function change_type(typ) {
    if (typ === 'Polyline' && clicked > 1) {
        if (line_feature === true) {
            remove_layers('name', 'line');
        }
        if (polygon_feature === true) {
            remove_layers('name', 'poly');
            remove_layers('name', 'poly_clo');
            coordinates = [];
        }
    } else if (typ === 'line' && clicked > 1) {
        if (polyline_feature === true) {
            remove_layers('name', 'seg');
        }
        if (polygon_feature === true) {
            remove_layers('name', 'poly');
            remove_layers('name', 'poly_clo');
            coordinates = [];
        }
    } else if (typ === 'polygon' && clicked > 1) {
        if (line_feature === true) {
            remove_layers('name', 'line');
        }
        if (polyline_feature === true) {
            remove_layers('name', 'seg');
        }
    }
    markers.getSource().clear();
    type = typ;
    if (type === 'Polyline') {
        clicked = 0;
        length = 0;
        lat = '';
        lng = '';
        $('#lines').hide();
        $('#polygon_area').hide();
        $('#line_length').show();
        $('#line_segment').show();
        $('#length').html('Total Distance');
        $('#segment').html('Distance');
    } else if (type === 'polygon') {
        clicked = 0;
        length = 0;
        lat = '';
        lng = '';
        $('#lines').hide();
        $('#line_length').hide();
        $('#line_segment').hide();
        $('#polygon_area').show();
        $('#area').html('Total Area');
    } else {
        clicked = 0;
        length = 0;
        lat = '';
        lng = '';
        $('#lines').show();
        $('#line_length').hide();
        $('#line_segment').hide();
        $('#polygon_area').hide();
        $('#line_distance').html('Line Distance');
    }
}
function get_extent() {
    var extent = this.map.getExtent().toGeometry().toString();
    var fval = this.map.getExtent().transform(new ol.proj.Projection("EPSG:900913"), new ol.proj.Projection("EPSG:4326"));
    console.log(extent);
//    console.log(fval);
//    console.log(fval.right);
    return fval;
}
function adjust_map_height()
{
    $(".fullheight").height($(window).height() - 60);
}

function get_map() {
//    var extent = this.map.getExtent().toGeometry().toString();
    var fval = this.map.getExtent().transform(new ol.proj.Projection("EPSG:900913"), new ol.proj.Projection("EPSG:4326"));
    console.log(fval);
    var xmax = fval.right;
    var xmin = fval.left;
    var ymax = fval.top;
    var ymin = fval.bottom;

    var layers = [];
    for (layername in map.layers) {
        // if the layer isn't visible at this range, or is turned off, skip it
        var layer = map.layers[layername];
        if (layer.length != 1) {
            console.log(layer.name);
            if (!layer.getVisible())
                continue;
            if (!layer.calculateInRange())
                continue;
            if (layer.name == "Print")
                continue;
            if (layer.name == "Google Streets") {
                continue;
            } else if (layer.name == "Markers") {
                continue;
            } else if (layer.name == "National Line") {
                continue;
            } else if (layer.name == "National Mask") {
                continue;
            } else if (layer.name == "Irrigation") {
                continue;
            } else {
                //var opacity = layer.opacity ? parseInt(100 * layer.opacity) : 100;
                layers.push(layer.name);
            }
        } else {
            continue;
        }
    }
    //console.log(layers);
    $.ajax({
        type: "POST",
        url: base_url + "map/download_map/",
        data: {'xmax': xmax, 'xmin': xmin, 'ymax': ymax, 'ymin': ymin, 'layers': layers},
        beforeSend: function () {
            $("#map_loading").html("<center><b>Processing Map...</b><br/><img src='" + base_url + "assets/img/file_loading.gif' /></center>");
        },
        complete: function () {
            $("#map_loading").text("");
        },
        success: function (result) {
            var result = $.parseJSON(result);
            console.log(result);

            if (result == true) {
                var path = base_url + "map_image/print_map.pdf";
                var save = document.createElement('a');
                save.href = path;
                save.download = "map_image/print_map.pdf";
                save.target = '_blank';
                save.textContent = 'Download Map';
                document.body.appendChild(save);
                save.click();
                document.body.removeChild(save);
            } else {
                alert('Error in Printing Map. Please Try Again.');
            }
        }
    });

}


