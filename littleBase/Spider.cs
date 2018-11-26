using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;



namespace littleBase
{
    public class Spider
    {
        public string url { set; get; }
        public string context { set; get; }
        public Uri uri;

        public async Task RunSpiderAsync()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.Headers = GenerateHeader();
            //request.CookieContainer = GenerateCookie();
            

            HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync();
            
            Stream content = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(content,Encoding.UTF8))
            {
                context = reader.ReadToEnd();
                var s = context.Length;
            }


        }


        public Spider(string _url)
        {
            url = _url;
            uri = new Uri(url);
        }

        public Spider()
        {
            //url = @"https://weibo.com/?category=0";
            //url = "https://weibo.com/?topnav=1&mod=logo";
            url = @"https://weibo.com/";
            uri = new Uri(url);
        }

        private WebHeaderCollection GenerateHeader()
        {
            WebHeaderCollection collection = new WebHeaderCollection();
            collection["Accept"] = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            collection["Accept-Encoding"] = "deflate,br";
            collection["Accept-Language"] = "en-US,en;q=0.8,zh-Hans-CN;q=0.5,zh-Hans;q=0.3";
            collection["Cache-Control"] = "max-age=0";
            collection["Connection"] = "Keep-Alive";
            collection["User-Agent"] =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/18.17763";
            collection["DNT"] = "1";
            collection["Host"] = "weibo.com";
            collection["Referer"] =
                @"https://www.baidu.com/link?url=uoCt8hEHMde3xHT3jMfHFJjKpKhv7gRSopBUSFR904u&wd=&eqid=a12fc6ab0001d2e1000000035bfb7ff3";
            collection["Upgrade-Insecure-Requests"] = "1";
            collection["Cookie"] =
                "Ugrow-G0=8751d9166f7676afdce9885c6d31cd61; SUB=_2AkMsp_HJf8NxqwJRmPATy2_jZYp0ygnEieKa-wASJRMxHRl-yT83qkE8tRB6ByffJgg_Ea4VJLE8BiTqvI-ozpBEexuj; SUBP=0033WrSXqPxfM72-Ws9jqgMF55529P9D9WhQPRHO35ydOWB41XX7a7_M; login_sid_t=3904899b15b7cda2b089bdc896e5e74b; cross_origin_proto=SSL; YF-V5-G0=c948c7abbe2dbb5da556924587966312; wb_view_log=1670*9391.149999976158142; _s_tentry=passport.weibo.com; Apache=9261249851406.36.1543208520399; SINAGLOBAL=9261249851406.36.1543208520399; ULV=1543208520415:1:1:1:9261249851406.36.1543208520399:; UOR=,,www.baidu.com";
            return collection;

        }

        private CookieContainer GenerateCookie()
        {
            //CookieCollection collection = new CookieCollection();
            CookieContainer container = new CookieContainer();
          
            Cookie c1 = new Cookie("_s_tentry","passport.weibo.com"); 
            Cookie c2 = new Cookie("Apache", "9261249851406.36.1543208520399");
            Cookie c3 = new Cookie("cross_origin_proto","SSL");
            Cookie c4 = new Cookie("login_sid_t","3904899b15b7cda2b089bdc896e5e74b");
            Cookie c5 = new Cookie("SINAGLOBAL","9261249851406.36.1543208520399");
            Cookie c6 = new Cookie("SUB","_2AkMsp_HJf8NxqwJRmPATy2_jZYp0ygnEieKa-wASJRMxHRl-yT83qkE8tRB6ByffJgg_Ea4VJLE8BiTqvI-ozpBEexuj");
            Cookie c7 = new Cookie("SUBP","0033WrSXqPxfM72-Ws9jqgMF55529P9D9WhQPRHO35ydOWB41XX7a7_M");
            Cookie c8 = new Cookie("Ugrow-G0","8751d9166f7676afdce9885c6d31cd61");
            Cookie c9 = new Cookie("ULV","1543208520415:1:1:1:9261249851406.36.1543208520399:");
            Cookie c10 = new Cookie("UOR",",, www.baidu.com");
            Cookie c11 = new Cookie("wb_view_log","1670 * 9391.149999976158142");
            Cookie c12 = new Cookie("YF-V5- G0","c948c7abbe2dbb5da556924587966312");
            container.Add(uri,c1);
            container.Add(uri, c2);
            container.Add(uri, c3);
            container.Add(uri, c4);
            container.Add(uri, c5);
            container.Add(uri, c6);
            container.Add(uri, c7);
            container.Add(uri, c8);
            container.Add(uri, c9);
            container.Add(uri, c10);
            container.Add(uri, c11);
            container.Add(uri, c12);

            //collection.Add(c1);
            //collection.Add(c2);
            //collection.Add(c3);
            //collection.Add(c4);
            //collection.Add(c5);
            //collection.Add(c6);
            //collection.Add(c7);
            //collection.Add(c8);
            //collection.Add(c9);
            //collection.Add(c10);
            //collection.Add(c11);
            //collection.Add(c12);
            return container;

        }



    }
}
