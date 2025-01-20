/*kakshyapati@gmail.com
 *02-13-2022
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
                    htmlOut += '<input checked="true" id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:' + obj + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>' + layer.get('name') + "helo";

                } else {
                    htmlOut += '<input id="checkbox_' + layer.id + '" type="checkbox" onclick="javascript:' + obj + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>' + layer.get('name') + "helo1";
                }
                htmlOut += '</h4><div class="accordion_content">';
                if (layer.legend) {
                    for (j = 0; j < layer.legend.length; j++) {
                        htmlOut += "<span class=\"legend\">" + "<img src=\"" + layer.legend[j].url + "\">" + layer.legend[j].label + "1</span>";
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
                        if (layer.getVisible()) {
                            htmlOut += '<input checked="true" name="radio_' + obj + '" id="radio_' + layer.get('name') + '" type="radio" onclick="javascript:' + obj + '.layerCheckedExclusive(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;' + layer.get('name');
                        } else {
                            htmlOut += '<input name="radio_' + obj + '" id="radio_' + layer.get('name') + '" type="radio" onclick="javascript:' + obj + '.layerCheckedExclusive(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;' + layer.get('name');
                        }
                    }
                    else {
                        if (layer.getVisible()) {
                            /////////////////////////////////////////////////////
                            if (layer.get('name') === "Tap") {
                                htmlOut += '<li class="collapsed"><strong>' + layer.get('name') + '</strong>';
                                htmlOut += "<ul>";
                                for (var i = 0; i < Themes1.themesArr1.length; i++) {
                                    var theme1 = Themes1.themesArr1[i];
                                    if (theme1.objName === "tapTypeGroup")
                                        htmlOut += '<li class="collapsed"><strong>' + theme1.title + ' <input type="checkbox" checked name="layer_chkbox' + theme1.title + '" id="layer_chkbox_' + theme1.objName + '" onclick="check_checked_layer(\'' + theme1.objName + '\')"></strong>';
                                    else
                                        htmlOut += '<li class="collapsed"><strong>' + theme1.title + ' <input type="checkbox" name="layer_chkbox' + theme1.title + '" id="layer_chkbox_' + theme1.objName + '" onclick="check_checked_layer(\'' + theme1.objName + '\')"></strong>';
                                    if (theme1.buttonType === "checkbox") {
                                        htmlOut += this.getOverlayLayersInLeftMenu1(i);
                                    }
                                    else {
                                        htmlOut += this.getOverlayLayersInLeftMenu1(i, true);
                                    }
                                    htmlOut += '</li>';
                                    //mapLayers = mapLayers.concat(theme1.layerGroup.getLayers());
                                }
                                htmlOut += '</ul>';
                                htmlOut += '</li>';
                            }
                            ////////////////////////////////////////////////////////////////
                            else {
                                htmlOut += '<input checked="true" id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:' + obj + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;';

                                if (layer.legend && layer.legend.length == 1) {
                                    for (j = 0; j < layer.legend.length; j++) {
                                        htmlOut += "<img src=\"" + layer.legend[j].url + "\">";
                                    }
                                }
                                htmlOut += layer.get('name');
                            }
                        } else {

                            /////////////////////////////////////////////////////
                            if (layer.get('name') === "Tap") {
                                htmlOut += '<li class="collapsed"><strong>' + layer.get('name') + '</strong>';
                                htmlOut += "<ul>";
                                for (var i = 0; i < Themes1.themesArr1.length; i++) {
                                    var theme1 = Themes1.themesArr1[i];
                                    if (theme1.objName === "tapTypeGroup")
                                        htmlOut += '<li class="collapsed"><strong>' + theme1.title + ' <input type="checkbox" checked name="layer_chkbox' + theme1.title + '" id="layer_chkbox_' + theme1.objName + '" onclick="check_checked_layer(\'' + theme1.objName + '\')"></strong>';
                                    else
                                        htmlOut += '<li class="collapsed"><strong>' + theme1.title + ' <input type="checkbox" name="layer_chkbox' + theme1.title + '" id="layer_chkbox_' + theme1.objName + '" onclick="check_checked_layer(\'' + theme1.objName + '\')"></strong>';
                                    if (theme1.buttonType === "checkbox") {
                                        htmlOut += this.getOverlayLayersInLeftMenu1(i);
                                    }
                                    else {
                                        htmlOut += this.getOverlayLayersInLeftMenu1(i, true);
                                    }
                                    htmlOut += '</li>';
                                    //mapLayers = mapLayers.concat(theme1.layerGroup.getLayers());
                                }
                                htmlOut += '</ul>';
                                htmlOut += '</li>';
                            }
                            ////////////////////////////////////////////////////////////////
                            else {
                                htmlOut += '<input id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:' + obj + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;';
                                if (layer.legend && layer.legend.length == 1) {
                                    for (j = 0; j < layer.legend.length; j++) {
                                        htmlOut += "<img src=\"" + layer.legend[j].url + "\">";
                                    }
                                }
                                htmlOut += layer.get('name');
                            }
                        }
                    }
                    if (layer.get('name') != "Tap") {
                        if (layer.legend && layer.legend.length > 1) {
                            htmlOut += '<ul>';
                            for (j = 0; j < layer.legend.length; j++) {
                                htmlOut += "<li><span class=\"legend\">" + "<img src=\"" + layer.legend[j].url + "\">" + layer.legend[j].label + "</span></li>";
                            }
                            htmlOut += '</ul>';
                        }
                    }
                    htmlOut += '</li>';

                }
            }
            htmlOut += '</ul>';
            return htmlOut;
        },
        getOverlayLayersInLeftMenu1: function (k, radioButton) {
            htmlOut = "";
            htmlOut += '<ul>';
            var sortedArr = Themes1.themesArr1[k].layerGroup.getLayers();
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
                        if (layer.getVisible()) {
                            htmlOut += '<input checked="true" name="radio_' + obj + '" id="radio_' + layer.get('name') + '" type="radio" onclick="javascript:' + obj + '.layerCheckedExclusive(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;' + layer.get('name');
                        } else {
                            htmlOut += '<input name="radio_' + obj + '" id="radio_' + layer.get('name') + '" type="radio" onclick="javascript:' + obj + '.layerCheckedExclusive(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;' + layer.get('name');
                        }
                    }
                    else {
                        if (layer.get('visible')) {
                            //if (layer.getVisible()) {   
                            /*htmlOut += '<input checked="true" id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:tapTypeGroup.layerChecked(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;';*/
                            htmlOut += '<input checked="true" id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:' + Themes1.themesArr1[k].objName + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;';
                            if (layer.legend && layer.legend.length == 1) {
                                for (j = 0; j < layer.legend.length; j++) {
                                    htmlOut += "<img src=\"" + layer.legend[j].url + "\">";
                                }
                            }
                            htmlOut += layer.get('name');
                        } else {


                            /*htmlOut += '<input id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:tapTypeGroup.layerChecked(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;';*/
                            htmlOut += '<input id="checkbox_' + layer.get('name') + '" type="checkbox" onclick="javascript:' + Themes1.themesArr1[k].objName + '.layerChecked(event,\'' + layer.get('name') + '\',this)"/>&nbsp;&nbsp;';
                            if (layer.legend && layer.legend.length == 1) {
                                for (j = 0; j < layer.legend.length; j++) {
                                    htmlOut += "<img src=\"" + layer.legend[j].url + "\">";
                                }
                            }
                            htmlOut += layer.get('name');
                        }
                    }
                    if (layer.legend && layer.legend.length > 1) {
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
        // ============================================================================Remove to check for contours
        layerChecked: function (event, layerName, elem) {
            var layer = this.getLayerByName(layerName);
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
        }

    };

}

/*overlay Layer*/

var province_layer = new ol.layer.Tile({
    //extent:[-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash_01:Province_44N',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true
});
province_layer.set('name', 'Province');

//<editor-fold desc="varous mask layer">

var nationalmask = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:Mask_poly_National_boundary',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true,
    zIndex: 100000
});
nationalmask.set('name', 'National Mask');

var province_mask = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_province_mask',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 100000
});
province_mask.set('name', 'Province Mask');

var district_mask = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_district_boundary_mask',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 100000
});
district_mask.set('name', 'District Boundary');


var muni_mask = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash_basemap_localbodies_mask',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 100000
});
muni_mask.set('name', 'Muni Mask');
//</editor-fold>

