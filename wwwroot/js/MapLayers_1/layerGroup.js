/*shprabin@gmail.com
 *02-13-2017
 **/

/* global ol */

//load dependent scripts
//$.getScript('assets/js/swMap.js');
var overlayOpacity = 0.5;
var maxOpacity = 1;
var index = 1;
var layerGroup = function (varname) {
    var layersArr = new Array();
    var obj = varname;

    return {
        addLayer: function (layer) {
            if (layer !== "") {
//                if (layer.options.hasOwnProperty('zIndex')) {
//                    index = layer.options.zIndex;
//                } else {
//                    index = index + 1;
//                }
//                if (typeof layer.setZIndex === 'function') {
//                    layer.setZIndex(index);
//                    layer.zIndex = index;
//                }
                layersArr.push(layer);
            }
        },
        sortArrayByVindex: function () {
            function compare(a, b) {
                if (a.vindex < b.vindex)
                    return -1;
                else if (a.vindex > b.vindex)
                    return 1;
                else
                    return 0;
            }
            var sorted = jQuery.extend(true, [], layersArr);
            sorted.sort(compare);
            return sorted;
        },
        removeLayer: function () {
            var index = this.layersArr.indexOf(layer);
            layersArr.splice(index, 1);
        },
        getLayers: function () {
            return layersArr;
        },
        getOverlayLayersAsList: function (node) {
            var htmlOut = "<div class=\"sortable\">";
            for (i = 0; i < layersArr.length; i++) {
                var layer = layersArr[i];
                htmlOut += '<div class="item"><h4><span class="sortable-handle icon"></span>';
                if (layer.getVisible()) {
                    htmlOut += '<input checked="true" id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:' + obj + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>' + layer.get('name');

                } else {
                    htmlOut += '<input id="checkbox_' + layer.id + '" type="checkbox" onclick="javascript:' + obj + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>' + layer.get('name');
                }
                htmlOut += '</h4><div class="accordion_content">';
                if (layer.legend) {
                    for (j = 0; j < layer.legend.length; j++) {
                        htmlOut += "<span class=\"legend\">" + "<img src=\"" + layer.legend[j].url + "\">" + layer.legend[j].label + "</span>";
                    }
                }
                /*htmlOut+='<h6>Transparency</h6><div id="'+layer.id+'_slider">';
                 //slider
                 htmlOut+='<script>$( "#'+layer.id+'_slider" ).slider({orientation: "horizontal",range: "min",min: 0,max: 100,value:'+layer.opacity+',slide: function( event, ui ) {'+obj+'.transparencyChanged("'+layer.get('name')+'",'+'ui.value)}});</script>';
                 htmlOut+='</div>'*/
                htmlOut += '</div>';
                htmlOut += '</div>';

                $(node + "> .content").html(htmlOut);
            }
            htmlOut = "</ul>";
            //$( "#sortable" ).sortable();
        },
        getOverlayLayersInLeftMenu: function (radioButton) {
            htmlOut = "";
            htmlOut += '<ul>';
            var sortedArr = this.sortArrayByVindex();
            if (radioButton === true) {
                htmlOut += '<li>';
                htmlOut += '<input checked="true" name="radio_' + obj + '" id="radio_none" type="radio" onclick="javascript:' + obj + '.layerCheckedExclusive(event,\'none\',this)"/>&nbsp;&nbsp;' + "None";
                htmlOut += '</li>';
            }

            for (i = 0; i < sortedArr.length; i++) {
                var layer = sortedArr[i];
                if (layer.get('name') !== 'National Mask') {
                    htmlOut += '<li>';
                    if (radioButton === true) {
                        if (layer.getVisible() ) {
                            htmlOut += '<input checked="true" name="radio_' + obj + '" id="radio_' + layer.get('name') + '" type="radio" onclick="javascript:' + obj + '.layerCheckedExclusive(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;' + layer.get('name');
                        } else {
                            htmlOut += '<input name="radio_' + obj + '" id="radio_' + layer.get('name') + '" type="radio" onclick="javascript:' + obj + '.layerCheckedExclusive(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;' + layer.get('name');
                        }
                    } else {
                        if(layer.get('name') == 'Contour 100m interval' || layer.get('name') == 'Contour 20m interval'){
                            
                        }
                        else if(layer.get('name') == 'Contour 500m interval'){
                                htmlOut += '<input id="checkbox_Contour" type="checkbox" onclick="javascript:' + obj + '.layerChecked(event, \'Contour\',this)"/>&nbsp;&nbsp;Contour';
                            }
                        else{
                            
                        if (layer.getVisible()) {
                            htmlOut += '<input checked="true" id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:' + obj + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;' + layer.get('name');
                        } else {
                            htmlOut += '<input id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:' + obj + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;' + layer.get('name');
                        }
                    }
                    }
                    if (layer.legend) {
                        htmlOut += '<ul>';
                        for (j = 0; j < layer.legend.length; j++) {
                            htmlOut += "<li><span class=\"legend\">" + "<img src=\"" + layer.legend[j].url + "\">" + layer.legend[j].label + "</span></li>";
                        }
                        htmlOut += '</ul>';
                    }
                    htmlOut += '</li>';

                }
            }
            htmlOut += '</ul>';
            return htmlOut;
        },
        getOverlayLayersInLeftMenuasDropdown: function () {
            //debugger;
            htmlOut = "";
            var sortedArr = this.sortArrayByVindex();
            htmlOut += '<br><select onchange="javascript:googleGroup.layerCheckedExclusive(event,this.value,this)" style="margin-left:-5px !important;">';
            htmlOut += '<option>Choose Online Basemap</option>';
            htmlOut += '<option>None</option>';
            for (i = 0; i < sortedArr.length; i++) {
                var layer = sortedArr[i];
                if (layer.get('name') === 'Open Street Map') {
                    htmlOut += '<option value="' + layer.get('name') + '" selected="selected">' + layer.get('name') + '</option>';
                } else {
                    htmlOut += '<option value="' + layer.get('name') + '">' + layer.get('name') + '</option>';
                }
            }
            htmlOut += '</select>';
            return htmlOut;
        },
        getLayerAsSelectOptions: function (node) {
            htmlOut = '<select onchange="javascript:' + obj + '.layerSelected(event,this)" id="' + obj + '_select" class="input-sm">';
            var selected = "selected";
            for (i = 0; i < layersArr.length; i++) {
                var layer = layersArr[i];
                if (layer.getVisible()) {
                    htmlOut += '<option value="' + layer.get('name') + '" selected>' + layer.get('name') + '</option>';
                    selected = true;
                } else {
                    htmlOut += '<option value="' + layer.get('name') + '">' + layer.get('name') + '</option>';
                }
            }

            htmlOut += '<option value=""' + selected + '>Mute Google Layer</option>';
            htmlOut += "</select>";
            $(node).html(htmlOut);
        },
        layerChecked: function (event, layerName, elem) {
            if(layerName === 'Contour'){
                var layerArr = ['Contour 500m interval','Contour 100m interval','Contour 20m interval'];
                for(var i = 0;i<layerArr.length;i++){
                    var layer = this.getLayerByName(layerArr[i]);
            if ($(elem).is(":checked")) {
                layer.setVisible(true);
            } else {
                layer.setVisible(false);
            }
            if (event.preventDefault) {
                event.stopPropagation();
            } else {
                event.cancelBubble = true;
            }
                }
                
            }
            else{
                var layer = this.getLayerByName(layerName);
                console.log("d"+layerName);
                console.log(elem);
                console.log(layer.getVisible());
            if ($(elem).is(":checked")) {
                layer.setVisible(true);
                console.log(layer.getVisible());
            } else {
                layer.setVisible(false);
            }
            if (event.preventDefault) {
                event.stopPropagation();
            } else {
                event.cancelBubble = true;
            }
            }
        },
        layerCheckedExclusive: function (event, layerName, elem) {
            /*var layer = this.getLayerByName(layerName);
             if ($(elem).is(":checked"))
             {
             layer.setVisibility(true);
             } else {
             layer.setVisibility(false);
             }*/
            for (i = 0; i < layersArr.length; i++) {
                var layer = layersArr[i];
                if (layer.get('name') === layerName) {
                    //layer.setVisibility(true);
                    layer.setVisible(true);
                } else {
                    //layer.setVisibility(false);
                    layer.setVisible(false);
                }
            }

        },
        layerSelected: function (event, elem) {
            var selectedLayer = $(elem).val();
            for (i = 0; i < layersArr.length; i++) {
                var layer = layersArr[i];
                if (layer.get('name') === selectedLayer) {
                    //layer.setVisibility(true);
                    layer.setVisible(true);
                } else {
                    //layer.setVisibility(false);
                    layer.setVisible(false);
                }
            }

        },
        getLayerByName: function (layerName) {
            for (i = 0; i < layersArr.length; i++) {
                var layer = layersArr[i];
                if (layer.get('name') === layerName) {
                    return layer;
                }
            }
            return false;
        },
        transparencyChanged: function (layerName, value) {
            var layer = this.getLayerByName(layerName, value);
            layer.setOpacity(1 - value / 100);
            //console.log(layer.opacity);
        }

    };

}


