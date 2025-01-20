var app=app ||{};
app.LineModel=Backbone.Model.extend({
    defaults:{
        wkt:null
    },
    //used lastchangedSynched http://berzniz.com/post/71312670980/detecting-if-a-backbone-model-needs-to-be-saved
    hasChangedSinceLastSync:false,    
    //url:site_url+'line/save',
    initialize:function(){
        this.listenTo(this,'change',this.modelChanged);       
    },
    modelChanged:function()
    {
        this.hasChangedSinceLastSync=true;
        app.drawView.updateUnsavedItems();
        console.log("line model changed");
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
