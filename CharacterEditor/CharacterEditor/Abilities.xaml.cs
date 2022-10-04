using CharacterEditorCore;
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
using System.Windows.Shapes;
using UnitsEditor;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for Abilities.xaml
    /// </summary>
    public partial class Abilities : Window
    {
        private BaseCharacteristics _selectedCharacter;
        private MainWindow _mainWindow;
        private delegate void AbilityChangeDelegate();
        public Abilities(BaseCharacteristics selectedCharacter, MainWindow mainWindow)
        {
            InitializeComponent();

            _selectedCharacter = selectedCharacter;
            _mainWindow = mainWindow;
            OnAbilityChangeEvent += FillAbilities;
            OnAbilityChangeEvent += _mainWindow.FillCharacterInfo;

            if(_selectedCharacter is null)
            {
                return;
            }
            FillAbilities();
            
        }
        private void FillAbilities()
        {
            var freeAbilitiesList = AbilitiesList.Abilities
                .Where(x => _selectedCharacter.Abilities.FirstOrDefault
                (z => z.Name == x.Name) is null);

            foreach(var ability in freeAbilitiesList)
            {
                lvAbilities.Items.Add(ability);
            }
        }

        private void lvAbilities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAbility = (Ability)lvAbilities.SelectedItem;

            _selectedCharacter.AddAbility(selectedAbility);

            _mainWindow.lbAbilities.DisplayMemberPath = "Name";
            _mainWindow.lbAbilities.Items.Add(selectedAbility);

            OnAbilityChangeEvent?.Invoke();

            this.Close();
        }

        private event AbilityChangeDelegate OnAbilityChangeEvent;
    }
}
