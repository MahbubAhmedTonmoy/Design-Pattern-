using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Xunit;

namespace DesignPattern.Behavioral.TemplateMethod
{
    public class TemplateMethodTest
    {
        [Fact]
        public void ShoudCreateXmlDocument()
        {
            var documentBuilder = new StringBuilder();
            Document document = new XmlDocument(documentBuilder);
            var xmldata = document.GenerateDocument();

            xmldata.Should().NotBeNullOrEmpty();
            var xDoc = XDocument.Parse(xmldata);
            xDoc.Should().NotBeNull();
        }
        [Fact]
        public void ShoudCreateJsonDocument()
        {
            var documentBuilder = new StringBuilder();
            Document document = new JsonDocument(documentBuilder);
            var jsondata = document.GenerateDocument();

            jsondata.Should().NotBeNullOrEmpty();
            var jsonDoc = System.Text.Json.JsonDocument.Parse(jsondata);
            jsonDoc.Should().NotBeNull();
        }
    }
}
