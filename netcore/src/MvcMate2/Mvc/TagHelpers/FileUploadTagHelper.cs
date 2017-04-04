using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMate2.Mvc.TagHelpers
{
    [HtmlTargetElement("upload")]
    public class FileUploadTagHelper : TagHelper
    {
        public IHtmlGenerator Generator { get; private set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        /// <summary>
        /// Creates a new <see cref="FileUploadTagHelper"/>.
        /// </summary>
        /// <param name="generator">The <see cref="IHtmlGenerator"/>.</param>
        public FileUploadTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var modelExplorer = For.ModelExplorer;
            var format = modelExplorer.Metadata.EditFormatString;
            var htmlAttributes = new Dictionary<string, object>
            {
                { "type", "file" }
            };

            var tagBuilder = Generator.GenerateTextBox(
                ViewContext,
                modelExplorer,
                For.Name,
                value: modelExplorer.Model,
                format: format,
                htmlAttributes: htmlAttributes);

            output.TagName = "input";
            if (tagBuilder != null)
            {
                tagBuilder.Attributes.ToList()
                    .ForEach(a => output.Attributes.Add(a.Key, a.Value));
                output.Content.Append(tagBuilder.InnerHtml.ToString());
            }
        }
    }
}
