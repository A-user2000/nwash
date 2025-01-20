var app = app || {};

app.GeoIntakeView = Backbone.View.extend({
    template: _.template($("#geointake-template").html()),
    events: {
        'change .edit': 'prop_changed',
        'click .delete': 'delete_feature'
    },
    initialize: function (layerId) {
        this.layerId = layerId;
    },
    render: function () {
        var obj = clone(this.model.attributes);
        obj.cid = this.model.cid;
        this.$el.html(this.template(obj));
        this.$input = this.$('.name');
        return this;
    },
    prop_changed: function (e)
    {
        this.model.set(e.target.name, e.target.value);
        this.model.setFeatureAttributes(this.model.feature);
    },
    delete_feature: function (e)
    {
        if (confirm("Are you sure you want to delete this Intake?"))
        {
           this.model.delete_feature();
        }
    }
});
