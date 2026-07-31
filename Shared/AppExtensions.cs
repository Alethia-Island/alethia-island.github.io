namespace AlethiaIsland.Shared;

public sealed class AppExtensions
{
    public event Func<string?, string?, Task>? SetTitle;

    public Task SetPageTitle(string? title, string? icon = null) =>
        SetTitle?.Invoke(title, icon) ?? Task.CompletedTask;
}