//<editor-fold desc="contour styling">

var styleCache = {};

            // the style function returns an array of styles
            // for the given feature and resolution.
            // Return null to hide the feature.
            function styleFunction(feature, resolution) {
                //debugger;
                vi = map.getView();
                var zoom = parseInt(vi.getZoom());
                // get the category from the feature properties
                var level = feature.get('category');
                var layer = feature.get('layer');
                // if there is no level or its one we don't recognize,
                // return the default style (in an array!)
                 if (layer === "500m_contourgeojson") {
                     if (zoom === 11) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [178,59,0,1],
                                    width: 0.5,
                                }),
                                text: new ol.style.Text({
                                    text: feature.get('elev').toString(),
                                    placement: 'line',
                                    rotationWithView: true,
                                    font: '10px Arial Regular',
                                    fill: new ol.style.Fill({
                                        color: [102,60,0, 1]
                                    }),
                                    stroke: new ol.style.Stroke({
                                    color: [255, 255, 255, 1],
                                    width: 3
                                })
                                    //textBaseline: "ideographic"
                                })
                            })];
                    }
                    else if (zoom === 12) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [178,59,0, 1],
                                    width: 0.6,
                                }),
                                text: new ol.style.Text({
                                    text: feature.get('elev').toString(),
                                    placement: 'line',
                                    rotationWithView: true,
                                    font: '11px Arial Regular',
                                    fill: new ol.style.Fill({
                                        color: [102,60,0, 1]
                                    }),
                                    stroke: new ol.style.Stroke({
                                    color: [255, 255, 255, 1],
                                    width: 3
                                })
                                    //textBaseline: "ideographic"
                                })
                            })];
                    }
                    else if (zoom === 13) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [178,59,0, 1],
                                    width: 0.7,
                                }),
                                text: new ol.style.Text({
                                    text: feature.get('elev').toString(),
                                    placement: 'line',
                                    rotationWithView: true,
                                    font: '11px Arial Regular',
                                    fill: new ol.style.Fill({
                                        color: [102,60,0, 1]
                                    }),
                                    stroke: new ol.style.Stroke({
                                    color: [255, 255, 255, 1],
                                    width: 3
                                })
                                    //textBaseline: "ideographic"
                                })
                            })];
                    }
                    else if (zoom === 14) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [178,59,0, 1],
                                    width: 0.8,
                                }),
                                text: new ol.style.Text({
                                    text: feature.get('elev').toString(),
                                    placement: 'line',
                                    rotationWithView: true,
                                    font: '11px Arial regular',
                                    fill: new ol.style.Fill({
                                        color: [102,60,0, 1]
                                    }),
                                    stroke: new ol.style.Stroke({
                                    color: [255, 255, 255, 1],
                                    width: 3
                                })
                                    //textBaseline: "ideographic"
                                })
                            })];
                    }
                    else if (zoom === 15) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [178,59,0, 1],
                                    width: 0.9,
                                }),
                                text: new ol.style.Text({
                                    text: feature.get('elev').toString(),
                                    placement: 'line',
                                    rotationWithView: true,
                                    font: '11px Arial Regular',
                                    fill: new ol.style.Fill({
                                        color: [102,60,0, 1]
                                    }),
                                    stroke: new ol.style.Stroke({
                                    color: [255, 255, 255, 1],
                                    width: 3
                                })
                                    //textBaseline: "ideographic"
                                })
                            })];
                    }
                    else if (zoom >= 16) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [178,59,0, 1],
                                    width: 1.3,
                                }),
                                text: new ol.style.Text({
                                    text: feature.get('elev').toString(),
                                    placement: 'line',
                                    rotationWithView: true,
                                    font: '12px Arial Regular',
                                    fill: new ol.style.Fill({
                                        color: [102,60,0, 1]
                                    }),
                                    stroke: new ol.style.Stroke({
                                    color: [255, 255, 255, 1],
                                    width: 3
                                })
                                    //textBaseline: "ideographic"
                                })
                            })];
                    }

                }
                if (layer === '100m_contourgeojson') {
//                    if (zoom < 13) {
//                        return [new ol.style.Style({
//                                stroke: new ol.style.Stroke({
//                                    color: [204,120,0,0],
//                                    width: 0.5,
//                                })
//                            })];
//                    }
//                    else 
                        if (zoom === 13) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [204,120,0, 1],
                                    width: 0.4,
                                })
                            })];
                    }
                    else if (zoom === 14) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [204,120,0, 1],
                                    width: 0.6,
                                }),
//                                text: new ol.style.Text({
//                                    text: feature.get('elev').toString(),
//                                    placement: 'line',
//                                    rotationWithView: true,
//                                    //font: '12px Arial Regular',
//                                    fill: new ol.style.Fill({
//                                        color: [255, 26, 26, 1]
//                                    }),
//                                    textBaseline: "ideographic"
//                                })
                            })];
                    }
                    else if (zoom === 15) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [204,120,0, 1],
                                    width: 0.8,
                                }),
                                text: new ol.style.Text({
                                    text: feature.get('elev').toString(),
                                    placement: 'line',
                                    rotationWithView: true,
                                    font: '11px Arial Regular',
                                    fill: new ol.style.Fill({
                                        color: [102,60,0, 1]
                                    }),
                                    stroke: new ol.style.Stroke({
                                    color: [255, 255, 255, 1],
                                    width: 3
                                })
                                    //textBaseline: "ideographic"
                                })
                            })];
                    }
                    else if (zoom >= 16) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [204,120,0, 1],
                                    width: 1.1,
                                }),
                                text: new ol.style.Text({
                                    text: feature.get('elev').toString(),
                                    placement: 'line',
                                    rotationWithView: true,
                                    font: '12px Arial Regular',
                                    fill: new ol.style.Fill({
                                        color: [102,60,0, 1]
                                    }),
                                    stroke: new ol.style.Stroke({
                                    color: [255, 255, 255, 1],
                                    width: 3
                                })
                                    //textBaseline: "ideographic"
                                })
                            })];
                    }
