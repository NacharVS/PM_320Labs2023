namespace GameCharacterEditor
{
    partial class MatchCreator
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
            this.SavedCharacteers_Lable = new System.Windows.Forms.Label();
            this.SavedCharactersBox = new System.Windows.Forms.ListBox();
            this.CustomTeam_Button = new System.Windows.Forms.Button();
            this.TeamType_Label = new System.Windows.Forms.Label();
            this.AutoTeam_Button = new System.Windows.Forms.Button();
            this.Choos_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SavedCharacteers_Lable
            // 
            this.SavedCharacteers_Lable.AutoSize = true;
            this.SavedCharacteers_Lable.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SavedCharacteers_Lable.Location = new System.Drawing.Point(74, 21);
            this.SavedCharacteers_Lable.Name = "SavedCharacteers_Lable";
            this.SavedCharacteers_Lable.Size = new System.Drawing.Size(122, 17);
            this.SavedCharacteers_Lable.TabIndex = 49;
            this.SavedCharacteers_Lable.Text = "List of characters";
            // 
            // SavedCharactersBox
            // 
            this.SavedCharactersBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SavedCharactersBox.Enabled = false;
            this.SavedCharactersBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.SavedCharactersBox.FormattingEnabled = true;
            this.SavedCharactersBox.ItemHeight = 15;
            this.SavedCharactersBox.Location = new System.Drawing.Point(50, 41);
            this.SavedCharactersBox.Name = "SavedCharactersBox";
            this.SavedCharactersBox.Size = new System.Drawing.Size(169, 379);
            this.SavedCharactersBox.TabIndex = 48;
            this.SavedCharactersBox.SelectedIndexChanged += new System.EventHandler(this.SavedCharactersBox_SelectedIndexChanged);
            // 
            // CustomTeam_Button
            // 
            this.CustomTeam_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CustomTeam_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CustomTeam_Button.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CustomTeam_Button.Location = new System.Drawing.Point(321, 210);
            this.CustomTeam_Button.Name = "CustomTeam_Button";
            this.CustomTeam_Button.Size = new System.Drawing.Size(367, 42);
            this.CustomTeam_Button.TabIndex = 78;
            this.CustomTeam_Button.Text = "Custom team generation";
            this.CustomTeam_Button.UseVisualStyleBackColor = false;
            this.CustomTeam_Button.Click += new System.EventHandler(this.CustomTeam_Button_Click);
            // 
            // TeamType_Label
            // 
            this.TeamType_Label.AutoSize = true;
            this.TeamType_Label.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TeamType_Label.Location = new System.Drawing.Point(321, 154);
            this.TeamType_Label.Name = "TeamType_Label";
            this.TeamType_Label.Size = new System.Drawing.Size(367, 31);
            this.TeamType_Label.TabIndex = 79;
            this.TeamType_Label.Text = "Choose a way to create a team";
            // 
            // AutoTeam_Button
            // 
            this.AutoTeam_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AutoTeam_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoTeam_Button.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AutoTeam_Button.Location = new System.Drawing.Point(321, 258);
            this.AutoTeam_Button.Name = "AutoTeam_Button";
            this.AutoTeam_Button.Size = new System.Drawing.Size(367, 42);
            this.AutoTeam_Button.TabIndex = 80;
            this.AutoTeam_Button.Text = "Automatic team generation";
            this.AutoTeam_Button.UseVisualStyleBackColor = false;
            this.AutoTeam_Button.Click += new System.EventHandler(this.AutoTeam_Button_Click);
            // 
            // Choos_Label
            // 
            this.Choos_Label.AutoSize = true;
            this.Choos_Label.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Choos_Label.Location = new System.Drawing.Point(26, 21);
            this.Choos_Label.Name = "Choos_Label";
            this.Choos_Label.Size = new System.Drawing.Size(229, 17);
            this.Choos_Label.TabIndex = 81;
            this.Choos_Label.Text = "Choosing a character for the team";
            this.Choos_Label.Visible = false;
            // 
            // Match
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Choos_Label);
            this.Controls.Add(this.AutoTeam_Button);
            this.Controls.Add(this.TeamType_Label);
            this.Controls.Add(this.CustomTeam_Button);
            this.Controls.Add(this.SavedCharacteers_Lable);
            this.Controls.Add(this.SavedCharactersBox);
            this.Name = "Match";
            this.Text = "Match";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label SavedCharacteers_Lable;
        private ListBox SavedCharactersBox;
        private Button CustomTeam_Button;
        private Label TeamType_Label;
        private Button AutoTeam_Button;
        private Label Choos_Label;
    }
}