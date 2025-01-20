/* 
 * July 31,2013
 * shprabin@gmail.com
 * 
 */
/* global map, googleGroup, basemap, province_mask, district_mask, muni_mask, tgamp */

var Themes = {
    themesArr: new Array(),
    currentTheme: null,
    minimizedThemes: new Array(),
    addTheme: function (theme)
    {
        this.themesArr.push(theme);
    },
    setCurrentTheme: function (theme)
    {
        this.currentTheme = theme;
    },
    getCurrentTheme: function ()
    {
        return this.currentTheme;
    },
    maximize: function ()
    {
        $('#theme-minimized').hide();
        for (i = 0; i < this.minimizedThemes.length; i++)
        {
            var theme = this.minimizedThemes.pop();
            $(theme.htmlNode).show();

        }
    }


};

//=====================for 3 tier view======================
var Themes1 = {
    themesArr1: new Array(),
    currentTheme1: null,
    minimizedThemes1: new Array(),
    addTheme1: function (theme) {
        this.themesArr1.push(theme);
    },
    setCurrentTheme1: function (theme) {
        this.currentTheme1 = theme;
    },
    getCurrentTheme1: function () {
        return this.currentTheme1;
    },
    maximize: function () {
        $('#theme-minimized').hide();
        for (i = 0; i < this.minimizedThemes1.length; i++) {
            var theme = this.minimizedThemes1.pop();
            $(theme.htmlNode).show();

        }
    }
};
//==================================end=========================

var Theme = function (_layerGroup, _htmlNode, _title, _objName, _buttonType) {
    this.layerGroup = _layerGroup;
    this.htmlNode = _htmlNode;
    this.title = _title;
    this.objName = _objName;
    this.buttonType = _buttonType;

    this.loadOldTheme = function () {
        //get current querylayer(districtLayer) object
        var theme = this;

        $(theme.htmlNode).show();
        var themeLayers = theme.layerGroup.getLayers();

        map.addLayers(themeLayers);
        var htmlContent = theme.layerGroup.getOverlayLayersAsList(theme.htmlNode);
        $(theme.htmlNode + "  .titletext").html(theme.title);
        $(theme.htmlNode + "  .titletext").append('<span class="minimize" onclick="' + this.objName + '.minimize()"></span>' + '<span class="closeicon" onclick="' + this.objName + '.close()"></span>');
        $(theme.htmlNode).html(htmlContent);

    };
    this.loadTheme = function () {
        //get current querylayer(districtLayer) object
        var theme = this;

        $(theme.htmlNode).show();
        var themeLayers = theme.layerGroup.getLayers();

        map.addLayers(themeLayers);
        var htmlContent = theme.layerGroup.getOverlayLayersInLeftMenu();
    };
    this.mergeNewParams = function ()
    {

    };

    this.unloadTheme = function ()
    {
        var themeLayers = this.layerGroup.getLayers();
        for (i = 0; i < themeLayers.length; i++)
        {
            var layer = themeLayers[i];
            map.removeLayer(layer);
        }
        $((Themes.getCurrentTheme()).htmlNode).hide();
        Themes.setCurrentTheme(null);
    };
    //this is close
    this.close = function ()
    {
        var themeLayers = this.layerGroup.getLayers();
        for (i = 0; i < themeLayers.length; i++)
        {
            var layer = themeLayers[i];
            map.removeLayer(layer);
        }
        $(this.htmlNode).hide();
        if (Themes.getCurrentTheme() !== null)
            Themes.setCurrentTheme(null);
    };
    this.minimize = function ()
    {
        $(this.htmlNode).hide();
        $("#theme-minimized").show();
        Themes.minimizedThemes.push(this);
    };

};



/**---------------IDPM Theme--------------------*/

