using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Units
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBoxChoice.Items.AddRange(new string[] { "Rogue", "Warrior", "Wizard" });

            OnParameterChangedEvent += delegate
            {
                numericStrength.Value = unit2.Strength;
                numericStrength.Maximum = unit2.maxStrength;
                numericStrength.Minimum = unit2.minStrength;

                numericDexterity.Value = unit2.Dexterity;
                numericDexterity.Maximum = unit2.maxDexterity;
                numericDexterity.Minimum = unit2.minDexterity;
                
                numericConstitution.Value = unit2.Constitution;
                numericConstitution.Maximum = unit2.maxConstitution;
                numericConstitution.Minimum = unit2.minConstitution;

                numericIntellisence.Value = unit2.Intelligence;
                numericIntellisence.Maximum = unit2.maxIntelligence;
                numericIntellisence.Minimum = unit2.minIntelligence;

                tbHP.Text = unit2.healthPoint.ToString();
                tbMP.Text = unit2.manaPoint.ToString();
                tbDefence.Text = unit2.damage.ToString();
                tbDamage.Text = unit2.damage.ToString();

            };
          
    }
        Unit unit2;
        public delegate void ParameterChangedDelegate();
        public event ParameterChangedDelegate OnParameterChangedEvent;


        private void domainChoice_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void numericStrength_ValueChanged(object sender, EventArgs e)
        {
            OnParameterChangedEvent += delegate
            {
               tbHP.Text = unit2.healthPoint.ToString();
               tbMP.Text = unit2.manaPoint.ToString();
               tbDefence.Text = unit2.damage.ToString();
               tbDamage.Text = unit2.damage.ToString();
            };

           


        }

        private void comboBoxChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string unit = comboBoxChoice.SelectedItem.ToString();
           

            switch (unit)
            {
                case "Rogue":
                    Console.WriteLine("1");
                    
                    unit2 = new Rogue();
                    OnParameterChangedEvent?.Invoke();

                    break;

                case "Warrior":
                    Console.WriteLine("2");
                    unit2 = new Warrior();
                    OnParameterChangedEvent?.Invoke();
                    
                    break;

                case "Wizard":
                    unit2 = new Wizard();
                    OnParameterChangedEvent?.Invoke();
                    Console.WriteLine("3");
                    break;
            }
            
        }
    }
}
