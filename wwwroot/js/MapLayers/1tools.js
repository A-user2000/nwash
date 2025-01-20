/* 
 * shprabin@gmail.com 
 * 01-Aug-2013
 * openlayers 2 to ol5 
 * kakshyapati@gmail.com 
 * 15-Sep-2019
 */

var selectedLayer = new Array();
var selectedUrl;
var url;
//var elem;
var Tools = {
    toolsArr: new Array(),
    initialize: function () {

        for (i = 0; i < this.toolsArr.length; i++)
        {
            var tool = this.toolsArr[i].tool;
            $(tool.node).click(function () {
                //map.addInteraction(tool);
                tool.activate();
            });
        }
    },
    addTools: function (_toolsArr) {
        for (i = 0; i < _toolsArr.length; i++)
        {
            this.toolsArr.push(_toolsArr[i])
        }

    },
    deactivateAllTools: function ()
    {
        var dragZoom;
        var dragPan;
        var selectIdentify;
        map.getInteractions().forEach(function (interaction) {
            if (interaction instanceof ol.interaction.DragZoom) {
                dragZoom = interaction;
            }
            if (interaction instanceof ol.interaction.DragPan) {
                dragPan = interaction;
            }
            if (interaction instanceof ol.interaction.Select) {
                selectIdentify = interaction;
            }
        });
        if (dragZoom)
            map.removeInteraction(dragZoom);
        if (dragPan)
            map.removeInteraction(dragPan);
        if (selectIdentify)
            map.removeInteraction(selectIdentify);

//        for (i = 0; i < this.toolsArr.length; i++)
//        {
//            map.removeInteraction(this.toolsArr[i]);
//        }
    },
    deactivateZoomTools: function ()
    {
        var dragZoom;
        var selectIdentify;
        map.getInteractions().forEach(function (interaction) {
            if (interaction instanceof ol.interaction.DragZoom) {
                dragZoom = interaction;
            }
            if (interaction instanceof ol.interaction.Select) {
                selectIdentify = interaction;
            }
        });
        if (dragZoom)
            map.removeInteraction(dragZoom);
        if (selectIdentify)
            map.removeInteraction(selectIdentify);

//        for (i = 0; i < this.toolsArr.length; i++)
//        {
//            map.removeInteraction(this.toolsArr[i]);
//        }
    }

};
var ToolHelper = function (objName, _tool, _name, _active, _node, _activeClass, _inactiveClass, _mouseOverClass, _mouseOutClass, _cursor)
{
    this.objName = objName;
    this.tool = _tool;
    this.name = _name;
    this.active = _active;
    this.node = _node;
    this.activeClass = _activeClass;
    this.inactiveClass = _inactiveClass;
    this.mouseOverClass = _mouseOverClass;
    this.mouseOutClass = _mouseOutClass;
    //This prop is only for identify tool
    this.identifylayer = null;
    this.cursor = _cursor;
    this.activate = function ()
    {

        if (objName === "identifyToolHelper") {
            Tools.deactivateZoomTools();
        } else {
            Tools.deactivateAllTools();
        }

        //if(this.tool !== null){
        map.addInteraction(this.tool);
        //console.log(this.tool);
        //}
        //this.tool.activate();
        $(this.node).attr("class", this.activeClass);
        $('#mapDiv').css('cursor', this.cursor);

        //map.getInteractions().extend([this.tool]);
        //selectedLayer.set('selectable',true);


        if (objName === "identifyToolHelper") {
            map.removeEventListener('singleclick');
            this.IdentifyToolHelperClick();
        }

    };
    this.deactivate = function ()
    {
        //this.tool.deactivate();
        map.removeInteraction(this.tool);
        //map.getInteractions().pop()
        $(this.node).attr("class", this.inactiveClass);
    };
    this.IdentifyToolHelperClick = function ()
    {
        map.on('singleclick', function (e) {
            var elem1 = document.getElementById('popup-content');
            elem1.innerHTML = '';
            var viewResolution = map.getView().getResolution();

            selectedLayer.forEach(function (layer) {
                url1 = layer.getSource().getGetFeatureInfoUrl(e.coordinate, viewResolution, 'EPSG:3857', {'INFO_FORMAT': 'application/json'});
                if (url1) {
                    $.ajax({
                        url: url1,
                        success: function (data) {
                            var event = (data);
                            var feature = event.features;
                            //console.log(feature);
                            var lFeatures = [];
                            feature.forEach(function (curr, i) {
                                lFeatures.push(feature[i].properties);
                            });

                            var ikey = 0;
                            var projectkey = ['uuid', 'pro_name', 'pro_code', 'pro_type', 'lat', 'lon', 'ele', 'ward_no', 'settlement_name', 'cons_year', 'cons_agency', 'sup_agency', 'inv_agency'];
                            var sanitationkey = [];
                            var sourcekey = ['pro_uuid', 'sou_name', 'sou_type', 'sou_reg', 'reg_year', 'lat', 'lon', 'ele', 'int_type', 'sou_con', 'sou_use', 'nea_cmu', 'sou_dist', 'mea_dis', 'mea_date', 'min_yield', 'wat_qua', 'flow_reg', 'sou_pro', 'sou_eqk', 'sta_eqk', 'tre_req', 'rtip_time', 'sou_rem', 'add_date'];
                            var reservoirkey = [];
                            var pipekey = [];
                            var junctionkey = [];
                            var structurekey = [];
                            var tapkey = ['pro_uuid', 'tap_no', 'tap_owner', 'tap_contact', 'lat', 'lon', 'ele', 'tap_type', 'tap_meter', 'hh_serverd', 'bc_hh', 'jan_hh', 'dal_hh', 'mi_hh', 'hh_toilet', 'female_pop', 'male_pop', 'tap_cond', 'tap_flow_con', 'tap_fhours', 'tap_water_quality', 'tap_eqk', 'tap_complaint', 'no_leakage', 'tap_rem', 'data_year', 'add_date'];
                            var community_sanitationkey = [];
                            var healthc_carekey = [];
                            var householdkey = [];
                            var public_toiletkey = [];
                            var schoolkey = [];
                            var potential_sourcekey = [];                                                //Unserved Population
                            var unserved_communitykey = [];                                              //Unserved Population
                            /*
                             * 
                             * Solid Wastes
                             */
                            var benchmarkingkey = [];
                            var disposal_pointkey = [];
                            var route_pointkey = [];
                            var skipskey = [];
                            var street_sweepingkey = [];
                            /*
                             * Drainage
                             */
                            var drainage_pointkey = [];
                            var flood_benchmarkingkey = [];
                            var manholekey = [];
                            var outfallkey = [];
                            var rain_inletkey = [];
                            var sanitation_benchmarkingkey = [];
                            /*
                             * 
                             * Urban Sanitation
                             */
                            var urban_sanKey = ['visit_date','respondent_name','respondent_age','respondent_gender','ward','tole','respondent_contact_no','family_head_gender','total_family_members','family_type','household_type','other_household_type','house_purpose','average_expenditure','waterborne_diseases_status','waterborne_diseases','major_drinking_water_source','other_major_drinking_water_source','water_consumption_quantity','containment_lateral_distance','dry_ground_water_level_depth','wet_ground_water_level_depth','grey_water_connection','separate_system_for_wwm_status','expected_support_for_wwm','toilet_facilities','different_type_toilet_facilities','no_toilet_alternative','other_no_toilet_alternative','no_toilet_reason','other_no_toilet_reason','toilet_superstructure','num_of_people_using_toilet','toilet_connection','other_toilet_connection','containment_unit_connection','other_containment_unit_connection','septic_tank_compartments','sewer_chokes_overflow_status','annual_sewer_problems_num','containment_material','other_containment_material','pit_kind','faecal_sludge_reused_status','tank_or_pit_emptying_accessibility','lid_and_cover_condition','flooring_type_above_tank','other_flooring_type_above_tank','tank_length','tank_breadth','tank_depth','pit_diameter','pit_depth','containment_system_built','proper_septic_tank_investment','containment_emptying_accessibility','on_site_truck_parking','closest_parking_place_distance','elevation_difference','containment_unit_last_emptied','containment_not_emptied_reason','containment_emptied_reason','other_containment_emptied_reason','emptying_containment_period','emptying_service_provider','containment_emptied_process','mechanical_emptying_completeness_status','left_sludge_portion_in_feet','emptying_service_satisfaction','service_improving_ways','other_service_improving_ways','manual_emptying_reason','other_manual_emptying_reason','emptying_charge_per_trip','emptying_charge_calculation','other_emptying_charge_calculation','satisfied_with_emptying_cost','suggested_emptying_cost','willing_treatment_additional_charge','manual_emptying_disposal','other_manual_emptying_disposal','emptied_sludge_utilization','end_product_usage_perception','compost_expected_price','biogas_expected_price','treated_water_expected_price','solid_waste_mgmt','other_solid_waste_mgmt','hh_waste_segregation','hh_organic_solid_waste_mgmt','waste_collection_payment_status','waste_collection_charge_per_month','disabled_member_status','toilet_for_disabled','difficulties_using_toilet_for_disabled','hh_menstrual_waste_mgmt','waste_mgmt_responsibility','locality_sanitation_committee','committee_male_num','committee_female_num','committee_leading_gender','fsm_awareness_status','fsm_laws_awareness_status','fsm_laws_known','fsm_program_participation_status','septic_and_holding_tank_difference_known','runoff_water_connection','rainwater_collection_status','nominal_treatment_for_rainwater','rainwater_collection_container_size','unpaved_land_for_rainwater','place_for_groundwater_recharge','uploaded_date','uploaded_by','unique_code','fsm_program_participating_gender','other_grey_water_connection','other_expected_support_for_wwm','other_emptying_service_provider','other_hh_organic_solid_waste_mgmt','other_difficulties_using_toilet_for_disabled','other_hh_menstrual_waste_mgmt','other_runoff_water_connection','house_number','street_name','containment_dimension','other_containment_emptied_process'];
                            
                            var test_val = '';
                            if (event.features && event.features.length) {
                                if (maxfeatures === 1) {
                                    var resultObj = event.features[0].properties;
                                    //console.log(resultObj);
                                    if (event.features[0].id.split('.')[0] === 'sanitation') {
                                        var array_key = sanitationkey;
                                    } else if (event.features[0].id.split('.')[0] === 'water_source') {
                                        var array_key = sourcekey;
                                    } else if (event.features[0].id.split('.')[0] === 'project_details') {
                                        var array_key = projectkey;
                                    } else if (event.features[0].id.split('.')[0] === 'reservoir') {
                                        var array_key = reservoirkey;
                                    } else if (event.features[0].id.split('.')[0] === 'pipe') {
                                        var array_key = pipekey;
                                    } else if (event.features[0].id.split('.')[0] === 'junction') {
                                        var array_key = junctionkey;
                                    } else if (event.features[0].id.split('.')[0] === 'project_details_fun') {
                                        var array_key = [];
                                    } else if (event.features[0].id.split('.')[0] === 'project_details_sustain') {
                                        var array_key = [];
                                    } else if (event.features[0].id.split('.')[0] === 'tap') {
                                        var array_key = tapkey;
                                    } else if (event.features[0].id.split('.')[0] === 'structure') {
                                        var array_key = structurekey;
                                    } else if (event.features[0].id.split('.')[0] === 'tbl_observed_locations') {            //community Sanitation
                                        var array_key = community_sanitationkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'health_care_facility') {
                                        var array_key = healthc_carekey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'tbl_household') {
                                        var array_key = householdkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'public_toilet') {
                                        var array_key = public_toiletkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'tbl_school') {
                                        var array_key = schoolkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'unserved_community') {
                                        var array_key = unserved_communitykey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'potential_source') {
                                        var array_key = potential_sourcekey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'benchmarking') {
                                        var array_key = benchmarkingkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'disposal_point') {
                                        var array_key = disposal_pointkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'route_point') {
                                        var array_key = route_pointkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'skips') {
                                        var array_key = skipskey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'street_sweeping') {
                                        var array_key = street_sweepingkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'drainage_point') {
                                        var array_key = drainage_pointkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'flood_benchmarking') {
                                        var array_key = flood_benchmarkingkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'manhole') {
                                        var array_key = manholekey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'outfall') {
                                        var array_key = outfallkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'rain_inlet') {
                                        var array_key = rain_inletkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'sanitation_benchmarking') {
                                        var array_key = sanitation_benchmarkingkey;
                                        test_val = 'wash';
                                    } else if (event.features[0].id.split('.')[0] === 'tbl_urban_sanitation') {
                                        var array_key = urban_sanKey;
                                        test_val = 'wash';
                                    }

                                    var title = selectedLayer[0].get('name');
//console.log(title);
                                    var html = '<table class=\"table table-condensed\" style="margin-top:10px">';

                                    if (event.features[0].id.split('.')[0] === 'project_details') {
                                        html += '<tr style="background:#366BD6;color:#fff;" id="title_sus"><td colspan="2"><strong>Info:: ' + title + '</strong></td></tr>';
                                        html += '<tr id="1_district"></tr>';
                                        html += '<tr id="1_muni"></tr>';
                                        html += '<tr id="1_pro_name"></tr>';
                                        html += '<tr id="1_project_code"></tr>';
                                        get_project_details(1, resultObj['uuid'], test_val);

                                    }
                                    if (array_key.length > 0) {
                                        for (i = 0; i < array_key.length; i++) {
                                            if (array_key[i] === 'pro_uuid') {
                                                html += '<tr style="background:#366BD6;color:#fff;"><td colspan="2"><strong>Info:: ' + title + '</strong></td></tr>';
                                                html += '<tr id="1_district"></tr>';
                                                html += '<tr id="1_muni"></tr>';
                                                html += '<tr id="1_pro_name"></tr>';
                                                html += '<tr id="1_project_code"></tr>';
                                                get_project_details(1, resultObj[array_key[i]], test_val);
                                            } else if (array_key[i] === 'uuid') {
                                            } else if (array_key[i] === 'pro_name') {
                                            } else if (array_key[i] === 'pro_code') {
                                            } else {
                                                if (resultObj.hasOwnProperty(array_key[i])) {
                                                    html += "<tr><td>" + check_dictionary(array_key[i]) + "</td><td>" + if_null(array_key[i], resultObj[array_key[i]]) + "</td></tr>";
                                                    //alert(key + " -> " + resultObj[key]);
                                                }
                                            }
                                        }
                                    } else {
                                        for (var key in resultObj) {
                                            if (key == 'pro_uuid') {
                                                html += '<tr style="background:#366BD6;color:#fff;" id="title_sus"><td colspan="2"><strong>Info:: ' + title + '</strong></td></tr>';
                                                html += '<tr id="1_district"></tr>';
                                                html += '<tr id="1_muni"></tr>';
                                                html += '<tr id="1_pro_name"></tr>';
                                                html += '<tr id="1_project_code"></tr>';
                                                get_project_details('1', resultObj[key], test_val);
                                            } else if (key == 'uuid') {
                                                if (event.features[0].id.split('.')[0] === 'project_details') {
                                                    html += '<tr id="1_district"></tr>';
                                                    html += '<tr id="1_muni"></tr>';
                                                    get_project_details('1', resultObj[key], test_val);
                                                }
                                            } else if (key == 'photo1_path') {
                                            } else if (key == 'photo2_path') {
                                            } else if (key == 'photo3_path') {
                                            } else if (key == 'photo4_path') {
                                            } else if (key == 'photo5_path') {
                                            } else if (key == 'photo6_path') {
                                            } else if (key == 'photo1_desc') {
                                            } else if (key == 'photo2_desc') {
                                            } else if (key == 'rvt_cons') {
                                            } else if (key == 'pipe_cons') {
                                            } else if (key == 'junc_type') {
                                            } else if (key == 'str_nrp') {
                                            } else if (key == 'str_cons') {
                                            } else if (key == 'photo_hcf1') {
                                            } else if (key == 'photo_hcf2') {
                                            } else if (key == 'photo_hcf3') {
                                            } else if (key == 'photo_water_station_1') {
                                            } else if (key == 'photo_water_tank_1') {
                                            } else if (key == 'photo_female_toilet_dustbin_1') {
                                            } else if (key == 'photo_female_toilet_1') {
                                            } else if (key == 'photo_female_toilet_2') {
                                            } else if (key == 'photo_toilet_ramp_1') {
                                            } else if (key == 'photo_hand_washing_station_toilet_1') {
                                            } else if (key == 'photo_hand_washing_station_opd_1') {
                                            } else if (key == 'photo_toilet_mdu_2') {
                                            } else if (key == 'photo_toilet_mdu_1') {
                                            } else if (key == 'province_code') {
                                            } else if (key == 'district_code') {
                                            } else if (key == 'muni_code') {
                                            } else if (key == 'upload_date') {
                                            } else if (key == 'school_photo_1') {
                                            } else if (key == 'school_photo_2') {
                                            } else if (key == 'school_photo_3') {
                                            } else if (key == 'water_point_photo_1') {
                                            } else if (key == 'water_point_photo_2') {
                                            } else if (key == 'station_photo_1') {
                                            } else if (key == 'station_photo_2') {
                                            } else if (key == 'toilet_photo_1') {
                                            } else if (key == 'urinal_photo_1') {
                                            } else if (key == 'photo_1') {
                                            } else if (key == 'photo_2') {
                                            } else if (key == 'photo_3') {
                                            } else if (key == 'photo_4') {
                                            } else if (key == 'photo_5') {
                                            } else if (key == 'photo_6') {
                                            } else {
                                                if (resultObj.hasOwnProperty(key)) {
                                                    html += "<tr><td>" + check_dictionary(key) + "</td><td>" + if_null(key, resultObj[key]) + "</td></tr>";
                                                    //alert(key + " -> " + resultObj[key]);
                                                }
                                            }
                                        }
                                    }
                                    if (event.features[0].id.split('.')[0] === 'project_details') {
                                        html += '<tr style="background:#F6BB42;color:#fff;" id="title_sus"><td colspan="2"><strong>Project Sustainability</strong></td></tr>';
                                        for (var isus = 0; isus < sus_len; isus++) {
                                            html += '<tr style="background:#e7e7e7;" id="1_tr_fiscal_year_' + isus + '"><td><strong>Fiscal Year : </strong></td><td id="1_fiscal_year_' + isus + '"></td></tr>';
                                            html += '<tr id="1_tr_wua_name_' + isus + '"><td><strong>Community Name : </strong></td><td id="1_wua_name_' + isus + '"></td></tr>';
                                            html += '<tr id="1_tr_wua_date_' + isus + '"><td><strong>Community Formation Date: </strong></td><td id="1_wua_date_' + isus + '"></td></tr>';
                                            html += '<tr id="1_tr_wua_address_' + isus + '"><td><strong>Address : </strong></td><td id="1_wua_address_' + isus + '"></td></tr>';
                                            html += '<tr id="1_tr_wua_phone_' + isus + '"><td><strong>Phone No : </strong></td><td id="1_wua_phone_' + isus + '"></td></tr>';
                                            html += '<tr id="1_tr_wua_email_' + isus + '"><td><strong>Email : </strong></td><td id="1_wua_email_' + isus + '"></td></tr>';
                                            html += '<tr id="1_tr_add_by_' + isus + '"><td><strong>Added By : </strong></td><td id="1_add_by_' + isus + '"></td></tr>';
                                            html += '<tr id="1_tr_add_date_' + isus + '"><td><strong>Added Date : </strong></td><td id="1_add_date_' + isus + '"></td></tr>';
                                            html += '<tr id="1_tr_view_all_' + isus + '"><td colspan="2" id="1_view_all_' + isus + '"></td></tr>';
                                        }
                                        get_sustain_data('1', resultObj['uuid']);
                                    }
                                    // }
                                    html += "</table>";
//                    //var layerName=event.features[0].id.split('.')[0];
//                    var title = event.object.layers[ikey].name;
//                    //getLinkCodeData(linkcode,layer,event);
//var title = selectedLayer.get('name');

                                    $("#identify-view-draggable").remove();
                                    //var il = '';
                                    var elem = '';

                                    elem = document.getElementById('popup-content');
                                    elem.innerHTML = '';
                                    
                                    overlay.setPosition(e.coordinate);


                                    elem.innerHTML += html;

                                    var layer_photos = get_photos(event.features[0].id.split('.')[0], resultObj, elem);

                                } else if (maxfeatures > 1) {
                                    //debugger;
                                    var main_html = '';
                                    var pipe_main_html = '';
                                    var sus_main_html = '';
                                    var r = 0;



                                    for (var im = 0; im < event.features.length; im++) {
                                        r = r + 1;
                                        //var resultObj = event.features[im].attributes;
                                        var resultObj = event.features[im].properties;
                                        if (selectedLayer.length > 1) {

                                            if (event.features[im].id.split('.')[0] === 'project_details' && selectedLayer[0].getVisible()) {
                                                ikey = 0;
                                                var array_key = projectkey;
                                            } else if (event.features[im].id.split('.')[0] === 'water_source' && selectedLayer[1].getVisible()) {
                                                ikey = 1;
                                                var array_key = sourcekey;
                                            } else if (event.features[im].id.split('.')[0] === 'reservoir' && selectedLayer[2].getVisible()) {
                                                ikey = 2;
                                                var array_key = reservoirkey;
                                            } else if (event.features[im].id.split('.')[0] === 'pipe' && selectedLayer[3].getVisible()) {
                                                ikey = 3;
                                                var array_key = pipekey;
                                            } else if (event.features[im].id.split('.')[0] === 'tap' && selectedLayer[4].getVisible()) {
                                                ikey = 4;
                                                //ikey = 7;
                                                var array_key = tapkey;
                                            } else if (event.features[im].id.split('.')[0] === 'structure' && selectedLayer[5].getVisible()) {
                                                ikey = 5;
                                                //ikey = 8;
                                                var array_key = structurekey;
                                            } else if (event.features[im].id.split('.')[0] === 'junction' && selectedLayer[6].getVisible()) {
                                                ikey = 6;
                                                //ikey = 4;
                                                var array_key = junctionkey;
                                            } else if (event.features[im].id.split('.')[0] === 'project_details_fun' && selectedLayer[7].getVisible()) {
                                                //ikey = 5;
                                                ikey = 7;
                                                var array_key = [];
                                            } else if (event.features[im].id.split('.')[0] === 'project_details_sustain' && selectedLayer[8].getVisible()) {
                                                ikey = 8;
                                                //ikey = 6;
                                                var array_key = [];
                                            } else if (event.features[im].id.split('.')[0] === 'sanitation' && selectedLayer[9].getVisible()) {
                                                ikey = 9;
                                                var array_key = sanitationkey;
                                            } else if (event.features[im].id.split('.')[0] === 'tbl_observed_locations' && selectedLayer[0].getVisible()) {
                                                ikey = 0;
                                                var array_key = community_sanitationkey;
                                            } else if (event.features[im].id.split('.')[0] === 'health_care_facility' && selectedLayer[1].getVisible()) {
                                                ikey = 1;
                                                var array_key = healthc_carekey;
                                            } else if (event.features[im].id.split('.')[0] === 'tbl_household' && selectedLayer[2].getVisible()) {
                                                ikey = 2;
                                                var array_key = householdkey;
                                            } else if (event.features[im].id.split('.')[0] === 'public_toilet' && selectedLayer[3].getVisible()) {
                                                ikey = 3;
                                                var array_key = public_toiletkey;
                                            } else if (event.features[im].id.split('.')[0] === 'tbl_school' && selectedLayer[4].getVisible()) {
                                                ikey = 4;
                                                var array_key = schoolkey;
                                            } else if (event.features[im].id.split('.')[0] === 'unserved_community' && selectedLayer[5].getVisible()) {
                                                ikey = 5;
                                                var array_key = unserved_communitykey;
                                            } else if (event.features[im].id.split('.')[0] === 'potential_source' && selectedLayer[6].getVisible()) {
                                                ikey = 6;
                                                var array_key = potential_sourcekey;
                                            } else if (event.features[im].id.split('.')[0] === 'benchmarking' && selectedLayer[7].getVisible()) {
                                                ikey = 7;
                                                var array_key = benchmarkingkey;
                                            } else if (event.features[im].id.split('.')[0] === 'disposal_point' && selectedLayer[8].getVisible()) {
                                                ikey = 8;
                                                var array_key = disposal_pointkey;
                                            } else if (event.features[im].id.split('.')[0] === 'route_point' && selectedLayer[9].getVisible()) {
                                                ikey = 9;
                                                var array_key = route_pointkey;
                                            } else if (event.features[im].id.split('.')[0] === 'skips' && selectedLayer[10].getVisible()) {
                                                ikey = 10;
                                                var array_key = skipskey;
                                            } else if (event.features[im].id.split('.')[0] === 'street_sweeping' && selectedLayer[11].getVisible()) {
                                                ikey = 11;
                                                var array_key = street_sweepingkey;
                                            } else if (event.features[im].id.split('.')[0] === 'drainage_point' && selectedLayer[12].getVisible()) {
                                                ikey = 12;
                                                var array_key = drainage_pointkey;
                                            } else if (event.features[im].id.split('.')[0] === 'flood_benchmarking' && selectedLayer[13].getVisible()) {
                                                ikey = 13;
                                                var array_key = flood_benchmarkingkey;
                                            } else if (event.features[im].id.split('.')[0] === 'manhole' && selectedLayer[14].getVisible()) {
                                                ikey = 14;
                                                var array_key = manholekey;
                                            } else if (event.features[im].id.split('.')[0] === 'outfall' && selectedLayer[15].getVisible()) {
                                                ikey = 15;
                                                var array_key = outfallkey;
                                            } else if (event.features[im].id.split('.')[0] === 'rain_inlet' && selectedLayer[16].getVisible()) {
                                                ikey = 16;
                                                var array_key = rain_inletkey;
                                            } else if (event.features[im].id.split('.')[0] === 'sanitation_benchmarking' && selectedLayer[17].getVisible()) {
                                                ikey = 17;
                                                var array_key = sanitation_benchmarkingkey;                                            
                                            } else if (event.features[im].id.split('.')[0] === 'tbl_urban_sanitation' && selectedLayer[5].getVisible()) {
                                                ikey = 5;
                                                var array_key = urban_sanKey;
                                            }
                                        } else {
                                            ikey = 0;
                                        }
                                        if (event.features[im].id.split('.')[0] === 'pipe') {
                                            var pipe_html = "<table class=\"table table-condensed\">";

                                            if (array_key.length > 0) {
                                                for (i = 0; i < array_key.length; i++) {
                                                    if (array_key[i] === 'pro_uuid') {
                                                        pipe_html += '<tr style="background:#366BD6;color:#fff;" id="title_sus"><td colspan="2"><strong>Info:: ' + title + '</strong></td></tr>';
                                                        pipe_html += '<tr id="' + r + '_district"></tr>';
                                                        pipe_html += '<tr id="' + r + '_muni"></tr>';
                                                        pipe_html += '<tr id="' + r + '_pro_name"></tr>';
                                                        pipe_html += '<tr id="' + r + '_project_code"></tr>';
                                                        get_project_details(r, resultObj[array_key[i]], test_val);
                                                    } else {
                                                        if (resultObj.hasOwnProperty(array_key[i])) {
                                                            pipe_html += "<tr><td>" + check_dictionary(array_key[i]) + "</td><td>" + if_null(array_key[i], resultObj[array_key[i]]) + "</td></tr>";
                                                            //alert(key + " -> " + resultObj[key]);
                                                        }
                                                    }
                                                }
                                            } else {
                                                for (var key in resultObj) {
                                                    if (key == 'pro_uuid') {
                                                        pipe_html += '<tr style="background:#366BD6;color:#fff;" id="title_sus"><td colspan="2"><strong>Info:: ' + title + '</strong></td></tr>';
                                                        pipe_html += '<tr id="' + r + '_district"></tr>';
                                                        pipe_html += '<tr id="' + r + '_muni"></tr>';
                                                        pipe_html += '<tr id="' + r + '_pro_name"></tr>';
                                                        pipe_html += '<tr id="' + r + '_project_code"></tr>';
                                                        get_project_details(r, resultObj[key], test_val);
                                                    } else if (key == 'uuid') {
                                                        if (event.features[im].id.split('.')[0] === 'project_details') {
                                                            pipe_html += '<tr id="' + r + '_district"></tr>';
                                                            pipe_html += '<tr id="' + r + '_muni"></tr>';
                                                            get_project_details(r, resultObj[key], test_val);
                                                        }
                                                    } else if (key == 'photo1_path') {
                                                    } else if (key == 'photo2_path') {
                                                    } else if (key == 'photo3_path') {
                                                    } else if (key == 'photo4_path') {
                                                    } else if (key == 'photo5_path') {
                                                    } else if (key == 'photo6_path') {
                                                    } else if (key == 'photo1_desc') {
                                                    } else if (key == 'photo2_desc') {
                                                    } else if (key == 'rvt_cons') {
                                                    } else if (key == 'pipe_cons') {
                                                    } else if (key == 'photo_hcf1') {
                                                    } else if (key == 'photo_hcf2') {
                                                    } else if (key == 'photo_hcf3') {
                                                    } else if (key == 'photo_water_station_1') {
                                                    } else if (key == 'photo_water_tank_1') {
                                                    } else if (key == 'photo_female_toilet_dustbin_1') {
                                                    } else if (key == 'photo_female_toilet_1') {
                                                    } else if (key == 'photo_female_toilet_2') {
                                                    } else if (key == 'photo_toilet_ramp_1') {
                                                    } else if (key == 'photo_hand_washing_station_toilet_1') {
                                                    } else if (key == 'photo_hand_washing_station_opd_1') {
                                                    } else if (key == 'photo_toilet_mdu_2') {
                                                    } else if (key == 'photo_toilet_mdu_1') {
                                                    } else if (key == 'province_code') {
                                                    } else if (key == 'district_code') {
                                                    } else if (key == 'muni_code') {
                                                    } else if (key == 'upload_date') {
                                                    } else if (key == 'school_photo_1') {
                                                    } else if (key == 'school_photo_2') {
                                                    } else if (key == 'school_photo_3') {
                                                    } else if (key == 'water_point_photo_1') {
                                                    } else if (key == 'water_point_photo_2') {
                                                    } else if (key == 'station_photo_1') {
                                                    } else if (key == 'station_photo_2') {
                                                    } else if (key == 'toilet_photo_1') {
                                                    } else if (key == 'urinal_photo_1') {
                                                    } else if (key == 'photo_1') {
                                                    } else if (key == 'photo_2') {
                                                    } else if (key == 'photo_3') {
                                                    } else if (key == 'photo_4') {
                                                    } else if (key == 'photo_5') {
                                                    } else if (key == 'photo_6') {
                                                    } else {
                                                        if (resultObj.hasOwnProperty(key)) {
                                                            pipe_html += "<tr><td>" + check_dictionary(key) + "</td><td>" + if_null(key, resultObj[key]) + "</td></tr>";
                                                            //alert(key + " -> " + resultObj[key]);
                                                        }
                                                    }
                                                }
                                            }
                                            //}
                                            pipe_html += "</table>";
                                            //var layerName=event.features[0].id.split('.')[0];

                                            //var title = event.object.layers[ikey].name;
                                            var title = selectedLayer[ikey].get('name');
                                            //getLinkCodeData(linkcode,layer,event);
                                            var photos = get_all_photos(event.features[im].id.split('.')[0], resultObj, title);
                                            pipe_main_html += '<div style="background:#366BD6;padding:1px;color:white;margin-bottom:5px" id="' + event.features[im].id.split('.')[1] + '" class="identi"><h4>Info: ' + title + '</h4></div><div style="padding:0px 0px !important;" id="' + event.features[im].id.split('.')[1] + '_s">' + pipe_html + '<br>' + photos + '</div>';
                                        } else {
                                            var html = "<table class=\"table table-condensed\">";
                                            if (event.features[im].id.split('.')[0] === 'project_details') {
                                                html += '<tr id="' + r + '_district"></tr>';
                                                html += '<tr id="' + r + '_muni"></tr>';
                                                html += '<tr id="' + r + '_pro_name"></tr>';
                                                html += '<tr id="' + r + '_project_code"></tr>';
                                                get_project_details(r, resultObj['uuid'], test_val);
                                            }
                                            if (array_key.length > 0) {
                                                for (i = 0; i < array_key.length; i++) {
                                                    if (array_key[i] === 'pro_uuid') {
                                                        html += '<tr id="' + r + '_district"></tr>';
                                                        html += '<tr id="' + r + '_muni"></tr>';
                                                        html += '<tr id="' + r + '_pro_name"></tr>';
                                                        html += '<tr id="' + r + '_project_code"></tr>';
                                                        get_project_details(r, resultObj[array_key[i]], test_val);
                                                    } else if (array_key[i] === 'uuid') {
                                                    } else if (array_key[i] === 'pro_name') {
                                                    } else if (array_key[i] === 'pro_code') {
                                                    } else {
                                                        if (resultObj.hasOwnProperty(array_key[i])) {
                                                            html += "<tr><td>" + check_dictionary(array_key[i]) + "</td><td>" + if_null(array_key[i], resultObj[array_key[i]]) + "</td></tr>";
                                                            //alert(key + " -> " + resultObj[key]);
                                                        }
                                                    }
                                                }
                                            } else {
                                                for (var key in resultObj) {
                                                    if (key == 'pro_uuid') {
                                                        html += '<tr id="' + r + '_district"></tr>';
                                                        html += '<tr id="' + r + '_muni"></tr>';
                                                        html += '<tr id="' + r + '_pro_name"></tr>';
                                                        html += '<tr id="' + r + '_project_code"></tr>';
                                                        get_project_details(r, resultObj[key], test_val);
                                                    } else if (key == 'uuid') {
                                                        if (event.features[im].id.split('.')[0] === 'project_details') {
                                                            html += '<tr id="' + r + '_district"></tr>';
                                                            html += '<tr id="' + r + '_muni"></tr>';
                                                            get_project_details(r, resultObj[key], test_val);
                                                        }
                                                    } else if (key == 'photo1_path') {
                                                    } else if (key == 'photo2_path') {
                                                    } else if (key == 'photo3_path') {
                                                    } else if (key == 'photo4_path') {
                                                    } else if (key == 'photo5_path') {
                                                    } else if (key == 'photo6_path') {
                                                    } else if (key == 'photo1_desc') {
                                                    } else if (key == 'photo2_desc') {
                                                    } else if (key == 'rvt_cons') {
                                                    } else if (key == 'junc_type') {
                                                    } else if (key == 'str_nrp') {
                                                    } else if (key == 'str_cons') {
                                                    } else if (key == 'photo_hcf1') {
                                                    } else if (key == 'photo_hcf2') {
                                                    } else if (key == 'photo_hcf3') {
                                                    } else if (key == 'photo_water_station_1') {
                                                    } else if (key == 'photo_water_tank_1') {
                                                    } else if (key == 'photo_female_toilet_dustbin_1') {
                                                    } else if (key == 'photo_female_toilet_1') {
                                                    } else if (key == 'photo_female_toilet_2') {
                                                    } else if (key == 'photo_toilet_ramp_1') {
                                                    } else if (key == 'photo_hand_washing_station_toilet_1') {
                                                    } else if (key == 'photo_hand_washing_station_opd_1') {
                                                    } else if (key == 'photo_toilet_mdu_2') {
                                                    } else if (key == 'photo_toilet_mdu_1') {
                                                    } else if (key == 'province_code') {
                                                    } else if (key == 'district_code') {
                                                    } else if (key == 'muni_code') {
                                                    } else if (key == 'upload_date') {
                                                    } else if (key == 'school_photo_1') {
                                                    } else if (key == 'school_photo_2') {
                                                    } else if (key == 'school_photo_3') {
                                                    } else if (key == 'water_point_photo_1') {
                                                    } else if (key == 'water_point_photo_2') {
                                                    } else if (key == 'station_photo_1') {
                                                    } else if (key == 'station_photo_2') {
                                                    } else if (key == 'toilet_photo_1') {
                                                    } else if (key == 'urinal_photo_1') {
                                                    } else if (key == 'photo_1') {
                                                    } else if (key == 'photo_2') {
                                                    } else if (key == 'photo_3') {
                                                    } else if (key == 'photo_4') {
                                                    } else if (key == 'photo_5') {
                                                    } else if (key == 'photo_6') {
                                                    } else {
                                                        if (resultObj.hasOwnProperty(key)) {
                                                            html += "<tr><td>" + check_dictionary(key) + "</td><td>" + if_null(key, resultObj[key]) + "</td></tr>";
                                                        }
                                                        //alert(key + " -> " + resultObj[key]);
                                                    }
                                                }
                                            }
                                            //}
                                            html += "</table>";
                                            //var layerName=event.features[0].id.split('.')[0];

                                            //var title = event.object.layers[ikey].name;
                                            var title = selectedLayer[ikey].get('name');
                                            //getLinkCodeData(linkcode,layer,event);
                                            
                                            if(event.features[im].id.split('.')[0] === 'tbl_urban_sanitation'){
                                                var photos = get_urban_san_photos(event.features[im].id.split('.')[0], resultObj, title);
                                            }else{
                                                var photos = get_all_photos(event.features[im].id.split('.')[0], resultObj, title);
                                            }
                                            var sus_html = '';
                                            if (event.features[im].id.split('.')[0] === 'project_details') {
                                                sus_html += '<table class=\"table table-condensed\" id="' + r + '_table_sus">';
                                                sus_html += '<tr style="background:#F6BB42;color:#fff;" id="title_sus"><td colspan="2"><strong>Project Sustainability</strong></td></tr>';
                                                for (var isus = 0; isus < sus_len; isus++) {
                                                    sus_html += '<tr style="background:#e7e7e7;" id="' + r + '_tr_fiscal_year_' + isus + '"><td><strong>Fiscal Year : </strong></td><td id="' + r + '_fiscal_year_' + isus + '"></td></tr>';
                                                    sus_html += '<tr id="' + r + '_tr_wua_name_' + isus + '"><td><strong>Community Name : </strong></td><td id="' + r + '_wua_name_' + isus + '"></td></tr>';
                                                    sus_html += '<tr id="' + r + '_tr_wua_date_' + isus + '"><td><strong>Community Formation Date: </strong></td><td id="' + r + '_wua_date_' + isus + '"></td></tr>';
                                                    sus_html += '<tr id="' + r + '_tr_wua_address_' + isus + '"><td><strong>Address : </strong></td><td id="' + r + '_wua_address_' + isus + '"></td></tr>';
                                                    sus_html += '<tr id="' + r + '_tr_wua_phone_' + isus + '"><td><strong>Phone No : </strong></td><td id="' + r + '_wua_phone_' + isus + '"></td></tr>';
                                                    sus_html += '<tr id="' + r + '_tr_wua_email_' + isus + '"><td><strong>Email : </strong></td><td id="' + r + '_wua_email_' + isus + '"></td></tr>';
                                                    sus_html += '<tr id="' + r + '_tr_add_by_' + isus + '"><td><strong>Added By : </strong></td><td id="' + r + '_add_by_' + isus + '"></td></tr>';
                                                    sus_html += '<tr id="' + r + '_tr_add_date_' + isus + '"><td><strong>Added Date : </strong></td><td id="' + r + '_add_date_' + isus + '"></td></tr>';
                                                    sus_html += '<tr id="' + r + '_tr_view_all_' + isus + '"><td colspan="2" id="' + r + '_view_all_' + isus + '"></td></tr>';
                                                }
                                                get_sustain_data(r, resultObj['uuid']);
                                                sus_html += '</table>';
                                            }
                                            main_html += '<div style="background:#366BD6;padding:1px;color:white;margin-bottom:5px" id="' + event.features[im].id.split('.')[1] + '" class="identi"><h4>Info: ' + title + '</h4></div><div style="padding:0px 0px !important;" id="' + event.features[im].id.split('.')[1] + '_s">' + html + '<br>' + photos + '<br>' + sus_html + '</div>';
                                        }
                                    }
                                    $("#identify-view-draggable").remove();

                                    overlay.setPosition(e.coordinate);

                                    //elem.innerHTML +=html;
                                    elem1.innerHTML += main_html;
                                    elem1.innerHTML += pipe_main_html;

                                    $(".identi").on('click', function (event) {
                                        var clickedId = $(this).attr('id');
                                        if ($('#' + clickedId + '_s').css("display") != "none") {
                                            $('#' + clickedId + '_s').css("display", "none");
                                        } else {
                                            $('#' + clickedId + '_s').css("display", "inline");
                                        }


                                    })
                                    $(document).ready(function () {
                                        $('.all-identify').mouseenter(function () {
                                            isOnDiv = true;
                                        });
                                        $('.all-identify').mouseleave(function () {
                                            isOnDiv = false;
                                        });
                                    });

                                }
                            }
                        }
                    });
                }
            });
        });
    };
    this.selectIdentifyLayer = function ()
    {
        maxfeatures = 1;
        var layerName = $("#identify_select").val();
        this.tool.layers = new Array();
        selectedLayer = new Array();
//        selectedLayer = 'project';
//        console.log(this.tool);
        map.getLayers().forEach(function (layer) {
            if (layer.get('name') === layerName) {
                this.identifyLayer = layer;
                //selectedLayer = layer;
                selectedLayer.push(layer);
            } else {

            }
        });
    };
    this.selectAllIdentifyLayer = function ()
    {
        filt = '';
        var this_project = $('#this_project_only').is(":checked");
        identifyToolHelper.hideIdentifyTool()
        maxfeatures = 10;
        var layerNames = ["Water Supply Projects", "Source", "Reservoir", "Pipe", "Tap", "Structure", "Junction", "Functionality Framework", "Sustainability Framework", "Sanitation","LeftoutTaps"];
        this.tool.layers = new Array();
        selectedLayer = new Array();
        layersArray = map.getLayers();
        var j = 0;
//        for (i = 0; i < layersArray.length; i++)
//        {
        map.getLayers().forEach(function (layer) {
            if (layerNames.inArray(layer.get('name')))
            {
                this.identifyLayer = layer;
                selectedLayer.push(layer);

            } else
            {
                //$("#id_"+layersArray[i].id).prop("class","identifybuttonicon");
            }
        });


    };
    this.selectWashDataLayers = function ()
    {
        filt = '';
        var this_project = $('#this_project_only').is(":checked");
        identifyToolHelper.hideIdentifyTool()
        maxfeatures = 12;
        var layerNames = ["Community Sanitation", "Health Care Facility", "Household", "Public Toilet", "Schools", "Unserved Community", "Potential Source", "Benchmarking", "Disposal Point", "Route Point", "Skips", "Street Sweeping", "Drainage Point", "Flood Benchmarking", "Manhole", "Outfall", "Rain Inlet", "Sanitation Benchmarking","CWIS Urban Sanitation"];
        this.tool.layers = new Array();
        selectedLayer = new Array();
        layersArray = map.layers;
        var j = 0;
        map.getLayers().forEach(function (layer) {
            if (layerNames.inArray(layer.get('name')))
            {

                this.identifyLayer = layer;
                selectedLayer.push(layer);
                if (this_project === true) {
                    var lyrCQL = layer.params.CQL_FILTER;
                    if (lyrCQL !== null) {
                        if (j > 0) {
                            filt += ";";
                        }
                        filt += lyrCQL;
                        j++;
                    }
                }

            } else
            {

            }
        });
    };

    Array.prototype.inArray = function (value)
    {
        var i;
        for (i = 0; i < this.length; i++)
        {
            if (this[i] == value)
            {
                return true;
            }
        }
        return false;
    };
    this.showIdentifyTool = function ()
    {
        $("#identify-draggable").show();
        $("#identify-tool").attr("class", "identify-active");
    };
    this.hideIdentifyTool = function ()
    {
        $("#identify-draggable").hide();
        $("#identify-tool").attr("class", "identify");
        map.removeInteraction(this.tool);
        //this.tool.deactivate();
    }

    this.activateIdentifyLayer = function ()
    {
        var layerName = $("#identify_select").val();
        if (layerName == "")
        {
            this.identifyLayer = "";
            alert("Please Select Identify Layer");
            return;
        }

        Tools.deactivateAllTools();
        this.tool.activate();
        $('#mapDiv').css('cursor', this.cursor);
    };
    this.showAllIdentifyLayers = function ()
    {
        var html = '<option value="">Select Identify Layer</option>';
        var layer_group_labels = ["Basemap", "Road Network", "Water Supply Projects"];
        var layer_groups = [basemap, lrnGroup, wspGroup];
        for (var i = 0; i < layer_groups.length; i++)
        {
            var current_group = layer_groups[i];
            var layers = current_group.getLayers();
            html += "<optgroup label=\"" + layer_group_labels[i] + "\">";
            for (var j = 0; j < layers.length; j++)
            {
                var layer = layers[j];
                //console.log(layer);
//                if (layer.index('Google') == -1)
//                {
                html += "<option value=\"" + layer.get('name') + "\">" + layer.get('name') + "</option>";
                //}
            }
            html += "</optgroup>";
        }
        $("#identify_select").html(html);
    }

}



