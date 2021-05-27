#pragma checksum "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f7810e5d65d6574b6af19197c8e9c6d0281fc05"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f7810e5d65d6574b6af19197c8e9c6d0281fc05", @"/Views/Account/Login.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GP.IdentityServer.Models.LoginViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"login-page\">\n    <div class=\"lead\">\n        <h1>Login</h1>\n        <p>Choose how to login</p>\n    </div>\n\n    <partial name=\"_ValidationSummary\" />\n\n    <div class=\"row\">\n\n");
#nullable restore
#line 13 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
         if (Model.EnableLocalLogin)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col-sm-6"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h2>Local Account</h2>
                    </div>

                    <div class=""card-body"">
                        <form asp-route=""Login"">
                            <input type=""hidden"" asp-for=""ReturnUrl"" />

                            <div class=""form-group"">
                                <label asp-for=""Username""></label>
                                <input class=""form-control"" placeholder=""Username"" asp-for=""Username"" autofocus>
                            </div>
                            <div class=""form-group"">
                                <label asp-for=""Password""></label>
                                <input type=""password"" class=""form-control"" placeholder=""Password"" asp-for=""Password"" autocomplete=""off"">
                            </div>
");
#nullable restore
#line 33 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
                             if (Model.AllowRememberLogin)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""form-group"">
                                    <div class=""form-check"">
                                        <input class=""form-check-input"" asp-for=""RememberLogin"">
                                        <label class=""form-check-label"" asp-for=""RememberLogin"">
                                            Remember My Login
                                        </label>
                                    </div>
                                </div>
");
#nullable restore
#line 43 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <button class=""btn btn-primary"" name=""button"" value=""login"">Login</button>
                            <button class=""btn btn-secondary"" name=""button"" value=""cancel"">Cancel</button>
                        </form>
                    </div>
                </div>
            </div>
");
#nullable restore
#line 50 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 52 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
         if (Model.VisibleExternalProviders.Any())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col-sm-6"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h2>External Account</h2>
                    </div>
                    <div class=""card-body"">
                        <ul class=""list-inline"">
");
#nullable restore
#line 61 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
                             foreach (var provider in Model.VisibleExternalProviders)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"list-inline-item\">\n                                    <a class=\"btn btn-secondary\"\n                                       asp-controller=\"External\"\n                                       asp-action=\"Challenge\"");
            BeginWriteAttribute("asp-route-scheme", "\n                                       asp-route-scheme=\"", 2859, "\"", 2947, 1);
#nullable restore
#line 67 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
WriteAttributeValue("", 2917, provider.AuthenticationScheme, 2917, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("asp-route-returnUrl", "\n                                       asp-route-returnUrl=\"", 2948, "\"", 3025, 1);
#nullable restore
#line 68 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
WriteAttributeValue("", 3009, Model.ReturnUrl, 3009, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                        ");
#nullable restore
#line 69 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
                                   Write(provider.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </a>\n                                </li>\n");
#nullable restore
#line 72 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\n                    </div>\n                </div>\n            </div>\n");
#nullable restore
#line 77 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 79 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
         if (!Model.EnableLocalLogin && !Model.VisibleExternalProviders.Any())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-warning\">\n                <strong>Invalid login request</strong>\n                There are no login schemes configured for this request.\n            </div>\n");
#nullable restore
#line 85 "D:\PROJEKTY\GP.IdentitiServer\GP.IdentityServer\Views\Account\Login.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GP.IdentityServer.Models.LoginViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
