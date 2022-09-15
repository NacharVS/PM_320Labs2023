
namespace Units
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericStrength = new System.Windows.Forms.NumericUpDown();
            this.numericDexterity = new System.Windows.Forms.NumericUpDown();
            this.comboBoxChoice = new System.Windows.Forms.ComboBox();
            this.numericConstitution = new System.Windows.Forms.NumericUpDown();
            this.numericIntellisence = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbHP = new System.Windows.Forms.TextBox();
            this.tbMP = new System.Windows.Forms.TextBox();
            this.tbDefence = new System.Windows.Forms.TextBox();
            this.tbDamage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDexterity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericConstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntellisence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericStrength
            // 
            this.numericStrength.Location = new System.Drawing.Point(600, 65);
            this.numericStrength.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericStrength.Name = "numericStrength";
            this.numericStrength.Size = new System.Drawing.Size(120, 20);
            this.numericStrength.TabIndex = 1;
            this.numericStrength.UseWaitCursor = true;
            this.numericStrength.ValueChanged += new System.EventHandler(this.numericStrength_ValueChanged);
            // 
            // numericDexterity
            // 
            this.numericDexterity.Location = new System.Drawing.Point(600, 125);
            this.numericDexterity.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericDexterity.Name = "numericDexterity";
            this.numericDexterity.Size = new System.Drawing.Size(120, 20);
            this.numericDexterity.TabIndex = 2;
            // 
            // comboBoxChoice
            // 
            this.comboBoxChoice.FormattingEnabled = true;
            this.comboBoxChoice.Location = new System.Drawing.Point(89, 65);
            this.comboBoxChoice.Name = "comboBoxChoice";
            this.comboBoxChoice.Size = new System.Drawing.Size(121, 21);
            this.comboBoxChoice.TabIndex = 3;
            this.comboBoxChoice.Text = "Choose unit";
            this.comboBoxChoice.SelectedIndexChanged += new System.EventHandler(this.comboBoxChoice_SelectedIndexChanged);
            // 
            // numericConstitution
            // 
            this.numericConstitution.Location = new System.Drawing.Point(600, 185);
            this.numericConstitution.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericConstitution.Name = "numericConstitution";
            this.numericConstitution.Size = new System.Drawing.Size(120, 20);
            this.numericConstitution.TabIndex = 4;
            // 
            // numericIntellisence
            // 
            this.numericIntellisence.Location = new System.Drawing.Point(600, 245);
            this.numericIntellisence.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericIntellisence.Name = "numericIntellisence";
            this.numericIntellisence.Size = new System.Drawing.Size(120, 20);
            this.numericIntellisence.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(59, 138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 251);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // tbHP
            // 
            this.tbHP.Location = new System.Drawing.Point(312, 358);
            this.tbHP.Name = "tbHP";
            this.tbHP.Size = new System.Drawing.Size(50, 20);
            this.tbHP.TabIndex = 7;
            // 
            // tbMP
            // 
            this.tbMP.Location = new System.Drawing.Point(418, 358);
            this.tbMP.Name = "tbMP";
            this.tbMP.Size = new System.Drawing.Size(50, 20);
            this.tbMP.TabIndex = 8;
            // 
            // tbDefence
            // 
            this.tbDefence.Location = new System.Drawing.Point(524, 358);
            this.tbDefence.Name = "tbDefence";
            this.tbDefence.Size = new System.Drawing.Size(50, 20);
            this.tbDefence.TabIndex = 9;
            // 
            // tbDamage
            // 
            this.tbDamage.Location = new System.Drawing.Point(630, 358);
            this.tbDamage.Name = "tbDamage";
            this.tbDamage.Size = new System.Drawing.Size(50, 20);
            this.tbDamage.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbDamage);
            this.Controls.Add(this.tbDefence);
            this.Controls.Add(this.tbMP);
            this.Controls.Add(this.tbHP);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numericIntellisence);
            this.Controls.Add(this.numericConstitution);
            this.Controls.Add(this.comboBoxChoice);
            this.Controls.Add(this.numericDexterity);
            this.Controls.Add(this.numericStrength);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDexterity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericConstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntellisence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericStrength;
        private System.Windows.Forms.NumericUpDown numericDexterity;
        private System.Windows.Forms.ComboBox comboBoxChoice;
        private System.Windows.Forms.NumericUpDown numericConstitution;
        private System.Windows.Forms.NumericUpDown numericIntellisence;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbHP;
        private System.Windows.Forms.TextBox tbMP;
        private System.Windows.Forms.TextBox tbDefence;
        private System.Windows.Forms.TextBox tbDamage;
    }
}

