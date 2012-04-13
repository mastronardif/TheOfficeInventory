using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using RestSharp;

using System.Xml;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace Mvc3Razor.Controllers
{
    public class MyXmlController : Controller
    {

        // callback used to validate the certificate in an SSL conversation
        private static bool ValidateRemoteCertificate(
        object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors policyErrors
        )
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["IgnoreSslErrors"]))
            {
                // allow any old dodgy certificate...
                return true;
            }
            else
            {
                //return policyErrors == SslPolicyErrors.None;
                // FM
                return true;
            }
        }

        private static string MakeRequest(string uri, string method, WebProxy proxy)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.AllowAutoRedirect = true;
            webRequest.Method = method;

            // allows for validation of SSL conversations
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(
                ValidateRemoteCertificate
            );

            if (proxy != null)
            {
                webRequest.Proxy = proxy;
            }

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        public ActionResult Pinterest()
        {
            try
            {
                var client = new RestClient();
                client.BaseUrl = "https://api.pinterest.com/v2/popular/";

                var request22 = new RestRequest();

                RestResponse response22 = client.Execute(request22);

                string myJsonString = response22.Content;
                System.Text.StringBuilder myJsonString22 = new System.Text.StringBuilder();
                myJsonString22.Append("{ \"?xml\": { \"@version\": \"1.0\", \"@standalone\": \"no\" }, \"root\":" + myJsonString + "}");

                string json = myJsonString22.ToString();

                System.Xml.XmlDocument xmlDocument = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json);

                //System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter("json.xml", null);
                //xmlTextWriter.Formatting = System.Xml.Formatting.Indented;

                // fm 4/11/12

                StringBuilder sb = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.Encoding = Encoding.UTF8;
                settings.CloseOutput = false;
                settings.CheckCharacters = true;

                XmlWriter w = XmlWriter.Create(sb, settings); 
                //System.Xml.XmlWriter xmlTextWriter22 = new System.Xml.XmlTextWriter(w, null);
                xmlDocument.Save(w);

                string resutls = (xmlDocument).InnerXml;

                Response.ContentType = "text/xml";
                return Content(resutls);
                //return Content(response22.Content);
            }
            catch (Exception ee)
            {
                return Content(ee.ToString());
            }
            
        }

        //
        // GET: /MyXml/
        public ActionResult JustOneDb()
        {
            ViewBag.fuck = "<h1>Test JustONeDb!</h1>";
            ViewBag.fn = "*.xml";
            ///////////
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {

                String Xml;
                // Create the web request 
                // curl -k -X POST https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session  
                //curl -k -X GET             https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session
                string url = @"https:77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";
                //                string url = @"https://api.pinterest.com/v2/popular/";
                // Fm 4/5/12
                //curl -k -X GET https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session
                //string url = @"https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";
                //string url = @"https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";


                if (1 == 1)
                {
                    url = @"https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";
                    //                    url =  @"https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session//9342041334159164/table";
                    // fm works request = (HttpWebRequest)WebRequest.Create("https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/");
                    request = (HttpWebRequest)WebRequest.Create(url);

                    request.Method = "GET";

                    string authInfo = @"zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh";
                    request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));


                    //request.Method = "HEAD";
                    //request.AllowAutoRedirect = true;
                    //request.Credentials = CredentialCache.DefaultCredentials;
                    //request.Credentials = new NetworkCredential("zn0lvkpdhdxb70l2ub4", "zn0lvkpdhdxb70l2ub4");


                    // Ignore Certificate validation failures (aka untrusted certificate + certificate chains)
                    ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                    ((HttpWebRequest)request).AllowWriteStreamBuffering = true;

                    // Get response 
                    using (response = (HttpWebResponse)request.GetResponse() as HttpWebResponse)
                    {
                        // Get the response stream 
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        Xml = reader.ReadToEnd();

                        Object obj = JsonConvert.DeserializeObject(Xml);

                        var jsonSerializer = new JsonSerializer();
                        dynamic stuff = jsonSerializer.Deserialize(new JsonTextReader(new StringReader(Xml)));

                        var name = stuff.session;
                        string str = stuff.message;

                        string strBuff = String.Empty;
                        StringBuilder sb22 = new StringBuilder();
                        foreach (var c in stuff)
                        { sb22.AppendFormat("{0}\n", c); }
                        //{ strBuff += (c); strBuff += "\n"; }

                        //MyJustOneDB db;
                        string[] array = MyJustOneDB.listTables();
                        string result = "<br/><br/>\n"+ string.Join("<br/>\n", array);
                        /*****
                        for (int i = 0; i < str.Length; i++)
                            Console.Write(str[i] + " ");  
                                                
                         * *********/

                        Object obj22 = new Object();
                        JsonConvert.PopulateObject(Xml, obj22);
                        return Content(sb22.ToString()+result);
                    //return Content(Xml);

                    }
                }
            }
            catch (Exception ee)
            {
                return Content(ee.ToString());

            }
            //////////////

            //return View();
        }

        public ActionResult JustOneDbOldShit()
        {
            ViewBag.fuck = "<h1>Test JustONeDb!</h1>";
            ///////////
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                if (1 == 12)
                {

                    var client = new RestClient();
                    client.BaseUrl = "https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/";
                    //client.BaseUrl = "https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";
                //    client.BaseUrl =  "https://api.pinterest.com/v2/popular/";
                    //client.Authenticator = new HttpBasicAuthenticator("zn0lvkpdhdxb70l2ub4", "iy59bj7rh0z6uurshn5e7i41lb3fiwuh");
                    //  request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                    //string authInfo = @"zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh";
                    //client.AddDefaultHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authInfo)));
                    var request22 = new RestRequest();
                    //request22.Resource = "/session";

                    RestResponse response22 = client.Execute(request22);
                    //return Content("h f");
                    return Content(response22.Content);
                }


                String Xml;
                // Create the web request 
                // curl -k -X POST https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session  
                //curl -k -X GET             https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session
                string url = @"https:77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";
                //                string url = @"https://api.pinterest.com/v2/popular/";
                // Fm 4/5/12
                //curl -k -X GET https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session
                //string url = @"https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";
                //string url = @"https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";

                if(1==15)
                { 
                    string strResp =  MakeRequest("https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session",
                                                  "GET", null);

                    return Content(strResp);
                
                }

                if (1==1)
                {
                    url = @"https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";
//                    url =  @"https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session//9342041334159164/table";
                // fm works request = (HttpWebRequest)WebRequest.Create("https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/");
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";

                string authInfo = @"zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh";
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));


                //request.Method = "HEAD";
                //request.AllowAutoRedirect = true;
                //request.Credentials = CredentialCache.DefaultCredentials;
                //request.Credentials = new NetworkCredential("zn0lvkpdhdxb70l2ub4", "zn0lvkpdhdxb70l2ub4");


                // Ignore Certificate validation failures (aka untrusted certificate + certificate chains)
                ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                ((HttpWebRequest)request).AllowWriteStreamBuffering = true;

                // Get response 
                using (response = (HttpWebResponse)request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream 
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    Xml = reader.ReadToEnd();

                    Object obj = JsonConvert.DeserializeObject(Xml);
                }
                return Content(Xml);
                }
            }
            catch (Exception ee)
            {
                return Content(ee.ToString());
            
            }
            //////////////

            ViewBag.fn = "*.xml";
            return View();
        }


        public ActionResult Test22()
        {
            ViewBag.fuck = "<h1>hey ya big dummy!</h1>";
            ViewBag.fnXml = "detail.xml";
            ViewBag.fnXsl = "myTable.xsl";
            return View("dummy");
        }


        public ActionResult Test()
        {
            ViewBag.fuck = "<h1>Test shit here!</h1>";
            ViewBag.fn = "*.xml";
            return View();
        }

        public ActionResult Office()
        {
            ViewBag.fuck = "<h1>The Office </h1>";
            ViewBag.fn = "office2.htm";
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult ViewPage1()
        {
            return View();
        }



    }

}
