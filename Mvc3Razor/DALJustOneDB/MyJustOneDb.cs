using System.Net;
using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Mvc3Razor.MyJSON;

//http://www.justonedb.com/wp-content/uploads/2011/09/JustOneDB-REST-Interface-Sep-2011-2.pdf
public static class MyJustOneDB
{
    /*
Key 	Value
JUSTONEDB_REST_BASE 	https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb
JUSTONEDB_REST_DB 	database/n10lvkpdhdxei0l2uja
JUSTONEDB_DBI_URL 	postgres://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:10301/n10lvkpdhdxei0l2uja
JUSTONEDB_SUPPORT_ID 	7bccf301
*/
    //const string REST_BASE = "https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja";
    const string REST_BASE = "https://77.92.68.105:31415/justonedb";
    const string JUSTONEDB_REST_DB  = "/database/n10lvkpdhdxei0l2uja";
    const string authInfo = @"zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh";
    //static string   TheSession;
    //static string[] TheSessions;

    //static List<string> TheSessions;
    static List<string> TheSessions = new List<string>();

    static public string JsonToList(string json)
    {
        string results = string.Empty;
        var jsonSerializer = new JsonSerializer();
        var stuff = jsonSerializer.Deserialize(new JsonTextReader(new StringReader(json)));

        System.Text.StringBuilder myJsonString22 = new System.Text.StringBuilder();
        myJsonString22.Append("{ \"?xml\": { \"@version\": \"1.0\", \"@standalone\": \"no\" }, \"root\":" + json + "}");
        System.Xml.XmlDocument xmlDocument = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(myJsonString22.ToString());

        results = xmlDocument.InnerXml;
            /******
        foreach (var c in stuff.tables)
        {
            //            sb22.AppendFormat("{0}\n", c);
            Tables.Add((string)c);
        }
            *******/
        return results;
    }

    static public string[] Select22(string sql)
    {
        string str = MyJSON.JsonToObj(Mvc3Razor.MyUtility.TestData.mmm);
        return new string[] { str }; 
    }

    static public string[] Select(string sql)
    {
        string jsonSql = "{\"select\":[{\"table\":\"offices\",\"column\":\"Emp\"}]}";

        TheSessions = getSessions();
        string req = TheSessions[0] + "/query";
        string json = RestCallWithJson("POST", req, jsonSql);

        var jsonSerializer = new JsonSerializer();
        dynamic stuff = jsonSerializer.Deserialize(new JsonTextReader(new StringReader(json)));

        string qryId = stuff.query;

        // Fetch rows from query cursor
        jsonSql = "{\"fetch\":\"0\"}";
        json = RestCallWithJson("PUT", qryId, jsonSql);

        // list rows
        //string str = JsonToList(json);
        //string str = MyJSON.JsonToObj(json);
         json = Mvc3Razor.MyUtility.TestData.mmm;
        string str = MyJSON.JsonToXML(json);

        return new string[] {str}; 
        //return TheSessions.ToArray();

    }

    static public string [] listTables() 
    {
        TheSessions = getSessions();
        string req = TheSessions[0] + "/table";
        string Xml = RestCall("GET", req);


        var jsonSerializer = new JsonSerializer();
        dynamic stuff = jsonSerializer.Deserialize(new JsonTextReader(new StringReader(Xml)));

        string results = string.Empty;
        StringBuilder sb22 = new StringBuilder();
        foreach (var c in stuff)
        { sb22.AppendFormat("{0}\n", c); }
        results = sb22.ToString();

        List<string> Tables = new List<string>();
        if (results.Contains("tables") && results.Contains("get"))
        {
            foreach (var c in stuff.get.tables)
            {
                //            sb22.AppendFormat("{0}\n", c);
                Tables.Add((string)c);
            }
        }
        else //            if (1 == 2) //(stuff.session)
        {
            Tables.Add((string)stuff.session);
        }
        string tables = string.Join(",<br/>\n", Tables.ToArray());
        
        Tables.AddRange(TheSessions);

	    string line = string.Join(",<br/>\n", TheSessions.ToArray());

        return Tables.ToArray();
        //return line;
        //return TheSessions.ToArray();

        // get tables

        //return new string[] { "one", "two", "three" }; 
    }

    static string RestCallWithJson(string verb, string req, string postData)
    {
        string results = string.Empty;
        string strBuff = String.Empty;
        StringBuilder sb22 = new StringBuilder();

        try
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            string url = REST_BASE + "/" + req;

            request = (HttpWebRequest)WebRequest.Create(url);

            request.ContentType = "application/json";

            request.Method = verb;

            // authInfo
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

            // Ignore Certificate validation failures (aka untrusted certificate + certificate chains)
            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

            ((HttpWebRequest)request).AllowWriteStreamBuffering = true;

            StreamWriter requestWriter;
            using (requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(postData);
            }

            // Get response 
            using (response = (HttpWebResponse)request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream 
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
        }
        catch (Exception ee)
        {
            //return (new string[] { "Error", ee.ToString() });
            //List<string> myVar = new List<string>(new string[] { "Error", ee.ToString() });
            return ee.ToString();
        }

        return results;
    }



    static string RestCall(string verb, string req)
    {
        string results = string.Empty;
        string strBuff = String.Empty;
        StringBuilder sb22 = new StringBuilder();
              
        try
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            string url = REST_BASE + "/" + req;

            request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = verb;

            // authInfo
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

            // Ignore Certificate validation failures (aka untrusted certificate + certificate chains)
            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

            ((HttpWebRequest)request).AllowWriteStreamBuffering = true;

            // Get response 
            using (response = (HttpWebResponse)request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream 
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
        }
        catch (Exception ee)
        {
            //return (new string[] { "Error", ee.ToString() });
            //List<string> myVar = new List<string>(new string[] { "Error", ee.ToString() });
            return ee.ToString();
        }

        return results;
    }

    static void setTheSessions(string Xml)
    {
        var jsonSerializer = new JsonSerializer();
        dynamic stuff = jsonSerializer.Deserialize(new JsonTextReader(new StringReader(Xml)));

        string results = string.Empty;
        StringBuilder sb22 = new StringBuilder();
        foreach (var c in stuff)
        { sb22.AppendFormat("{0}\n", c); }
        results = sb22.ToString();

        //JObject jjj = (JObject) (stuff);
        //if (jjj.Property("fuck") == null)
          
        //if (jjj.Property("get.sessions") == null)
        //{
        //    ;
        //}

        TheSessions.Clear();

        
        if(results.Contains("sessions") && results.Contains("get"))
        {
            foreach (var c in stuff.get.sessions)
            {
                //            sb22.AppendFormat("{0}\n", c);
                TheSessions.Add((string)c);
            }
        }
        else
        {
            TheSessions.Add((string)stuff.session);
        }
    }

    static List<string> getSessions()
    {
        try
        {
            TheSessions.Clear();

            string json;
            json = RestCall("GET", JUSTONEDB_REST_DB+"/session");

            setTheSessions(json);

            // If no sessions make one.
            if (TheSessions.Count == 0)
            {
                // RestCall("POST session  ")
                json = RestCall("POST", JUSTONEDB_REST_DB + "/session");
                setTheSessions(json);
            }
        }
        catch (Exception ee)
        {
            List<string> myVar = new List<string>(new string[] { "Error", ee.ToString() });
            return myVar;
        }

        return (TheSessions);
    }
}