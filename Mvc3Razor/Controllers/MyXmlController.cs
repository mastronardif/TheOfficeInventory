using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using RestSharp;

namespace Mvc3Razor.Controllers
{
    public class MyXmlController : Controller
    {
        //
        // GET: /MyXml/
        public ActionResult JustOneDb()
        {
            ViewBag.fuck = "<h1>Test JustONeDb!</h1>";
            ///////////
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                {

                    var client = new RestClient();
                    client.BaseUrl = "https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/";
                    //client.BaseUrl = "https://api-dev.bugzilla.mozilla.org/1.1/";
                    client.Authenticator = new HttpBasicAuthenticator("zn0lvkpdhdxb70l2ub4", "iy59bj7rh0z6uurshn5e7i41lb3fiwuh");

                    var request22 = new RestRequest();
                    request22.Resource = "/session";

                    RestResponse response22 = client.Execute(request22);
                    return Content(response22.Content);
                }


                String Xml;
                // Create the web request 
                // curl -k -X POST https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session  
                //curl -k -X GET             https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session
                //string url = @"https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";

                // Fm 4/5/12
                //curl -k -X GET https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session
                //string url = @"https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";
                string url = @"https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";

                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";

                //request.Method = "HEAD";
                //request.AllowAutoRedirect = false;
                request.Credentials = CredentialCache.DefaultCredentials;

                // Ignore Certificate validation failures (aka untrusted certificate + certificate chains)
                ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                ((HttpWebRequest)request).AllowWriteStreamBuffering = true;

                // Get response 
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    // Get the response stream 
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    Xml = reader.ReadToEnd();
                }
                return Content(Xml);
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
