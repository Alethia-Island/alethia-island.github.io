using CommonMark;

namespace AlethiaIsland;

public static class HttpClientExtensions
{
    public static Task<string> GetMarkdownAsHtml(this HttpClient client, string uri, CancellationToken cancellationToken = default) =>
        GetMarkdownAsHtml(client, new Uri(uri), cancellationToken);

    public static async Task<string> GetMarkdownAsHtml(this HttpClient client, Uri uri, CancellationToken cancellationToken = default)
    {
        using var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return string.Empty;

        var markdown = await response.Content.ReadAsStringAsync(cancellationToken);
        return CommonMarkConverter.Convert(markdown);
    }
}