//<editor-fold desc="Nepal Basemap Layers">
var nationalboundary = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_Nationalline',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true,
    zIndex: 1800
});
nationalboundary.set('name', 'National Line');
nationalboundary.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_basemap_Nationalline&RULE=I zoom",
        "label": "National Boundary"
    }
];

var districtLine = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_Districtline',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    zIndex: 1800
});
districtLine.set('name', 'District Boundary');
//
districtLine.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_basemap_Districtline&RULE=II zoom",
        "label": "District Boundary"
    }
];

var district = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            //'LAYERS': 'nhydro_01:District_Boundary_2017_WGS84',
            'LAYERS': '	nwash:nwash_basemap_district_boundary_label',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    zIndex: 300,
    visible: false
});
district.set('name', 'District');


var vdcboundary = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_VDCboundary',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    zIndex: 500,
    visible: false
});
vdcboundary.set('name', 'VDC Boundary');
vdcboundary.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_basemap_VDCboundary",
        "label": "VDC Boundary"
    }
];


var local_boundry = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_localbodies_line',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    zIndex: 1800,
    visible: true
});
local_boundry.set('name', 'Localbodies Boundary');
local_boundry.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_basemap_localbodies_line&RULE=II zoom",
        "label": "Localbodies Boundary"
    }
];


var settlements = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_settlement',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    zIndex: 1750,
    visible: false
});
settlements.set('name', 'Settlements');
settlements.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_basemap_settlement&RULE=I zoom",
        "label": "Settlements"
    }
];

var ward_boundry = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wardboundary_line,nwash:ward_boundary_45N',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    zIndex: 440,
    visible: false
});
ward_boundry.set('name', 'Ward Boundary');
ward_boundry.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wardboundary_line&RULE=II zoom",
        "label": "Ward Boundary"
    }
];


var majorriver = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_Major_River',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    zIndex: 600,
    visible: false
});
majorriver.set('name', 'Major River');
majorriver.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_basemap_Major_River&RULE=river",
        "label": " Major River"
    }
];

var contour = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_Contour',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    zIndex: 600,
    visible: false
});
contour.set('name', 'Contour');
contour.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_basemap_Contour&RULE=Contour",
        "label": "Contour"
    }
];

var airport = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_basemap_Airport',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    zIndex: 1701,
    visible: false
});
airport.set('name', 'Airport');
airport.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_basemap_Airport&RULE=II zoom",
        "label": "Airport"
    }
];

//var roadDivisionColor = new ol.layer.Tile({
//        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
//        source: new ol.source.TileWMS({
//            url: 'https://geoserver.softwel.com.np/geoserver/ARMP2014/wms',
//            params: {
//                'LAYERS': 'ARMP2014:road_division_color,ARMP2014:DivisionName',
//                'TILED': true,
//            },
//            serverType: 'geoserver',
//            projection: 'EPSG:4269',
//            crossOrigin: 'anonymous'
//        }),
//        zIndex:100,
//    visible:false
//    });
//    roadDivisionColor.set('name','Road Division');

//var elevation = new ol.layer.Tile({
//        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
//        source: new ol.source.TileWMS({
//            url: 'https://geoserver.softwel.com.np/geoserver/WB_LS_Hazard/wms',
//            params: {
//                'LAYERS': 'WB_LS_Hazard:Nepal_dem_44N',
//                'TILED': true,
//            },
//            serverType: 'geoserver',
//            projection: 'EPSG:4269',
//            crossOrigin: 'anonymous'
//        }),
//        zIndex:200,
//    visible:false
//    });
//    elevation.set('name','Elevation Map');

//    var aspectMap = new ol.layer.Tile({
//        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
//        source: new ol.source.TileWMS({
//            url: 'https://geoserver.softwel.com.np/geoserver/tiles/wms',
//            params: {
//                'LAYERS': 'tiles:aspect_1',
//                'TILED': true,
//            },
//            serverType: 'geoserver',
//            projection: 'EPSG:4269',
//            crossOrigin: 'anonymous'
//        }),
//        zIndex:400,
//    visible:false,
//            opacity:0.7
//    });
//    aspectMap.set('name','Aspect Map');

//    aspectMap.legend = [
//    {
//        "url": "assets/img/legend/aspect.PNG",
//        "label": "Aspect Map"
//    }
//];

//var slopeMap = new ol.layer.Tile({
//        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
//        source: new ol.source.TileWMS({
//            url: 'https://geoserver.softwel.com.np/geoserver/tiles/wms',
//            params: {
//                'LAYERS': 'tiles:slope',
//                'TILED': true,
//            },
//            serverType: 'geoserver',
//            projection: 'EPSG:4269',
//            crossOrigin: 'anonymous'
//        }),
//        zIndex:380,
//    visible:false,
//            opacity:0.7
//    });
//    slopeMap.set('name','Slope Map');

//    slopeMap.legend = [
//    {
//        "url": "assets/img/legend/slope.PNG",
//        "label": "Slope Map"
//    }
//];

//vindex is index for displaying the layer in the list
nationalboundary.vindex = 1;
district.vindex = 3;
districtLine.vindex = 2;
vdcboundary.vindex = 6;
ward_boundry.vindex = 5;
local_boundry.vindex = 4;
majorriver.vindex = 7;
settlements.vindex = 8;
airport.vindex = 9;
contour.vindex = 16;



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
basemap.addLayer(airport);
basemap.addLayer(contour);

var basemap_arr = [districtLine, district, nationalboundary, vdcboundary, ward_boundry, local_boundry, majorriver, settlements, airport, contour]// Remove [contour_20, contour_100, contour_500];

//</editor-fold>

//<editor-fold desc="Map Layer">
var tgamp = new ol.layer.Tile({
    source: new ol.source.OSM({
        url: 'https://mt1.google.com/vt/lyrs=s&hl=pl&&x={x}&y={y}&z={z}'
    }),
    zIndex: 1
});
tgamp.set('name', 'Google Satellite');

var tgphy = new ol.layer.Tile({
    source: new ol.source.TileImage({
        url: 'https://mt0.google.com/vt/lyrs=p&hl=en&x={x}&y={y}&z={z}'
    }),
    zIndex: 2
});
tgphy.set('name', 'Google Terrain');

var tgmap = new ol.layer.Tile({
    source: new ol.source.TileImage({
        url: 'https://mt1.google.com/vt/lyrs=m&x={x}&y={y}&z={z}'
    }),
    zIndex: 3
});
tgmap.set('name', 'Google Streets');

var bing_road = new ol.layer.Tile({
    source: new ol.source.BingMaps({
        key: "AuzAZ5dpuR6OxpUPx2mUBezeWtt_V26O2s0JVAG3WoDKaN-IRLeJEP1AnNtcUZ6e",
        imagerySet: 'Road'
    }),
    zIndex: 5,
    visible: false,
    preload: Infinity
});
bing_road.set('name', 'Bing Road');

var bing_aerial = new ol.layer.Tile({
    source: new ol.source.BingMaps({
        key: "AuzAZ5dpuR6OxpUPx2mUBezeWtt_V26O2s0JVAG3WoDKaN-IRLeJEP1AnNtcUZ6e",
        imagerySet: 'Aerial'
    }),
    zIndex: 6,
    visible: false,
    preload: Infinity
});
bing_aerial.set('name', 'Bing Aerial');

var mapnik = new ol.layer.Tile({
    source: new ol.source.OSM(),
    zIndex: 7
});
mapnik.set('name', 'Open Street Map');

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
//        "https://geoserver.softwel.com.np/geoserver/ARMP2014/wms",
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
        url: 'https://geoserver.softwel.com.np/geoserver/ARMP2014/wms',
        params: {
            'LAYERS': 'pavement',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false
});
search_road_layer.set('name', 'Inventory Road Network');


//<editor-fold desc="Nepal Road Network Group">
var armp_ssrn_pavement = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_roadnetwork_srn',
            'TILED': true,
            //CQL_FILTER: "dyear='" + dyear + "'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
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
    visible: false,
    zIndex: 900
});
armp_ssrn_pavement.set('name', 'Strategic Road Network');

armp_ssrn_pavement.legend = [{
    "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_roadnetwork_srn&RULE=50000%20-%203000000%20-%20BT",
    "label": "Black Topped Road"
},
{
    "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_roadnetwork_srn&RULE=50000%20-%203000000%20-%20GR",
    "label": "Gravel Road"
},
{
    "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_roadnetwork_srn&RULE=50000%20-%203000000%20-%20ER",
    "label": "Earthen Road"
},
{
    "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_roadnetwork_srn&RULE=50000 - 3000000 - UC",
    "label": "Under Construction Road"
},
{
    "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_roadnetwork_srn&RULE=50000%20-%203000000%20-%20PL",
    "label": "Planned"
}

];

