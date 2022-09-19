using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        }

        Unit unit;
        public delegate void ParameterChangedDelegate();
        public event ParameterChangedDelegate OnParameterChangedEvent;
        List<Unit> units = new List<Unit>();
       
        private void domainChoice_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void numericStrength_ValueChanged(object sender, EventArgs e)
        {
            unit.Strength = (int)numericStrength.Value;
            tbHP.Text = unit.healthPoint.ToString();
            tbMP.Text = unit.manaPoint.ToString();
            tbDefence.Text = unit.defense.ToString();
            tbDamage.Text = unit.damage.ToString();
        }

        private void comboBoxChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string unit2 = comboBoxChoice.SelectedItem.ToString();
           
            switch (unit2)
            {
                case "Rogue":
                    unit = new Rogue();
                    OnParameterChangedEvent?.Invoke();
                    pictureBox.ImageLocation = "https://pa1.narvii.com/6728/1bc29898e3889d8db7269e3f8357f450c2492f52_00.gif";



                    break;

                case "Warrior":
                    unit = new Warrior();
                    OnParameterChangedEvent?.Invoke();
                    pictureBox.ImageLocation = "https://media.moddb.com/images/groups/1/9/8054/wYAqUqX.gif";


                    break;

                case "Wizard":
                    unit = new Wizard();
                    OnParameterChangedEvent?.Invoke();
                    pictureBox.ImageLocation = "https://content.foto.my.mail.ru/inbox/gotika_foreva/_blogs/i-5819.gif";


                    break;
            }
            numericStrength.Maximum = 256;
            numericStrength.Minimum = 0;
      
            numericDexterity.Maximum = 256;
            numericDexterity.Minimum = 0;

            numericConstitution.Maximum = 256;
            numericConstitution.Minimum = 0;

            numericIntellisence.Maximum = 256;
            numericIntellisence.Minimum = 0;


            OnParameterChangedEvent += delegate
            {
                numericStrength.Value = unit.Strength;
                numericStrength.Maximum = unit.maxStrength;
                numericStrength.Minimum = unit.minStrength;

                numericDexterity.Value = unit.Dexterity;
                numericDexterity.Maximum = unit.maxDexterity;
                numericDexterity.Minimum = unit.minDexterity;

                numericConstitution.Value = unit.Constitution;
                numericConstitution.Maximum = unit.maxConstitution;
                numericConstitution.Minimum = unit.minConstitution;

                numericIntellisence.Value = unit.Intelligence;
                numericIntellisence.Maximum = unit.maxIntelligence;
                numericIntellisence.Minimum = unit.minIntelligence;

                tbHP.Text = unit.healthPoint.ToString();
                tbMP.Text = unit.manaPoint.ToString();
                tbDefence.Text = unit.damage.ToString();
                tbDamage.Text = unit.damage.ToString();
            };
        }

        private void numericDexterity_ValueChanged(object sender, EventArgs e)
        {
            unit.Dexterity = (int)numericDexterity.Value;
            tbHP.Text = unit.healthPoint.ToString();
            tbMP.Text = unit.manaPoint.ToString();
            tbDefence.Text = unit.defense.ToString();
            tbDamage.Text = unit.damage.ToString();
        }

        private void numericConstitution_ValueChanged(object sender, EventArgs e)
        {
            unit.Constitution = (int)numericConstitution.Value;
            tbHP.Text = unit.healthPoint.ToString();
            tbMP.Text = unit.manaPoint.ToString();
            tbDefence.Text = unit.defense.ToString();
            tbDamage.Text = unit.damage.ToString();
        }

        private void numericIntellisence_ValueChanged(object sender, EventArgs e)
        {
            unit.Intelligence = (int)numericIntellisence.Value;
            tbHP.Text = unit.healthPoint.ToString();
            tbMP.Text = unit.manaPoint.ToString();
            tbDefence.Text = unit.defense.ToString();
            tbDamage.Text = unit.damage.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            units.Add(unit);
            numericStrength.Minimum = 0;
            numericStrength.Value = 0;

            numericDexterity.Minimum = 0;
            numericDexterity.Value = 0;

            numericConstitution.Minimum = 0;
            numericConstitution.Value = 0;

            numericIntellisence.Minimum = 0;
            numericIntellisence.Value = 0;
            
            tbHP.Text = "0";
            tbMP.Text = "0";
            tbDefence.Text = "0";
            tbDamage.Text = "0";
            comboBoxChoice.Text = "";

        }
    }
}
