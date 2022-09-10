namespace GameEditor
{
    partial class Main
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
            this.mainPan = new System.Windows.Forms.Panel();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.mainPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPan
            // 
            this.mainPan.Controls.Add(this.listBoxMain);
            this.mainPan.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainPan.Location = new System.Drawing.Point(428, 0);
            this.mainPan.Name = "mainPan";
            this.mainPan.Size = new System.Drawing.Size(372, 450);
            this.mainPan.TabIndex = 0;
            // 
            // listBoxMain
            // 
            this.listBoxMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.ItemHeight = 20;
            this.listBoxMain.Location = new System.Drawing.Point(0, 0);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(372, 84);
            this.listBoxMain.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPan);
            this.Name = "Main";
            this.Text = "Main";
            this.mainPan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel mainPan;
        private ListBox listBoxMain;
    }
}