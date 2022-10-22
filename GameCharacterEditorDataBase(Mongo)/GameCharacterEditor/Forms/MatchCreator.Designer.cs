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
            this.components = new System.ComponentModel.Container();
            this.SavedCharacteers_Lable = new System.Windows.Forms.Label();
            this.SavedCharactersBox = new System.Windows.Forms.ListBox();
            this.CustomTeam_Button = new System.Windows.Forms.Button();
            this.TeamType_Label = new System.Windows.Forms.Label();
            this.AutoTeam_Button = new System.Windows.Forms.Button();
            this.Choose_Label = new System.Windows.Forms.Label();
            this.FirstTeam_ListBox = new System.Windows.Forms.ListBox();
            this.SecondTeam_ListBox = new System.Windows.Forms.ListBox();
            this.SecondTeam_Label = new System.Windows.Forms.Label();
            this.FirstTeam_Label = new System.Windows.Forms.Label();
            this.AutoGenerate_Button = new System.Windows.Forms.Button();
            this.ClearFirst_Button = new System.Windows.Forms.Button();
            this.ClearSecond_Button = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MatchInfo_Button = new System.Windows.Forms.Button();
            this.Or_Lable = new System.Windows.Forms.Label();
            this.Match_ListBox = new System.Windows.Forms.ListBox();
            this.Matches_Label = new System.Windows.Forms.Label();
            this.HoldMatch_Button = new System.Windows.Forms.Button();
            this.MatchNumber = new System.Windows.Forms.NumericUpDown();
            this.Balance_Text = new System.Windows.Forms.TextBox();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchNumber)).BeginInit();
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
            this.CustomTeam_Button.Location = new System.Drawing.Point(321, 166);
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
            this.TeamType_Label.Location = new System.Drawing.Point(321, 116);
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
            this.AutoTeam_Button.Location = new System.Drawing.Point(321, 214);
            this.AutoTeam_Button.Name = "AutoTeam_Button";
            this.AutoTeam_Button.Size = new System.Drawing.Size(367, 42);
            this.AutoTeam_Button.TabIndex = 80;
            this.AutoTeam_Button.Text = "Automatic team generation";
            this.AutoTeam_Button.UseVisualStyleBackColor = false;
            this.AutoTeam_Button.Click += new System.EventHandler(this.AutoTeam_Button_Click);
            // 
            // Choose_Label
            // 
            this.Choose_Label.AutoSize = true;
            this.Choose_Label.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Choose_Label.Location = new System.Drawing.Point(26, 21);
            this.Choose_Label.Name = "Choose_Label";
            this.Choose_Label.Size = new System.Drawing.Size(229, 17);
            this.Choose_Label.TabIndex = 81;
            this.Choose_Label.Text = "Choosing a character for the team";
            this.Choose_Label.Visible = false;
            // 
            // FirstTeam_ListBox
            // 
            this.FirstTeam_ListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FirstTeam_ListBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FirstTeam_ListBox.FormattingEnabled = true;
            this.FirstTeam_ListBox.ItemHeight = 15;
            this.FirstTeam_ListBox.Location = new System.Drawing.Point(321, 170);
            this.FirstTeam_ListBox.Name = "FirstTeam_ListBox";
            this.FirstTeam_ListBox.Size = new System.Drawing.Size(169, 94);
            this.FirstTeam_ListBox.TabIndex = 82;
            this.FirstTeam_ListBox.Visible = false;
            this.FirstTeam_ListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FirstTeam_ListBox_MouseUp);
            // 
            // SecondTeam_ListBox
            // 
            this.SecondTeam_ListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SecondTeam_ListBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SecondTeam_ListBox.FormattingEnabled = true;
            this.SecondTeam_ListBox.ItemHeight = 15;
            this.SecondTeam_ListBox.Location = new System.Drawing.Point(519, 170);
            this.SecondTeam_ListBox.Name = "SecondTeam_ListBox";
            this.SecondTeam_ListBox.Size = new System.Drawing.Size(169, 94);
            this.SecondTeam_ListBox.TabIndex = 83;
            this.SecondTeam_ListBox.Visible = false;
            this.SecondTeam_ListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SecondTeam_ListBox_MouseUp);
            // 
            // SecondTeam_Label
            // 
            this.SecondTeam_Label.AutoSize = true;
            this.SecondTeam_Label.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SecondTeam_Label.Location = new System.Drawing.Point(556, 150);
            this.SecondTeam_Label.Name = "SecondTeam_Label";
            this.SecondTeam_Label.Size = new System.Drawing.Size(91, 17);
            this.SecondTeam_Label.TabIndex = 84;
            this.SecondTeam_Label.Text = "Second team";
            this.SecondTeam_Label.Visible = false;
            // 
            // FirstTeam_Label
            // 
            this.FirstTeam_Label.AutoSize = true;
            this.FirstTeam_Label.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FirstTeam_Label.Location = new System.Drawing.Point(364, 150);
            this.FirstTeam_Label.Name = "FirstTeam_Label";
            this.FirstTeam_Label.Size = new System.Drawing.Size(75, 17);
            this.FirstTeam_Label.TabIndex = 85;
            this.FirstTeam_Label.Text = "First team";
            this.FirstTeam_Label.Visible = false;
            // 
            // AutoGenerate_Button
            // 
            this.AutoGenerate_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AutoGenerate_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoGenerate_Button.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AutoGenerate_Button.Location = new System.Drawing.Point(321, 105);
            this.AutoGenerate_Button.Name = "AutoGenerate_Button";
            this.AutoGenerate_Button.Size = new System.Drawing.Size(367, 42);
            this.AutoGenerate_Button.TabIndex = 86;
            this.AutoGenerate_Button.Text = "Start generating teams";
            this.AutoGenerate_Button.UseVisualStyleBackColor = false;
            this.AutoGenerate_Button.Visible = false;
            this.AutoGenerate_Button.Click += new System.EventHandler(this.AutoGenerate_Button_Click);
            // 
            // ClearFirst_Button
            // 
            this.ClearFirst_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClearFirst_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearFirst_Button.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClearFirst_Button.Location = new System.Drawing.Point(352, 270);
            this.ClearFirst_Button.Name = "ClearFirst_Button";
            this.ClearFirst_Button.Size = new System.Drawing.Size(100, 30);
            this.ClearFirst_Button.TabIndex = 87;
            this.ClearFirst_Button.Text = "Clear";
            this.ClearFirst_Button.UseVisualStyleBackColor = false;
            this.ClearFirst_Button.Visible = false;
            this.ClearFirst_Button.Click += new System.EventHandler(this.ClearFirst_Button_Click);
            // 
            // ClearSecond_Button
            // 
            this.ClearSecond_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClearSecond_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearSecond_Button.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClearSecond_Button.Location = new System.Drawing.Point(556, 270);
            this.ClearSecond_Button.Name = "ClearSecond_Button";
            this.ClearSecond_Button.Size = new System.Drawing.Size(100, 30);
            this.ClearSecond_Button.TabIndex = 88;
            this.ClearSecond_Button.Text = "Clear";
            this.ClearSecond_Button.UseVisualStyleBackColor = false;
            this.ClearSecond_Button.Visible = false;
            this.ClearSecond_Button.Click += new System.EventHandler(this.ClearSecond_Button_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 26);
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem.Text = "toolStripMenuItem1";
            // 
            // MatchInfo_Button
            // 
            this.MatchInfo_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.MatchInfo_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MatchInfo_Button.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MatchInfo_Button.Location = new System.Drawing.Point(321, 310);
            this.MatchInfo_Button.Name = "MatchInfo_Button";
            this.MatchInfo_Button.Size = new System.Drawing.Size(367, 42);
            this.MatchInfo_Button.TabIndex = 89;
            this.MatchInfo_Button.Text = "View info about all matches";
            this.MatchInfo_Button.UseVisualStyleBackColor = false;
            this.MatchInfo_Button.Click += new System.EventHandler(this.MatchInfo_Button_Click);
            // 
            // Or_Lable
            // 
            this.Or_Lable.AutoSize = true;
            this.Or_Lable.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Or_Lable.Location = new System.Drawing.Point(482, 263);
            this.Or_Lable.Name = "Or_Lable";
            this.Or_Lable.Size = new System.Drawing.Size(40, 31);
            this.Or_Lable.TabIndex = 90;
            this.Or_Lable.Text = "or";
            // 
            // Match_ListBox
            // 
            this.Match_ListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Match_ListBox.Enabled = false;
            this.Match_ListBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.Match_ListBox.FormattingEnabled = true;
            this.Match_ListBox.ItemHeight = 15;
            this.Match_ListBox.Location = new System.Drawing.Point(50, 41);
            this.Match_ListBox.Name = "Match_ListBox";
            this.Match_ListBox.Size = new System.Drawing.Size(169, 379);
            this.Match_ListBox.TabIndex = 91;
            this.Match_ListBox.Visible = false;
            this.Match_ListBox.SelectedIndexChanged += new System.EventHandler(this.Match_ListBox_SelectedIndexChanged);
            // 
            // Matches_Label
            // 
            this.Matches_Label.AutoSize = true;
            this.Matches_Label.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Matches_Label.Location = new System.Drawing.Point(97, 21);
            this.Matches_Label.Name = "Matches_Label";
            this.Matches_Label.Size = new System.Drawing.Size(65, 17);
            this.Matches_Label.TabIndex = 92;
            this.Matches_Label.Text = "Matches";
            this.Matches_Label.Visible = false;
            // 
            // HoldMatch_Button
            // 
            this.HoldMatch_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.HoldMatch_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HoldMatch_Button.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HoldMatch_Button.Location = new System.Drawing.Point(321, 310);
            this.HoldMatch_Button.Name = "HoldMatch_Button";
            this.HoldMatch_Button.Size = new System.Drawing.Size(367, 42);
            this.HoldMatch_Button.TabIndex = 93;
            this.HoldMatch_Button.Text = "Hold a match";
            this.HoldMatch_Button.UseVisualStyleBackColor = false;
            this.HoldMatch_Button.Visible = false;
            this.HoldMatch_Button.Click += new System.EventHandler(this.HoldMatch_Button_Click);
            // 
            // MatchNumber
            // 
            this.MatchNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MatchNumber.Enabled = false;
            this.MatchNumber.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MatchNumber.Location = new System.Drawing.Point(445, 358);
            this.MatchNumber.Name = "MatchNumber";
            this.MatchNumber.Size = new System.Drawing.Size(120, 25);
            this.MatchNumber.TabIndex = 94;
            this.MatchNumber.ValueChanged += new System.EventHandler(this.MatchNumber_ValueChanged);
            // 
            // Balance_Text
            // 
            this.Balance_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Balance_Text.Enabled = false;
            this.Balance_Text.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Balance_Text.Location = new System.Drawing.Point(445, 74);
            this.Balance_Text.Name = "Balance_Text";
            this.Balance_Text.Size = new System.Drawing.Size(120, 25);
            this.Balance_Text.TabIndex = 95;
            // 
            // MatchCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Balance_Text);
            this.Controls.Add(this.MatchNumber);
            this.Controls.Add(this.HoldMatch_Button);
            this.Controls.Add(this.Matches_Label);
            this.Controls.Add(this.Match_ListBox);
            this.Controls.Add(this.Or_Lable);
            this.Controls.Add(this.ClearSecond_Button);
            this.Controls.Add(this.ClearFirst_Button);
            this.Controls.Add(this.AutoGenerate_Button);
            this.Controls.Add(this.FirstTeam_Label);
            this.Controls.Add(this.SecondTeam_Label);
            this.Controls.Add(this.SecondTeam_ListBox);
            this.Controls.Add(this.FirstTeam_ListBox);
            this.Controls.Add(this.Choose_Label);
            this.Controls.Add(this.AutoTeam_Button);
            this.Controls.Add(this.TeamType_Label);
            this.Controls.Add(this.CustomTeam_Button);
            this.Controls.Add(this.SavedCharacteers_Lable);
            this.Controls.Add(this.SavedCharactersBox);
            this.Controls.Add(this.MatchInfo_Button);
            this.Name = "MatchCreator";
            this.Text = "Match";
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MatchNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label SavedCharacteers_Lable;
        private ListBox SavedCharactersBox;
        private Button CustomTeam_Button;
        private Label TeamType_Label;
        private Button AutoTeam_Button;
        private Label Choose_Label;
        private ListBox FirstTeam_ListBox;
        private ListBox SecondTeam_ListBox;
        private Label SecondTeam_Label;
        private Label FirstTeam_Label;
        private Button AutoGenerate_Button;
        private Button ClearFirst_Button;
        private Button ClearSecond_Button;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItem;
        private Button MatchInfo_Button;
        private Label Or_Lable;
        private ListBox Match_ListBox;
        private Label Matches_Label;
        private Button HoldMatch_Button;
        private NumericUpDown MatchNumber;
        private TextBox Balance_Text;
    }
}