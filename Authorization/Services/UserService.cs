using Authorization.Module;

namespace Authorization.Services
{
    public class UserService
    {
        public UserService()
        {
            UserLog = new User();
        }
        public User UserLog { get; set; }

        protected Task UserAsync()
        {
            return Task.CompletedTask;
        }
    }
}
