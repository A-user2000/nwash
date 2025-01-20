var editorApp = editorApp || {};
var app = app || {};
editorApp.messageCounter=0;


editorApp.NewSourceCollection = new editorApp.DataCollection("new_source", editorApp.NewSourceModel, editorApp.NewSourceView, site_url + "data/new_source/" + pid);
editorApp.CommunityIrrCollection = new editorApp.DataCollection("community_irr", editorApp.CommunityIrrModel, editorApp.CommunityIrrView, site_url + "data/community_irr/" + pid);
editorApp.CommunityWSCollection = new editorApp.DataCollection("community_ws", editorApp.CommunityWSModel, editorApp.CommunityWSView, site_url + "data/community_ws/" + pid);



var EditorAppView = Backbone.View.extend({
    el: "#editorDiv",
    events: {
        'click .item': 'left_menu_clicked',
        'click #save_new_source': 'save_new_source',
        'click #save_community_irr': 'save_community_irr',
        'click #save_community_ws': 'save_community_ws'
        
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
    save_new_source: function ()
    {
        editorApp.NewSourceCollection.save();
    },
    save_community_irr: function ()
    {
        editorApp.CommunityIrrCollection.save();
    },
    save_community_ws: function ()
    {
        editorApp.CommunityWSCollection.save();
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



