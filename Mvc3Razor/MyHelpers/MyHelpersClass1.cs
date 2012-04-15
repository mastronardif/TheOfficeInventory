using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml;

namespace Mvc3Razor.MyHelpers
{
    public static class MyHelpersClass1
    {

        public static IHtmlString Fuck(string fn)
        {
            //string filePath = HttpContext.Current.Server.MapPath("~/App_Data/000.htm");
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/"+fn);

            //return new HtmlString(@"<b>C:\FxM\MSDev\another mvc\Mvc3Razor\MyHelpers\MyHelpersClass1.cs</b><br/>");
            var streamReader = File.OpenText(filePath);
            var markup = streamReader.ReadToEnd();
            streamReader.Close();

            return new HtmlString(markup);

            //return new HtmlString(path);
        }


        public static IHtmlString ServerSideInclude(this HtmlHelper helper, string serverPath)
        {
            var filePath = HttpContext.Current.Server.MapPath(serverPath);

            // load from file
            var streamReader = File.OpenText(filePath);
            var markup = streamReader.ReadToEnd();
            streamReader.Close();

            return new HtmlString(markup);
        }

        public static IHtmlString ListFiles(string ext)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/");

            string sep = ", <br/>";

            var filteredFiles = Directory.GetFiles(filePath, "*.*")
                                         .Where(file => file.EndsWith("xml") || file.EndsWith("xsl") || file.EndsWith("xslt"))
                                         .ToList();

            for (int iii=0; iii < filteredFiles.Count; iii++)
            {
                filteredFiles[iii] = Path.GetFileName(filteredFiles[iii]);
            }

            string str = String.Join(sep, filteredFiles);
            
            return  new HtmlString(str);
        }

        public static IHtmlString Transform00(string fnxml, string fnxsl)
        {
            string sXslPath = HttpContext.Current.Server.MapPath("~/App_Data/" + fnxsl);

            // FM 4/14/12
            // if string buffs cheesy for now. xslt can be string buf too.  Do that later.
            { 
                bool contains = fnxml.IndexOf(".xml", StringComparison.OrdinalIgnoreCase) >= 0;
                if (!contains && fnxml.Length > 100)
                {
                    return new HtmlString(MyXML.MyXML.Transform(fnxml, sXslPath)); 
                }
                //if (fnxml.Contains(".xml",))
            
            }
            // FM 4/14/12

            string sXmlPath = HttpContext.Current.Server.MapPath("~/App_Data/" + fnxml);
            
            return Transform(sXmlPath, sXslPath);
        }
        public static IHtmlString Transform(string sXmlPath, string sXslPath)
        {
            try
            {
                //load the Xml doc
                XPathDocument myXPathDoc = new XPathDocument(sXmlPath);

                XsltArgumentList args = new XsltArgumentList();

                IDictionary<string, string> parameters = null;
                if (parameters != null)
                {
                    foreach (string key in parameters.Keys)
                    {
                        args.AddParam(key, "", parameters[key]);
                    }
                }
                XslCompiledTransform tt = new XslCompiledTransform();

                //load the Xsl 
                tt.Load(sXslPath);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.ValidationType = ValidationType.DTD;

                //create the output stream
                //XmlTextWriter myWriter = new XmlTextWriter("result.html", null);
                //StringWriter writer = new StringWriter();

                //do the actual transform of Xml
                //myXslTrans.Transform(myXPathDoc, null, myWriter);

                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //StringWriter sw = new StringWriter(sb);

                using (XmlReader reader = XmlReader.Create(sXmlPath, settings))
                {
                    StringWriter writer = new StringWriter();
                    tt.Transform(reader, args, writer);
                    return new HtmlString(writer.ToString());
                }




                //myXslTrans.Transform(myXPathDoc, null, sw);
                //sw.Close();
                //string results = sb.ToString();
                                
                //Console.WriteLine(results);


                //myWriter.Close();
                //return new HtmlString(results);


            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: {0}", e.ToString());
                return new HtmlString(e.ToString());
            }

        }


    }
}