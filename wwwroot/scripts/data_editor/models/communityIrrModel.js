editorApp.CommunityIrrModel = Backbone.Model.extend({
    defaults: {},
    initialize: function () {
        this.listenTo(this, 'change', this.model_changed);
    },
    sync: function (method, model, options) {
        options = options || {};
        var success = options.success;
        options.success = function (resp) {
            success && success(resp);
            model.hasChangedSinceLastSync = false;
            var message = {"layer": "Community Irrigation MOdel", "success": true, "message": "Community Irrigation Saved Successfully."};
            editorAppView.write_status_message(message);

        };
        options.error = function (resp)
        {
            console.log(resp);
            var message = {"layer": "New Source", "success": false, "message": "Error  Saving Community Irrigation."};
            //app.writeStatusMessage(message);
        }
        return Backbone.sync(method, model, options);
    },
    get_defaults: function (merge_obj)
    {
        var attrs = clone(project_attrs);
        for (var attr in merge_obj)
        {
            attrs[attr] = merge_obj[attr];
        }
        return attrs;

    },
    model_changed: function ()
    {
        this.hasChangedSinceLastSync = true;
    }

});