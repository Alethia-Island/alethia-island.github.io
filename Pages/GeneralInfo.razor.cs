using Microsoft.AspNetCore.Components;

namespace AlethiaIsland.Pages
{
    public partial class GeneralInfo
    {
        [Inject]
        private HttpClient Http { get; set; }

        private MarkupString Output = new();

        protected override async Task OnInitializedAsync()
        {
            Output = new(await Http.GetMarkdownAsHtml($"{AppConfig.LinksRepo}/general_information.md"));
            await base.OnInitializedAsync();
        }
    }
}