var lrn_drcn_road = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_roadnetwork_lrn1',
            'TILED': true,
            CQL_FILTER: "road_categ='DRCN'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 1050
});
lrn_drcn_road.set('name', 'District Road Core Network');

lrn_drcn_road.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_roadnetwork_lrn1&RULE=0 - 50000 - DRCN",
        "label": "DRCN"
    }

];

var lrn_ur_road = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_roadnetwork_lrn1',
            'TILED': true,
            CQL_FILTER: "road_categ='UR'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 1051
});
lrn_ur_road.set('name', 'Urban Road');
lrn_ur_road.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_roadnetwork_lrn1&RULE=0 - 50000 - UR",
        "label": "UR"
    }

];

var lrn_vr_road = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_roadnetwork_lrn1',
            'TILED': true,
            CQL_FILTER: "road_categ='VR'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 1052
});
lrn_vr_road.set('name', 'Village Road');
lrn_vr_road.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_roadnetwork_lrn1&RULE=0 - 50000 - VR",
        "label": "VR"
    }

];

var lrnGroup = new layerGroup("lrnGroup");
lrnGroup.addLayer(armp_ssrn_pavement);
lrnGroup.addLayer(lrn_drcn_road);
lrnGroup.addLayer(lrn_ur_road);
lrnGroup.addLayer(lrn_vr_road);

var lrn_arr = [armp_ssrn_pavement, lrn_drcn_road, lrn_vr_road, lrn_ur_road];

//</editor-fold>

//<editor-fold desc="WASH Data Group">
var health_care = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:health_care_facility',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
health_care.set('name', 'Health Care Facility');

health_care.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:health_care_facility&RULE=zoom I",
        "label": "Health Care Facility"
    }
];


var schools = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:tbl_school',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schools.set('name', 'Schools');

schools.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:tbl_school&RULE=zoom II",
        "label": "Schools"
    }
];

var com_sanitation = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:cs_initial_details',
            'TILED': true,
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
com_sanitation.set('name', 'Community Sanitation');

com_sanitation.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:cs_initial_details&Rule=Existing Sanitation System II",
        "label": "Existing Sanitation System"
    },
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:cs_initial_details&Rule=New Sanitation System II",
        "label": "New Sanitation System"
    },
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:cs_initial_details&Rule=Ongoing Sanitation System II",
        "label": "Ongoing Sanitation System"
    }
];

var unserved_pop = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:unserved_initial_details',
            'TILED': true,
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
unserved_pop.set('name', 'Unserved Population');

unserved_pop.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:unserved_initial_details&Rule=New System II",
        "label": "Proposed System"
    },
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:unserved_initial_details&Rule=Ongoing System II",
        "label": "Ongoing System"
    }
];

var householdWash = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:tbl_household',
            'TILED': true,
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
householdWash.set('name', 'Household');

householdWash.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:tbl_household&RULE=zoom I",
        "label": "Household"
    }
];

var publicToilet = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:public_toilet',
            'TILED': true,
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
publicToilet.set('name', 'Public Toilet');

publicToilet.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:public_toilet&RULE=Existing zoom II",
        "label": "Existing"
    },
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:public_toilet&RULE=Proposed zoom II",
        "label": "Proposed"
    }
];

var urbanSan = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:tbl_urban_sanitation',
            'TILED': true,
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
urbanSan.set('name', 'CWIS Urban Sanitation');

urbanSan.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:tbl_urban_sanitation&RULE=II zoom",
        "label": ""
    }
];

var washGroup = new layerGroup("washGroup");
washGroup.addLayer(com_sanitation);
washGroup.addLayer(health_care);
washGroup.addLayer(householdWash);
washGroup.addLayer(publicToilet);
washGroup.addLayer(schools);
washGroup.addLayer(unserved_pop);
washGroup.addLayer(urbanSan);




var wash_arr = [health_care, schools, com_sanitation, householdWash, publicToilet, unserved_pop, urbanSan];

//</editor-fold>

//<editor-fold desc="WASH status of schools Group">
var schoolToiletYes = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.nwash.gov.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_toilet_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "school_latrines_availability='छ'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletYes.set('name', 'Toilet Availability');

schoolToiletYes.legend = [
    {
        "url": "https://geoserver.nwash.gov.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_toilet_availability",
        "label": ""
    }
];

var schoolToiletNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_toilet_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "school_latrines_availability='छैन'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletNo.set('name', 'No Toilet Availability');

schoolToiletNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_toilet_availability&RULE=II zoom not available",
        "label": ""
    }
];
var schoolToiletMHM = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_toilet_mhm_facility',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "usable_female_toilet_with_hygiene<>0"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletMHM.set('name', 'Toilet with MHM facility');

schoolToiletMHM.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_toilet_mhm_facility&RULE=II zoom available",
        "label": ""
    }
];

var schoolToiletMHMNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_toilet_mhm_facility',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "usable_female_toilet_with_hygiene=0"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletMHMNo.set('name', 'Toilet without MHM facility');

schoolToiletMHMNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_toilet_mhm_facility&RULE=II zoom not available",
        "label": ""
    }
];

var schoolToiletDisable = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_toilet_disable_facility',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "usable_toilet_for_disabled<>0"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletDisable.set('name', 'Disabled-friendly toilet availability');

schoolToiletDisable.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_toilet_disable_facility&RULE=II zoom available",
        "label": ""
    }
];

var schoolToiletDisableNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_toilet_disable_facility',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "usable_toilet_for_disabled=0"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletDisableNo.set('name', 'Disabled-friendly toilet not availability');

schoolToiletDisableNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_toilet_disable_facility&RULE=II zoom not available",
        "label": ""
    }
];

var schoolToiletWater = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_water_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "school_water_status='छ'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletWater.set('name', 'Water Availability ');

schoolToiletWater.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_water_availability&RULE=II zoom available",
        "label": ""
    }
];

var schoolToiletWaterNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_water_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "school_water_status='छैन'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletWaterNo.set('name', 'No Water Availability ');

schoolToiletWaterNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_water_availability&RULE=II zoom not available",
        "label": ""
    }
];

//Availability of Water in handwashing Station
var schoolToiletWaterHS = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_handwash_water_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "soap_water_availability_in_handwashing_station='छ'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletWaterHS.set('name', 'Availability of Water &Soap in handwashing Station');

schoolToiletWaterHS.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_handwash_water_availability&RULE=II zoom available",
        "label": ""
    }
];

// Availability of Soap in handwashing Station
var schoolToiletWaterHSNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_school_handwash_water_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "soap_water_availability_in_handwashing_station='छैन'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
schoolToiletWaterHSNo.set('name', 'No Availability of Water &Soap in handwashing Station');

schoolToiletWaterHSNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_school_handwash_water_availability&RULE=II zoom not available",
        "label": ""
    }
];

var washSchoolGroup = new layerGroup("washSchoolGroup");
washSchoolGroup.addLayer(schoolToiletYes);
washSchoolGroup.addLayer(schoolToiletNo);
washSchoolGroup.addLayer(schoolToiletMHM);
washSchoolGroup.addLayer(schoolToiletMHMNo);
washSchoolGroup.addLayer(schoolToiletDisable);
washSchoolGroup.addLayer(schoolToiletDisableNo);
washSchoolGroup.addLayer(schoolToiletWater);
washSchoolGroup.addLayer(schoolToiletWaterNo);
washSchoolGroup.addLayer(schoolToiletWaterHS);
washSchoolGroup.addLayer(schoolToiletWaterHSNo);




var washSchoolGroup_arr = [schoolToiletYes, schoolToiletNo, schoolToiletMHM, schoolToiletMHMNo, schoolToiletDisable, schoolToiletDisableNo, schoolToiletWater, schoolToiletWaterNo, schoolToiletWaterHS, schoolToiletWaterHSNo];
//</editor-fold>



//<editor-fold desc="WASH status of HCF Group">
var hcfToiletYes = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_toilet_availablity',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "hcf_toilstatus='छ'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletYes.set('name', 'Toilet Availability');

hcfToiletYes.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_toilet_availablity&RULE=II zoom available",
        "label": ""
    }
];

var hcfToiletNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_toilet_availablity',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "hcf_toilstatus<>'छ'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletNo.set('name', 'No Toilet Availability');

hcfToiletNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_toilet_availablity&RULE=II zoom not available",
        "label": ""
    }
];
var hcfToiletMHM = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_toilet_mhm_facility',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "usable_female_toilet_with_mhm<>'0'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletMHM.set('name', 'Toilet with MHM facility');

hcfToiletMHM.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_toilet_mhm_facility&RULE=II zoom available",
        "label": ""
    }
];

var hcfToiletMHMNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_toilet_mhm_facility',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "usable_female_toilet_with_mhm='0'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletMHMNo.set('name', 'Toilet without MHM facility');

hcfToiletMHMNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_toilet_mhm_facility&RULE=II zoom not available",
        "label": ""
    }
];

var hcfToiletDisable = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_disable_friendly_toilet_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "usable_disabled_friendly_toilet<>'0' and usable_disabled_friendly_toilet<>'00'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletDisable.set('name', 'Disabled-friendly toilet availability');

hcfToiletDisable.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_disable_friendly_toilet_availability&RULE=II zoom available",
        "label": ""
    }
];

var hcfToiletDisableNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_disable_friendly_toilet_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "usable_disabled_friendly_toilet='0' or usable_disabled_friendly_toilet='00'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletDisableNo.set('name', 'No Disabled-friendly toilet availability');

hcfToiletDisableNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_disable_friendly_toilet_availability&RULE=II zoom not available",
        "label": ""
    }
];

var hcfToiletWater = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_water_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "hcf_source_of_water_status_plan='स्वास्थ्य सँस्थासंग आफ्नै श्रोत छ' or hcf_source_of_water_status_plan='खानेपानीप्रणालीबाट'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletWater.set('name', 'Water Availability');

hcfToiletWater.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_water_availability&RULE=II zoom available",
        "label": ""
    }
];

var hcfToiletWaterNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_water_availability',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "hcf_source_of_water_status_plan='छैन'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletWaterNo.set('name', 'No Water Availability');

hcfToiletWaterNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_water_availability&RULE=II zoom not available",
        "label": ""
    }
];

//Availability of Water &Soap in handwashing Station  
var hcfToiletWaterHS = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_soap_water_facility',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "soap_water_in_handwashing_station='छ'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletWaterHS.set('name', 'Availability of Water &Soap in handwashing Station');

hcfToiletWaterHS.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_soap_water_facility&RULE=II zoom available",
        "label": ""
    }
];

// No Availability of Water &Soap in handwashing Station  
var hcfToiletWaterHSNo = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_hcf_soap_water_facility',
            'TILED': true,
            transparent: true,
            CQL_FILTER: "soap_water_in_handwashing_station<>'छ'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
hcfToiletWaterHSNo.set('name', 'No Availability of Water &Soap in handwashing Station');

hcfToiletWaterHSNo.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_hcf_soap_water_facility&RULE=II zoom not available",
        "label": ""
    }
];

var washHCFGroup = new layerGroup("washHCFGroup");
washHCFGroup.addLayer(hcfToiletYes);
washHCFGroup.addLayer(hcfToiletNo);
washHCFGroup.addLayer(hcfToiletMHM);
washHCFGroup.addLayer(hcfToiletMHMNo);
washHCFGroup.addLayer(hcfToiletDisable);
washHCFGroup.addLayer(hcfToiletDisableNo);
washHCFGroup.addLayer(hcfToiletWater);
washHCFGroup.addLayer(hcfToiletWaterNo);
washHCFGroup.addLayer(hcfToiletWaterHS);
washHCFGroup.addLayer(hcfToiletWaterHSNo);




var washHCFGroup_arr = [hcfToiletYes, hcfToiletNo, hcfToiletMHM, hcfToiletMHMNo, hcfToiletDisable, hcfToiletDisableNo, hcfToiletWater, hcfToiletWaterNo, hcfToiletWaterHS, hcfToiletWaterHSNo];
//</editor-fold>
//<editor-fold desc="Unserved Community Group">

//var unserved = new ol.layer.Tile({
//        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
//        source: new ol.source.TileWMS({
//            url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
//            params: {
//                'LAYERS': 'nwash:unserved_community',
//                'TILED': true,
//            },
//            serverType: 'geoserver',
//            projection: 'EPSG:4269'
//        }),
//    visible:false,
//            zIndex: 2007
//    });
//    unserved.set('name','Unserved Community');

//unserved.legend = [
//    {
//        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:unserved_community&RULE=zoom II",
//        "label": "Unserved Community"
//    }
//];

//var potentialSrc = new ol.layer.Tile({
//        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
//        source: new ol.source.TileWMS({
//            url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
//            params: {
//                'LAYERS': 'nwash:potential_source',
//                'TILED': true,
//            },
//            serverType: 'geoserver',
//            projection: 'EPSG:4269'
//        }),
//    visible:false,
//            zIndex: 2007
//    });
//    potentialSrc.set('name','Potential Source');

//potentialSrc.legend = [
//    {
//        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:potential_source&RULE=zoom I",
//        "label": "Potential Source"
//    }
//];

//var unservedGroup = new layerGroup("unservedGroup");
//unservedGroup.addLayer(unserved);
//unservedGroup.addLayer(potentialSrc);

//var unservedGroup_arr = [unserved, potentialSrc];

//</editor-fold>

//<editor-fold desc="Community Water Supply Project Group">

var project = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:project_details',
            'TILED': true,
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true,
    zIndex: 2007,
    opacity: 0.9
});
project.set('name', 'Water Supply Projects');


project.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:project_details&RULE=zoom II",
        "label": "Project"
    }
];

var project_coverage = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:project_coverage',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true,
    zIndex: 2001,
    opacity: 0.9
});
project_coverage.set('name', 'Project Coverage');

var water_source = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:water_source',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true,
    zIndex: 2007,
    opacity: 0.9
});
water_source.set('name', 'Source');


water_source.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:water_source&RULE=Water_source",
        "label": "Water Source"
    }
];

var reservoir = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:reservoir',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true,
    zIndex: 2008,
    opacity: 0.9
});
reservoir.set('name', 'Reservoir');


reservoir.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:reservoir&RULE=reservoir",
        "label": "Reservoir"
    }
];


var pipe = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:pipe',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2009,
    opacity: 0.9
});
pipe.set('name', 'Pipe');


pipe.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:pipe&RULE=pipe",
        "label": "Pipe"
    }
];

var tap = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:tap',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2012,
    opacity: 0.9
});
tap.set('name', 'Tap');

tap.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:tap&RULE=Community",
        "label": "Community"
    },

    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:tap&RULE=Institutional",
        "label": "Institutional"
    },
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:tap&RULE=Yard",
        "label": "Yard"
    }
];

var structure = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:structure',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2012,
    opacity: 0.9
});
structure.set('name', 'Structure');


structure.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:structure&RULE=Structure",
        "label": "Structure"
    }
];

var junction = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:junction',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2010,
    opacity: 0.9
});
junction.set('name', 'Junction');


junction.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:junction&RULE=zoom I",
        "label": "Junction"
    }
];

//var functionality_framework = new ol.layer.Tile({
//        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
//        source: new ol.source.TileWMS({
//            url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
//            params: {
//                'LAYERS': 'nwash_01:project_details_fun',
//                'TILED': true
//            },
//            serverType: 'geoserver',
//            projection: 'EPSG:4269',
//            crossOrigin: 'anonymous'
//        }),
//    visible:false,
//            zIndex: 2010,
//            opacity:0.9
//    });
//    functionality_framework.set('name','Functionality Framework');


//functionality_framework.legend = [
//    {
//        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=CARE_ims:functionality_framework&RULE=zoom II",
//        "label": "Functionality Framework"
//    }
//];

//var sustainability_framework = new ol.layer.Tile({
//        extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
//        source: new ol.source.TileWMS({
//            url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
//            params: {
//                'LAYERS': 'nwash_01:project_details_fun',
//                'TILED': true
//            },
//            serverType: 'geoserver',
//            projection: 'EPSG:4269',
//            crossOrigin: 'anonymous'
//        }),
//    visible:false,
//            zIndex: 2010,
//            opacity:0.9
//    });
//    sustainability_framework.set('name','Sustainability Framework');


//sustainability_framework.legend = [
//    {
//        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=CARE_ims:sustainability_framework&RULE=zoom II",
//        "label": "Sustainability Framework"
//    }
//];

var leftoutTaps = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:leftout_taps',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2010,
    opacity: 0.9
});
leftoutTaps.set('name', 'LeftoutTaps');


