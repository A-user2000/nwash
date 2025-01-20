/* global ol, zoomInToolHelper, zoomOutToolHelper, panToolHelper, identifyToolHelper, googleGroup */

var map;
var map3d;
var markers;
var overlay;
var mapext;
var currZoom;
var mape;
var mapCanvas;
var canva;
var scaleCheck;
var aniCheck;
var check3d = false;
var scene;
var cType = "";
function init() {

    var overlayOpacity = 0.5;
    var maxOpacity = 1;
    var showLegend = false;
    scaleCheck = false;

    var controls_array = [
        new ol.control.ScaleLine()
    ];

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


    //var interactions = ol.interaction.defaults({
    //    shiftDragZoom: false
    //});

    map = new ol.Map({
        overlays: [overlay],
        controls: controls_array,
        //interactions: interactions,
        target: 'mapDiv',
        view: new ol.View({
            center: ol.proj.fromLonLat([84.1240, 28.3949]),
            resolution: 2000,
            //extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
            //minZoom: 3
        })
    });

    map3d = new olcs.OLCesium({
        map: map,
        sceneOptions: {
            terrainExaggeration: 2
        }
    });
    scene = map3d.getCesiumScene();

    map.on('moveend', function () {
        //record extend
        history_tool.record_screen_extent();

        //get zoom level to display in map
        var vi = map.getView();
        var zoomVal = parseInt(vi.getZoom());
        var zoomInfo = '<strong>Zoom Level : </strong>' + zoomVal;
        $('#zoom').html(zoomInfo);

        mapext = map.getView().calculateExtent(map.getSize());
        currZoom = vi.getZoom();

        if (check3d === true) {
            var rotAngle = scene.camera.heading;
            const rotated = document.getElementById('map3d-tool1');
            rotated.style.transform = 'rotate(' + rotAngle + 'rad)';
        }
    });

    map.on("pointermove", function (e) {
        var position = ol.proj.transform(e.coordinate, 'EPSG:3857', 'EPSG:4326');
        position.x = position[0];
        position.y = position[1];
        $("#latlon").html("<strong>Lat, Lon : </strong>" + position.y.toFixed(5) + ', ' + position.x.toFixed(5))
    });

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
    map.addLayer(markers);


    map.on('click', function (e) {
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
                }

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
                for (var i in coordinates) {
                    if (coordinates[i].length > 1) {
                        var coord = coordinates[i];
                        var point = [coord[0], coord[1]];
                        sitePoints.push(point);
                    }
                }
                sitePoints.push(sitePoints[0]);
                var siteStyle = {
                    FillColor: "#0500bd"
                };
                var geometry = new ol.geom.Polygon([sitePoints]);

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

function get3D() {
    if (check3d === false) {
        map3d.setEnabled(true);
        //if (cType === "clip") {
        //    nationalmask.setVisible(true);
        //}
        //else {
        //    nationalmask.setVisible(false);
        //}
        check3d = true;
        document.getElementById("map3d-tool").innerHTML = "2D";
        if (scene.camera.pitch.toFixed(2) === "-1.57") {
            Cesium.CesiumTerrainProvider.fromUrl("https://app1.softavi.com/tiles/nepal/").then(tp => scene.terrainProvider = tp);
            map3DPitched();
        }
        else {
        }
    }
    else {
        map3d.setEnabled(false);
        //nationalmask.setVisible(true);
        check3d = false;
        document.getElementById("map3d-tool").innerHTML = "3D";
    }
}

function map3Dextent() {
    scene.camera.flyTo({
        orientation: {

            heading: 0,
            pitch: -1.1,
        },
        destination: Cesium.Cartesian3.fromDegrees(84.13221153, 25.21293208, 690969),
        //destination: Cesium.Cartesian3.fromDegrees(84.1240, 28.3949, 690517),
        duration: 2
    })
}

function map3DPitched() {
    if (check3d === true) {
        var center = scene.camera.pickEllipsoid(
            new Cesium.Cartesian2(scene.canvas.width / 2, scene.canvas.height / 0.8), Cesium.Ellipsoid.WGS84);
        var cartographic = scene.globe.ellipsoid.cartesianToCartographic(center);
        var lat = Cesium.Math.toDegrees(cartographic.latitude).toFixed(8);
        var lon = Cesium.Math.toDegrees(cartographic.longitude).toFixed(8);
        scene.camera.flyTo({
            orientation: {
                heading: 0,

                pitch: -1.1,

                roll: scene.camera.roll
            },
            destination: Cesium.Cartesian3.fromDegrees(+lon, +lat, scene.camera.positionCartographic.height),
            duration: 2
        })
    }
}

function map3DTilt() {
    if (check3d === true) {
        //alert(scene.camera.heading);
        var center = scene.camera.pickEllipsoid(
            new Cesium.Cartesian2(scene.canvas.width / 2, scene.canvas.height / 2), Cesium.Ellipsoid.WGS84);
        var cartographic = scene.globe.ellipsoid.cartesianToCartographic(center);
        var lat = Cesium.Math.toDegrees(cartographic.latitude).toFixed(8);
        var lon = Cesium.Math.toDegrees(cartographic.longitude).toFixed(8);

        scene.camera.flyTo({
            orientation: {
                heading: 0,

                //pitch: scene.camera.pitch,

                //roll: scene.camera.roll
            },
            destination: Cesium.Cartesian3.fromDegrees(+lon, +lat, scene.camera.positionCartographic.height),
            duration: 2
        })
    }
}