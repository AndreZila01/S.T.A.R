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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoC_
{
    public partial class Form1 : Form
    {
        public string Keybinds = ""; // variável que vai guardar as teclas pressionadas
        private Comunicacao _com_; // cria uma class que vai comunicar com o arduino
        public string dataArduino = ""; // variável que vai guardar os dados do arduino

        //public HashSet<Keys> teclasPressionadas = new HashSet<Keys>();

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.ActiveControl != null)
            {
                this.ActiveControl = null; // meter o foco no form
                this.ActiveControl = null; lblFlame.Text = Properties.Resources.StringFlameSensor; lblHumidade.Text = Properties.Resources.StringHumidity; lblTemp.Text = Properties.Resources.StringTemperature; lblUSonic.Text = Properties.Resources.StringUltraSonicSensor; lblSound.Text = Properties.Resources.StringSound; timer1.Start(); // meter os valores nas labels e começar o timer
            }
        }
        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            //var asasa = (new Keybinds());

            if (!bgwStart.IsBusy) // verifica se o backgroundworker está a correr
                bgwStart.RunWorkerAsync(); // inicia o backgroundworker, executando primeiro o DoWork e depois o DoWorkRunWorkerAsync 

            //    public int NumberPing
            //public float UltraSonic_sensor 
            //public int Flame_sensor 
            //public float Temperatura 
            //public float Humidade 
            //public int Sound_sensor 
            txtData.Text = "[{\"NumberPing\":1, \"UltraSonic_sensor\":0.5, \"Flame_sensor\":0, \"Temperatura\":0.2, \"Humidade\":0.7, \"Sound_sensor\":1},{\"NumberPing\":1, \"UltraSonic_sensor\":0.5, \"Flame_sensor\":0, \"Temperatura\":0.2, \"Humidade\":0.7, \"Sound_sensor\":1}]";
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _com_ = new Comunicacao(); // inicializar a class do arduino
            new Thread(() =>
            {
                try
                {
                    Keybinds = ""; // começar a keybinds a vazio
                    Console.WriteLine("Teste");
                    new Keybinds().Background_Keybinds(this); // iniciar a keybinds
                }
                catch
                {

                }
            }).Start();
            //new Keybinds().Background_Keybinds(this); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ActiveControl = null; // meter o foco no form
            if (Keybinds != txtInput.Text)
            {
                if (Keybinds != "PARAR") //Se o Keybinds não tiver "PARAR"
                    txtInput.Text = Keybinds.Replace("\n", Environment.NewLine); // remove os \n para Environment.NewLine
                txtInput.SelectionStart = txtInput.Text.Length; // mete a progressbar no ultimo caracter para o textbox ficar em baixo
                txtInput.ScrollToCaret();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            switch (((System.Windows.Forms.Button)sender).Name) // crias um objeto local que recebe a informação do sender que mete tudo como botão e pega o nome
            {
                case "btnClear": // se o botão tiver o nome de btnClear
                    txtInput.Text = ""; Keybinds = ""; //apaga o txtInput text e keybinds
                    break;
                case "btnCopy": // se o botão tiver o nome de btnCopy
                    System.Windows.Forms.Clipboard.SetText(Keybinds); // copia toda a informação da keybinds para o sistema de Ctrl+V do Windows
                    break;
                case "btnInput": // se o botão tiver o nome de btnInput
                    if (btnInput.Text.Contains("ON")) // se tiver "On" entra
                    {
                        btnInput.Text = "Input OFF"; // mete o button como OFF
                        Keybinds = "PARAR"; // e keybinds fica PARAR, para parar a leitura de inputs do cliente
                    }
                    else
                    {
                        btnInput.Text = "Input ON"; // mete o button como ON

                        if (!bgwStart.IsBusy)
                            bgwStart.RunWorkerAsync(); // inicia o background de novo
                    }
                    break;
                case "btnOnArd": // se o botão tiver o nome de btnOnArd
                    string ipv4 = "Escreva o IP do MQTT Broadcaster:";
                    while (true)
                    {
                        ipv4 = (Interaction.InputBox(ipv4, "Ip do MQTT Broadcaster")).Replace(" ", ""); // cria uma caixazinha para o cliente escrever o IP do Arduino
                        if (ipv4 == "" || ipv4 == "\r\n" || ipv4 == "\n") // se for vazio ou \r\n ou \n
                            break;


                        if (IPAddress.TryParse(ipv4, out IPAddress address)) // certifica se o string ipv4 tem um ip compativel com base na library do IPAdress. Tenta converter seguindo a regra do address. Aqui irá retornar true or false
                        {
                            string path = (Interaction.InputBox(ipv4, "Ip MQTT Broadcaster")).Replace(" ", ""); // cria uma caixinha para o cliente escrever o Topic do MQTT Broadcaster

                            _com_.StartMQQT(ipv4.ToString(), path, this); // entra na função para ligares-te ao MQTT Broadcaster
                            this.Tag = path; // o topic vai ficar guardado na Tag do Form.

                            while (pctIPV4.Tag.ToString() == "0") // enquanto o pctIPV4.Tag.ToString() for 0 ele fica aqui. Ele só irá atualizar, quando o Arduino entregar a string "Greenlight" ao MQTT Broadcaster
                                Thread.Sleep(200);

                            btnOnArd.Enabled = false; // desativa o botão de Ligar ao Arduino
                            btnOffArd.Enabled = true; // liga o botão de desligar ao Arduino
                            break; // e sai deste ciclo!
                        }
                        else
                            ipv4 = "O ip não é valido, escreva again!"; // atualiza a mensagem do Interaction.InputBox
                    }
                    break;
                case "btnIA": // se o botão tiver o nome de btnIA
                    // um W é 30 cm 
                    break;
                case "btnExport": // se o botão tiver o nome de btnExport
                    new ExpImpData().ExcelData(txtData.Text.ToString()); // criamos uma ligação a class ExpImpData e exportamos os dados do txtData.Text para Excel.
                    break;
                case "btnClearData": // se o botão tiver o nome de btnClearData
                    lblFlame.Text = Properties.Resources.StringFlameSensor; lblHumidade.Text = Properties.Resources.StringHumidity; lblTemp.Text = Properties.Resources.StringTemperature; lblUSonic.Text = Properties.Resources.StringUltraSonicSensor; lblSound.Text = Properties.Resources.StringSound; txtData.Text = "";
                    //Apagar a informação da DashBoard
                    break;
                case "btnOffArd": // se o botão tiver o nome de btnOffArd
                    btnOnArd.Enabled = true; // ativa o botão de ligar ao arduino
                    btnOffArd.Enabled = false; // desliga o botão de desligar ao arduino
                    _com_.StopMQQT(this.Tag.ToString());
                    break;
                case "btnImport": // se o botão tiver o nome de btnImport
                    OpenFileDialog ofds = new OpenFileDialog(); // criamos um objeto chamado OpenFileDialog, para o cliente selecionar algum ficheiro
                    ofds.Filter = "Excel Files (*.xlsx)|*.xlsx|JSON Files (*.json)|*.json|Text Files (*.txt)|*.txt|Data Files (*.dat)|*.dat"; // aqui limitamos que seja só ficheiros do formato *.xslx, *.json, *.txt, *.dat
                    ofds.Multiselect = false; // e não poderá selecionar varios tipos de ficheiros
                    if ((ofds.ShowDialog() == DialogResult.OK) && (ofds.SafeFileName.Contains(".xlsx") || ofds.SafeFileName.Contains(".json") || ofds.SafeFileName.Contains(".txt") || ofds.SafeFileName.Contains(".dat"))) // se for tudo conforme acima e tiver selecionado um ficheiro com os formatos indicados acima! Prosegue se não, gameOver
                    {
                        string data = "";
                        txtData.Text = "";
                        //TODO: Testar caso o Sabino pense em criar um ficheiro pelo meio xlsx!

                        if (ofds.SafeFileName.Contains(".xlsx")) // se o ficheiro chamar-se .xlsx
                            data = new ExpImpData().ImportData(ofds.FileName, 0); // chamamos a classe ExpImpData e dizemos que é excel e o caminho é este!
                        else if (ofds.SafeFileName.Contains(".json"))// se o ficheiro chamar-se .json
                            data = new ExpImpData().ImportData(ofds.FileName, 1);// chamamos a classe ExpImpData e dizemos que é json e o caminho é este!
                        else if (ofds.SafeFileName.Contains(".txt"))// se o ficheiro chamar-se .txt
                            data = new ExpImpData().ImportData(ofds.FileName, 2);// chamamos a classe ExpImpData e dizemos que é txt e o caminho é este!
                        else if (ofds.SafeFileName.Contains(".dat"))// se o ficheiro chamar-se .dat
                            data = new ExpImpData().ImportData(ofds.FileName, 3);// chamamos a classe ExpImpData e dizemos que é protobuf e o caminho é este!
                        
                        if (data != "")
                            txtData.Text = data; // caso o texto dos ficheiros for como queremos enviamos para o TxtData.Text
                    }
                    else
                    {
                        //MessageBox.Show("", "");
                    }
                    break;
                case "btnForm": // se o botão tiver o nome de btnCopy
                    new frmData(this).Show(); // mostrar o frmData! E enviar o Form1
                    break;
                case "test":
                    var asasas = Path.GetTempPath(); //localtemp %temp%
                    var asa = Environment.CurrentDirectory; //localpath
                    var asas = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //%appdata%
                    (new Comunicacao()).CollectDataMQQT("", "TESTO");
                    _com_.CollectDataMQQT("/test/", "WAIT");
                    break;
            }
        }

        private void btnExport_MouseHover(object sender, EventArgs e)
        {
            Point ptLowerLeft = new Point(0, btnExport.Height); // saber as posições com base no btnExport.Height
            ptLowerLeft = btnExport.PointToScreen(ptLowerLeft); // ?
            cmsData.Show(ptLowerLeft.X, ptLowerLeft.Y); // mostrar a csmData (que é a ContextMenuStrip) nas posições indicadas
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Keybinds = "PARAR"; //para parar a thread das keybinds
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (((System.Windows.Forms.ToolStripMenuItem)sender).Tag) // Crias um ToolStripMMenuItem local e envias os dados para o sender e pegas no Tag
            {
                case "0": // se o tag for 0, entras
                    new ExpImpData().ProtobufData(txtData.Text.ToString()); // Crias localmente a class ExpImpData da função ProtobufData e envias os dados da txtData.Text para exportar! 
                    //Protobuf
                    break;
                case "1":  // se o tag for 1, entras
                    new ExpImpData().JSONData(txtData.Text.ToString()); // Crias localmente a class ExpImpData da função JSONData e envias os dados da txtData.Text para exportar!
                    //JSON
                    break;
                case "2":  // se o tag for 2, entras
                    new ExpImpData().ExcelData(txtData.Text.ToString()); // Crias localmente a class ExpImpData da função ExcelData e envias os dados da txtData.Text para exportar!
                    //Excel
                    break;
                case "3":  // se o tag for 3, entras
                    new ExpImpData().TXTData(txtData.Text.ToString()); // Crias localmente a class ExpImpData da função TXTData e envias os dados da txtData.Text para exportar!
                    //Txt
                    break;
                default: // caso contrario entras aqui!
                    //Erro ou bug
                    break;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = "Acceleration: " + trackBar1.Value; // Cada vez que atualizas a trackBar, ele atualiza o valor da label5.text 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string texto = (Interaction.InputBox("", "Texto")).Replace(" ", ""); // teste!
            _com_.CollectDataMQQT("/test/", texto);
        }

        public void ChangeMovement_Arduino(string keybind)
        {
            _com_.CollectDataMQQT("/test/", keybind);
        }

        /*
         TODO:
        Fazer um menustrip para o NotifyIcon para:
        -> mudar caminho do ficheiro
        -> close program
        -> Import Data
        -> ...


         */
    }
}