leftoutTaps.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:leftout_taps&RULE=leftout_taps",
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
//wspGroup.addLayer(functionality_framework);
//wspGroup.addLayer(sustainability_framework);
wspGroup.addLayer(leftoutTaps);

var wspGroup_arr = [project, project_coverage, water_source, reservoir, pipe, structure, junction, leftoutTaps];

//</editor-fold>

//<editor-fold desc="Tap Type Group">
var yard_tap = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap',
            'TILED': true,
            CQL_FILTER: "tap_type='Yard'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true,
    zIndex: 2007
});
yard_tap.set('name', 'Yard Tap');

yard_tap.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap&RULE=II zoom Yard",
        "label": ""
    }
];

var community_tap = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap',
            'TILED': true,
            CQL_FILTER: "tap_type='Community'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true,
    zIndex: 2007
});
community_tap.set('name', 'Community Tap');

community_tap.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap&RULE=II zoom Community",
        "label": ""
    }
];

var institutional_tap = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap',
            'TILED': true,
            CQL_FILTER: "tap_type='Institutional'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: true,
    zIndex: 2007
});
institutional_tap.set('name', 'Institutional Tap');

institutional_tap.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap&RULE=II zoom Institutional",
        "label": ""
    }
];

var tapTypeGroup = new layerGroup("tapTypeGroup");
tapTypeGroup.addLayer(yard_tap);
tapTypeGroup.addLayer(community_tap);
tapTypeGroup.addLayer(institutional_tap);

var tapTypeGroup_arr = [yard_tap, community_tap, institutional_tap];
//</editor-fold>



var tapGroup = new layerGroup("tapGroup");



//<editor-fold desc="Meter Availability Group">
var meter_yes = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_meter',
            'TILED': true,
            CQL_FILTER: "tap_meter='Yes'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
meter_yes.set('name', 'Tap with Metered Connection');

meter_yes.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_meter&RULE=Yes",
        "label": ""
    }
];

var meter_no = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_meter',
            'TILED': true,
            CQL_FILTER: "tap_meter <>'Yes'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
meter_no.set('name', 'Tap without Metered Connection');

meter_no.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_meter&RULE=No",
        "label": ""
    }
];

var tapMeterGroup = new layerGroup("tapMeterGroup");
tapMeterGroup.addLayer(meter_yes);
tapMeterGroup.addLayer(meter_no);

var tapMeterGroup_arr = [meter_yes, meter_no];
//</editor-fold>


//<editor-fold desc="Supply Hour Group">
var supplyHr0 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_supply_hour',
            'TILED': true,
            CQL_FILTER: "tap_fhours=0"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
supplyHr0.set('name', 'Water Supply Hour(0 hr)');

supplyHr0.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_supply_hour&RULE=0",
        "label": ""
    }
];

var supplyHr04 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_supply_hour',
            'TILED': true,
            CQL_FILTER: "tap_fhours>0 and tap_fhours<4"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
supplyHr04.set('name', 'Water Supply Hour(0-4hr)');

supplyHr04.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_supply_hour&RULE=0 - 4",
        "label": ""
    }
];

var supplyHr424 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_supply_hour',
            'TILED': true,
            CQL_FILTER: "tap_fhours>=4 and tap_fhours<24"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
supplyHr424.set('name', 'Water Supply Hour(4-24hr)');

supplyHr424.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_supply_hour&RULE=4 - 24",
        "label": ""
    }
];

var supplyHr24 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_supply_hour',
            'TILED': true,
            CQL_FILTER: "tap_fhours>=24"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
supplyHr24.set('name', 'Water Supply Hour(24hr)');

supplyHr24.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_supply_hour&RULE=24",
        "label": ""
    }
];

var supplyHrGroup = new layerGroup("supplyHrGroup");
supplyHrGroup.addLayer(supplyHr0);
supplyHrGroup.addLayer(supplyHr04);
supplyHrGroup.addLayer(supplyHr424);
supplyHrGroup.addLayer(supplyHr24);

var supplyHrGroup_arr = [supplyHr0, supplyHr04, supplyHr424, supplyHr24];

//</editor-fold>


//<editor-fold desc="Water Flow Condition Group">
//Water Flow : No water at all
var waterFlow1 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_water_flow_cond',
            'TILED': true,
            CQL_FILTER: "tap_flow_con='No water at all'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
waterFlow1.set('name', 'No water at all');

waterFlow1.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_water_flow_cond&RULE=No water at all",
        "label": ""
    }
];

//Water Flow : Just sufficient for drinking
var waterFlow2 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_water_flow_cond',
            'TILED': true,
            CQL_FILTER: "tap_flow_con='Just sufficient for drinking'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
waterFlow2.set('name', 'Just sufficient for drinking');

waterFlow2.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_water_flow_cond&RULE=Just sufficient for drinking",
        "label": ""
    }
];

//Water Flow : There is water but not sufficient for drinking
var waterFlow3 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_water_flow_cond',
            'TILED': true,
            CQL_FILTER: "tap_flow_con='There is water but not sufficient for drinking'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
waterFlow3.set('name', 'There is water but not sufficient for drinking');

waterFlow3.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_water_flow_cond&RULE=There is water but not sufficient for drinking",
        "label": ""
    }
];

//Water Flow: Sufficient for drinking and cooking and washing
var waterFlow4 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_water_flow_cond',
            'TILED': true,
            CQL_FILTER: "tap_flow_con='Sufficient for drinking and cooking and washing'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
waterFlow4.set('name', 'Sufficient for drinking and cooking and washing');

waterFlow4.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_water_flow_cond&RULE=Sufficient for drinking and cooking and washing",
        "label": ""
    }
];

//Water Flow: Sufficient for all daily needs
var waterFlow5 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_water_flow_cond',
            'TILED': true,
            CQL_FILTER: "tap_flow_con='Sufficient for all daily needs'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
waterFlow5.set('name', 'Sufficient for all daily needs');

waterFlow5.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_water_flow_cond&RULE=Sufficient for all daily needs",
        "label": ""
    }
];

var waterFlowGroup = new layerGroup("waterFlowGroup");
waterFlowGroup.addLayer(waterFlow1);
waterFlowGroup.addLayer(waterFlow2);
waterFlowGroup.addLayer(waterFlow3);
waterFlowGroup.addLayer(waterFlow4);
waterFlowGroup.addLayer(waterFlow5);

var waterFlowGroup_arr = [waterFlow1, waterFlow2, waterFlow3, waterFlow4, waterFlow5];

//</editor-fold>


//<editor-fold desc="Tap Condition Group">
var tapConditionGood = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_condition',
            'TILED': true,
            CQL_FILTER: "tap_cond='Good'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
tapConditionGood.set('name', 'Good');

tapConditionGood.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_condition&RULE=Good",
        "label": ""
    }
];

var tapConditionMinor = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_condition',
            'TILED': true,
            CQL_FILTER: "tap_cond='Minor Repair'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
tapConditionMinor.set('name', 'Minor Repair');

tapConditionMinor.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_condition&RULE=Minor Repair",
        "label": ""
    }
];

var tapConditionMajor = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_condition',
            'TILED': true,
            CQL_FILTER: "tap_cond='Major Repair'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
tapConditionMajor.set('name', 'Major Repair');

tapConditionMajor.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_condition&RULE=Major Repair",
        "label": ""
    }
];

var tapConditionRe = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash1_tap_condition',
            'TILED': true,
            CQL_FILTER: "tap_cond='Reconstruction'"
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
tapConditionRe.set('name', 'Reconstruction');

tapConditionRe.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash1_tap_condition&RULE=Reconstruction",
        "label": ""
    }
];

var tapConditionGroup = new layerGroup("tapConditionGroup");
tapConditionGroup.addLayer(tapConditionGood);
tapConditionGroup.addLayer(tapConditionMinor);
tapConditionGroup.addLayer(tapConditionMajor);
tapConditionGroup.addLayer(tapConditionRe);

var tapConditionGroup_arr = [tapConditionGood, tapConditionMinor, tapConditionMajor, tapConditionRe];

//</editor-fold>

//<editor-fold desc="Solid Waste">
var benchmarking = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:benchmarking',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
benchmarking.set('name', 'Benchmarking');

benchmarking.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:benchmarking&RULE=zoom II",
        "label": "Benchmarking"
    }
];

var disposal_point = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:disposal_point',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
disposal_point.set('name', 'Disposal Point');

disposal_point.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:disposal_point&RULE=zoom II",
        "label": "Disposal Point"
    }
];

