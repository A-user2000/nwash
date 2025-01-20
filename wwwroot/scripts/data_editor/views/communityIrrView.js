editorApp.CommunityIrrView = Backbone.View.extend({
    template: _.template($("#community-irr-template").html()),
    events: {
        'change .edit': 'prop_changed',
        'click .delete': 'delete_feature',
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
    }
});
