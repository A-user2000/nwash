var app=app||{};
app.BaseCollection=Backbone.Collection.extend({
    defaults:{
        name:""
    },
    initialize:function(){
        //alert("parent init");
    },
    hello:function()
    {
        alert("hello I am parent");
    }
});

app.ChildCollection=app.BaseCollection.extend({
    defaults:{
        name:"child"
    },
    initialize:function(){
        this.parent=app.ChildCollection.__super__;
        this.parent.initialize.call(this);
        //alert("child init");
        
    },
    hello:function()
    {
        alert("Hello I am Child");
    }
});
//parent= new app.BaseCollection();
child= new app.ChildCollection();