var route_point = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:route_point',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
route_point.set('name', 'Route Point');

route_point.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:route_point&RULE=zoom II",
        "label": "Route Point"
    }
];

var skips = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:skips',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
skips.set('name', 'Skips');

skips.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:skips&RULE=zoom II",
        "label": "Skips"
    }
];

var street_sweeping = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:street_sweeping',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
street_sweeping.set('name', 'Street Sweeping');

street_sweeping.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:street_sweeping&RULE=zoom II",
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
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:drainage_point',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
drainage_point.set('name', 'Drainage Point');

drainage_point.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:drainage_point&RULE=zoom II",
        "label": "Drainage Point"
    }
];

var flood_benchmarking = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:flood_benchmarking',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
flood_benchmarking.set('name', 'Flood Benchmarking');

flood_benchmarking.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:flood_benchmarking&RULE=zoom II",
        "label": "Flood Benchmarking"
    }
];

var manhole = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:manhole',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
manhole.set('name', 'Manhole');

manhole.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:manhole&RULE=II zoom",
        "label": "Manhole"
    }
];

var outfall = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:outfall',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
outfall.set('name', 'Outfall');

outfall.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:outfall&RULE=zoom II",
        "label": "Outfall"
    }
];

var rain_inlet = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:rain_inlet',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
rain_inlet.set('name', 'Rain Inlet');

rain_inlet.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:rain_inlet&RULE=zoom II",
        "label": "Rain Inlet"
    }
];

var sanitation_benchmarking = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:sanitation_benchmarking',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
sanitation_benchmarking.set('name', 'Sanitation Benchmarking');


sanitation_benchmarking.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:sanitation_benchmarking&RULE=zoom II",
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
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:arsenic_his',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_arsenic.set('name', 'Historical Arsenic Data');


wq_arsenic.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:arsenic_his&RULE=0-10",
        "label": "0-10 (per &micro;g/L)"
    },
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:arsenic_his&RULE=10-50",
        "label": "10-50 (per &micro;g/L)"
    },
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:arsenic_his&RULE=>50",
        "label": "> 50 (per &micro;g/L)"
    }
];

var wq_watersafe_comm = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:watersafe_community',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_watersafe_comm.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:watersafe_community",
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
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Aluminium',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Alumunium.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Aluminium",
        "label": ""
    }
]
wq_view_Alumunium.set('name', 'Aluminium');

var wq_view_Ammonia = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Ammonia',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Ammonia.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Ammonia",
        "label": ""
    }
]

wq_view_Ammonia.set('name', 'Ammonia');

var wq_view_Arsenic = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Arsenic',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Arsenic.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Arsenic",
        "label": ""
    }
]

wq_view_Arsenic.set('name', 'Arsenic');

var wq_view_Cadmium = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Cadmium',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Cadmium.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Cadmium",
        "label": ""
    }
]

wq_view_Cadmium.set('name', 'Cadmium');

var wq_view_Calcium = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Calcium',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Calcium.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Calcium",
        "label": ""
    }
]

wq_view_Calcium.set('name', 'Calcium');

var wq_view_Chloride = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Chloride',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Chloride.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Chloride",
        "label": ""
    }
]

wq_view_Chloride.set('name', 'Chloride');

var wq_view_Chromium = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Chromium',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Chromium.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Chromium",
        "label": ""
    }
]

wq_view_Chromium.set('name', 'Chromium');

var wq_view_Color = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Color',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Color.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Color",
        "label": ""
    }
]

wq_view_Color.set('name', 'Color');

var wq_view_Copper = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Copper',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Copper.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Copper",
        "label": ""
    }
]

wq_view_Copper.set('name', 'Copper');

var wq_view_Cyanide = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Cyanide',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Cyanide.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Cyanide",
        "label": ""
    }
]

wq_view_Cyanide.set('name', 'Cyanide');

var wq_view_Electrical_conductivity = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Electrical_conductivity',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Electrical_conductivity.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Electrical_conductivity",
        "label": ""
    }
]

wq_view_Electrical_conductivity.set('name', 'Electrical Conductivity');

var wq_view_Faecal_coliform_ecoli = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Faecal_coliform_ecoli',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Faecal_coliform_ecoli.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Faecal_coliform_ecoli",
        "label": ""
    }
]

wq_view_Faecal_coliform_ecoli.set('name', 'Faecal Coliform EColi');

var wq_view_Faecal_contamination = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Faecal_contamination',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Faecal_contamination.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Faecal_contamination",
        "label": ""
    }
]

wq_view_Faecal_contamination.set('name', 'Faecal Contamination');

var wq_view_Fluoride = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Fluoride',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Fluoride.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Fluoride",
        "label": ""
    }
]

wq_view_Fluoride.set('name', 'Fluoride');

var wq_view_Iron = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Iron',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Iron.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Iron",
        "label": ""
    }
]

wq_view_Iron.set('name', 'Iron');

var wq_view_Lead = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Lead',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Lead.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Lead",
        "label": ""
    }
]

wq_view_Lead.set('name', 'Lead');

var wq_view_Manganese = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Manganese',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Manganese.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Manganese",
        "label": ""
    }
]

wq_view_Manganese.set('name', 'Manganese');

var wq_view_Mercury = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Mercury',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Mercury.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Mercury",
        "label": ""
    }
]

wq_view_Mercury.set('name', 'Mercury');

var wq_view_Nitrate = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Nitrate',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Nitrate.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Nitrate",
        "label": ""
    }
]

wq_view_Nitrate.set('name', 'Nitrate');

var wq_view_Nitrites = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Nitrites',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Nitrites.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Nitrites",
        "label": ""
    }
]

wq_view_Nitrites.set('name', 'Nitrites');

var wq_view_pH = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_pH',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_pH.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_pH",
        "label": ""
    }
]

wq_view_pH.set('name', 'pH');

var wq_view_Residual_Chlorine = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Residual_Chlorine',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Residual_Chlorine.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Residual_Chlorine",
        "label": ""
    }
]

wq_view_Residual_Chlorine.set('name', 'Residual Chlorine');

var wq_view_Sulphate = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Sulphate',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Sulphate.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Sulphate",
        "label": ""
    }
]

wq_view_Sulphate.set('name', 'Sulphate');

var wq_view_Taste_odor = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Taste_odor',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Taste_odor.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Taste_odor",
        "label": ""
    }
]

wq_view_Taste_odor.set('name', 'Taste and Odor');

var wq_view_Total_colifom = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Total_colifom',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Total_colifom.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Total_colifom",
        "label": ""
    }
]

wq_view_Total_colifom.set('name', 'Total Colifom');

var wq_view_Total_dissolved_solids = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Total_dissolved_solids',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Total_dissolved_solids.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Total_dissolved_solids",
        "label": ""
    }
]

wq_view_Total_dissolved_solids.set('name', 'Total Dissolved Solids');

var wq_view_Total_hardness = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Total_hardness',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Total_hardness.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Total_hardness",
        "label": ""
    }
]

wq_view_Total_hardness.set('name', 'Total Hardness');

var wq_view_Turbidity = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Turbidity',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Turbidity.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Turbidity",
        "label": ""
    }
]

wq_view_Turbidity.set('name', 'Turbidity');

var wq_view_Zinc = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:wq_view_Zinc',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
wq_view_Zinc.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:wq_view_Zinc",
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

//<editor-fold desc="Agency Mapping">

var washPlanAgencyENPHO = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='ENPHO'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyENPHO.set('name', 'ENPHO');

washPlanAgencyENPHO.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=ENPHO",
        "label": "ENPHO"
    }
];

var washPlanAgencyGWTN = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='GWTN/RWEPP'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyGWTN.set('name', 'GWTN/RWEPP');

washPlanAgencyGWTN.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=GWTN/RWEPP",
        "label": "GWTN/RWEPP"
    }
];

var washPlanAgencyHelvitas = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='HELVETAS, NEPAL'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyHelvitas.set('name', 'HELVETAS, NEPAL');

washPlanAgencyHelvitas.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=HELVETAS",
        "label": "HELVETAS, NEPAL"
    }
];

var washPlanAgencyLumanti = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='Lumanti'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyLumanti.set('name', 'Lumanti');

washPlanAgencyLumanti.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=Lumanti",
        "label": "Lumanti"
    }
];

var washPlanAgencyMOPID = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='MOPID'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyMOPID.set('name', 'MOPID');

washPlanAgencyMOPID.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=MOPID",
        "label": "MOPID"
    }
];

