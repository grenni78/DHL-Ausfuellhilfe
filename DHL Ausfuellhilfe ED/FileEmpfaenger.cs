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
using System.ComponentModel;
using System.Diagnostics;

namespace DHL_Ausfuellhilfe_ED
{
    class FileEmpfaenger: File
    {

        private byte[] gap = { 0x00, 0x00, 0x01, 0x80 };

        public FileEmpfaenger()
        {
            kennung = "Empfaengerdaten";
        }
        public class empfaenger
        {
            public String[] data = new String[6] ;
            public enum fieldName: int { Firma, Name, Zusatz, Strasse, PLZ, Ort};

            public empfaenger()
            {
                clear();
            }
            public void clear()
            {
                for (int i = 0; i < data.Length; i++ )
                    this.data[i] = "";
            }
            public String Firma { 
                get
                {
                    return data[(int)fieldName.Firma];
                }
                set
                {
                    data[(int)fieldName.Firma] = value;
                }
            }
            public String Name
            {
                get
                {
                    return data[(int)fieldName.Name];
                }
                set
                {
                    data[(int)fieldName.Name] = value;
                }
            }
            public String Zusatz
            {
                get
                {
                    return data[(int)fieldName.Zusatz];
                }
                set
                {
                    data[(int)fieldName.Zusatz] = value;
                }
            }
            public String Strasse
            {
                get
                {
                    return data[(int)fieldName.Strasse];
                }
                set
                {
                    data[(int)fieldName.Strasse] = value;
                }
            }
            public String PLZ
            {
                get
                {
                    return data[(int)fieldName.PLZ];
                }
                set
                {
                    data[(int)fieldName.PLZ] = value;
                }
            }
            public String Ort
            {
                get
                {
                    return data[(int)fieldName.Ort];
                }
                set
                {
                    data[(int)fieldName.Ort] = value;
                }
            }

            public override String ToString()
            {
                String o;
                o = "Firma: " + this.Firma;
                o += "\nName: " + this.Name;
                o += "\nZusatz: " + this.Zusatz;
                o += "\nStrasse: " + this.Strasse;
                o += "\nPLZ: " + this.PLZ;
                o += "\nOrt: " + this.Ort;
                return o;
            }
        }

        public BindingList<empfaenger> empfaengerList;

        public override void readData(ref BinaryReader br)
        {
            int current = 0;
            // Anzahl der Elemente in der empfaenger-Klasse
            int max = 4;
            byte[] gap = new byte[2];
            byte c;

            empfaengerList = new BindingList<empfaenger>();
            empfaengerList.AllowNew = true;
            empfaengerList.AllowRemove = true;
            empfaengerList.RaiseListChangedEvents = true;
            empfaengerList.AllowEdit = true;

            empfaenger e = new empfaenger();

            Debug.WriteLine("Starte das Lesen...");


            try
            {
                while (true)
                {
                    c = br.ReadByte();

                    switch (c)
                    {
                        case 0x00:
                            Debug.WriteLine(" -> Auslassung...");
                            current++;
                            break;
                        case 0x01:
                            if (br.ReadByte() == 0x80)
                            {
                                // neuer Datensatz
                                Debug.WriteLine("neuer Datensatz "+e.ToString());

                                empfaengerList.Add(e);
                                e = new empfaenger();

                                current = 0;
                            }
                            else
                            {
                                br.BaseStream.Seek(-1, SeekOrigin.Current);
                            }
                            break;
                        default:
                            // Zeichenkette
                            br.BaseStream.Seek(-1, SeekOrigin.Current);
                            e.data[current] += br.ReadString();
                            Debug.WriteLine("String gefunden: " + e.data[current]);
                            current++;
                            break;

                    }
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("fehler beim Einlesen eines Datensatzes:");
                Debug.WriteLine(ex.Message);

                if (ex.GetType()==typeof(EndOfStreamException) )
                    empfaengerList.Add(e);

                return;
            }
        }
        public override bool writeData(ref BinaryWriter bw)
        {
            try
            {
                foreach (empfaenger e in empfaengerList)
                {
                    foreach (String s in e.data)
                    {
                        //s.Trim();
                        byte[] len = { (byte)s.Length };
                        byte[] arr_utf8 = Encoding.UTF8.GetBytes(s.ToCharArray());
                        byte[] arr_ansi = Encoding.Convert(Encoding.UTF8, this._enc, arr_utf8);
                        Debug.Write(len);
                        Debug.Write(arr_ansi);
                        
                        if (len[0] > 0)
                        {
                            len[0]--;
                            bw.BaseStream.Write(len, 0, 1);
                            bw.BaseStream.Write(arr_ansi, 1, len[0]);
                        } else
                            bw.BaseStream.Write(len, 0, 1);
                        //bw.Write(len);
                        //bw.Write(arr);
                    }
                    bw.BaseStream.Write(gap,0,gap.Length);
                }
                
                bw.BaseStream.Seek(-2, SeekOrigin.End);
                bw.BaseStream.SetLength(bw.BaseStream.Position);
                return true;
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Fehler beim Speichern der Datenbank: " + e.Message);
                return false;
            }
        }
        public override bool readFile(String path)
        {
            path += @"\empfaenger.dat";
            return base.readFile(path);
        }
        public override bool writeFile(String path)
        {
            path += @"\empfaenger.dat";
            return base.writeFile(path);
        }
    }
}
