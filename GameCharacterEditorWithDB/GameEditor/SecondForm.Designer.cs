namespace GameEditor
{
    partial class SecondForm
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
            this.listBoxOfUnits = new System.Windows.Forms.ListBox();
            this.matchLbl = new System.Windows.Forms.Label();
            this.firstTeamLbl = new System.Windows.Forms.Label();
            this.secondTeamLbl = new System.Windows.Forms.Label();
            this.listBoxTeamOne = new System.Windows.Forms.ListBox();
            this.listBoxTeamTwo = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxOne = new System.Windows.Forms.TextBox();
            this.textBoxTwo = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.contextMenuStripTwo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripTw = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // listBoxOfUnits
            // 
            this.listBoxOfUnits.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxOfUnits.FormattingEnabled = true;
            this.listBoxOfUnits.ItemHeight = 20;
            this.listBoxOfUnits.Location = new System.Drawing.Point(0, 0);
            this.listBoxOfUnits.Name = "listBoxOfUnits";
            this.listBoxOfUnits.Size = new System.Drawing.Size(150, 450);
            this.listBoxOfUnits.TabIndex = 0;
            // 
            // matchLbl
            // 
            this.matchLbl.AutoSize = true;
            this.matchLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.matchLbl.Location = new System.Drawing.Point(401, 20);
            this.matchLbl.Name = "matchLbl";
            this.matchLbl.Size = new System.Drawing.Size(99, 38);
            this.matchLbl.TabIndex = 1;
            this.matchLbl.Text = "Match";
            // 
            // firstTeamLbl
            // 
            this.firstTeamLbl.AutoSize = true;
            this.firstTeamLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.firstTeamLbl.Location = new System.Drawing.Point(252, 62);
            this.firstTeamLbl.Name = "firstTeamLbl";
            this.firstTeamLbl.Size = new System.Drawing.Size(126, 28);
            this.firstTeamLbl.TabIndex = 2;
            this.firstTeamLbl.Text = "FIRST TEAM";
            // 
            // secondTeamLbl
            // 
            this.secondTeamLbl.AutoSize = true;
            this.secondTeamLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.secondTeamLbl.Location = new System.Drawing.Point(511, 62);
            this.secondTeamLbl.Name = "secondTeamLbl";
            this.secondTeamLbl.Size = new System.Drawing.Size(156, 28);
            this.secondTeamLbl.TabIndex = 3;
            this.secondTeamLbl.Text = "SECOND TEAM";
            // 
            // listBoxTeamOne
            // 
            this.listBoxTeamOne.FormattingEnabled = true;
            this.listBoxTeamOne.ItemHeight = 20;
            this.listBoxTeamOne.Location = new System.Drawing.Point(243, 113);
            this.listBoxTeamOne.Name = "listBoxTeamOne";
            this.listBoxTeamOne.Size = new System.Drawing.Size(150, 244);
            this.listBoxTeamOne.TabIndex = 4;
            // 
            // listBoxTeamTwo
            // 
            this.listBoxTeamTwo.FormattingEnabled = true;
            this.listBoxTeamTwo.ItemHeight = 20;
            this.listBoxTeamTwo.Location = new System.Drawing.Point(528, 113);
            this.listBoxTeamTwo.Name = "listBoxTeamTwo";
            this.listBoxTeamTwo.Size = new System.Drawing.Size(150, 244);
            this.listBoxTeamTwo.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxOne
            // 
            this.textBoxOne.Location = new System.Drawing.Point(243, 363);
            this.textBoxOne.Name = "textBoxOne";
            this.textBoxOne.ReadOnly = true;
            this.textBoxOne.Size = new System.Drawing.Size(148, 27);
            this.textBoxOne.TabIndex = 6;
            this.textBoxOne.TextChanged += new System.EventHandler(this.TextBoxOne_TextChanged);
            // 
            // textBoxTwo
            // 
            this.textBoxTwo.Location = new System.Drawing.Point(528, 363);
            this.textBoxTwo.Name = "textBoxTwo";
            this.textBoxTwo.ReadOnly = true;
            this.textBoxTwo.Size = new System.Drawing.Size(148, 27);
            this.textBoxTwo.TabIndex = 7;
            this.textBoxTwo.TextChanged += new System.EventHandler(this.TextBoxTwo_TextChanged);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(415, 363);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(94, 29);
            this.startBtn.TabIndex = 8;
            this.startBtn.Text = "Start Game";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // contextMenuStripTwo
            // 
            this.contextMenuStripTwo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTwo.Name = "contextMenuStripTwo";
            this.contextMenuStripTwo.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripTw
            // 
            this.contextMenuStripTw.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTw.Name = "contextMenuStripTw";
            this.contextMenuStripTw.Size = new System.Drawing.Size(211, 32);
            // 
            // SecondForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.textBoxTwo);
            this.Controls.Add(this.textBoxOne);
            this.Controls.Add(this.listBoxTeamTwo);
            this.Controls.Add(this.listBoxTeamOne);
            this.Controls.Add(this.secondTeamLbl);
            this.Controls.Add(this.firstTeamLbl);
            this.Controls.Add(this.matchLbl);
            this.Controls.Add(this.listBoxOfUnits);
            this.Name = "SecondForm";
            this.Text = "SecondForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBoxOfUnits;
        private Label matchLbl;
        private Label firstTeamLbl;
        private Label secondTeamLbl;
        private ListBox listBoxTeamOne;
        private ListBox listBoxTeamTwo;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBoxOne;
        private TextBox textBoxTwo;
        private Button startBtn;
        private ContextMenuStrip contextMenuStripTwo;
        private ContextMenuStrip contextMenuStripTw;
    }
}