var washPlanAgencyMoTRUD = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='MoTRUD'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyMoTRUD.set('name', 'MoTRUD');

washPlanAgencyMoTRUD.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=MoTRUD",
        "label": "MoTRUD"
    }
];

var washPlanAgencyMunicipality = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='Municipality'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyMunicipality.set('name', 'Municipality');

washPlanAgencyMunicipality.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=Municipality",
        "label": "Municipality"
    }
];

var washPlanAgencyNEWAH = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='NEWAH'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyNEWAH.set('name', 'NEWAH');

washPlanAgencyNEWAH.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=NEWAH",
        "label": "NEWAH"
    }
];

var washPlanAgencyOXFAM = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='OXFAM'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyOXFAM.set('name', 'OXFAM');

washPlanAgencyOXFAM.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=OXFAM",
        "label": "OXFAM"
    }
];

var washPlanAgencyPLAN = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='Plan International Nepal'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyPLAN.set('name', 'Plan International Nepal');

washPlanAgencyPLAN.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=Plan International Nepal",
        "label": "Plan International Nepal"
    }
];



var washPlanAgencyRVWRMP = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='RVWRMP'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyRVWRMP.set('name', 'RVWRMP');

washPlanAgencyRVWRMP.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=RVWRMP",
        "label": "RVWRMP"
    }
];

var washPlanAgencySUSWA = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='Sustainable WASH for All'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencySUSWA.set('name', 'Sustainable WASH for All');

washPlanAgencySUSWA.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=Sustainable WASH for All",
        "label": "Sustainable WASH for All"
    }
];

var washPlanAgencyUNICEF = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='UNICEF'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyUNICEF.set('name', 'UNICEF');

washPlanAgencyUNICEF.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=UNICEF",
        "label": "UNICEF"
    }
];

var washPlanAgencyUSAID = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='USAID Karnali Water Activity'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyUSAID.set('name', 'USAID Karnali Water Activity');

washPlanAgencyUSAID.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=USAID Karnali Water Activity",
        "label": "USAID Karnali Water Activity"
    }
];

var washPlanAgencyWaterAid = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='WaterAid'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyWaterAid.set('name', 'WaterAid');

washPlanAgencyWaterAid.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=WaterAid",
        "label": "WaterAid"
    }
];

var washPlanAgencyWHH = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='WHH'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyWHH.set('name', 'WHH');

washPlanAgencyWHH.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=WHH",
        "label": "WHH"
    }
];

var washPlanAgencyWWSD5 = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_washplan_agency',
            'TILED': true,
            CQL_FILTER: "washplan_agency='WSSD5'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007
});
washPlanAgencyWWSD5.set('name', 'WSSD5');

washPlanAgencyWWSD5.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_washplan_agency&RULE=WWSD5",
        "label": "WSSD5"
    }
];

var agencyMappingGroup = new layerGroup("agencyMappingGroup");
agencyMappingGroup.addLayer(washPlanAgencyENPHO);
agencyMappingGroup.addLayer(washPlanAgencyGWTN);
agencyMappingGroup.addLayer(washPlanAgencyHelvitas);
agencyMappingGroup.addLayer(washPlanAgencyLumanti);
agencyMappingGroup.addLayer(washPlanAgencyMOPID);
agencyMappingGroup.addLayer(washPlanAgencyMoTRUD);
agencyMappingGroup.addLayer(washPlanAgencyMunicipality);
agencyMappingGroup.addLayer(washPlanAgencyNEWAH);
agencyMappingGroup.addLayer(washPlanAgencyOXFAM);
agencyMappingGroup.addLayer(washPlanAgencyPLAN);
agencyMappingGroup.addLayer(washPlanAgencyRVWRMP);
agencyMappingGroup.addLayer(washPlanAgencySUSWA);
agencyMappingGroup.addLayer(washPlanAgencyUNICEF);
agencyMappingGroup.addLayer(washPlanAgencyUSAID);
agencyMappingGroup.addLayer(washPlanAgencyWaterAid);
agencyMappingGroup.addLayer(washPlanAgencyWHH);
agencyMappingGroup.addLayer(washPlanAgencyWWSD5);

var agencyMappingGroup_arr = [washPlanAgencyENPHO, washPlanAgencyGWTN, washPlanAgencyHelvitas, washPlanAgencyLumanti, washPlanAgencyMOPID, washPlanAgencyMoTRUD, washPlanAgencyMunicipality, washPlanAgencyNEWAH, washPlanAgencyOXFAM, washPlanAgencyPLAN, washPlanAgencyRVWRMP, washPlanAgencySUSWA, washPlanAgencyUNICEF, washPlanAgencyUSAID, washPlanAgencyWaterAid, washPlanAgencyWHH, washPlanAgencyWWSD5];

//</editor-fold>

//<editor-fold desc="Wash Plan Status">

var wps_completed = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_progress_status',
            'TILED': true,
            CQL_FILTER: "washplan_status='Completed'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 200,
    opacity: 0.9
});
wps_completed.set('name', 'Completed');

wps_completed.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_progress_status&RULE=Completed",
        "label": "Completed"
    }
];

var wps_ongoing = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_progress_status',
            'TILED': true,
            CQL_FILTER: "washplan_status='Ongoing'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 200,
    opacity: 0.9
});
wps_ongoing.set('name', 'Ongoing');

wps_ongoing.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_progress_status&RULE=Ongoing",
        "label": "Ongoing"
    }
];

var wps_not_started = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_progress_status',
            'TILED': true,
            CQL_FILTER: "washplan_status='Not started'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 200,
    opacity: 0.9
});
wps_not_started.set('name', 'Not Started');

wps_not_started.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_progress_status&RULE=Not Started",
        "label": "Not Started"
    }
];

var wps_unregistered = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:v_agency_mapping_progress_status',
            'TILED': true,
            CQL_FILTER: "washplan_status='Unregistered'",
            transparent: true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 200,
    opacity: 0.9
});
wps_unregistered.set('name', 'Unregistered');

wps_unregistered.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:v_agency_mapping_progress_status&RULE=Unregistered",
        "label": "Unregistered"
    }
];

var wpsGroup = new layerGroup("wpsGroup");
wpsGroup.addLayer(wps_completed);
wpsGroup.addLayer(wps_ongoing);
wpsGroup.addLayer(wps_not_started);
wpsGroup.addLayer(wps_unregistered);

var wpsGroup_arr = [wps_completed, wps_ongoing, wps_not_started, wps_unregistered];

//</editor-fold>

//<editor-fold desc="Wash Plan SDG">
var piped_system_service = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.softwel.com.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:pipedsystem_graph_data',
            'TILED': true
        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007,
    opacity: 0.6
});
piped_system_service.legend = [
    {
        "url": "https://geoserver.softwel.com.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:pipedsystem_graph_data",
        "label": ""
    }
]

piped_system_service.set('name', 'Piped System Service');

var wpsdgGroup = new layerGroup("wpsdgGroup");
wpsdgGroup.addLayer(piped_system_service);

var wpsdgGroup_arr = [piped_system_service];


//<editor-fold desc="Wash Quality lab">
var dwssm_lab = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.nwash.gov.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_lab_registration',
            'TILED': true,
            CQL_FILTER: "lab_type=1 and lab_sub_type=1"

        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007,
    opacity: 0.6
});
dwssm_lab.legend = [
    {
        "url": "https://geoserver.nwash.gov.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_lab_registration&RULE=Laboratories under DWSSM I",
        "label": ""
    }
]

dwssm_lab.set('name', 'DWSSM');





var surveillance_lab = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.nwash.gov.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_lab_registration',
            'TILED': true,
            CQL_FILTER: "lab_type=1 and lab_sub_type=2"

        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007,
    opacity: 0.6
});
surveillance_lab.legend = [
    {
        "url": "https://geoserver.nwash.gov.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_lab_registration&RULE=laboratories of surveillance Agencies I",
        "label": ""
    }
]

surveillance_lab.set('name', 'Surveillance Agencies');

var provincial_lab = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.nwash.gov.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_lab_registration',
            'TILED': true,
            CQL_FILTER: "lab_type=1 and lab_sub_type=3"

        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007,
    opacity: 0.6
});
provincial_lab.legend = [
    {
        "url": "https://geoserver.nwash.gov.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_lab_registration&RULE=Provincial Lab I",
        "label": ""
    }
]

provincial_lab.set('name', 'Provincial Lab');

