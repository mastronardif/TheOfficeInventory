using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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


    }
}