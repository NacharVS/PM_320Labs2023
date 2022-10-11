using CharacterEditorMongoDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for MathInfo.xaml
    /// </summary>
    public partial class MathInfo : Page
    {
        private readonly CharacterEditorContext _charContext;
        public MathInfo(CharacterEditorContext charContext)
        {
            InitializeComponent();

            _charContext = charContext;
            
            lvCharactersList.ItemsSource = _charContext.GetAllChars();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
