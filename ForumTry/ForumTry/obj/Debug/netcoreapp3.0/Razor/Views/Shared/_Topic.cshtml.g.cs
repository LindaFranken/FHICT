#pragma checksum "C:\Users\lfran\source\repos\ForumTry\ForumTry\Views\Shared\_Topic.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c5e7c80e6ff58d63d359483f3e9394386ffe632"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Topic), @"mvc.1.0.view", @"/Views/Shared/_Topic.cshtml")]
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
#line 1 "C:\Users\lfran\source\repos\ForumTry\ForumTry\Views\_ViewImports.cshtml"
using ForumTry;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lfran\source\repos\ForumTry\ForumTry\Views\_ViewImports.cshtml"
using ForumTry.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c5e7c80e6ff58d63d359483f3e9394386ffe632", @"/Views/Shared/_Topic.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55ea729d61e1a954edd8e8c1a4ba011270f8822f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Topic : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ForumTry.Models.Topic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\lfran\source\repos\ForumTry\ForumTry\Views\Shared\_Topic.cshtml"
  
    ViewData["Title"] = "_Topic";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<a");
            BeginWriteAttribute("href", " href=\"", 76, "\"", 133, 1);
#nullable restore
#line 6 "C:\Users\lfran\source\repos\ForumTry\ForumTry\Views\Shared\_Topic.cshtml"
WriteAttributeValue("", 83, Url.Action("Topic", "Post", new { id = Model.Id}), 83, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Read topic</a>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ForumTry.Models.Topic> Html { get; private set; }
    }
}
#pragma warning restore 1591