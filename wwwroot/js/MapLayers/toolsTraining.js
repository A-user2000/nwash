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

        for (i = 0; i < this.toolsArr.length; i++) {
            var tool = this.toolsArr[i].tool;
            $(tool.node).click(function () {
                //map.addInteraction(tool);
                tool.activate();
            });
        }
    },
    addTools: function (_toolsArr) {
        for (i = 0; i < _toolsArr.length; i++) {
            this.toolsArr.push(_toolsArr[i])
        }

    },
    deactivateAllTools: function () {
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
    deactivateZoomTools: function () {
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
var ToolHelper = function (objName, _tool, _name, _active, _node, _activeClass, _inactiveClass, _mouseOverClass, _mouseOutClass, _cursor) {
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
    this.activate = function () {

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
    this.deactivate = function () {
        //this.tool.deactivate();
        map.removeInteraction(this.tool);
        //map.getInteractions().pop()
        $(this.node).attr("class", this.inactiveClass);
    };
    this.IdentifyToolHelperClick = function () {
        map.on('singleclick', function (e) {
            var elem1 = document.getElementById('popup-content');
            elem1.innerHTML = '';
            var viewResolution = map.getView().getResolution();
            selectedLayer.forEach(function (layer) {
                if (layer.get('visible') == true) {
                    //url1 = layer.getSource().getGetFeatureInfoUrl(e.coordinate, viewResolution, 'EPSG:3857', { 'INFO_FORMAT': 'application/json' });
                    url1 = layer.getSource().getFeatureInfoUrl(e.coordinate, viewResolution, 'EPSG:3857', { 'INFO_FORMAT': 'application/json' });
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
                                var projectkey = ['uuid', 'pro_name', 'pro_code', 'pro_type', 'lat', 'lon', 'ele', 'ward_no', 'settlement_name', 'cons_year', 'cons_agency', 'sup_agency', 'inv_agency', 'collected_on', 'collected_by'];
                                var projectkeyDisplay = ['uuid', 'pro_name', 'pro_code', 'Project Type:', 'Latitude:', 'Longitude:', 'Elevation:', 'Ward No:', 'Settlement Name:', 'Construction Year:', 'Construction Agency:', 'Supporting Agency:', 'Inv Agency:', 'Collected Date:', 'Collected By:'];
                                var sanitationkey = [];
                                var sourcekey = ['pro_uuid', 'sou_name', 'sou_type', 'sou_reg', 'reg_year', 'lat', 'lon', 'ele', 'int_type', 'sou_con', 'sou_use', 'nea_cmu', 'sou_dist', 'mea_dis', 'mea_date', 'min_yield', 'wat_qua', 'flow_reg', 'sou_pro', 'sou_eqk', 'sta_eqk', 'tre_req', 'rtip_time', 'sou_rem', 'add_date', 'collected_on', 'collected_by'];
                                var sourcekeyDisplay = ['pro_uuid', 'Source Name:', 'Source Type:', 'Source Registration:', 'Registered Year:', 'Latitude:', 'Longitude:', 'Elevation:', 'Intake Type:', 'Intake Condition:', 'Present Water Use:', 'Nearest Community Name:', 'Distance from Nearest Community (km):', 'Measured Distance:', 'Measured Date:', 'Minimun Yield(lps):', 'Water Quality:', 'Flow Regularity', 'Source Protection:', 'Earthquake Effect on Flow:', 'Earthquake Effect on Stability:', 'Treatment Facilities:', 'Round Trip Time:', 'Remarks:', 'Add Date:', 'Collected Date:', 'Collected By:'];
                                var reservoirkey = ['pro_uuid', 'rvt_no', 'rvt_type', 'rvt_cap', 'lat', 'lon', 'ele', 'rvt_qua', 'rvt_con', 'rvt_eqk', 'rvt_rem', 'data_year', 'add_date', 'add_by', 'cons_year', 'collected_on', 'collected_by'];
                                var reservoirkeyDisplay = ['pro_uuid', 'RVT No in Scheme:', 'RVT Type:', 'RVT Capacity(cum):', 'Latitude:', 'Longitude:', 'Elevation:', 'Adequacy of RVT:', 'RVT Condition:', 'Earthquake Effect:', 'Remarks:', 'Data Year:', 'Added Date:', 'Added By:', 'construction Year:', 'Collected Date:', 'Collected By:'];
                                var pipekey = ['pro_uuid', 'pipe_name', 'pipe_part', 'pipe_type', 'pipe_class', 'pipe_dia', 'pipe_cond', 'pipe_eqk', 'pipe_rem', 'pipe_lcon', 'pipe_len', 'leakage_count', 'add_date', 'add_by', 'data_year', 'collected_on', 'collected_by'];
                                var pipekeyDisplay = ['pro_uuid', 'Pipe Name:', 'Pipe Type:', 'Pipe Type:', 'Pipe Class:', 'Pipe Diameter(Mm):', 'Pipe Condition:', 'Earthquake Effect:', 'Remarks:', 'Pipe Laying Condition:', 'Pipe Length:', 'Leakage Count:', 'Added Date:', 'Added By:', 'Data Year:', 'Collected On:', 'Collected By:'];
                                var junctionkey = ['pro_uuid', 'junc_no', 'lat', 'lon', 'ele', 'data_year', 'add_date', 'add_by', 'collected_on', 'collected_by'];
                                var junctionkeyDisplay = ['pro_uuid', 'Junction No:', 'Latitude:', 'Longitude:', 'Elevation:', 'Data Year:', 'Added Date:', 'Added By:', 'Collected Date:', 'Collected By:'];
                                var structurekey = ['pro_uuid', 'str_no', 'str_type', 'lat', 'lon', 'ele', 'str_other', 'str_cond', 'str_dim', 'str_eqk', 'str_rem', 'str_dim_len', 'str_dim_width', 'str_dim_height', 'add_date', 'add_by', 'cons_year', 'collected_on', 'collected_by'];
                                var structurekeyDisplay = ['pro_uuid', 'Structure No:', 'Structure Type:', 'Latitude:', 'Longitude:', 'Elevation:', 'Structure Type Others:', 'Condition of Structure:', 'Structure Dimension:', 'Earthquake Effect:', 'Remarks:', 'Structure Dimension Length:', 'Structure Dimension Width:', 'Structure Dimension Height:', 'Added Date:', 'Added By:', 'Construction Year:', 'Collected Date:', 'Collected By:'];
                                var tapkey = ['pro_uuid', 'tap_no', 'tap_owner', 'tap_contact', 'lat', 'lon', 'ele', 'tap_type', 'tap_meter', 'hh_serverd', 'hh_toilet', 'female_pop', 'male_pop', 'tap_cond', 'tap_flow_con', 'tap_fhours', 'tap_water_quality', 'tap_eqk', 'tap_complaint', 'no_leakage', 'tap_rem', 'data_year', 'add_date', 'add_by', 'collected_on', 'collected_by'];
                                var tapkeyDisplay = ['pro_uuid', 'Tap No:', 'Owner/Representative Name:', 'Contact Number:', 'Latitude:', 'Longitude:', 'Elevation:', 'Tap Type:', 'Metered Connection:', 'No of HH Serverd:', 'Household Toilet:', 'Female Population:', 'Male Population:', 'Tap Condition:', 'Flow Condition:', 'Supply Hours:', 'Tap Water Quality:', 'Earthquake Effect:', 'No of Complaints Logged this Year:', 'No of Leakage this Year:', 'Remarks:', 'Data Year:', 'Added Date:', 'Added By:', 'Collected Date:', 'Collected By:'];
                                var leftouttapskey = ['pro_uuid', 'tap_no', 'tap_owner', 'tap_contact', 'lat', 'lon', 'ele', 'tap_type', 'hh_serverd', 'hh_toilet', 'female_pop', 'male_pop', 'data_year', 'add_date', 'add_by', 'collected_on', 'collected_by'];
                                var leftouttapskeyDisplay = ['pro_uuid', 'Tap No:', 'Owner/Representative Name:', 'Contact Number:', 'Latitude:', 'Longitude:', 'Elevation:', 'Tap Type:', 'No of HH Serverd:', 'Household Toilet:', 'Female Population:', 'Male Population:', 'Data Year:', 'Added Date:', 'Added By:', 'Collected Date:', 'Collected By:'];
                                var pipedSystemkey = ['mun_code', 'mun_name', 'basic', 'basic_percent', 'limited', 'limited_percent', 'safely_managed', 'safely_managed_percent', 'unserved', 'unserved_percent'];
                                var pipedSystemkeyDisplay = ['Municipality Code', 'Municipality Name', 'Basic', 'Basic Percent', 'Limited', 'Limited Percent', 'Safely Managed', 'Safely Managed Percent', 'Unserved', 'Unserved Percent'];
                                var community_sanitationkey = [];
                                var healthc_carekey = ['name_of_hcf', 'hcf_type', 'hcf_type_other', 'name_of_community', 'ward_number', 'contact_name', 'contact_number', 'key_respondent', 'latitude', 'longitude', 'elevation', 'birthing_center_status', 'no_of_patients_daily', 'hcf_source_of_water_status', 'hcf_source_of_water', 'hcf_drinking_water_status', 'hcf_water_sufficient_status', 'water_insufficient', 'alternative_water_source', 'alternative_water_source_lasting_period', 'water_safe_to_drink', 'water_treatment_status', 'water_treatment_type', 'water_treatment_type_other', 'water_quality_tested_status', 'water_quality_tested_result', 'disabled_access_water', 'water_storage_tank', 'water_managed', 'hcf_toilstatus', 'total_toilet', 'total_toilet_used', 'total_toilet_unused', 'total_toilet_with_water', 'toilet_for_patient', 'toilet_for_patient_used', 'toilet_for_patient_unused', 'toilet_for_patient_with_water', 'toilet_for_staff', 'toilet_for_staff_used', 'toilet_for_staff_unused', 'toilet_for_staff_with_water', 'toilet_for_all', 'toilet_for_all_used', 'toilet_for_all_unused', 'toilet_for_all_with_water', 'type_of_latrine', 'type_of_latrine_other', 'who_cleans_latrine_hp', 'dustbin_with_lid_in_female_toilet', 'urinal_status', 'no_of_urinal', 'reason_for_no_toilet', 'type_of_dustbins', 'dustbin_other', 'waste_nirmulikaran', 'waste_disposed', 'resuable_medical_instruments_cleaned', 'drinking_water_station_status', 'drinking_water_accessible_status', 'drinking_water_tank', 'water_tank_covered_status', 'toilet_hygiene', 'status_of_toilet', 'toilet_security', 'separate_female_toilet', 'dustbin_in_female_toilet', 'children_easy_access', 'children_adequate_soap', 'ramp_outside_toilet', 'sufficient_space_in_toilet', 'hand_washing_station_near_toilet', 'hand_washing_station_condition', 'hand_washing_station_in_opd', 'hand_washing_station_condition_in_opd', 'delivery_room_status', 'delivery_room_clean_status', 'toilet_in_dr', 'hand_washing_station_in_dr', 'hand_washing_station_condition_in_dr', 'dustbins_labelled', 'toilet_clean_schedule', 'own_building', 'salnal_status', 'salnal_type', 'salnal_covered', 'salnal_ventilator', 'organisation_comittee_status', 'organisation_comittee_work', 'hcf_drinking_water_inside_status', 'toilet_lock_system', 'health_care_kind', 'date', 'hcf_source_of_water_status_plan', 'male_patient', 'female_patient', 'male_staff', 'female_staff', 'time_to_bring_water', 'tank_size', 'water_purifier_availability', 'water_purifier_condition', 'working_taps', 'disabled_friendly_working_taps', 'minor_taps_repair', 'major_taps_repair', 'reconstruction_needed_taps', 'fecal_contamination', 'priority_chemical_contamination', 'usable_male_toilet', 'usable_female_toilet', 'usable_female_toilet_with_mhm', 'usable_staff_toilet', 'minor_toilet_repair', 'major_toilet_repair', 'reconstruction_needed_toilet', 'usable_disabled_friendly_toilet', 'usable_handwashing_station', 'minor_handwashing_repair', 'major_handwashing_repair', 'reconstruction_needed_handwashing', 'soap_water_in_handwashing_station', 'alcohol_based_rub_availability', 'dustbin_number', 'acute_contagious_waste_separation', 'incinerator_availability_for_mhm', 'incinerator_condition', 'incinerator_for_hazardous_waste', 'hazardous_waste_incinerator_condition', 'salnal_condition', 'environmental_sanitation_protocol', 'environmental_sanitation_staff', 'uploaded_by', 'agency_name'];
                                var healthc_carekeyDisplay = ['Name of Health Care Facility:', 'HCF Type:', 'HCF Type Other:', 'Name of Community:', 'Ward Number:', 'Contact Name:', 'Contact Number:', 'Key Respondent:', 'Latitude:', 'Longitude:', 'Elevation:', 'Birthing Center Status:', 'No of Patients Daily:', 'HCF  Source of Water Status:', 'HCF Source of Water:', 'HCF Drinking Water Status:', 'HCF Water Sufficient Status:', 'Water Insufficient:', 'Alternative Water Source:', 'Alternative Water Source Lasting Period:', 'Water Safe to Drink:', 'Water Treatment Status:', 'Water Treatment Type:', 'Water Treatment Type Other:', 'Water Quality Tested Status:', 'Water Quality Tested Result:', 'Disabled Access Water:', 'Water Storage Tank:', 'Water Managed:', 'HCF Toilet Status:', 'Total Toilet:', 'Total Toilet Used:', 'Total Toilet Unused:', 'Total Toilet with Water:', 'Toilet for Patient:', 'Toilet for Patient Used:', 'Toilet for Patient Unused:', 'Toilet for Patient with Water:', 'Toilet for Staff:', 'Toilet for Staff Used:', 'Toilet for Staff Unused:', 'Toilet for Staff with Water:', 'Toilet for All:', 'Toilet for all Used:', 'Toilet for all Unused:', 'Toilet for all with Water:', 'Type of Latrine:', 'Type of Latrine Other:', 'Who Cleans Latrine Healthpost:', 'Dustbin with Lid in Female Toilet:', 'Urinal Status:', 'No of Urinal:', 'Reason for No Toilet:', 'Type of Dustbins:', 'Dustbin Other:', 'Waste Nirmulikaran:', 'Waste Disposed:', 'Resuable Medical Instruments Cleaned:', 'Drinking Water Station Status:', 'Drinking Water Accessible Status:', 'Drinking Water Tank:', 'Water Tank Covered Status:', 'Toilet Hygiene:', 'Status of Toilet:', 'Toilet Security:', 'Separate Female Toilet:', 'Dustbin in Female Toilet:', 'Children Easy Access:', 'Children Adequate Soap:', 'Ramp Outside Toilet:', 'Sufficient Space in Toilet:', 'Hand Washing Station Near Toilet:', 'Hand Washing Station Condition:', 'Hand Washing Station in OPD:', 'Hand Washing Station Condition in OPD:', 'Delivery Room Status:', 'Delivery Room Clean Status:', 'Toilet in Dr:', 'Hand Washing Station in Dr:', 'Hand Washing Station Condition in Dr:', 'Dustbins Labelled:', 'Toilet Clean Schedule:', 'Own Building:', 'Salnal Status:', 'Salnal Type:', 'Salnal Covered:', 'Salnal Ventilator:', 'Organisation Comittee Status:', 'Organisation Comittee Work:', 'HCF Drinking Water Inside Status:', 'Toilet Lock System:', 'Health Care Kind:', 'Date:', 'HCF Source of Water Status Plan:', 'Male Patient:', 'Female Patient:', 'Male Staff:', 'Female Staff:', 'Time to Bring Water:', 'Tank Size:', 'Water Purifier Availability:', 'Water Purifier Condition:', 'Working Taps:', 'Disabled Friendly Working Taps:', 'Minor Taps Repair:', 'Major Taps Repair:', 'Reconstruction Needed Taps:', 'Fecal Contamination:', 'Priority Chemical Contamination:', 'Usable Male Toilet:', 'Usable Female Toilet:', 'Usable Female Toilet with mhm:', 'Usable Staff Toilet:', 'Minor Toilet Repair:', 'Major Toilet Repair:', 'Reconstruction Needed Toilet:', 'Usable Disabled Friendly Toilet:', 'Usable Handwashing Station:', 'Minor Handwashing Repair:', 'Major Handwashing Repair:', 'Reconstruction Needed Handwashing:', 'Soap Water in Handwashing Station:', 'Alcohol based Rub Availability:', 'Dustbin Number:', 'Acute Contagious Waste Separation:', 'Incinerator Availability for mhm:', 'Incinerator Condition:', 'Incinerator for Hazardous Waste:', 'Hazardous Waste Incinerator Condition:', 'Salnal Condition:', 'Environmental Sanitation Protocol:', 'Environmental Sanitation Staff:', 'Uploaded By:', 'Agency Name:'];
                                var householdkey = ['ward_no', 'village', 'informer_name', 'informer_ethnicity', 'informer_age', 'informer_gender', 'contact_no', 'fam_head_name', 'fam_head_ethnicity', 'female_fam_head_status', 'fam_no', 'female_num', 'male_num', 'other_num', 'male_below_18_num', 'female_below_18_num', 'boy_below_5_num', 'girl_below_5_num', 'disabled_member_num', 'latitude', 'longitude', 'elevation', 'date', 'main_fam_income_source', 'other_income_source', 'source_of_water', 'time_to_bring_water', 'used_water_drinkable_perception', 'accessibility_of_water', 'water_purification_done', 'toilet_availability', 'toilet_construction_yr_mnth', 'toilet_construction_cost', 'toilet_superstructure_type', 'toilet_used_status', 'toilet_type_used', 'num_using_toilet', 'toilet_type', 'toilet_roof_material', 'latrine_floor_type', 'female_using_toilet_during_period_status', 'toilet_connection', 'pit_leakage_status', 'cover_for_pit', 'toilet_gas_pipe_used', 'space_for_pit_construction', 'cleaning_facilities', 'soap_hand_washing_facilities', 'defecation', 'hand_washing_facilities', 'availability_of_soap_water', 'hand_washing_time_with_soap', 'fixed_dish_wash_station', 'dish_waste_water_dest', 'dry_dishes_in_sun_status', 'dry_dishes_place', 'house_cleanliness_status', 'pit_line_status', 'full_tank_period', 'tank_cleaner', 'tank_cleaning_cost', 'faecal_waste_transportation', 'faecal_sludge_treatment', 'public_space_for_sludge_treatment', 'treatment_land_area', 'separate_waste_mgmt', 'solid_waste_transport_facility', 'solid_waste_transporter', 'solid_waste_transport_cost', 'land_field_location', 'waste_transport_period', 'service_satisfaction', 'land_field_distance_from_community', 'recyclable_nonrecyclable_separation', 'tubewell_depth', 'tubewell_platform', 'tubewell_water_taste', 'tubewell_water_smell', 'tubewell_water_color', 'tubewell_water_turbidity', 'tubewell_water_effect_on_teeth', 'tubewell_arsenic_test', 'tubewell_arsenic_test_status', 'tubewell_clothes_stained', 'water_12mnths_availability', 'water_purification_method', 'other_water_purification_method', 'house_cleanliness_observed', 'toilet_used_by_neighbours', 'toilet_wall_material', 'water_source_distance_from_pit', 'toilet_renovation_status', 'toilet_renovation_type', 'toilet_cleanliness_observed', 'toilet_pit_cleaner', 'tubewell_photo_uuid', 'presence_of_water_in_toilet', 'fam_head_contact_no', 'tubewell_pipe_sys_project_status', 'tubewell_condition', 'tubewell_type', 'households_using_tubewell', 'population_using_tubewell', 'tubewell_treatment_system', 'tubewell_fecal_contamination', 'tubewell_arsenic_contamination', 'tubewell_constructed_year', 'tubewell_construction_cost', 'private_toilet', 'disabled_friendly_toilet', 'soap_in_hand_washing_station', 'water_in_hand_washing_station', 'uploaded_by', 'agency_name', 'tubewell_water_adequacy'];
                                var householdkeyDisplay = ['Ward No:', 'Village:', 'Informer Name:', 'Informer Ethnicity:', 'Informer Age:', 'Informer Gender:', 'Contact No:', 'Family Head Name:', 'Family Head Ethnicity:', 'Female Family Head Status:', 'Family No:', 'Female No:', 'Male No:', 'Other No:', 'Male Below 18 No:', 'Female Below 18 No:', 'Boy Below 5 No:', 'Girl Below 5 No:', 'Disabled Member No:', 'Latitude:', 'Longitude:', 'Elevation:', 'Date:', 'Main Family Income Source:', 'Other Income Source:', 'Source of Water:', 'Time to Bring Water:', 'Used Water Drinkable Perception:', 'Accessibility of Water:', 'Water Purification Done:', 'Toilet Availability:', 'Toilet Construction Year Month:', 'Toilet Construction Cost:', 'Toilet Superstructure Type:', 'Toilet used Status:', 'Toilet Type used:', 'No using Toilet:', 'Toilet Type:', 'Toilet Roof Material:', 'Latrine Floor Type:', 'Female using Toilet during Period:', 'Toilet Connection:', 'Pit Leakage Status:', 'Cover for Pit:', 'Toilet Gas Pipe used:', 'Space for Pit Construction:', 'Cleaning Facilities:', 'Soap Hand Washing Facilities:', 'Defecation:', 'Hand Washing Facilities:', 'Availability of Soap Water:', 'Hand Washing Time with Soap:', 'Fixed Dish Wash Station:', 'Dish Waste Water Destination:', 'Dry Dishes in Sun Status:', 'Dry Dishes Place:', 'House Cleanliness Status:', 'Pit Line Status:', 'Full Tank Period:', 'Tank Cleaner:', 'Tank Cleaning Cost:', 'Faecal Waste Transportation:', 'Faecal Sludge Treatment:', 'Public Space for Sludge Treatment:', 'Treatment Land Area:', 'Separate Waste Management:', 'Solid Waste Transport Facility:', 'Solid Waste Transporter:', 'Solid Waste Transport Cost:', 'Land Field Location:', 'Waste Transport Period:', 'Service Satisfaction:', 'Land Field Distance from Community:', 'Recyclable Nonrecyclable Separation:', 'Tubewell Depth:', 'Tubewell Platform:', 'Tubewell Water Taste:', 'Tubewell Water Smell:', 'Tubewell Water Color:', 'Tubewell Water Turbidity:', 'Tubewell Water Effect on Teeth:', 'Tubewell Arsenic Test:', 'Tubewell Arsenic Test Status:', 'Tubewell Clothes Stained:', 'Water 12 Months Availability:', 'Water Purification Method:', 'Other Water Purification Method:', 'House Cleanliness Observed:', 'Toilet used by Neighbours:', 'Toilet Wall Material:', 'Water Source Distance from Pit:', 'Toilet Renovation Status:', 'Toilet Renovation Type:', 'Toilet Cleanliness Observed:', 'Toilet Pit Cleaner:', 'Tubewell Photo:', 'Presence of Water in Toilet:', 'Family Head Contact No:', 'Tubewell Pipe System Project Status:', 'Tubewell Condition:', 'Tubewell Type:', 'Households using Tubewell:', 'Population using Tubewell:', 'Tubewell Treatment System:', 'Tubewell Fecal Contamination:', 'Tubewell Arsenic Contamination:', 'Tubewell Constructed Year:', 'Tubewell Construction Cost:', 'Private Toilet:', 'Disabled Friendly Toilet:', 'Soap in Hand Washing Station:', 'Water in Hand Washing Station:', 'Uploaded By:', 'Agency Name:', 'Tubewell Water Adequacy:'];
                                var public_toiletkey = ['toilet_name', 'tole_name', 'ward_number', 'name', 'contact_number', 'latitude', 'longitude', 'elevation', 'running_pt', 'running_pt_other', 'no_of_users', 'no_of_users_access_at_a_time', 'available_fund', 'operator_cost', 'material_cost', 'repair_cost', 'water_facility_available', 'type_of_facility', 'hand_washing_basin', 'soap_available_in_basin', 'lock_system', 'ventilated', 'odour', 'separate_latrine', 'urinal', 'disable_accessible', 'toilet_child_friendly', 'dustbin_facility', 'fund_collection', 'pad_availability', 'toilet_located', 'toilet_connection', 'treatment_facility', 'no_of_public_toilet', 'toilet_located_other', 'urinal_female', 'urinal_male', 'public_toilet_in_use', 'have_to_pay_to_use', 'daily_collection', 'public_toilet_not_in_use_reason', 'toilet_use_amount', 'space_for_shop', 'shop_running', 'date', 'public_toilet_state', 'male_toilet', 'female_toilet', 'provision_of_toilet_for_disabled', 'provision_of_toilet_for_children', 'public_toilet_condition', 'hand_washing_facility_sections', 'without_hand_washing_facility_sections', 'hand_washing_place_access', 'sufficient_water_supply', 'water_tank_availability', 'water_tank_sufficiency', 'toilet_use_amount_for_urination', 'agency_name', 'uploaded_by'];
                                var public_toiletkeyDisplay = ['Toilet Name:', 'Tole Name:', 'Wards:', 'Respondent Name:', 'Contact Number:', 'Latitude:', 'Longitude:', 'Elevation:', 'Running Public Toilet:', 'Running Public Toilet Other:', 'No of Users:', 'No of Users Access at a Time:', 'Available Fund:', 'Operator Cost:', 'Material Cost:', 'Repair Cost:', 'Water Facility Available:', 'Type of Facility:', 'Hand Washing Basin:', 'Soap Available in Basin:', 'Lock System:', 'Ventilated:', 'Odour:', 'Separate Latrine:', 'Urinal:', 'Disable Accessible:', 'Child Friendly Toilet:', 'Dustbin Facility:', 'Fund Collection:', 'Availability of Pad:', 'Toilet Location:', 'Toilet Connection:', 'Treatment Facility:', 'No of Public Toilet:', 'Toilet Located Other:', 'Urinal Female:', 'Urinal Male:', 'Public Toilet in use:', 'Have to Pay to use:', 'Daily Collection:', 'Public Toilet not in use Reason:', 'Toilet use Amount:', 'Space for Shop:', 'Shop Running:', 'Date:', 'Public Toilet State:', 'Male Toilet:', 'Female Toilet:', 'Provision of Toilet for Disabled:', 'Provision of Toilet for Children:', 'Public Toilet Condition:', 'Hand Washing Facility Sections:', 'Without Hand Washing Facility Sections:', 'Hand Washing Place Access:', 'Sufficient Water Supply:', 'Water Tank Availability:', 'Water Tank Sufficiency:', 'Toilet use Amount for Urination:', 'Agency Name:', 'Uploaded By'];
                                var schoolkey = ['school_name', 'school_type', 'school_level', 'school_community', 'school_ward', 'key_respondents', 'respondent_contact', 'latitude', 'longitude', 'elevation', 'female_student', 'male_student', 'other_student', 'female_teacher', 'male_teacher', 'disabled_female_student', 'disabled_male_student', 'disabled_female_teacher', 'disabled_male_teacher', 'school_wash_plan_status', 'school_ground_availability', 'cleanliness_activities_involved_status', 'wash_repair_charge_status', 'school_latrines_availability', 'total_toilets', 'total_toilets_used', 'total_toilets_unused', 'total_toilets_with_water', 'girls_separate_toilets', 'girls_separate_toilets_used', 'girls_separate_toilets_unused', 'girls_separate_toilets_with_water', 'boys_separate_toilets', 'boys_separate_toilets_used', 'boys_separate_toilets_unused', 'boys_separate_toilets_with_water', 'teachers_toilets', 'teachers_toilets_used', 'teachers_toilets_unused', 'teachers_toilets_with_water', 'communal_toilets', 'communal_toilets_used', 'communal_toilets_unused', 'communal_toilets_with_water', 'school_toilets_type', 'school_toilet_type_comments', 'school_toilets_condn', 'not_using_toilet_status', 'not_using_toilet', 'other_not_using_toilet', 'toilet_students_use', 'other_toilet_students_use', 'school_latrine_cleaner', 'student_hygiene_practice', 'student_hygiene_practice_cmnt', 'hand_washing_status', 'not_washing_with_soap_reason', 'not_washing_with_soap_other_reason', 'sanitary_napkins_access', 'mhm_fund', 'mhm_focal_teacher_status', 'mhm_trainings', 'students_presence_during_menstruation', 'sanitary_pads_disposal_plc', 'other_sanitary_pads_disposal_plc', 'child_club_status', 'chair_person_gender', 'secretary_gender', 'treasurer_gender', 'child_club_active_status', 'club_in_wash_status', 'club_member_training_status', 'school_water_status', 'school_water_source', 'major_water_source', 'time_to_bring_water', 'availability_of_drinking_water', 'adequacy_of_water', 'safe_drinking_water_status', 'water_treatment_status', 'water_treatment_type', 'other_water_treatment_type', 'water_tested_status', 'water_test_result', 'special_people_access_to_water', 'school_water_tank_availability', 'tank_size', 'total_water_points', 'tap_for_drinking', 'tap_for_washing', 'well_used_points', 'partial_damaged_points', 'fully_damaged_points', 'unused_fully_damaged_points', 'water_quality_perception', 'points_observed_status', 'points_with_condn_observed_status', 'drinking_water_access_for_all', 'source_if_no_school_water', 'hand_washing_station', 'hand_washing_station_using_condn', 'toilets_observed', 'safe_secure_toilets', 'soap_water_easy_access_by_children_for_toilet', 'door_lock_easy_access_by_children', 'dustbin_in_female_toilets', 'ramp_outside_toilet', 'sufficient_toilet_space_seat', 'toilets_cmnts', 'school_facilities', 'urinal_bathroom_cmnts', 'male_urinal_using_condn', 'male_urinal_clean_condn', 'female_urinal_using_condn', 'female_urinal_clean_condn', 'bathroom_using_condn', 'bathroom_clean_condn', 'incinerator_using_condn', 'incinerator_clean_condn', 'school_hygiene_plan_status', 'school_rating', 'skills_available', 'cleaned_regularly', 'availability_of_drinking_water_for_children', 'drainage_system', 'hand_washing_with_soap', 'waste_dumped_status', 'waste_glass_status', 'waste_recycled_status', 'open_defecation_free_status', 'extra_activity_in_vacant_land_status', 'hygiene_taught_status', 'class_five_status', 'students_actively_involved_status', 'risk_reduction_status', 'disaster_preparedness_status', 'risk_mapping_status', 'structure_constructed_criteria_status', 'teacher_provided_status', 'daily_cleaned_status', 'hygiene_corner_status', 'date', 'reusable_product_skill_status', 'hygiene_rating_status', 'coordination_committee_formed_status', 'disabled_student_teacher_status', 'physically_disabled_student', 'physically_disabled_teacher', 'blind_student', 'blind_teacher', 'student_with_other_disability', 'teacher_with_other_disability', 'female_staff', 'male_staff', 'other_staff', 'usable_female_toilet_with_hygiene', 'usable_female_toilet_without_hygiene', 'usable_toilet_for_disabled', 'minor_toilet_repair', 'major_toilet_repair', 'reconstruction_needed_toilet', 'usable_separate_boy_hand_washing_station', 'usable_separate_girl_hand_washing_station', 'usable_communal_hand_washing_station', 'usable_hand_washing_station_for_disabled', 'minor_handwashing_repair', 'major_handwashing_repair', 'reconstruction_needed_handwashing', 'soap_water_availability_in_handwashing_station', 'fecal_contamination', 'priority_chemical_contamination', 'menstruation_related_education_status', 'incinerator_availability', 'incinerator_condition', 'sufficient_water_availability_status', 'water_purifier_availability', 'water_purifier_condition', 'working_taps_for_disabled', 'school_code', 'separate_male_urinal', 'separate_female_urinal', 'is_wq_tested', 'uploaded_by'];
                                var schoolkeyDisplay = ['School Name:', 'School Type:', 'School Level:', 'School Community:', 'wards:', 'Key Respondents:', 'Respondent Contact:', 'Latitude:', 'Longitude:', 'Elevation:', 'Female Student:', 'Male Student:', 'Other Student:', 'Female Teacher:', 'Male Teacher:', 'Disabled Female Student:', 'Disabled Male Student:', 'Disabled Female Teacher:', 'Disabled Male Teacher:', 'School Wash Plan Status:', 'School Ground Availability:', 'Cleanliness Activities Involved Status:', 'Wash Repair Charge Status:', 'School Latrines Availability:', 'Total Toilets:', 'Total Toilets used:', 'Total Toilets unused:', 'Total Toilets with Water:', 'Separate toilets for Girls:', 'Girls Separate Toilets used:', 'Girls Separate Toilets unused:', 'Girls Separate Toilets with Water:', 'Separate Toilets for Boys:', 'Boys Separate Toilets used:', 'Boys Separate Toilets unused:', 'Boys Separate Toilets with Water:', 'Toilets for Teachers:', 'Teachers Toilets used:', 'Teachers Toilets unused:', 'Teachers Toilets with Water:', 'Communal Toilets:', 'Communal Toilets used:', 'Communal Toilets unused:', 'Communal Toilets with Water:', 'School Toilets Type:', 'School Toilet Type Comments:', 'School Toilets Condition:', 'Not using Toilet Status:', 'Not using Toilet:', 'Other not using Toilet:', 'Toilet Students use:', 'Other Toilet Students use:', 'School Latrine Cleaner:', 'Student Hygiene Practice:', 'Student Hygiene Practice Comments:', 'Hand Washing Status:', 'Not Washing with Soap Reason:', 'Not Washing with Soap Other Reason:', 'Sanitary Napkins Access:', 'MHM Fund:', 'MHM Focal Teacher Status:', 'MHM Trainings:', 'Students Presence During Menstruation:', 'Sanitary Pads Disposal Place:', 'Other Sanitary Pads Disposal Place:', 'Child Club Status:', 'Chairperson Gender:', 'Secretary Gender:', 'Treasurer Gender:', 'Child Club Active Status:', 'Club in Wash Status:', 'Club Member Training Status:', 'School Water Status:', 'School Water Source:', 'Major Water Source:', 'Time to bring Water:', 'Availability of Drinking Water:', 'Adequacy of Water:', 'Safe Drinking Water Status:', 'Water Treatment Status:', 'Water Treatment Type:', 'Other Water Treatment Type:', 'Water Tested Status:', 'Water Test Result:', 'Special People Access to Water:', 'School Water Tank Availability:', 'Tank Size:', 'Total Water Points:', 'Tap for Drinking:', 'Tap for Washing:', 'Well used Points:', 'Partial Damaged Points:', 'Fully Damaged Points:', 'Unused Fully Damaged Points:', 'Water Quality Perception:', 'Points Observed Status:', 'Points with Condition Observed Status:', 'Drinking Water Access for All:', 'Source if No School Water:', 'Hand Washing Station:', 'Hand Washing Station using Condition:', 'Toilets Observed:', 'Safe Secure Toilets:', 'Soap Water Easy Access by Children for Toilet:', 'Door Lock Easy Access by Children:', 'Dustbin in Female Toilets:', 'Ramp Outside Toilet:', 'Sufficient Toilet Space Seat:', 'Toilets Comments:', 'School Facilities:', 'Urinal Bathroom Comments:', 'Male Urinal using Condition:', 'Male Urinal Clean condition:', 'Female Urinal using Condition:', 'Female Urinal Clean Condition:', 'Bathroom using Condition:', 'Bathroom Clean Condition:', 'Incinerator using Condition:', 'Incinerator Clean Condition:', 'School Hygiene Plan Status:', 'School Rating:', 'Skills Available:', 'Cleaned Regularly:', 'Availability of Drinking Water for Children:', 'Drainage System:', 'Handwashing with Soap:', 'Waste Dumped Status:', 'Waste Glass Status:', 'Waste Recycled Status:', 'Open Defecation Free Status:', 'Extra Activity in Vacant Land Status:', 'Hygiene Taught Status:', 'Class Five Status:', 'Students Actively Involved Status:', 'Risk Reduction Status:', 'Disaster Preparedness Status:', 'Risk Mapping Status:', 'Structure Constructed Criteria Status:', 'Teacher Provided Status:', 'Daily Cleaned Status:', 'Hygiene Corner Status:', 'Date:', 'Reusable Product Skill Status:', 'Hygiene Rating Status:', 'Coordination Committee Formed Status:', 'Disabled Student Teacher Status:', 'Physically Disabled Student:', 'Physically Disabled Teacher:', 'Blind Student:', 'Blind Teacher:', 'Student with Other Disability:', 'Teacher with Other Disability:', 'Female Staff:', 'Male Staff:', 'Other Staff:', 'Usable Hygenic Female toilet:', 'Usable Female Toilet without Hygiene:', 'Usable Toilet for Disabled:', 'Minor Toilet Repair:', 'Major Toilet Repair:', 'Reconstruction Needed Toilet:', 'Usable Separate Boy Handwashing Station:', 'Usable Separate Girl Handwashing Station:', 'Usable Communal Handwashing Station:', 'Usable Handwashing Station for Disabled:', 'Minor Handwashing Repair:', 'Major Handwashing Repair:', 'Reconstruction Needed Handwashing:', 'Soap Water Availability in Handwashing Station:', 'Fecal Contamination:', 'Priority Chemical Contamination:', 'Menstruation Related Education Status:', 'Incinerator Availability:', 'Incinerator Condition:', 'Sufficient Water Availability Status:', 'Water Purifier Availability:', 'Water Purifier Condition:', 'Working Taps for Disabled:', 'School Code:', 'Separate Male Urinal:', 'Separate Female Urinal:', 'Is Water Quality Tested:', 'Uploaded By:'];
                                var potential_sourcekey = [];                                                //Unserved Population
                                var unserved_communitykey = ['community_name', 'visit_date', 'ward', 'bc_hh', 'total_hh', 'janajati_hh', 'dalit_hh', 'madesi_hh', 'obc_hh', 'women_headed_hh', 'present_source', 'time_to_fetch_water', 'treatment_to_collected_water', 'latitude', 'longitude', 'elevation', 'point_description', 'source_name', 'type_of_source', 'lift_required', 'present_water_use', 'source_ownership', 'distance_from_community', 'round_trip_time', 'flow_measurement', 'minimum_yield', 'flow_regularity', 'water_quality', 'settlement_above_source', 'landslide_vulnerability', 'flood_vulnerability', 'drought_vulnerability', 'affected_by_climate', 'system_type', 'uploaded_by'];                                              //Unserved Population
                                var unserved_communitykeyDisplay = ['Community Name:', 'Visit Date:', 'Ward:', 'Brahmin/Chhetri HH:', 'Total HH:', 'Janajati HH:', 'Dalit HH:', 'Madesi HH:', 'OBC HH:', 'Women Headed HH:', 'Present Source:', 'Time to fetch Water:', 'Treatment to Collected Water:', 'Latitude:', 'Longitude:', 'Elevation:', 'Point Description:', 'Name of Source:', 'Type of Source:', 'Lift Required:', 'Present water Use:', 'Source Ownership:', 'Distance from Community:', 'Round Trip Time:', 'Flow Measurement:', 'Minimum Yield:', 'Flow Regularity:', 'Water Quality:', 'Settlement Above Source:', 'Landslide Vulnerability:', 'Flood Vulnerability:', 'Drought Vulnerability:', 'Affected by Climate:', 'System Type:', 'Uploaded By:'];
                                /*
                                 * 
                                 * Solid Wastes 
                                 */
                                //var benchmarkingkey = [];
                                var benchmarkingkey = ['benchmarking_collection_effectiveness', 'benchmarking_street_sweeping_effectiveness', 'benchmarking_tariff_level', 'description', 'lat', 'lon', 'ele', 'uploaded_date'];
                                var benchmarkingkeyDisplay = ['Benchmarking Collection Effectiveness:', 'Benchmarking Street Sweeping Effectiveness:', 'Benchmarking Tariff Level:', 'Description:', 'Latitude:', 'Longitude:', 'Elevation:', 'Uploaded Date:'];
                                var disposal_pointkey = [];
                                var route_pointkey = ['rp_route_no', 'description', 'lat', 'lon', 'ele', 'uploaded_date'];
                                var route_pointkeyDispaly = ['Route Point Route No:', 'Description:', 'Latitude:', 'Longitude:', 'Elevation:', 'Uploaded Date:'];
                                var skipskey = ['skip_type', 'description', 'lat', 'lon', 'ele', 'skip_volume', 'skip_schedule', 'skip_condition', 'skip_intvn_req', 'uploaded_date'];
                                var skipskeyDisplay = ['Skip Type:', 'Description:', 'Latitude:', 'Longitude:', 'Elevation:', 'Skip Volume:', 'Skip Schedule:', 'Skip Condition:', 'Skip Intvn Required:', 'Uploaded Date:'];
                                var street_sweepingkey = ['street_name', 'description', 'lat', 'lon', 'ele', 'street_frequency', 'street_condition', 'uploaded_date'];
                                var street_sweepingkeyDisplay = ['Street Name:', 'Description:', 'Latitude:', 'Longitude:', 'Elevation:', 'Street Frequency:', 'Street Condition:', 'Uploaded Date:'];
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
                                var urban_sanKey = ['visit_date', 'respondent_name', 'respondent_age', 'respondent_gender', 'ward', 'tole', 'respondent_contact_no', 'family_head_gender', 'total_family_members', 'family_type', 'household_type', 'other_household_type', 'house_purpose', 'average_expenditure', 'waterborne_diseases_status', 'waterborne_diseases', 'major_drinking_water_source', 'other_major_drinking_water_source', 'water_consumption_quantity', 'containment_lateral_distance', 'dry_ground_water_level_depth', 'wet_ground_water_level_depth', 'grey_water_connection', 'separate_system_for_wwm_status', 'expected_support_for_wwm', 'toilet_facilities', 'different_type_toilet_facilities', 'no_toilet_alternative', 'other_no_toilet_alternative', 'no_toilet_reason', 'other_no_toilet_reason', 'toilet_superstructure', 'num_of_people_using_toilet', 'toilet_connection', 'other_toilet_connection', 'containment_unit_connection', 'other_containment_unit_connection', 'septic_tank_compartments', 'sewer_chokes_overflow_status', 'annual_sewer_problems_num', 'containment_material', 'other_containment_material', 'pit_kind', 'faecal_sludge_reused_status', 'tank_or_pit_emptying_accessibility', 'lid_and_cover_condition', 'flooring_type_above_tank', 'other_flooring_type_above_tank', 'tank_length', 'tank_breadth', 'tank_depth', 'pit_diameter', 'pit_depth', 'containment_system_built', 'proper_septic_tank_investment', 'containment_emptying_accessibility', 'on_site_truck_parking', 'closest_parking_place_distance', 'elevation_difference', 'containment_unit_last_emptied', 'containment_not_emptied_reason', 'containment_emptied_reason', 'other_containment_emptied_reason', 'emptying_containment_period', 'emptying_service_provider', 'containment_emptied_process', 'mechanical_emptying_completeness_status', 'left_sludge_portion_in_feet', 'emptying_service_satisfaction', 'service_improving_ways', 'other_service_improving_ways', 'manual_emptying_reason', 'other_manual_emptying_reason', 'emptying_charge_per_trip', 'emptying_charge_calculation', 'other_emptying_charge_calculation', 'satisfied_with_emptying_cost', 'suggested_emptying_cost', 'willing_treatment_additional_charge', 'manual_emptying_disposal', 'other_manual_emptying_disposal', 'emptied_sludge_utilization', 'end_product_usage_perception', 'compost_expected_price', 'biogas_expected_price', 'treated_water_expected_price', 'solid_waste_mgmt', 'other_solid_waste_mgmt', 'hh_waste_segregation', 'hh_organic_solid_waste_mgmt', 'waste_collection_payment_status', 'waste_collection_charge_per_month', 'disabled_member_status', 'toilet_for_disabled', 'difficulties_using_toilet_for_disabled', 'hh_menstrual_waste_mgmt', 'waste_mgmt_responsibility', 'locality_sanitation_committee', 'committee_male_num', 'committee_female_num', 'committee_leading_gender', 'fsm_awareness_status', 'fsm_laws_awareness_status', 'fsm_laws_known', 'fsm_program_participation_status', 'septic_and_holding_tank_difference_known', 'runoff_water_connection', 'rainwater_collection_status', 'nominal_treatment_for_rainwater', 'rainwater_collection_container_size', 'unpaved_land_for_rainwater', 'place_for_groundwater_recharge', 'uploaded_date', 'uploaded_by', 'unique_code', 'fsm_program_participating_gender', 'other_grey_water_connection', 'other_expected_support_for_wwm', 'other_emptying_service_provider', 'other_hh_organic_solid_waste_mgmt', 'other_difficulties_using_toilet_for_disabled', 'other_hh_menstrual_waste_mgmt', 'other_runoff_water_connection', 'house_number', 'street_name', 'containment_dimension', 'other_containment_emptied_process'];

                                var wqpdkey = ['parameter_name', 'proj_name', 'point_type', 'sampling_time', 'lower_range', 'upper_range', 'pvalues', 'result_range'];
                                var wqpdkeyDisplay = ['Parameter Name:', 'Project Name:', 'Sampling Point:', 'Sampling Time:', 'Lower Range:', 'Upper Range:', 'Value:', 'Result Range:'];

                                var test_val = '';
                                if (event.features && event.features.length) {
                                    if (maxfeatures === 1) {
                                        var resultObj = event.features[0].properties;
                                        //console.log(resultObj);
                                        if (event.features[0].id.split('.')[0] === 'sanitation') {
                                            var array_key = sanitationkey;
                                        } else if (event.features[0].id.split('.')[0] === 'water_source') {
                                            var array_key = sourcekey;
                                            var array_key_display = sourcekeyDisplay;
                                        } else if (event.features[0].id.split('.')[0] === 'project_details') {
                                            var array_key = projectkey;
                                            var array_key_display = projectkeyDisplay;
                                        } else if (event.features[0].id.split('.')[0] === 'reservoir') {
                                            var array_key = reservoirkey;
                                            var array_key_display = reservoirkeyDisplay;
                                        } else if (event.features[0].id.split('.')[0] === 'pipe') {
                                            var array_key = pipekey;
                                            var array_key_display = pipekeyDisplay;
                                        } else if (event.features[0].id.split('.')[0] === 'junction') {
                                            var array_key = junctionkey;
                                            var array_key_display = junctionkeyDisplay;
                                        } else if (event.features[0].id.split('.')[0] === 'project_details_fun') {
                                            var array_key = [];
                                        } else if (event.features[0].id.split('.')[0] === 'project_details_sustain') {
                                            var array_key = [];
                                        //} else if (event.features[0].id.split('.')[0] === 'tap') {
                                        //    var array_key = tapkey;
                                            //    var array_key_display = tapkeyDisplay;
                                        } else if (event.features[0].id.split('.')[0] === 'nwash1_tap') {
                                            var array_key = tapkey;
                                            var array_key_display = tapkeyDisplay;
                                        } else if (event.features[0].id.split('.')[0] === 'structure') {
                                            var array_key = structurekey;
                                            var array_key_display = structurekeyDisplay;
                                        } else if (event.features[0].id.split('.')[0] === 'leftout_taps') {
                                            var array_key = leftouttapskey;
                                            var array_key_display = leftouttapskeyDisplay;
                                        } else if (event.features[0].id.split('.')[0] === 'pipedsystem_graph_data') {
                                            var array_key = pipedSystemkey;
                                            var array_key_display = pipedSystemkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'tbl_observed_locations') {            //community Sanitation
                                            var array_key = community_sanitationkey;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'health_care_facility') {
                                            var array_key = healthc_carekey;
                                            var array_key_display = healthc_carekeyDisplay;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'tbl_household') {
                                            var array_key = householdkey;
                                            var array_key_display = householdkeyDisplay;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'public_toilet') {
                                            var array_key = public_toiletkey;
                                            var array_key_display = public_toiletkeyDisplay;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'tbl_school') {
                                            var array_key = schoolkey;
                                            var array_key_display = schoolkeyDisplay;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'unserved_initial_details') {
                                            var array_key = unserved_communitykey;
                                            var array_key_display = unserved_communitykeyDisplay;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'potential_source') {
                                            var array_key = potential_sourcekey;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'benchmarking') {
                                            var array_key = benchmarkingkey;
                                            var array_key_display = benchmarkingkeyDisplay;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'disposal_point') {
                                            var array_key = disposal_pointkey;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'route_point') {
                                            var array_key = route_pointkey;
                                            var array_key_display = route_pointkeyDispaly;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'skips') {
                                            var array_key = skipskey;
                                            var array_key_display = skipskeyDisplay;
                                            test_val = 'wash';
                                        } else if (event.features[0].id.split('.')[0] === 'street_sweeping') {
                                            var array_key = street_sweepingkey;
                                            var array_key_display = street_sweepingkeyDisplay;
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
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Aluminium') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Ammonia') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Arsenic') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Cadmium') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Calcium') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Chloride') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Chromium') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Color') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Copper') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Cyanide') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Electrical_conductivity') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Faecal_coliform_ecoli') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Faecal_contamination') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Fluoride') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Iron') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Lead') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Manganese') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Mercury') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Nitrate') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Nitrites') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_pH') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Residual_Chlorine') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Sulphate') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Taste_odor') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Total_colifom') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Total_dissolved_solids') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Total_hardness') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Turbidity') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        } else if (event.features[0].id.split('.')[0] === 'wq_view_Zinc') {
                                            var array_key = wqpdkey;
                                            var array_key_display = wqpdkeyDisplay;
                                            test_val = 'wqpd';
                                        }

                                        var title = selectedLayer[0].get('name');
                                        //console.log(title);
                                        var html = '<table class=\"table table-condensed table-sm table-bordered table-striped\" style="margin-top:10px;font-size:14px">';

                                        if (event.features[0].id.split('.')[0] === 'project_details') {
                                            html += '<tr style="background:#366BD6;color:#fff;" id="title_sus"><td colspan="2"><strong>Info:: ' + title + '</strong></td></tr>';
                                            html += '<tr id="1_district"></tr>';
                                            html += '<tr id="1_muni"></tr>';
                                            html += '<tr id="1_pro_name"></tr>';
                                            html += '<tr id="1_project_code"></tr>';
                                            get_project_details(1, resultObj['uuid'], test_val);

                                        }
                                        if (array_key.length > 0) {
                                            html += '<tr style="background:#366BD6;color:#fff;"><td colspan="2"><strong>Info:: ' + title + '</strong></td></tr>';
                                            for (i = 0; i < array_key.length; i++) {
                                                if (array_key[i] === 'pro_uuid') {
                                                    //html += '<tr style="background:#366BD6;color:#fff;"><td colspan="2"><strong>Info:: ' + title + '</strong></td></tr>';
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
                                                        html += "<tr><td>" + check_dictionary(array_key_display[i]) + "</td><td>" + if_null(array_key[i], resultObj[array_key[i]]) + "</td></tr>";
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
                                                } else if (key == 'photo1_path_uuid') {
                                                } else if (key == 'photo2_path_uuid') {
                                                } else if (key == 'photo3_path_uuid') {
                                                } else if (key == 'photo4_path_uuid') {
                                                } else if (key == 'photo5_path_uuid') {
                                                } else if (key == 'photo6_path_uuid') {
                                                } else if (key == 'photo1_desc') {
                                                } else if (key == 'photo2_desc') {
                                                } else if (key == 'rvt_cons') {
                                                } else if (key == 'pipe_cons') {
                                                } else if (key == 'junc_type') {
                                                } else if (key == 'str_nrp') {
                                                } else if (key == 'str_cons') {
                                                } else if (key == 'photo_hcf1_uuid') {
                                                } else if (key == 'photo_hcf2_uuid') {
                                                } else if (key == 'photo_hcf3_uuid') {
                                                } else if (key == 'photo_water_station_1_uuid') {
                                                } else if (key == 'photo_water_tank_1_uuid') {
                                                } else if (key == 'photo_female_toilet_dustbin_1_uuid') {
                                                } else if (key == 'photo_female_toilet_1_uuid') {
                                                } else if (key == 'photo_female_toilet_2_uuid') {
                                                } else if (key == 'photo_toilet_ramp_1_uuid') {
                                                } else if (key == 'photo_hand_washing_station_toilet_1_uuid') {
                                                } else if (key == 'photo_hand_washing_station_opd_1_uuid') {
                                                } else if (key == 'photo_toilet_mdu_2_uuid') {
                                                } else if (key == 'photo_toilet_mdu_1_uuid') {
                                                } else if (key == 'province_code') {
                                                } else if (key == 'district_code') {
                                                } else if (key == 'muni_code') {
                                                } else if (key == 'upload_date') {
                                                } else if (key == 'school_photo_1_uuid') {
                                                } else if (key == 'school_photo_2_uuid') {
                                                } else if (key == 'school_photo_3_uuid') {
                                                } else if (key == 'water_point_photo_1_uuid') {
                                                } else if (key == 'water_point_photo_2_uuid') {
                                                } else if (key == 'station_photo_1_uuid') {
                                                } else if (key == 'station_photo_2_uuid') {
                                                } else if (key == 'toilet_photo_1_uuid') {
                                                } else if (key == 'urinal_photo_1_uuid') {
                                                } else if (key == 'photo_1_uuid') {
                                                } else if (key == 'photo_2_uuid') {
                                                } else if (key == 'photo_3_uuid') {
                                                } else if (key == 'photo_4_uuid') {
                                                } else if (key == 'photo_5_uuid') {
                                                } else if (key == 'photo_6_uuid') {
                                                } else {
                                                    if (resultObj.hasOwnProperty(key)) {
                                                        html += "<tr><td>" + check_dictionary(key) + "</td><td>" + if_null(key, resultObj[key]) + "</td></tr>";
                                                    }
                                                }
                                            }
                                        }
                                        html += "</table>";

                                        $("#identify-view-draggable").remove();
                                        //var il = '';
                                        var elem = '';

                                        elem = document.getElementById('popup-content');
                                        elem.innerHTML = '';

                                        overlay.setPosition(e.coordinate);


                                        elem.innerHTML += html;
                                        if (test_val != "wqpd") {
                                            var layer_photos = get_photos(event.features[0].id.split('.')[0], resultObj, elem);
                                        }

                                    } else if (maxfeatures > 1) {
                                        var main_html = '';
                                        var pipe_main_html = '';
                                        var sus_main_html = '';
                                        var r = 0;
                                        for (var im = 0; im < event.features.length; im++) {
                                            r = r + 1;
                                            var resultObj = event.features[im].properties;
                                            if (selectedLayer.length > 1) {

                                                if (event.features[im].id.split('.')[0] === 'project_details' && selectedLayer[0].getVisible()) {
                                                    ikey = 0;
                                                    var array_key = projectkey;
                                                    var array_key_display = projectkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'water_source' && selectedLayer[1].getVisible()) {
                                                    ikey = 1;
                                                    var array_key = sourcekey;
                                                    var array_key_display = sourcekeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'reservoir' && selectedLayer[2].getVisible()) {
                                                    ikey = 2;
                                                    var array_key = reservoirkey;
                                                    var array_key_display = reservoirkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'pipe' && selectedLayer[3].getVisible()) {
                                                    ikey = 3;
                                                    var array_key = pipekey;
                                                    var array_key_display = pipekeyDisplay;
                                                //} else if (event.features[im].id.split('.')[0] === 'tap' && selectedLayer[4].getVisible()) {
                                                //    ikey = 4;
                                                //    var array_key = tapkey;
                                                //    var array_key_display = tapkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'structure' && selectedLayer[4].getVisible()) {
                                                    ikey = 4;
                                                    var array_key = structurekey;
                                                    var array_key_display = structurekeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'junction' && selectedLayer[5].getVisible()) {
                                                    ikey = 5;
                                                    var array_key = junctionkey;
                                                    var array_key_display = junctionkeyDisplay;
                                                //} else if (event.features[im].id.split('.')[0] === 'project_details_fun' && selectedLayer[7].getVisible()) {
                                                //    ikey = 7;
                                                //    var array_key = [];
                                                //} else if (event.features[im].id.split('.')[0] === 'project_details_sustain' && selectedLayer[8].getVisible()) {
                                                //    ikey = 8;
                                                //    var array_key = [];
                                                //    //} else if (event.features[im].id.split('.')[0] === 'sanitation' && selectedLayer[9].getVisible()) {
                                                //    //    ikey = 9;
                                                //    //    var array_key = sanitationkey;
                                                } else if (event.features[im].id.split('.')[0] === 'leftout_taps' && selectedLayer[6].getVisible()) {
                                                    ikey = 6;
                                                    var array_key = leftouttapskey;
                                                    var array_key_display = leftouttapskeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'nwash1_tap' && selectedLayer[7].getVisible()) {
                                                    ikey = 7;
                                                    var array_key = tapkey;
                                                    var array_key_display = tapkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'nwash1_tap' && selectedLayer[8].getVisible()) {
                                                    ikey = 8;
                                                    var array_key = tapkey;
                                                    var array_key_display = tapkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'nwash1_tap' && selectedLayer[9].getVisible()) {
                                                    ikey = 9;
                                                    var array_key = tapkey;
                                                    var array_key_display = tapkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'tbl_observed_locations' && selectedLayer[0].getVisible()) {
                                                    ikey = 0;
                                                    var array_key = community_sanitationkey;
                                                } else if (event.features[im].id.split('.')[0] === 'health_care_facility' && selectedLayer[1].getVisible()) {
                                                    ikey = 1;
                                                    var array_key = healthc_carekey;
                                                    var array_key_display = healthc_carekeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'tbl_household' && selectedLayer[2].getVisible()) {
                                                    ikey = 2;
                                                    var array_key = householdkey;
                                                    var array_key_display = householdkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'public_toilet' && selectedLayer[3].getVisible()) {
                                                    ikey = 3;
                                                    var array_key = public_toiletkey;
                                                    var array_key_display = public_toiletkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'tbl_school' && selectedLayer[4].getVisible()) {
                                                    ikey = 4;
                                                    var array_key = schoolkey;
                                                    var array_key_display = schoolkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'unserved_initial_details' && selectedLayer[5].getVisible()) {
                                                    ikey = 5;
                                                    var array_key = unserved_communitykey;
                                                    var array_key_display = unserved_communitykeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'potential_source' && selectedLayer[6].getVisible()) {
                                                    ikey = 6;
                                                    var array_key = potential_sourcekey;
                                                } else if (event.features[im].id.split('.')[0] === 'benchmarking' && selectedLayer[7].getVisible()) {
                                                    ikey = 7;
                                                    var array_key = benchmarkingkey;
                                                    var array_key_display = benchmarkingkeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'disposal_point' && selectedLayer[8].getVisible()) {
                                                    ikey = 8;
                                                    var array_key = disposal_pointkey;
                                                } else if (event.features[im].id.split('.')[0] === 'route_point' && selectedLayer[9].getVisible()) {
                                                    ikey = 9;
                                                    var array_key = route_pointkey;
                                                    var array_key_display = route_pointkeyDispaly;
                                                } else if (event.features[im].id.split('.')[0] === 'skips' && selectedLayer[10].getVisible()) {
                                                    ikey = 10;
                                                    var array_key = skipskey;
                                                    var array_key_display = skipskeyDisplay;
                                                } else if (event.features[im].id.split('.')[0] === 'street_sweeping' && selectedLayer[11].getVisible()) {
                                                    ikey = 11;
                                                    var array_key = street_sweepingkey;
                                                    var array_key_display = street_sweepingkeyDisplay;
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
                                                else if (event.features[im].id.split('.')[0] === 'wq_view_Aluminium' && selectedLayer[0].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 0;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Ammonia' && selectedLayer[1].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 1;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Arsenic' && selectedLayer[2].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 2;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Cadmium' && selectedLayer[3].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 3;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Calcium' && selectedLayer[4].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 4;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Chloride' && selectedLayer[5].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 5;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Chromium' && selectedLayer[6].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 6;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Color' && selectedLayer[7].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 7;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Copper' && selectedLayer[8].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 8;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Cyanide' && selectedLayer[9].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 9;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Electrical_conductivity' && selectedLayer[10].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 10;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Faecal_coliform_ecoli' && selectedLayer[11].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 11;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Faecal_contamination' && selectedLayer[12].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 12;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Fluoride' && selectedLayer[13].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 13;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Iron' && selectedLayer[14].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 14;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Lead' && selectedLayer[15].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 15;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Manganese' && selectedLayer[16].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 16;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Mercury' && selectedLayer[17].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 17;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Nitrate' && selectedLayer[18].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 18;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Nitrites' && selectedLayer[19].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 19;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_pH' && selectedLayer[20].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 20;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Residual_Chlorine' && selectedLayer[21].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 21;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Sulphate' && selectedLayer[22].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 22;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Taste_odor' && selectedLayer[23].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 23;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Total_colifom' && selectedLayer[24].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 24;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Total_dissolved_solids' && selectedLayer[25].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 25;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Total_hardness' && selectedLayer[26].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 26;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Turbidity' && selectedLayer[27].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 27;
                                                } else if (event.features[im].id.split('.')[0] === 'wq_view_Zinc' && selectedLayer[28].getVisible()) {
                                                    var array_key = wqpdkey;
                                                    var array_key_display = wqpdkeyDisplay;
                                                    test_val = 'wqpd';
                                                    ikey = 28;
                                                }
                                            } else {
                                                ikey = 0;
                                            }
                                            if (event.features[im].id.split('.')[0] === 'pipe') {
                                                var pipe_html = "<table class=\"table table-condensed table-sm table-bordered table-striped\" style=\"font-size: 14px\">";

                                                if (array_key.length > 0) {
                                                    for (i = 0; i < array_key.length; i++) {
                                                        if (array_key[i] === 'pro_uuid') {
                                                            //pipe_html += '<tr style="background:#366BD6;color:#fff;" id="title_sus"><td colspan="2"><strong>Info1:: ' + title + '</strong></td></tr>';
                                                            pipe_html += '<tr id="' + r + '_district"></tr>';
                                                            pipe_html += '<tr id="' + r + '_muni"></tr>';
                                                            pipe_html += '<tr id="' + r + '_pro_name"></tr>';
                                                            pipe_html += '<tr id="' + r + '_project_code"></tr>';
                                                            get_project_details(r, resultObj[array_key[i]], test_val);
                                                        } else {
                                                            if (resultObj.hasOwnProperty(array_key[i])) {
                                                                pipe_html += "<tr><td>" + check_dictionary(array_key_display[i]) + "</td><td>" + if_null(array_key[i], resultObj[array_key[i]]) + "</td></tr>";
                                                                //alert(key + " -> " + resultObj[key]);
                                                            }
                                                        }
                                                    }
                                                } else {
                                                    for (var key in resultObj) {
                                                        if (key == 'pro_uuid') {
                                                            //pipe_html += '<tr style="background:#366BD6;color:#fff;" id="title_sus"><td colspan="2"><strong>Info2:: ' + title + '</strong></td></tr>';
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
                                                        } else if (key == 'photo1_path_uuid') {
                                                        } else if (key == 'photo2_path_uuid') {
                                                        } else if (key == 'photo3_path_uuid') {
                                                        } else if (key == 'photo4_path_uuid') {
                                                        } else if (key == 'photo5_path_uuid') {
                                                        } else if (key == 'photo6_path_uuid') {
                                                        } else if (key == 'photo1_desc') {
                                                        } else if (key == 'photo2_desc') {
                                                        } else if (key == 'rvt_cons') {
                                                        } else if (key == 'pipe_cons') {
                                                        } else if (key == 'photo_hcf1_uuid') {
                                                        } else if (key == 'photo_hcf2_uuid') {
                                                        } else if (key == 'photo_hcf3_uuid') {
                                                        } else if (key == 'photo_water_station_1_uuid') {
                                                        } else if (key == 'photo_water_tank_1_uuid') {
                                                        } else if (key == 'photo_female_toilet_dustbin_1_uuid') {
                                                        } else if (key == 'photo_female_toilet_1_uuid') {
                                                        } else if (key == 'photo_female_toilet_2_uuid') {
                                                        } else if (key == 'photo_toilet_ramp_1_uuid') {
                                                        } else if (key == 'photo_hand_washing_station_toilet_1_uuid') {
                                                        } else if (key == 'photo_hand_washing_station_opd_1_uuid') {
                                                        } else if (key == 'photo_toilet_mdu_2_uuid') {
                                                        } else if (key == 'photo_toilet_mdu_1_uuid') {
                                                        } else if (key == 'province_code') {
                                                        } else if (key == 'district_code') {
                                                        } else if (key == 'muni_code') {
                                                        } else if (key == 'upload_date') {
                                                        } else if (key == 'school_photo_1_uuid') {
                                                        } else if (key == 'school_photo_2_uuid') {
                                                        } else if (key == 'school_photo_3_uuid') {
                                                        } else if (key == 'water_point_photo_1_uuid') {
                                                        } else if (key == 'water_point_photo_2_uuid') {
                                                        } else if (key == 'station_photo_1_uuid') {
                                                        } else if (key == 'station_photo_2_uuid') {
                                                        } else if (key == 'toilet_photo_1_uuid') {
                                                        } else if (key == 'urinal_photo_1_uuid') {
                                                        } else if (key == 'photo_1_uuid') {
                                                        } else if (key == 'photo_2_uuid') {
                                                        } else if (key == 'photo_3_uuid') {
                                                        } else if (key == 'photo_4_uuid') {
                                                        } else if (key == 'photo_5_uuid') {
                                                        } else if (key == 'photo_6_uuid') {
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
                                                pipe_main_html += '<div style="background:#366BD6;padding:1px;color:white;margin-bottom:5px" id="' + event.features[im].id.split('.')[1] + '" class="identi"><h5>Info: ' + title + '</h5></div><div style="padding:0px 0px !important;" id="' + event.features[im].id.split('.')[1] + '_s">' + pipe_html + '<br>' + photos + '</div>';
                                            } else {
                                                var html = "<table class=\"table table-condensed table-sm table-bordered table-striped\" style=\"font-size: 14px\">";
                                                if (event.features[im].id.split('.')[0] === 'project_details') {
                                                    html += '<tr id="' + r + '_district"></tr>';
                                                    html += '<tr id="' + r + '_muni"></tr>';
                                                    html += '<tr id="' + r + '_pro_name"></tr>';
                                                    html += '<tr id="' + r + '_project_code"></tr>';
                                                    get_project_details(r, resultObj['uuid'], test_val);
                                                }
                                                if (typeof array_key !== 'undefined' && array_key.length > 0) {
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
                                                                html += "<tr><td>" + check_dictionary(array_key_display[i]) + "</td><td>" + if_null(array_key[i], resultObj[array_key[i]]) + "</td></tr>";
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
                                                        } else if (key == 'photo1_path_uuid') {
                                                        } else if (key == 'photo2_path_uuid') {
                                                        } else if (key == 'photo3_path_uuid') {
                                                        } else if (key == 'photo4_path_uuid') {
                                                        } else if (key == 'photo5_path_uuid') {
                                                        } else if (key == 'photo6_path_uuid') {
                                                        } else if (key == 'photo1_desc') {
                                                        } else if (key == 'photo2_desc') {
                                                        } else if (key == 'rvt_cons') {
                                                        } else if (key == 'junc_type') {
                                                        } else if (key == 'str_nrp') {
                                                        } else if (key == 'str_cons') {
                                                        } else if (key == 'photo_hcf1_uuid') {
                                                        } else if (key == 'photo_hcf2_uuid') {
                                                        } else if (key == 'photo_hcf3_uuid') {
                                                        } else if (key == 'photo_water_station_1_uuid') {
                                                        } else if (key == 'photo_water_tank_1_uuid') {
                                                        } else if (key == 'photo_female_toilet_dustbin_1_uuid') {
                                                        } else if (key == 'photo_female_toilet_1_uuid') {
                                                        } else if (key == 'photo_female_toilet_2_uuid') {
                                                        } else if (key == 'photo_toilet_ramp_1_uuid') {
                                                        } else if (key == 'photo_hand_washing_station_toilet_1_uuid') {
                                                        } else if (key == 'photo_hand_washing_station_opd_1_uuid') {
                                                        } else if (key == 'photo_toilet_mdu_2_uuid') {
                                                        } else if (key == 'photo_toilet_mdu_1_uuid') {
                                                        } else if (key == 'province_code') {
                                                        } else if (key == 'district_code') {
                                                        } else if (key == 'muni_code') {
                                                        } else if (key == 'upload_date') {
                                                        } else if (key == 'school_photo_1_uuid') {
                                                        } else if (key == 'school_photo_2_uuid') {
                                                        } else if (key == 'school_photo_3_uuid') {
                                                        } else if (key == 'water_point_photo_1_uuid') {
                                                        } else if (key == 'water_point_photo_2_uuid') {
                                                        } else if (key == 'station_photo_1_uuid') {
                                                        } else if (key == 'station_photo_2_uuid') {
                                                        } else if (key == 'toilet_photo_1_uuid') {
                                                        } else if (key == 'urinal_photo_1_uuid') {
                                                        } else if (key == 'photo_1_uuid') {
                                                        } else if (key == 'photo_2_uuid') {
                                                        } else if (key == 'photo_3_uuid') {
                                                        } else if (key == 'photo_4_uuid') {
                                                        } else if (key == 'photo_5_uuid') {
                                                        } else if (key == 'photo_6_uuid') {
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
                                                if (title === "Yard Tap" || title === "Community Tap" || title === "Institutional Tap") {
                                                    title = "Tap";
                                                }
                                                //getLinkCodeData(linkcode,layer,event);

                                                if (event.features[im].id.split('.')[0] === 'tbl_urban_sanitation') {
                                                    var photos = get_urban_san_photos(event.features[im].id.split('.')[0], resultObj, title);
                                                } else {
                                                    var photos = get_all_photos(event.features[im].id.split('.')[0], resultObj, title);
                                                }
                                                var sus_html = '';
                                                //if (event.features[im].id.split('.')[0] === 'project_details') {
                                                //    sus_html += '<table class=\"table table-condensed\" id="' + r + '_table_sus">';
                                                //    sus_html += '<tr style="background:#F6BB42;color:#fff;" id="title_sus"><td colspan="2"><strong>Project Sustainability</strong></td></tr>';
                                                //    for (var isus = 0; isus < sus_len; isus++) {
                                                //        sus_html += '<tr style="background:#e7e7e7;" id="' + r + '_tr_fiscal_year_' + isus + '"><td><strong>Fiscal Year : </strong></td><td id="' + r + '_fiscal_year_' + isus + '"></td></tr>';
                                                //        sus_html += '<tr id="' + r + '_tr_wua_name_' + isus + '"><td><strong>Community Name : </strong></td><td id="' + r + '_wua_name_' + isus + '"></td></tr>';
                                                //        sus_html += '<tr id="' + r + '_tr_wua_date_' + isus + '"><td><strong>Community Formation Date: </strong></td><td id="' + r + '_wua_date_' + isus + '"></td></tr>';
                                                //        sus_html += '<tr id="' + r + '_tr_wua_address_' + isus + '"><td><strong>Address : </strong></td><td id="' + r + '_wua_address_' + isus + '"></td></tr>';
                                                //        sus_html += '<tr id="' + r + '_tr_wua_phone_' + isus + '"><td><strong>Phone No : </strong></td><td id="' + r + '_wua_phone_' + isus + '"></td></tr>';
                                                //        sus_html += '<tr id="' + r + '_tr_wua_email_' + isus + '"><td><strong>Email : </strong></td><td id="' + r + '_wua_email_' + isus + '"></td></tr>';
                                                //        sus_html += '<tr id="' + r + '_tr_add_by_' + isus + '"><td><strong>Added By : </strong></td><td id="' + r + '_add_by_' + isus + '"></td></tr>';
                                                //        sus_html += '<tr id="' + r + '_tr_add_date_' + isus + '"><td><strong>Added Date : </strong></td><td id="' + r + '_add_date_' + isus + '"></td></tr>';
                                                //        sus_html += '<tr id="' + r + '_tr_view_all_' + isus + '"><td colspan="2" id="' + r + '_view_all_' + isus + '"></td></tr>';
                                                //    }
                                                //    get_sustain_data(r, resultObj['uuid']);
                                                //    sus_html += '</table>';
                                                //}
                                                main_html += '<div style="background:#366BD6;padding:1px;color:white;margin-bottom:5px" id="' + event.features[im].id.split('.')[1] + '" class="identi"><h5>Info: ' + title + '</h5></div><div style="padding:0px 0px !important;" id="' + event.features[im].id.split('.')[1] + '_s">' + html + '<br>' + photos + '<br>' + sus_html + '</div>';
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
                }
            });
        });
    };
    this.selectIdentifyLayer = function () {
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
    this.selectAllIdentifyLayer = function () {
        filt = '';
        var this_project = $('#this_project_only').is(":checked");
        identifyToolHelper.hideIdentifyTool()
        maxfeatures = 10;
        var layerNames = ["Water Supply Projects", "Source", "Reservoir", "Pipe", "Structure", "Junction", "LeftoutTaps", "Yard Tap", "Community Tap", "Institutional Tap"];
        //var layerNames = ["Water Supply Projects", "Source", "Reservoir", "Pipe", "Tap", "Structure", "Junction", "Functionality Framework", "Sustainability Framework", "Sanitation","LeftoutTaps"];
        this.tool.layers = new Array();
        selectedLayer = new Array();
        layersArray = map.getLayers();
        var j = 0;
        //        for (i = 0; i < layersArray.length; i++)
        //        {
        map.getLayers().forEach(function (layer) {
            if (layerNames.inArray(layer.get('name'))) {
                this.identifyLayer = layer;
                selectedLayer.push(layer);
            } else {
                //$("#id_"+layersArray[i].id).prop("class","identifybuttonicon");
            }
        });


    };
    this.selectWashDataLayers = function () {
        filt = '';
        var this_project = $('#this_project_only').is(":checked");
        identifyToolHelper.hideIdentifyTool()
        maxfeatures = 12;
        var layerNames = ["Community Sanitation", "Health Care Facility", "Household", "Public Toilet", "Schools", "Unserved Population", "Potential Source", "Benchmarking", "Disposal Point", "Route Point", "Skips", "Street Sweeping", "Drainage Point", "Flood Benchmarking", "Manhole", "Outfall", "Rain Inlet", "Sanitation Benchmarking", "CWIS Urban Sanitation"];
        this.tool.layers = new Array();
        selectedLayer = new Array();
        layersArray = map.layers;
        var j = 0;
        map.getLayers().forEach(function (layer) {
            if (layerNames.inArray(layer.get('name'))) {

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

            } else {

            }
        });
    };
    this.selectWaterQualityLayers = function () {
        filt = '';
        var this_project = $('#this_project_only').is(":checked");
        identifyToolHelper.hideIdentifyTool()
        maxfeatures = 12;
        var layerNames = ["Aluminium", "Ammonia", "Arsenic", "Cadmium", "Calcium", "Chloride", "Chromium", "Color", "Copper", "Cyanide", "Electrical Conductivity", "Faecal Coliform EColi", "Faecal Contamination", "Fluoride", "Iron", "Lead", "Manganese", "Mercury", "Nitrate", "Nitrites", "pH", "Residual Chlorine", "Sulphate", "Taste and Odor", "Total Colifom", "Total Dissolved Solids", "Total Hardness", "Turbidity", "Zinc"];
        this.tool.layers = new Array();
        selectedLayer = new Array();
        layersArray = map.layers;
        var j = 0;
        map.getLayers().forEach(function (layer) {
            if (layerNames.inArray(layer.get('name'))) {

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
            } else {

            }
        });
    };

    Array.prototype.inArray = function (value) {
        var i;
        for (i = 0; i < this.length; i++) {
            if (this[i] == value) {
                return true;
            }
        }
        return false;
    };
    this.showIdentifyTool = function () {
        $("#identify-draggable").show();
        $("#identify-tool").attr("class", "identify-active");
    };
    this.hideIdentifyTool = function () {
        $("#identify-draggable").hide();
        $("#identify-tool").attr("class", "identify");
        map.removeInteraction(this.tool);
        //this.tool.deactivate();
    }

    this.activateIdentifyLayer = function () {
        var layerName = $("#identify_select").val();
        if (layerName == "") {
            this.identifyLayer = "";
            alert("Please Select Identify Layer");
            return;
        }

        Tools.deactivateAllTools();
        this.tool.activate();
        $('#mapDiv').css('cursor', this.cursor);
    };
    this.showAllIdentifyLayers = function () {
        var html = '<option value="">Select Identify Layer</option>';
        var layer_group_labels = ["Basemap", "Road Network", "Water Supply Projects", "Wash Plan SDG"];
        var layer_groups = [basemap, lrnGroup, wspGroup, wpsdgGroup];
        for (var i = 0; i < layer_groups.length; i++) {
            var current_group = layer_groups[i];
            var layers = current_group.getLayers();
            html += "<optgroup label=\"" + layer_group_labels[i] + "\">";
            for (var j = 0; j < layers.length; j++) {
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



function zoomToExtent() {
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
    show: function () {
        $("#division-draggable").show();
        $("#division-tool").attr("class", 'goto-division-active');
    },
    hide: function () {
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
    goto_province: function (province, type) {
        if (province) {
            if (type === 'clip') {
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

        } else {
            alert("Please Select District");
            province_mask.setVisible(false);
        }
    },
    goto_district: function (dcode, type) {
        if (dcode) {
            if (type === 'clip') {
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
        } else {
            alert("Please Select District");
            district_mask.setVisible(false);
        }
    },
    goto_municipality: function (muni, type) {
        if (muni) {
            if (type === 'clip') {
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
        } else {
            alert("Please Select Municipality");
            muni_mask.setVisible(false);
            //muni_mask.setVisible(false);
        }
    }

}
function get_all_photos(layer, resultObj, title) {
    var photo_url = "/Inv/";
    var arr = {};
    arr.reservoir = ['photo1_path_uuid', 'photo2_path_uuid'];
    arr.nwash1_tap = ['photo1_path_uuid', 'photo2_path_uuid'];
    arr.water_source = ['photo1_path_uuid', 'photo2_path_uuid', 'photo3_path_uuid'];
    arr.project_details = ['photo1_path_uuid', 'photo2_path_uuid', 'photo3_path_uuid'];
    arr.pipe = ['photo1_path_uuid', 'photo2_path_uuid'];
    arr.structure = ['photo1_path_uuid', 'photo2_path_uuid'];
    arr.sanitation = ['photo1_path_uuid', 'photo2_path_uuid'];
    arr.leftout_taps = ['photo_path_uuid'];
    arr.junction = ['photo1_path_uuid', 'photo2_path_uuid'];

    if (layer == 'unserved_initial_details') {
        photo_url = "/Unserved/";
    }
    if (layer == 'public_toilet') {
        photo_url = "/PT/";
    }
    if (layer == 'tbl_school') {
        photo_url = "/Skl/";
    }

    arr.unserved_initial_details = ['unserved_photo_1_uuid', 'unserved_photo_2_uuid', 'potential_photo_1_uuid', 'potential_photo_2_uuid'];
    arr.public_toilet = ['image1_uuid', 'image2_uuid', 'image3_uuid'];
    arr.tbl_school = ['wq_report_photo_uuid'];
    arr.benchmarking = ['benchmarking_photo1_uuid', 'benchmarking_photo2_uuid'];
    arr.route_point = ['rp_photo1_uuid'];
    arr.skips = ['skip_photo1_uuid', 'skip_photo2_uuid'];
    arr.street_sweeping = ['street_photo1_uuid', 'street_photo2_uuid'];
    var has_photos = '';
    //    var photos_html = "<table>";
    //    photos_html += '<tr><th colspan="2">Photos:</th></tr>';
    var photos_html = '<table class=\"table table-condensed\" style="margin-top:10px;font-size:14px">';
    photos_html += '<tr style="background:#37D166 ;color:#fff;" id="title_sus"><td colspan="2"><strong>Photos</strong></td></tr>';
    for (var key in resultObj) {
        if (resultObj[key] != null) {
            if (inArray(key, arr[layer])) {
                var photo = resultObj[key];
                if (photo != null && photo != "") {
                    var directorypath = photo[0] + "/" + photo[1] + "/" + photo[2] + "/";
                    has_photos = 'yes';
                    photos_html += '<tr><td><button onclick="load_pop_image(\'' + photo + '\',\'' + layer + '\')"><img src="' + photo_url + directorypath + photo + '" width="150px" /></button>' + "</td></tr>";
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

function get_urban_san_photos(layer, resultObj, title) {
    //var photo_url = "https://nwash.training.softwel.com.np/images/urban_sanitation/";
    var photo_url = "/UrbanSan/";
    var arr = {};
    arr.tbl_urban_sanitation = ['photo_1_uuid', 'photo_2_uuid', 'photo_3_uuid', 'photo_4_uuid'];
    var has_photos = '';
    //    var photos_html = "<table>";
    //    photos_html += '<tr><th colspan="2">Photos:</th></tr>';
    var photos_html = '<table class=\"table table-condensed\" style="margin-top:10px;font-size:14px">';
    photos_html += '<tr style="background:#37D166 ;color:#fff;" id="title_sus"><td colspan="2"><strong>Photos</strong></td></tr>';
    for (var key in resultObj) {
        if (resultObj[key] != null) {
            if (inArray(key, arr[layer])) {
                var photo = resultObj[key];
                if (photo != null && photo != "") {
                    var directorypath = photo[0] + "/" + photo[1] + "/" + photo[2] + "/";
                    console.log(directorypath);
                    has_photos = 'yes';
                    photos_html += '<tr><td><button onclick="load_pop_urban_san_image(\'' + photo + '\')"><img src="' + photo_url + directorypath + photo + '" width="150px" /></button>' + "</td></tr>";
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

function get_photos(layer, resultObj, elem) {
    //var photo_url = "https://nwash.training.softwel.com.np/" + "images/Inventory/";
    var photo_url = "/Inv/";
    var arr = {};
    arr.reservoir = ['photo1_path_uuid', 'photo2_path_uuid'];
    arr.tap = ['photo1_path_uuid', 'photo2_path_uuid'];
    arr.water_source = ['photo1_path_uuid', 'photo2_path_uuid', 'photo3_path_uuid'];
    arr.project_details = ['photo1_path_uuid', 'photo2_path_uuid', 'photo3_path_uuid'];
    arr.pipe = ['photo1_path_uuid', 'photo2_path_uuid'];
    arr.structure = ['photo1_path_uuid', 'photo2_path_uuid'];
    arr.sanitation = ['photo1_path_uuid', 'photo2_path_uuid'];
    //var photos_html = "<table>";
    //photos_html += '<tr><th colspan="2">Photos:</th></tr>';
    var photos_html = '<table class=\"table table-condensed\" style="margin-top:10px;font-size:14px">';
    photos_html += '<tr style="background:#37D166 ;color:#fff;" id="title_sus"><td colspan="2"><strong>Photos</strong></td></tr>';
    for (var key in resultObj) {
        if (resultObj[key] != null) {
            if (inArray(key, arr[layer])) {
                var photo = resultObj[key];
                if (photo != null) {
                    var directorypath = photo[0] + "/" + photo[1] + "/" + photo[2] + "/";
                    photos_html += '<tr><td><a target="_blank" href="' + photo_url + directorypath + photo + '" class="bridge-photo" rel="bridge-photo"><img src="' + photo_url + directorypath + photo + '" width="150px" /></a>' + "</td></tr>";
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
            data: { 'proUuid': pro_uuid },
            dataType: 'json',
            success: function (data) {
                //console.log(data);
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
        url: '/data/get_sustain_details',
        data: { 'pro_uuid': pro_uuid, [csrfName]: csrfHash },
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
        url: '/data/get_sustain_details',
        data: { 'pro_uuid': pro_uuid, [csrfName]: csrfHash },
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
    record_screen_extent: function () {
        if (!this.is_using_history_tool) {
            var extent = map.getView().calculateExtent();
            //            var extent = map.getExtent();
            if (extent != null) {
                if (this.arr.length == this.maxSize) {
                    this.arr.shift()
                    //this.index--;
                } else {
                    this.index++;
                }
                this.currentIndex = this.index;
                this.arr[this.currentIndex] = extent;
            } else {
                if (this.first_render) {
                    this.index++;
                    this.currentIndex = this.index;
                    this.arr[this.currentIndex] = [8912260.091133313, 3042341.524138276, 9818849.801192472, 3561365.8324687113];
                    //this.arr[this.currentIndex] = new OpenLayers.Bounds(8912260.091133313, 3042341.524138276, 9818849.801192472, 3561365.8324687113);
                    this.first_render = false;
                }
            }
        } else {
            this.is_using_history_tool = false;
        }
    },
    goto_previous_extent: function () {
        if (this.currentIndex > 0) {
            //console.log(this.currentIndex);
            this.currentIndex--;
            this.is_using_history_tool = true;
            map.getView().fit(this.arr[this.currentIndex]);
            //map.zoomToExtent(this.arr[this.currentIndex], true);
        }

    },
    goto_next_extent: function () {
        if (this.currentIndex < this.index) {
            this.currentIndex++;
            this.is_using_history_tool = true;
            map.getView().fit(this.arr[this.currentIndex]);
            //map.zoomToExtent(this.arr[this.currentIndex], true);
        }

    }

}

//</editor-fold>

Tools.goto_project = function (pro_uuid) {
    var this_project = $('#this_project_only').is(":checked");
    var selected_project_uuid = cql_pro_uuid = $("#select_project").val();
    //console.log(selected_project_uuid);
    var url = "Map/GetProjectExtent/";
    $.ajax({
        type: "POST",
        url: url,
        data: { 'proUuid': selected_project_uuid },
        dataType: 'json',
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

Tools.goto_taps = function (pro_uuid) {

    var selected_tap_uuid = cql_tap_uuid = $("#select_tap").val();
    var url = "Map/GetTapExtents/";
    $.ajax({
        type: "POST",
        url: url,
        data: { 'tapUuid': selected_tap_uuid },
        dataType: 'json',
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

Tools.edit_project = function (pro_uuid) {
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
    show: function () {
        $('#mapDiv').css('cursor', 'default');
        Tools.deactivateAllTools();
        activate = true;
        $("#distance-draggable").show();
        $("#distance-draggable").attr("class", 'goto-distance-active');
    },
    deactivate: function () {
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
    clear: function () {
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
    show: function () {
        $("#newsource-draggable").show();
        $("#newsource-tool").attr("class", 'new-source-active');
    },
    hide: function () {
        $("#newsource-draggable").hide();
        $("#newsource-tool").attr("class", 'new-source');
    },
    goto_project: function (pro_uuid) {
        var selected_source_uuid = $("#select_newsource").val();
        var url = baseurl + "map/get_new_source_extent/" + selected_source_uuid;
        $.ajax(
            {
                type: "POST",
                url: url,
                data: { [csrfName]: csrfHash },
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
    edit_project: function (pro_uuid) {
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





