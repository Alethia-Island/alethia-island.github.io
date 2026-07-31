using Microsoft.AspNetCore.Components;

namespace AlethiaIsland.Pages;

public partial class ObjectSelfService
{
    [Inject]
    private HttpClient? Http { get; set; }

    private MarkupString Output = new();

    protected override async Task OnInitializedAsync()
    {
        Output = new(await Http.GetMarkdownAsHtml($"{AppConfig.LinksRepo}/object_return_service.md"));
        await base.OnInitializedAsync();
    }
}
