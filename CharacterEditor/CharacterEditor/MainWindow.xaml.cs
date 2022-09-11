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
using CharacterEditor.Core;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OnParameterChangedEvent += delegate
            {
                tbStrength.Text = character.Strength.ToString();
                tbDextirity.Text = character.Dexterity.ToString();
                tbConstitution.Text = character.Constitution.ToString();
                tbIntelligence.Text = character.Intelligence.ToString();
                tbHealphPoint.Text = character.healthPoint.ToString();
                tbPhysicalDamage.Text = character.physicalDamage.ToString();
                tbPhysicalDefense.Text = character.physicalDefense.ToString();
                tbMageDamage.Text = character.mageDamage.ToString();
                tbManaPoint.Text = character.manaPoint.ToString();
            };
        }

        Character character;
        
        public delegate void ParameterChangedDelegate();
        public event ParameterChangedDelegate OnParameterChangedEvent;

        private void Warrior_Button_Click(object sender, RoutedEventArgs e)
        {
            character = new Warrior();
            OnParameterChangedEvent?.Invoke();
        }

        private void Rogue_Button_Click(object sender, RoutedEventArgs e)
        {
            character = new Rogue();
            OnParameterChangedEvent?.Invoke();
        }

        private void Wizard_Button_Click(object sender, RoutedEventArgs e)
        {
            character = new Wizzard();
            OnParameterChangedEvent?.Invoke();
        }

        private void btnStrengthLow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                character.Strength--;
                OnParameterChangedEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStrengthUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                character.Strength++;
                OnParameterChangedEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDexterityLow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                character.Dexterity--;
                OnParameterChangedEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDexterityUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                character.Dexterity++;
                OnParameterChangedEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConstitutionLow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                character.Constitution--;
                OnParameterChangedEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConstitutionUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                character.Constitution++;
                OnParameterChangedEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIntelligenceLow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                character.Intelligence--;
                OnParameterChangedEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIntelligenceUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                character.Intelligence++;
                OnParameterChangedEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
