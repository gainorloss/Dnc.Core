using DncAspNetCore.Admin.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DncAspNetCore.Admin.Admin.Infrastructure.TagHelpers
{
    [HtmlTargetElement("layui-data-grid")]
    public class LayUIDataGridTagHelper
        : TagHelper
    {
        [HtmlAttributeName("items")]
        public List<LayUIDataGridItem> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var sb = new StringBuilder();

            var qs = Items.Where(i => i.Type != null && i.Type.Equals("q"));
            var rs = Items.Where(i => i.Type != null && i.Type.Equals("r"));

            #region html.
            sb.AppendLine(@"            <div class='layui-fluid'>");
            sb.AppendLine(@"    <div class='layui-card'>");
            sb.AppendLine(@"        <div class='layui-form layui-card-header layuiadmin-card-header-auto'>");
            sb.AppendLine(@"            <div class='layui-form-item'>");
            sb.AppendLine(@"                搜索：");
            sb.AppendLine(@"                <div class='layui-inline'>");
            sb.AppendLine(@"                    <input type='text' name='name' placeholder='请输入' autocomplete='off' class='layui-input'>");
            sb.AppendLine(@"                </div>");
            sb.AppendLine(@"                <div class='layui-inline'>");
            sb.AppendLine(@"                    <button class='layui-btn layuiadmin-btn-useradmin' lay-submit lay-filter='dataGrid-query' id='dataGrid-query'>搜索</button>");
            sb.AppendLine(@"                </div>");
            sb.AppendLine(@"            </div>");
            sb.AppendLine(@"        </div>");
            sb.AppendLine(@"");
            sb.AppendLine(@"        <div class='layui-card-body'>");
            sb.AppendLine(@"            <script type='text/html' id='tool'>");
            sb.AppendLine(@"                <div class='layui-btn-group layui-btn-container'>");
            if (rs != null && rs.Any())
            {
                foreach (var r in rs)
                    sb.AppendLine($@"                    <a class='layui-btn layui-btn-xs layui-btn-primary' lay-event='{r.Name}'>{r.Name}</a>");
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"                </div>");
            sb.AppendLine(@"            </script>");
            sb.AppendLine(@"            <script type='text/html' id='toolbar'>");
            sb.AppendLine(@"                <div class='layui-btn-group layui-btn-container'>");
            if (qs != null && qs.Any())
            {
                foreach (var q in qs)
                    sb.AppendLine($@"                    <button class='layui-btn layui-btn-sm' lay-event='{q.Name}'>{q.Name}</button>");
            }
            sb.AppendLine(@"                </div>");
            sb.AppendLine(@"            </script>");
            sb.AppendLine(@"            <table id='dataGrid' lay-filter='dataGrid'></table>");
            sb.AppendLine(@"        </div>");
            sb.AppendLine(@"    </div>");
            sb.AppendLine(@"</div>");
            sb.AppendLine(@"<script>");
            sb.AppendLine(@"    var dataGrid = {");
            sb.AppendLine(@"        init: function (paras) {");
            sb.AppendLine(@"            var self = this;");
            sb.AppendLine(@"     var opts = para.opts;");
            sb.AppendLine(@"for(var k in items) {");
            sb.AppendLine(@"var item = items[k];");
            sb.AppendLine(@"for (var i in opts) {");
            sb.AppendLine(@"    var opt = opts[i];");
            sb.AppendLine(@"    if (opt.name === item.name) {");
            sb.AppendLine(@"        for (var j in opt) {");
            sb.AppendLine(@"            if (opt[j]) {");
            sb.AppendLine(@"                item[j] = opt[j];");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");
            sb.AppendLine(@"}");
            sb.AppendLine(@" para.opts = items;");
            sb.AppendLine(@"            self.data = paras;");
            sb.AppendLine(@"            self.render();");
            sb.AppendLine(@"        },");
            sb.AppendLine(@"        data: {},");
            sb.AppendLine(@"        render: function () {");
            sb.AppendLine(@"            var self = this;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (self.data.cols) {");
            sb.AppendLine(@"                for (var i in self.data.cols) {");
            sb.AppendLine(@"                    self.data.cols[i].sort = true;");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            self.data.cols.unshift({ field: 'id', title: '序号', width: 80, type: 'numbers' });//序号");
            sb.AppendLine(@"            self.data.cols.unshift({ type: 'checkbox', fixed: 'left', align: 'center' });//复选框");
            sb.AppendLine(@"            self.data.cols.push({ title: '操作', width: 300,align: 'center', fixed: 'right', toolbar: '#tool' });//filter:tool的行工具栏");
            sb.AppendLine(@"");
            sb.AppendLine(@"            var queryUrl = self.data.opts.filter(function (item, index) {");
            sb.AppendLine(@"                return item.name === '搜索';");
            sb.AppendLine(@"            })[0].url;//获取dataGrid加载url");
            sb.AppendLine(@"");
            sb.AppendLine(@"            var qs = self.data.opts.filter(function (item, index) {");
            sb.AppendLine(@"                return item.type === 'q';");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"            var rs = self.data.opts.filter(function (item, index) {");
            sb.AppendLine(@"                return item.type === 'r';");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"            layui.config({");
            sb.AppendLine(@"                base: '/lib/layuiadmin/' //静态资源所在路径");
            sb.AppendLine(@"            }).extend({");
            sb.AppendLine(@"                index: 'lib/index' //主入口模块");
            sb.AppendLine(@"            }).use('index');");
            sb.AppendLine(@"            layui.use(['table', 'form'], function () {");
            sb.AppendLine(@"                var table = layui.table;");
            sb.AppendLine(@"                var form = layui.form;");
            sb.AppendLine(@"                var $ = layui.$;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                //第一个实例");

            #region 表格渲染
            sb.AppendLine(@"                table.render({");
            sb.AppendLine(@"                    elem: '#dataGrid'");
            sb.AppendLine(@"                    , toolbar: '#toolbar'");
            sb.AppendLine(@"                    , url: queryUrl");
            sb.AppendLine(@"                    , done: function (res, curr, count) { //表格数据加载完后的事件");
            sb.AppendLine(@"             //调用示例");
            sb.AppendLine(@"             layer.photos({//点击图片弹出");
            sb.AppendLine(@"                 photos: '.layer-photos-avatar'");
            sb.AppendLine(@"                 , anim: 1 //0-6的选择，指定弹出图片动画类型，默认随机（请注意，3.0之前的版本用shift参数）");
            sb.AppendLine(@"             });");
            sb.AppendLine(@"         }");
            sb.AppendLine(@"                    , cols: [self.data.cols]");
            sb.AppendLine(@"                    , page: true");
            sb.AppendLine(@"                    , limit: 30");
            sb.AppendLine(@"                    , text: '对不起，加载出现异常！'");
            sb.AppendLine(@"                    , size: 'sm'");
            sb.AppendLine(@"                    , unresize: true");
            sb.AppendLine(@"                    , title: '列表'");
            sb.AppendLine(@"                });");
            sb.AppendLine(@""); 
            #endregion

            #region 全局工具条
            sb.AppendLine(@"                table.on('toolbar(dataGrid)', function (obj) {");
            sb.AppendLine(@"                    var checkStatus = table.checkStatus(obj.config.id);");
            sb.AppendLine(@"                    console.log(JSON.stringify(checkStatus));");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    if (!qs)");
            sb.AppendLine(@"                        return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    for (var i in qs) {");
            sb.AppendLine(@"                        if (obj.event != qs[i].name)");
            sb.AppendLine(@"                            continue;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                        if (!qs[i].pageUrl) {");
            sb.AppendLine(@"                            layer.msg(qs[i].name);");
            sb.AppendLine(@"                            return;");
            sb.AppendLine(@"                        }");
            sb.AppendLine(@"                        if (!qs[i].url) {");
            sb.AppendLine(@"                            layer.open({");
            sb.AppendLine(@"                                type: 2");
            sb.AppendLine(@"                                , title: qs[i].name");
            sb.AppendLine(@"                                , content: rs[i].pageUrl");
            sb.AppendLine(@"                                , maxmin: true");
            sb.AppendLine(@"                                , area: ['500px', '400px']");
            sb.AppendLine(@"                            });");
            sb.AppendLine(@"                            break;");
            sb.AppendLine(@"                        }");
            sb.AppendLine(@"                        layer.open({");
            sb.AppendLine(@"                            type: 2");
            sb.AppendLine(@"                            ,title:qs[i].name");
            sb.AppendLine(@"                            , content: qs[i].pageUrl");
            sb.AppendLine(@"                            , shadeClose: true");
            sb.AppendLine(@"                            , maxmin: true");
            sb.AppendLine(@"                            , area: ['500px', '400px']");
            sb.AppendLine(@"                            , btn: ['立即提交', '取消']");
            sb.AppendLine(@"                            , yes: function(index, layero) {");
            sb.AppendLine(@"                                var iframeWindow = window['layui-layer-iframe' + index]");
            sb.AppendLine(@"                                    , submitID = 'LAY-user-front-submit'");
            sb.AppendLine(@"                                    , submit = layero.find('iframe').contents().find('#' + submitID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                                //监听提交");
            sb.AppendLine(@"                                iframeWindow.layui.form.on('submit(' + submitID + ')', function (data) {");
            sb.AppendLine(@"                                    var field = data.field; //获取提交的字段");
            sb.AppendLine(@"");
            sb.AppendLine(@"                                    //提交 Ajax 成功后，静态更新表格中的数据");
            sb.AppendLine(@"                                    $.ajax({");
            sb.AppendLine(@"                                        type: 'post',");
            sb.AppendLine(@"                                        url: qs[i].url,");
            sb.AppendLine(@"                                        data: field,");
            sb.AppendLine(@"                                        success: function (data) {");
            sb.AppendLine(@"                                            if (data.success) {");
            sb.AppendLine(@"                                                $('#dataGrid-query').trigger('click');");
            sb.AppendLine(@"                                            }");
            sb.AppendLine(@"                                        }");
            sb.AppendLine(@"                                    });");
            sb.AppendLine(@"                                    layer.close(index); //关闭弹层");
            sb.AppendLine(@"                                });");
            sb.AppendLine(@"                                submit.trigger('click'); ");
            sb.AppendLine(@"                            }");
            sb.AppendLine(@"                        });");
            sb.AppendLine(@"                        break;");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                });");
            sb.AppendLine(@""); 
            #endregion

            #region 行内工具条
            sb.AppendLine(@"                //监听工具条");
            sb.AppendLine(@"                table.on('tool(dataGrid)', function (obj) {");
            sb.AppendLine(@"                    var data = obj.data;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    if (!rs)");
            sb.AppendLine(@"                        return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    for (var i in rs) {");
            sb.AppendLine(@"                        if (obj.event != rs[i].name)");
            sb.AppendLine(@"                            continue;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                        if (!rs[i].pageUrl) {");
            sb.AppendLine(@"                            layer.confirm('确定吗', function (index) {");
            sb.AppendLine(@"                                $.ajax({");
            sb.AppendLine(@"                                    type: 'delete',");
            sb.AppendLine(@"                                    url: rs[i].url,");
            sb.AppendLine(@"                                    data: { 'id': data.id},");
            sb.AppendLine(@"                                    success: function (data) {");
            sb.AppendLine(@"                                        if (data.success) {");
            sb.AppendLine(@"                                            $('#dataGrid-query').trigger('click');");
            sb.AppendLine(@"                                        }");
            sb.AppendLine(@"                                    }");
            sb.AppendLine(@"                                });");
            sb.AppendLine(@"                                layer.close(index);");
            sb.AppendLine(@"                            });");
            sb.AppendLine(@"                            break;");
            sb.AppendLine(@"                        }");
            sb.AppendLine(@"                        var tr = $(obj.tr);");
            sb.AppendLine(@"                        if (rs[i].target && rs[i].target === 'blank')");
            sb.AppendLine(@"                        {");
            sb.AppendLine(@"                            var topLayui = parent === self ? layui : top.layui;");
            sb.AppendLine(@"                            topLayui.index.openTabsPage(rs[i].pageUrl+'?_id='+data.id, rs[i].name+ ''+data.id , window.parent.document);");
            sb.AppendLine(@"                            break;");
            sb.AppendLine(@"                        }");
            sb.AppendLine(@"                        layer.open({");
            sb.AppendLine(@"                            type: 2");
            sb.AppendLine(@"                            ,title:rs[i].name");
            sb.AppendLine(@"                            , content: rs[i].pageUrl");
            sb.AppendLine(@"                            , shadeClose: true");
            sb.AppendLine(@"                            , maxmin: true");
            sb.AppendLine(@"                            , area: ['500px', '400px']");
            sb.AppendLine(@"                            , btn: ['立即提交', '取消']");
            sb.AppendLine(@"                            , yes: function(index, layero) {");
            sb.AppendLine(@"                                var iframeWindow = window['layui-layer-iframe' + index]");
            sb.AppendLine(@"                                    , submitID = 'LAY-user-front-submit'");
            sb.AppendLine(@"                                    , submit = layero.find('iframe').contents().find('#' + submitID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                                //监听提交");
            sb.AppendLine(@"                                iframeWindow.layui.form.on('submit(' + submitID + ')', function (form) {");
            sb.AppendLine(@"                                    form.field.id = data.id;");
            sb.AppendLine(@"                                    var field = form.field; //获取提交的字段");
            sb.AppendLine(@"");
            sb.AppendLine(@"                                    //提交 Ajax 成功后，静态更新表格中的数据");
            sb.AppendLine(@"                                    $.ajax({");
            sb.AppendLine(@"                                        type: 'PUT',");
            sb.AppendLine(@"                                        url: rs[i].url,");
            sb.AppendLine(@"                                        data: field,");
            sb.AppendLine(@"                                        success: function (data) {");
            sb.AppendLine(@"                                            if (data.success) {");
            sb.AppendLine(@"                                                $('#dataGrid-query').trigger('click');");
            sb.AppendLine(@"                                            }");
            sb.AppendLine(@"                                        }");
            sb.AppendLine(@"                                    });");
            sb.AppendLine(@"                                    layer.close(index); //关闭弹层");
            sb.AppendLine(@"                                });");
            sb.AppendLine(@"");
            sb.AppendLine(@"                                submit.trigger('click'); ");
            sb.AppendLine(@"                            }");
            sb.AppendLine(@"                            , success: function (layero, index) {");
            sb.AppendLine(@"                                var container = layero.find('iframe')[0].contentWindow.document;");
            sb.AppendLine(@"                                layer.setTop(layero); //重点2，窗体显示最前");
            sb.AppendLine(@"                                if (!rs[i].cb)");
            sb.AppendLine(@"                                    return;");
            sb.AppendLine(@"                                rs[i].cb($,layui.form, container, data);");
            sb.AppendLine(@"                            }");
            sb.AppendLine(@"                        });");
            sb.AppendLine(@"                        break;");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                });");
            sb.AppendLine(@""); 
            #endregion

            sb.AppendLine(@"                //监听搜索");
            sb.AppendLine(@"                form.on('submit(dataGrid-query)', function (data) {");
            sb.AppendLine(@"                    var field = data.field;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    //执行重载");
            sb.AppendLine(@"                    table.reload('dataGrid', {");
            sb.AppendLine(@"                        where: field");
            sb.AppendLine(@"                    });");
            sb.AppendLine(@"                });");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"    };");
            sb.AppendLine(@"</script>");
            #endregion

            output.Content.AppendHtml(sb.ToString()); ;
        }
    }
}