//                    else {
//                        return [new ol.style.Style({
//                                stroke: new ol.style.Stroke({
//                                    color: [204,120,0, 1],
//                                    width: 0.8,
//                                })
//                            })];
//                    }
                }
                if (layer === 'contour') {
//                    if (zoom < 15) {
//                        return [new ol.style.Style({
//                                stroke: new ol.style.Stroke({
//                                    color: [255,160,25, 0],
//                                    width: 0.0,
//                                })
//                            })];
//                    }
//                    else 
                        if (zoom === 15) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [255,160,25, 1],
                                    width: 0.4,
                                })
                            })];
                    }
                    else if (zoom === 16) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [255,160,25, 1],
                                    width: 0.5,
                                })
                            })];
                    }
                    else if (zoom >= 17) {
                        return [new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: [255,160,25, 1],
                                    width: 0.6,
                                })
                            })];
                    }
//                    else {
//                        return [new ol.style.Style({
//                                stroke: new ol.style.Stroke({
//                                    color: [255,160,25, 1],
//                                    width: 0.5,
//                                })
//                            })];
//                    }
                }
                // at this point, the style for the current level is in the cache
                // so return it (as an array!)
                //return [styleCache[layer]];
            }
            
//</editor-fold>

//<editor-fold desc="contour url load">
var reuseZoomLevels = 1;

            // Offset of loaded tiles from web mercator zoom level 0.
            // 0 means "At map zoom level 0, use tiles from zoom level 0". 1 means "At map
            // zoom level 0, use tiles from zoom level 1".
            var zoomOffset = 1;

            // Calculation of tile urls
            var resolutions = [];
            for (var z = zoomOffset / reuseZoomLevels; z <= 14 / reuseZoomLevels; ++z) {
                resolutions.push(156543.03392804097 / Math.pow(2, z * reuseZoomLevels));
            }
            function tileUrlFunction500(tileCoord) {
                vi = map.getView();
                var zoomVal = parseInt(vi.getZoom());
                //console.log(vi.getZoom());
                //console.log(zoomVal);
                //alert(map.getView().getZoom());
                if (zoomVal >= 11) {
                    //debugger;
                    return ('http://npgp.softwel.com.np/vt/tileserver.php?/index.json?/z_500m_contour/{z}/{x}/{y}.pbf')
                            .replace('{z}', String(tileCoord[0] * reuseZoomLevels + zoomOffset))
                            .replace('{x}', String(tileCoord[1]))
                            .replace('{y}', String(-tileCoord[2] - 1))
                            .replace('{a-d}', 'abcd'.substr(
                                    ((tileCoord[1] << tileCoord[0]) + tileCoord[2]) % 4, 1));
                }
            }

            function tileUrlFunction100(tileCoord) {
                vi = map.getView();
                var zoomVal = parseInt(vi.getZoom());
                //console.log(vi.getZoom()+'-100');
                //console.log(zoomVal+'-100');
                if (zoomVal >= 13) {
                    return ('http://npgp.softwel.com.np/vt/tileserver.php?/index.json?/z_100m_contour/{z}/{x}/{y}.pbf')
                            .replace('{z}', String(tileCoord[0] * reuseZoomLevels + zoomOffset))
                            .replace('{x}', String(tileCoord[1]))
                            .replace('{y}', String(-tileCoord[2] - 1))
                            .replace('{a-d}', 'abcd'.substr(
                                    ((tileCoord[1] << tileCoord[0]) + tileCoord[2]) % 4, 1));
                }
            }

            function tileUrlFunction20(tileCoord) {
                vi = map.getView();
                var zoomVal = parseInt(vi.getZoom());
                //console.log(vi.getZoom()+'-20');
                //console.log(zoomVal+'-20');
                if (zoomVal >= 14) {
                    return ('http://npgp.softwel.com.np/vt/tileserver.php?/index.json?/z_20m_contour/{z}/{x}/{y}.pbf')
                            .replace('{z}', String(tileCoord[0] * reuseZoomLevels + zoomOffset))
                            .replace('{x}', String(tileCoord[1]))
                            .replace('{y}', String(-tileCoord[2] - 1))
                            .replace('{a-d}', 'abcd'.substr(
                                    ((tileCoord[1] << tileCoord[0]) + tileCoord[2]) % 4, 1));
                }
            }
//</editor-fold>

/*overlay Layer*/

var province_layer = new ol.layer.Tile({
    //extent:[-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_01/wms',
        params: {
            'LAYERS' : 'nwash_01:Province_44N',
            'TILED' : true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible:true
});
province_layer.set('name','Province');

//<editor-fold desc="varous mask layer">

var nationalmask = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_01/wms',
            params: {
                'LAYERS': 'nwash_01:Mask_poly_National_boundary',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:true,
    zIndex:1000
    });
    nationalmask.set('name','National Mask');

var province_mask = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_01/wms',
            params: {
                'LAYERS': 'nwash_01:province_nepal',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
    zIndex:100000
    });
    province_mask.set('name','Province Mask');

var district_mask = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_01/wms',
            params: {
                'LAYERS': 'nwash_01:district_boundary',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
    zIndex:100000
    });
    district_mask.set('name','District Boundary');


var muni_mask = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_01/wms',
            params: {
                'LAYERS': 'nwash_01:localbodies_nepal',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
    zIndex:100000
    });
    muni_mask.set('name','Muni Mask');   
    //</editor-fold>
    
//<editor-fold desc="Nepal Basemap Layers">
var nationalboundary = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/NepalRoadNetwork/wms',
            params: {
                'LAYERS': 'NepalRoadNetwork:Nationalline',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:true,
    zIndex:1800
    });
    nationalboundary.set('name','National Line');
nationalboundary.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=NepalRoadNetwork:Nationalline&RULE=I zoom",
        "label": "National Boundary"
    }
];

var districtLine = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nhydro_01/wms',
            params: {
                'LAYERS': 'nhydro_01:District_Boundary_Line_2017_WGS84',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:1800
    });
    districtLine.set('name','District Boundary');
//
districtLine.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nhydro_01:District_Boundary_Line_2017_WGS84&RULE=II zoom",
        "label": "District Boundary"
    }
];

var district = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nhydro_01/wms',
            params: {
                'LAYERS': 'nhydro_01:District_Boundary_2017_WGS84',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:300,
    visible:false
    });
    district.set('name','District');


var vdcboundary = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/NepalRoadNetwork/wms',
            params: {
                'LAYERS': 'NepalRoadNetwork:nepal_vdc_boundary',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:500,
    visible:false
    });
    vdcboundary.set('name','VDC Boundary');
    vdcboundary.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=NepalRoadNetwork:vdcline",
        "label": "VDC Boundary"
    }
];


