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
using Units_Practic;

namespace EditUnit_Practic_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Unit> units;

        public MainWindow()
        {
            units = new List<Unit>() {new Warrior(), new Wizard(), new Rogue() };

            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            UpdateCharacteristics(0);
        }

        private void UpdateCharacteristics(int unit)
        {
            tbStrength.Text = units[unit].characteristics.strength.ToString();
            tbDexterity.Text = units[unit].characteristics.dexterity.ToString();
            tbConstitution.Text = units[unit].characteristics.constitution.ToString();
            tbIntelligence.Text = units[unit].characteristics.intelligence.ToString();

            tbHP.Text = units[unit].healthPoint.ToString();
            tbMP.Text = units[unit].manaPoint.ToString();
            tbAtackPoint.Text = units[unit].atackPoint.ToString();
            tbMagicAtackPoint.Text = units[unit].magicAtackPoint.ToString();
            tbPhysicalProtectionPoint.Text = units[unit].physicalProtectionPoint.ToString();
        }
    }
}
