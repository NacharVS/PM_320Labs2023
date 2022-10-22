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
    /// Interaction logic for MatchCharacterInfo.xaml
    /// </summary>
    public partial class MatchCharacterInfo : Window
    {
        private Character _currentCharacter;

        public MatchCharacterInfo(Character character)
        {
            InitializeComponent();

            if (character != null)
            {
                _currentCharacter = character;
            }

            UpdateCharacterInfo();
        }

        private void UpdateCharacterInfo()
        {
            if (_currentCharacter == null)
            {
                tbCharacterName.Text = "";
                Attack.Content = 0;
                Health.Content = 0;
                PhysicalDefence.Content = 0;
                Mana.Content = 0;
                MagicalAttack.Content = 0;

                strength.Content = 0;
                dexterity.Content = 0;
                constitution.Content = 0;
                intellisense.Content = 0;
                return;
            }

            if (_currentCharacter.Name != null)
            {
                tbCharacterName.Text = _currentCharacter.Name;
            }

            Experience.Content = _currentCharacter.Experience;
            Level.Content = _currentCharacter.Level;

            strength.Content = _currentCharacter.GetStrengthValue()
                                + _currentCharacter.GetLevelCharactericticsValue()
                                + _currentCharacter.GetEquipmentStrength();
            dexterity.Content = _currentCharacter.GetDexterityValue()
                                + _currentCharacter.GetLevelCharactericticsValue()
                                + _currentCharacter.GetEquipmentDexterity();
            constitution.Content = _currentCharacter.GetConstitutionValue()
                                + _currentCharacter.GetLevelCharactericticsValue()
                                + _currentCharacter.GetEquipmentConstitution();
            intellisense.Content = _currentCharacter.GetIntellisenseValue()
                                + _currentCharacter.GetLevelCharactericticsValue()
                                + _currentCharacter.GetEquipmentIntellisence();

            FillLBCharacterAbilities();
            CalculateCharacterictics();
        }

        private void FillLBCharacterAbilities()
        {
            if (_currentCharacter == null || _currentCharacter.Abilities == null)
            {
                return;
            }

            lbCharacterAbilities.Items.Clear();
            foreach (var ability in _currentCharacter.Abilities)
            {
                lbCharacterAbilities.Items.Add(ability);
            }

            lbCharacterAbilities.DisplayMemberPath = "Name";
        }

        private void CalculateCharacterictics()
        {
            var str = int.Parse(strength.Content.ToString());
            var dex = int.Parse(dexterity.Content.ToString());
            var con = int.Parse(constitution.Content.ToString());
            var intel = int.Parse(intellisense.Content.ToString());

            Attack.Content = str * _currentCharacter.StrengthAttackChange +
                           dex * _currentCharacter.DexterityAttackChange +
                           _currentCharacter.GetAbilitiesAttackDamage();
            Health.Content = con * _currentCharacter.ConstitutionHealthChange +
                        str * _currentCharacter.StrengthHealthChange +
                        _currentCharacter.GetAbilitiesHealth();
            PhysicalDefence.Content = con * _currentCharacter.ConstitutionPhysicalDefenceChange +
                                dex * _currentCharacter.DexterityPhysicalDefenceChange +
                                _currentCharacter.GetAbilitiesPhysicalDefense();
            Mana.Content = intel * _currentCharacter.IntellisenseManaChange +
                         _currentCharacter.GetAbilitiesMana();
            MagicalAttack.Content = intel * _currentCharacter.IntellisenseMagicalAttackChange +
                                    _currentCharacter.GetAbilitiesMagicalAttack();
        }
    }
}