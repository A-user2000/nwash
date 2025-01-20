/* Module for printing map
 * shprabin@gmail.com
 * Feb 14, 2014
 *  All the Printing calculations are based on method/procedure from this website
 *  http://www.britishideas.com/2009/09/22/map-scales-and-printing-with-mapnik/
 */

var QgsModule = {
    vectorLayer: null,
    isAlreadyOpened: false,
    control: null,
    request: null,
    paperSizes: [
        {
            size: "A4",
            mode: "P",
            width: 8.26,
            height: 11.7,
            print_width: 7.3,
            print_height: 9.44
        },
        {
            size: "A4",
            mode: "L",
            width: 297,
            height: 210,
            print_width: 225,
            print_height: 180
        },
        {
            size: "A3",
            mode: "P",
            width: 297,
            height: 420,
            print_width: 9.72,
            print_height: 14.56
        },
        {
            size: "A3",
            mode: "L",
            width: 420,
            height: 297,
            print_width: 317.638,
            print_height: 266.832
        },
    ],
    addVectorLayer: function ()
    {
        if (this.isAlreadyOpened)
            return;
        var polygonFeature = new ol.Feature({
            geometry: new ol.geom.Polygon([[[9148315.0639, 3427368.48391], [9345352.70364, 3428727.36856],
                    [9349429.39491, 3275173.851], [9164621.60505, 3265661.69578], [9148315.0639, 3427368.48391]]])
        });

        vectorLayer = new ol.layer.Vector({
            source: new ol.source.Vector({
                features: [polygonFeature]
            }),
            style: new ol.style.Style({
                fill: new ol.style.Fill({
                    color: [0, 0, 255, 0.3]
                }),
                stroke: new ol.style.Stroke({
                    color: [255, 160, 25, 1],
                    width: 0.6,
                })
            }),
            zIndex: 1299096

        });
        vectorLayer.set('name', 'Print');

        map.addLayer(vectorLayer);



        control = new ol.interaction.Translate({
            features: new ol.Collection([polygonFeature])
        });
        map.addInteraction(control);
        this.set_size();

    },
    set_size: function ()
    {
        var scale = $("#qgsscale_den").val();
        var scale_denominator = Number(scale) * 1000;
//        var papersize = $("#qgsprint_size").val();
//        var mode = $("#qgsorientation").val();
        var papersize = "A4";
        var mode = "L";
        this.set_vector_layer(papersize, mode, scale_denominator);
    },
    set_size_manual: function ()
    {
        var scale = $("#qgsscale_ent").val();
        var scale_denominator = Number(scale);
//        var papersize = $("#qgsprint_size").val();
//        var mode = $("#qgsorientation").val();
        var papersize = "A4";
        var mode = "L";
        sc_val = scale_denominator / 1000;
//        $('<option>').val(sc_val).text('1:' + scale_denominator).appendTo('#qgsscale_den');
        $('#qgsscale_den').append('<option value="' + sc_val + '" selected="selected">1:' + scale_denominator + '</option>');
        this.set_vector_layer(papersize, mode, scale_denominator);
    },
    screenScale: function () {
        var unit = map.getView().getProjection().getUnits();
        var resolution = map.getView().getResolution();
        var inchesPerMetre = 39.3700787;
        var dpi = 96;

        return resolution * ol.proj.Units.METERS_PER_UNIT[unit] * inchesPerMetre * dpi;
    },
    printResolution: function (scale) {
        var unit = map.getView().getProjection().getUnits();
        var inchesPerMetre = 39.3700787;
        var dpi = 120;

        return scale / (ol.proj.Units.METERS_PER_UNIT[unit] * inchesPerMetre * dpi);
    },
    set_vector_layer: function (papersize, mode, scale_denominator)
    {
        var point;
        for (var i = 0; i < this.paperSizes.length; i++) {
            paperObj = this.paperSizes[i];
            if (paperObj.size === papersize) {
                if (paperObj.mode === mode) {
                    break;
                }
            }
        }

        var size = [paperObj.print_width, paperObj.print_height];


        var w = Number(size[0]) * this.printResolution(scale_denominator) / this.screenScale() * 18000;
        var h = Number(size[1]) * this.printResolution(scale_denominator) / this.screenScale() * 18000;

        //w = 225;
        //h = 0.9615*h;

        var bounds = map.getView().calculateExtent([w, h]);
        var printBox = [
            [bounds[0], bounds[1]],
            [bounds[0], bounds[3]],
            [bounds[2], bounds[3]],
            [bounds[2], bounds[1]],
            [bounds[0], bounds[1]]
        ];

        var polygonFeature = new ol.Feature({
            geometry: new ol.geom.Polygon([printBox])
        });
        vectorLayer.getSource().clear();
        vectorLayer.getSource().addFeature(polygonFeature);
        control = new ol.interaction.Translate({
            features: new ol.Collection([polygonFeature])
        });
        map.addInteraction(control);

    },
    activate: function ()
    {
        $("#map-print-tool").attr("class", "qgsprinter-active");
        $("#qgsprint-draggable").show();

        this.addVectorLayer();
        this.isAlreadyOpened = true;
    },
    deactivate: function ()
    {
        $("#map-print-tool").attr("class", "qgsprinter");
        this.isAlreadyOpened = false;
        remove_layers('name', 'Print'),
                //map.removeLayer(this.vectorLayer);
                $("#qgsprint-draggable").hide();
    },
    print: function ()
    {
        var layers = [];
        layers.push("National Line", "National Mask");           // national line and mask at top order in layers.
        map.getLayers().forEach(function (layer) {
            if (layer.Length !== 1) {
                if (!layer.getVisible()) {
                } else {
                    if (layer.get('name') === "Google Physical") {
                    } else if (layer.get('name') === "Google Hybrid") {
                    } else if (layer.get('name') === "Markers") {
                    } else if (layer.get('name') === "Irrigation") {
                    } else if (layer.get('name') === "Muni Mask") {
                    } else if (layer.get('name') === "District") {
                    } else if (layer.get('name') === "National Line") {
                    } else if (layer.get('name') === "National Mask") {
                    } else if (layer.get('name') === "District Boundary") {
                    } else if (layer.get('name') === "Province Mask") {                    
                    } else if (layer.get('name') === "Project Coverage") {
                    } else if (layer.get('name') === "Print") {
                    } else if (layer.get('name') === "Functionality Framework") {
                    } else if (layer.get('name') === "Sustainability Framework") {
                    } else if (layer.get('name') === undefined) {
                    } else {
                        layers.push(layer.get('name'));
                    }
                    //}
                }
            } else {
                //continue;
            }

        });
        // debugger;
        var printBounds = vectorLayer.getSource().getExtent();       
        var maxCo = proj4('EPSG:3857', 'EPSG:32645', [printBounds[2], printBounds[3]]);
        var minCo = proj4('EPSG:3857', 'EPSG:32645', [printBounds[0], printBounds[1]]);

        var xmax = Number(maxCo[0]);
        var ymax = Number(maxCo[1]);
        var xmin = Number(minCo[0]);
        var ymin = Number(minCo[1]);
        var calc_ymax = ymin + ((xmax - xmin) / 1.25);
        
        
        var title = $("#qgsprintform #title").val();
        var map_no = $("#qgsprintform #map_no").val();
        var comment = $("#qgsprintform #comment").val();
        var paper_size = $("#qgsprintform #paper_size").val();
        var scale = $("#qgsprintform #qgsscale_den").val();
        var orientation = $("#qgsprintform #orientation").val();
        var extension = $("#extension").val();
        var dpi = $("#dpi").val();
        var gaunpalika = $("#gaunpalika").val();
        var gaunpalika_code = $("#gaunpalika_code").val();
        var map_clipped = $("#map_clipped").val();
        var district_code = $("#district_code").val();
        var district = $("#districtname").val();
        

        var map_name = '';

        if (gaunpalika_code != '') {
            map_name = gaunpalika;
        } else {
            map_name = district;
        }

        if (extension === 'PDF') {
            var ext = 'pdf';
        } else if (extension === 'JPG') {
            var ext = 'jpg';
        } else if (extension === 'PNG') {
            var ext = 'png';
        }
        var i = 0;    
        var elem = document.getElementById("map_loading");
        var id;        
        layers = layers.toString();        
        this.request = $.ajax({
            type: "POST",
            url: "Map/DownloadMap/",
            //timeout: 180000,            // 3 minutes time out
            data: {'id':1, 'xmax': xmax, 'xmin': xmin, 'ymax': calc_ymax, 'ymin': ymin, 'layers': layers, 'title': title, 'map_no': map_no, 'comment': comment, 'scale': scale, 'gaunpalika_code': gaunpalika_code, 'gaunpalika': gaunpalika, 'map_clipped': map_clipped, 'extension': extension, 'district': district, 'district_code': district_code, 'paper_size': paper_size },
            beforeSend: function () {

                $("#map_loading").css("display", "block");
                $("#loading_text1").html("<center><b>Processing Map...</b></center>");
                $("#loading_text2").html("<center>This request may take 1-2 minutes.</center>");
                var width = 1;                
                if (i == 0) {
                    i = 1;                    
                    elem.style.width = 0;
                    var width = 1;
                    id = setInterval(frame, 1000);
                    function frame() {
                        if (width >= 80) {
                            clearInterval(id);
                            i = 0;
                        } else if (width <= 40) {
                            width += 2;
                            elem.style.width = width + "%";
                        } else {
                            width += 1;
                            elem.style.width = width + "%";
                        }                        
                    }
                }

                $("#qgs_print_cancel").css("display", "block");
                $("#qgs_print").attr("disabled", true);
            },
            complete: function () {
                clearInterval(id);
                $("#loading_text1").text("");
                $("#loading_text2").text("");
                $("#map_loading").css("display", "none");
                $("#qgs_print_cancel").css("display", "none");
                $("#qgs_print").attr("disabled", false);
            },
            success: function (result) {                
                var result = $.parseJSON(result);  

                if (result === true) {
                    var path = window.location.origin + "/PrintMap/" + map_name + "_map." + ext;
                    var save = document.createElement('a');
                    save.href = path;
                    save.download = map_name + "_map." + ext;
                    save.target = '_blank';
                    save.textContent = 'Download Map';
                    document.body.appendChild(save);
                    save.click();
                    document.body.removeChild(save);
                    // }
                } else {
                    alert(result);

                }
            }
        });
    },
    cancel_print: function () {
        this.request.abort();
        $("#map_loading").css("width", "0");
        $("#loading_text1").text("");
        $("#loading_text2").text("");
        $("#map_loading").text("");
        $("#map_loading").css("display", "none");
        $("#qgs_print_cancel").css("display", "none");
        $("#qgs_print").attr("disabled", false);
    },
    json_encode: function (value, whitelist) {
        ///// some helper functions for the encoding process
        function f(n) {    // Format integers to have at least two digits.
            return n < 10 ? '0' + n : n;
        }

        Date.prototype.toJSON = function () {
            // Eventually, this method will be based on the date.toISOString method.
            return this.getUTCFullYear() + '-' +
                    f(this.getUTCMonth() + 1) + '-' +
                    f(this.getUTCDate()) + 'T' +
                    f(this.getUTCHours()) + ':' +
                    f(this.getUTCMinutes()) + ':' +
                    f(this.getUTCSeconds()) + 'Z';
        };

        var m = {// table of character substitutions
            '\b': '\\b',
            '\t': '\\t',
            '\n': '\\n',
            '\f': '\\f',
            '\r': '\\r',
            '"': '\\"',
            '\\': '\\\\'
        };

        ///// finally, on to actually encoding
        var a, // The array holding the partial texts.
                i, // The loop counter.
                k, // The member key.
                l, // Length.
                r = /["\\\x00-\x1f\x7f-\x9f]/g,
                v;          // The member value.

        switch (typeof value) {
            case 'string':
                // If the string contains no control characters, no quote characters, and no
                // backslash characters, then we can safely slap some quotes around it.
                // Otherwise we must also replace the offending characters with safe sequences.
                return r.test(value) ?
                        '"' + value.replace(r, function (a) {
                            var c = m[a];
                            if (c) {
                                return c;
                            }
                            c = a.charCodeAt();
                            return '\\u00' + Math.floor(c / 16).toString(16) +
                                    (c % 16).toString(16);
                        }) + '"' :
                        '"' + value + '"';

            case 'number':
                // JSON numbers must be finite. Encode non-finite numbers as null.
                return isFinite(value) ? String(value) : 'null';

            case 'boolean':
            case 'null':
                return String(value);

            case 'object':
                // Due to a specification blunder in ECMAScript, typeof null is 'object', so watch out for that case.
                if (!value) {
                    return 'null';
                }

                // If the object has a toJSON method, call it, and stringify the result.
                if (typeof value.toJSON === 'function') {
                    return this.json_encode(value.toJSON());
                }
                a = [];
                if (typeof value.length === 'number' && !(value.propertyIsEnumerable('length'))) {
                    // The object is an array. Stringify every element. Use null as a placeholder for non-JSON values.
                    l = value.length;
                    for (i = 0; i < l; i += 1) {
                        a.push(this.json_encode(value[i], whitelist) || 'null');
                    }

                    // Join all of the elements together and wrap them in brackets.
                    return '[' + a.join(',') + ']';
                }
                if (whitelist) {
                    // If a whitelist (array of keys) is provided, use it to select the components of the object.
                    l = whitelist.length;
                    for (i = 0; i < l; i += 1) {
                        k = whitelist[i];
                        if (typeof k === 'string') {
                            v = this.json_encode(value[k], whitelist);
                            if (v) {
                                a.push(this.json_encode(k) + ':' + v);
                            }
                        }
                    }
                } else {
                    // Otherwise, iterate through all of the keys in the object.
                    for (k in value) {
                        if (typeof k === 'string') {
                            v = this.json_encode(value[k], whitelist);
                            if (v) {
                                a.push(this.json_encode(k) + ':' + v);
                            }
                        }
                    }
                }

                // Join all of the member texts together and wrap them in braces.
                return '{' + a.join(',') + '}';
        }
    }


}