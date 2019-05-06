using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace LianzhongDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LianZhongCode();
            Console.WriteLine("Hello World!");
        }
        public static string LianZhongCode()
        {
            var url = "";
            var img64 = NetHandle.GetImageAsBase64Url(url).Result;
            RequestModel rm = new RequestModel();
            rm.captchaData = img64;
            rm.softwareId = 0;
            rm.softwareSecret = "";
            rm.username = "";
            rm.password = "";
            rm.captchaType = 1001;
            var api = "https://v2-api.jsdama.com/upload";
            using (var _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Add("host", "v2-api.jsdama.com");
                _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36");
                StringContent content = new StringContent(JsonConvert.SerializeObject(rm), Encoding.UTF8,
                                "application/json");
                HttpResponseMessage response = _client.PostAsync(api, content).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("返回结果--" + result);
                if (!result.Contains("recognition")) return string.Empty;
                dynamic resultObj = JsonConvert.DeserializeObject(result);
                var data = resultObj["data"];
                string recognition = data["recognition"];
                Console.WriteLine("验证码:" + recognition);
                return recognition.Trim();
            }
        }
    }
}
