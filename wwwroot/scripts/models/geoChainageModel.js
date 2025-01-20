app.GeoChainageModel=app.PointModel.fullExtend({
    defaults:{
        pcode:null,
        canal_name:null,
        chainage:null,
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
        var chainage=this.get('chainage');
        var prefix=Math.floor(chainage/1000);
        var suffix=Math.abs(prefix*1000-chainage);
        suffix=suffix.toFixed(0);
        suffix=suffix==0?"000":suffix;
        var chainage_text=prefix+"+"+suffix;
        feature.name=chainage_text;
    }
});