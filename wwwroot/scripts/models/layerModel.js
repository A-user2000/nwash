var app=app ||{};
app.LayerModel=Backbone.Model.extend({
    defaults:{
        layer:null,
        type:null,
        name:null
    },
    initialize:function(){
             
    },
    sync: function(method, model, options) {
        options = options || {};
        var success = options.success;
        options.success = function(resp) {
            success && success(resp);
            model.hasChangedSinceLastSync = false;
        };
        return Backbone.sync(method, model, options);
    }
})
