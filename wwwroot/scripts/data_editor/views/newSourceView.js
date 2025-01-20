editorApp.NewSourceView = Backbone.View.extend({
    template: _.template($("#new-source-template").html()),
    events: {
        'change .edit': 'prop_changed',
        'click .delete': 'delete_feature',
        'click .save':'save'
    },
    initialize: function () {
      
    },
    render: function () {
        var obj = clone(this.model.attributes);
        this.$el.html(this.template(obj));
        //this.$input = this.$('.name');
        return this;
    },
    prop_changed: function (e)
    {
        this.model.set(e.target.name, e.target.value);
    },
    save:function(e)
    {
        this.model.collection.save();
    }
    
});