var mapLayers = [];
function loadAllThemes()
{
//    var raster = new ol.layer.Tile({
//        source: new ol.source.OSM()
//                ///////////////////////////////////// loading stamen /////////////////////////        
//                //        source: new ol.source.Stamen({
//                //            layer:'watercolor'
//                //        })
//    });
//    map.addLayer(raster);
    
    var googleTheme = new Theme(googleGroup, "#main-theme-draggable", "Online Basemap", 'googleTheme', 'radio');
    var basemapTheme = new Theme(basemap, "#base-theme-draggable", "Nepal Basemap", 'baseMapTheme', 'checkbox');
    var lrnTheme = new Theme(lrnGroup, "#main-theme-draggable", "Nepal Road Network", 'lrnTheme', 'checkbox');
    var wspTheme = new Theme(wspGroup, "#main-theme-draggable", "Water Supply Projects", 'wspGroup', 'checkbox');
    //var tapTheme = new Theme(tapGroup, "#main-theme-draggable", "Tap", 'tapGroup', 'checkbox');

    //=====================for tap layer as 3rd tier==================================
    var tapTypeTheme = new Theme(tapTypeGroup, "#main-theme-draggable", "Tap Type", 'tapTypeGroup', 'checkbox');
    var tapMeterTheme = new Theme(tapMeterGroup, "#main-theme-draggable", "Meter Availability", 'tapMeterGroup', 'checkbox');
    var supplyHrTheme = new Theme(supplyHrGroup, "#main-theme-draggable", "Supply Hour", 'supplyHrGroup', 'checkbox');
    var waterFlowTheme = new Theme(waterFlowGroup, "#main-theme-draggable", "Water Flow Condition", 'waterFlowGroup', 'checkbox');
    var tapConditionTheme = new Theme(tapConditionGroup, "#main-theme-draggable", "Tap Condition", 'tapConditionGroup', 'checkbox');
    //==============================end===============================================

    var washTheme = new Theme(washGroup, "#main-theme-draggable", "WASH Data", 'washGroup', 'checkbox');
    var washSchoolTheme = new Theme(washSchoolGroup, "#main-theme-draggable", "WASH status of Schools", 'washSchoolGroup', 'checkbox');
    var washHCFTheme = new Theme(washHCFGroup, "#main-theme-draggable", "WASH status of HCF", 'washHCFGroup', 'checkbox');
//    var unservedTheme = new Theme(unservedGroup, "#main-theme-draggable", "Unserved Community", 'unservedGroup', 'checkbox');
    var solidWasteTheme = new Theme(solidWasteGroup, "#main-theme-draggable", "Solid Waste", 'solidWasteGroup', 'checkbox');
    var drainageTheme = new Theme(drainageGroup, "#main-theme-draggable", "Drainage", 'drainageGroup', 'checkbox');
    var WQTheme = new Theme(WQGroup, "#main-theme-draggable", "Water Quality", 'WQGroup', 'checkbox');
    var WQParaTheme = new Theme(WQParaGroup, "#main-theme-draggable", "Water Quality Parameter Data", 'WQParaGroup', 'checkbox');         //Water Quality Parameter wise data
    var agencyMappingTheme = new Theme(agencyMappingGroup, "#main-theme-draggable", "Agency Mapping", 'agencyMappingGroup', 'checkbox'); //Agency Mapping
    var wpsTheme = new Theme(wpsGroup, "#main-theme-draggable", "Wash Plan Status", 'wpsGroup', 'checkbox');    //WPS
    var wpsdgTheme = new Theme(wpsdgGroup, "#main-theme-draggable", "Wash Plan SDG", 'wpsdgGroup', 'checkbox');    //WPS

    var labTheme = new Theme(labGroup, "#main-theme-draggable", "Water Quality Lab", 'labGroup', 'checkbox');    //Lab

    Themes.addTheme(googleTheme);
    Themes.addTheme(basemapTheme);
    Themes.addTheme(lrnTheme);
    Themes.addTheme(wspTheme);
    //Themes.addTheme(tapTheme);

    Themes.addTheme(washTheme);
    Themes.addTheme(washSchoolTheme);
    Themes.addTheme(washHCFTheme);
 //   Themes.addTheme(unservedTheme);
    Themes.addTheme(solidWasteTheme);
    Themes.addTheme(drainageTheme);
    Themes.addTheme(WQTheme);
    Themes.addTheme(WQParaTheme);
    Themes.addTheme(agencyMappingTheme);
    Themes.addTheme(wpsTheme);
    Themes.addTheme(wpsdgTheme);
    Themes.addTheme(labTheme);

    //==============added to Themes1 for 3 tier=========================
    Themes1.addTheme1(tapTypeTheme);
    Themes1.addTheme1(tapMeterTheme);
    Themes1.addTheme1(supplyHrTheme);
    Themes1.addTheme1(waterFlowTheme);
    Themes1.addTheme1(tapConditionTheme);
    //========================end========================================
    
    var htmlContent = "<ol id=\"layers_treeview\">";
    for (var i = 0; i < Themes.themesArr.length; i++)
    {
        var theme = Themes.themesArr[i];
        if (theme.title != 'Online Basemap') {
            //=================for 3 tier view under Tap group ======================
            //if (theme.title == "Water Supply Projects1") {
            //    htmlContent += '<li class="collapsed"><strong>' + theme.title + '</strong>';
            //    var k1 = theme.layerGroup.getLayers();
            //    for (var j = 0; j < k1.length; j++){
            //        if (k1[j].get("name") == "Tap") {
            //            htmlContent += "<ol>";
            //    for (var i = 0; i < Themes1.themesArr1.length; i++) {
            //        var theme1 = Themes1.themesArr1[i];
            //                htmlContent += '<li class="collapsed"><strong>' + theme1.title + ' <input type="checkbox" name="layer_chkbox' + theme1.title + '" id="layer_chkbox_' + theme1.objName + '" onclick="check_checked_layer(\'' + theme1.objName + '\')"></strong>';
            //            if (theme1.buttonType === "checkbox") {
            //                    htmlContent += theme1.layerGroup.getOverlayLayersInLeftMenu();
            //            }
            //            else {
            //                htmlContent += theme1.layerGroup.getOverlayLayersInLeftMenu(true);
            //            }
            //        htmlContent += '</li>';
            //        mapLayers = mapLayers.concat(theme1.layerGroup.getLayers());
            //    }
            //    htmlContent += '</ol>';
            //    htmlContent += '</li>';
            //        }
            //    }

            //    //htmlContent += "<ol>";
            //    //for (var i = 0; i < Themes1.themesArr1.length; i++) {
            //    //    var theme1 = Themes1.themesArr1[i];
            //    //            htmlContent += '<li class="collapsed"><strong>' + theme1.title + ' <input type="checkbox" name="layer_chkbox' + theme1.title + '" id="layer_chkbox_' + theme1.objName + '" onclick="check_checked_layer(\'' + theme1.objName + '\')"></strong>';
            //    //        if (theme1.buttonType === "checkbox") {
            //    //                htmlContent += theme1.layerGroup.getOverlayLayersInLeftMenu();
            //    //        }
            //    //        else {
            //    //            htmlContent += theme1.layerGroup.getOverlayLayersInLeftMenu(true);
            //    //        }
            //    //    htmlContent += '</li>';
            //    //    mapLayers = mapLayers.concat(theme1.layerGroup.getLayers());
            //    //}
            //    //htmlContent += '</ol>';
            //    //htmlContent += '</li>';

            //}
            ////========================end============================
            //else
            //{
                htmlContent += '<li class="collapsed"><strong>' + theme.title + ' <input type="checkbox" name="layer_chkbox' + theme.title + '" id="layer_chkbox_' + theme.objName + '" onclick="check_checked_layer(\'' + theme.objName + '\')"></strong>';
            //}
        } else {
            htmlContent += '<li class="collapsed"><strong>' + theme.title + '</strong>';
        }
        if (theme.title !== 'Online Basemap') {
            if (theme.buttonType === "checkbox") {
                htmlContent += theme.layerGroup.getOverlayLayersInLeftMenu();
            }
            else{
                htmlContent += theme.layerGroup.getOverlayLayersInLeftMenu(true);
            }
        } else {
            htmlContent += theme.layerGroup.getOverlayLayersInLeftMenuasDropdown();
        }
        htmlContent += '</li>';
        mapLayers = mapLayers.concat(theme.layerGroup.getLayers());
    }
    for (var i = 0; i < Themes1.themesArr1.length; i++) {
        var theme1 = Themes1.themesArr1[i];
        mapLayers = mapLayers.concat(theme1.layerGroup.getLayers());
    }


    mapLayers.sort(compare);
    map.getLayers().extend(mapLayers);
    map.addLayer(nationalmask);
    map.addLayer(province_mask);
    map.addLayer(district_mask);
    map.addLayer(muni_mask);
    //map.addLayer(yard_tap);
    //Add Other Extra Layer
    /*map.addLayer(search_road_layer);
     map.addLayer(road_division_mask);
     map.addLayer(road_division_boundary);
     map.addLayer(road_division_name);*/
    /*for (var i = 0; i < mapLayers.length; i++)
     {
     console.log(mapLayers[i].name+" "+mapLayers[i].zIndex);
     }*/
    htmlContent += '</ol>';
    $("#layers_div").html(htmlContent);
    $('#layers_treeview').bonsai();
}

function compare(a, b) {
    if (a.zIndex < b.zIndex)
        return -1;
    else if (a.zIndex > b.zIndex)
        return 1;
    else
        return 0;
}


function loadScriptForAddedTheme()
{

    $('.sortable').accordion({
        collapsible: true,
        active: true,
        heightStyle: "content",
        header: 'h4'
    }).sortable({
        axis: 'y',
        handle: '.sortable-handle',
        items: '.item',
        stop: function (event, ui) {
            // IE doesn't register the blur when sorting
            // so trigger focusout handlers to remove .ui-state-focus
            ui.item.children("h4").triggerHandler("focusout");
        }
    });

    $('.sortable').on('accordionactivate', function (event, ui) {
        if (ui.newPanel.length) {
            $('.sortable').sortable('disable');
        } else {
            $('.sortable').sortable('enable');
        }
    });
}

function check_checked_layer(sel_layergrp) {
    var id = $('#layer_chkbox_' + sel_layergrp);
    if (id.prop('checked') == true) {
        layerGroupCheck(sel_layergrp, 'checked');
    } else {
        layerGroupCheck(sel_layergrp, 'unchecked');
    }
}