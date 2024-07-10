namespace AlethiaIsland.Shared;

public class AppExtensions
{
    public event Func<string?, string?, Task>? SetTitle;

    public void SetPageTitle(string? title, string? icon = null)
    {
        SetTitle?.Invoke(title, icon);
    }
}