var local_boundry = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nhydro_01/wms',
            params: {
                'LAYERS': 'nhydro_01:Localbodies_WGS84,nhydro_01:Localbodies_Line_WGS84',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:1800,
    visible:true
    });
    local_boundry.set('name','Localbodies Boundary');
    local_boundry.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nhydro_01:Localbodies_Line_WGS84&RULE=II zoom",
        "label": "Localbodies Boundary"
    }
];


var settlements = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/NepalRoadNetwork/wms',
            params: {
                'LAYERS': 'NepalRoadNetwork:Junctionname',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:1750,
    visible:false
    });
    settlements.set('name','Settlements');
    settlements.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=NepalRoadNetwork:Junctionname&RULE=I zoom",
        "label": "Settlements"
    }
];

var ward_boundry = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/tiles/wms',
        params: {
            'LAYERS': 'tiles:ward_boundary_45N,tiles:wardboundary_line',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    zIndex: 440,
    visible: false
});
ward_boundry.set('name', 'Ward Boundary');


var majorriver = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/NepalRoadNetwork/wms',
            params: {
                'LAYERS': 'NepalRoadNetwork:Major_river',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:600,
    visible:false
    });
    majorriver.set('name','Major River');
    majorriver.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=NepalRoadNetwork:Major_river&RULE=river",
        "label": " Major River"
    }
];

var contour_20 = new ol.layer.VectorTile({
                renderMode: 'vector',
                preload: Infinity,
                source: new ol.source.VectorTile({
                    attributions: 'Softwel',
                    format: new ol.format.MVT({
                        defaultDataProjection: 'EPSG:4326'
                    }),
                    tileGrid: new ol.tilegrid.TileGrid({
                        extent: ol.proj.get('EPSG:3857').getExtent(),
                        //extent: ol.proj.get('EPSG:4326').getExtent(),
                        resolutions: resolutions
                    }),
                    tilePixelRatio: 1,
                    tileUrlFunction: tileUrlFunction20
                }),
                zIndex:800,
                visible:false,
                style: styleFunction
            });
    contour_20.set('name','Contour 20m interval');
    contour_20.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=npgp:20m_contour&RULE=20m_contour",
        "label": "Contour 20"
    }
];


var contour_100 = new ol.layer.VectorTile({
                renderMode: 'vector',
                preload: Infinity,
                source: new ol.source.VectorTile({
                    attributions: 'Softwel',
                    format: new ol.format.MVT({
                        defaultDataProjection: 'EPSG:4326'
                    }),
                    tileGrid: new ol.tilegrid.TileGrid({
                        extent: ol.proj.get('EPSG:3857').getExtent(),
                        //extent: ol.proj.get('EPSG:4326').getExtent(),
                        resolutions: resolutions
                    }),
                    tilePixelRatio: 1,
                    tileUrlFunction: tileUrlFunction100
                }),
                zIndex:800,
                visible:false,
                style: styleFunction
            });
    contour_100.set('name','Contour 100m interval');
    contour_100.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=npgp:100m_contour&RULE=100m_contour",
        "label": "Contour 100"
    }
];


var contour_500 = new ol.layer.VectorTile({
                renderMode: 'vector',
                preload: Infinity,
                source: new ol.source.VectorTile({
                    attributions: 'Softwel',
                    format: new ol.format.MVT({
                        defaultDataProjection: 'EPSG:4326'
                    }),
                    tileGrid: new ol.tilegrid.TileGrid({
                        extent: ol.proj.get('EPSG:3857').getExtent(),
                        //extent: ol.proj.get('EPSG:4326').getExtent(),
                        resolutions: resolutions
                    }),
                    tilePixelRatio: 1,
                    tileUrlFunction: tileUrlFunction500
                    
                }),
                zIndex:800,
                visible:false,
                style: styleFunction
            });
    contour_500.set('name','Contour 500m interval');
    contour_500.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=npgp:500m_contour&RULE=500m_contour",
        "label": "Contour 500"
    }
];


var airport = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/NepalRoadNetwork/wms',
            params: {
                'LAYERS': 'NepalRoadNetwork:Airport',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:1701,
    visible:false
    });
    airport.set('name','Airport');
    airport.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=NepalRoadNetwork:Airport&RULE=II zoom",
        "label": "Airport"
    }
];

var roadDivisionColor = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/ARMP2014/wms',
            params: {
                'LAYERS': 'ARMP2014:road_division_color,ARMP2014:DivisionName',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:100,
    visible:false
    });
    roadDivisionColor.set('name','Road Division');

var elevation = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/WB_LS_Hazard/wms',
            params: {
                'LAYERS': 'WB_LS_Hazard:Nepal_dem_44N',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:200,
    visible:false
    });
    elevation.set('name','Elevation Map');
    
    var aspectMap = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/tiles/wms',
            params: {
                'LAYERS': 'tiles:aspect_1',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:400,
    visible:false,
            opacity:0.7
    });
    aspectMap.set('name','Aspect Map');
    
    aspectMap.legend = [
    {
        "url": "assets/img/legend/aspect.PNG",
        "label": "Aspect Map"
    }
];

var slopeMap = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/tiles/wms',
            params: {
                'LAYERS': 'tiles:slope',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        zIndex:380,
    visible:false,
            opacity:0.7
    });
    slopeMap.set('name','Slope Map');
    
    slopeMap.legend = [
    {
        "url": "assets/img/legend/slope.PNG",
        "label": "Slope Map"
    }
];

//vindex is index for displaying the layer in the list
nationalboundary.vindex = 1;
district.vindex = 3;
districtLine.vindex = 2;
vdcboundary.vindex = 4;
ward_boundry.vindex = 5;
local_boundry.vindex = 6;
majorriver.vindex = 7;
settlements.vindex = 8;
airport.vindex = 9;
//elevation.vindex = 10;
//aspectMap.vindex = 11;
//slopeMap.vindex = 12;
contour_500.vindex = 13;
contour_100.vindex = 14;
contour_20.vindex = 15;



//the parameter is the same name as the var name..
var basemap = new layerGroup("basemap");

basemap.addLayer(districtLine);
basemap.addLayer(district);
basemap.addLayer(nationalboundary);
basemap.addLayer(vdcboundary);
basemap.addLayer(ward_boundry);
basemap.addLayer(local_boundry);
basemap.addLayer(majorriver);
basemap.addLayer(settlements);
//basemap.addLayer(contour);

basemap.addLayer(airport);
basemap.addLayer(nationalmask);
//basemap.addLayer(elevation);
//basemap.addLayer(aspectMap);
//basemap.addLayer(slopeMap);
basemap.addLayer(contour_20);
basemap.addLayer(contour_100);
basemap.addLayer(contour_500);

var basemap_arr = [districtLine, district, nationalboundary,vdcboundary, local_boundry, majorriver, settlements, airport, contour_20, contour_100, contour_500];

//</editor-fold>

//<editor-fold desc="Map Layer">
var tgamp = new ol.layer.Tile({
                source: new ol.source.OSM({
                   url: 'http://mt1.google.com/vt/lyrs=s&hl=pl&&x={x}&y={y}&z={z}'  
                }),
                zIndex: 1
            });
            tgamp.set('name','Google Satellite');

