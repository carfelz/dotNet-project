#pragma checksum "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\Despacho.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dcce816894c18a41a9df83ffbe058daf4fcb129"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Almacen.Pages.Pages_Despacho), @"mvc.1.0.razor-page", @"/Pages/Despacho.cshtml")]
namespace Almacen.Pages
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
#line 1 "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\_ViewImports.cshtml"
using Almacen;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dcce816894c18a41a9df83ffbe058daf4fcb129", @"/Pages/Despacho.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab67681358c8796b8de668b6f6639c4bb08c137e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Despacho : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <table class=""table table-striped"">
        <thead>
            <tr>
                <th>Codigo</th>
                <th>Fecha</th>
                <th>Accion</th>
                <th>Cliente</th>
                <th>Contacto</th>
                <th>Detalle</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 18 "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\Despacho.cshtml"
             foreach (var despacho in Model.despachoProductos)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\Despacho.cshtml"
                   Write(despacho.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\Despacho.cshtml"
                   Write(despacho.Fecha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\Despacho.cshtml"
                   Write(despacho.TipoAccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\Despacho.cshtml"
                   Write(despacho.Cliente);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\Despacho.cshtml"
                   Write(despacho.Contacto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\Despacho.cshtml"
                   Write(despacho.Detalle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 28 "C:\Users\carlo\Desktop\dotNet-project\Almacen\Pages\Despacho.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DespachoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DespachoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DespachoModel>)PageContext?.ViewData;
        public DespachoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591