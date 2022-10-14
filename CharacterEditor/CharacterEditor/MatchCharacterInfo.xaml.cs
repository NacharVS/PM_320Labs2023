using CharacterEditorCore;
using CharacterEditorCore.DataBase;
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
    /// Interaction logic for MatchCharacterInfo.xaml
    /// </summary>
    public partial class MatchCharacterInfo : Page
    {
        private readonly BaseCharacteristics _character;
        public MatchCharacterInfo(ICharacterRep characterContext, CharacterIdName selectedCharacter)
        {
            InitializeComponent();

            _character = characterContext.GetCharacter(selectedCharacter.Id);
            FillCharacterInfo();
        }

        private void FillCharacterInfo()
        {
            if(_character is null)
            {
                return;
            }

            try
            {
                lblStrengthVal.Content = Convert.ToString(_character.Strength.Value);
                lblDexterityVal.Content = Convert.ToString(_character.Dexterity.Value);
                lblConstitutionVal.Content = Convert.ToString(_character.Constitution.Value);
                lblIntelligenceVal.Content = Convert.ToString(_character.Intelligence.Value);

                tbAttackVal.Text = Convert.ToString(_character.AttackDamage);
                tbHPVal.Text = Convert.ToString(_character.HealthPoint);
                tbMPVal.Text = Convert.ToString(_character.ManaPoint);
                tbPdefVal.Text = Convert.ToString(_character.PhysicalDef);
                tbMagicAttackVal.Text = Convert.ToString(_character.MagicAttack);
                lblExpVal.Content = Convert.ToString(_character.Lvl.CurrentExp);
                lblLvlVal.Content = _character.Lvl.CurrentLevel;
                lbAbilities.ItemsSource = _character.Abilities;
                lbInventory.ItemsSource = _character.Inventory;
                lblCharacterName.Content = _character.Name;
                
                FillItemsBuffs();
                FillAbilitiesBuffs();
            }
            catch
            {

            }
        }

        private void FillItemsBuffs()
        {
            if (_character is null) return;
            foreach (var item in _character.Inventory)
            {
                lblStrengthVal.Content = (int.Parse((string)lblStrengthVal.Content) + item.StrengthChange).ToString();
                lblDexterityVal.Content = (int.Parse((string)lblDexterityVal.Content) + item.DexterityChange).ToString();
                lblConstitutionVal.Content = (int.Parse((string)lblConstitutionVal.Content) + item.ConstitutionChange).ToString();
                lblIntelligenceVal.Content = (int.Parse((string)lblIntelligenceVal.Content) + item.IntelligenceChange).ToString();

                tbAttackVal.Text = (int.Parse(tbAttackVal.Text) + item.AttackChange).ToString();
                tbHPVal.Text = (int.Parse(tbHPVal.Text) + item.HPChange).ToString();
                tbMPVal.Text = (int.Parse(tbMPVal.Text) + item.ManaChange).ToString();
                tbMagicAttackVal.Text = (int.Parse(tbMagicAttackVal.Text) + item.MagicalAttackChange).ToString();
                tbPdefVal.Text = (int.Parse(tbPdefVal.Text) + item.PdefChange).ToString();

                switch (_character.GetType().Name)
                {
                    case "Warrior":
                        tbAttackVal.Text = (int.Parse(tbAttackVal.Text) + (5 * item.StrengthChange + item.DexterityChange)).ToString();
                        tbHPVal.Text = (int.Parse(tbHPVal.Text) + (2 * item.StrengthChange + 10 * item.ConstitutionChange)).ToString();
                        tbMPVal.Text = (int.Parse(tbMPVal.Text) + (5 * item.IntelligenceChange)).ToString();
                        tbMagicAttackVal.Text = (int.Parse(tbMagicAttackVal.Text) + (item.IntelligenceChange)).ToString();
                        tbPdefVal.Text = (int.Parse(tbPdefVal.Text) + (item.DexterityChange + 2 * item.ConstitutionChange)).ToString();
                        break;
                    case "Rogue":
                        tbAttackVal.Text = (int.Parse(tbAttackVal.Text) + (2 * item.StrengthChange + 4 * item.DexterityChange)).ToString();
                        tbHPVal.Text = (int.Parse(tbHPVal.Text) + (item.StrengthChange + 6 * item.ConstitutionChange)).ToString();
                        tbMPVal.Text = (int.Parse(tbMPVal.Text) + (1.5 * item.IntelligenceChange)).ToString();
                        tbMagicAttackVal.Text = (int.Parse(tbMagicAttackVal.Text) + (2 * item.IntelligenceChange)).ToString();
                        tbPdefVal.Text = (int.Parse(tbPdefVal.Text) + (1.5 * item.DexterityChange + 0 * item.ConstitutionChange)).ToString();
                        break;
                    case "Wizzard":
                        tbAttackVal.Text = (int.Parse(tbAttackVal.Text) + (3 * item.StrengthChange + 0 * item.DexterityChange)).ToString();
                        tbHPVal.Text = (int.Parse(tbHPVal.Text) + (item.StrengthChange + 3 * item.ConstitutionChange)).ToString();
                        tbMPVal.Text = (int.Parse(tbMPVal.Text) + (2 * item.IntelligenceChange)).ToString();
                        tbMagicAttackVal.Text = (int.Parse(tbMagicAttackVal.Text) + (5 * item.IntelligenceChange)).ToString();
                        tbPdefVal.Text = (int.Parse(tbPdefVal.Text) + (0.5 * item.DexterityChange + 1 * item.ConstitutionChange)).ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void FillAbilitiesBuffs()
        {
            foreach (var ability in _character.Abilities)
            {
                tbAttackVal.Text = (int.Parse(tbAttackVal.Text) + ability.AttackChange).ToString();
                tbHPVal.Text = (int.Parse(tbHPVal.Text) + ability.HealthChange).ToString();
                tbMPVal.Text = (Convert.ToDouble(tbMPVal.Text) + ability.ManaChange).ToString();
                tbMagicAttackVal.Text = (int.Parse(tbMagicAttackVal.Text) + ability.MagicalAttackChange).ToString();
                tbPdefVal.Text = (Convert.ToDouble(tbPdefVal.Text) + ability.PhysicalDefChange).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
