using Authorization_1.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization_1.ClassApp
{
    public static class DBConnection
    {
        public static AuthorizationEntities Connection = new AuthorizationEntities();
    }
}