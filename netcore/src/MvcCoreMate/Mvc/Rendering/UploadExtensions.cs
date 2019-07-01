using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.IO;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace MvcCoreMate.Mvc.Rendering
{
    /// <summary>
    /// Represents support for HTML input "file" controls in an application.
    /// </summary>
    public static class UploadExtensions
    {
        /// <summary>
        /// Returns a file input element by using the specified HTML helper and the name of the form field.
        /// </summary>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field.</param>
        /// <returns>An input element whose type attribute is set to "file".</returns>
        public static IHtmlContent Upload(this IHtmlHelper helper, string name)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Target cannot be null or empty", nameof(name));

            return Upload(helper, name, null);
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An input element whose type attribute is set to "file".</returns>
        public static IHtmlContent Upload(this IHtmlHelper helper, string name, object htmlAttributes)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Target cannot be null or empty", nameof(name));

            return Upload(helper, name, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An input element whose type attribute is set to "file".</returns>
        public static IHtmlContent Upload(this IHtmlHelper helper, string name, IDictionary<string, object> htmlAttributes)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Target cannot be null or empty", nameof(name));

            var tagBuilder = BuildTagBuilder(name, htmlAttributes);
            //tagBuilder.MergeAttributes<string, object>(helper.GetUnobtrusiveValidationAttributes(name));

            var htmlChunk = GetHtmlFromTagBuilder(tagBuilder);
            return new HtmlString(htmlChunk);

            //htmlAttributes.Add("type", "file");
            //return helper.TextBox(name, string.Empty, htmlAttributes);
        }

        /// <summary>
        /// Returns a file input element for each property in the object that is represented by the specified expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <returns>An HTML input element whose type attribute is set to "file" for each property in the object that is represented by the expression.</returns>
        public static IHtmlContent UploadFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return UploadFor(helper, expression, null);
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <typeparam name="TModel">The type of the model</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An input element whose type attribute is set to "file".</returns>
        public static IHtmlContent UploadFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return UploadFor(helper, expression, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <typeparam name="TModel">The type of the model</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An input element whose type attribute is set to "file".</returns>
        public static IHtmlContent UploadFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            string name = ExpressionHelper.GetExpressionText(expression);
            var tagBuilder = BuildTagBuilder(name, htmlAttributes);
            //var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData);
            //tagBuilder.MergeAttributes<string, object>(helper.GetUnobtrusiveValidationAttributes(name, metadata));
            var htmlChunk = GetHtmlFromTagBuilder(tagBuilder);

            return new HtmlString(htmlChunk);

            //htmlAttributes.Add("type", "file");
            //return helper.TextBoxFor(expression, htmlAttributes);
        }

        private static TagBuilder BuildTagBuilder(string name, IDictionary<string, object> htmlAttributes)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;
            tagBuilder.MergeAttribute("type", "file");
            tagBuilder.MergeAttribute("name", name);
            tagBuilder.MergeAttribute("id", name);
            //tagBuilder.MergeAttribute("multiple", string.Empty);
            tagBuilder.MergeAttributes(htmlAttributes);
            return tagBuilder;
        }

        private static string GetHtmlFromTagBuilder(TagBuilder tagBuilder)
        {
            using (var writer = new StringWriter())
            {
                HtmlEncoder encoder = HtmlEncoder.Default;
                tagBuilder.WriteTo(writer, encoder);
                var htmlChunk = writer.ToString();
                return htmlChunk;
            }
        }
    }
}