function zoomToExtent()
{
    map.getView().fit([8912260.091133313, 3042341.524138276, 9818849.801192472, 3561365.8324687113]);
}

var panToolHelper = new ToolHelper("panToolHelper", new ol.interaction.DragPan, "Pan", true, "#pan-tool", "pan-active", "pan", "", "", 'move');
var zoomInToolHelper = new ToolHelper("zoomInToolHelper", new ol.interaction.DragZoom({
    condition: function (mapBrowserEvent) {
        var originalEvent = mapBrowserEvent.originalEvent;
        return (
                originalEvent.button == 0);
    },
    out: false
}), "Zoom in", false, "#zoom-in-tool", "zoom-in-active", "zoom-in", "", "", 'crosshair');
var zoomOutToolHelper = new ToolHelper("zoomOutToolHelper", new ol.interaction.DragZoom({
    condition: function (mapBrowserEvent) {
        var originalEvent = mapBrowserEvent.originalEvent;
        return (
                originalEvent.button == 0);
    },
    out: true
}), "Zoom Out", false, "#zoom-out-tool", "zoom-out-active", "zoom-out", "", "", 'crosshair');

//<editor-fold desc="commented">
var identifyToolHelper = new ToolHelper("identifyToolHelper", new ol.interaction.Select({
//    layers:[selectedLayer],
//    condition: ol.events.condition.click

    layers: function (layer) {
        return layer.get('selectable') == true;
    }


}), "identify tool", false, "#identify", "identify-active", "identify", "", "", 'help');


