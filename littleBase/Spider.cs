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


        public async Task RunSpiderAsync()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.Headers = GenerateHeader();

            HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync();
            
            Stream content = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(content))
            {
                context = reader.ReadToEnd();
            }


        }


        public Spider(string _url)
        {
            url = _url;
        }

        public Spider()
        {
            //url = @"https://weibo.com/?category=0";
            //url = "https://weibo.com/?topnav=1&mod=logo";
            url = @"https://weibo.com/";
        }

        private WebHeaderCollection GenerateHeader()
        {
            WebHeaderCollection collection = new WebHeaderCollection();
            collection["Accept"] = "text/ html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            collection["Accept-Encoding"] = "gzip, deflate, br";
            collection["Accept-Language"] = "en-US,en;q = 0.8,zh-Hans-CN;q = 0.5,zh-Hans;q=0.3";
            collection["Cache-Control"] = " max-age = 0";
            collection["Connection"] = "Keep-Alive";
            collection["User-Agent"] =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/18.17763";
            collection["DNT"] = "1";
            collection["Host"] = "weibo.com";
            collection["Referer"] =
                "https://www.baidu.com/link?url=uoCt8hEHMde3xHT3jMfHFJjKpKhv7gRSopBUSFR904u&wd=&eqid=a12fc6ab0001d2e1000000035bfb7ff3";
            collection["Upgrade-Insecure-Requests"] = "1";
            return collection;

        }

        private CookieCollection GenerateCookie()
        {
            CookieCollection collection;

            Cookie c1 = new Cookie("_s_tentry","passport.weibo.com"); 
            Cookie c2 = new Cookie();
                

        }



    }
}
