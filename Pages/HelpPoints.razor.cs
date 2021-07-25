﻿using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlethiaIsland.Pages
{
    public partial class HelpPoints
    {
        [Inject]
        private HttpClient Http { get; set; }

        private MarkupString Output = new();

        protected override async Task OnInitializedAsync()
        {
            Output = new(await Http.GetMarkdownAsHtml($"{AppConfig.LinksRepo}/help_points.md"));
            await base.OnInitializedAsync();
        }
    }
}