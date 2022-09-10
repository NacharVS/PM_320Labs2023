namespace GameCharacterEditor
{
    partial class GameCharacterEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CharacterBox = new System.Windows.Forms.ComboBox();
            this.Strength_Label = new System.Windows.Forms.Label();
            this.Dexterity_Label = new System.Windows.Forms.Label();
            this.Constitution_Label = new System.Windows.Forms.Label();
            this.Intelligence_Label = new System.Windows.Forms.Label();
            this.HP_Label = new System.Windows.Forms.Label();
            this.MP_Label = new System.Windows.Forms.Label();
            this.PDef_Label = new System.Windows.Forms.Label();
            this.Attack_Label = new System.Windows.Forms.Label();
            this.Attack_Text = new System.Windows.Forms.TextBox();
            this.PDef_Text = new System.Windows.Forms.TextBox();
            this.MP_Text = new System.Windows.Forms.TextBox();
            this.HP_Text = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // CharacterBox
            // 
            this.CharacterBox.FormattingEnabled = true;
            this.CharacterBox.Location = new System.Drawing.Point(12, 12);
            this.CharacterBox.Name = "CharacterBox";
            this.CharacterBox.Size = new System.Drawing.Size(150, 23);
            this.CharacterBox.TabIndex = 0;
            this.CharacterBox.Text = "Character";
            // 
            // Strength_Label
            // 
            this.Strength_Label.AutoSize = true;
            this.Strength_Label.Location = new System.Drawing.Point(12, 100);
            this.Strength_Label.Name = "Strength_Label";
            this.Strength_Label.Size = new System.Drawing.Size(55, 15);
            this.Strength_Label.TabIndex = 1;
            this.Strength_Label.Text = "Strength:";
            // 
            // Dexterity_Label
            // 
            this.Dexterity_Label.AutoSize = true;
            this.Dexterity_Label.Location = new System.Drawing.Point(12, 133);
            this.Dexterity_Label.Name = "Dexterity_Label";
            this.Dexterity_Label.Size = new System.Drawing.Size(57, 15);
            this.Dexterity_Label.TabIndex = 2;
            this.Dexterity_Label.Text = "Dexterity:";
            // 
            // Constitution_Label
            // 
            this.Constitution_Label.AutoSize = true;
            this.Constitution_Label.Location = new System.Drawing.Point(12, 166);
            this.Constitution_Label.Name = "Constitution_Label";
            this.Constitution_Label.Size = new System.Drawing.Size(76, 15);
            this.Constitution_Label.TabIndex = 3;
            this.Constitution_Label.Text = "Constitution:";
            // 
            // Intelligence_Label
            // 
            this.Intelligence_Label.AutoSize = true;
            this.Intelligence_Label.Location = new System.Drawing.Point(12, 200);
            this.Intelligence_Label.Name = "Intelligence_Label";
            this.Intelligence_Label.Size = new System.Drawing.Size(71, 15);
            this.Intelligence_Label.TabIndex = 4;
            this.Intelligence_Label.Text = "Intelligence:";
            // 
            // HP_Label
            // 
            this.HP_Label.AutoSize = true;
            this.HP_Label.Location = new System.Drawing.Point(432, 100);
            this.HP_Label.Name = "HP_Label";
            this.HP_Label.Size = new System.Drawing.Size(26, 15);
            this.HP_Label.TabIndex = 5;
            this.HP_Label.Text = "HP:";
            // 
            // MP_Label
            // 
            this.MP_Label.AutoSize = true;
            this.MP_Label.Location = new System.Drawing.Point(432, 133);
            this.MP_Label.Name = "MP_Label";
            this.MP_Label.Size = new System.Drawing.Size(28, 15);
            this.MP_Label.TabIndex = 6;
            this.MP_Label.Text = "MP:";
            // 
            // PDef_Label
            // 
            this.PDef_Label.AutoSize = true;
            this.PDef_Label.Location = new System.Drawing.Point(432, 166);
            this.PDef_Label.Name = "PDef_Label";
            this.PDef_Label.Size = new System.Drawing.Size(35, 15);
            this.PDef_Label.TabIndex = 7;
            this.PDef_Label.Text = "PDef:";
            // 
            // Attack_Label
            // 
            this.Attack_Label.AutoSize = true;
            this.Attack_Label.Location = new System.Drawing.Point(432, 200);
            this.Attack_Label.Name = "Attack_Label";
            this.Attack_Label.Size = new System.Drawing.Size(44, 15);
            this.Attack_Label.TabIndex = 8;
            this.Attack_Label.Text = "Attack:";
            // 
            // Attack_Text
            // 
            this.Attack_Text.Location = new System.Drawing.Point(510, 197);
            this.Attack_Text.Name = "Attack_Text";
            this.Attack_Text.Size = new System.Drawing.Size(100, 23);
            this.Attack_Text.TabIndex = 10;
            // 
            // PDef_Text
            // 
            this.PDef_Text.Location = new System.Drawing.Point(510, 163);
            this.PDef_Text.Name = "PDef_Text";
            this.PDef_Text.Size = new System.Drawing.Size(100, 23);
            this.PDef_Text.TabIndex = 11;
            // 
            // MP_Text
            // 
            this.MP_Text.Location = new System.Drawing.Point(510, 130);
            this.MP_Text.Name = "MP_Text";
            this.MP_Text.Size = new System.Drawing.Size(100, 23);
            this.MP_Text.TabIndex = 12;
            // 
            // HP_Text
            // 
            this.HP_Text.Location = new System.Drawing.Point(510, 97);
            this.HP_Text.Name = "HP_Text";
            this.HP_Text.Size = new System.Drawing.Size(100, 23);
            this.HP_Text.TabIndex = 13;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(119, 198);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 19;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(119, 164);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown2.TabIndex = 20;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(119, 98);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown3.TabIndex = 21;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(119, 131);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown4.TabIndex = 22;
            // 
            // GameCharacterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.HP_Text);
            this.Controls.Add(this.MP_Text);
            this.Controls.Add(this.PDef_Text);
            this.Controls.Add(this.Attack_Text);
            this.Controls.Add(this.Attack_Label);
            this.Controls.Add(this.PDef_Label);
            this.Controls.Add(this.MP_Label);
            this.Controls.Add(this.HP_Label);
            this.Controls.Add(this.Intelligence_Label);
            this.Controls.Add(this.Constitution_Label);
            this.Controls.Add(this.Dexterity_Label);
            this.Controls.Add(this.Strength_Label);
            this.Controls.Add(this.CharacterBox);
            this.Name = "GameCharacterEditor";
            this.Text = "Game character editor";
            this.Load += new System.EventHandler(this.GameCharacterEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox CharacterBox;
        private Label Strength_Label;
        private Label Dexterity_Label;
        private Label Constitution_Label;
        private Label Intelligence_Label;
        private Label HP_Label;
        private Label MP_Label;
        private Label PDef_Label;
        private Label Attack_Label;
        private TextBox Attack_Text;
        private TextBox PDef_Text;
        private TextBox MP_Text;
        private TextBox HP_Text;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
    }
}