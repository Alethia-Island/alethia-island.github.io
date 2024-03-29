﻿using CommonMark;

namespace AlethiaIsland
{
    public static class HttpClientExtensions
    {
        public static async Task<string> GetMarkdownAsHtml(this HttpClient? client, string? uri) => await GetMarkdownAsHtml(client, new Uri(uri ?? string.Empty));
        public static async Task<string> GetMarkdownAsHtml(this HttpClient? client, Uri? uri)
        {
            if (client != null)
            {
                var resp = await client.GetAsync(uri);
                if (resp.IsSuccessStatusCode is true)
                {
                    try
                    {
                        return new(CommonMarkConverter.Convert(await resp.Content.ReadAsStringAsync()));
                    }
                    catch (Exception)
                    {
                        throw new NullReferenceException();
                    }
                }
            }
            return string.Empty;
        }
    }
}