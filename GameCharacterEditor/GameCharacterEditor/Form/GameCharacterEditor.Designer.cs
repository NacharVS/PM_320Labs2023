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
            this.Strength_Label = new System.Windows.Forms.Label();
            this.Dexterity_Label = new System.Windows.Forms.Label();
            this.Constitution_Label = new System.Windows.Forms.Label();
            this.Intelligence_Label = new System.Windows.Forms.Label();
            this.HP_Label = new System.Windows.Forms.Label();
            this.MP_Label = new System.Windows.Forms.Label();
            this.PDef_Label = new System.Windows.Forms.Label();
            this.Attack_Label = new System.Windows.Forms.Label();
            this.Intelligence_Text = new System.Windows.Forms.NumericUpDown();
            this.Constitution_Text = new System.Windows.Forms.NumericUpDown();
            this.Strength_Text = new System.Windows.Forms.NumericUpDown();
            this.Dexterity_Text = new System.Windows.Forms.NumericUpDown();
            this.Rogue_Button = new System.Windows.Forms.Button();
            this.Wizard_Button = new System.Windows.Forms.Button();
            this.Warrior_Button = new System.Windows.Forms.Button();
            this.MPAttack_Label = new System.Windows.Forms.Label();
            this.MPAttack_Text = new System.Windows.Forms.TextBox();
            this.Attack_Text = new System.Windows.Forms.TextBox();
            this.PDef_Text = new System.Windows.Forms.TextBox();
            this.MP_Text = new System.Windows.Forms.TextBox();
            this.HP_Text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Intelligence_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Constitution_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Strength_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dexterity_Text)).BeginInit();
            this.SuspendLayout();
            // 
            // Strength_Label
            // 
            this.Strength_Label.AutoSize = true;
            this.Strength_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Strength_Label.Location = new System.Drawing.Point(66, 117);
            this.Strength_Label.Name = "Strength_Label";
            this.Strength_Label.Size = new System.Drawing.Size(85, 22);
            this.Strength_Label.TabIndex = 1;
            this.Strength_Label.Text = "Strength:";
            // 
            // Dexterity_Label
            // 
            this.Dexterity_Label.AutoSize = true;
            this.Dexterity_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Dexterity_Label.Location = new System.Drawing.Point(66, 148);
            this.Dexterity_Label.Name = "Dexterity_Label";
            this.Dexterity_Label.Size = new System.Drawing.Size(90, 22);
            this.Dexterity_Label.TabIndex = 2;
            this.Dexterity_Label.Text = "Dexterity:";
            // 
            // Constitution_Label
            // 
            this.Constitution_Label.AutoSize = true;
            this.Constitution_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Constitution_Label.Location = new System.Drawing.Point(66, 179);
            this.Constitution_Label.Name = "Constitution_Label";
            this.Constitution_Label.Size = new System.Drawing.Size(115, 22);
            this.Constitution_Label.TabIndex = 3;
            this.Constitution_Label.Text = "Constitution:";
            // 
            // Intelligence_Label
            // 
            this.Intelligence_Label.AutoSize = true;
            this.Intelligence_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Intelligence_Label.Location = new System.Drawing.Point(66, 210);
            this.Intelligence_Label.Name = "Intelligence_Label";
            this.Intelligence_Label.Size = new System.Drawing.Size(109, 22);
            this.Intelligence_Label.TabIndex = 4;
            this.Intelligence_Label.Text = "Intelligence:";
            // 
            // HP_Label
            // 
            this.HP_Label.AutoSize = true;
            this.HP_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.HP_Label.Location = new System.Drawing.Point(414, 101);
            this.HP_Label.Name = "HP_Label";
            this.HP_Label.Size = new System.Drawing.Size(41, 22);
            this.HP_Label.TabIndex = 5;
            this.HP_Label.Text = "HP:";
            // 
            // MP_Label
            // 
            this.MP_Label.AutoSize = true;
            this.MP_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.MP_Label.Location = new System.Drawing.Point(414, 132);
            this.MP_Label.Name = "MP_Label";
            this.MP_Label.Size = new System.Drawing.Size(45, 22);
            this.MP_Label.TabIndex = 6;
            this.MP_Label.Text = "MP:";
            // 
            // PDef_Label
            // 
            this.PDef_Label.AutoSize = true;
            this.PDef_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.PDef_Label.Location = new System.Drawing.Point(414, 163);
            this.PDef_Label.Name = "PDef_Label";
            this.PDef_Label.Size = new System.Drawing.Size(56, 22);
            this.PDef_Label.TabIndex = 7;
            this.PDef_Label.Text = "PDef:";
            // 
            // Attack_Label
            // 
            this.Attack_Label.AutoSize = true;
            this.Attack_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Attack_Label.Location = new System.Drawing.Point(414, 194);
            this.Attack_Label.Name = "Attack_Label";
            this.Attack_Label.Size = new System.Drawing.Size(70, 22);
            this.Attack_Label.TabIndex = 8;
            this.Attack_Label.Text = "Attack:";
            // 
            // Intelligence_Text
            // 
            this.Intelligence_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Intelligence_Text.Location = new System.Drawing.Point(204, 209);
            this.Intelligence_Text.Name = "Intelligence_Text";
            this.Intelligence_Text.Size = new System.Drawing.Size(120, 25);
            this.Intelligence_Text.TabIndex = 19;
            this.Intelligence_Text.ValueChanged += new System.EventHandler(this.Intelligence_Text_ValueChanged);
            // 
            // Constitution_Text
            // 
            this.Constitution_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Constitution_Text.Location = new System.Drawing.Point(204, 178);
            this.Constitution_Text.Name = "Constitution_Text";
            this.Constitution_Text.Size = new System.Drawing.Size(120, 25);
            this.Constitution_Text.TabIndex = 20;
            this.Constitution_Text.ValueChanged += new System.EventHandler(this.Constitution_Text_ValueChanged);
            // 
            // Strength_Text
            // 
            this.Strength_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Strength_Text.Location = new System.Drawing.Point(204, 120);
            this.Strength_Text.Name = "Strength_Text";
            this.Strength_Text.Size = new System.Drawing.Size(120, 25);
            this.Strength_Text.TabIndex = 21;
            this.Strength_Text.ValueChanged += new System.EventHandler(this.Strength_Text_ValueChanged);
            // 
            // Dexterity_Text
            // 
            this.Dexterity_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Dexterity_Text.Location = new System.Drawing.Point(204, 147);
            this.Dexterity_Text.Name = "Dexterity_Text";
            this.Dexterity_Text.Size = new System.Drawing.Size(120, 25);
            this.Dexterity_Text.TabIndex = 22;
            this.Dexterity_Text.ValueChanged += new System.EventHandler(this.Dexterity_Text_ValueChanged);
            // 
            // Rogue_Button
            // 
            this.Rogue_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Rogue_Button.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Rogue_Button.Location = new System.Drawing.Point(12, 29);
            this.Rogue_Button.Name = "Rogue_Button";
            this.Rogue_Button.Size = new System.Drawing.Size(100, 30);
            this.Rogue_Button.TabIndex = 23;
            this.Rogue_Button.Text = "Rogue";
            this.Rogue_Button.UseVisualStyleBackColor = false;
            this.Rogue_Button.Click += new System.EventHandler(this.Rogue_Button_Click);
            // 
            // Wizard_Button
            // 
            this.Wizard_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Wizard_Button.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Wizard_Button.Location = new System.Drawing.Point(224, 29);
            this.Wizard_Button.Name = "Wizard_Button";
            this.Wizard_Button.Size = new System.Drawing.Size(100, 30);
            this.Wizard_Button.TabIndex = 24;
            this.Wizard_Button.Text = "Wizard";
            this.Wizard_Button.UseVisualStyleBackColor = false;
            this.Wizard_Button.Click += new System.EventHandler(this.Wizard_Button_Click);
            // 
            // Warrior_Button
            // 
            this.Warrior_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Warrior_Button.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Warrior_Button.Location = new System.Drawing.Point(118, 29);
            this.Warrior_Button.Name = "Warrior_Button";
            this.Warrior_Button.Size = new System.Drawing.Size(100, 30);
            this.Warrior_Button.TabIndex = 25;
            this.Warrior_Button.Text = "Warrior";
            this.Warrior_Button.UseVisualStyleBackColor = false;
            this.Warrior_Button.Click += new System.EventHandler(this.Warrior_Button_Click);
            // 
            // MPAttack_Label
            // 
            this.MPAttack_Label.AutoSize = true;
            this.MPAttack_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.MPAttack_Label.Location = new System.Drawing.Point(414, 225);
            this.MPAttack_Label.Name = "MPAttack_Label";
            this.MPAttack_Label.Size = new System.Drawing.Size(103, 22);
            this.MPAttack_Label.TabIndex = 30;
            this.MPAttack_Label.Text = "MP Attack:";
            // 
            // MPAttack_Text
            // 
            this.MPAttack_Text.Location = new System.Drawing.Point(548, 224);
            this.MPAttack_Text.Name = "MPAttack_Text";
            this.MPAttack_Text.Size = new System.Drawing.Size(100, 23);
            this.MPAttack_Text.TabIndex = 33;
            // 
            // Attack_Text
            // 
            this.Attack_Text.Location = new System.Drawing.Point(548, 190);
            this.Attack_Text.Name = "Attack_Text";
            this.Attack_Text.Size = new System.Drawing.Size(100, 23);
            this.Attack_Text.TabIndex = 34;
            // 
            // PDef_Text
            // 
            this.PDef_Text.Location = new System.Drawing.Point(548, 161);
            this.PDef_Text.Name = "PDef_Text";
            this.PDef_Text.Size = new System.Drawing.Size(100, 23);
            this.PDef_Text.TabIndex = 35;
            // 
            // MP_Text
            // 
            this.MP_Text.Location = new System.Drawing.Point(548, 132);
            this.MP_Text.Name = "MP_Text";
            this.MP_Text.Size = new System.Drawing.Size(100, 23);
            this.MP_Text.TabIndex = 36;
            // 
            // HP_Text
            // 
            this.HP_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HP_Text.Location = new System.Drawing.Point(548, 103);
            this.HP_Text.Name = "HP_Text";
            this.HP_Text.Size = new System.Drawing.Size(100, 25);
            this.HP_Text.TabIndex = 37;
            // 
            // GameCharacterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HP_Text);
            this.Controls.Add(this.MP_Text);
            this.Controls.Add(this.PDef_Text);
            this.Controls.Add(this.Attack_Text);
            this.Controls.Add(this.MPAttack_Text);
            this.Controls.Add(this.MPAttack_Label);
            this.Controls.Add(this.Warrior_Button);
            this.Controls.Add(this.Wizard_Button);
            this.Controls.Add(this.Rogue_Button);
            this.Controls.Add(this.Dexterity_Text);
            this.Controls.Add(this.Strength_Text);
            this.Controls.Add(this.Constitution_Text);
            this.Controls.Add(this.Intelligence_Text);
            this.Controls.Add(this.Attack_Label);
            this.Controls.Add(this.PDef_Label);
            this.Controls.Add(this.MP_Label);
            this.Controls.Add(this.HP_Label);
            this.Controls.Add(this.Intelligence_Label);
            this.Controls.Add(this.Constitution_Label);
            this.Controls.Add(this.Dexterity_Label);
            this.Controls.Add(this.Strength_Label);
            this.Name = "GameCharacterEditor";
            this.Text = "Game character editor";
            this.Load += new System.EventHandler(this.GameCharacterEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Intelligence_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Constitution_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Strength_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dexterity_Text)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label Strength_Label;
        private Label Dexterity_Label;
        private Label Constitution_Label;
        private Label Intelligence_Label;
        private Label HP_Label;
        private Label MP_Label;
        private Label PDef_Label;
        private Label Attack_Label;
        private NumericUpDown Intelligence_Text;
        private NumericUpDown Constitution_Text;
        private NumericUpDown Strength_Text;
        private NumericUpDown Dexterity_Text;
        private Button Rogue_Button;
        private Button Wizard_Button;
        private Button Warrior_Button;
        private Label MPAttack_Label;
        private TextBox MPAttack_Text;
        private TextBox Attack_Text;
        private TextBox PDef_Text;
        private TextBox MP_Text;
        private TextBox HP_Text;
    }
}