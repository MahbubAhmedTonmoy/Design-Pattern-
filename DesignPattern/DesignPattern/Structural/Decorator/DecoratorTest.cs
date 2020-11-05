using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Structural.Decorator
{
    public class DecoratorTest
    {
        [Fact]
        public void ShouldWriteToJsonUsingDecorator()
        {
            string data = "decorator test clsaa";
            IWritter writter = new textWritter();
            var jsonWritter = new JsonWriterDecorator(writter);
            bool success = jsonWritter.WriteTOJson(data);
            success.Should().BeTrue();
        }
        [Fact]
        public void ShouldWriteToXMLUsingDecorator()
        {
            string data = "decorator test clsaa";
            IWritter writter = new textWritter();
            var xmlWritter = new XmlWriterDecorator(writter);
            bool success = xmlWritter.WriteTOJson(data);
            success.Should().BeTrue();
        }
    }
}
