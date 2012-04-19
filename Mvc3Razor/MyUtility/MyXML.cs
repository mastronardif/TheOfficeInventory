using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Text;

namespace Mvc3Razor.MyXML
{
    public class MyXML
    {
        public static string Transform(string xml, string xslPath)
        {
            try
            {
                //create an XPathDocument using the reader containing the XML
                MemoryStream m = new MemoryStream(System.Text.Encoding.Default.GetBytes(xml));

                XPathDocument xpathDoc = new XPathDocument(new StreamReader(m));

                //Create the new transform object
                XslCompiledTransform transform = new XslCompiledTransform();

                //String to store the resulting transformed XML
                StringBuilder resultString = new StringBuilder();

                XmlWriter writer = XmlWriter.Create(resultString);

                transform.Load(xslPath);

                transform.Transform(xpathDoc,writer);
               
                return resultString.ToString();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: {0}", e.ToString());
                return e.ToString();
            }
        }

    }
}