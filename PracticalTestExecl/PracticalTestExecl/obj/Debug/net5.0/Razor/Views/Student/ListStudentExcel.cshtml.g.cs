#pragma checksum "C:\Users\Athula\source\repos\PracticalTestExecl\PracticalTestExecl\Views\Student\ListStudentExcel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33e583f201b2c6009adec94a070f3c9fb0f2c838"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_ListStudentExcel), @"mvc.1.0.view", @"/Views/Student/ListStudentExcel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33e583f201b2c6009adec94a070f3c9fb0f2c838", @"/Views/Student/ListStudentExcel.cshtml")]
    public class Views_Student_ListStudentExcel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Athula\source\repos\PracticalTestExecl\PracticalTestExecl\Views\Student\ListStudentExcel.cshtml"
  
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div id=\"app\" class=\"container-fluid\" style=\"overflow:scroll\" >\r\n    <table id=\"students\" class=\"table table-striped\">\r\n        <thead>\r\n\r\n        </thead>\r\n        <tbody>\r\n                     \r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>

        var vueApp = new Vue({
            el: '#app',
            data: {

            },
            mounted: function (event) {
                this.GetAll();

            },
            methods: {

                GetAll: function () {
                    axios.get('/Student/GetAllExcel')
                        .then((response) => {
                            var table = '';
                            $('#students tbody').empty();
                            $.each(response[0].data, function (index, value) {
                                var tr =
                                    '<tr>'+                               
                                    '<td>' + value[0] + '</td>' +
                                    '<td>' + value[1] + '</td>' +
                                    '<td>' + value[2] + '</td>' +
                                    '<td>' + value[3] + '</td>' +
                                    '<td>' + value[4] + '</td>' +
             ");
                WriteLiteral(@"                       '<td>' + value[5] + '</td>' +
                                    '<td>' + value[6] + '</td>' +
                                    '<td>' + value[7] + '</td>' +
                                    '<td>' + value[8] + '</td>' +
                                    '<td>' + value[9] + '</td>' +

                                    '<td>' + value[10] + '</td>' +
                                    '<td>' + value[11] + '</td>' +
                                    '<td>' + value[12] + '</td>' +
                                    '<td>' + value[13] + '</td>' +
                                    '<td>' + value[14] + '</td>' +
                                    '<td>' + value[15] + '</td>' +
                                    '<td>' + value[16] + '</td>' +
                                    '<td>' + value[17] + '</td>' +
                                    '<td>' + value[18] + '</td>' +
                                    '<td>' + value[19] + '</td>' +

                  ");
                WriteLiteral(@"                  '<td>' + value[20] + '</td>' +
                                    '<td>' + value[21] + '</td>' +
                                    '<td>' + value[22] + '</td>' +
                                    '</tr>';                         
                                     
                                table += tr;
                            });
                            $(""#students tbody"").append(table);
                            
                        });
                },
            }
        })
    </script>

");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