var division_tool = {
    layer_style: null,
    filterParams: {
        filter: null,
        cql_filter: null,
        featureId: null
    },
    show: function ()
    {
        $("#division-draggable").show();
        $("#division-tool").attr("class", 'goto-division-active');
    },
    hide: function ()
    {
        $("#division-draggable").hide();
        $("#division-tool").attr("class", 'goto-division');
        district_mask.setVisible(false);
        muni_mask.setVisible(false);
        district.setVisible(false);
        province_mask.setVisible(false);

    },
    hide_projects: function () {
        $("#division-draggable").hide();
        $("#division-tool").attr("class", 'goto-division');

    },
    goto_province: function (province, type)
    {
        if (province)
        {
            if (type === 'clip')
            {
                zoomToExtent();
                muni_mask.setVisible(false);
                district_mask.setVisible(false);
                var params = province_mask.getSource().getParams();
                params.cql_filter = "province<>'" + province + "'";

                province_mask.getSource().updateParams(params);

                province_mask.setVisible(true);
            } else {
                zoomToExtent();
                muni_mask.setVisible(false);
                district_mask.setVisible(false);
                var params = province_mask.getSource().getParams();
                params.cql_filter = "province<>'" + province + "'";
                province_mask.getSource().updateParams(params);
                province_mask.setVisible(false);
            }
            var url = "/Map/GetProvinceExtent/";
            $.ajax({
                type: "POST",
                url: url,
                data: { 'province': province },
                dataType: 'json',
                success: function (search_result) {                    
                    if (search_result.length > 0) {
                        search_result = search_result[0];
                      
                        var x1 = parseFloat(search_result.xmin);
                        var y1 = parseFloat(search_result.ymin);
                        var x2 = parseFloat(search_result.xmax);
                        var y2 = parseFloat(search_result.ymax);
                       
                        var minProj = ol.proj.transform([x1, y1], 'EPSG:4326', 'EPSG:3857');
                        
                        var x1 = minProj[0];
                        var y1 = minProj[1];                       

                        var maxProj = ol.proj.transform([x2, y2], 'EPSG:4326', 'EPSG:3857');
                        var x2 = maxProj[0];
                        var y2 = maxProj[1];
                        
                        map.getView().fit([x1, y1, x2, y2]);                        
                    }
                }
            });

        } else
        {
            alert("Please Select District");
            province_mask.setVisible(false);
        }
    },
    goto_district: function (dcode, type)
    {
        if (dcode)
        {
            if (type === 'clip')
            {
                zoomToExtent();
                muni_mask.setVisible(false);
                province_mask.setVisible(false);
                var params = district_mask.getSource().getParams();
                params.cql_filter = "new_dcode<>'" + dcode + "'";
                district_mask.getSource().updateParams(params);
                district_mask.setVisible(true);
                district.setVisible(true);
            } else {
                zoomToExtent();
                muni_mask.setVisible(false);
                district_mask.setVisible(false);
                var params = district_mask.getSource().getParams();
                params.cql_filter = "new_dcode<>'" + dcode + "'";
                district_mask.getSource().updateParams(params);
                district_mask.setVisible(false);
                district.setVisible(false);
            }
            var url = "/Map/GetDistrictExtent/";
            $.ajax({
                type: "POST",
                url: url,
                data: { 'dCode': dcode },
                dataType: 'json',
                success: function (search_result) {                    
                    if (search_result.length > 0) {
                        search_result = search_result[0];

                        var x1 = parseFloat(search_result.xmin);
                        var y1 = parseFloat(search_result.ymin);
                        var x2 = parseFloat(search_result.xmax);
                        var y2 = parseFloat(search_result.ymax);

                        var minProj = ol.proj.transform([x1, y1], 'EPSG:4326', 'EPSG:3857');
                        var x1 = minProj[0];
                        var y1 = minProj[1];

                        var maxProj = ol.proj.transform([x2, y2], 'EPSG:4326', 'EPSG:3857');
                        var x2 = maxProj[0];
                        var y2 = maxProj[1];
                        map.getView().fit([x1, y1, x2, y2]);
                    }
                }
            });
        } else
        {
            alert("Please Select District");
            district_mask.setVisible(false);
        }
    },
    goto_municipality: function (muni, type)
    {
        if (muni)
        {
            if (type === 'clip')
            {
                district_mask.setVisible(false);
                province_mask.setVisible(false);
                var params = muni_mask.getSource().getParams();
                params.CQL_FILTER = "loc_code<>'" + muni + "'";
                muni_mask.getSource().updateParams(params);
                muni_mask.setVisible(true);
            } else {
                zoomToExtent();
                district_mask.setVisible(false);
                province_mask.setVisible(false);
                var params = muni_mask.getSource().getParams();
                params.CQL_FILTER = "loc_code<>'" + muni + "'";
                muni_mask.getSource().updateParams(params);
                muni_mask.setVisible(false);
            }
            var url = "/Map/GetMuniExtent";
            $.ajax({
                type: "POST",
                url: url,
                data: { 'munCode': muni },
                dataType: 'json',
                success: function (search_result) {
                    if (search_result.length > 0) {
                        search_result = search_result[0];
                        var x1 = parseFloat(search_result.xmin);
                        var y1 = parseFloat(search_result.ymin);
                        var x2 = parseFloat(search_result.xmax);
                        var y2 = parseFloat(search_result.ymax);

                        var minProj = ol.proj.transform([x1, y1], 'EPSG:4326', 'EPSG:3857');
                        var x1 = minProj[0];
                        var y1 = minProj[1];

                        var maxProj = ol.proj.transform([x2, y2], 'EPSG:4326', 'EPSG:3857');
                        var x2 = maxProj[0];
                        var y2 = maxProj[1];
                        map.getView().fit([x1, y1, x2, y2]);
                    }
                }
            });
        } else
        {
            alert("Please Select Municipality");
            muni_mask.setVisible(false);
            //muni_mask.setVisible(false);
        }
    }

}
function get_all_photos(layer, resultObj, title)
{
    var photo_url = "http://nwash.softwel.com.np/" + "uploadedphotos/Inventory/";
    var arr = {};
    arr.reservoir = ['photo1_path', 'photo2_path'];
    arr.tap = ['photo1_path', 'photo2_path'];
    arr.water_source = ['photo1_path', 'photo2_path', 'photo3_path'];
    arr.project_details = ['photo1_path', 'photo2_path', 'photo3_path'];
    arr.pipe = ['photo1_path', 'photo2_path'];
    arr.structure = ['photo1_path', 'photo2_path'];
    arr.sanitation = ['photo1_path', 'photo2_path'];    
    var has_photos = '';
//    var photos_html = "<table>";
//    photos_html += '<tr><th colspan="2">Photos:</th></tr>';
    var photos_html = '<table class=\"table table-condensed\" style="margin-top:10px">';
    photos_html += '<tr style="background:#37D166 ;color:#fff;" id="title_sus"><td colspan="2"><strong>Photos</strong></td></tr>';
    for (var key in resultObj) {
        if (resultObj[key] != null) {
            if (inArray(key, arr[layer])) {
                var photo = resultObj[key];
                if (photo != null && photo != "") {
                    has_photos = 'yes';
                    photos_html += '<tr><td><button onclick="load_pop_image(\'' + photo + '\')"><img src="' + photo_url + photo + '" width="150px" /></button>' + "</td></tr>";
                }
            }
        }
    }
    photos_html += '</table>';
    if (has_photos === 'yes') {
        return photos_html;
    } else {
        return '';
    }
    setTimeout(function () {
        $(".bridge-photo").colorbox({
            rel: 'bridge-photo',
            height: 600
        });
    }, 1000);
}

