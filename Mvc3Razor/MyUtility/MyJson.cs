using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mvc3Razor.MyUtility;

namespace Mvc3Razor.MyJSON
{
    public class MyJSON
    {
        static public string JsonToXML(string json)
        {
            string results = string.Empty;
            var jsonSerializer = new JsonSerializer();
            var stuff = jsonSerializer.Deserialize(new JsonTextReader(new StringReader(json)));

            System.Text.StringBuilder myJsonString22 = new System.Text.StringBuilder();
            myJsonString22.Append("{ \"?xml\": { \"@version\": \"1.0\", \"@standalone\": \"no\" }, \"root\":" + json + "}");
            System.Xml.XmlDocument xmlDocument = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(myJsonString22.ToString());

            results = xmlDocument.InnerXml;
            return results;
        }


        static public string JsonToObj(string json)
        {
            string results = string.Empty;
            try
            {
                StringBuilder sb33 = new StringBuilder();

                JObject oJJ = JObject.Parse(json);

                //
                { 
                
                    int iii = oJJ["rows"].Count();
                    bool bGetHeader = true;
                    for (int irow = 0; irow < iii; irow++)
                    {
                        int icols = oJJ["rows"][0]["column"].Count();

                        string sss = (string) oJJ["rows"][0]["column"][0]["name"];
                        if (bGetHeader)
                        {
                        // header
                        for (int icol = 0; icol < icols; icol++ )
                            sb33.AppendFormat("{0}\t", oJJ["rows"][irow]["column"][icol]["name"]);

                        sb33.AppendFormat("\n");
                        bGetHeader = false;
                        }
                        // data
                        for (int icol = 0; icol < icols; icol++)
                            sb33.AppendFormat("{0}\t", oJJ["rows"][irow]["column"][icol]["value"]);

                        sb33.AppendFormat("\n");
                    }
                    results = sb33.ToString();
                    return results;
                
                
                }

                var a = oJJ.SelectToken("rows[1].column")[0]["value"];
                var aid = oJJ.SelectToken("rows[1].column")[1]["value"];
                

                //var a = oJJ.SelectToken("column");

                sb33.Clear();
                foreach (var c in a)
                { sb33.AppendFormat("{0}\n", c); }
                results = sb33.ToString();


                var bib =
                                  from c in oJJ.SelectToken("rows")
                                  select (string)oJJ["column"][0]["value"];

                var fuckbib =
                                  from c in oJJ.SelectToken("rows")
                                  select (string)oJJ["column"]["value"];



                var bb = oJJ["rows"].Select(m => (string)m.SelectToken("column[0].value")).ToList();

                sb33.Clear();
                foreach (var c in bb)
                { sb33.AppendFormat("{0}\n", c); }
                results = sb33.ToString();



                //string name = (string)o.SelectToken("Manufacturers[0].Name");
                //IList<string> empNames = oJJ["rows"].Select(m => (string)m.SelectToken("column[1].value")).ToList();
                Array empNames = oJJ["rows"].Select(m => (JArray)m.SelectToken("column")).ToArray();

                //var fuck = from j in empNames
                //               Select(j);


                var cols = oJJ["rows"].Select(m => (JArray)m.SelectToken("column")).ToArray();
                var a3 = cols.Select(m => (string)m.SelectToken("column[0].value")).ToList();
                //var fuja3 = cols.Select(m => (string)m.SelectToken("column[0].value", "column[0].value") ).ToList();

                //var aa2 = empNames.Select(m => (string)m.SelectToken("column[0].value")).ToList();

                sb33.Clear();
                foreach (var c in empNames)
                {
                    sb33.AppendFormat("YYY {0} ZZZ\n", c);
                }

                results = sb33.ToString();
                return results;

                Object obj = JsonConvert.DeserializeObject(json);

                var jsonSerializer = new JsonSerializer();
                dynamic stuff = jsonSerializer.Deserialize(new JsonTextReader(new StringReader(json)));

                JObject o = (JObject)jsonSerializer.Deserialize(new JsonTextReader(new StringReader(json)));
                //rss["rows"][0]["row"]

                var postTitles =
  from p in o["rows"].Children()
  select (string)p["row"];


                sb33.Clear();
                foreach (var c in postTitles)
                { sb33.AppendFormat("{0}<br/>\n", c); }


                //  group c by c into g
                //  orderby g.Count() descending

                //var categories =
                //  //from c in rss["channel"]["item"].Children()["category"].Values<string>()
                //  from c in rss[0][0].Children()[0].Values<string>()
                //  group c by c into g
                //  orderby g.Count() descending
                //  select new { Category = g.Key, Count = g.Count() };


                return sb33.ToString();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: {0}", e.ToString());
                return e.ToString();
            }
        
        }

        public static string Transform(string json, string xslPath)
        {
            
            try
            {
                Object obj = JsonConvert.DeserializeObject(json);
                StringBuilder sb22 = new StringBuilder();

                var jsonSerializer = new JsonSerializer();
                dynamic stuff = jsonSerializer.Deserialize(new JsonTextReader(new StringReader(json)));

                var name = stuff.session;
                string str = stuff.message;

                string strBuff = String.Empty;
                
                foreach (var c in stuff)
                { sb22.AppendFormat("{0}\n", c); }
                //{ strBuff += (c); strBuff += "\n"; }
                return sb22.ToString();

            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: {0}", e.ToString());
                return e.ToString();
            }
        }

    }
}