using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignPattern.Structural.Decorator
{
   
    public interface IWritter
    {
        void write(string data);
    }
    public class textWritter : IWritter
    {
        private FileInfo fileInfo = new FileInfo("ReportFile.txt");
        public void write(string data)
        {
            byte[] dataBytes = System.Text.UTF8Encoding.UTF8.GetBytes(data);
            using(FileStream fileStream = fileInfo.OpenWrite())
            {
                fileStream.Write(dataBytes);
            }
        }
    }

    public abstract class WriterDecorator : IWritter
    {
        protected readonly IWritter writter;
        private readonly Transformer transformer = new Transformer();

        public WriterDecorator(IWritter writter)
        {
            this.writter = writter;
        }
        public void write(string data)
        {
            writter.write(data);
        }
    }

    public class JsonWriterDecorator : WriterDecorator
    {
        public JsonWriterDecorator(IWritter writter):base(writter)
        {

        }
        public bool WriteTOJson(string data)
        {
            string json = Transformer.TransformJson(data);
            writter.write(json);
            return true;
        }
    }
    public class XmlWriterDecorator : WriterDecorator
    {
        public XmlWriterDecorator(IWritter writter) : base(writter)
        {

        }
        public bool WriteTOJson(string data)
        {
            string xml = Transformer.TransformXML(data);
            writter.write(xml);
            return true;
        }
    }

    public class Transformer
    {
        public static string TransformXML(string data)
        {
            return $"<root><message>{data}</message></root>";
        }
        public static string TransformJson(string data)
        {
            return $@"{"message"} : ""{data}""";
        }
    }
}
