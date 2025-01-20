var editorApp = editorApp || {};
var app = app || {};
editorApp.messageCounter=0;
/*editorApp.config = [];
 editorApp.config.push({
 label: "Project",
 collection: app.DataCollection,
 model: app.ProjectModel,
 view: app.ProjectView,
 url: site_url + "data/project/" + pid
 });*/

editorApp.ProjectCollection = new editorApp.DataCollection("project", editorApp.ProjectModel, editorApp.ProjectView, site_url + "data/project/" + pid);
editorApp.TapCollection = new editorApp.DataCollection("tap", editorApp.TapModel, editorApp.TapView, site_url + "data/tap/" + pid);
editorApp.PipeCollection = new editorApp.DataCollection("pipe", editorApp.PipeModel, editorApp.PipeView, site_url + "data/pipe/" + pid);
editorApp.ReservoirCollection = new editorApp.DataCollection("reservoir", editorApp.ReservoirModel, editorApp.ReservoirView, site_url + "data/reservoir/" + pid);
editorApp.SourceCollection = new editorApp.DataCollection("source", editorApp.SourceModel, editorApp.SourceView, site_url + "data/water_source/" + pid);
editorApp.StructureCollection = new editorApp.DataCollection("structure", editorApp.StructureModel, editorApp.StructureView, site_url + "data/structure/" + pid);
editorApp.FunctionalityFrameworkCollection = new editorApp.DataCollection("functionality_framework", editorApp.FunctionalityFrameworkModel, editorApp.FunctionalityFrameworkView, site_url + "data/functionality_framework/" + pid);
editorApp.SustainabilityFrameworkCollection = new editorApp.DataCollection("sustainability_framework", editorApp.SustainabilityFrameworkModel, editorApp.SustainabilityFrameworkView, site_url + "data/sustainability_framework/" + pid);




var EditorAppView = Backbone.View.extend({
    el: "#editorDiv",
    events: {
        'click .item': 'left_menu_clicked',
        'click #save_project': 'save_project',
        'click #save_functionality_framework': 'save_functionality_framework',
        'click #save_sustainability_framework': 'save_sustainability_framework',
        'click #save_tap': 'save_tap',
        'click #save_pipe': 'save_pipe',
        'click #save_reservoir': 'save_reservoir',
        'click #save_source': 'save_source',
        'click #save_structure': 'save_structure',
    },
    initialize: function () {

    },
    left_menu_clicked: function (el)
    {
        console.log(el.target.rel);
        $("#left_div .item.active").removeClass('active');
        $("#right_div .tab-content").hide();
        $(el.target).addClass('active');
        var content_tab = el.target.rel + "_tab";
        $("#" + content_tab).show();
    },
    save_project: function ()
    {
        editorApp.ProjectCollection.save();
    },
    save_functionality_framework: function ()
    {
        editorApp.FunctionalityFrameworkCollection.save();
    },
    save_sustainability_framework: function ()
    {
        editorApp.SustainabilityFrameworkCollection.save();
    },
    save_tap: function ()
    {
        editorApp.TapCollection.save();
    },
    save_pipe: function ()
    {
        editorApp.PipeCollection.save();
    },
    save_reservoir: function ()
    {
        editorApp.ReservoirCollection.save();
    },
    save_source: function ()
    {
        editorApp.SourceCollection.save();
    },
    save_structure: function ()
    {
        editorApp.StructureCollection.save();
    },
    write_status_message: function (savedStatus)
    {
        var cssClass = "ui negative message";
        var target = "status_message_" + editorApp.messageCounter;
        if (savedStatus.success)
        {
            cssClass = "ui positive message";
        }
        var message = '<p id="' + target + '" class="' + cssClass + '" style="text-align:center;"><strong>' + savedStatus.message + '</strong></p>';
        $("#status_message").append(message);
        editorApp.messageCounter++;
        $("#" + target).fadeOut(7000, function () {
            $(this).remove();
        });
    }
});


var editorAppView = new EditorAppView();



