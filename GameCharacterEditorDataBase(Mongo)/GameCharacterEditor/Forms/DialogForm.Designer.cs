namespace GameCharacterEditor
{
    partial class DialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TeamType_Label = new System.Windows.Forms.Label();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Armor_Label = new System.Windows.Forms.Label();
            this.Skill_Text = new System.Windows.Forms.TextBox();
            this.Skills_Lable = new System.Windows.Forms.Label();
            this.Equipment_Text = new System.Windows.Forms.TextBox();
            this.Lvl_Text = new System.Windows.Forms.Label();
            this.Lvl_Lable = new System.Windows.Forms.Label();
            this.Equipment_Lable = new System.Windows.Forms.Label();
            this.Type_Lable = new System.Windows.Forms.Label();
            this.Name_Text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MP_Text = new System.Windows.Forms.NumericUpDown();
            this.HP_Text = new System.Windows.Forms.NumericUpDown();
            this.MPAttack_Text = new System.Windows.Forms.NumericUpDown();
            this.PDef_Text = new System.Windows.Forms.NumericUpDown();
            this.Attack_Text = new System.Windows.Forms.NumericUpDown();
            this.MPAttack_Label = new System.Windows.Forms.Label();
            this.Dexterity_Text = new System.Windows.Forms.NumericUpDown();
            this.Strength_Text = new System.Windows.Forms.NumericUpDown();
            this.Constitution_Text = new System.Windows.Forms.NumericUpDown();
            this.Intelligence_Text = new System.Windows.Forms.NumericUpDown();
            this.Attack_Label = new System.Windows.Forms.Label();
            this.PDef_Label = new System.Windows.Forms.Label();
            this.MP_Label = new System.Windows.Forms.Label();
            this.HP_Label = new System.Windows.Forms.Label();
            this.Intelligence_Label = new System.Windows.Forms.Label();
            this.Constitution_Label = new System.Windows.Forms.Label();
            this.Dexterity_Label = new System.Windows.Forms.Label();
            this.Strength_Label = new System.Windows.Forms.Label();
            this.Armor_Text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MP_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HP_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MPAttack_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDef_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Attack_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dexterity_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Strength_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Constitution_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intelligence_Text)).BeginInit();
            this.SuspendLayout();
            // 
            // TeamType_Label
            // 
            this.TeamType_Label.AutoSize = true;
            this.TeamType_Label.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TeamType_Label.Location = new System.Drawing.Point(127, 446);
            this.TeamType_Label.Name = "TeamType_Label";
            this.TeamType_Label.Size = new System.Drawing.Size(609, 31);
            this.TeamType_Label.TabIndex = 80;
            this.TeamType_Label.Text = "Do you want to remove a character from the team?";
            // 
            // OK_Button
            // 
            this.OK_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.OK_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OK_Button.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OK_Button.Location = new System.Drawing.Point(328, 480);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(100, 30);
            this.OK_Button.TabIndex = 88;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = false;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel_Button.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Cancel_Button.Location = new System.Drawing.Point(434, 480);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(100, 30);
            this.Cancel_Button.TabIndex = 89;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = false;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Armor_Label
            // 
            this.Armor_Label.AutoSize = true;
            this.Armor_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Armor_Label.Location = new System.Drawing.Point(425, 168);
            this.Armor_Label.Name = "Armor_Label";
            this.Armor_Label.Size = new System.Drawing.Size(69, 22);
            this.Armor_Label.TabIndex = 131;
            this.Armor_Label.Text = "Armor:";
            // 
            // Skill_Text
            // 
            this.Skill_Text.Location = new System.Drawing.Point(542, 82);
            this.Skill_Text.Multiline = true;
            this.Skill_Text.Name = "Skill_Text";
            this.Skill_Text.Size = new System.Drawing.Size(194, 32);
            this.Skill_Text.TabIndex = 128;
            // 
            // Skills_Lable
            // 
            this.Skills_Lable.AutoSize = true;
            this.Skills_Lable.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Skills_Lable.Location = new System.Drawing.Point(425, 92);
            this.Skills_Lable.Name = "Skills_Lable";
            this.Skills_Lable.Size = new System.Drawing.Size(60, 22);
            this.Skills_Lable.TabIndex = 127;
            this.Skills_Lable.Text = "Skills:";
            // 
            // Equipment_Text
            // 
            this.Equipment_Text.Location = new System.Drawing.Point(542, 120);
            this.Equipment_Text.Multiline = true;
            this.Equipment_Text.Name = "Equipment_Text";
            this.Equipment_Text.Size = new System.Drawing.Size(194, 32);
            this.Equipment_Text.TabIndex = 125;
            // 
            // Lvl_Text
            // 
            this.Lvl_Text.AutoSize = true;
            this.Lvl_Text.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Lvl_Text.Location = new System.Drawing.Point(325, 45);
            this.Lvl_Text.Name = "Lvl_Text";
            this.Lvl_Text.Size = new System.Drawing.Size(20, 22);
            this.Lvl_Text.TabIndex = 122;
            this.Lvl_Text.Text = "0";
            // 
            // Lvl_Lable
            // 
            this.Lvl_Lable.AutoSize = true;
            this.Lvl_Lable.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Lvl_Lable.Location = new System.Drawing.Point(261, 46);
            this.Lvl_Lable.Name = "Lvl_Lable";
            this.Lvl_Lable.Size = new System.Drawing.Size(50, 22);
            this.Lvl_Lable.TabIndex = 120;
            this.Lvl_Lable.Text = "LVL:";
            // 
            // Equipment_Lable
            // 
            this.Equipment_Lable.AutoSize = true;
            this.Equipment_Lable.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Equipment_Lable.Location = new System.Drawing.Point(425, 130);
            this.Equipment_Lable.Name = "Equipment_Lable";
            this.Equipment_Lable.Size = new System.Drawing.Size(111, 22);
            this.Equipment_Lable.TabIndex = 118;
            this.Equipment_Lable.Text = "Equipments:";
            // 
            // Type_Lable
            // 
            this.Type_Lable.AutoSize = true;
            this.Type_Lable.Font = new System.Drawing.Font("Swis721 BlkCn BT", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.Type_Lable.ForeColor = System.Drawing.Color.Black;
            this.Type_Lable.Location = new System.Drawing.Point(127, 46);
            this.Type_Lable.Name = "Type_Lable";
            this.Type_Lable.Size = new System.Drawing.Size(105, 22);
            this.Type_Lable.TabIndex = 117;
            this.Type_Lable.Text = "CHARACTER";
            // 
            // Name_Text
            // 
            this.Name_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Name_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_Text.Location = new System.Drawing.Point(268, 94);
            this.Name_Text.Name = "Name_Text";
            this.Name_Text.Size = new System.Drawing.Size(120, 25);
            this.Name_Text.TabIndex = 116;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(127, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 22);
            this.label2.TabIndex = 115;
            this.label2.Text = "Name:";
            // 
            // MP_Text
            // 
            this.MP_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MP_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MP_Text.Location = new System.Drawing.Point(268, 280);
            this.MP_Text.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MP_Text.Name = "MP_Text";
            this.MP_Text.Size = new System.Drawing.Size(120, 25);
            this.MP_Text.TabIndex = 114;
            // 
            // HP_Text
            // 
            this.HP_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HP_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HP_Text.Location = new System.Drawing.Point(268, 249);
            this.HP_Text.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.HP_Text.Name = "HP_Text";
            this.HP_Text.Size = new System.Drawing.Size(120, 25);
            this.HP_Text.TabIndex = 113;
            // 
            // MPAttack_Text
            // 
            this.MPAttack_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MPAttack_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MPAttack_Text.Location = new System.Drawing.Point(268, 374);
            this.MPAttack_Text.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MPAttack_Text.Name = "MPAttack_Text";
            this.MPAttack_Text.Size = new System.Drawing.Size(120, 25);
            this.MPAttack_Text.TabIndex = 112;
            // 
            // PDef_Text
            // 
            this.PDef_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PDef_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PDef_Text.Location = new System.Drawing.Point(268, 311);
            this.PDef_Text.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.PDef_Text.Name = "PDef_Text";
            this.PDef_Text.Size = new System.Drawing.Size(120, 25);
            this.PDef_Text.TabIndex = 111;
            // 
            // Attack_Text
            // 
            this.Attack_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Attack_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Attack_Text.Location = new System.Drawing.Point(268, 342);
            this.Attack_Text.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Attack_Text.Name = "Attack_Text";
            this.Attack_Text.Size = new System.Drawing.Size(120, 25);
            this.Attack_Text.TabIndex = 110;
            // 
            // MPAttack_Label
            // 
            this.MPAttack_Label.AutoSize = true;
            this.MPAttack_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.MPAttack_Label.Location = new System.Drawing.Point(127, 372);
            this.MPAttack_Label.Name = "MPAttack_Label";
            this.MPAttack_Label.Size = new System.Drawing.Size(103, 22);
            this.MPAttack_Label.TabIndex = 109;
            this.MPAttack_Label.Text = "MP Attack:";
            // 
            // Dexterity_Text
            // 
            this.Dexterity_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Dexterity_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Dexterity_Text.Location = new System.Drawing.Point(268, 156);
            this.Dexterity_Text.Name = "Dexterity_Text";
            this.Dexterity_Text.Size = new System.Drawing.Size(120, 25);
            this.Dexterity_Text.TabIndex = 108;
            // 
            // Strength_Text
            // 
            this.Strength_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Strength_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Strength_Text.Location = new System.Drawing.Point(268, 125);
            this.Strength_Text.Name = "Strength_Text";
            this.Strength_Text.Size = new System.Drawing.Size(120, 25);
            this.Strength_Text.TabIndex = 107;
            // 
            // Constitution_Text
            // 
            this.Constitution_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Constitution_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Constitution_Text.Location = new System.Drawing.Point(268, 187);
            this.Constitution_Text.Name = "Constitution_Text";
            this.Constitution_Text.Size = new System.Drawing.Size(120, 25);
            this.Constitution_Text.TabIndex = 106;
            // 
            // Intelligence_Text
            // 
            this.Intelligence_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Intelligence_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Intelligence_Text.Location = new System.Drawing.Point(268, 218);
            this.Intelligence_Text.Name = "Intelligence_Text";
            this.Intelligence_Text.Size = new System.Drawing.Size(120, 25);
            this.Intelligence_Text.TabIndex = 105;
            // 
            // Attack_Label
            // 
            this.Attack_Label.AutoSize = true;
            this.Attack_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Attack_Label.Location = new System.Drawing.Point(127, 341);
            this.Attack_Label.Name = "Attack_Label";
            this.Attack_Label.Size = new System.Drawing.Size(70, 22);
            this.Attack_Label.TabIndex = 104;
            this.Attack_Label.Text = "Attack:";
            // 
            // PDef_Label
            // 
            this.PDef_Label.AutoSize = true;
            this.PDef_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.PDef_Label.Location = new System.Drawing.Point(127, 310);
            this.PDef_Label.Name = "PDef_Label";
            this.PDef_Label.Size = new System.Drawing.Size(56, 22);
            this.PDef_Label.TabIndex = 103;
            this.PDef_Label.Text = "PDef:";
            // 
            // MP_Label
            // 
            this.MP_Label.AutoSize = true;
            this.MP_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.MP_Label.Location = new System.Drawing.Point(127, 279);
            this.MP_Label.Name = "MP_Label";
            this.MP_Label.Size = new System.Drawing.Size(45, 22);
            this.MP_Label.TabIndex = 102;
            this.MP_Label.Text = "MP:";
            // 
            // HP_Label
            // 
            this.HP_Label.AutoSize = true;
            this.HP_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.HP_Label.Location = new System.Drawing.Point(127, 248);
            this.HP_Label.Name = "HP_Label";
            this.HP_Label.Size = new System.Drawing.Size(41, 22);
            this.HP_Label.TabIndex = 101;
            this.HP_Label.Text = "HP:";
            // 
            // Intelligence_Label
            // 
            this.Intelligence_Label.AutoSize = true;
            this.Intelligence_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Intelligence_Label.Location = new System.Drawing.Point(127, 216);
            this.Intelligence_Label.Name = "Intelligence_Label";
            this.Intelligence_Label.Size = new System.Drawing.Size(109, 22);
            this.Intelligence_Label.TabIndex = 100;
            this.Intelligence_Label.Text = "Intelligence:";
            // 
            // Constitution_Label
            // 
            this.Constitution_Label.AutoSize = true;
            this.Constitution_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Constitution_Label.Location = new System.Drawing.Point(127, 185);
            this.Constitution_Label.Name = "Constitution_Label";
            this.Constitution_Label.Size = new System.Drawing.Size(115, 22);
            this.Constitution_Label.TabIndex = 99;
            this.Constitution_Label.Text = "Constitution:";
            // 
            // Dexterity_Label
            // 
            this.Dexterity_Label.AutoSize = true;
            this.Dexterity_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Dexterity_Label.Location = new System.Drawing.Point(127, 154);
            this.Dexterity_Label.Name = "Dexterity_Label";
            this.Dexterity_Label.Size = new System.Drawing.Size(90, 22);
            this.Dexterity_Label.TabIndex = 98;
            this.Dexterity_Label.Text = "Dexterity:";
            // 
            // Strength_Label
            // 
            this.Strength_Label.AutoSize = true;
            this.Strength_Label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Strength_Label.Location = new System.Drawing.Point(127, 123);
            this.Strength_Label.Name = "Strength_Label";
            this.Strength_Label.Size = new System.Drawing.Size(85, 22);
            this.Strength_Label.TabIndex = 97;
            this.Strength_Label.Text = "Strength:";
            // 
            // Armor_Text
            // 
            this.Armor_Text.Location = new System.Drawing.Point(542, 158);
            this.Armor_Text.Multiline = true;
            this.Armor_Text.Name = "Armor_Text";
            this.Armor_Text.Size = new System.Drawing.Size(194, 32);
            this.Armor_Text.TabIndex = 133;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(853, 520);
            this.Controls.Add(this.Armor_Label);
            this.Controls.Add(this.Skill_Text);
            this.Controls.Add(this.Skills_Lable);
            this.Controls.Add(this.Equipment_Text);
            this.Controls.Add(this.Lvl_Text);
            this.Controls.Add(this.Lvl_Lable);
            this.Controls.Add(this.Equipment_Lable);
            this.Controls.Add(this.Type_Lable);
            this.Controls.Add(this.Name_Text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MP_Text);
            this.Controls.Add(this.HP_Text);
            this.Controls.Add(this.MPAttack_Text);
            this.Controls.Add(this.PDef_Text);
            this.Controls.Add(this.Attack_Text);
            this.Controls.Add(this.MPAttack_Label);
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
            this.Controls.Add(this.Armor_Text);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.TeamType_Label);
            this.Name = "InfoForm";
            this.Text = "DialogForm";
            ((System.ComponentModel.ISupportInitialize)(this.MP_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HP_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MPAttack_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDef_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Attack_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dexterity_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Strength_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Constitution_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intelligence_Text)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label TeamType_Label;
        private Button OK_Button;
        private Button Cancel_Button;
        private Label Armor_Label;
        private TextBox Skill_Text;
        private Label Skills_Lable;
        private TextBox Equipment_Text;
        private Label Lvl_Text;
        private Label Lvl_Lable;
        private Label Equipment_Lable;
        private Label Type_Lable;
        private TextBox Name_Text;
        private Label label2;
        private NumericUpDown MP_Text;
        private NumericUpDown HP_Text;
        private NumericUpDown MPAttack_Text;
        private NumericUpDown PDef_Text;
        private NumericUpDown Attack_Text;
        private Label MPAttack_Label;
        private NumericUpDown Dexterity_Text;
        private NumericUpDown Strength_Text;
        private NumericUpDown Constitution_Text;
        private NumericUpDown Intelligence_Text;
        private Label Attack_Label;
        private Label PDef_Label;
        private Label MP_Label;
        private Label HP_Label;
        private Label Intelligence_Label;
        private Label Constitution_Label;
        private Label Dexterity_Label;
        private Label Strength_Label;
        private TextBox Armor_Text;
    }
}