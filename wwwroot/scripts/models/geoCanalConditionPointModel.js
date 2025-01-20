app.GeoCanalConditionPointModel=app.PointModel.fullExtend({
    defaults:{
        pcode:null,
        wkt:null
    },
    initialize:function(){
        this.parent=app.ChildCollection.__super__;
        this.parent.initialize.call(this);
        this.listenTo(this,'change',this.modelChanged);
    },
    setFeatureAttributes:function(feature)
    {
        feature.setId(this.cid);
        //feature.name=this.get('stype');
    }


});