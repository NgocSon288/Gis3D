#pragma checksum "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e24ab289fa6c230ce0496585a1634b6c8d13ea4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Line_Create), @"mvc.1.0.view", @"/Views/Line/Create.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
using WebApp.ViewModels.Lines;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
using WebApp.ViewModels.LineTypeOptions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e24ab289fa6c230ce0496585a1634b6c8d13ea4", @"/Views/Line/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Line_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LineCreateRequest>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("line-type"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
  
    var lineTypeOptions = ViewBag.lineTypeOptions as List<LineTypeOptionViewModel>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>Tạo Line</h1>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-10 mx-auto\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e24ab289fa6c230ce0496585a1634b6c8d13ea45981", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 17 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
             if (ViewBag.isShow)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div");
                BeginWriteAttribute("class", " class=\"", 392, "\"", 451, 3);
                WriteAttributeValue("", 400, "alert", 400, 5, true);
                WriteAttributeValue(" ", 405, "alert-", 406, 7, true);
#nullable restore
#line 19 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 412, ViewBag.isSuccess?"success":"danger", 412, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" role=\"alert\">\r\n                    ");
#nullable restore
#line 20 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
               Write(ViewBag.message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 22 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <div class=\"form-group row\">\r\n                <label class=\"control-label col-3\"><strong>Chọn type line</strong></label>\r\n                <div class=\"col-9\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e24ab289fa6c230ce0496585a1634b6c8d13ea47740", async() => {
                    WriteLiteral("\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 27 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.LineTypeId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 27 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.lineTypes;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"form-group row\">\r\n                <label class=\"control-label col-3\"><strong>Chọn body</strong></label>\r\n                <div class=\"col-9\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e24ab289fa6c230ce0496585a1634b6c8d13ea410181", async() => {
                    WriteLiteral("\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 35 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BodyId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 35 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.bodies;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"form-group row\">\r\n                <label class=\"control-label col-3\"><strong>Chọn mức độ chi tiết</strong></label>\r\n                <div class=\"col-9\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e24ab289fa6c230ce0496585a1634b6c8d13ea412540", async() => {
                    WriteLiteral("\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 43 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Lod);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 43 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.lods;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n\r\n            <div class=\"form-group row\">\r\n                <label class=\"control-label col-3\"><strong>Mô tả - Metadata</strong></label>\r\n                <div class=\"col-9\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4e24ab289fa6c230ce0496585a1634b6c8d13ea414894", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 52 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Description);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <hr />\r\n\r\n");
#nullable restore
#line 58 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
             for (int i = 0; i < lineTypeOptions.Count; i++)
            {
                var item = lineTypeOptions[i];


#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"form-group row\">\r\n                    <label class=\"control-label col-3\"><strong>");
#nullable restore
#line 63 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
                                                          Write(item.Option.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong></label>\r\n                    <div class=\"col-9\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4e24ab289fa6c230ce0496585a1634b6c8d13ea417334", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 65 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.LineTypeOptionValues[i].LineTypeOptionId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
                                                                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4e24ab289fa6c230ce0496585a1634b6c8d13ea419897", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 66 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.LineTypeOptionValues[i].Value);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 69 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

            <div class=""form-group row"">
                <label class=""control-label col-3""><strong>Danh sách các điểm</strong></label>
                <div class=""col-12"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th scope=""col"">X</th>
                                <th scope=""col"">Y</th>
                                <th scope=""col"">Z</th>
                                <th scope=""col"">Modified</th>
                            </tr>
                        </thead>
                        <tbody id=""body-nodes"" data-count=""");
#nullable restore
#line 84 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
                                                       Write((Model != null && Model.Nodes != null && Model.Nodes.Count > 0)?Model.Nodes.Count:1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">\r\n");
#nullable restore
#line 85 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
                             if (Model != null && Model.Nodes != null && Model.Nodes.Count > 0)
                            {
                                for (int i = 0; i < Model.Nodes.Count; i++)
                                {
                                    var item = Model.Nodes[i];


#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            <input");
                BeginWriteAttribute("id", " id=\"", 3720, "\"", 3738, 3);
                WriteAttributeValue("", 3725, "Nodes_", 3725, 6, true);
#nullable restore
#line 93 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 3731, i, 3731, 4, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3735, "__X", 3735, 3, true);
                EndWriteAttribute();
                WriteLiteral(" required");
                BeginWriteAttribute("name", " name=\"", 3748, "\"", 3768, 3);
                WriteAttributeValue("", 3755, "Nodes[", 3755, 6, true);
#nullable restore
#line 93 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 3761, i, 3761, 4, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3765, "].X", 3765, 3, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 3769, "\"", 3784, 1);
#nullable restore
#line 93 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 3777, item.X, 3777, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control node-x\" />\r\n                                        </td>\r\n                                        <td>\r\n                                            <input");
                BeginWriteAttribute("id", " id=\"", 3961, "\"", 3979, 3);
                WriteAttributeValue("", 3966, "Nodes_", 3966, 6, true);
#nullable restore
#line 96 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 3972, i, 3972, 4, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3976, "__Y", 3976, 3, true);
                EndWriteAttribute();
                WriteLiteral(" required");
                BeginWriteAttribute("name", " name=\"", 3989, "\"", 4009, 3);
                WriteAttributeValue("", 3996, "Nodes[", 3996, 6, true);
#nullable restore
#line 96 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 4002, i, 4002, 4, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4006, "].Y", 4006, 3, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 4010, "\"", 4025, 1);
#nullable restore
#line 96 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 4018, item.Y, 4018, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control node-y\" />\r\n                                        </td>\r\n                                        <td>\r\n                                            <input");
                BeginWriteAttribute("id", " id=\"", 4202, "\"", 4220, 3);
                WriteAttributeValue("", 4207, "Nodes_", 4207, 6, true);
#nullable restore
#line 99 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 4213, i, 4213, 4, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4217, "__Z", 4217, 3, true);
                EndWriteAttribute();
                WriteLiteral(" required");
                BeginWriteAttribute("name", " name=\"", 4230, "\"", 4250, 3);
                WriteAttributeValue("", 4237, "Nodes[", 4237, 6, true);
#nullable restore
#line 99 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 4243, i, 4243, 4, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4247, "].Z", 4247, 3, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 4251, "\"", 4266, 1);
#nullable restore
#line 99 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
WriteAttributeValue("", 4259, item.Z, 4259, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control node-z"" />
                                        </td>
                                        <td>
                                            <button class=""btn btn-danger btn-remove-node"" type=""button""><i class=""fas fa-minus""></i></button>
                                        </td>
                                    </tr>
");
#nullable restore
#line 105 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
                                }
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <tr>
                                    <td>
                                        <input id=""Nodes_0__X"" required name=""Nodes[0].X"" class=""form-control node-x"" />
                                    </td>
                                    <td>
                                        <input id=""Nodes_0__Y"" required name=""Nodes[0].Y"" class=""form-control node-y"" />
                                    </td>
                                    <td>
                                        <input id=""Nodes_0__Z"" required name=""Nodes[0].Z"" class=""form-control node-z"" />
                                    </td>
                                    <td>
                                        <button class=""btn btn-danger btn-remove-node"" type=""button""><i class=""fas fa-minus""></i></button>
                                    </td>
                                </tr>
");
#nullable restore
#line 123 "C:\Users\ngocd\Desktop\gis\Gis3D\WebApp\WebApp\Views\Line\Create.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </tbody>
                    </table>
                    <button class=""btn btn-success btn-add-node"" type=""button"">
                        <i class=""fas fa-plus""></i>
                    </button>
                </div>
            </div>

            <div class=""form-group"">
                <div class=""w-100 text-center"">
                    <input type=""submit"" value=""Tạo mới"" class=""btn btn-primary w-50"" />
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e24ab289fa6c230ce0496585a1634b6c8d13ea431668", async() => {
                WriteLiteral("Quay lại danh sách");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<script>
    $(document).ready(() => {
        const lineTypeEle = document.getElementById('line-type')
        const bodyNodesEle = document.getElementById('body-nodes')
        const btnAddNodeEle = document.querySelector('.btn-add-node')

        // Update name và id
        const updateNameId = () => {

            // Cập nhật lại các name và id
            [...bodyNodesEle.children].forEach((item, i) => {
                var xEle = item.querySelector('.node-x')
                var yEle = item.querySelector('.node-y')
                var zEle = item.querySelector('.node-z')

                xEle.setAttribute('name', `Nodes[${i}].X`)
                xEle.setAttribute('id', `Nodes_${i}__X`)

                yEle.setAttribute('name', `Nodes[${i}].Y`)
                yEle.setAttribute('id', `Nodes_${i}__Y`)

                zEle.setAttribute('name', `Nodes[${i}].Z`)
                zEle.setAttribute('id', `Nodes_${i}__Z`)
            })
        }

        // Xóa
        ");
            WriteLiteral(@"$('body').on('click', '.btn-remove-node', function () {
            var count = bodyNodesEle.dataset.count;

            if (count > 1) {
                count--;
                bodyNodesEle.dataset.count = count;
                $(this).parents('tr').remove()

                updateNameId()
            }
        })

        // Thêm một nodes
        btnAddNodeEle.addEventListener('click', function () {
            var count = bodyNodesEle.dataset.count;
            var trEle = document.createElement('tr')

            count++;
            bodyNodesEle.dataset.count = count;

            trEle.innerHTML = `
                            <td>
                                <input required class=""form-control node-x"" />
                            </td>
                            <td>
                                <input required class=""form-control node-y"" />
                            </td>
                            <td>
                                <input required class=""");
            WriteLiteral(@"form-control node-z"" />
                            </td>
                            <td>
                                <button class=""btn btn-danger btn-remove-node"" type=""button""><i class=""fas fa-minus""></i></button>
                            </td>`

            bodyNodesEle.appendChild(trEle);

            updateNameId()
        })

        // Reload trang khi chọn type, vì cần load lại form
        lineTypeEle.addEventListener('change', function (e) {
            var lineTypeId = lineTypeEle.value;

            window.location.href = '/Line/Create?lineTypeSelected=' + lineTypeId;
        })
    })
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LineCreateRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591
