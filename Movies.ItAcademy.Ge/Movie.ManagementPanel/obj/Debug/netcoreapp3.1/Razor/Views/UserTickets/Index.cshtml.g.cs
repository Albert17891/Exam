#pragma checksum "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c9efae7c096bf514694915acc315b7afa83f525"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserTickets_Index), @"mvc.1.0.view", @"/Views/UserTickets/Index.cshtml")]
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
#line 1 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\_ViewImports.cshtml"
using Movies.ManagementPanel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\_ViewImports.cshtml"
using Movies.ManagementPanel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\_ViewImports.cshtml"
using MoviesManagement.Domain.Models.UserIdentiy;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c9efae7c096bf514694915acc315b7afa83f525", @"/Views/UserTickets/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29cf525979969994d5247ef104db165939715c82", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_UserTickets_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Movies.ManagementPanel.Models.User.UserModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
           Write(Html.ActionLink("Ticket", "Tickets", new {  name=item.UserName }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n               \r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 47 "C:\Users\user\source\repos\Movies.ItAcademy.Ge\Movie.ManagementPanel\Views\UserTickets\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Movies.ManagementPanel.Models.User.UserModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
