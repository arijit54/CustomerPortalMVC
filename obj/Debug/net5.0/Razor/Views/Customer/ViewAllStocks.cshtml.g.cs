#pragma checksum "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54f4e9caab4edded8b8ab6978747bb1641f1725b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_ViewAllStocks), @"mvc.1.0.view", @"/Views/Customer/ViewAllStocks.cshtml")]
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
#line 1 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\_ViewImports.cshtml"
using CustomerPortalMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\_ViewImports.cshtml"
using CustomerPortalMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54f4e9caab4edded8b8ab6978747bb1641f1725b", @"/Views/Customer/ViewAllStocks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03510779d3dea3e9bbe0a0f9864ddeaf8903da9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_ViewAllStocks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CustomerPortalMVC.Models.Stocks>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml"
  
    Layout = "~/Views/Shared/AllStockMutual.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <table class=\"table\">\r\n                                    <thead>\r\n                                        <tr>\r\n                                            <th>\r\n                                                ");
#nullable restore
#line 10 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml"
                                           Write(Html.DisplayNameFor(model => model.StockId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </th>\r\n                                            <th>\r\n                                                ");
#nullable restore
#line 13 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml"
                                           Write(Html.DisplayNameFor(model => model.StockName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </th>\r\n                                            <th>\r\n                                                ");
#nullable restore
#line 16 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml"
                                           Write(Html.DisplayNameFor(model => model.StockValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </th>\r\n                                        </tr>\r\n                                    </thead>\r\n\r\n                                    <tbody>\r\n");
#nullable restore
#line 22 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 26 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.StockId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 29 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.StockName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 32 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.StockValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n\r\n                                            </tr>\r\n");
#nullable restore
#line 36 "C:\Users\Arijit\Desktop\CustomerPortalMVC\Views\Customer\ViewAllStocks.cshtml"

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                           ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CustomerPortalMVC.Models.Stocks>> Html { get; private set; }
    }
}
#pragma warning restore 1591