function get_urban_san_photos(layer, resultObj, title)
{
    var photo_url = "http://nwash2.softwel.com.np/images/urban_sanitation/";
    var arr = {};
    arr.tbl_urban_sanitation = ['photo_1', 'photo_2','photo_3','photo_4'];      
    var has_photos = '';
//    var photos_html = "<table>";
//    photos_html += '<tr><th colspan="2">Photos:</th></tr>';
    var photos_html = '<table class=\"table table-condensed\" style="margin-top:10px">';
    photos_html += '<tr style="background:#37D166 ;color:#fff;" id="title_sus"><td colspan="2"><strong>Photos</strong></td></tr>';
    for (var key in resultObj) {
        if (resultObj[key] != null) {
            if (inArray(key, arr[layer])) {
                var photo = resultObj[key];
                if (photo != null && photo != "") {
                    has_photos = 'yes';
                    photos_html += '<tr><td><button onclick="load_pop_urban_san_image(\'' + photo + '\')"><img src="' + photo_url + photo + '" width="150px" /></button>' + "</td></tr>";
                }
            }
        }
    }
    photos_html += '</table>';
    if (has_photos === 'yes') {
        return photos_html;
    } else {
        return '';
    }
    setTimeout(function () {
        $(".bridge-photo").colorbox({
            rel: 'bridge-photo',
            height: 600
        });
    }, 1000);
}