var municipality_lab = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.nwash.gov.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_lab_registration',
            'TILED': true,
            CQL_FILTER: "lab_type=1 and lab_sub_type=4"

        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007,
    opacity: 0.6
});
municipality_lab.legend = [
    {
        "url": "https://geoserver.nwash.gov.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_lab_registration&RULE=Municipality Lab I",
        "label": ""
    }
]

municipality_lab.set('name', 'Municipality Lab');



var private_lab = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.nwash.gov.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_lab_registration',
            'TILED': true,
            CQL_FILTER: "lab_type=2 and lab_sub_type=0"

        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007,
    opacity: 0.6
});
private_lab.legend = [
    {
        "url": "https://geoserver.nwash.gov.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_lab_registration&RULE=Private Lab I",
        "label": ""
    }
]

private_lab.set('name', 'Private Lab');

var committee_lab = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.nwash.gov.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_lab_registration',
            'TILED': true,
            CQL_FILTER: "lab_type=3 and lab_sub_type=0"

        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007,
    opacity: 0.6
});
committee_lab.legend = [
    {
        "url": "https://geoserver.nwash.gov.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_lab_registration&RULE=User's Committee Lab I",
        "label": ""
    }
]

committee_lab.set('name', 'User\'s Committee Lab');

var ingo_lab = new ol.layer.Tile({
    extent: [-20037508.34, -20037508.34, 20037508.34, 20037508.34],
    source: new ol.source.TileWMS({
        url: 'https://geoserver.nwash.gov.np/geoserver/nwash/wms',
        params: {
            'LAYERS': 'nwash:nwash_lab_registration',
            'TILED': true,
            CQL_FILTER: "lab_type=4 and lab_sub_type=0"

        },
        serverType: 'geoserver',
        projection: 'EPSG:4269',
        crossOrigin: 'anonymous'
    }),
    visible: false,
    zIndex: 2007,
    opacity: 0.6
});
ingo_lab.legend = [
    {
        "url": "https://geoserver.nwash.gov.np/geoserver/wms?REQUEST=GetLegendGraphic&VERSION=1.0.0&FORMAT=image/png&WIDTH=40&HEIGHT=20&LAYER=nwash:nwash_lab_registration&RULE=I/NGO Lab I",
        "label": ""
    }
]

ingo_lab.set('name', 'I/NGO Lab');

var labGroup = new layerGroup("labGroup");
labGroup.addLayer(dwssm_lab);
labGroup.addLayer(surveillance_lab);
labGroup.addLayer(provincial_lab);
labGroup.addLayer(municipality_lab);
labGroup.addLayer(private_lab);
labGroup.addLayer(committee_lab);
labGroup.addLayer(ingo_lab);

var labGroup_arr = [dwssm_lab, surveillance_lab, provincial_lab, municipality_lab, private_lab, committee_lab ,ingo_lab];


function layerGroupCheck(sel_layergrp, type) {
    switch (sel_layergrp) {
        case 'baseMapTheme':
            for (i = 0; i < basemap_arr.length; i++) {

                if (type == 'checked') {
                    basemap_arr[i].setVisible(true);
                    $("[id='checkbox_" + basemap_arr[i].get('name') + "']").prop("checked", true);
                    $("[id='checkbox_Contour']").prop("checked", true);
                    //                    $("#checkbox_"+basemap_arr[i].get('name')).prop("checked",true);
                } else if (type == 'unchecked') {
                    basemap_arr[i].setVisible(false);
                    $("[id='checkbox_" + basemap_arr[i].get('name') + "']").prop("checked", false);
                    $("[id='checkbox_Contour']").prop("checked", false);
                }
                //                var set_id = $('#checkbox_' + sel_title);
                //                $(set_id).prop("checked", true);
            }
            break;
        case 'lrnTheme':
            for (i = 0; i < lrn_arr.length; i++) {
                if (type == 'checked') {
                    lrn_arr[i].setVisible(true);
                    $("[id='checkbox_" + lrn_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    lrn_arr[i].setVisible(false);
                    $("[id='checkbox_" + lrn_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'washGroup':
            for (i = 0; i < wash_arr.length; i++) {
                if (type == 'checked') {
                    wash_arr[i].setVisible(true);
                    $("[id='checkbox_" + wash_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    wash_arr[i].setVisible(false);
                    $("[id='checkbox_" + wash_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        //case 'unservedGroup':
        //for (i = 0; i < unservedGroup_arr.length; i++) {
        //    if (type == 'checked') {
        //        unservedGroup_arr[i].setVisible(true);
        //        $("[id='checkbox_"+unservedGroup_arr[i].get('name')+"']").prop("checked",true);
        //    } else if (type == 'unchecked') {
        //        unservedGroup_arr[i].setVisible(false);
        //        $("[id='checkbox_"+unservedGroup_arr[i].get('name')+"']").prop("checked",false);
        //    }
        //}
        //break;
        case 'wspGroup':
            for (i = 0; i < wspGroup_arr.length; i++) {
                if (type == 'checked') {
                    wspGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + wspGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    wspGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + wspGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'solidWasteGroup':
            for (i = 0; i < solidwaste_arr.length; i++) {
                if (type == 'checked') {
                    solidwaste_arr[i].setVisible(true);
                    $("[id='checkbox_" + solidwaste_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    solidwaste_arr[i].setVisible(false);
                    $("[id='checkbox_" + solidwaste_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'drainageGroup':
            for (i = 0; i < drainage_arr.length; i++) {
                if (type == 'checked') {
                    drainage_arr[i].setVisible(true);
                    $("[id='checkbox_" + drainage_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    drainage_arr[i].setVisible(false);
                    $("[id='checkbox_" + drainage_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'WQGroup':
            for (i = 0; i < wq_arr.length; i++) {
                if (type == 'checked') {
                    wq_arr[i].setVisible(true);
                    $("[id='checkbox_" + wq_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    wq_arr[i].setVisible(false);
                    $("[id='checkbox_" + wq_arr[i].get('name') + "']").prop("checked", false);
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
        case 'agencyMappingGroup':
            for (i = 0; i < agencyMappingGroup_arr.length; i++) {
                if (type == 'checked') {
                    agencyMappingGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + agencyMappingGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    agencyMappingGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + agencyMappingGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'wpsGroup':
            for (i = 0; i < wpsGroup_arr.length; i++) {
                if (type == 'checked') {
                    wpsGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + wpsGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    wpsGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + wpsGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'wpsdgGroup':
            for (i = 0; i < wpsdgGroup_arr.length; i++) {
                if (type == 'checked') {
                    wpsdgGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + wpsdgGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    wpsdgGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + wpsdgGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'tapTypeGroup':
            for (i = 0; i < tapTypeGroup_arr.length; i++) {
                if (type == 'checked') {
                    tapTypeGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + tapTypeGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    tapTypeGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + tapTypeGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'tapMeterGroup':
            for (i = 0; i < tapMeterGroup_arr.length; i++) {
                if (type == 'checked') {
                    tapMeterGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + tapMeterGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    tapMeterGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + tapMeterGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'supplyHrGroup':
            for (i = 0; i < supplyHrGroup_arr.length; i++) {
                if (type == 'checked') {
                    supplyHrGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + supplyHrGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    supplyHrGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + supplyHrGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'waterFlowGroup':
            for (i = 0; i < waterFlowGroup_arr.length; i++) {
                if (type == 'checked') {
                    waterFlowGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + waterFlowGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    waterFlowGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + waterFlowGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'tapConditionGroup':
            for (i = 0; i < tapConditionGroup_arr.length; i++) {
                if (type == 'checked') {
                    tapConditionGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + tapConditionGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    tapConditionGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + tapConditionGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'washSchoolGroup':
            for (i = 0; i < washSchoolGroup_arr.length; i++) {
                if (type == 'checked') {
                    washSchoolGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + washSchoolGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    washSchoolGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + washSchoolGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'washHCFGroup':
            for (i = 0; i < washHCFGroup_arr.length; i++) {
                if (type == 'checked') {
                    washHCFGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + washHCFGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    washHCFGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + washHCFGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        case 'labGroup':
            for (i = 0; i < labGroup_arr.length; i++) {
                if (type == 'checked') {
                    labGroup_arr[i].setVisible(true);
                    $("[id='checkbox_" + labGroup_arr[i].get('name') + "']").prop("checked", true);
                } else if (type == 'unchecked') {
                    labGroup_arr[i].setVisible(false);
                    $("[id='checkbox_" + labGroup_arr[i].get('name') + "']").prop("checked", false);
                }
            }
            break;
        default:
    }
}