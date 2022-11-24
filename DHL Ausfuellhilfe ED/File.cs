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
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace DHL_Ausfuellhilfe_ED
{
    public abstract class File
    {
        protected byte[] header = { 0xFF, 0xFF, 0x01, 0x00, 0x10, 0x00, 0x43 };
        protected byte[] seperator = { 0x01, 0x80 };
        protected String kennung = "";

        protected Encoding _enc = Encoding.GetEncoding(1252);

        public Encoding encoding {
            get { return _enc; }
        }


        private bool checkHeader(ref BinaryReader br)
        {
            Debug.WriteLine("Checke Header");

            //System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            //byte[] kng = enc.GetBytes(kennung);
            byte[] kng = _enc.GetBytes(kennung);
            byte soll, ist;

            try
            {
                for (int i = 0; i < header.Length; i++)
                {
                    soll = header[i];
                    ist = br.ReadByte();
                    Debug.WriteLine("ist = " + ist + " - soll = " + soll);
                    if (soll != ist)
                        return false;
                }
                for (int i = 0; i < kng.Length; i++)
                {
                    soll = kng[i];
                    ist = br.ReadByte();
                    Debug.WriteLine("ist = " + ist + " - soll = " + soll);

                    if (soll != ist)
                        return false;
                }
            }
            catch (EndOfStreamException e)
            {
                Debug.WriteLine("Exception beim Header-prüfen:");
                Debug.WriteLine(e.Message);
                return false;
            }
            Debug.WriteLine("Header check erfolgreich!");
            return true;
        }
        private bool writeHeader(ref BinaryWriter bw)
        {
            bw.Seek(0, SeekOrigin.Begin);
            bw.Write(header);

            //System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            //byte[] kng = enc.GetBytes(kennung);
            byte[] kng = _enc.GetBytes(kennung);

            bw.Write(kng);

            return true;
        }
        public virtual bool readFile(String path)
        {
            FileStream fs;
            BinaryReader br;

            try
            {
                fs = new FileStream(path, FileMode.Open);
            } catch ( IOException e){
                MessageBox.Show(e.Message);
                return false;
            }

            br = new BinaryReader(fs, _enc);

            if (checkHeader(ref br))
            {
                Debug.WriteLine("lese Daten...");
                readData(ref br);
                br.Close();
                return true;
            }
            br.Close();
            return false;
        }
        public virtual bool writeFile(String path)
        {
            FileStream fs;
            BinaryWriter bw;

            try
            {
                System.IO.File.Move(@path, @path + ".bak");

                fs = new FileStream(path, FileMode.Create);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            bw = new BinaryWriter(fs, _enc);

            writeHeader(ref bw);

            writeData(ref bw);

            bw.Close();
            return true;
        }
        public abstract void readData(ref BinaryReader br);
        public abstract bool writeData(ref BinaryWriter bw);
    }
}
