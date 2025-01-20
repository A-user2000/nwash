app.GeoCanalPointModel=app.PointModel.fullExtend({
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
        var chainage_text=this.get("chainage");
        feature.name=chainage_text;
    },
    get_defaults: function (merge_obj)
    {
        var attrs = clone(geo_intake_attrs);
        for (var attr in merge_obj)
        {
            attrs[attr] = merge_obj[attr];
        }
        return attrs;
    }
});