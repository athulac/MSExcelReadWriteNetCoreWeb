#pragma checksum "C:\Users\Athula\source\repos\PracticalTestExecl\PracticalTestExecl\Views\Student\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c57ecb71ca4e894c41151b8655c79b47c0ce939e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Index), @"mvc.1.0.view", @"/Views/Student/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c57ecb71ca4e894c41151b8655c79b47c0ce939e", @"/Views/Student/Index.cshtml")]
    public class Views_Student_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Athula\source\repos\PracticalTestExecl\PracticalTestExecl\Views\Student\Index.cshtml"
  
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""col-12"">
    <table id=""example"" class=""display"" style=""width:100%"">
        <thead>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Dob</th>
                <th>Ethnicity</th>
                <th>Gender</th>
                <th>Email</th>
                <th>City</th>                
                <th>Action</th>                
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>


");
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
                    axios.get('/Student/GetAll')
                        .then((response) => {
                            var data = [];
                            $.each(response, function (index, value) {
                                var obj = {
                                    ""firstName"": value.firstName,
                                    ""lastName"": value.lastName,
                                    ""dob"": moment(value.dob, ""YYYYMMDD"").fromNow(),                                  
                                    ""ethnicity"": value.ethnicity.name,
                                    ""gender"": value.gender,
                                    ""email"": value.email,
                ");
                WriteLiteral(@"                    ""city"": value.city,
                                    ""action"": ""<a>Edit</a>"",
                                };
                                data.push(obj);
                            });

                            $('#example').dataTable().fnClearTable();
                            $('#example').dataTable().fnDestroy();
                            $('#example').DataTable({
                                data: data,
                                columns: [
                                    { ""data"": ""firstName"" },
                                    { ""data"": ""lastName"" },
                                    { ""data"": ""dob"" },
                                    { ""data"": ""ethnicity"" },
                                    { ""data"": ""gender"" },
                                    { ""data"": ""email"" },
                                    { ""data"": ""city"" },  
                                    { ""data"": ""action"" },     
                                ],
 ");
                WriteLiteral("                               pageLength: 6,\r\n                                lengthMenu: [[6, 12, -1], [6, 12, \'All\']]\r\n                            });\r\n                        });\r\n                },\r\n            }\r\n        })\r\n    </script>\r\n\r\n");
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