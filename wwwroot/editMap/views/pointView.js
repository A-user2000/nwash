var app = app || {};
app.PointView=Backbone.View.extend({
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
        //console.log(this);
        return this;
    },
    prop_changed:function(e)
    {
        this.model.set("name",$(".name").val());
    }

    
});
