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
        internal const string userAgent = "Mozilla/5.0 (compatible; AWBW-API/1.0; +https://github.com/TheGamerASD/AWBW-API)";

        public static async Task<HttpResponseMessage> HttpGet(this HttpClient client, string page)
        {
            HttpRequestMessage request = new(HttpMethod.Get, $"https://awbw.amarriner.com/{page}");

            request.Headers.Add("Host", "awbw.amarriner.com");
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*; q = 0.8");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            request.Headers.Add("Origin", "https://awbw.amarriner.com");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Sec-Fetch-Dest", "document");
            request.Headers.Add("Sec-Fetch-Mode", "navigate");
            request.Headers.Add("Sec-Fetch-Site", "same-origin");
            request.Headers.Add("Sec-GPC", "1");
            request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add("User-Agent", userAgent);

            HttpResponseMessage response = await client.SendAsync(request);

            return response;
        }

        public static async Task<HttpResponseMessage> HttpGet(this HttpClient client, string page, string cookie)
        {
            HttpRequestMessage request = new(HttpMethod.Get, $"https://awbw.amarriner.com/{page}");

            request.Headers.Add("Host", "awbw.amarriner.com");
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*; q = 0.8");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            request.Headers.Add("Origin", "https://awbw.amarriner.com");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Sec-Fetch-Dest", "document");
            request.Headers.Add("Sec-Fetch-Mode", "navigate");
            request.Headers.Add("Sec-Fetch-Site", "same-origin");
            request.Headers.Add("Sec-GPC", "1");
            request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add("User-Agent", userAgent);
            request.Headers.Add("Cookie", cookie);
            request.Headers.Add("Sec-Fetch-User", "?1");

            HttpResponseMessage response = await client.SendAsync(request);

            return response;
        }

        public static async Task<HttpResponseMessage> HttpPost(this HttpClient client, string page, string referer, string cookie, params (string key, string value)[] body)
        {
            List<KeyValuePair<string, string>> requestBody = new();

            foreach ((string key, string value) pair in body)
            {
                requestBody.Add(new(pair.key, pair.value));
            }

            HttpRequestMessage request = new(HttpMethod.Post, $"https://awbw.amarriner.com/{page}");

            request.Headers.Add("Host", "awbw.amarriner.com");
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*; q = 0.8");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            request.Headers.Add("Origin", "https://awbw.amarriner.com");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Sec-Fetch-Dest", "document");
            request.Headers.Add("Sec-Fetch-Mode", "navigate");
            request.Headers.Add("Sec-Fetch-Site", "same-origin");
            request.Headers.Add("Sec-GPC", "1");
            request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add("User-Agent", userAgent);
            request.Headers.Add("Cookie", cookie);
            request.Headers.Add("Sec-Fetch-User", "?1");
            request.Headers.Add("Referer", $"https://awbw.amarriner.com/{referer}");
            request.Headers.Add("Cache-Control", "no-cache");

            FormUrlEncodedContent content = new(requestBody);
            request.Content = content;

            HttpResponseMessage response = await client.SendAsync(request);

            return response;
        }

        public static async Task<HttpResponseMessage> HttpPost(this HttpClient client, string page, string referer, params (string key, string value)[] body)
        {
            List<KeyValuePair<string, string>> requestBody = new();

            foreach ((string key, string value) pair in body)
            {
                requestBody.Add(new(pair.key, pair.value));
            }

            HttpRequestMessage request = new(HttpMethod.Post, $"https://awbw.amarriner.com/{page}");

            request.Headers.Add("Host", "awbw.amarriner.com");
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*; q = 0.8");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            request.Headers.Add("Origin", "https://awbw.amarriner.com");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Sec-Fetch-Dest", "document");
            request.Headers.Add("Sec-Fetch-Mode", "navigate");
            request.Headers.Add("Sec-Fetch-Site", "same-origin");
            request.Headers.Add("Sec-GPC", "1");
            request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add("User-Agent", userAgent);
            request.Headers.Add("Sec-Fetch-User", "?1");
            request.Headers.Add("Referer", $"https://awbw.amarriner.com/{referer}");
            request.Headers.Add("Cache-Control", "no-cache");

            FormUrlEncodedContent content = new(requestBody);
            request.Content = content;

            HttpResponseMessage response = await client.SendAsync(request);

            return response;
        }
    }
}
