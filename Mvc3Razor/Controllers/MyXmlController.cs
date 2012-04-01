using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc3Razor.Controllers
{
    public class MyXmlController : Controller
    {
        //
        // GET: /MyXml/

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
