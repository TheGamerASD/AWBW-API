using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading.Tasks;

namespace AWBW
{
    internal static class Utils
    {
        public static async Task<HttpResponseMessage> HttpGet(this HttpClient client, string page)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Host", "awbw.amarriner.com");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*; q = 0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.Add("Origin", "https://awbw.amarriner.com");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
            client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            client.DefaultRequestHeaders.Add("Sec-GPC", "1");
            client.DefaultRequestHeaders.Add("Pragma", "no-cache");

            HttpResponseMessage response = await client.GetAsync($"https://awbw.amarriner.com/{page}");

            return response;
        }

        public static async Task<HttpResponseMessage> HttpGet(this HttpClient client, string page, string cookie)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Host", "awbw.amarriner.com");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*; q = 0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.Add("Origin", "https://awbw.amarriner.com");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("Cookie", cookie);
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
            client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            client.DefaultRequestHeaders.Add("Sec-GPC", "1");
            client.DefaultRequestHeaders.Add("Pragma", "no-cache");

            HttpResponseMessage response = await client.GetAsync($"https://awbw.amarriner.com/{page}");

            return response;
        }

        public static async Task<HttpResponseMessage> HttpPost(this HttpClient client, string page, string referer, string cookie, params (string key, string value)[] body)
        {
            List<KeyValuePair<string, string>> requestBody = new();

            foreach ((string key, string value) pair in body)
            {
                requestBody.Add(new(pair.key, pair.value));
            }

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Host", "awbw.amarriner.com");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*; q = 0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.Add("Origin", "https://awbw.amarriner.com");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Referer", $"https://awbw.amarriner.com/{referer}");
            client.DefaultRequestHeaders.Add("Cookie", cookie);
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
            client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            client.DefaultRequestHeaders.Add("Sec-GPC", "1");
            client.DefaultRequestHeaders.Add("Pragma", "no-cache");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            FormUrlEncodedContent content = new(requestBody);

            HttpResponseMessage response = await client.PostAsync($"https://awbw.amarriner.com/{page}", content);

            return response;
        }

        public static async Task<HttpResponseMessage> HttpPost(this HttpClient client, string page, string referer, params (string key, string value)[] body)
        {
            List<KeyValuePair<string, string>> requestBody = new();

            foreach ((string key, string value) pair in body)
            {
                requestBody.Add(new(pair.key, pair.value));
            }

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Host", "awbw.amarriner.com");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*; q = 0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.Add("Origin", "https://awbw.amarriner.com");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Referer", $"https://awbw.amarriner.com/{referer}");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
            client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            client.DefaultRequestHeaders.Add("Sec-GPC", "1");
            client.DefaultRequestHeaders.Add("Pragma", "no-cache");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            FormUrlEncodedContent content = new(requestBody);

            HttpResponseMessage response = await client.PostAsync($"https://awbw.amarriner.com/{page}", content);

            return response;
        }
    }
}
