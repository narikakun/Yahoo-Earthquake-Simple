using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo_Earthquake_Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            GetEarthqukaeList();
        }

        private static void GetEarthqukaeList()
        {
            // Yahoo地震の一覧を取得
            var request = WebRequest.Create("https://typhoon.yahoo.co.jp/weather/jp/earthquake/list/");
            var response = request.GetResponse();
            var responseString = response.GetResponseStream();
            var encode = new StreamReader(responseString, Encoding.UTF8);
            var request_html = encode.ReadToEnd();
            // スクレイピング
            var document = new HtmlParser().ParseDocument(request_html);
            var list_table = document.QuerySelectorAll("#main > .yjw_main_md > #eqhist > table > tbody > tr").Skip(1);
            foreach (var item in list_table)
            {
                Console.WriteLine(item.TextContent);
            }
            Console.ReadKey(true);
        }
    }
}
