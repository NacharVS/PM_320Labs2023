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
            this.secondPanel = new System.Windows.Forms.Panel();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.textBoxAttackMana = new System.Windows.Forms.TextBox();
            this.attackManaLbl = new System.Windows.Forms.Label();
            this.textBoxPDef = new System.Windows.Forms.TextBox();
            this.textBoxAttack = new System.Windows.Forms.TextBox();
            this.textBoxHP = new System.Windows.Forms.TextBox();
            this.textBoxMana = new System.Windows.Forms.TextBox();
            this.pDefLbl = new System.Windows.Forms.Label();
            this.attackLbl = new System.Windows.Forms.Label();
            this.hpLbl = new System.Windows.Forms.Label();
            this.manaLbl = new System.Windows.Forms.Label();
            this.numericUpDownInt = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCon = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDex = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStr = new System.Windows.Forms.NumericUpDown();
            this.intelligenceLbl = new System.Windows.Forms.Label();
            this.constitutionLbl = new System.Windows.Forms.Label();
            this.dexterityLbl = new System.Windows.Forms.Label();
            this.strengthLbl = new System.Windows.Forms.Label();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.thirdComboBox = new System.Windows.Forms.ComboBox();
            this.thirdItemLbl = new System.Windows.Forms.Label();
            this.secondComboBox = new System.Windows.Forms.ComboBox();
            this.inventoryLbl = new System.Windows.Forms.Label();
            this.firstComboBox = new System.Windows.Forms.ComboBox();
            this.secondItemLbl = new System.Windows.Forms.Label();
            this.firstItemLbl = new System.Windows.Forms.Label();
            this.listBoxRes = new System.Windows.Forms.ListBox();
            this.mainPan.SuspendLayout();
            this.secondPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStr)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPan
            // 
            this.mainPan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mainPan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPan.Controls.Add(this.secondPanel);
            this.mainPan.Controls.Add(this.textBoxName);
            this.mainPan.Controls.Add(this.nameLbl);
            this.mainPan.Controls.Add(this.okBtn);
            this.mainPan.Controls.Add(this.textBoxAttackMana);
            this.mainPan.Controls.Add(this.attackManaLbl);
            this.mainPan.Controls.Add(this.textBoxPDef);
            this.mainPan.Controls.Add(this.textBoxAttack);
            this.mainPan.Controls.Add(this.textBoxHP);
            this.mainPan.Controls.Add(this.textBoxMana);
            this.mainPan.Controls.Add(this.pDefLbl);
            this.mainPan.Controls.Add(this.attackLbl);
            this.mainPan.Controls.Add(this.hpLbl);
            this.mainPan.Controls.Add(this.manaLbl);
            this.mainPan.Controls.Add(this.numericUpDownInt);
            this.mainPan.Controls.Add(this.numericUpDownCon);
            this.mainPan.Controls.Add(this.numericUpDownDex);
            this.mainPan.Controls.Add(this.numericUpDownStr);
            this.mainPan.Controls.Add(this.intelligenceLbl);
            this.mainPan.Controls.Add(this.constitutionLbl);
            this.mainPan.Controls.Add(this.dexterityLbl);
            this.mainPan.Controls.Add(this.strengthLbl);
            this.mainPan.Controls.Add(this.listBoxMain);
            this.mainPan.Controls.Add(this.panelMain);
            this.mainPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPan.Location = new System.Drawing.Point(328, 0);
            this.mainPan.Name = "mainPan";
            this.mainPan.Size = new System.Drawing.Size(819, 466);
            this.mainPan.TabIndex = 0;
            // 
            // secondPanel
            // 
            this.secondPanel.Controls.Add(this.listBoxItems);
            this.secondPanel.Location = new System.Drawing.Point(442, 258);
            this.secondPanel.Name = "secondPanel";
            this.secondPanel.Size = new System.Drawing.Size(370, 125);
            this.secondPanel.TabIndex = 30;
            // 
            // listBoxItems
            // 
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.ItemHeight = 20;
            this.listBoxItems.Location = new System.Drawing.Point(22, 10);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(341, 104);
            this.listBoxItems.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(156, 69);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(280, 27);
            this.textBoxName.TabIndex = 21;
            this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLbl.Location = new System.Drawing.Point(21, 67);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(59, 25);
            this.nameLbl.TabIndex = 20;
            this.nameLbl.Text = "Name";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(359, 418);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(94, 25);
            this.okBtn.TabIndex = 19;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // textBoxAttackMana
            // 
            this.textBoxAttackMana.Location = new System.Drawing.Point(328, 385);
            this.textBoxAttackMana.Name = "textBoxAttackMana";
            this.textBoxAttackMana.ReadOnly = true;
            this.textBoxAttackMana.Size = new System.Drawing.Size(125, 27);
            this.textBoxAttackMana.TabIndex = 18;
            // 
            // attackManaLbl
            // 
            this.attackManaLbl.AutoSize = true;
            this.attackManaLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attackManaLbl.Location = new System.Drawing.Point(216, 389);
            this.attackManaLbl.Name = "attackManaLbl";
            this.attackManaLbl.Size = new System.Drawing.Size(106, 23);
            this.attackManaLbl.TabIndex = 17;
            this.attackManaLbl.Text = "Attack Mana";
            // 
            // textBoxPDef
            // 
            this.textBoxPDef.Location = new System.Drawing.Point(158, 345);
            this.textBoxPDef.Name = "textBoxPDef";
            this.textBoxPDef.ReadOnly = true;
            this.textBoxPDef.Size = new System.Drawing.Size(278, 27);
            this.textBoxPDef.TabIndex = 16;
            // 
            // textBoxAttack
            // 
            this.textBoxAttack.Location = new System.Drawing.Point(85, 385);
            this.textBoxAttack.Name = "textBoxAttack";
            this.textBoxAttack.ReadOnly = true;
            this.textBoxAttack.Size = new System.Drawing.Size(125, 27);
            this.textBoxAttack.TabIndex = 15;
            // 
            // textBoxHP
            // 
            this.textBoxHP.Location = new System.Drawing.Point(158, 306);
            this.textBoxHP.Name = "textBoxHP";
            this.textBoxHP.ReadOnly = true;
            this.textBoxHP.Size = new System.Drawing.Size(278, 27);
            this.textBoxHP.TabIndex = 14;
            // 
            // textBoxMana
            // 
            this.textBoxMana.Location = new System.Drawing.Point(158, 266);
            this.textBoxMana.Name = "textBoxMana";
            this.textBoxMana.ReadOnly = true;
            this.textBoxMana.Size = new System.Drawing.Size(278, 27);
            this.textBoxMana.TabIndex = 13;
            // 
            // pDefLbl
            // 
            this.pDefLbl.AutoSize = true;
            this.pDefLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pDefLbl.Location = new System.Drawing.Point(21, 349);
            this.pDefLbl.Name = "pDefLbl";
            this.pDefLbl.Size = new System.Drawing.Size(96, 23);
            this.pDefLbl.TabIndex = 12;
            this.pDefLbl.Text = "PhysicalDef";
            // 
            // attackLbl
            // 
            this.attackLbl.AutoSize = true;
            this.attackLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attackLbl.Location = new System.Drawing.Point(21, 389);
            this.attackLbl.Name = "attackLbl";
            this.attackLbl.Size = new System.Drawing.Size(58, 23);
            this.attackLbl.TabIndex = 11;
            this.attackLbl.Text = "Attack";
            // 
            // hpLbl
            // 
            this.hpLbl.AutoSize = true;
            this.hpLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hpLbl.Location = new System.Drawing.Point(21, 310);
            this.hpLbl.Name = "hpLbl";
            this.hpLbl.Size = new System.Drawing.Size(32, 23);
            this.hpLbl.TabIndex = 10;
            this.hpLbl.Text = "HP";
            // 
            // manaLbl
            // 
            this.manaLbl.AutoSize = true;
            this.manaLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.manaLbl.Location = new System.Drawing.Point(21, 270);
            this.manaLbl.Name = "manaLbl";
            this.manaLbl.Size = new System.Drawing.Size(53, 23);
            this.manaLbl.TabIndex = 9;
            this.manaLbl.Text = "Mana";
            // 
            // numericUpDownInt
            // 
            this.numericUpDownInt.Location = new System.Drawing.Point(158, 229);
            this.numericUpDownInt.Name = "numericUpDownInt";
            this.numericUpDownInt.Size = new System.Drawing.Size(278, 27);
            this.numericUpDownInt.TabIndex = 8;
            this.numericUpDownInt.ValueChanged += new System.EventHandler(this.NumericUpDownInt_ValueChanged);
            // 
            // numericUpDownCon
            // 
            this.numericUpDownCon.Location = new System.Drawing.Point(158, 189);
            this.numericUpDownCon.Name = "numericUpDownCon";
            this.numericUpDownCon.Size = new System.Drawing.Size(278, 27);
            this.numericUpDownCon.TabIndex = 7;
            this.numericUpDownCon.ValueChanged += new System.EventHandler(this.NumericUpDownCon_ValueChanged);
            // 
            // numericUpDownDex
            // 
            this.numericUpDownDex.Location = new System.Drawing.Point(158, 149);
            this.numericUpDownDex.Name = "numericUpDownDex";
            this.numericUpDownDex.Size = new System.Drawing.Size(278, 27);
            this.numericUpDownDex.TabIndex = 6;
            this.numericUpDownDex.ValueChanged += new System.EventHandler(this.NumericUpDownDex_ValueChanged);
            // 
            // numericUpDownStr
            // 
            this.numericUpDownStr.Location = new System.Drawing.Point(158, 108);
            this.numericUpDownStr.Name = "numericUpDownStr";
            this.numericUpDownStr.Size = new System.Drawing.Size(278, 27);
            this.numericUpDownStr.TabIndex = 5;
            this.numericUpDownStr.ValueChanged += new System.EventHandler(this.NumericUpDownStr_ValueChanged);
            // 
            // intelligenceLbl
            // 
            this.intelligenceLbl.AutoSize = true;
            this.intelligenceLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.intelligenceLbl.Location = new System.Drawing.Point(21, 229);
            this.intelligenceLbl.Name = "intelligenceLbl";
            this.intelligenceLbl.Size = new System.Drawing.Size(98, 23);
            this.intelligenceLbl.TabIndex = 4;
            this.intelligenceLbl.Text = "Intelligence";
            // 
            // constitutionLbl
            // 
            this.constitutionLbl.AutoSize = true;
            this.constitutionLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.constitutionLbl.Location = new System.Drawing.Point(21, 189);
            this.constitutionLbl.Name = "constitutionLbl";
            this.constitutionLbl.Size = new System.Drawing.Size(104, 23);
            this.constitutionLbl.TabIndex = 3;
            this.constitutionLbl.Text = "Constitution";
            // 
            // dexterityLbl
            // 
            this.dexterityLbl.AutoSize = true;
            this.dexterityLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dexterityLbl.Location = new System.Drawing.Point(21, 149);
            this.dexterityLbl.Name = "dexterityLbl";
            this.dexterityLbl.Size = new System.Drawing.Size(78, 23);
            this.dexterityLbl.TabIndex = 2;
            this.dexterityLbl.Text = "Dexterity";
            // 
            // strengthLbl
            // 
            this.strengthLbl.AutoSize = true;
            this.strengthLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.strengthLbl.Location = new System.Drawing.Point(21, 108);
            this.strengthLbl.Name = "strengthLbl";
            this.strengthLbl.Size = new System.Drawing.Size(75, 23);
            this.strengthLbl.TabIndex = 1;
            this.strengthLbl.Text = "Strength";
            // 
            // listBoxMain
            // 
            this.listBoxMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.ItemHeight = 20;
            this.listBoxMain.Items.AddRange(new object[] {
            "Warrior",
            "Rogue",
            "Wizard"});
            this.listBoxMain.Location = new System.Drawing.Point(0, 0);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(815, 64);
            this.listBoxMain.TabIndex = 0;
            this.listBoxMain.SelectedIndexChanged += new System.EventHandler(this.ListBoxMain_SelectedIndexChanged);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.thirdComboBox);
            this.panelMain.Controls.Add(this.thirdItemLbl);
            this.panelMain.Controls.Add(this.secondComboBox);
            this.panelMain.Controls.Add(this.inventoryLbl);
            this.panelMain.Controls.Add(this.firstComboBox);
            this.panelMain.Controls.Add(this.secondItemLbl);
            this.panelMain.Controls.Add(this.firstItemLbl);
            this.panelMain.Location = new System.Drawing.Point(442, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(370, 182);
            this.panelMain.TabIndex = 29;
            // 
            // thirdComboBox
            // 
            this.thirdComboBox.FormattingEnabled = true;
            this.thirdComboBox.Items.AddRange(new object[] {
            "Bow",
            "Axe",
            "Sword"});
            this.thirdComboBox.Location = new System.Drawing.Point(172, 118);
            this.thirdComboBox.Name = "thirdComboBox";
            this.thirdComboBox.Size = new System.Drawing.Size(191, 28);
            this.thirdComboBox.TabIndex = 25;
            this.thirdComboBox.SelectedIndexChanged += new System.EventHandler(this.ThirdComboBox_SelectedIndexChanged);
            // 
            // thirdItemLbl
            // 
            this.thirdItemLbl.AutoSize = true;
            this.thirdItemLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.thirdItemLbl.Location = new System.Drawing.Point(23, 122);
            this.thirdItemLbl.Name = "thirdItemLbl";
            this.thirdItemLbl.Size = new System.Drawing.Size(93, 25);
            this.thirdItemLbl.TabIndex = 28;
            this.thirdItemLbl.Text = "Third Item";
            // 
            // secondComboBox
            // 
            this.secondComboBox.FormattingEnabled = true;
            this.secondComboBox.Items.AddRange(new object[] {
            "Bow",
            "Axe",
            "Sword"});
            this.secondComboBox.Location = new System.Drawing.Point(172, 80);
            this.secondComboBox.Name = "secondComboBox";
            this.secondComboBox.Size = new System.Drawing.Size(191, 28);
            this.secondComboBox.TabIndex = 24;
            this.secondComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondComboBox_SelectedIndexChanged);
            // 
            // inventoryLbl
            // 
            this.inventoryLbl.AutoSize = true;
            this.inventoryLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inventoryLbl.Location = new System.Drawing.Point(22, 1);
            this.inventoryLbl.Name = "inventoryLbl";
            this.inventoryLbl.Size = new System.Drawing.Size(87, 25);
            this.inventoryLbl.TabIndex = 22;
            this.inventoryLbl.Text = "Inventory";
            // 
            // firstComboBox
            // 
            this.firstComboBox.FormattingEnabled = true;
            this.firstComboBox.Items.AddRange(new object[] {
            "Bow",
            "Axe",
            "Sword"});
            this.firstComboBox.Location = new System.Drawing.Point(172, 37);
            this.firstComboBox.Name = "firstComboBox";
            this.firstComboBox.Size = new System.Drawing.Size(191, 28);
            this.firstComboBox.TabIndex = 23;
            this.firstComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstComboBox_SelectedIndexChanged);
            // 
            // secondItemLbl
            // 
            this.secondItemLbl.AutoSize = true;
            this.secondItemLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secondItemLbl.Location = new System.Drawing.Point(22, 79);
            this.secondItemLbl.Name = "secondItemLbl";
            this.secondItemLbl.Size = new System.Drawing.Size(112, 25);
            this.secondItemLbl.TabIndex = 27;
            this.secondItemLbl.Text = "Second Item";
            // 
            // firstItemLbl
            // 
            this.firstItemLbl.AutoSize = true;
            this.firstItemLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstItemLbl.Location = new System.Drawing.Point(23, 40);
            this.firstItemLbl.Name = "firstItemLbl";
            this.firstItemLbl.Size = new System.Drawing.Size(86, 25);
            this.firstItemLbl.TabIndex = 26;
            this.firstItemLbl.Text = "First Item";
            // 
            // listBoxRes
            // 
            this.listBoxRes.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxRes.FormattingEnabled = true;
            this.listBoxRes.ItemHeight = 20;
            this.listBoxRes.Location = new System.Drawing.Point(0, 0);
            this.listBoxRes.Name = "listBoxRes";
            this.listBoxRes.Size = new System.Drawing.Size(328, 466);
            this.listBoxRes.TabIndex = 1;
            this.listBoxRes.SelectedValueChanged += new System.EventHandler(this.ListBoxRes_SelectedValueChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1147, 466);
            this.Controls.Add(this.mainPan);
            this.Controls.Add(this.listBoxRes);
            this.Name = "Main";
            this.Text = "Main";
            this.mainPan.ResumeLayout(false);
            this.mainPan.PerformLayout();
            this.secondPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStr)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel mainPan;
        private ListBox listBoxMain;
        private Label intelligenceLbl;
        private Label constitutionLbl;
        private Label dexterityLbl;
        private Label strengthLbl;
        private Label manaLbl;
        private NumericUpDown numericUpDownInt;
        private NumericUpDown numericUpDownCon;
        private NumericUpDown numericUpDownDex;
        private NumericUpDown numericUpDownStr;
        private Label attackLbl;
        private Label hpLbl;
        private Label pDefLbl;
        private TextBox textBoxAttackMana;
        private Label attackManaLbl;
        private TextBox textBoxPDef;
        private TextBox textBoxAttack;
        private TextBox textBoxHP;
        private TextBox textBoxMana;
        private Button okBtn;
        private ListBox listBoxRes;
        private TextBox textBoxName;
        private Label nameLbl;
        private Label firstItemLbl;
        private ComboBox thirdComboBox;
        private ComboBox secondComboBox;
        private ComboBox firstComboBox;
        private Label inventoryLbl;
        private Label thirdItemLbl;
        private Label secondItemLbl;
        private Panel panelMain;
        private Panel secondPanel;
        private ListBox listBoxItems;
    }
}