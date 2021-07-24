using CommonMark;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlethiaIsland
{
    public static class HttpClientExtensions
    {
        public static async Task<string> GetMarkdownAsHtml(this HttpClient client, string uri) => await GetMarkdownAsHtml(client, new Uri(uri));
        public static async Task<string> GetMarkdownAsHtml(this HttpClient client, Uri uri)
        {
            var resp = await client.GetAsync(uri);
            if (resp.IsSuccessStatusCode is true)
                return new(CommonMarkConverter.Convert(await resp.Content.ReadAsStringAsync()));

            return string.Empty;
        }
    }
}