var tgphy = new ol.layer.Tile({
                source: new ol.source.TileImage({
                    url: 'http://mt0.google.com/vt/lyrs=p&hl=en&x={x}&y={y}&z={z}'  
                }),
                zIndex: 2
            });
            tgphy.set('name','Google Terrain');

 var tgmap = new ol.layer.Tile({
                source: new ol.source.TileImage({
                   url: 'http://mt1.google.com/vt/lyrs=m&x={x}&y={y}&z={z}'  
                }),
                zIndex: 3
            });
            tgmap.set('name','Google Streets');

var bing_road = new ol.layer.Tile({
                source: new ol.source.BingMaps({
                    key: "AuzAZ5dpuR6OxpUPx2mUBezeWtt_V26O2s0JVAG3WoDKaN-IRLeJEP1AnNtcUZ6e",
                    imagerySet:'Road'
                }),
                zIndex:5,
                visible:false,
                preload:Infinity
            });
            bing_road.set('name','Bing Road');

var bing_aerial = new ol.layer.Tile({
                source: new ol.source.BingMaps({
                    key: "AuzAZ5dpuR6OxpUPx2mUBezeWtt_V26O2s0JVAG3WoDKaN-IRLeJEP1AnNtcUZ6e",
                    imagerySet:'Aerial'
                }),
                zIndex:6,
                visible:false,
                preload:Infinity
            });
            bing_aerial.set('name','Bing Aerial');

var mapnik = new ol.layer.Tile({
                source: new ol.source.OSM(),
                zIndex:7
            });
            mapnik.set('name','Open Street Map');

var googleGroup = new layerGroup("googleGroup");
googleGroup.addLayer(tgamp);
googleGroup.addLayer(tgphy);
googleGroup.addLayer(tgmap);
googleGroup.addLayer(bing_road);
googleGroup.addLayer(bing_aerial);
googleGroup.addLayer(mapnik);
//</editor-fold>

///*-------------------DTMP-----------------------*/
//
//
///*-------- For Search Layer----------------- */
//var search_road_layer = new ol.layer.WMS(
//        "Inventory Road Network",
//        "http://geoserver.aviyaan.com/geoserver/ARMP2014/wms",
//        {
//            layers: "pavement",
//            styles: "armp_search_road_style",
//            format: 'image/png',
//            transparent: 'true'
//        },
//        {
//            numZoomLevels: 18,
//            tileSize: new OpenLayers.Size(256, 256),
//            isBaseLayer: false,
//            visibility: false
//        }
//);
var search_road_layer = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/ARMP2014/wms',
            params: {
                'LAYERS': 'pavement',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false
    });
    search_road_layer.set('name','Inventory Road Network');


//<editor-fold desc="Nepal Road Network Group">
var armp_ssrn_pavement = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/ARMP2014/wms',
            params: {
                'LAYERS': 'ARMP2014:pavement_view',
                'TILED': true,
                CQL_FILTER: "dyear='" + dyear + "'"
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
        identify_attributes: {
                "link_name": "Link Name",
                "road_code": "Link Code",
                "from_ch": "From Chainage",
                "to_ch": "To Chainage",
                "pave_type": "Pavement Type",
                "last_resurface": "Last Resurfaced",
                "sdi_value": "SDI",
                "iri_value": "IRI",
                "inotes": "Inotes",
                "aadt_value": "Traffic(AADT)"

            },
    visible:false,
    zIndex:900
    });
    armp_ssrn_pavement.set('name','Strategic Road Network');

armp_ssrn_pavement.legend = [{
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=ARMP2014:pavement&RULE=50000%20-%203000000%20-%20BT",
        "label": "Black Topped Road"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=ARMP2014:pavement&RULE=50000%20-%203000000%20-%20GR",
        "label": "Gravel Road"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=ARMP2014:pavement&RULE=50000%20-%203000000%20-%20ER",
        "label": "Earthen Road"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=ARMP2013:ssrn_pavementstatus&RULE=50000 - 3000000 - UC",
        "label": "Under Construction Road"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=ARMP2014:pavement&RULE=50000%20-%203000000%20-%20PL",
        "label": "Planned"
    }

];

var lrn_drcn_road = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/lrn_2016/wms',
            params: {
                'LAYERS': 'lrn_2016:all_district',
                'TILED': true,
                CQL_FILTER: "road_categ='DRCN'"
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 1050
    });
    lrn_drcn_road.set('name','District Road Core Network');

lrn_drcn_road.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=lrn_2016:all_district&RULE=0 - 50000 - DRCN",
        "label": "DRCN"
    }

];

var lrn_ur_road = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/lrn_2016/wms',
            params: {
                'LAYERS': 'lrn_2016:all_district',
                'TILED': true,
                CQL_FILTER: "road_categ='UR'"
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 1051
    });
    lrn_ur_road.set('name','Urban Road');
lrn_ur_road.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=lrn_2016:all_district&RULE=0 - 50000 - UR",
        "label": "UR"
    }

];

var lrn_vr_road = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/lrn_2016/wms',
            params: {
                'LAYERS': 'lrn_2016:all_district',
                'TILED': true,
                CQL_FILTER: "road_categ='VR'"
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 1052
    });
    lrn_vr_road.set('name','Village Road');
lrn_vr_road.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=lrn_2016:all_district&RULE=0 - 50000 - VR",
        "label": "VR"
    }

];

var lrnGroup = new layerGroup("lrnGroup");
lrnGroup.addLayer(armp_ssrn_pavement);
lrnGroup.addLayer(lrn_drcn_road);
lrnGroup.addLayer(lrn_vr_road);
lrnGroup.addLayer(lrn_ur_road);

var lrn_arr = [armp_ssrn_pavement, lrn_drcn_road, lrn_vr_road, lrn_ur_road];

//</editor-fold>

//<editor-fold desc="WASH Data Group">
var health_care = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:health_care_facility',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    health_care.set('name','Health Care Facility');

health_care.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:health_care_facility&RULE=zoom I",
        "label": "Health Care Facility"
    }
];


var schools = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:tbl_school',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    schools.set('name','Schools');

schools.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:tbl_school&RULE=zoom II",
        "label": "Schools"
    }
];

var com_sanitation = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:cs_initial_details',
            'TILED': true,
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
com_sanitation.set('name', 'Community Sanitation');

com_sanitation.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:cs_initial_details&Rule=Existing Sanitation System II",
        "label": "Existing Sanitation System"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:cs_initial_details&Rule=New Sanitation System II",
        "label": "New Sanitation System"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:cs_initial_details&Rule=Ongoing Sanitation System II",
        "label": "Ongoing Sanitation System"
    }
];

var unserved_pop = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:unserved_initial_details',
            'TILED': true,
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
unserved_pop.set('name', 'Unserved Population');

unserved_pop.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:unserved_initial_details&Rule=New System II",
        "label": "New Sanitation System"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:unserved_initial_details&Rule=Ongoing System II",
        "label": "Ongoing Sanitation System"
    }
];

var householdWash = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:tbl_household',
                'TILED': true,
                transparent:true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    householdWash.set('name','Household');

householdWash.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:tbl_household&RULE=zoom I",
        "label": "Household"
    }
];

var publicToilet = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:public_toilet',
                'TILED': true,
                transparent:true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    publicToilet.set('name','Public Toilet');

publicToilet.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:public_toilet&RULE=zoom II",
        "label": "Public Toilet"
    }
];

