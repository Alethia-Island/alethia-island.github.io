using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlethiaIsland.Pages
{
    public partial class ContactUs
    {
        [Inject]
        private HttpClient Http { get; set; }

        private MarkupString Output = new();

        protected override async Task OnInitializedAsync()
        {
            Output = new(await Http.GetMarkdownAsHtml($"{AppConfig.LinksRepo}/contact_us.md"));
            await base.OnInitializedAsync();
        }
    }
}