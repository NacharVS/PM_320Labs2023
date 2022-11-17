using Core;
using Core.Interfaces;
using MongoDB;

namespace GasWaterSupply.Service
{
    public class AuthorizationService
    {
        public IPrimaryData? CurrentUser { get; set; }
        private readonly MongoDB<IPrimaryData> _mongoDb;

        public AuthorizationService(MongoDB<IPrimaryData> mongoDb)
        {
            _mongoDb = mongoDb;
        }

        public bool LogIn(string login, string password) 
        {
            IPrimaryData user = MongoDB<IPrimaryData>.FindByLogin(login, "Users");

            if (user.Password == password)
            {
                CurrentUser = user;
                return true;
            }
            else if (user.Password != password) 
            {
                return false;
            }
            return false;
        }
    }
}
