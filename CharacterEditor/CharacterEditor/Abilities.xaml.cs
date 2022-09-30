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

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for Abilities.xaml
    /// </summary>
    public partial class Abilities : Window
    {
        private BaseCharacteristics _selectedCharacter;
        public Abilities(BaseCharacteristics selectedCharacter)
        {
            InitializeComponent();

            _selectedCharacter = selectedCharacter;

            if(_selectedCharacter is null)
            {
                return;
            }
            FillAbilities();
            
        }
        private void FillAbilities()
        {
            foreach(var ability in AbilitiesList.Abilities)
            {
                lvAbilities.Items.Add(ability);
            }
        }

        private void lvAbilities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAbility = (Ability)lvAbilities.SelectedItem;

            _selectedCharacter.AddAbility(selectedAbility);

            lvAbilities.Items.Remove(selectedAbility);
            this.Close();
        }
    }
}
