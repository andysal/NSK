using System;
using SharpTestsEx;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Globalization;
using NUnit.Framework;
using MvcCoreMate.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MvcMate.Web.Tests.Helpers
{
    [TestFixture]
    public class UploadExtensionsFixture
    {
        private CultureInfo OriginalCulture;
        private CultureInfo OriginalUICulture;

        [SetUp]
        public void Initialize()
        {
            OriginalCulture = Thread.CurrentThread.CurrentCulture;
            OriginalUICulture = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }

        [TearDown]
        public void Cleanup()
        {
            Thread.CurrentThread.CurrentCulture = OriginalCulture;
            Thread.CurrentThread.CurrentUICulture = OriginalUICulture;
        }

        [Test]
        public void Upload_method_should_throw_ArgumentNullException_if_helper_parameter_is_null()
        {
            Executing.This(() => UploadExtensions.Upload(null, "xyz"))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("helper");
        }

        [Test]
        public void Upload_method_should_throw_ArgumentException_if_name_parameter_is_null()
        {
            var helper = MockFactories.CreateFakeHtmlHelper();
            Executing.This(() => UploadExtensions.Upload(helper, null))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("name");
        }

        [Test]
        public void Upload_method_should_throw_ArgumentException_if_name_parameter_is_empty()
        {
            var helper = MockFactories.CreateFakeHtmlHelper();
            Executing.This(() => UploadExtensions.Upload(helper, ""))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("name");
        }

        [Test]
        public void Upload_method_should_throw_ArgumentException_if_name_parameter_is_whitespace()
        {
            var helper = MockFactories.CreateFakeHtmlHelper();
            Executing.This(() => UploadExtensions.Upload(helper, "   "))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("name");
        }

        [Test]
        public void Upload_should_generate_expected_html_code()
        {
            var helper = MockFactories.CreateFakeHtmlHelper();
            var mvcHtmlString = UploadExtensions.Upload(helper, "myfile");
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input id=\"myfile\" name=\"myfile\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void Upload_should_generate_expected_html_code_and_attributes_when_attributes_are_specified_using_anonymous_type()
        {
            var helper = MockFactories.CreateFakeHtmlHelper();
            var attributes = new { @class = "fake", style = "text-align: left;" };
            var mvcHtmlString = UploadExtensions.Upload(helper, "myfile", attributes);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input class=\"fake\" id=\"myfile\" name=\"myfile\" style=\"text-align: left;\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void Upload_should_generate_expected_html_code_and_attributes_when_attributes_are_specified_using_dictionary()
        {
            var helper = MockFactories.CreateFakeHtmlHelper();
            var attributes = new Dictionary<string, object>()   { 
                                                                    { "class", "fake"},
                                                                    { "style", "text-align: left;" }
                                                                };
            var mvcHtmlString = UploadExtensions.Upload(helper, "myfile", attributes);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input class=\"fake\" id=\"myfile\" name=\"myfile\" style=\"text-align: left;\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void UploadFor_method_should_throw_ArgumentNullException_if_helper_parameter_is_null()
        {
            Expression<Func<object, bool>> func = x => true;
            Executing.This(() => UploadExtensions.UploadFor(null, func))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("helper");
        }

        [Test]
        public void UploadFor_method_should_throw_ArgumentNullException_if_expression_parameter_is_null()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<object>();
            Executing.This(() => UploadExtensions.UploadFor(helper, (Expression<Func<object, bool>>)null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("expression");
        }

        [Test]
        public void UploadFor_should_generate_expected_html_code()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<DummyViewModel>();
            var mvcHtmlString = UploadExtensions.UploadFor(helper, model => model.TheFile);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input id=\"TheFile\" name=\"TheFile\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void UploadFor_should_generate_expected_html_code_and_attributes_when_attributes_are_specified_using_anonymous_type()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<DummyViewModel>();
            var attributes = new { @class = "fake", style = "text-align: left;" };
            var mvcHtmlString = UploadExtensions.UploadFor(helper, model => model.TheFile, attributes);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input class=\"fake\" id=\"TheFile\" name=\"TheFile\" style=\"text-align: left;\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void UploadFor_should_generate_expected_html_code_and_attributes_when_attributes_are_specified_using_dictionary()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<DummyViewModel>();
            var attributes = new Dictionary<string, object>()   { 
                                                                    { "class", "fake"},
                                                                    { "style", "text-align: left;" }
                                                                };
            var mvcHtmlString = UploadExtensions.UploadFor(helper, model => model.TheFile, attributes);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input class=\"fake\" id=\"TheFile\" name=\"TheFile\" style=\"text-align: left;\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void UploadFor_should_generate_expected_html_code_when_validation_is_required()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<DummyViewModel>();
            helper.ViewContext.ClientValidationEnabled = true;
            helper.ViewContext.UnobtrusiveJavaScriptEnabled = true;
            helper.ViewContext.FormContext = new FormContext();

            var mvcHtmlString = UploadExtensions.UploadFor(helper, model => model.TheRequestedFile);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input data-val=\"true\" data-val-required=\"The TheRequestedFile field is required.\" id=\"TheRequestedFile\" name=\"TheRequestedFile\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void UploadFor_should_generate_expected_html_code_and_attributes_when_attributes_are_specified_using_anonymous_type_and_validation_is_required()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<DummyViewModel>();
            helper.ViewContext.ClientValidationEnabled = true;
            helper.ViewContext.UnobtrusiveJavaScriptEnabled = true;
            helper.ViewContext.FormContext = new FormContext();

            var attributes = new { @class = "fake", style = "text-align: left;" };
            var mvcHtmlString = UploadExtensions.UploadFor(helper, model => model.TheRequestedFile, attributes);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input class=\"fake\" data-val=\"true\" data-val-required=\"The TheRequestedFile field is required.\" id=\"TheRequestedFile\" name=\"TheRequestedFile\" style=\"text-align: left;\" type=\"file\" />";
                           Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void UploadFor_should_generate_expected_html_code_and_attributes_when_attributes_are_specified_using_dictionary_and_validation_is_required()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<DummyViewModel>();
            helper.ViewContext.ClientValidationEnabled = true;
            helper.ViewContext.UnobtrusiveJavaScriptEnabled = true;
            helper.ViewContext.FormContext = new FormContext();

            var attributes = new Dictionary<string, object>()   { 
                                                                    { "class", "fake"},
                                                                    { "style", "text-align: left;" }
                                                                };
            var mvcHtmlString = UploadExtensions.UploadFor(helper, model => model.TheRequestedFile, attributes);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input class=\"fake\" data-val=\"true\" data-val-required=\"The TheRequestedFile field is required.\" id=\"TheRequestedFile\" name=\"TheRequestedFile\" style=\"text-align: left;\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void UploadFor_should_generate_expected_html_code_when_nested_model_property_validation_is_required()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<DummyParentViewModel>();
            helper.ViewContext.ClientValidationEnabled = true;
            helper.ViewContext.UnobtrusiveJavaScriptEnabled = true;
            helper.ViewContext.FormContext = new FormContext();

            var mvcHtmlString = UploadExtensions.UploadFor(helper, model => model.Nested.TheRequestedFile);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input data-val=\"true\" data-val-required=\"The TheRequestedFile field is required.\" id=\"Nested_TheRequestedFile\" name=\"Nested.TheRequestedFile\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void UploadFor_should_generate_expected_html_code_and_attributes_when_nested_model_property_and_attributes_are_specified_using_anonymous_type_and_validation_is_required()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<DummyParentViewModel>();
            helper.ViewContext.ClientValidationEnabled = true;
            helper.ViewContext.UnobtrusiveJavaScriptEnabled = true;
            helper.ViewContext.FormContext = new FormContext();

            var attributes = new { @class = "fake", style = "text-align: left;" };
            var mvcHtmlString = UploadExtensions.UploadFor(helper, model => model.Nested.TheRequestedFile, attributes);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input class=\"fake\" data-val=\"true\" data-val-required=\"The TheRequestedFile field is required.\" id=\"Nested_TheRequestedFile\" name=\"Nested.TheRequestedFile\" style=\"text-align: left;\" type=\"file\" />";
            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        [Test]
        public void UploadFor_should_generate_expected_html_code_and_attributes_when_nested_model_property_and_attributes_are_specified_using_dictionary_and_validation_is_required()
        {
            var helper = MockFactories.CreateFakeHtmlHelper<DummyParentViewModel>();
            helper.ViewContext.ClientValidationEnabled = true;
            helper.ViewContext.UnobtrusiveJavaScriptEnabled = true;
            helper.ViewContext.FormContext = new FormContext();

            var attributes = new Dictionary<string, object>()
            {
                { "class", "fake"},
                { "style", "text-align: left;" }
            };

            var mvcHtmlString = UploadExtensions.UploadFor(helper, model => model.Nested.TheRequestedFile, attributes);
            var generatedHtml = mvcHtmlString.ToString();
            var expectedHtml = "<input class=\"fake\" data-val=\"true\" data-val-required=\"The TheRequestedFile field is required.\" id=\"Nested_TheRequestedFile\" name=\"Nested.TheRequestedFile\" style=\"text-align: left;\" type=\"file\" />";

            Assert.AreEqual(expectedHtml, generatedHtml);
        }

        public class DummyViewModel
        {
            public HttpPostedFileBase TheFile { get; set; }

            [Required]
            public HttpPostedFileBase TheRequestedFile { get; set; }
        }

        public class DummyParentViewModel
        {
            public DummyNestedViewModel Nested { get; set; }

            public class DummyNestedViewModel
            {
                [Required]
                public HttpPostedFileBase TheRequestedFile { get; set; }
            }
        }
    }
}
