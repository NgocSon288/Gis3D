#pragma checksum "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f33a436a856bce90ffa513668fa91eb751aa3b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LineType_Index), @"mvc.1.0.view", @"/Views/LineType/Index.cshtml")]
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
#line 1 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f33a436a856bce90ffa513668fa91eb751aa3b3", @"/Views/LineType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_LineType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebApp.ViewModels.LineTypes.LineTypeViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "LineType", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Danh sách các LineType</h1>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"mx-auto\">\r\n        <div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f33a436a856bce90ffa513668fa91eb751aa3b34510", async() => {
                WriteLiteral("\r\n                Tạo\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <table class=""table caption-top mt-2"">
            <thead>
                <tr>
                    <th scope=""col"">#</th>
                    <th scope=""col"">Name</th>
                    <th scope=""col"">Description</th>
                    <th scope=""col"">Created by</th>
                    <th scope=""col"">Updated by</th>
                    <th scope=""col"">Modified</th>
                </tr>
            </thead>
            <tbody id=""body-bodies"">
");
#nullable restore
#line 24 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                  
                    var count = Model.Count;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                 for (int i = 0; i < count; i++)
                {
                    var item = Model[i];

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
#nullable restore
#line 31 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                                    Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <td>");
#nullable restore
#line 32 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                       Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><strong>");
#nullable restore
#line 34 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                               Write(item.CreatedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></td>\r\n                        <td><strong>");
#nullable restore
#line 35 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                                Write(string.IsNullOrEmpty(item.UpdatedBy)?"- - - - -": item.UpdatedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></td>\r\n                        <td>\r\n                            <div class=\"d-flex justify-content-center align-items-center\">\r\n                                <a class=\"btn btn-danger btn-delete-body mr-1\" data-id=\"");
#nullable restore
#line 38 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                                                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                    <i class=\"fas fa-trash-alt\"></i>\r\n                                </a>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f33a436a856bce90ffa513668fa91eb751aa3b39252", async() => {
                WriteLiteral("\r\n                                    <i class=\"far fa-edit\"></i>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                                                                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 47 "D:\School\HK1-năm 4\Địa lý 3 chiều\Gis3D\WebApp\WebApp\Views\LineType\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>

<script>
    const bodiesEle = document.getElementById('body-bodies')

    const updateId = () => {
        const trEles = bodiesEle.querySelectorAll('tr')

        trEles.forEach((item, i) => {
            var th = item.querySelector('th')
            th.innerText = i + 1
        })
    }

    $('body').on('click', '.btn-delete-body', function () {
        const pw = window.prompt(""Password?"")

        if (pw.toLocaleLowerCase() !== '1234567890') {
            return
        }
        if (confirm('Bạn có chắc chắn muốn xóa LineType ?')) {
            if (confirm('Bạn có chắc chưa?')) {
                const id = $(this).data('id')

                $.ajax({
                    url: `/LineType/Delete/${id}`,
                    success: (res) => {
                        if (res.isSuccess) {
                            $(this).parents('tr').remove();
                            updateId()

                            ale");
            WriteLiteral("rt(\'Xóa thành công\')\r\n                        }\r\n                    }\r\n                });\r\n\r\n\r\n            }\r\n        }\r\n    })\r\n\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebApp.ViewModels.LineTypes.LineTypeViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
