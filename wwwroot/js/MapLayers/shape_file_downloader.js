/**
 * 27th May,2016
 * Prabin Shrestha
 * shprabin@gmail.com
 * Softwel Pvt Ltd.
 */
var shape_file_tool = {
    geoserver_url: "http://geoserver.aviyaan.com/geoserver",
    themes: {},
    workspaces: {},
    layerGroups: [],
    layerGroupCount: 0,
    layerGroupCounter: 0,
    init: function () {
        $("#shapefile-tool-draggable").show();
        this.layerGroupCount = 0;
        this.layerGroupCounter = 0;
        this.get_all_layers();
    },
    close: function ()
    {
        $("#shapefile-tool-draggable").hide();

    },
    get_all_layers: function ()
    {
        //Deep copy of themes
        var ignoreThemes = ['googleTheme'];
        this.themes = jQuery.extend(true, {}, Themes);
        this.remove_ignored_themes(ignoreThemes);
        this.find_workspaces_in_all_layers();
        this.find_layergroups_in_workspaces();
    },
    generate_shape_file_link: function ()
    {
        html = "";
        var allThemes = this.themes.themesArr;
        for (var i = 0; i < allThemes.length; i++)
        {
            //start 1.ul 1.li
            html += i == 0 ? "<ul id=\"shapefile-treeview\"><li>" : "<li>";

            var theme = allThemes[i];
            html += "<strong>" + theme.title + "</strong>";
            var _layerGroup = theme.layerGroup;
            var layers = _layerGroup.getLayers();
            for (var j = 0; j < layers.length; j++)
            {   //start 2.ul 2.li
                html += j == 0 ? "<ul><li>" : "<li>";
                var layerObj = layers[j];
                var layer_label = layerObj.name;
                html += layer_label;
                //layerscommaseperated=layer.params.LAYERS
                var layer = layerObj.params.LAYERS;
                var cqlFilter = "";
                if (layerObj.params.hasOwnProperty("CQL_FILTER"))
                {
                    cqlFilter = "&CQL_FILTER=" + layerObj.params.CQL_FILTER;
                }
                var layerarr = layer.split(",");
                html += "<ul>";
                for (var k = 0; k < layerarr.length; k++)
                {
                    var eachLayer = layerarr[k];
                    //if layer is a layergroup in geoserver list its layer
                    var is_layer_group = this.is_a_layer_group(eachLayer);
                    if (is_layer_group > -1)
                    {
                        // add all layers in geoserver layergroup
                        html += this.add_geoserver_layergroup_layers(is_layer_group, cqlFilter);

                    } else {
                        html += "<li>";
                        var layerName = this.get_layer_name_only(eachLayer);
                        var url = this.geoserver_url + "/ows?service=WFS&version=1.0.0&request=GetFeature&typeName=" + eachLayer + "&outputFormat=SHAPE-ZIP" + cqlFilter;
                        html += '<a class="btn btn-success btn-xs" href="' + url + '">Download ' + layerName + "</a>";
                        html += '</li>';
                    }
                }
                html += '</ul>';
                //close 2.li
                html += "</li>";

            }
            //close 2.ul
            html += '</ul>';
            //close 1.li
            html += "</li>";
        }
        // close 1.ul
        html += '</ul>';
        $("#shapefile-tool-draggable .content").html(html);
        $("#shapefile-treeview").bonsai();
    },
    get_layer_name_only: function (fullLayerName) {
        //fullname="workspacename:layername"
        var arr = fullLayerName.split(':');
        if (typeof arr[1] === 'undefined') {
            return "invalid layer";
        } else
        {
            return arr[1];
        }
    },
    is_a_layer_group: function (_layer)
    {
        for (var v = 0; v < this.layerGroups.length; v++)
        {
            var layerGroup = this.layerGroups[v];
            if (layerGroup.layer == _layer)
                return v;
        }
        return -1;
    },
    add_geoserver_layergroup_layers: function (index, cqlFilter)
    {
        var html = "";
        var obj = this.layerGroups[index];
        var workspace = obj.layergroup.layerGroup.workspace.name;
        var layers_arr = obj.layergroup.layerGroup.publishables.published;
        for (var x = 0; x < layers_arr.length; x++)
        {
            var layer = layers_arr[x];
            html += "<li>";
            var layerName = layer.name;
            var fullLayerName = workspace + ":" + layerName;
            var url = this.geoserver_url + "/ows?service=WFS&version=1.0.0&request=GetFeature&typeName=" + fullLayerName + "&outputFormat=SHAPE-ZIP" + cqlFilter;
            html += '<a class="btn btn-success btn-xs" href="' + url + '">Download ' + layerName + "</a>";
            html += '</li>';
        }
        return html;
    },
    remove_ignored_themes: function (ignoreThemes)
    {
        for (var i = 0; i < ignoreThemes.length; i++)
        {
            var ignoreThisTheme = ignoreThemes[i];
            for (var j = 0; j < this.themes.themesArr.length; j++)
            {
                var theme = this.themes.themesArr[i];
                if (theme.objName == ignoreThisTheme)
                {
                    this.themes.themesArr.splice(j, 1);
                }
            }
        }
    },
    find_workspaces_in_all_layers: function ()
    {
        for (var x = 0; x < this.themes.themesArr.length; x++)
        {
            var theme = this.themes.themesArr[x];
            var layerGroupLayers = theme.layerGroup.getLayers();
            for (var i = 0; i < layerGroupLayers.length; i++)
            {
                var layer = layerGroupLayers[i];
                //A layer can have multiple layers comma seperated
                var layer = layer.params.LAYERS;
                var layerarr = layer.split(",");
                for (var j = 0; j < layerarr.length; j++)
                {
                    var eachLayer = layerarr[j];
                    var eachLayerArr = eachLayer.split(':');
                    if (eachLayerArr[1])
                    {
                        var workspace = eachLayerArr[0];
                        this.workspaces[workspace] = workspace;
                    }

                }
            }
        }
    },
    find_layergroups_in_workspaces: function ()
    {
        var that = this;
        //clear layerGroups array
        this.layerGroups = [];
        for (var ws in this.workspaces)
        {
            $.ajax({
                type: "POST",
                url: baseurl + "geoserver/getWorkspaceLayergroups/" + ws,
                data: "",
                workspace: ws,
                success: function (result) {
                    result = $.parseJSON(result);
                    //console.log(result);
                    if (result.layerGroups != "")
                    {
                        that.layerGroupCount += result.layerGroups.layerGroup.length;
                        for (var i = 0; i < result.layerGroups.layerGroup.length; i++)
                        {
                            obj = result.layerGroups.layerGroup[i];
                            var layergroup = obj.name;
                            that.get_layers_list_in_layergroups(this.workspace, layergroup)
                        }
                    }
                }

            });
        }
    },
    get_layers_list_in_layergroups: function (workspace, layergroup)
    {
        var that = this;
        $.ajax({
            type: "POST",
            url: baseurl + "geoserver/getLayersinLayerGroups/" + workspace + "/" + layergroup,
            data: "",
            workspace: workspace,
            layergroup: layergroup,
            success: function (result) {
                result = $.parseJSON(result);
                that.layerGroupCounter++;
                var layer = this.workspace + ":" + this.layergroup;
                that.layerGroups.push({"layer": layer, "layergroup": result});
                if (that.layerGroupCounter == that.layerGroupCount)
                {
                    console.log(that.layerGroups);
                    //After All request are completed call generate_shape_file_link function
                    that.generate_shape_file_link();
                }
            }

        });
    }
};
