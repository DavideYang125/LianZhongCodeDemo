using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LianzhongDemo
{
    public class NetHandle
    {

        public async static Task<string> GetImageAsBase64Url(string url)
        {
            using (var handler = new HttpClientHandler { })
            using (var client = new HttpClient(handler))
            {
                var bytes = await client.GetByteArrayAsync(url);
                return Convert.ToBase64String(bytes);//"image/jpeg;base64," + 
            }
        }
    }

}