function get_photos(layer, resultObj, elem)
{
    var photo_url = "http://nwash.softwel.com.np/" + "uploadedphotos/Inventory/";
    var arr = {};
    arr.reservoir = ['photo1_path', 'photo2_path'];
    arr.tap = ['photo1_path', 'photo2_path'];
    arr.water_source = ['photo1_path', 'photo2_path', 'photo3_path'];
    arr.project_details = ['photo1_path', 'photo2_path', 'photo3_path'];
    arr.pipe = ['photo1_path', 'photo2_path'];
    arr.structure = ['photo1_path', 'photo2_path'];
    arr.sanitation = ['photo1_path', 'photo2_path'];
    //var photos_html = "<table>";
    //photos_html += '<tr><th colspan="2">Photos:</th></tr>';
    var photos_html = '<table class=\"table table-condensed\" style="margin-top:10px">';
    photos_html += '<tr style="background:#37D166 ;color:#fff;" id="title_sus"><td colspan="2"><strong>Photos</strong></td></tr>';
    for (var key in resultObj) {
        if (resultObj[key] != null) {
            if (inArray(key, arr[layer])) {
                var photo = resultObj[key];
                if (photo != null) {
                    photos_html += '<tr><td><a target="_blank" href="' + photo_url + photo + '" class="bridge-photo" rel="bridge-photo"><img src="' + photo_url + photo + '" width="150px" /></a>' + "</td></tr>";
                }
            }
        }
    }
    photos_html += '</table>';
    elem.innerHTML += photos_html;
    //$("#identify-view-draggable .content").append(photos_html);
    setTimeout(function () {
        $(".bridge-photo").colorbox({
            rel: 'bridge-photo',
            height: 600
        });
    }, 1000);
}

