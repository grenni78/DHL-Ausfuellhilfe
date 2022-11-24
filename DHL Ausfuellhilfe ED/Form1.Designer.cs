namespace DHL_Ausfuellhilfe_ED
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ModusGrp = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.showPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.empfaengerCheck = new System.Windows.Forms.RadioButton();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.Items = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputFirma = new System.Windows.Forms.TextBox();
            this.inputName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputZusatz = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inputStrasse = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.inputPLZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inputOrt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonSaveDatabase = new System.Windows.Forms.Button();
            this.exportCSVButton = new System.Windows.Forms.Button();
            this.saveCSVDialog = new System.Windows.Forms.SaveFileDialog();
            this.ModusGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModusGrp
            // 
            this.ModusGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModusGrp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ModusGrp.Controls.Add(this.button1);
            this.ModusGrp.Controls.Add(this.showPath);
            this.ModusGrp.Controls.Add(this.label1);
            this.ModusGrp.Controls.Add(this.radioButton1);
            this.ModusGrp.Controls.Add(this.empfaengerCheck);
            this.ModusGrp.Location = new System.Drawing.Point(12, 9);
            this.ModusGrp.MinimumSize = new System.Drawing.Size(474, 0);
            this.ModusGrp.Name = "ModusGrp";
            this.ModusGrp.Size = new System.Drawing.Size(476, 65);
            this.ModusGrp.TabIndex = 0;
            this.ModusGrp.TabStop = false;
            this.ModusGrp.Text = "Einstellungen";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(395, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "suchen...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // showPath
            // 
            this.showPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showPath.Enabled = false;
            this.showPath.Location = new System.Drawing.Point(269, 25);
            this.showPath.MinimumSize = new System.Drawing.Size(120, 4);
            this.showPath.Name = "showPath";
            this.showPath.Size = new System.Drawing.Size(120, 20);
            this.showPath.TabIndex = 3;
            this.showPath.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Verzeichnis:";
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(86, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 23);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Absender";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // empfaengerCheck
            // 
            this.empfaengerCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.empfaengerCheck.AutoSize = true;
            this.empfaengerCheck.Checked = true;
            this.empfaengerCheck.Location = new System.Drawing.Point(12, 23);
            this.empfaengerCheck.Name = "empfaengerCheck";
            this.empfaengerCheck.Size = new System.Drawing.Size(68, 23);
            this.empfaengerCheck.TabIndex = 0;
            this.empfaengerCheck.TabStop = true;
            this.empfaengerCheck.Text = "Empfänger";
            this.empfaengerCheck.UseVisualStyleBackColor = true;
            // 
            // folderBrowser
            // 
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // Items
            // 
            this.Items.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Items.FormattingEnabled = true;
            this.Items.Location = new System.Drawing.Point(12, 80);
            this.Items.Name = "Items";
            this.Items.Size = new System.Drawing.Size(177, 368);
            this.Items.TabIndex = 1;
            this.Items.SelectedIndexChanged += new System.EventHandler(this.Items_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Firma";
            // 
            // inputFirma
            // 
            this.inputFirma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFirma.Location = new System.Drawing.Point(241, 90);
            this.inputFirma.Name = "inputFirma";
            this.inputFirma.Size = new System.Drawing.Size(247, 20);
            this.inputFirma.TabIndex = 3;
            // 
            // inputName
            // 
            this.inputName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputName.Location = new System.Drawing.Point(241, 116);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(247, 20);
            this.inputName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // inputZusatz
            // 
            this.inputZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputZusatz.Location = new System.Drawing.Point(241, 142);
            this.inputZusatz.Name = "inputZusatz";
            this.inputZusatz.Size = new System.Drawing.Size(247, 20);
            this.inputZusatz.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Zusatz";
            // 
            // inputStrasse
            // 
            this.inputStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputStrasse.Location = new System.Drawing.Point(241, 168);
            this.inputStrasse.Name = "inputStrasse";
            this.inputStrasse.Size = new System.Drawing.Size(247, 20);
            this.inputStrasse.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Straße";
            // 
            // inputPLZ
            // 
            this.inputPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputPLZ.Location = new System.Drawing.Point(241, 194);
            this.inputPLZ.Name = "inputPLZ";
            this.inputPLZ.Size = new System.Drawing.Size(90, 20);
            this.inputPLZ.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "PLZ.";
            // 
            // inputOrt
            // 
            this.inputOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputOrt.Location = new System.Drawing.Point(241, 220);
            this.inputOrt.Name = "inputOrt";
            this.inputOrt.Size = new System.Drawing.Size(247, 20);
            this.inputOrt.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ort";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(206, 278);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "löschen";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(375, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Datensatz speichern";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSaveDatabase
            // 
            this.buttonSaveDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveDatabase.Location = new System.Drawing.Point(345, 478);
            this.buttonSaveDatabase.Name = "buttonSaveDatabase";
            this.buttonSaveDatabase.Size = new System.Drawing.Size(143, 31);
            this.buttonSaveDatabase.TabIndex = 13;
            this.buttonSaveDatabase.Text = "Datenbank speichern";
            this.buttonSaveDatabase.UseVisualStyleBackColor = true;
            this.buttonSaveDatabase.Click += new System.EventHandler(this.buttonSaveDatabase_Click);
            // 
            // exportCSVButton
            // 
            this.exportCSVButton.Location = new System.Drawing.Point(13, 455);
            this.exportCSVButton.Name = "exportCSVButton";
            this.exportCSVButton.Size = new System.Drawing.Size(176, 23);
            this.exportCSVButton.TabIndex = 14;
            this.exportCSVButton.Text = "Daten als CSV exportieren";
            this.exportCSVButton.UseVisualStyleBackColor = true;
            this.exportCSVButton.Click += new System.EventHandler(this.exportCSVButton_Click);
            // 
            // saveCSVDialog
            // 
            this.saveCSVDialog.DefaultExt = "csv";
            this.saveCSVDialog.Filter = "CSV Dateien|*.csv";
            this.saveCSVDialog.RestoreDirectory = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(498, 521);
            this.Controls.Add(this.exportCSVButton);
            this.Controls.Add(this.buttonSaveDatabase);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.inputOrt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.inputPLZ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inputStrasse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.inputZusatz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputFirma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Items);
            this.Controls.Add(this.ModusGrp);
            this.Name = "Form1";
            this.Text = "DHL Ausfüllhilfe ED";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ModusGrp.ResumeLayout(false);
            this.ModusGrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ModusGrp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox showPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton empfaengerCheck;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.ListBox Items;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputFirma;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputZusatz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputStrasse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox inputPLZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputOrt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonSaveDatabase;
        private System.Windows.Forms.Button exportCSVButton;
        private System.Windows.Forms.SaveFileDialog saveCSVDialog;
    }
}

