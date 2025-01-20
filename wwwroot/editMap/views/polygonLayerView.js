var app = app || {};
function ajax11() {
    return $.ajax({
        type: 'POST',
        data: { pName: "nwash", group: layerGroupName },
        url: siteurl + 'Draw/GetGroupLayers',
        dataType: 'json',
        success: function (data) {
            layers_list = data;
        },
        error: function () {
            alert("error polygon");
        }

    });
}
$.when(ajax11()).done(function (layers_list) {
    layers_list.forEach(function (la) {
        if (la.obj_type == "polygon") {
        var xx = la.tbl_name;
        var xy = xx.split(".")[1];
app.PolygonLayerView = Backbone.View.extend({
template: _.template($("#"+xy).html()),
    events: {
        'change .edit': 'prop_changed',
        'click .delete': 'delete_feature',
        'click #delete_attributes': 'delete_feature',
    },
    initialize: function (layerId) {
        this.layerId = layerId;
    },
    render: function () {
        var obj = clone(this.model.attributes);
        obj.cid = this.model.cid;
        this.$el.html(this.template(obj));
        this.$input = this.$('.name');
        this.$('#the_geom').text(obj.wkt);
        this.$('#pro_uuid').val(pid);
        this.$('#edited_on').val(addDate);
        this.$('#edited_by').val(addBy);
        this.$('#data_year').val(addDate.split("-")[0]);
        return this;
    },
    prop_changed: function (e)
    {
        this.model.set(e.target.name, e.target.value);
        //this.model.setFeatureAttributes(this.model.feature);
    },
    delete_feature: function (e)
    {
        if (confirm("Are you sure you want to delete this polygon?"))
        {
            this.model.delete_feature();
        }
    }
});
        }
    });
});