function check_dictionary(key) {
    if (dictionary[key] != '' && typeof dictionary[key] != 'undefined') {
        return dictionary[key];
    } else {
        return key;
    }
}
function if_null(key, val) {
    if (val == null) {
        return dictionary[key + '_val'];
    } else {
        return val;
    }
}
function get_project_details(r, pro_uuid, test_val) {
    if (test_val != 'wash') {
        $.ajax({
            type: 'POST',
            url: '/System/GetProjectDetails',
            data: {'proUuid': pro_uuid},
            dataType: 'json',
            success: function (data) {
                console.log(data);
                var district = "<td><b>District :</b></td><td>" + data.district_name + " (" + data.district_code + ")</td>";
                var muni = "<td><b>Municipality :</b></td><td>" + data.mun_name + " (" + data.mun_code + ")</td>";
                var pname = "<td><b>Project Name :</b></td><td>" + data.pro_name + "</td>";
                var pcode = "<td><b>Project Code :</b></td><td>" + data.pro_code + "</td>";
                $('#' + r + '_district').html(district);
                $('#' + r + '_muni').html(muni);
                $('#' + r + '_pro_name').html(pname);
                $('#' + r + '_project_code').html(pcode);
            }
        });
    }
}
function get_sustain_count(pro_uuid) {
    $.ajax({
        type: 'POST',
        url: baseurl + 'data/get_sustain_details',
        data: {'pro_uuid': pro_uuid,[csrfName]: csrfHash},
        dataType: 'json',
        success: function (data) {
            assign_sus_count(data.length);
        }
    });
}
function assign_sus_count(sus_count) {
    sus_len = sus_count;
}
function get_sustain_data(r, pro_uuid) {
    $.ajax({
        type: 'POST',
        url: baseurl + 'data/get_sustain_details',
        data: {'pro_uuid': pro_uuid,[csrfName]: csrfHash},
        dataType: 'json',
        success: function (data) {
            $.each(data, function (el) {
                $('#' + r + '_fiscal_year_' + el).html(data[el].fiscal_year);
                $('#' + r + '_wua_name_' + el).html(data[el].wua_name_eng);
                $('#' + r + '_wua_date_' + el).html(data[el].wua_date);
                $('#' + r + '_wua_address_' + el).html(data[el].wua_address);
                $('#' + r + '_wua_phone_' + el).html(data[el].wua_phone);
                if (data[el].wua_email != 'dev@mail.com') {
                    $('#' + r + '_wua_email_' + el).html(data[el].wua_email);
                }
                if (data[el].add_by != 'Softwel') {
                    $('#' + r + '_add_by_' + el).html(data[el].add_by);
                }
                $('#' + r + '_add_date_' + el).html(data[el].add_date);
                $('#' + r + '_view_all_' + el).html('<a href="' + baseurl + 'structure/report_view/' + pro_uuid + '/' + data[el].fiscal_year.replace('/', '-') + '?list_by=province,district,municipality" target="_blank">View All Details >></a>');
            });
            if (!data.length) {
                for (var i = 0; i < sus_len; i++) {
                    $('#' + r + '_tr_fiscal_year_' + i).remove();
                    $('#' + r + '_tr_wua_name_' + i).remove();
                    $('#' + r + '_tr_wua_date_' + i).remove();
                    $('#' + r + '_tr_wua_address_' + i).remove();
                    $('#' + r + '_tr_wua_phone_' + i).remove();
                    $('#' + r + '_tr_wua_email_' + i).remove();
                    $('#' + r + '_tr_add_by_' + i).remove();
                    $('#' + r + '_tr_add_date_' + i).remove();
                    $('#' + r + '_tr_view_all_' + i).remove();
                }
                $('#' + r + '_table_sus').append('<tr><td colspan="2">NoData Available</td></tr>');
            } else if (data.length > 0 && data.length < sus_len) {
                for (var i = data.length; i < sus_len; i++) {
                    $('#' + r + '_tr_fiscal_year_' + i).remove();
                    $('#' + r + '_tr_wua_name_' + i).remove();
                    $('#' + r + '_tr_wua_date_' + i).remove();
                    $('#' + r + '_tr_wua_address_' + i).remove();
                    $('#' + r + '_tr_wua_phone_' + i).remove();
                    $('#' + r + '_tr_wua_email_' + i).remove();
                    $('#' + r + '_tr_add_by_' + i).remove();
                    $('#' + r + '_tr_add_date_' + i).remove();
                    $('#' + r + '_tr_view_all_' + i).remove();
                }
            }
        }
    });
}

