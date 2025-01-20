// js/app.js

var app = app || {};
var ENTER_KEY = 13;
$(function () {

    // Kick things off by creating the **App**.
    app.drawView = new app.DrawView();
    app.config = [];
    //for original layer
    app.config1 = [];
    app.savedMessage = [];
    app.messageCounter = 1;
    app.previousDrawInteraction = null;
    app.isCanalMergingOnProcess = false;
    app.selectedCanalButtonId = null;
    app.headCanal = null;
    app.tailCanal = null;
    app.type = "NEW_SOURCE";
    app.writeStatusMessage = function (savedStatus)
    {
        var cssClass = "bg-danger";
        var target = "status_message_" + app.messageCounter;
        if (savedStatus.success)
        {
            cssClass = "bg-success";
        }
        var message = '<p id="' + target + '" class="' + cssClass + '" style="text-align:center;"><strong>' + savedStatus.message + '</strong></p>';
        $("#status_message").append(message);
        app.messageCounter++;
        $("#" + target).fadeOut(7000, function () {
            $(this).remove();
        });
    };
    app.InstanceFactory = function (strClass) {
        var args = Array.prototype.slice.call(arguments, 1);
        var clsClass = eval(strClass);
        function F() {
            return clsClass.apply(this, args);
        }
        F.prototype = clsClass.prototype;
        return new F();
    };


    app.config.push({
        label: "Water Source",
        layerId: 'new_source',
        selectable: true,
        visibility: true,
        type: 'Point',
        legend: 'ws-legend',
        collection: app.PointCollection,
        model: app.NewSourceModel,
        view: app.NewSourceView,
        url: site_url + "edit_new_source/source/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.RegularShape({
                    fill: new ol.style.Fill({color: '#0033cc'}),
                    stroke: new ol.style.Stroke({color: 'black', width: 2}),
                    points: 3,
                    radius: 10,
                    rotation: 90,
                    angle: 0
                }),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#0000FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 0,
                    offsetY: 0,
                    rotation: 0
                })
            })
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
                console.log(resolution);
            }
            var style = new ol.style.Style({
                image: new ol.style.RegularShape({
                    fill: new ol.style.Fill({color: '#0033cc'}),
                    stroke: new ol.style.Stroke({color: '#ffff00', width: 2}),
                    points: 3,
                    radius: 10,
                    rotation: 90,
                    angle: 0
                }),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 0,
                    offsetY: 0,
                    rotation: 0
                })
            })
            return [style];
        }
    });


    app.config.push({
        label: "Community Water Supply",
        layerId: 'community_ws',
        selectable: true,
        visibility: true,
        type: 'Point',
        legend: 'community-ws-legend',
        collection: app.PointCollection,
        model: app.CommunityWSModel,
        view: app.CommunityWSView,
        url: site_url + "edit_new_source/community_ws/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.Circle({
                    fill: null,
                    stroke: new ol.style.Stroke({
                        color: '#b30059',
                        width: 2
                    }),
                    points: 4,
                    radius: 10
                }),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#0000FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 0,
                    offsetY: 0,
                    rotation: 0
                })
            })
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
                console.log(resolution);
            }
            var style = new ol.style.Style({
                image: new ol.style.Circle({
                    fill: null,
                    stroke: new ol.style.Stroke({
                        color: '#ffff00',
                        width: 2
                    }),
                    points: 4,
                    radius: 10
                }),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 0,
                    offsetY: 0,
                    rotation: 0
                })
            })
            return [style];
        }
    });


    app.config.push({
        label: "Community Irrigation",
        layerId: 'community_irr',
        selectable: true,
        visibility: true,
        type: 'Point',
        legend: 'community-irr-legend',
        collection: app.PointCollection,
        model: app.CommunityIrrModel,
        view: app.CommunityIrrView,
        url: site_url + "edit_new_source/community_irr/" + pid,
        style: function (feature, resolution)
        {
            //if called feature.setstyle() it sends only one parameter resolution
            if (!resolution)
            {
                resolution = feature;
                feature = this;
            }
            var style = new ol.style.Style({
                image: new ol.style.RegularShape({
                    fill: null,
                    stroke: new ol.style.Stroke({
                        color: '#33cc33',
                        width: 2
                    }),
                    points: 4,
                    radius: 10,
                    angle: Math.PI / 4
                }),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#0000FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 0,
                    offsetY: 0,
                    rotation: 0
                })
            })
            return [style];
        },
        selectedStyle: function (feature, resolution)
        {
            if (!resolution)
            {
                resolution = feature;
                feature = this;
                console.log(resolution);
            }
            var style = new ol.style.Style({
                image: new ol.style.RegularShape({
                    fill: null,
                    stroke: new ol.style.Stroke({
                        color: '#ffff00',
                        width: 2
                    }),
                    points: 4,
                    radius: 10,
                    angle: Math.PI / 4
                }),
                text: new ol.style.Text({
                    textAlign: 'left',
                    textBaseline: 'middle',
                    font: '12px Arial',
                    text: getText(feature, resolution),
                    fill: new ol.style.Fill({
                        color: '#3300FF'
                    }),
                    stroke: new ol.style.Stroke({
                        color: '#ffffff',
                        width: 2
                    }),
                    offsetX: 0,
                    offsetY: 0,
                    rotation: 0
                })
            })
            return [style];
        }
    });




    app.layerCollection = new app.LayerCollection();
    _.each(app.config, function (configItem, key, object) {
        app.collection = new configItem.collection(configItem.layerId, configItem.model, configItem.view, configItem.url, configItem.visibility, configItem.selectable, configItem.style, configItem.selectedStyle);
        app.layerCollection.add(
                new app.LayerModel({
                    layer: app.collection,
                    type: "overlay",
                    name: configItem.layerId,
                    label: configItem.label,
                    legend: configItem.legend
                }));
    });
    app.drawView.renderLayersView();
});
var getText = function (feature, resolution) {
    //var type = dom.text.value;
    var maxResolution = 0.6;
    var text = feature.name;
    if (resolution > maxResolution || text === null) {
        text = '';
    }
    /*else if (type == 'hide') {
     text = '';
     } else if (type == 'shorten') {
     text = text.trunc(12);
     } else if (type == 'wrap') {
     text = stringDivider(text, 16, '\n');
     }*/

    return text;
};

app.refresh = function ()
{
    if (app.drawView.countUnsavedItems() > 0)
    {
        if (confirm("There are still unsaved items. Your changes will be lost if you refresh this page without saving. Do you still want to Refresh?"))
        {
            window.location = window.location.href;
        }
    } else
    {
        window.location = window.location.href;
    }
}

