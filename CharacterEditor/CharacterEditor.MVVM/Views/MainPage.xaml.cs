using System.Windows;
using System.Windows.Controls;
using CharacterEditor.MVVM.ViewModels;
using CharacterEditor.MVVM.ViewModels.Base;

namespace CharacterEditor.MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private ViewModel _viewModel => (MainWindowViewModel)DataContext;
        private Page? _nextPage;
        
        public MainPage()
        {
            InitializeComponent();
            Loaded += OnNavigatedTo;
            _nextPage = new MatchGenerator();
        }

        private void OnNavigatedTo(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService is null)
                return;
            NavigationService.Navigate(_nextPage);
        }
    }
}