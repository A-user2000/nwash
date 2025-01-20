//translate feature
//http://openlayers.org/en/v3.9.0/examples/translate-features.html?q=select
/**
 *shprabin@gmail.com
 *17th Sep,2015
 *
 */
var i = 0;
var app = app || {};
var features;
app.DrawView = Backbone.View.extend({
    el: '#appdiv',
    map: null,
    drawFeature: null,
    events: {
        'click #reservoir': 'drawPointHandler',
        'click #tap': 'drawPointHandler',
        'click #geocanal': 'drawLineHandler',
//        'click #pipeDrawnalignment': 'drawLineHandler',
//        'click #pipeRoutepoint': 'drawPointHandler',
        'click #source': 'drawPointHandler',
        'click #structure': 'drawPointHandler',
        'click #junction': 'drawPointHandler',
        'click #coverage': 'drawPolygonHandler',

        'click #save_btn': 'saveData',
        'click .layer-checkbox': 'checkboxToggled',
        'change .edit-radio': 'editToggled',
        'click #geocanalmerge': 'showMergeCanalWindow',
        'click #canal_1': 'mergingCanalInitiated',
        'click #canal_2': 'mergingCanalInitiated',
        'click #merge': 'mergeCanal'
    },
    layer_template: _.template($("#layer-template").html()),

    initialize: function () {
        /*this.raster=new ol.layer.Tile({
         source: new ol.source.MapQuest({
         layer: 'sat'
         })
         });*/
        this.listenTo(this, 'mergingCanalSelected', this.canalSelected);
        this.raster = new ol.layer.Tile({
            preload: Infinity,
            source: new ol.source.BingMaps({
                key: 'Atn3I2g5CTaX_q8BKW4eOXco3GP9bkM7qhxrNRM-OJ0lesj3v7KFA3bRgO_YgG8x',
                imagerySet: 'Aerial'
                        // use maxZoom 19 to see stretched tiles instead of the BingMaps
                        // "no photos at this zoom level" tiles
                        // maxZoom: 19
            })
        });


        if (googlelayer == 'on')
        {
            var gmap = new google.maps.Map(document.getElementById('gmap'), {
                disableDefaultUI: true,
                keyboardShortcuts: false,
                draggable: false,
                disableDoubleClickZoom: true,
                scrollwheel: false,
                streetViewControl: false,
                mapTypeId: "satellite"
            });
            this.elevator = new google.maps.ElevationService;

            var view = new ol.View({
                // make sure the view doesn't go beyond the 22 zoom levels of Google Maps
                maxZoom: 19,
                center: [9501789.122216, 3195917.02766273],
                zoom: 15
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
                interactions: ol.interaction.defaults({
                    altShiftDragRotate: false,
                    dragPan: false,
                    rotate: false
                }).extend([new ol.interaction.DragPan({kinetic: null})]),
                target: olMapDiv,
                view: view
            });
            var that = this;
            this.map.on('click', function (evt) {
                var xy = evt.coordinate;
                var latlon = ol.proj.transform(xy, 'EPSG:3857', 'EPSG:4326');
                that.elevator.getElevationForLocations({
                    'locations': [{lat: latlon[1], lng: latlon[0]}]
                }, function (results, status) {
                    if (status === google.maps.ElevationStatus.OK) {
                        // Retrieve the first result
                        if (results[0]) {
                            // Open the infowindow indicating the elevation at the clicked position.
                            $("#latlonelev").html("<strong>Lat,Lon: </strong>" + latlon[1].toFixed(5) + "<strong>,</strong> " + latlon[0].toFixed(5) + "&nbsp&nbsp<strong>Elevation: </strong>" + results[0].elevation.toFixed(2) + " m");
                            //console.log('The elevation at this point <br>is ' + results[0].elevation + ' meters.');
                        } else {
                            //console.log('No results found');
                            $("#latlonelev").html("No results found");
                        }
                    }
                });
            });
            view.setCenter([9501789.122216, 3195917.02766273]);
            view.setZoom(15);

            olMapDiv.parentNode.removeChild(olMapDiv);
            gmap.controls[google.maps.ControlPosition.TOP_LEFT].push(olMapDiv);
        } else {

            this.map = new ol.Map({
                layers: [],
                target: 'map',
                view: new ol.View({
                    center: [9501789.122216, 3195917.02766273],
                    zoom: 15
                })
            });
        }
        var that = this;
        this.fitExtent();
        this.select = new ol.interaction.Select({
            //style:this.overlayStyle
            filter: function (feature, layer)
            {
                if (layer.get('selectable') && layer.getVisible() && layer.get('editable'))
                    return true;
                else
                    return false;
            }
        });

        this.map.addInteraction(this.select);
        this.select.on('select', this.featureSelected, this);

        this.modify = new ol.interaction.Modify({
            features: this.select.getFeatures(),
            style: this.overlayStyle,
            // the SHIFT key must be pressed to delete vertices, so
            // that new vertices can be drawn at the same position
            // of existing vertices
            deleteCondition: function (event) {
                return ol.events.condition.shiftKeyOnly(event) &&
                        ol.events.condition.singleClick(event);
            }
        });
        this.modify.on("modifyend", this.featureChanged, this);
        this.map.addInteraction(this.modify);

        //find canal layer for snapping
        /*canal_layer = app.layerCollection.find({
         name: 'geocanal'
         })
         this.snap = new ol.interaction.Snap({
         source: this.select.getFeatures()
         });
         this.map.addInteraction(this.snap);*/

    },
    //TODO:Merge all Drawhandler into 1 function
    drawPointHandler: function (e) {
        var layer_id = e.target.id;
        this.draw(app.layerCollection.find({
            name: layer_id
        }));
    },
    drawLineHandler: function (e)
    {
        var layer_id = e.target.id;
        this.draw(app.layerCollection.find({
            name: layer_id
        }));
    },
    drawPolygonHandler: function (e)
    {
        var layer_id = e.target.id;
        this.draw(app.layerCollection.find({
            name: layer_id
        }));
    },
    draw: function (tool) {
        tool.get('layer').addDrawFeature();
    },
    featureSelected: function (e)
    {

        var _cid, collection, model_view;
        if (e.deselected.length > 0) {
            _cid = e.deselected[0].getId();
            if (_cid)
            {
                var _collection = this.getCollectionInstance(_cid);
                /*when selected feature is deleted _collection could be null*/
                if (_collection)
                {
                    //this.select.set("style",_collection.overlayStyle);
                    e.deselected[0].setStyle(_collection.style);
                    $("#prop_window").html("Please select a feature to see it's properties.");
                    if (e.selected.length < 1)
                    {
                        $('#tab a:first').tab('show');
                    }
                }

            }
        }

        if (e.selected.length > 0)
        {
            _cid = e.selected[0].getId();
            if (_cid)
            {
                _collection = this.getCollectionInstance(_cid);
                _model = _collection.get(_cid);
                _model.feature = e.selected[0];
                _view = new _collection.view({
                    model: _model
                });

                if (_collection.layerId == "geocanal" && app.isCanalMergingOnProcess)
                {
                    this.trigger('mergingCanalSelected', _model);
                    if (_model.get("id"))
                    {
                        e.selected[0].setStyle(_collection.selectedStyle);
                    }

                } else {
                    //this.select.set("style",_collection.overlayStyle);
                    e.selected[0].setStyle(_collection.selectedStyle);
                    $("#prop_window").html(_view.render().el);
                    $('.nav-tabs a[href="#prop_window"]').tab('show');
                }
            }
        }

    },
    featureChanged: function (e)
    {

        if (e.features.getLength() > 0)
        {
            wktier = new ol.format.WKT();
            var _feature = e.features.item(0);
            var _cid = _feature.getId();
            if (_cid)
            {
                var _collection = this.getCollectionInstance(_cid);
                var _model = _collection.get(_cid);
                _model.set("wkt", wktier.writeFeature(_feature));
                //for snapping of structure into canal
                if (_collection.layerId == "geostructure")
                {
                    var geom = _feature.getGeometry();
                    coordinates = geom.getCoordinates();
                    _model.snapToCanal(coordinates);
                }
            }
        }
        //console.log(app.snap);
    }
    ,
    saveData: function (e)
    {
        app.savedMessage = [];
        _.each(app.layerCollection.models, function (value, key, object) {
//            console.log(value.get('layer'));
            _layer = value.get('layer');
            _layer.save();
        });
    },
    getCollectionInstance: function (_cid)
    {
        var layer = null;
        _.each(app.layerCollection.models, function (value, key, object) {
            _layer = value.get('layer');
            var _model = _layer.get(_cid);
            if (_model)
            {
                layer = _layer;
                return layer;
            }
        });
        return layer;
    }
    ,
    renderLayersView: function ()
    {
        var html = this.layer_template({
            'items': app.layerCollection.models,
            'referenceLayers': app.originalCollection.models
        });
        $("#layer_window").html(html);
    }
    ,
    checkboxToggled: function (e)
    {
        _model = app.layerCollection.find({
            name: e.target.name
        });
        if (!_model)
        {
            _model = app.originalCollection.find({
                name: e.target.name
            });
        }
        var _vector = _model.get("layer");
        _vector.featureOverlay.setVisible(e.target.checked);
        this.map.render();
    }
    ,
    editToggled: function (e)
    {
        //console.log(e.target);
        _.each(app.layerCollection.models, function (value, key, object) {
            _layer = value.get('layer');
            if (_layer.selectable)
            {
                if (e.target.value == _layer.layerId)
                {
                    _layer.featureOverlay.set('editable', true);
                } else
                {
                    _layer.featureOverlay.set('editable', false);
                }
            }
        });
    },
    countUnsavedItems: function ()
    {
        var layer = null;
        var count = 0;
        _.each(app.layerCollection.models, function (value, key, object) {
            _layer = value.get('layer');
            _layer.each(function (model) {
                if (model.hasChangedSinceLastSync)
                {
                    count++;
                }
            });
        });
        return count;
    }
    ,
    updateUnsavedItems: function ()
    {
        var count = this.countUnsavedItems();
        if (count > 0)
        {
            $("#unsaved_count").html("Unsaved Items: " + count);
        } else
        {
            $("#unsaved_count").html("");
        }
    },
    getCollectionInstanceBylayerId: function (layerId)
    {
        var _layer = null;
        var arr = app.layerCollection.models;
        _layer = arr.find(function (value) {
            _layer1 = value.get('layer');
            return layerId == _layer1.layerId;
        });
        if (_layer)
        {
            return _layer.get('layer');
        } else {
            return null;
        }
    },
    showMergeCanalWindow: function ()
    {
        var tab = "merge_window";
        $('.nav-tabs a[href="#' + tab + '"]').tab('show');
    }
    ,
    //canal selected for merging
    canalSelected: function (e)
    {
        if (e.get("id") != null)
        {
            var selected_canal = e.get("id");
            $("#selected_" + app.selectedCanalButtonId).html(selected_canal);
            if (app.selectedCanalButtonId == "canal_1")
                app.headCanal = e;
            else if (app.selectedCanalButtonId == "canal_2")
                app.tailCanal = e;
            app.isCanalMergingOnProcess = false;
            this.toggleCanalEditable(false);
        } else
        {
            //unsaved canal cannot be merged.
            alert("This canal should be saved first to merge");

        }

    }
    ,
    mergingCanalInitiated: function (e)
    {
        app.isCanalMergingOnProcess = true;
        app.selectedCanalButtonId = e.target.id;
        $('.edit-radio').prop('checked', false);

        this.toggleCanalEditable(true);
    }
    ,
    toggleCanalEditable: function (bool)
    {
        var _col = this.getCollectionInstanceBylayerId("geocanal");
        if (_col.selectable)
        {
            //setting geo canal to be selectable
            _col.featureOverlay.set('editable', bool);
        }
    },
    mergeCanal: function ()
    {
        app.headCanal.merge_canal(app.tailCanal);
    }
    ,
    fitExtent: function ()
    {
        var url = "";
        if (appType == "EXISTING_PROJECT")
        {
            url = base_url + "draw/getExtent/" + pid;
        } else if (appType == "NEW_SOURCE")
        {
            url = base_url + "edit_new_source/getExtent/" + pid;
        }
        var that = this;
        $.ajax({
            url: url,
            success: function (result) {
                jsonObj = jQuery.parseJSON(result);
                bottomLeft = [jsonObj.left, jsonObj.bottom];
                topRight = [jsonObj.right, jsonObj.top];
                var extent = new ol.extent.boundingExtent([bottomLeft, topRight]);
                that.map.getView().fit(extent, {size: that.map.getSize(), nearest: true});
                //that.map.getView().setCenter([jsonObj.bottom, jsonObj.left]);
            },
            error: function (e)
            {
                alert("Please check if you are connected to internet.");
            }
        });
    }


});


