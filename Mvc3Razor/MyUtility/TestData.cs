using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc3Razor.MyUtility
{
    static public class TestData
    {
        // test begin
        public static string mmm = (@"{
""count"":4,
        ""status"":0,""query"":""database/n10lvkpdhdxei0l2uja/session/690201334672059/query/3296271334672059"",
        ""rows"":[{""row"":""database/n10lvkpdhdxei0l2uja/session/690201334672059/query/3296271334672059/1"",
        ""column"":
[
{""value"":""Jacqueline"",""name"":""emp"",""table"":""offices""}
,{""value"":""001"",""name"":""id"",""table"":""offices""}
]},
{""row"":""database/n10lvkpdhdxei0l2uja/session/690201334672059/query/3296271334672059/2"",
""column"":
[
{""value"":""Larry"",""name"":""emp"",""table"":""offices""}
,{""value"":""111"",""name"":""id"",""table"":""offices""}
]},
{""row"":""database/n10lvkpdhdxei0l2uja/session/690201334672059/query/3296271334672059/3"",
""column"":
[
{""value"":""Laura"",""name"":""emp"",""table"":""offices""}
,{""value"":""222"",""name"":""id"",""table"":""offices""}
]},
{""row"":""database/n10lvkpdhdxei0l2uja/session/690201334672059/query/3296271334672059/4"",
""column"":
[
{""value"":""Frank"",""name"":""emp"",""table"":""offices""}
,{""value"":""333"",""name"":""id"",""table"":""offices""}
]}
],
""message"":""""
}");

        static public string sManu = (@"{

  ""Stores"": [

    ""Lambton Quay"",

    ""Willis Street""

  ],

  ""Manufacturers"": [

    {

      ""Name"": ""Acme Co"",

      ""Products"": [

        {

          ""Name"": ""Anvil"",

          ""Price"": 50

        }

      ]

    },

    {

      ""Name"": ""Contoso"",

      ""Products"": [

        {

          ""Name"": ""Elbow Grease"",

          ""Price"": 99.95

        },

        {

          ""Name"": ""Headlight Fluid"",

          ""Price"": 4

        }

      ]

    }

  ]

}");

        // test end

    }
}

/*************
http://theofficeinventory.apphb.com/MyXml

 43  git add .
 44  git commit -m "cleanup"
 45  git push
 46  git push appharbor master
 47  history
*******/