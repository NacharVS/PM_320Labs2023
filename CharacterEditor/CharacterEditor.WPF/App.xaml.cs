using System.Configuration;
using System.Windows;
using CharacterEditor.Core;
using CharacterEditor.MongoDB;

namespace CharacterEditor.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MongoConnection Connection { get; }
        public ICharacterRepository CharacterRepository { get; }

        public App()
        {
            Connection = new MongoConnection(
                ConfigurationManager.AppSettings["MongoConnection"],
                ConfigurationManager.AppSettings["MongoDatabase"]);
            CharacterRepository = new CharacterRepository(Connection);
        }
    }
}