using Microsoft.VisualBasic;
using ProjetoC_.Cerebro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static ProjetoC_.Cerebro.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoC_
{
    public partial class Form1 : Form
    {
        public string Keybinds = "";
        private Comunicacao _com_;
        //public HashSet<Keys> teclasPressionadas = new HashSet<Keys>();


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) { this.ActiveControl = null; }
        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            timer1.Start();
            var asasa = (new Keybinds());
            _com_ = new Comunicacao();

            new Thread(() =>
            {
                try
                {
                    Console.WriteLine("Teste");
                    new Keybinds().Background_Keybinds(this);
                }
                catch
                {

                }
            }).Start();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            new Keybinds().Background_Keybinds(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (Keybinds != txtInput.Text)
            {
                txtInput.Text = Keybinds.Replace("\n", Environment.NewLine);
                txtInput.SelectionStart = txtInput.Text.Length;
                txtInput.ScrollToCaret();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (((System.Windows.Forms.Button)sender).Name)
            {
                case "btnClear":
                    txtInput.Text = ""; Keybinds = "";
                    break;
                case "btnCopy":
                    System.Windows.Forms.Clipboard.SetText(Keybinds);
                    break;
                case "btnInput":
                    if (txtInput.Text.Contains("ON"))
                        btnInput.Text = "Input ON";
                    else
                        btnInput.Text = "Input OFF";
                    break;
                case "btnOnArd":
                    string ipv4 = "Escreva o IP do arduino:";
                    while (true)
                    {
                        ipv4 = (Interaction.InputBox(ipv4, "Ip Arduino")).Replace(" ", "");
                        if (ipv4 == "")
                            break;

                        if (IPAddress.TryParse(ipv4, out IPAddress address))
                        {
                            string path = (Interaction.InputBox(ipv4, "Ip Arduino")).Replace(" ", "");
                            //TODO: Perguntar ao Nathan as regras de Topic! Como por exemplo não ter no inicio /, etc...
                            _com_.StartMQQT(ipv4.ToString(), path, this);
                            this.Tag = path;
                            //_com_.StartMQQT(path, "Connection");
                            while (pctIPV4.Tag.ToString() == "0")
                                Thread.Sleep(200);
                            btnOnArd.Enabled = false;
                            btnOffArd.Enabled = true;
                        }
                        else
                            ipv4 = "O ip não é valido, escreva again!";
                    }
                    break;
                case "btnExport":
                    new ExportData().ExcelData(txtData.Text.ToString());
                    break;
                case "btnClearData":
                    //Apagar a informação
                    break;
                case "btnOffArd":
                    _com_.StopMQQT(this.Tag.ToString());
                    break;
                case "test":
                    var asasas = Path.GetTempPath(); //localtemp %temp%
                    var asa = Environment.CurrentDirectory; //localpath
                    var asas = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //%appdata%
                    (new Comunicacao()).CollectDataMQQT("", "TESTO");
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void btnExport_MouseHover(object sender, EventArgs e)
        {
            Point ptLowerLeft = new Point(0, btnExport.Height);
            ptLowerLeft = btnExport.PointToScreen(ptLowerLeft);
            cmsData.Show(ptLowerLeft.X, ptLowerLeft.Y);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Keybinds = "PARAR"; //para parar a thread das keybinds
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (((System.Windows.Forms.ToolStripMenuItem)sender).Tag)
            {
                case 0:
                    new ExportData().ProtobufData(txtData.Text.ToString());
                    //Protobuf
                    break;
                case 1:
                    new ExportData().JSONData(txtData.Text.ToString());
                    //JSON
                    break;
                case 2:
                    new ExportData().ExcelData(txtData.Text.ToString());
                    //Excel
                    break;
                case 3:
                    new ExportData().TXTData(txtData.Text.ToString());
                    //Txt
                    break;
                default:
                    //Erro ou bug
                    break;
            }
        }

        /*
         TODO:
        Fazer um menustrip para o NotifyIcon para:
        -> mudar caminho do ficheiro
        -> close program
        -> ...
         */
    }
}
