#pragma checksum "/Users/babayev_/Desktop/Eduhome/Eduhome/Eduhome/Views/Shared/Components/Header/Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "494c961d9035e9027b75a507af580055a06fc6be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Eduhome.Views.Shared.Components.Header.Views_Shared_Components_Header_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Header/Default.cshtml")]
namespace Eduhome.Views.Shared.Components.Header
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
#line 4 "/Users/babayev_/Desktop/Eduhome/Eduhome/Eduhome/Views/_ViewImports.cshtml"
using Business.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/babayev_/Desktop/Eduhome/Eduhome/Eduhome/Views/_ViewImports.cshtml"
using DAL.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"494c961d9035e9027b75a507af580055a06fc6be", @"/Views/Shared/Components/Header/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7026866bf26df0d615537a47380b100b237db0f7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_Header_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<string>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("eduhome"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<header class=""top"">
    <div class=""header-area header-sticky fixed"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-3 col-sm-3 col-xs-6"">
                    <div class=""logo"">
                        <a href=""index.html"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "494c961d9035e9027b75a507af580055a06fc6be5196", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 305, "~/assets/img/logo/", 305, 18, true);
#nullable restore
#line 9 "/Users/babayev_/Desktop/Eduhome/Eduhome/Eduhome/Views/Shared/Components/Header/Default.cshtml"
AddHtmlAttributeValue("", 323, Model[0], 323, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
                    </div>
                </div>
                <div class=""col-md-9 col-sm-9 col-xs-12"">
                    <div class=""content-wrapper one"">
                        <!-- Main Menu Start -->
                        <div class=""main-menu one text-right"">
                            <nav>
                                <ul>
                                    <li>
                                        <a href=""index.html"">Home</a>
                                        <ul>
                                            <li><a href=""index.html"">Home One</a></li>
                                            <li><a href=""index-2.html"">Home Two</a></li>
                                            <li><a href=""index-3.html"">Home Three</a></li>
                                            <li><a href=""index-4.html"">Home Four</a></li>
                                            <li><a href=""index-5.html"">Home Five</a></li>
                                        </ul>
                         ");
            WriteLiteral(@"           </li>
                                    <li><a href=""about.html"">About</a></li>
                                    <li>
                                        <a href=""course.html"">courses</a>
                                        <ul>
                                            <li><a href=""course.html"">courses</a></li>
                                            <li><a href=""course-details.html"">courses details</a></li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a href=""event.html"">event</a>
                                        <ul>
                                            <li><a href=""event.html"">event</a></li>
                                            <li><a href=""event-left-side-bar.html"">event left sidebar</a></li>
                                            <li><a href=""event-right-side-bar.html"">event right sidebar</a></li>
                            ");
            WriteLiteral(@"                <li><a href=""event-details.html"">event details</a></li>
                                        </ul>
                                    </li>
                                    <li class=""hidden-sm"">
                                        <a href=""teacher.html"">teacher</a>
                                        <ul>
                                            <li><a href=""teacher.html"">teacher</a></li>
                                            <li><a href=""teacher-details.html"">teacher details</a></li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a href=""blog.html"">blog</a>
                                        <ul>
                                            <li><a href=""blog.html"">blog</a></li>
                                            <li><a href=""blog-left-side-bar.html"">blog left sidebar</a></li>
                                            <li><a href=""bl");
            WriteLiteral("og-right-side-bar.html\">blog righ sidebar</a></li>\n                                            <li><a href=\"blog-details.html\">blog details</a></li>\n                                        </ul>\n                                    </li>\n");
#nullable restore
#line 61 "/Users/babayev_/Desktop/Eduhome/Eduhome/Eduhome/Views/Shared/Components/Header/Default.cshtml"
                                     if (User.Identity.IsAuthenticated)
                                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><a>");
#nullable restore
#line 64 "/Users/babayev_/Desktop/Eduhome/Eduhome/Eduhome/Views/Shared/Components/Header/Default.cshtml"
                                          Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n                                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "494c961d9035e9027b75a507af580055a06fc6be10886", async() => {
                WriteLiteral("Logout");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
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
            WriteLiteral("</li>\n");
#nullable restore
#line 66 "/Users/babayev_/Desktop/Eduhome/Eduhome/Eduhome/Views/Shared/Components/Header/Default.cshtml"
                                    }
                                    else
                                    {



#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "494c961d9035e9027b75a507af580055a06fc6be12595", async() => {
                WriteLiteral("Register");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n                                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "494c961d9035e9027b75a507af580055a06fc6be13988", async() => {
                WriteLiteral("Login");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n");
#nullable restore
#line 73 "/Users/babayev_/Desktop/Eduhome/Eduhome/Eduhome/Views/Shared/Components/Header/Default.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </ul>
                            </nav>
                        </div>
                        <div class=""mobile-menu hidden-lg hidden-md one""></div>
                        <!-- Main Menu End -->
                    </div>
                </div>
            </div>
        </div>
    </div>

</header>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<string>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591