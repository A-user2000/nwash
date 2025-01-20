app.GeoCommandareaPointModel=app.PointModel.fullExtend({
    defaults:{
    },
    initialize:function(){
        this.parent=app.ChildCollection.__super__;
        this.parent.initialize.call(this);
        this.listenTo(this,'change',this.modelChanged);
    },
    setFeatureAttributes:function(feature)
    {
         feature.setId(this.cid);
        var chainage_text=this.get("point_type");
        feature.name=chainage_text;
    }
});