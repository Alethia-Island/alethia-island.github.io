using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AlethiaIsland.Layout;

public partial class MainLayout
{
    [Inject]
    private AppExtensions? AppExtensions { get; set; }

    [Inject]
    private IJSRuntime? JSRuntime { get; set; }

    private string? PageIcon { get; set; }
    private string? PageTitle { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (AppExtensions is not null)
        {
            AppExtensions.SetTitle += SetTitle;
        }
        await base.OnInitializedAsync();
    }

    private ValueTask? GoBack() => JSRuntime?.InvokeVoidAsync("window.history.back");

    private async Task SetTitle(string? title, string? icon)
    {
        PageIcon = icon;
        PageTitle = title;
        await InvokeAsync(StateHasChanged);
        //Console.WriteLine(JSRuntime?.InvokeAsync<object>("window.history.length.valueOf"));
    }
}