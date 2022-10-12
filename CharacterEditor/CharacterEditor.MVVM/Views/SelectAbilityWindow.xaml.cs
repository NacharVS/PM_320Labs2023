using System.Linq;
using System.Windows;
using CharacterEditor.Core;
using CharacterEditor.Core.Misc;

namespace CharacterEditor.MVVM.Views
{
    /// <summary>
    /// Interaction logic for SelectAbilityWindow.xaml
    /// </summary>
    public partial class SelectAbilityWindow
    {
        public Ability SelectedAbility { get; private set; } = null!;

        public SelectAbilityWindow(Character character, Ability[] abilities)
        {
            InitializeComponent();

            AbilityListBox.ItemsSource =
                abilities.Where(x => character.Abilities.FirstOrDefault(z => z.Name == x.Name) is null);
            AbilityListBox.DisplayMemberPath = "Name";
            ButtonLearn.Click += LearnAbility;
        }

        private void LearnAbility(object sender, RoutedEventArgs e)
        {
            if (AbilityListBox.SelectedItem is null)
                return;

            SelectedAbility = (AbilityListBox.SelectedItem as Ability)!;
            DialogResult = true;
        }
    }
}
