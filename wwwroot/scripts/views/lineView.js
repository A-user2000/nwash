var app = app || {};

app.LineView=Backbone.View.extend({
    template:_.template($("#point-template").html()),
    events:{
        'change .name':'prop_changed'
    },
    initialize: function(layerId) {
        this.layerId=layerId;      
    },
    render:function(){
        this.$el.html( this.template({
            "name":this.model.get("name"),
            "cid":this.model.cid
        }) );
        this.$input = this.$('.name');
        return this;
    },
    prop_changed:function(e)
    {
        console.log(this.model);
        this.model.set("name",$(".name").val());
    }    
});