var urbanSan = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:tbl_urban_sanitation',
                'TILED': true,
                transparent:true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    urbanSan.set('name','CWIS Urban Sanitation');


var washGroup = new layerGroup("washGroup");
washGroup.addLayer(com_sanitation);
washGroup.addLayer(health_care);
washGroup.addLayer(householdWash);
washGroup.addLayer(publicToilet);
washGroup.addLayer(schools);
washGroup.addLayer(unserved_pop);
washGroup.addLayer(urbanSan);




var wash_arr = [health_care, schools, com_sanitation, householdWash, publicToilet,urbanSan];

//</editor-fold>

//<editor-fold desc="Unserved Community Group">
var unserved = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:unserved_community',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    unserved.set('name','Unserved Community');

unserved.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:unserved_community&RULE=zoom II",
        "label": "Unserved Community"
    }
];

var potentialSrc = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:potential_source',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    potentialSrc.set('name','Potential Source');

potentialSrc.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:potential_source&RULE=zoom I",
        "label": "Potential Source"
    }
];

var unservedGroup = new layerGroup("unservedGroup");
unservedGroup.addLayer(unserved);
unservedGroup.addLayer(potentialSrc);

var unservedGroup_arr = [unserved, potentialSrc];

//</editor-fold>

//<editor-fold desc="Community Water Supply Project Group">

var project = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:project_details',
                'TILED': true,
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:true,
            zIndex: 2007,
            opacity:0.9
    });
    project.set('name','Water Supply Projects');


project.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:project_details&RULE=zoom II",
        "label": "Project"
    }
];

var project_coverage = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:project_coverage',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:true,
            zIndex: 2001,
            opacity:0.9
    });
    project_coverage.set('name','Project Coverage');

var water_source = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:water_source',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:true,
            zIndex: 2007,
            opacity:0.9
    });
    water_source.set('name','Source');


water_source.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:water_source&RULE=Water_source",
        "label": "Water Source"
    }
];

var reservoir = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:reservoir',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:true,
            zIndex: 2008,
            opacity:0.9
    });
    reservoir.set('name','Reservoir');


reservoir.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:reservoir&RULE=reservoir",
        "label": "Reservoir"
    }
];


var pipe = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:pipe',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2009,
            opacity:0.9
    });
    pipe.set('name','Pipe');


pipe.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:pipe&RULE=pipe",
        "label": "Pipe"
    }
];

var tap = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:tap',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:true,
            zIndex: 2012,
            opacity:0.9
    });
    tap.set('name','Tap');

tap.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:tap&RULE=Community",
        "label": "Community"
    },

    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:tap&RULE=Institutional",
        "label": "Institutional"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:tap&RULE=Yard",
        "label": "Yard"
    }
];

var structure = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:structure',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:true,
            zIndex: 2012,
            opacity:0.9
    });
    structure.set('name','Structure');


structure.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:structure&RULE=Structure",
        "label": "Structure"
    }
];

var junction = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:junction',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2010,
            opacity:0.9
    });
    junction.set('name','Junction');


junction.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:junction&RULE=zoom I",
        "label": "Junction"
    }
];

var functionality_framework = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_01/wms',
            params: {
                'LAYERS': 'nwash_01:project_details_fun',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2010,
            opacity:0.9
    });
    functionality_framework.set('name','Functionality Framework');


functionality_framework.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=CARE_ims:functionality_framework&RULE=zoom II",
        "label": "Functionality Framework"
    }
];

var sustainability_framework = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_01/wms',
            params: {
                'LAYERS': 'nwash_01:project_details_fun',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2010,
            opacity:0.9
    });
    sustainability_framework.set('name','Sustainability Framework');


sustainability_framework.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=CARE_ims:sustainability_framework&RULE=zoom II",
        "label": "Sustainability Framework"
    }
];

var leftoutTaps = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:leftout_taps',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2010,
            opacity:0.9
    });
leftoutTaps.set('name','LeftoutTaps');


leftoutTaps.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:leftout_taps&RULE=leftout_taps",
        "label": "Leftout Taps"
    }
];


var wspGroup = new layerGroup("wspGroup");
wspGroup.addLayer(project);
wspGroup.addLayer(project_coverage);
wspGroup.addLayer(water_source);
wspGroup.addLayer(reservoir);
wspGroup.addLayer(pipe);
wspGroup.addLayer(tap);
wspGroup.addLayer(structure);
wspGroup.addLayer(junction);
wspGroup.addLayer(functionality_framework);
wspGroup.addLayer(sustainability_framework);
wspGroup.addLayer(leftoutTaps);

var wspGroup_arr = [project,project_coverage, water_source, reservoir, pipe, tap, structure, junction, functionality_framework, sustainability_framework];

//</editor-fold>

//<editor-fold desc="Solid Waste">
var benchmarking = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:benchmarking',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    benchmarking.set('name','Benchmarking');

benchmarking.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:benchmarking&RULE=zoom II",
        "label": "Benchmarking"
    }
];

var disposal_point = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:disposal_point',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    disposal_point.set('name','Disposal Point');

disposal_point.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:disposal_point&RULE=zoom II",
        "label": "Disposal Point"
    }
];

var route_point = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:route_point',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    route_point.set('name','Route Point');

route_point.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:route_point&RULE=zoom II",
        "label": "Route Point"
    }
];

var skips = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:skips',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    skips.set('name','Skips');

skips.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:skips&RULE=zoom II",
        "label": "Skips"
    }
];

var street_sweeping = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:street_sweeping',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    street_sweeping.set('name','Street Sweeping');

street_sweeping.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:street_sweeping&RULE=zoom II",
        "label": "Street Sweeping"
    }
];

var solidWasteGroup = new layerGroup("solidWasteGroup");
solidWasteGroup.addLayer(benchmarking);
solidWasteGroup.addLayer(disposal_point);
solidWasteGroup.addLayer(route_point);
solidWasteGroup.addLayer(skips);
solidWasteGroup.addLayer(street_sweeping);

var solidwaste_arr = [benchmarking, disposal_point, route_point, skips, street_sweeping];
//</editor-fold>

//<editor-fold desc="Drainage Layer Group">
var drainage_point = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:drainage_point',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    drainage_point.set('name','Drainage Point');

drainage_point.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:drainage_point&RULE=zoom II",
        "label": "Drainage Point"
    }
];

var flood_benchmarking = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:flood_benchmarking',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    flood_benchmarking.set('name','Flood Benchmarking');

flood_benchmarking.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:flood_benchmarking&RULE=zoom II",
        "label": "Flood Benchmarking"
    }
];

var manhole = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:manhole',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    manhole.set('name','Manhole');

manhole.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:manhole&RULE=II zoom",
        "label": "Manhole"
    }
];

var outfall = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:outfall',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    outfall.set('name','Outfall');

outfall.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:outfall&RULE=zoom II",
        "label": "Outfall"
    }
];

var rain_inlet = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:rain_inlet',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    rain_inlet.set('name','Rain Inlet');

rain_inlet.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:rain_inlet&RULE=II zoom",
        "label": "Rain Inlet"
    }
];

var sanitation_benchmarking = new ol.layer.Tile({
        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
        source: new ol.source.TileWMS({
            url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
            params: {
                'LAYERS': 'nwash_02:sanitation_benchmarking',
                'TILED': true
            },
            serverType: 'geoserver',
            projection: 'EPSG:4269'
        }),
    visible:false,
            zIndex: 2007
    });
    sanitation_benchmarking.set('name','Sanitation Benchmarking');


