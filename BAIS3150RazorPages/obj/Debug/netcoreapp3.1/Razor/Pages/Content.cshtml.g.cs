#pragma checksum "C:\Users\b_lap\Documents\GitHub\BAIS3150-Software-Developement-Tools\BAIS3150RazorPages\Pages\Content.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f49dda994ff0980939d42026fcfcf74104742a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BAIS3150RazorPages.Pages.Pages_Content), @"mvc.1.0.razor-page", @"/Pages/Content.cshtml")]
namespace BAIS3150RazorPages.Pages
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
#line 10 "C:\Users\b_lap\Documents\GitHub\BAIS3150-Software-Developement-Tools\BAIS3150RazorPages\Pages\_ViewImports.cshtml"
using BAIS3150RazorPages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f49dda994ff0980939d42026fcfcf74104742a6", @"/Pages/Content.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76816717eb13e033afabd6cdc40961726b3f1afa", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Content : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\b_lap\Documents\GitHub\BAIS3150-Software-Developement-Tools\BAIS3150RazorPages\Pages\Content.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Content Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("scriptContent", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        //any script in here so it can be used in the layout\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("footerContent", async() => {
                WriteLiteral("\r\n    <div>\r\n        <h5>footer</h5>\r\n    </div>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BAIS3150RazorPages.Pages.ContentModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BAIS3150RazorPages.Pages.ContentModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BAIS3150RazorPages.Pages.ContentModel>)PageContext?.ViewData;
        public BAIS3150RazorPages.Pages.ContentModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
