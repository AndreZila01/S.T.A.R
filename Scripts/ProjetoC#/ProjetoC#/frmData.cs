﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoC_
{
    public partial class frmData : Form
    {
        Timer tmr = new Timer();
        Form1 frm;
        public frmData(Form1 frm)
        {
            InitializeComponent();
            this.frm = frm; // envias o frm para this.frm. Este frm, é o valor enviado quando chamos o new frmData(this).Show()
        }

        private void frmData_Load(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear(); // apaga tudo o que tiver dentro do pnlPrincipal
            tmr.Interval = 1000; // cria um intervalo de 1 segundo
            tmr.Tick += Tmr_Tick; // cria um evento chamado Tick, cada vez que passa 1 seg
            tmr.Start(); // e começa
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            //frm.Tag = ""; PEGAR VALOR EM frm.Tag!
            string[] data = frm.txtData.Tag.ToString().Split(new string[] { "_" }, StringSplitOptions.None);
            if (data.Length > 1)
            {
                //"{\"NumberPing\":\"" + values[1] + ",\"UltraSonic_sensor\":\"" + values[3] + ",\"Flame_sensor\":\"" + values[5] + ",\"Temperatura\":\"" + values[7] + ",\"Humidade\":\"" + values[9] + ",\"Sound_sensor\":\"" + values[11] + "},";
                //"{\"UltraSonic_sensor\":" + values[1].Replace(" S", "") + ",\"Flame_sensor\":" + values[2].Replace(" T", "") + ",\"Temperatura\":" + values[3].Replace("H", "") + ",\"Humidade\":" + values[4].Replace(" F", "") + ",\"Sound_sensor\":\"" + values[5] + "\"},";
                frm.txtData.Tag = "";
                CreatePnl(pnlPrincipal.Controls.Count.ToString(), data[1].Replace(" S", ""), data[2].Replace(" T", ""), data[3].Replace("H", ""), data[4].Replace(" F", ""), data[5]); // cada segundo cria os objetos e manda para o pnlPrincipal
                //pnlPrincipal.AutoScrollPosition = new Point(0, pnlPrincipal.VerticalScroll.Maximum); // faz autoscroll com base na posição atal

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear(); // apaga tudo o que tiver dentro do pnlPrincipal 
        }

        //DONT TOUCH!
        private void CreatePnl(string data, string ultrasonic, string sound, string temperatura, string humidade, string flame)
        {
            PictureBox pctSound = new PictureBox();
            PictureBox pctUltraSonic = new PictureBox();
            PictureBox pctFlame = new PictureBox();
            PictureBox pctTemperatura = new PictureBox();
            PictureBox pctHumity = new PictureBox();
            PictureBox pctTime = new PictureBox();
            Label lblTime = new Label();
            Label lblHumidade = new Label();
            Label lblUltraSonic = new Label();
            Label lnlTemperatura = new Label();
            Label lblSensor = new Label();
            Label lblSound = new Label();
            TableLayoutPanel tlpData = new TableLayoutPanel();

            #region Data

            pctSound.Anchor = AnchorStyles.Right;
            pctSound.Image = global::ProjetoC_.Properties.Resources.wave_sound;
            pctSound.Location = new System.Drawing.Point(699, 9);
            pctSound.Name = "pctSound";
            pctSound.Size = new System.Drawing.Size(67, 50);
            pctSound.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            pctSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;


            pctUltraSonic.Anchor = AnchorStyles.Right;
            pctUltraSonic.Image = global::ProjetoC_.Properties.Resources.ultrasonic_sensor;
            pctUltraSonic.Location = new System.Drawing.Point(565, 9);
            pctUltraSonic.Name = "pctUltraSonic";
            pctUltraSonic.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            pctUltraSonic.Size = new System.Drawing.Size(67, 50);
            pctUltraSonic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;


            pctFlame.Anchor = AnchorStyles.Right;
            pctFlame.Image = global::ProjetoC_.Properties.Resources.smoke_detector;
            pctFlame.Location = new System.Drawing.Point(431, 9);
            pctFlame.Name = "pctFlame";
            pctFlame.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            pctFlame.Size = new System.Drawing.Size(67, 50);
            pctFlame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;


            pctTemperatura.Anchor = AnchorStyles.Right;
            pctTemperatura.Image = global::ProjetoC_.Properties.Resources.thermometer;
            pctTemperatura.Location = new System.Drawing.Point(297, 9);
            pctTemperatura.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            pctTemperatura.Name = "pctTemperatura";
            pctTemperatura.Size = new System.Drawing.Size(67, 50);
            pctTemperatura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;


            pctHumity.Anchor = AnchorStyles.Right;
            pctHumity.Image = global::ProjetoC_.Properties.Resources.humidity;
            pctHumity.Location = new System.Drawing.Point(163, 9);
            pctHumity.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            pctHumity.Name = "pctHumity";
            pctHumity.Size = new System.Drawing.Size(67, 50);
            pctHumity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;


            pctTime.Anchor = AnchorStyles.Right;
            pctTime.Image = global::ProjetoC_.Properties.Resources.chronometer;
            pctTime.Location = new System.Drawing.Point(29, 9);
            pctTime.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            pctTime.Name = "pctTime";
            pctTime.Size = new System.Drawing.Size(67, 50);
            pctTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;


            lblTime.Anchor = AnchorStyles.Right;
            lblTime.AutoSize = true;
            lblTime.Location = new System.Drawing.Point(26, 71);
            lblTime.Name = "lblTime";
            lblTime.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            lblTime.Size = new System.Drawing.Size(35, 13);
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            lblTime.Text = data;


            lblHumidade.Anchor = AnchorStyles.Right;
            lblHumidade.AutoSize = true;
            lblHumidade.Location = new System.Drawing.Point(160, 71);
            lblHumidade.Name = "lblHumidade";
            lblHumidade.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            lblHumidade.TextAlign = ContentAlignment.MiddleCenter;
            lblHumidade.Size = new System.Drawing.Size(35, 13);
            lblHumidade.Text = humidade;


            lblUltraSonic.Anchor = AnchorStyles.Right;
            lblUltraSonic.AutoSize = true;
            lblUltraSonic.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            lblUltraSonic.Location = new System.Drawing.Point(562, 71);
            lblUltraSonic.Name = "lblUltraSonic";
            lblUltraSonic.TextAlign = ContentAlignment.MiddleCenter;
            lblUltraSonic.Size = new System.Drawing.Size(35, 13);
            lblUltraSonic.Text = ultrasonic;


            lnlTemperatura.Anchor = AnchorStyles.Right;
            lnlTemperatura.AutoSize = true;
            lnlTemperatura.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            lnlTemperatura.TextAlign = ContentAlignment.MiddleCenter;
            lnlTemperatura.Location = new System.Drawing.Point(294, 71);
            lnlTemperatura.Name = "lnlTemperatura";
            lnlTemperatura.Size = new System.Drawing.Size(35, 13);
            lnlTemperatura.Text = temperatura;


            lblSensor.Anchor = AnchorStyles.Right;
            lblSensor.AutoSize = true;
            lblSensor.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            lblSensor.TextAlign = ContentAlignment.MiddleCenter;
            lblSensor.Location = new System.Drawing.Point(428, 71);
            lblSensor.Name = "lblSensor";
            lblSensor.Size = new System.Drawing.Size(35, 13);
            lblSensor.Text = flame;


            lblSound.Anchor = AnchorStyles.Right;
            lblSound.AutoSize = true;
            lblSound.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            lblSound.TextAlign = ContentAlignment.MiddleCenter;
            lblSound.Location = new System.Drawing.Point(696, 71);
            lblSound.Name = "lblSound";
            lblSound.Size = new System.Drawing.Size(35, 13);
            lblSound.Text = sound;

            #endregion

            tlpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            tlpData.ColumnCount = 6;
            tlpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.667F));
            tlpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.667F));
            tlpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.667F));
            tlpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.667F));
            tlpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.667F));
            tlpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.667F));
            tlpData.Controls.Add(lblUltraSonic, 4, 1);
            tlpData.Controls.Add(pctSound, 5, 0);
            tlpData.Controls.Add(pctUltraSonic, 4, 0);
            tlpData.Controls.Add(lblSensor, 3, 1);
            tlpData.Controls.Add(pctFlame, 3, 0);
            tlpData.Controls.Add(lnlTemperatura, 2, 1);
            tlpData.Controls.Add(pctTemperatura, 2, 0);
            tlpData.Controls.Add(lblHumidade, 1, 1);
            tlpData.Controls.Add(pctHumity, 1, 0);
            tlpData.Controls.Add(pctTime, 0, 0);
            tlpData.Controls.Add(lblTime, 0, 1);
            tlpData.Controls.Add(lblSound, 5, 1);
            tlpData.Location = new System.Drawing.Point(0, 0);
            tlpData.Name = "tableLayoutPanel1";
            tlpData.RowCount = 2;
            tlpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpData.Size = new System.Drawing.Size(800, 89);
            //panel.Dock = DockStyle.Top;

            Panel pnl = new Panel();
            pnl.Dock = System.Windows.Forms.DockStyle.Top;
            pnl.Location = new System.Drawing.Point(0, (pnlPrincipal.Controls.Count * 89));
            pnl.Size = new System.Drawing.Size(800, 89);
            pnl.Controls.Add(tlpData);


            pnlPrincipal.Controls.Add(pnl);
        }

        private void frmData_Resize(object sender, EventArgs e)
        {
            pnlPrincipal.AutoScrollPosition = new Point(0, pnlPrincipal.VerticalScroll.Maximum); // quando alterares o tamanho do form, altera a posição do scroll.
        }

        private void frmData_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr.Stop(); // para o tempo!
        }
    }
}
