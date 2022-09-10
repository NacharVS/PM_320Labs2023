namespace GameCharacterEditor
{
    public partial class GameCharacterEditor : Form
    {
        public GameCharacterEditor()
        {
            InitializeComponent();
        }
        /*private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = String.Format("Текущее значение: {0}", trackBar1.Value);
        }*/
        private void GameCharacterEditor_Load(object sender, EventArgs e)
        {
            CharacterBox.Items.Add("Rogue");
            CharacterBox.Items.Add("Warrer");
            CharacterBox.Items.Add("Wizard");
        }
    }
}