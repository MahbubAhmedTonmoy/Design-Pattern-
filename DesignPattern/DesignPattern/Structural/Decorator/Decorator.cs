using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignPattern.Structural.Decorator
{
    /// <summary>
    /// অবজেক্ট আর সাথে রান টাইম এ নতুন  ফিচার  যোগ  করা যায় 
    /// wrapper (text-> bold -> italic)
    /// add additional features / behaviour to a particular instance of a class, while not modifying the other instance of same class
    /// </summary>
    /// 
    /// Very similar to adapter and Proxy design pattern. Adapter provide new interface,  
    /// Proxy provide same interface for exising object. Decorator provide enhanced interface.
    /// ///
    /// 

    //component
    public interface IWritter
    {
        void write(string data);
    }

    //concrete component
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

    //decorator
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
    //ConcreteDecorator A...
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
    //ConcreteDecorator B...
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
