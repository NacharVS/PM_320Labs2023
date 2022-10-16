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
            this.contextMenuStrip.SuspendLayout();
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
            this.FirstTeam_ListBox.Location = new System.Drawing.Point(321, 210);
            this.FirstTeam_ListBox.Name = "FirstTeam_ListBox";
            this.FirstTeam_ListBox.Size = new System.Drawing.Size(169, 94);
            this.FirstTeam_ListBox.TabIndex = 82;
            this.FirstTeam_ListBox.Visible = false;
            this.FirstTeam_ListBox.SelectedIndexChanged += new System.EventHandler(this.FirstTeam_ListBox_SelectedIndexChanged);
            this.FirstTeam_ListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FirstTeam_ListBox_MouseUp);
            // 
            // SecondTeam_ListBox
            // 
            this.SecondTeam_ListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SecondTeam_ListBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SecondTeam_ListBox.FormattingEnabled = true;
            this.SecondTeam_ListBox.ItemHeight = 15;
            this.SecondTeam_ListBox.Location = new System.Drawing.Point(519, 210);
            this.SecondTeam_ListBox.Name = "SecondTeam_ListBox";
            this.SecondTeam_ListBox.Size = new System.Drawing.Size(169, 94);
            this.SecondTeam_ListBox.TabIndex = 83;
            this.SecondTeam_ListBox.Visible = false;
            this.SecondTeam_ListBox.SelectedIndexChanged += new System.EventHandler(this.SecondTeam_ListBox_SelectedIndexChanged);
            // 
            // SecondTeam_Label
            // 
            this.SecondTeam_Label.AutoSize = true;
            this.SecondTeam_Label.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SecondTeam_Label.Location = new System.Drawing.Point(556, 185);
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
            this.FirstTeam_Label.Location = new System.Drawing.Point(365, 185);
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
            this.AutoGenerate_Button.Location = new System.Drawing.Point(321, 109);
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
            this.ClearFirst_Button.Location = new System.Drawing.Point(355, 306);
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
            this.ClearSecond_Button.Location = new System.Drawing.Point(556, 306);
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
            // MatchCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "MatchCreator";
            this.Text = "Match";
            this.contextMenuStrip.ResumeLayout(false);
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
    }
}