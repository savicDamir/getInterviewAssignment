#pragma checksum "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ec97ec18fd330624eda373430202472254f4765"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\_ViewImports.cshtml"
using PROBANET;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\_ViewImports.cshtml"
using PROBANET.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ec97ec18fd330624eda373430202472254f4765", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c63dc48bca2bfa7ba82e902f8c593c6b20e3676c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("helpForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n");
#nullable restore
#line 6 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml"
     using (Html.BeginForm("Login","Home",FormMethod.Post, new {id= "myForm"}))
    { 

#line default
#line hidden
#nullable disable
            WriteLiteral("        <fieldset>\r\n            <div class=\"row d-flex justify-content-center\">\r\n                ");
#nullable restore
#line 10 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml"
           Write(Html.LabelFor(m => m.Username, new {@class="col-md-2 control-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 11 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml"
           Write(Html.TextBoxFor(m => m.Username, new {@class="form-control col-md-4"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            ");
#nullable restore
#line 13 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml"
       Write(Html.ValidationMessageFor(m => m.Username,"", new { @class = "text-danger row justify-content-center" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"row d-flex justify-content-center mt-3 form-group\">\r\n                ");
#nullable restore
#line 15 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml"
           Write(Html.LabelFor(m => m.Password, new {@class="col-md-2 control-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 16 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml"
           Write(Html.TextBoxFor(m => m.Password, new {@class="form-control col-md-4"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            ");
#nullable restore
#line 18 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml"
       Write(Html.ValidationMessageFor(m => m.Password,"", new { @class = "text-danger row justify-content-center" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <input type=\"button\" onclick=\"mySubmit()\" value=\"Login\" class=\"row btn btn-primary mt-3\" /> \r\n        </fieldset>\r\n");
#nullable restore
#line 21 "c:\Users\Damir\Desktop\ProbaNet\PROBANET\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ec97ec18fd330624eda373430202472254f47656938", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<script>
    function mySubmit()
    {
        if ( !$(""#myForm"").valid()) return;
        var data= $(""#myForm"").serialize();
        var type;
        var user;
        $.ajax(
            {
                type:""Post"",
                url: ""/Home/Login"",
                data: data,
                error: function (response)
                {
                    alert (response);
                },
                success: function(data, status, xhr)
                {
                    switch(xhr.status)
                    {
                        case 210:
                            alert (""User is not in database"");
                            return;
                        case 220:
                            $('#helpForm').attr('action','/Admin/Index');
                            break;
                        case 230:
                            $('#helpForm').attr('action','/Manager/Index');
                            break;
                        case");
            WriteLiteral(@" 240:
                            $('#helpForm').attr('action','/Developer/Index');
                            break;
                        
                    }
                    var input = $(""<input>"").attr(""type"", ""hidden"").attr(""name"", ""id"").val(data);
                    console.log(data);
                    $('#helpForm').append($(input));
                    $('#helpForm').submit();

                }
            }
        );

        

    }
  
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