//<editor-fold desc="zoom to previous extend and zoom to next extend tools">
var history_tool = {
    arr: [],
    index: -1,
    maxSize: 5,
    currentIndex: this.index,
    is_using_history_tool: false,
    first_render: true,
    record_screen_extent: function ()
    {
        if (!this.is_using_history_tool)
        {
            var extent = map.getView().calculateExtent();
//            var extent = map.getExtent();
            if (extent != null)
            {
                if (this.arr.length == this.maxSize)
                {
                    this.arr.shift()
                    //this.index--;
                } else
                {
                    this.index++;
                }
                this.currentIndex = this.index;
                this.arr[this.currentIndex] = extent;
            } else
            {
                if (this.first_render)
                {
                    this.index++;
                    this.currentIndex = this.index;
                    this.arr[this.currentIndex] = [8912260.091133313, 3042341.524138276, 9818849.801192472, 3561365.8324687113];
                    //this.arr[this.currentIndex] = new OpenLayers.Bounds(8912260.091133313, 3042341.524138276, 9818849.801192472, 3561365.8324687113);
                    this.first_render = false;
                }
            }
        } else
        {
            this.is_using_history_tool = false;
        }
    },
    goto_previous_extent: function ()
    {
        if (this.currentIndex > 0)
        {
            //console.log(this.currentIndex);
            this.currentIndex--;
            this.is_using_history_tool = true;
            map.getView().fit(this.arr[this.currentIndex]);
            //map.zoomToExtent(this.arr[this.currentIndex], true);
        }

    },
    goto_next_extent: function ()
    {
        if (this.currentIndex < this.index)
        {
            this.currentIndex++;
            this.is_using_history_tool = true;
            map.getView().fit(this.arr[this.currentIndex]);
            //map.zoomToExtent(this.arr[this.currentIndex], true);
        }

    }

}

