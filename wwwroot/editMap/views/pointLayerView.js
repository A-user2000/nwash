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
            alert("error point");
        }

    });
}
$.when(ajax11()).done(function (layers_list) {
    layers_list.forEach(function (la) {
        var xx = la.tbl_name;
        var xy = xx.split(".")[1];
app.PointLayerView = Backbone.View.extend({
    template: _.template($("#tap").html()),
    template1: _.template($("#project_details").html()),
    template2: _.template($("#reservoir").html()),
    template3: _.template($("#structure").html()),
    template4: _.template($("#water_source").html()),
    template5: _.template($("#junction").html()),
    template6: _.template($("#leftout_taps").html()),
    events: {
        'change .edit': 'prop_changed',
        'click .delete': 'delete_feature',
        'click #delete_attributes': 'delete_feature',
    },
    initialize: function (layerId) {
        this.layerId = layerId;
    },
    render: function () {
        if (this.model.get("wkt") != null && this.model.get("wkt") != "") {
            var obj = clone(this.model.attributes);
            obj.cid = this.model.cid;
            var lId = this.model.collection.layerId;
            if (lId == "existing_projects.tap") {
                this.$el.html(this.template(obj));
                //this.$input = this.$('.name');
                //this.$('#geom').text(obj.wkt);
            }
            else if (lId == "existing_projects.project_details") {
                this.$el.html(this.template1(obj));

                this.$input = this.$('.name');
                this.$('#the_geom').text(obj.wkt);
                this.$('#edited_on').val(addDate);
                this.$('#edited_by').val(addBy);
                this.$('#lat').val(obj.lat);
                this.$('#lon').val(obj.lon);
                this.$('#data_year').val(addDate.split("-")[0]);
                if (obj.uuid == null || obj.uuid == "") {
                    this.$('#uuid').val(crypto.randomUUID());
                }

                //this.$input = this.$('.name');
                //this.$('#geom').text(obj.wkt);
            }
            else if (lId == "existing_projects.reservoir") {
                this.$el.html(this.template2(obj));
                //this.$input = this.$('.name');
                //this.$('#geom').text(obj.wkt);
            }
            else if (lId == "existing_projects.structure") {
                this.$el.html(this.template3(obj));
                //this.$input = this.$('.name');
                //this.$('#geom').text(obj.wkt);
            }
            else if (lId == "existing_projects.water_source") {
                this.$el.html(this.template4(obj));
                //this.$input = this.$('.name');
                //this.$('#geom').text(obj.wkt);
            }
            else if (lId == "existing_projects.junction") {
                this.$el.html(this.template5(obj));
                //this.$input = this.$('.name');
                //this.$('#geom').text(obj.wkt);
            }
            else if (lId == "existing_projects.leftout_taps") {
                this.$el.html(this.template6(obj));
                //this.$input = this.$('.name');
                //this.$('#geom').text(obj.wkt);
            }
            if (lId != "existing_projects.project_details") {
                this.$input = this.$('.name');
                this.$('#the_geom').text(obj.wkt);
                this.$('#pro_uuid').val(pid);
                this.$('#edited_on').val(addDate);
                this.$('#edited_by').val(addBy);
                this.$('#lat').val(obj.lat);
                this.$('#lon').val(obj.lon);
                this.$('#data_year').val(addDate.split("-")[0]);
                if (obj.uuid == null || obj.uuid == "") {
                    this.$('#uuid').val(crypto.randomUUID());
                }
            }
            return this;
        }
    },
    prop_changed: function (e)
    {
        this.model.set(e.target.name, e.target.value);
        this.model.setFeatureAttributes(this.model.feature);
    },
    delete_feature: function (e)
    {
        if (confirm("Are you sure you want to delete this point?"))
        {
            this.model.delete_feature();
        }
    }
});
        //}
    });
});