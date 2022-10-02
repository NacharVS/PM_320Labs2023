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
        public DbConnection<CharacterDbModel> characterDbConnection;
        public DbConnection<AbilityDbModel> abilityDbConnection;

        public App()
        {
            characterDbConnection = new DbConnection<CharacterDbModel>(
                ConfigurationManager.AppSettings["MongoDbConnectionString"],
                ConfigurationManager.AppSettings["MongoDbName"], 
                ConfigurationManager.AppSettings["MongoCharactersCollectionName"]);

            abilityDbConnection = new DbConnection<AbilityDbModel>(
                ConfigurationManager.AppSettings["MongoDbConnectionString"],
                ConfigurationManager.AppSettings["MongoDbName"],
                ConfigurationManager.AppSettings["MongoAbilityCollectionName"]);
        }
    }
}