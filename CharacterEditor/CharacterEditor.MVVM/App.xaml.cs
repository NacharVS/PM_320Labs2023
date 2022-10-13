using System.Configuration;
using System.Windows;
using CharacterEditor.Core;
using CharacterEditor.Core.Db;
using CharacterEditor.Core.Exceptions;
using CharacterEditor.MongoDB;

namespace CharacterEditor.MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MongoConnection Connection { get; }
        public ICharacterRepository CharacterRepository { get; }
        public IAbilityRepository AbilityRepository { get; }
        public IItemRepository ItemRepository { get; }
        public IMatchRepository MatchRepository { get; }
        public Character? Character { get; set; }

        public App()
        {
            Connection = new MongoConnection(
                ConfigurationManager.AppSettings["MongoConnection"] ??
                throw new NotFoundException("No connection address"),
                ConfigurationManager.AppSettings["MongoDatabase"] ??
                throw new NotFoundException("No database name"));
            CharacterRepository = new CharacterRepository(Connection);
            AbilityRepository = new AbilityRepository(Connection);
            ItemRepository = new ItemRepository(Connection);
            MatchRepository = new MatchRepository(Connection);
            
            AbilityRepository.InitializeCollection();
            ItemRepository.InitializeCollection();
        }
    }
}