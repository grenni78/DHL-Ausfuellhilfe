/**
 * Copyright (c) 2016, Holger Genth (https://holger-genth.de)
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, this list
 *    of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list
 *    of conditions and the following disclaimer in the documentation and/or other
 *    materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
 * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL
 * THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT
 * OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR
 * TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFT-
 * WARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace DHL_Ausfuellhilfe_ED
{
    public partial class Form1 : Form
    {
        private FileEmpfaenger fe;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String path = "";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {

                path = folderBrowser.SelectedPath;
                showPath.Text = path;

                if (empfaengerCheck.Checked)
                {
                    fe.readFile(path);
                    Items.DataSource = fe.empfaengerList;
                    Items.DisplayMember = "Firma";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Starte...");
            fe = new FileEmpfaenger();
        }

        private void displayData(int index)
        {
            FileEmpfaenger.empfaenger empf;
            try {
                empf = fe.empfaengerList[index];
            } catch (Exception) {
                return;
            }

            inputFirma.Text = empf.Firma;
            inputName.Text = empf.Name;
            inputZusatz.Text = empf.Zusatz;
            inputStrasse.Text = empf.Strasse;
            inputPLZ.Text = empf.PLZ;
            inputOrt.Text = empf.Ort;
        }
        private void saveData(int index)
        {
            FileEmpfaenger.empfaenger empf;
            try {
                empf = fe.empfaengerList[index];
            } catch (Exception) {
                return;
            }
            empf.Firma = inputFirma.Text;
            empf.Name = inputName.Text;
            empf.Zusatz = inputZusatz.Text;
            empf.Strasse = inputStrasse.Text;
            empf.PLZ = inputPLZ.Text;
            empf.Ort = inputOrt.Text;

            // private Methode RefreshItems der Listbox aufrufen
            typeof(ListBox).InvokeMember("RefreshItems", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod, null, Items, new object[] { });

            MessageBox.Show("Datensatz gespeichert", "erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sel = Items.SelectedIndex;
            displayData(sel);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int sel = Items.SelectedIndex;

            if (sel < 0) return;

            if (MessageBox.Show("Der aktuelle Datensatz wird gelöscht!", "Datensatz löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //Datensatz löschen

                fe.empfaengerList.RemoveAt(sel);
                Items.SelectedIndex = (sel==0) ? sel + 1 : sel - 1;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sel = Items.SelectedIndex;
            if (sel < 0) return;
            saveData(sel);
        }

        private void buttonSaveDatabase_Click(object sender, EventArgs e)
        {
            int sel = Items.SelectedIndex;
            if (sel < 0) return;

            if (MessageBox.Show("Der aktuelle Bearbeitungsstand wird gespeichert.\nDie alte Datenbank wird als empfaenger.dat.bak gesichert.", "Datenbank speichern", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fe.writeFile(showPath.Text);
            }
        }

        private void exportCSVButton_Click(object sender, EventArgs e)
        {
            if (saveCSVDialog.ShowDialog() == DialogResult.OK)
            {
                String fn       = saveCSVDialog.FileName;
                String delim    = Properties.Settings.Default.CSVDelimiter;
             
                bool dispHeader = Properties.Settings.Default.CSVFieldNamesInFirstLine;

                StreamWriter sw = new StreamWriter(fn, false, fe.encoding);

                
                //sw.NewLine = @"\r\n";
                Debug.Write("CR is:");Debug.WriteLine(@Properties.Settings.Default.CSVEndLine);

                if (dispHeader)
                {
                    sw.WriteLine("Name 1" + delim + "Name 2" + delim + "Name 3" + delim + "Straße und Hausnummer" + delim + "PLZ" + delim + "Ort");
                }

                for (int idx = 0; idx < fe.empfaengerList.Count; idx++)
                {

                    FileEmpfaenger.empfaenger empf = fe.empfaengerList[idx];

                    sw.WriteLine(empf.Firma + delim + empf.Name + delim + empf.Zusatz + delim + empf.Strasse + delim + empf.PLZ + delim + empf.Ort);

                }

                sw.Close();

            }
        }
    }
}
