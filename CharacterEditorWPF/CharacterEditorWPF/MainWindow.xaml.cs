using CharacterEditorCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace CharacterEditorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Character currentCharacter;
        static List<Character> charactersList = new List<Character>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cb_chooseCharact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cb_chooseCharact.SelectedItem;
            string? value = typeItem.Content.ToString();
            switch (value)
            {
                case "Warrior":
                    Warrior newWarrior = new Warrior();
                    currentCharacter = newWarrior;
                    FillData(newWarrior);
                    break;

                case "Rogue":
                    Rogue newRogue = new Rogue();
                    currentCharacter = newRogue;
                    FillData(newRogue);
                    break;


                case "Wizard":
                    Wizard newWizard = new Wizard();
                    currentCharacter = newWizard;
                    FillData(newWizard);
                    break;
            }
        }

        public void FillData(Character newCharacter)
        {

            tb_strength.Text = newCharacter.Strength.ToString();
            tb_dexterity.Text = newCharacter.Dexterity.ToString();
            tb_constitution.Text = newCharacter.Constitution.ToString();
            tb_intelligence.Text = newCharacter.Intelligence.ToString();

            tb_HP.Text = newCharacter.healthPoints.ToString();
            tb_MP.Text = newCharacter.manaPoints.ToString();
            tb_attack.Text = newCharacter.attack.ToString();
            tb_magicAttack.Text = newCharacter.magicAttack.ToString();
            tb_physicalDef.Text = newCharacter.physicalDefense.ToString();
        }

        private void btn_increaseStrength_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Strength++;
            FillData(currentCharacter);
        }

        private void btn_increaseDexterity_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Dexterity++;
            FillData(currentCharacter);
        }

        private void btn_increaseConstitution_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Constitution++;
            FillData(currentCharacter);
        }

        private void btn_increaseIntelligence_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Intelligence++;
            FillData(currentCharacter);
        }
        private bool CheckCharactOnExistment()
        {
            try
            {
                var temp = currentCharacter.Intelligence;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have to choose type of character!");
                return false;
            }
            return true;
        }

        private void btn_decreaseStrength_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Strength--;
            FillData(currentCharacter);
        }

        private void btn_decreaseDexterity_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Dexterity--;
            FillData(currentCharacter);
        }

        private void btn_decreaseConstitution_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Constitution--;
            FillData(currentCharacter);
        }

        private void btn_decreaseIntelligence_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Intelligence--;
            FillData(currentCharacter);
        }

        private void button_addCharacter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                charactersList.Add(currentCharacter);
                FillTextInfoAboutCharacters();
            }
            catch
            {
                MessageBox.Show("You have to choose type of character!");
            }

        }
        private void FillTextInfoAboutCharacters()
        {
            textbox_existingCharacters.Text = "";

            foreach (Character character in charactersList)
            {
                textbox_existingCharacters.Text +=
                    $"{character.GetType().Name} Strength: {character.Strength} " +
                    $"Dexterity: {character.Dexterity} Constitution: {character.Constitution} " +
                    $"Intelligence: {character.Intelligence}";
                textbox_existingCharacters.Text += System.Environment.NewLine;

            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Characters"; 
            dlg.DefaultExt = ".txt"; 
            dlg.Filter = "Text documents (.txt)|*.txt"; 

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                Save(filename);
            }
        }

        public static void Save(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, charactersList);
            }
        }

        public static void Load(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                charactersList = (List<Character>)binaryFormatter.Deserialize(fileStream);
            }
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                Load(filename);
                FillTextInfoAboutCharacters();
            }
        }
    }
}
