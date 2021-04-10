using FagElGamous.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;
        public PaginationTagHelper(IUrlHelperFactory helperFactory)
        {
            urlInfo = helperFactory;
        }
        public PagingInfo PageModel { get; set; }

        //attributes to allow for button styling and such
        public bool PageClassesEnabled { get; set; } = false;
        public string PageAction { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //the dictionary make parameter passing easier
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext viewContext { get; set; }

        //building the html tags to create the link for the page numbers
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlInfo.GetUrlHelper(viewContext);
            TagBuilder tagDiv = new TagBuilder("div");

            //used with or related to the page numbering
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                //new link tag for each page number
                TagBuilder tagA = new TagBuilder("a");

                KeyValuePairs["pageNum"] = i;
                tagA.Attributes["href"] = urlHelper.Action(PageAction, KeyValuePairs);
                tagA.InnerHtml.Append(i.ToString());

                //if the classes are enabled in the cshtml file, styling options are available
                if (PageClassesEnabled)
                {
                    tagA.AddCssClass(PageClass);
                    tagA.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tagDiv.InnerHtml.AppendHtml(tagA);
            }

            output.Content.AppendHtml(tagDiv.InnerHtml);
        }
    }
}
