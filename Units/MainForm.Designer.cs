
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.lbStrength = new System.Windows.Forms.Label();
            this.lbDexterity = new System.Windows.Forms.Label();
            this.lbConstitution = new System.Windows.Forms.Label();
            this.lbIntelligence = new System.Windows.Forms.Label();
            this.lbChoose = new System.Windows.Forms.Label();
            this.lbHP = new System.Windows.Forms.Label();
            this.lbMP = new System.Windows.Forms.Label();
            this.lbDefence = new System.Windows.Forms.Label();
            this.lnDamage = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDexterity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericConstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntellisence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericStrength
            // 
            this.numericStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericStrength.Location = new System.Drawing.Point(588, 67);
            this.numericStrength.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericStrength.Name = "numericStrength";
            this.numericStrength.Size = new System.Drawing.Size(120, 26);
            this.numericStrength.TabIndex = 1;
            this.numericStrength.UseWaitCursor = true;
            this.numericStrength.ValueChanged += new System.EventHandler(this.numericStrength_ValueChanged);
            // 
            // numericDexterity
            // 
            this.numericDexterity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericDexterity.Location = new System.Drawing.Point(588, 124);
            this.numericDexterity.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericDexterity.Name = "numericDexterity";
            this.numericDexterity.Size = new System.Drawing.Size(120, 26);
            this.numericDexterity.TabIndex = 2;
            this.numericDexterity.ValueChanged += new System.EventHandler(this.numericDexterity_ValueChanged);
            // 
            // comboBoxChoice
            // 
            this.comboBoxChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxChoice.FormattingEnabled = true;
            this.comboBoxChoice.Location = new System.Drawing.Point(164, 80);
            this.comboBoxChoice.Name = "comboBoxChoice";
            this.comboBoxChoice.Size = new System.Drawing.Size(148, 33);
            this.comboBoxChoice.TabIndex = 3;
            this.comboBoxChoice.SelectedIndexChanged += new System.EventHandler(this.comboBoxChoice_SelectedIndexChanged);
            // 
            // numericConstitution
            // 
            this.numericConstitution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericConstitution.Location = new System.Drawing.Point(588, 185);
            this.numericConstitution.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericConstitution.Name = "numericConstitution";
            this.numericConstitution.Size = new System.Drawing.Size(120, 26);
            this.numericConstitution.TabIndex = 4;
            this.numericConstitution.ValueChanged += new System.EventHandler(this.numericConstitution_ValueChanged);
            // 
            // numericIntellisence
            // 
            this.numericIntellisence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericIntellisence.Location = new System.Drawing.Point(588, 240);
            this.numericIntellisence.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericIntellisence.Name = "numericIntellisence";
            this.numericIntellisence.Size = new System.Drawing.Size(120, 26);
            this.numericIntellisence.TabIndex = 5;
            this.numericIntellisence.ValueChanged += new System.EventHandler(this.numericIntellisence_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(50, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 200);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // tbHP
            // 
            this.tbHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbHP.Location = new System.Drawing.Point(63, 358);
            this.tbHP.Name = "tbHP";
            this.tbHP.Size = new System.Drawing.Size(65, 26);
            this.tbHP.TabIndex = 7;
            // 
            // tbMP
            // 
            this.tbMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMP.Location = new System.Drawing.Point(190, 358);
            this.tbMP.Name = "tbMP";
            this.tbMP.Size = new System.Drawing.Size(70, 26);
            this.tbMP.TabIndex = 8;
            // 
            // tbDefence
            // 
            this.tbDefence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDefence.Location = new System.Drawing.Point(314, 358);
            this.tbDefence.Name = "tbDefence";
            this.tbDefence.Size = new System.Drawing.Size(72, 26);
            this.tbDefence.TabIndex = 9;
            // 
            // tbDamage
            // 
            this.tbDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDamage.Location = new System.Drawing.Point(449, 358);
            this.tbDamage.Name = "tbDamage";
            this.tbDamage.Size = new System.Drawing.Size(70, 26);
            this.tbDamage.TabIndex = 10;
            // 
            // lbStrength
            // 
            this.lbStrength.AutoSize = true;
            this.lbStrength.BackColor = System.Drawing.Color.Transparent;
            this.lbStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStrength.Location = new System.Drawing.Point(413, 65);
            this.lbStrength.Name = "lbStrength";
            this.lbStrength.Size = new System.Drawing.Size(93, 25);
            this.lbStrength.TabIndex = 11;
            this.lbStrength.Text = "Strength";
            // 
            // lbDexterity
            // 
            this.lbDexterity.AutoSize = true;
            this.lbDexterity.BackColor = System.Drawing.Color.Transparent;
            this.lbDexterity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDexterity.Location = new System.Drawing.Point(413, 125);
            this.lbDexterity.Name = "lbDexterity";
            this.lbDexterity.Size = new System.Drawing.Size(97, 25);
            this.lbDexterity.TabIndex = 12;
            this.lbDexterity.Text = "Dexterity";
            // 
            // lbConstitution
            // 
            this.lbConstitution.AutoSize = true;
            this.lbConstitution.BackColor = System.Drawing.Color.Transparent;
            this.lbConstitution.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbConstitution.Location = new System.Drawing.Point(413, 185);
            this.lbConstitution.Name = "lbConstitution";
            this.lbConstitution.Size = new System.Drawing.Size(126, 25);
            this.lbConstitution.TabIndex = 13;
            this.lbConstitution.Text = "Constitution";
            // 
            // lbIntelligence
            // 
            this.lbIntelligence.AutoSize = true;
            this.lbIntelligence.BackColor = System.Drawing.Color.Transparent;
            this.lbIntelligence.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbIntelligence.Location = new System.Drawing.Point(413, 238);
            this.lbIntelligence.Name = "lbIntelligence";
            this.lbIntelligence.Size = new System.Drawing.Size(121, 25);
            this.lbIntelligence.TabIndex = 14;
            this.lbIntelligence.Text = "Intelligence";
            // 
            // lbChoose
            // 
            this.lbChoose.AutoSize = true;
            this.lbChoose.BackColor = System.Drawing.Color.Transparent;
            this.lbChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbChoose.Location = new System.Drawing.Point(158, 24);
            this.lbChoose.Name = "lbChoose";
            this.lbChoose.Size = new System.Drawing.Size(170, 33);
            this.lbChoose.TabIndex = 15;
            this.lbChoose.Text = "Choose unit";
            // 
            // lbHP
            // 
            this.lbHP.AutoSize = true;
            this.lbHP.BackColor = System.Drawing.Color.Transparent;
            this.lbHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbHP.Location = new System.Drawing.Point(76, 396);
            this.lbHP.Name = "lbHP";
            this.lbHP.Size = new System.Drawing.Size(41, 25);
            this.lbHP.TabIndex = 16;
            this.lbHP.Text = "HP";
            // 
            // lbMP
            // 
            this.lbMP.AutoSize = true;
            this.lbMP.BackColor = System.Drawing.Color.Transparent;
            this.lbMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMP.Location = new System.Drawing.Point(206, 397);
            this.lbMP.Name = "lbMP";
            this.lbMP.Size = new System.Drawing.Size(44, 25);
            this.lbMP.TabIndex = 17;
            this.lbMP.Text = "MP";
            // 
            // lbDefence
            // 
            this.lbDefence.AutoSize = true;
            this.lbDefence.BackColor = System.Drawing.Color.Transparent;
            this.lbDefence.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDefence.Location = new System.Drawing.Point(309, 397);
            this.lbDefence.Name = "lbDefence";
            this.lbDefence.Size = new System.Drawing.Size(92, 25);
            this.lbDefence.TabIndex = 18;
            this.lbDefence.Text = "Defence";
            // 
            // lnDamage
            // 
            this.lnDamage.AutoSize = true;
            this.lnDamage.BackColor = System.Drawing.Color.Transparent;
            this.lnDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lnDamage.Location = new System.Drawing.Point(454, 396);
            this.lnDamage.Name = "lnDamage";
            this.lnDamage.Size = new System.Drawing.Size(92, 25);
            this.lnDamage.TabIndex = 19;
            this.lnDamage.Text = "Damage";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Location = new System.Drawing.Point(607, 353);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(101, 35);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "CREATE";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lnDamage);
            this.Controls.Add(this.lbDefence);
            this.Controls.Add(this.lbMP);
            this.Controls.Add(this.lbHP);
            this.Controls.Add(this.lbChoose);
            this.Controls.Add(this.lbIntelligence);
            this.Controls.Add(this.lbConstitution);
            this.Controls.Add(this.lbDexterity);
            this.Controls.Add(this.lbStrength);
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
        private System.Windows.Forms.Label lbStrength;
        private System.Windows.Forms.Label lbDexterity;
        private System.Windows.Forms.Label lbConstitution;
        private System.Windows.Forms.Label lbIntelligence;
        private System.Windows.Forms.Label lbChoose;
        private System.Windows.Forms.Label lbHP;
        private System.Windows.Forms.Label lbMP;
        private System.Windows.Forms.Label lbDefence;
        private System.Windows.Forms.Label lnDamage;
        private System.Windows.Forms.Button btnOk;
    }
}

