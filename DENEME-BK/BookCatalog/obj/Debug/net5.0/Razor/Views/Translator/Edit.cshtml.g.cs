#pragma checksum "C:\Users\USER\Desktop\yedek\DENEME-BK\BookCatalog\Views\Translator\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "818edc154810cb5e5f889336f00ede68ad42f2ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Translator_Edit), @"mvc.1.0.view", @"/Views/Translator/Edit.cshtml")]
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
#line 1 "C:\Users\USER\Desktop\yedek\DENEME-BK\BookCatalog\Views\_ViewImports.cshtml"
using BookCatalog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\Desktop\yedek\DENEME-BK\BookCatalog\Views\_ViewImports.cshtml"
using Entities.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\USER\Desktop\yedek\DENEME-BK\BookCatalog\Views\_ViewImports.cshtml"
using BookCatalog.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"818edc154810cb5e5f889336f00ede68ad42f2ea", @"/Views/Translator/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6771a6869c480a1f0bc24c5abe194bb525916d94", @"/Views/_ViewImports.cshtml")]
    public class Views_Translator_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Translator>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "editPost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\USER\Desktop\yedek\DENEME-BK\BookCatalog\Views\Translator\Edit.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <ul class=""menu"">
        <li><a onclick=""geri()""><i class=""fas fa-arrow-left"" style=""cursor: pointer; padding-right: 20px;""></i></a> Sipariş Düzenle</li>
    </ul>
    <ul></ul>
</nav>
<article class=""container"">
    <div class=""item"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "818edc154810cb5e5f889336f00ede68ad42f2ea4521", async() => {
                WriteLiteral(@"
            <div class=""row"">
                <div class=""col-25"">
                    <label for=""name"">Müşteri Adı</label>
                </div>
                <div class=""col-75"">
                    <input type=""text"" id=""name"" name=""name"">
                </div>
            </div>
            <div class=""row"">
                <div class=""col-25"">
                    <label for=""payment"">Ödeme Yöntemi</label>
                </div>
                <div class=""col-75"">
                    <input type=""text"" id=""payment"" name=""payment"">
                </div>
            </div>
            <div class=""row"" style=""margin-top: 15px;"">
                <div class=""col-25"">
                    <label for=""name"">Kitap Adı ve Adedi</label>
                </div>
                <div class=""col-25"">
                </div>
            </div>
            <div id=""card"">
                <div class=""row"">
                    <div class=""col-25"" style=""margin-top: 7px;"">
                   ");
                WriteLiteral(@"     <button id=""plus"" style=""border: none; cursor: pointer;""><i class=""fas fa-plus-square"" style=""font-size: 20px; color: #7a91c0;""></i></button>
                        <input type=""text"" name=""bookName"" id=""bookName"">
                    </div>
                    <div class=""col-25"" style=""margin-top: 5px; margin-bottom: 1px;"">
                        <input type=""number""");
                BeginWriteAttribute("name", " name=\"", 1781, "\"", 1788, 0);
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 1789, "\"", 1794, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""padding: 7px; border: .5px solid rgb(211, 206, 206); appearance:textfield ; "">
                    </div>
                </div>
            </div>
            <div class=""row"" style=""margin-top: 20px;"">
                <button  type=""submit"" class=""submitButton""><a>Kaydet</a></button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n</article>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Translator> Html { get; private set; }
    }
}
#pragma warning restore 1591
