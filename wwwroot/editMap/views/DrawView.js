//translate feature
//http://openlayers.org/en/v3.9.0/examples/translate-features.html?q=select
/**
 *shprabin@gmail.com
 *17th Sep,2015
 *kakshyapati@gmail.com
 *2020
 *
 */
var i = 0;
var app = app || {};
var features;
var coo;
//var delete_vertex_check = 0;
var _this;
var selectedLayer = "";
var selectedLayerType = "";
var selectedLayerDetail;
var identifyStatus = false;
var identifiedLayerName = '';
var mmap;
var propertyList = document.getElementById('propertyList');
var _ccid = null;
var _ccFeature = null;
var lineDrawn = false;
var pointDrawn = false;
//var add_vertex_check = 0;
//var baseLayerType;
//var gmap;


app.DrawView = Backbone.View.extend({
    el: '#appdiv',
    map: null,
    drawFeature: null,
    events: {
        'click #hh': 'drawPointHandler',
        'click #add_point': 'drawPointHandler', //add point
        'click #move_house': 'movePointHandler', //move point
        'click #road': 'drawLineHandler',        //add line   
        'click #move_vertex': 'moveLineVertexHandler',  //move line vertex
        'click #add_road_vertex': 'addLineVertexHandler', //add line vertex
        'click #delete_road_vertex': 'deleteLineVertexHandler', //delete line vertex
        'click #add_polygon': 'drawPolygonHandler',       //add polygon
        'click #save_btn': 'saveData',
        'click #refresh_btn': 'refreshData',
        'click .layer-checkbox': 'checkboxToggled',
        'change .edit-radio': 'editToggled',
        'click #photo1': 'showPhoto1',
        'click #photo2': 'showPhoto2',
        'change #baseLayerType': 'changeBaseLayer',
        'click #edit-identify-id': 'identifyLayer',
        'click #refresh_edit': 'refreshData',
        'click #clear_edit': 'clearData'
    },
    layer_template: _.template($("#layer-template").html()),
    initialize: function () {
        this.raster = new ol.layer.Tile({
            preload: Infinity,
            source: new ol.source.BingMaps({
                key: 'AuzAZ5dpuR6OxpUPx2mUBezeWtt_V26O2s0JVAG3WoDKaN-IRLeJEP1AnNtcUZ6e',
                //key: 'Atn3I2g5CTaX_q8BKW4eOXco3GP9bkM7qhxrNRM-OJ0lesj3v7KFA3bRgO_YgG8x',
                imagerySet: 'Aerial',
                // use maxZoom 19 to see stretched tiles instead of the BingMaps
                // "no photos at this zoom level" tiles
                 //maxZoom: 10
            })
        });
        gmap = new google.maps.Map(document.getElementById('gmap'), {
            disableDefaultUI: true,
            keyboardShortcuts: false,
            draggable: false,
            disableDoubleClickZoom: true,
            scrollwheel: false,
            streetViewControl: false,
            //mapTypeId: "roadmap"
            mapTypeId: google.maps.MapTypeId.SATELLITE
        });
        this.elevator = new google.maps.ElevationService;

        var view = new ol.View({
            // make sure the view doesn't go beyond the 22 zoom levels of Google Maps
            maxZoom: 19,
        });
        view.on('change:center', function () {

            var center = ol.proj.transform(view.getCenter(), 'EPSG:3857', 'EPSG:4326');
            gmap.setCenter(new google.maps.LatLng(center[1], center[0]));
        });

        view.on('change:resolution', function () {
            gmap.setZoom(view.getZoom());
        });
        var olMapDiv = document.getElementById('olmap');
        this.map = new ol.Map({
            layers: [],
            overlays: [overlay],
            interactions: ol.interaction.defaults({
                altShiftDragRotate: false,
                dragPan: false,
                rotate: false
                }).extend([new ol.interaction.DragPan({ kinetic: null })]),
            target: olMapDiv,
            view: view
        });

        mmap = this.map;
        var that = this;
        _this = this;
        this.map.on('click', function (evt) {
            var xy = evt.coordinate;
            var latlon = ol.proj.transform(xy, 'EPSG:3857', 'EPSG:4326');
            that.elevator.getElevationForLocations({
                'locations': [{ lat: latlon[1], lng: latlon[0] }]
            }, function (results, status) {
                if (status === google.maps.ElevationStatus.OK) {
                    // Retrieve the first result
                    if (results[0]) {

                        // Open the infowindow indicating the elevation at the clicked position.
                        $("#latlonelev").html("<strong>Lat,Lon: </strong>" + latlon[1].toFixed(5) + "<strong>,</strong> " + latlon[0].toFixed(5) + "&nbsp&nbsp<strong>Elevation: </strong>" + results[0].elevation.toFixed(2) + " m");
                    } else {
                        $("#latlonelev").html("No results found");
                    }
                }
            });

        });
        view.fit([8912260.091133313, 3042341.524138276, 9818849.801192472, 3561365.8324687113]);
        olMapDiv.parentNode.removeChild(olMapDiv);
        gmap.controls[google.maps.ControlPosition.TOP_LEFT].push(olMapDiv);
        var that = this;
        _this = this;
        this.fitExtent();
        this.select = new ol.interaction.Select({
            //style:this.overlayStyle
            filter: function (feature, layer) {
                if (identifyStatus == true) {
                    identifiedLayerName = layer.get('LayerType');
                    return true;
                } else {
                    return false;
                }
            }
        });

        this.map.addInteraction(this.select);
        this.select.on('select', this.featureSelected, this);



        this.modify = new ol.interaction.Modify({
            features: this.select.getFeatures(),
            style: this.overlayStyle,

            //double click to delete vertices
            deleteCondition: function (event) {
                //if(delete_vertex_check == 1){
                return ol.events.condition.doubleClick(event);
            }
        });
        this.modify.on("modifyend", this.featureChanged, this);
        this.map.addInteraction(this.modify);


        //------------------------modify interaction to add vertex-------------------------        
        this.modify_add = new ol.interaction.Modify({
            features: this.select.getFeatures(),
            style: this.overlayStyle
        });
        this.modify_add.on("modifyend", this.featureChanged, this);
        this.map.addInteraction(this.modify_add);

        //        this.map.removeInteraction(this.modify);
        //        this.map.removeInteraction(this.modify_add);


        //------------------------modify interaction to add new line-------------------------        
        this.modify_add_new = new ol.interaction.Modify({
            features: this.select.getFeatures(),
            style: this.overlayStyle,
            insertVertexCondition: ol.events.condition.altKeyOnly,
        });
        this.modify_add_new.on("modifyend", this.featureChanged, this);
        this.map.addInteraction(this.modify_add_new);

        this.modify.setActive(false);
        this.modify_add.setActive(false);
        this.modify_add_new.setActive(false);

    },
    //TODO:Merge all Drawhandler into 1 function
    drawPointHandler: function (e) {
        if (selectedLayerDetail != null && selectedLayerDetail.type == "Point") {
            if (lineDrawn == true) {
                alert("save drawn line first");
                return;
            }

            document.getElementById("edit-identify-id").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("road").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("move_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("add_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("delete_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("olmap").style.cursor = "pointer";

            var layer_id = e.target.id;
            if (layer_id = "add_point") {
                layer_id = selectedLayer;
            }
            if (selectedLayerDetail.type == "Point") {
                this.draw(app.layerCollection.find({
                    name: selectedLayerDetail.layerId
                }));
            }

            this.removeSelectedStyle();
        } else {
            alert("select point layer");
        }
    },
    movePointHandler: function (e) {
        if (selectedLayerDetail != null && selectedLayerDetail.type == "Point") {
            if (pointDrawn == true) {
                alert("save drawn point first");
                return;
            }
            $("#olmap").css('cursor', 'grab');

            document.getElementById("edit-identify-id").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("road").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("move_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("add_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("delete_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            //document.getElementById("olmap").style.cursor = (document.body.style.cursor=="grab") ? "grabbing" : "grab"; 
            if (selectedLayerDetail != null) {
                selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
            }

            if (_thisline != null) {
                _thisline.map.removeInteraction(_thisline.drawFeature);
            }

            _this.modify.setActive(true);
        } else {
            alert("select point layer");
        }
    },
    moveLineVertexHandler: function (e) {
        if (selectedLayerDetail != null && (selectedLayerDetail.type == "LineString" || selectedLayerDetail.type == "Polygon")) {
            if (lineDrawn == true) {
                alert("save drawn line first");
                return;
            }
            identifyStatus = true;
            document.getElementById("edit-identify-id").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("road").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("move_vertex").style.boxShadow = "inset 10px 10px 10px #000000";
            document.getElementById("add_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("delete_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";

            document.getElementById("olmap").style.cursor = "pointer";
            if (selectedLayerDetail != null) {
                selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
            }
            _this.modify.setActive(false);
            _this.modify_add.setActive(false);
            _this.modify_add_new.setActive(true);
        } else {
            alert("select line layer");
        }
    },
    deleteLineVertexHandler: function (e) {
        if (selectedLayerDetail != null && selectedLayerDetail.type == "LineString") {
            if (lineDrawn == true) {
                alert("save drawn line first");
                return;
            }
            identifyStatus = true;
            delete_vertex_check = 1;


            document.getElementById("edit-identify-id").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("road").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("move_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("add_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("delete_road_vertex").style.boxShadow = "inset 10px 10px 10px #000000";
            document.getElementById("olmap").style.cursor = "pointer";
            if (selectedLayerDetail != null) {
                selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
            }

            if (_thisline != null) {
                _thisline.map.removeInteraction(_thisline.drawFeature);
            }
            _this.modify.setActive(true);
            _this.modify_add.setActive(false);
            _this.modify_add_new.setActive(false);
        } else {
            alert("select line layer");
        }
    },
    addLineVertexHandler: function (e) {
        if (selectedLayerDetail != null && selectedLayerDetail.type == "LineString") {
            if (lineDrawn == true) {
                alert("save drawn line first");
                return;
            }
            identifyStatus = true;
            document.getElementById("edit-identify-id").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("road").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("move_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("add_road_vertex").style.boxShadow = "inset 10px 10px 10px #000000";
            document.getElementById("delete_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("olmap").style.cursor = "pointer";

            if (selectedLayerDetail != null) {
                selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
            }

            if (_thisline != null) {
                _thisline.map.removeInteraction(_thisline.drawFeature);
            }
            _this.modify.setActive(false);
            _this.modify_add.setActive(true);
            _this.modify_add_new.setActive(false);

            this.removeSelectedStyle();
        } else {
            alert("select line layer");
        }
    },
    drawLineHandler: function (e) {
        if (selectedLayerDetail != null && selectedLayerDetail.type == "LineString") {

            if (lineDrawn == true) {
                alert("save drawn line first");
                return;
            }

            document.getElementById("edit-identify-id").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("road").style.boxShadow = "inset 10px 10px 10px #000000";
            document.getElementById("move_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("add_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("delete_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("olmap").style.cursor = "pointer";

            if (selectedLayerDetail != null) {
                selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
            }

            if (_thisline != null) {
                _thisline.map.removeInteraction(_thisline.drawFeature);
            }
            _this.modify.setActive(false);
            _this.modify_add.setActive(false);
            _this.modify_add_new.setActive(true);

            var layer_id = e.target.id;
            if (layer_id == "road") {
                layer_id = selectedLayer;
            }
            if (selectedLayerDetail.type == "LineString") {
                this.draw(app.layerCollection.find({
                    //name: layer_id
                    name: selectedLayerDetail.layerId
                }));
            }
        } else {
            alert("select line layer");
        }
    },
    drawPolygonHandler: function (e) {
        if (selectedLayerDetail != null && selectedLayerDetail.type == "Polygon") {
            document.getElementById("edit-identify-id").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("road").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("move_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("add_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("delete_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("olmap").style.cursor = "pointer";

            if (selectedLayerDetail != null) {
                selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
            }

            if (_thisline != null) {
                _thisline.map.removeInteraction(_thisline.drawFeature);
            }
            _this.modify.setActive(false);
            _this.modify_add.setActive(false);
            _this.modify_add_new.setActive(true);

            var layer_id = e.target.id;
            if (layer_id == "road") {
                layer_id = selectedLayer;
            }
            if (selectedLayerDetail.type == "Polygon") {
                this.draw(app.layerCollection.find({
                    //name: layer_id
                    name: selectedLayerDetail.layerId
                }));
            }
        } else {
            alert("select polygon layer");
        }
    },
    draw: function (tool) {
        tool.get('layer').addDrawFeature();
    },
    featureSelected: function (e) {
        $("#prop_window").css("visibility", "visible");
        var _cid, collection, model_view;
        if (e.deselected.length > 0) {
            _cid = e.deselected[0].getId();
            if (_cid) {
                var _collection = _this.getCollectionInstance(_cid);
                /*when selected feature is deleted _collection could be null*/
                if (_collection) {
                    e.deselected[0].setStyle(_collection.style);
                    $("#prop_window").html("Please select a feature to see its properties.");
                    document.getElementById('selected_layer_name').textContent = "";
                    if (e.selected.length < 1) {
                        $('#tab a:first').tab('show');
                    }
                }

            }
        }

        if (e.selected.length > 0) {
            _cid = e.selected[0].getId();
            _ccid = _cid;
            _ccFeature = e.selected[0];

            if (_cid) {
                _collection = _this.getCollectionInstance(_cid);
                _model = _collection.get(_cid);
                _model.feature = e.selected[0];
                _view = new _collection.view({
                    model: _model
                });
                if (identifyStatus == true) {


                    $('input[name="edit_radio"][value="' + identifiedLayerName + '"]').prop('checked', true);
                    selectedLayer = _collection.layerId;
                    selectedLayerDetail = _collection;
                    $.each(selectedLayerDetail.models[0].attributes, function (key, value) {
                        road_attrs[key] = null;
                    })
                }
                //------------------------------------ added ------------------------------                
                var geom = _model.feature.getGeometry();
                coordinates = geom.getCoordinates();
                coo = coordinates;
                if (_collection.layerId == "existing_projects.pipe")
                {
                    _model.set("pipe_len", Math.round(geom.getLength() * 100) / 100 );
                }
                //----------------------------------- end -------------------------------------                    

                if (_collection.layerId == "geocanal" && app.isCanalMergingOnProcess) {
                    this.trigger('mergingCanalSelected', _model);
                    if (_model.get("id")) {
                        e.selected[0].setStyle(_collection.selectedStyle);
                    }

                } else {
                    if (_model.get("id") == undefined) {
                        
                        document.getElementById('selected_layer_name').textContent = _collection.layerId;
                        e.selected[0].setStyle(_collection.selectedStyle);
                        $("#prop_window").html(_view.render().el);
                        $('.nav-tabs a[href="#prop_window"]').tab('show');
                    } else {
                        e.selected[0].setStyle(_collection.selectedStyle);
                        document.getElementById('selected_layer_name').textContent = _collection.layerId;
                        $("#prop_window").html(_view.render().el);
                        $("#r_length").val(parseFloat($("#r_length").val()).toFixed(2).toString());
                        $('.nav-tabs a[href="#prop_window"]').tab('show');
                    }
                }
            }
            }
        //}
    },
    identifyLayer: function (e) {
        if (identifyStatus == true) {
            identifyStatus = false;
            document.getElementById("olmap").style.cursor = "auto";
            document.getElementById("edit-identify-id").style.boxShadow = "inset 0px 0px 0px #000000";
            $("#prop_window").empty();
            this.removeSelectedStyle();
            selectedLayerDetail = null;
        }
        else {
            //identifyStatus = true;
            document.getElementById("olmap").style.cursor = "help";
            document.getElementById("edit-identify-id").style.boxShadow = "inset 10px 10px 10px  #000000";
            document.getElementById("road").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("move_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("add_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            document.getElementById("delete_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
            if (selectedLayerDetail != null) {
                selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
            }

            if (_thisline != null) {
                _thisline.map.removeInteraction(_thisline.drawFeature);
            }
            _this.modify.setActive(false);
            _this.modify_add.setActive(false);
            _this.modify_add_new.setActive(false);

            identifyStatus = true;
        }
    },
    featureChanged: function (e) {
        if (e.features.getLength() > 0) {
            wktier = new ol.format.WKT();
            var _feature = e.features.item(0);
            var _cid = _feature.getId();
            if (_cid) {
                var _collection = _this.getCollectionInstance(_cid);
                var _model = _collection.get(_cid);
                _model.set("wkt", wktier.writeFeature(_feature));
                if ($("#the_geom").length != 0) {
                    $("#the_geom").val(_model.attributes.wkt);
                }
                else if ($("#geom").length != 0) {
                    $("#geom").val(_model.attributes.wkt);
                }
                if (_collection.layerId == "existing_projects.project_details" || _collection.layerId == "existing_projects.water_source" || _collection.layerId == "existing_projects.reservoir" || _collection.layerId == "existing_projects.structure" || _collection.layerId == "existing_projects.tap" || _collection.layerId == "existing_projects.leftout_taps" || _collection.layerId == "existing_projects.junction") {
                    var geom = _feature.getGeometry();
                    coordinates = geom.getCoordinates();

                    coo = coordinates;
                    var cent = ol.proj.transform(coordinates, 'EPSG:3857', 'EPSG:4326');

                    $("#lat").val((parseFloat(cent.toString().split(',')[1])).toFixed(7));
                    $("#lon").val((parseFloat(cent.toString().split(',')[0])).toFixed(7));
                    _model.set("lat", (parseFloat(cent.toString().split(',')[1])).toFixed(7));
                    _model.set("lon", (parseFloat(cent.toString().split(',')[0])).toFixed(7));               

                }
                if (_collection.layerId == "existing_projects.pipe")
                {
                    $("#pipe_len").val(Math.round(_feature.getGeometry().getLength() * 100) / 100);
                }
            }
        }
    },
    saveData: function (e) {
        app.savedMessage = [];
        _.each(app.layerCollection.models, function (value, key, object) {
            _layer = value.get('layer');
            _layer.save();
        });
    },
    refreshData: function (e) {
        app.refresh();
    },
    clearData: function (e) {
        document.getElementById("edit-identify-id").style.boxShadow = "inset 0px 0px 0px #000000";
        document.getElementById("road").style.boxShadow = "inset 0px 0px 0px #000000";
        document.getElementById("add_point").style.boxShadow = "inset 0px 0px 0px #000000";
        document.getElementById("add_polygon").style.boxShadow = "inset 0px 0px 0px #000000";
        document.getElementById("move_house").style.boxShadow = "inset 0px 0px 0px #000000";
        document.getElementById("move_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
        document.getElementById("add_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";
        document.getElementById("delete_road_vertex").style.boxShadow = "inset 0px 0px 0px #000000";

        identifyStatus = false;
        document.getElementById("olmap").style.cursor = "auto";
        //$('input[name="edit_radio"][value="roadnetwork.road_network"]').prop('checked', false);
        if (selectedLayerDetail != null) {
            selectedLayerDetail.map.removeInteraction(selectedLayerDetail.drawFeature);
        }

        if (_thisline != null) {
            _thisline.map.removeInteraction(_thisline.drawFeature);
        }
        $("#prop_window").empty();
        this.removeSelectedStyle();
        selectedLayerDetail = null;
    },
    showPhoto1: function () {
        kl(coo, $("#photo1").val());
    },
    showPhoto2: function () {
        kl(coo, $("#photo2").val());
    },
    getCollectionInstance: function (_cid) {
        var layer = null;
        _.each(app.layerCollection.models, function (value, key, object) {
            _layer = value.get('layer');
            var _model = _layer.get(_cid);
            if (_model) {
                layer = _layer;
                return layer;
            }
        });
        return layer;
    }
    ,
    renderLayersView: function () {
        var html = this.layer_template({
            'items': app.layerCollection.models,
            'referenceLayers': app.originalCollection.models
        });
        $("#layer_window").html(html);
    }
    ,
    checkboxToggled: function (e) {
        _model = app.layerCollection.find({
            name: e.target.name
        });
        if (!_model) {
            _model = app.originalCollection.find({
                name: e.target.name
            });
        }
        var _vector = _model.get("layer");
        _vector.featureOverlay.setVisible(e.target.checked);
        this.map.render();
    }
    ,
    editToggled: function (e) {
        this.removeSelectedStyle();
        _.each(app.layerCollection.models, function (value, key, object) {
            _layer = value.get('layer');
            if ($('input[name="edit_radio"]:checked').val() == _layer.layerId) {

                $('input[name="edit_radio"]').mousedown(function (e) {

                    var $self = $(this);
                    if ($self.is(':checked')) {
                        var uncheck = function () {
                            selectedLayer = "";
                            selectedLayerDetail = null;
                            setTimeout(function () {
                                $self.removeAttr('checked');
                            }, 0);
                        };
                        var unbind = function () {
                            $self.unbind('mouseup', up);
                        };
                        var up = function () {
                            uncheck();
                            unbind();
                        };
                        $self.bind('mouseup', up);
                        $self.one('mouseout', unbind);
                    }
                });
                selectedLayer = _layer.layerId;
                selectedLayerDetail = _layer;
                identifiedLayerName = selectedLayer;
                $.each(selectedLayerDetail.models[0].attributes, function (key, value) {
                    road_attrs[key] = null;
                })
            }
        });
    },
    removeSelectedStyle: function () {
        if (_ccid && _ccFeature) {
            var _collection = _this.getCollectionInstance(_ccid);
            /*when selected feature is deleted _collection could be null*/
            if (_collection) {
                _ccFeature.setStyle(_collection.style);
                $("#prop_window").html("Please select a feature to see its properties.");
                document.getElementById('selected_layer_name').textContent = "";
            }

        }
    },
    changeBaseLayer: function (e) {
        let selectedMapType = $("#baseLayerType :selected").val();
        if (selectedMapType == "Empty") {
            var osmMapTypeOptions1 = {
                getTileUrl: function (coord, zoom) {
                    return null;
                },
                tileSize: new google.maps.Size(256, 256),
                isPng: true,
                maxZoom: 21,
                minZoom: 0,
                name: "Blank"
            };

            var osmMapType = new google.maps.ImageMapType(osmMapTypeOptions1);
            gmap.mapTypes.set('Blank', osmMapType);
            gmap.setMapTypeId('Blank');
        } else if (selectedMapType == "Google Satellite") {
            gmap.setMapTypeId(google.maps.MapTypeId.SATELLITE);
        } else if (selectedMapType == "Google Terrain")
            gmap.setMapTypeId(google.maps.MapTypeId.TERRAIN);
        else if (selectedMapType == "Google Streets")
            gmap.setMapTypeId(google.maps.MapTypeId.ROADMAP);
        else if (selectedMapType == "Open Street Map")
            var osmMapTypeOptions = {
                getTileUrl: function (coord, zoom) {
                    return "https://tile.openstreetmap.org/" +
                        zoom + "/" + coord.x + "/" + coord.y + ".png";
                },
                isPng: true,
                maxZoom: 21,
                minZoom: 0,
                name: "OSM"
            };

        var osmMapType = new google.maps.ImageMapType(osmMapTypeOptions);
        gmap.mapTypes.set('OSM', osmMapType);
        gmap.setMapTypeId('OSM');
    },
    countUnsavedItems: function () {
        var layer = null;
        var count = 0;
        _.each(app.layerCollection.models, function (value, key, object) {
            _layer = value.get('layer');
            _layer.each(function (model) {
                if (model.hasChangedSinceLastSync) {
                    count++;
                }
            });
        });
        return count;
    }
    ,
    updateUnsavedItems: function () {
        var count = this.countUnsavedItems();
        //if (count > 0) {
        //    $("#unsaved_count").html("Unsaved Items: " + count);
        //} else {
        //    $("#unsaved_count").html("");
        //}
    },
    getCollectionInstanceBylayerId: function (layerId) {
        var _layer = null;
        var arr = app.layerCollection.models;
        _layer = arr.find(function (value) {
            _layer1 = value.get('layer');
            return layerId == _layer1.layerId;
        });
        if (_layer) {
            return _layer.get('layer');
        } else {
            return null;
        }
    },
    showMergeCanalWindow: function () {
        var tab = "merge_window";
        $('.nav-tabs a[href="#' + tab + '"]').tab('show');
    }
    ,
    //canal selected for merging
    canalSelected: function (e) {
        if (e.get("id") != null) {
            var selected_canal = e.get("id");
            $("#selected_" + app.selectedCanalButtonId).html(selected_canal);
            if (app.selectedCanalButtonId == "canal_1")
                app.headCanal = e;
            else if (app.selectedCanalButtonId == "canal_2")
                app.tailCanal = e;
            app.isCanalMergingOnProcess = false;
            this.toggleCanalEditable(false);
        } else {
            //unsaved canal cannot be merged.
            alert("This canal should be saved first to merge");

        }

    }
    ,
    mergingCanalInitiated: function (e) {
        app.isCanalMergingOnProcess = true;
        app.selectedCanalButtonId = e.target.id;
        $('.edit-radio').prop('checked', false);

        this.toggleCanalEditable(true);
    }
    ,
    toggleCanalEditable: function (bool) {
        var _col = _this.getCollectionInstanceBylayerId("geocanal");
        if (_col.selectable) {
            //setting geo canal to be selectable
            _col.featureOverlay.set('editable', bool);
        }
    },
    mergeCanal: function () {
        app.headCanal.merge_canal(app.tailCanal);
    }
    ,
    fitExtent: function () {
        //alert(pid);
        var url = "";
        if (appType == "EXISTING_PROJECT") {
            url = siteurl + "Draw/GetExtent?pid="+pid;
        } else if (appType == "NEW_SOURCE") {
            url = siteurl + "edit_new_source/getExtent?pid="+pid;
        }
        var that = this;
        $.ajax({
            url: url,
            success: function (result) {
                var x1 = parseFloat(result[0]);
                var y1 = parseFloat(result[1]);
                var x2 = parseFloat(result[2]);
                var y2 = parseFloat(result[3]);


                var minProj = ol.proj.transform([x1, y1], 'EPSG:4326', 'EPSG:3857');
                var x1 = minProj[0];
                var y1 = minProj[1];

                var maxProj = ol.proj.transform([x2, y2], 'EPSG:4326', 'EPSG:3857');
                var x2 = maxProj[0];
                var y2 = maxProj[1];
                //that.map.getView().fit([x1, y1, x2, y2]);
                //that.map.getView().setZoom(12);

                //jsonObj = jQuery.parseJSON(result);
                //bottomLeft = [jsonObj.left, jsonObj.bottom];
                //topRight = [jsonObj.right, jsonObj.top];
                bottomLeft = [x1, y1];
                topRight = [x2,y2];
                var extent = new ol.extent.boundingExtent([bottomLeft, topRight]);
                that.map.getView().fit(extent, { size: that.map.getSize(), nearest: true });
            },
            error: function (e) {
                alert("Please check if you are connected to internet4.");
            }
        });
    }


});

function flyToSearch() {
    var vi;
    vi = mmap.getView();
    var duration = 2000;
    //var zoom = vi.getZoom();
    var zoom = 19;
    var parts = 2;
    var called = false;
    function callback(complete) {
        //                    --parts;
        if (called) {
            return;
        }
        if (parts === 0 || !complete) {
            called = true;
            done(complete);
        }
    }
    vi.animate({
        //                    center:ol.proj.fromLonLat([83.4726353, 27.6291936]),
        center: ol.proj.fromLonLat([parseFloat($("#searchedLng").val()), parseFloat($("#searchedLat").val())]),
        duration: duration
    }, callback);
    vi.animate({
        zoom: zoom - 1,
        duration: duration / 2
    }, {
        zoom: zoom,
        duration: duration / 2
    }, callback);
}

function flyToSearchEdit() {
    var vi;
    vi = mmap.getView();
    var duration = 2000;
    var zoom = 19;
    var parts = 2;
    var called = false;
    function callback(complete) {
        if (called) {
            return;
        }
        if (parts === 0 || !complete) {
            called = true;
            done(complete);
        }
    }
    vi.animate({
        center: ol.proj.fromLonLat([parseFloat($("#edit_map_search option:selected").val().split(",")[0]), parseFloat($("#edit_map_search option:selected").val().split(",")[1])]),
        duration: duration
    }, callback);
    vi.animate({
        zoom: zoom - 1,
        duration: duration / 2
    }, {
        zoom: zoom,
        duration: duration / 2
    }, callback);
}

