using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CharacterCreator.Data;
using CharacterCreator.Data.Models;

namespace CharacterCreator.Core
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DbConnection<CharacterDbModel> connection;

        public App()
        {
            connection = new DbConnection<CharacterDbModel>(ConfigurationManager.AppSettings["MongoDbConnectionString"],
                ConfigurationManager.AppSettings["MongoDbName"], 
                ConfigurationManager.AppSettings["MongoDbName"]);
        }
    }
}