//</editor-fold>

Tools.goto_project = function (pro_uuid)
{
    var this_project = $('#this_project_only').is(":checked");
    var selected_project_uuid = cql_pro_uuid = $("#select_project").val();
    console.log(selected_project_uuid);
    var url = "Map/GetProjectExtent/";
    $.ajax({
        type: "POST",
        url: url,
        data: { 'proUuid': selected_project_uuid },
        dataType:'json',
        success: function (result) {
            
            result = result[0];
           // var extentVal = [e.left, e.bottom, e.right, e.top];
            var extentVal = [result.xmin, result.ymin, result.xmax, result.ymax];
            var extent = map.getView().fit(extentVal, map.getSize());

            if (this_project === true) {

                division_tool.filterParams["cql_filter"] = "uuid='" + selected_project_uuid + "'";

                project.getSource().updateParams(division_tool.filterParams);

                project.setVisible(true);

                division_tool.filterParams["cql_filter"] = "pro_uuid='" + selected_project_uuid + "'";

                project_coverage.getSource().updateParams(division_tool.filterParams);

                project_coverage.setVisible(true);

                water_source.getSource().updateParams(division_tool.filterParams);
                water_source.setVisible(true);

                reservoir.getSource().updateParams(division_tool.filterParams);
                reservoir.setVisible(true);

                pipe.getSource().updateParams(division_tool.filterParams);
                pipe.setVisible(true);

                tap.getSource().updateParams(division_tool.filterParams);
                tap.setVisible(true);

                structure.getSource().updateParams(division_tool.filterParams);
                structure.setVisible(true);

                junction.getSource().updateParams(division_tool.filterParams);
                junction.setVisible(true);
                identifyToolHelper.selectAllIdentifyLayer()
            } else {

                division_tool.filterParams["cql_filter"] = null;

                project.getSource().updateParams(division_tool.filterParams);
                project.setVisible(true);

                project_coverage.getSource().updateParams(division_tool.filterParams);
                project_coverage.setVisible(true);

                water_source.getSource().updateParams(division_tool.filterParams);
                water_source.setVisible(true);

                reservoir.getSource().updateParams(division_tool.filterParams);
                reservoir.setVisible(true);

                pipe.getSource().updateParams(division_tool.filterParams);
                pipe.setVisible(true);

                tap.getSource().updateParams(division_tool.filterParams);
                tap.setVisible(true);

                structure.getSource().updateParams(division_tool.filterParams);
                structure.setVisible(true);

                junction.getSource().updateParams(division_tool.filterParams);
                junction.setVisible(true);
            }
        }
    })
}

Tools.goto_taps = function (pro_uuid)
{

    var selected_tap_uuid = cql_tap_uuid = $("#select_tap").val();
    var url = "Map/GetTapExtents/";
    $.ajax({
        type: "POST",
        url: url,
        data: { 'tapUuid': selected_tap_uuid },
        dataType:'json',
        success: function (result) {      
            result = result[0];
            var extentVal = [result.xmin, result.ymin, result.xmax, result.ymax];
            var extent = map.getView().fit(extentVal, map.getSize());

            division_tool.filterParams["cql_filter"] = "uuid='" + selected_tap_uuid + "'";
            tap.getSource().updateParams(division_tool.filterParams);
            tap.setVisible(true);
            identifyToolHelper.selectAllIdentifyLayer();
        }
    });
}

Tools.edit_project = function (pro_uuid)
{
    if (user_district === '0' || user_district === selected_district) {
        if (user_agency === selected_agency || user_agency === 'ALL') {
            var selected_project_uuid = btoa($("#select_project").val());
            var url = baseurl + "draw/main/" + selected_project_uuid;
            window.open(url, '_blank');
        } else {
            alert('You dont have permission to edit this project!!');
        }
    } else {
        alert('You dont have permission to edit this project!!');
    }
}
var distance_tool = {
    show: function ()
    {
        $('#mapDiv').css('cursor', 'default');
        Tools.deactivateAllTools();
        activate = true;
        $("#distance-draggable").show();
        $("#distance-draggable").attr("class", 'goto-distance-active');
    },
    deactivate: function ()
    {
        if (clicked > 1) {
            if (vec_line.getSource() !== null)
                remove_layers('name', 'line');
            if (vec_segment.getSource() !== null)
                remove_layers('name', 'seg');
            if (vec_polygon.getSource() !== null)
                remove_layers('name', 'poly');
            if (vec_polygon_clo.getSource() !== null)
                remove_layers('name', 'poly_clo');
           
            coordinates = [];
        }

        activate = false;
        markers.getSource().clear();
        clicked = 0;
        length = 0;
        lat = '';
        lng = '';
        $('#length').html('Total Distance');
        $('#segment').html('Distance');
        $('#area').html('Total Area');
        $('#line_distance').html('Line Distance');
        $("#distance-draggable").hide();
    },
    clear: function ()
    {
        if (clicked > 1) {
            if (vec_line.getSource() !== null)
                remove_layers('name', 'line');
            if (vec_segment.getSource() !== null)
                remove_layers('name', 'seg');
            if (vec_polygon.getSource() !== null)
                remove_layers('name', 'poly');
            if (vec_polygon_clo.getSource() !== null)
                remove_layers('name', 'poly_clo');

            coordinates = [];
        }
        markers.getSource().clear();
        clicked = 0;
        length = 0;
        lat = '';
        lng = '';
        $('#length').html('Total Distance');
        $('#segment').html('Distance');
        $('#area').html('Total Area');
        $('#line_distance').html('Line Distance');
    }
}
var newsource_tool = {
    show: function ()
    {
        $("#newsource-draggable").show();
        $("#newsource-tool").attr("class", 'new-source-active');
    },
    hide: function ()
    {
        $("#newsource-draggable").hide();
        $("#newsource-tool").attr("class", 'new-source');
    },
    goto_project: function (pro_uuid)
    {
        var selected_source_uuid = $("#select_newsource").val();
        var url = baseurl + "map/get_new_source_extent/" + selected_source_uuid;
        $.ajax(
                {
                    type: "POST",
                    url: url,
                    data: {[csrfName]: csrfHash},
                    success: function (result) {
                        var e = $.parseJSON(result);
                        var extentVal = [e.left, e.bottom, e.right, e.top];
                        var extent = map.getView().fit(extentVal, map.getSize());
                        //var extent = new OpenLayers.Bounds(e.left, e.bottom, e.right, e.top);
                        map.zoomToExtent(extent, true);
                        //map.zoomToExtent(this.arr[this.currentIndex], true);
                    }
                })
    },
    edit_project: function (pro_uuid)
    {
        var selected_source_uuid = $("#select_newsource").val();
        var url = baseurl + "edit_new_source/main/" + selected_source_uuid;
        window.open(url, '_blank');
    }
}

//Tools.addTools([panToolHelper, zoomInToolHelper, zoomOutToolHelper, identifyToolHelper]);
Tools.addTools([panToolHelper, zoomInToolHelper, zoomOutToolHelper, identifyToolHelper]);
Tools.initialize();
function inArray(needle, haystack) {
    if (typeof haystack === "undefined") {
        return false;
    } else {
        var length = haystack.length;
        for (var i = 0; i < length; i++) {
            if (haystack[i] == needle)
                return true;
        }
        return false;
    }
}

function clip_this(type, code, event_type) {
    if (type === 'municipality') {
        division_tool.goto_municipality(code, event_type);
    } else if (type === 'district') {
        division_tool.goto_district(code, event_type);
    } else if (type === 'province') {
        division_tool.goto_province(code, event_type);
    }
}





