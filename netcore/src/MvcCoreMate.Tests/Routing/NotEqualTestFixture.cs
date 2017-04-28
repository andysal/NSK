using System;
using SharpTestsEx;
using NUnit.Framework;
using MvcCoreMate.Mvc.Routing;

namespace MvcMate.Web.Routing.Tests.Routing
{
    [TestFixture]
    public class NotEqualTestFixture
    {
        [Test]
        public void Ctor_should_throw_ArgumentException_if_pattern_parameter_is_null()
        {
            Executing.This(() => new NotEqualConstraint(null))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("pattern");
        }

        [Test]
        public void Ctor_should_throw_ArgumentException_if_pattern_parameter_is_empty()
        {
            Executing.This(() => new NotEqualConstraint(string.Empty))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("pattern");
        }

        [Test]
        public void Ctor_should_throw_ArgumentException_if_pattern_parameter_is_whitespace()
        {
            Executing.This(() => new NotEqualConstraint(" "))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("pattern");
        }

        [Test]
        public void Ctor_should_set_Pattern_property_if_pattern_parameter_has_a_correct_value()
        {
            var pattern = "mypattern";
            var constraint = new NotEqualConstraint(pattern);
            Assert.AreEqual(pattern, constraint.Pattern);
        }
    }
}
