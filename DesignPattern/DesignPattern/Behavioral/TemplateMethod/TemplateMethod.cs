using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Behavioral.TemplateMethod
{
    /// <summary>
    /// এর আগে আমরা যারা স্ট্র্যাটেজি ডিজাইন প্যাটার্ন পড়েছি তারা একটা বিষয়ে আগে থেকেই ক্লিয়ার যে , কখনও কখনও আমাদের এপ্লিকেশনে 
    /// এমন কিছু কাজ করি যার অ্যালগরিদম রান টাইমে চেঞ্জ করে ফেলা যায় । যেমন সর্টিং অ্যালগরিদম এর Array এর সাইজ হিসেব করে  আমরা 
    /// রান টাইমে সর্টিং অ্যালগরিদম চেঞ্জ করে ফেলতে পারি ।
    /// এখন আমাদের এপ্লিকেশন ডেভেলপের সময় এরকম প্রয়োজন হতে পারে যে, আমরা যে কাজটি(যেমন সর্টিং) করার জন্য অ্যালগরিদম ইউজ করব
    /// সে অ্যালগরিদম ঠিকই থাকবে কিন্তু সেই অ্যালগরিদম এর কিছু স্টেপ পরিবর্তন হবে।
    /// </summary>
    public class TemplateMethod
    {
    }

    public abstract class Document
    {
        protected StringBuilder document;
        public Document(StringBuilder document)
        {
            this.document = document;
        }
        public string GenerateDocument()
        {
            CreateHeaderSection();
            CreateBodySection();
            CreateFooterSection();
            return document.ToString();
        }
        protected abstract void CreateHeaderSection();
        protected abstract void CreateBodySection();
        protected abstract void CreateFooterSection();
    }

    public class XmlDocument : Document
    {
        public XmlDocument(StringBuilder document):base(document)
        {

        }
        protected override void CreateBodySection()
        {
            document.Append($"<body>This is Document Body.</body>");
        }

        protected override void CreateFooterSection()
        {
            document.Append($"<footer>This is Document Footer.</footer></root>");
        }

        protected override void CreateHeaderSection()
        {
            document.Append($"<root><header>This is Document Header.</header>");
        }
    }

    public class JsonDocument : Document
    {
        public JsonDocument(StringBuilder docuemnt) : base(docuemnt)
        {
        }

        protected override void CreateBodySection()
        {
            document.Append(@"""body"":""This is Document Body."",");
        }

        protected override void CreateFooterSection()
        {
            document.Append(@"""footer"": ""This is Document Footer.""}");
        }

        protected override void CreateHeaderSection()
        {
            document.Append(@"{""header"": ""This is Document Header."",");
        }
    }
}
