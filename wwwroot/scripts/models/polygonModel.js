var app = app || {};
app.PolygonModel = Backbone.Model.extend({
    defaults: {
        wkt: null
    },
    //used lastchangedSynched http://berzniz.com/post/71312670980/detecting-if-a-backbone-model-needs-to-be-saved
    hasChangedSinceLastSync: false,
    initialize: function () {
        this.listenTo(this, 'change', this.modelChanged);
    },
    modelChanged: function ()
    {
        count_polygon = count_polygon + 1;
        this.hasChangedSinceLastSync = true;
        app.drawView.updateUnsavedItems();
        $("#unsaved_count").html("Unsaved Items: " + (count_polygon));
//        console.log("polygon model changed");
    },
    sync: function (method, model, options) {
        options = options || {};
        var success = options.success;
        options.success = function (resp) {
            success && success(resp);
            model.hasChangedSinceLastSync = false;
        };
        return Backbone.sync(method, model, options);
    }



})