sanitation_benchmarking.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:sanitation_benchmarking&RULE=II zoom",
        "label": "Sanitation Benchmarking"
    }
];
var drainageGroup = new layerGroup("drainageGroup");
drainageGroup.addLayer(drainage_point);
drainageGroup.addLayer(flood_benchmarking);
drainageGroup.addLayer(manhole);
drainageGroup.addLayer(outfall);
drainageGroup.addLayer(rain_inlet);
drainageGroup.addLayer(sanitation_benchmarking);

var drainage_arr = [drainage_point, flood_benchmarking, manhole, outfall, rain_inlet, sanitation_benchmarking];
//</editor-fold>

/*
 * Water Quality
 */

var WQGroup = new layerGroup("WQGroup");

var wq_arsenic = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:arsenic_his',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_arsenic.set('name', 'Historical Arsenic Data');


wq_arsenic.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:arsenic_his&RULE=0-10",
        "label": "0-10 (per &micro;g/L)"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:arsenic_his&RULE=10-50",
        "label": "10-50 (per &micro;g/L)"
    },
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:arsenic_his&RULE=>50",
        "label": "> 50 (per &micro;g/L)"
    }
];

var wq_watersafe_comm = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:watersafe_community',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_watersafe_comm.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:watersafe_community",
        "label": "Watersafe Community"
    }
]

wq_watersafe_comm.set('name', 'Water safe community');

WQGroup.addLayer(wq_arsenic);
WQGroup.addLayer(wq_watersafe_comm);

var wq_arr = [wq_arsenic, wq_watersafe_comm];


/*
 * 
 * Water Quality Parameter Data
 */

var wq_view_Alumunium = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Alumunium',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Alumunium.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Alumunium",
        "label": ""
    }
]
wq_view_Alumunium.set('name', 'Aluminium');

var wq_view_Ammonia = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Ammonia',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Ammonia.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Ammonia",
        "label": ""
    }
]

wq_view_Ammonia.set('name', 'Ammonia');

var wq_view_Arsenic = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Arsenic',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Arsenic.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Arsenic",
        "label": ""
    }
]

wq_view_Arsenic.set('name', 'Arsenic');

var wq_view_Cadmium = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Cadmium',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Cadmium.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Cadmium",
        "label": ""
    }
]

wq_view_Cadmium.set('name', 'Cadmium');

var wq_view_Calcium = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Calcium',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Calcium.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Calcium",
        "label": ""
    }
]

wq_view_Calcium.set('name', 'Calcium');

var wq_view_Chloride = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Chloride',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Chloride.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Chloride",
        "label": ""
    }
]

wq_view_Chloride.set('name', 'Chloride');

var wq_view_Chromium = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Chromium',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Chromium.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Chromium",
        "label": ""
    }
]

wq_view_Chromium.set('name', 'Chromium');

var wq_view_Color = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Color',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Color.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Color",
        "label": ""
    }
]

wq_view_Color.set('name', 'Color');

var wq_view_Copper = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Copper',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Copper.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Copper",
        "label": ""
    }
]

wq_view_Copper.set('name', 'Copper');

var wq_view_Cyanide = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Cyanide',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Cyanide.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Cyanide",
        "label": ""
    }
]

wq_view_Cyanide.set('name', 'Cyanide');

var wq_view_Electrical_conductivity = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Electrical_conductivity',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Electrical_conductivity.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Electrical_conductivity",
        "label": ""
    }
]

wq_view_Electrical_conductivity.set('name', 'Electrical Conductivity');

var wq_view_Faecal_coliform_ecoli = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Faecal_coliform_ecoli',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Faecal_coliform_ecoli.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Faecal_coliform_ecoli",
        "label": ""
    }
]

wq_view_Faecal_coliform_ecoli.set('name', 'Faecal Coliform EColi');

var wq_view_Faecal_contamination = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Faecal_contamination',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Faecal_contamination.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Faecal_contamination",
        "label": ""
    }
]

wq_view_Faecal_contamination.set('name', 'Faecal Contamination');

var wq_view_Fluoride = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Fluoride',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Fluoride.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Fluoride",
        "label": ""
    }
]

wq_view_Fluoride.set('name', 'Fluoride');

var wq_view_Iron = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Iron',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Iron.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Iron",
        "label": ""
    }
]

wq_view_Iron.set('name', 'Iron');

var wq_view_Lead = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Lead',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Lead.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Lead",
        "label": ""
    }
]

wq_view_Lead.set('name', 'Lead');

var wq_view_Manganese = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Manganese',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Manganese.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Manganese",
        "label": ""
    }
]

wq_view_Manganese.set('name', 'Manganese');

var wq_view_Mercury = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Mercury',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Mercury.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Mercury",
        "label": ""
    }
]

wq_view_Mercury.set('name', 'Mercury');

var wq_view_Nitrate = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Nitrate',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Nitrate.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Nitrate",
        "label": ""
    }
]

wq_view_Nitrate.set('name', 'Nitrate');

var wq_view_Nitrites = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Nitrites',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Nitrites.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Nitrites",
        "label": ""
    }
]

wq_view_Nitrites.set('name', 'Nitrites');

var wq_view_pH = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_pH',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_pH.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_pH",
        "label": ""
    }
]

wq_view_pH.set('name', 'pH');

var wq_view_Residual_Chlorine = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Residual_Chlorine',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Residual_Chlorine.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Residual_Chlorine",
        "label": ""
    }
]

wq_view_Residual_Chlorine.set('name', 'Residual Chlorine');

var wq_view_Sulphate = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Sulphate',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Sulphate.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Sulphate",
        "label": ""
    }
]

wq_view_Sulphate.set('name', 'Sulphate');

var wq_view_Taste_odor = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Taste_odor',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Taste_odor.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Taste_odor",
        "label": ""
    }
]

wq_view_Taste_odor.set('name', 'Taste and Odor');

var wq_view_Total_colifom = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Total_colifom',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Total_colifom.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Total_colifom",
        "label": ""
    }
]

wq_view_Total_colifom.set('name', 'Total Colifom');

var wq_view_Total_dissolved_solids = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Total_dissolved_solids',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Total_dissolved_solids.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Total_dissolved_solids",
        "label": ""
    }
]

wq_view_Total_dissolved_solids.set('name', 'Total Dissolved Solids');

var wq_view_Total_hardness = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Total_hardness',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Total_hardness.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Total_hardness",
        "label": ""
    }
]

wq_view_Total_hardness.set('name', 'Total Hardness');

var wq_view_Turbidity = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Turbidity',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Turbidity.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Turbidity",
        "label": ""
    }
]

wq_view_Turbidity.set('name', 'Turbidity');

