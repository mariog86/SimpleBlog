namespace SimpleBlog.Providers
{
    public interface IAuthorizationProvider
    {
        bool IsLoggedIn { get; }
        bool Login(string userName, string password);
        void Logout();
    }
}