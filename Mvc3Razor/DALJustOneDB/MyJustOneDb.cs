using System.Net;
using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

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
  //      StringBuilder sb22 = new StringBuilder();
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
        else //            if (1 == 2) //(stuff.session)
        {
            TheSessions.Add((string)stuff.session);
        }

    }

    static List<string> getSessions()
    {
        //create sessions curl -k -X POST https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session  
        string results = string.Empty;
        string strBuff = String.Empty;
        StringBuilder sb22 = new StringBuilder();

        try
        {
            TheSessions.Clear();
            //HttpWebRequest request = null;
            //HttpWebResponse response = null;

            string Xml;
            // Create the web request 
            // curl -k -X POST https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session  
            //curl -k -X GET             https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session
            //string url = @"https://77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session";

            // fm 4/12/12 8:03
            // RestCall("POST session  ")
            //Xml = RestCall("GET", "session");
            Xml = RestCall("GET", JUSTONEDB_REST_DB+"/session");
            // fm 4/12/12 8:03

/******************
            request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";

                    string authInfo = @"zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh";
                    request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

                    // Ignore Certificate validation failures (aka untrusted certificate + certificate chains)
                    ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                    ((HttpWebRequest)request).AllowWriteStreamBuffering = true;
                    // Get response 
                    using (response = (HttpWebResponse)request.GetResponse() as HttpWebResponse)
                    {
                        // Get the response stream 
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        Xml = reader.ReadToEnd();
************/
                        setTheSessions(Xml);

                        // If no sessions make one.
                        if (TheSessions.Count == 0)
                        {
                            // RestCall("POST session  ")
                            string str2222 = RestCall("POST", JUSTONEDB_REST_DB + "/session");
                            setTheSessions(str2222);
                            //curl -k -X POST https://zn0lvkpdhdxb70l2ub4:iy59bj7rh0z6uurshn5e7i41lb3fiwuh@77.92.68.105:31415/justonedb/database/n10lvkpdhdxei0l2uja/session  
                            //TheSessions.Add((string)c);
                        }
//                    }
        }
        catch (Exception ee)
        {
            List<string> myVar = new List<string>(new string[] { "Error", ee.ToString() });
            return myVar;
            
        }

        return (TheSessions);
    
    }
}