var wq_view_Zinc = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'http://geoserver.aviyaan.com/geoserver/nwash_02/wms',
        params: {
            'LAYERS': 'nwash_02:wq_view_Zinc',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Zinc.legend = [
    {
        "url": "http://geoserver.aviyaan.com/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash_02:wq_view_Zinc",
        "label": ""
    }
]

wq_view_Zinc.set('name', 'Zinc');

var WQParaGroup = new layerGroup("WQParaGroup");
WQParaGroup.addLayer(wq_view_Alumunium);
WQParaGroup.addLayer(wq_view_Ammonia);
WQParaGroup.addLayer(wq_view_Arsenic);
WQParaGroup.addLayer(wq_view_Cadmium);
WQParaGroup.addLayer(wq_view_Calcium);
WQParaGroup.addLayer(wq_view_Chloride);
WQParaGroup.addLayer(wq_view_Chromium);
WQParaGroup.addLayer(wq_view_Color);
WQParaGroup.addLayer(wq_view_Copper);
WQParaGroup.addLayer(wq_view_Cyanide);
WQParaGroup.addLayer(wq_view_Electrical_conductivity);
WQParaGroup.addLayer(wq_view_Faecal_coliform_ecoli);
WQParaGroup.addLayer(wq_view_Faecal_contamination);
WQParaGroup.addLayer(wq_view_Fluoride);
WQParaGroup.addLayer(wq_view_Iron);
WQParaGroup.addLayer(wq_view_Lead);
WQParaGroup.addLayer(wq_view_Manganese);
WQParaGroup.addLayer(wq_view_Mercury);
WQParaGroup.addLayer(wq_view_Nitrate);
WQParaGroup.addLayer(wq_view_Nitrites);
WQParaGroup.addLayer(wq_view_pH);
WQParaGroup.addLayer(wq_view_Residual_Chlorine);
WQParaGroup.addLayer(wq_view_Sulphate);
WQParaGroup.addLayer(wq_view_Taste_odor);
WQParaGroup.addLayer(wq_view_Total_colifom);
WQParaGroup.addLayer(wq_view_Total_dissolved_solids);
WQParaGroup.addLayer(wq_view_Total_hardness);
WQParaGroup.addLayer(wq_view_Turbidity);
WQParaGroup.addLayer(wq_view_Zinc);

var wq_para_arr = [wq_view_Alumunium, wq_view_Ammonia, wq_view_Arsenic, wq_view_Cadmium, wq_view_Calcium, wq_view_Chloride, wq_view_Chromium, wq_view_Color, wq_view_Copper, wq_view_Cyanide, wq_view_Electrical_conductivity, wq_view_Faecal_coliform_ecoli, wq_view_Faecal_contamination, wq_view_Fluoride, wq_view_Iron, wq_view_Lead, wq_view_Manganese, wq_view_Mercury, wq_view_Nitrate, wq_view_Nitrites, wq_view_pH, wq_view_Residual_Chlorine, wq_view_Sulphate, wq_view_Taste_odor, wq_view_Total_colifom, wq_view_Total_dissolved_solids, wq_view_Total_hardness, wq_view_Turbidity, wq_view_Zinc];

function layerGroupCheck(sel_layergrp, type) {
    switch (sel_layergrp) {
        case 'baseMapTheme':
            for (i = 0; i < basemap_arr.length; i++) {
                
                if (type == 'checked') {
                    basemap_arr[i].setVisible(true);
                     $("[id='checkbox_"+basemap_arr[i].get('name')+"']").prop("checked",true);
                     $("[id='checkbox_Contour']").prop("checked",true);
//                    $("#checkbox_"+basemap_arr[i].get('name')).prop("checked",true);
                } else if (type == 'unchecked') {
                    basemap_arr[i].setVisible(false);
                    $("[id='checkbox_"+basemap_arr[i].get('name')+"']").prop("checked",false);
                    $("[id='checkbox_Contour']").prop("checked",false);
                }
//                var set_id = $('#checkbox_' + sel_title);
//                $(set_id).prop("checked", true);
            }
            break;
        case 'lrnTheme':
            for (i = 0; i < lrn_arr.length; i++) {
                if (type == 'checked') {
                    lrn_arr[i].setVisible(true);
                    $("[id='checkbox_"+lrn_arr[i].get('name')+"']").prop("checked",true);
                } else if (type == 'unchecked') {
                    lrn_arr[i].setVisible(false);
                    $("[id='checkbox_"+lrn_arr[i].get('name')+"']").prop("checked",false);
                }
            }
            break;
        case 'washGroup':
            for (i = 0; i < wash_arr.length; i++) {
                if (type == 'checked') {
                    wash_arr[i].setVisible(true);
                    $("[id='checkbox_"+wash_arr[i].get('name')+"']").prop("checked",true);
                } else if (type == 'unchecked') {
                    wash_arr[i].setVisible(false);
                    $("[id='checkbox_"+wash_arr[i].get('name')+"']").prop("checked",false);
                }
            }
            break;
            case 'unservedGroup':
            for (i = 0; i < unservedGroup_arr.length; i++) {
                if (type == 'checked') {
                    unservedGroup_arr[i].setVisible(true);
                    $("[id='checkbox_"+unservedGroup_arr[i].get('name')+"']").prop("checked",true);
                } else if (type == 'unchecked') {
                    unservedGroup_arr[i].setVisible(false);
                    $("[id='checkbox_"+unservedGroup_arr[i].get('name')+"']").prop("checked",false);
                }
            }
            break;
            case 'wspGroup':
            for (i = 0; i < wspGroup_arr.length; i++) {
                if (type == 'checked') {
                    wspGroup_arr[i].setVisible(true);
                    $("[id='checkbox_"+wspGroup_arr[i].get('name')+"']").prop("checked",true);
                } else if (type == 'unchecked') {
                    wspGroup_arr[i].setVisible(false);
                    $("[id='checkbox_"+wspGroup_arr[i].get('name')+"']").prop("checked",false);
                }
            }
            break;
        case 'solidWasteGroup':
            for (i = 0; i < solidwaste_arr.length; i++) {
                if (type == 'checked') {
                    solidwaste_arr[i].setVisible(true);
                    $("[id='checkbox_"+solidwaste_arr[i].get('name')+"']").prop("checked",true);
                } else if (type == 'unchecked') {
                    solidwaste_arr[i].setVisible(false);
                    $("[id='checkbox_"+solidwaste_arr[i].get('name')+"']").prop("checked",false);
                }
            }
            break;
        case 'drainageGroup':
            for (i = 0; i < drainage_arr.length; i++) {
                if (type == 'checked') {
                    drainage_arr[i].setVisible(true);
                    $("[id='checkbox_"+drainage_arr[i].get('name')+"']").prop("checked",true);
                } else if (type == 'unchecked') {
                    drainage_arr[i].setVisible(false);
                    $("[id='checkbox_"+drainage_arr[i].get('name')+"']").prop("checked",false);
                }
            }
            break;
        case 'WQGroup':
            for (i = 0; i < wq_arr.length; i++) {
                if (type == 'checked') {
                    wq_arr[i].setVisible(true);
                    $("[id='checkbox_" + wq_arr[i].get('name')+"']").prop("checked",true);
                } else if (type == 'unchecked') {
                    wq_arr[i].setVisible(false);
                    $("[id='checkbox_" + wq_arr[i].get('name')+"']").prop("checked",false);
                }
            }
            break;
        case 'WQParaGroup':
            for (i = 0; i < wq_para_arr.length; i++) {
                if (type == 'checked') {
                    wq_para_arr[i].setVisible(true);
                    $("[id='checkbox_" + wq_para_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    wq_para_arr[i].setVisible(false);
                    $("[id='checkbox_" + wq_para_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        default:
    }
}