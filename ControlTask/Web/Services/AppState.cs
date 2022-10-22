using Core.Entities;

namespace Web.Services;

public class AppState
{
    public User CurrentUser { get; private set; }

    public event Action OnChange;

    public void SetCurrentUser(User user)
    {
        CurrentUser = user;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}