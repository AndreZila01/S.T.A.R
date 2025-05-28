namespace ProjetoC_
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pctIPV4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnIA = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnOnArd = new System.Windows.Forms.Button();
            this.btnOffArd = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnForm = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblSound = new System.Windows.Forms.Label();
            this.lblHumidade = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblFlame = new System.Windows.Forms.Label();
            this.lblUSonic = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.pctDirectionalPad = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.bgwStart = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmsData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.protobufdatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonjsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelxlsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFiletxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctIPV4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctDirectionalPad)).BeginInit();
            this.cmsData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(196)))), ((int)(((byte)(151)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pctIPV4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 69);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(683, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Request IPV4";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pctIPV4
            // 
            this.pctIPV4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctIPV4.Image = global::ProjetoC_.Properties.Resources.Off;
            this.pctIPV4.Location = new System.Drawing.Point(762, 23);
            this.pctIPV4.Name = "pctIPV4";
            this.pctIPV4.Size = new System.Drawing.Size(26, 24);
            this.pctIPV4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctIPV4.TabIndex = 1;
            this.pctIPV4.TabStop = false;
            this.pctIPV4.Tag = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::ProjetoC_.Properties.Resources.Icon3;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 392);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(186)))), ((int)(((byte)(133)))));
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.trackBar1);
            this.panel5.Controls.Add(this.btnIA);
            this.panel5.Controls.Add(this.btnExport);
            this.panel5.Controls.Add(this.btnOnArd);
            this.panel5.Controls.Add(this.btnOffArd);
            this.panel5.Controls.Add(this.btnClearData);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.btnForm);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(280, 0);
            this.panel5.MaximumSize = new System.Drawing.Size(220, 392);
            this.panel5.MinimumSize = new System.Drawing.Size(220, 392);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(220, 392);
            this.panel5.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(54, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Acceleration: 28";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(228)))), ((int)(((byte)(223)))));
            this.trackBar1.Location = new System.Drawing.Point(6, 191);
            this.trackBar1.Maximum = 51;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(208, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Value = 28;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // btnIA
            // 
            this.btnIA.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnIA.Location = new System.Drawing.Point(6, 142);
            this.btnIA.Name = "btnIA";
            this.btnIA.Size = new System.Drawing.Size(208, 23);
            this.btnIA.TabIndex = 6;
            this.btnIA.Text = "IA Start";
            this.btnIA.UseVisualStyleBackColor = true;
            this.btnIA.Click += new System.EventHandler(this.button_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnExport.Location = new System.Drawing.Point(6, 327);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(208, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export Data do Arduino";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button_Click);
            this.btnExport.MouseHover += new System.EventHandler(this.btnExport_MouseHover);
            // 
            // btnOnArd
            // 
            this.btnOnArd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOnArd.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnOnArd.Location = new System.Drawing.Point(6, 56);
            this.btnOnArd.Name = "btnOnArd";
            this.btnOnArd.Size = new System.Drawing.Size(208, 23);
            this.btnOnArd.TabIndex = 4;
            this.btnOnArd.Text = "Connect with Arduino ";
            this.btnOnArd.UseVisualStyleBackColor = true;
            this.btnOnArd.Click += new System.EventHandler(this.button_Click);
            // 
            // btnOffArd
            // 
            this.btnOffArd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOffArd.Enabled = false;
            this.btnOffArd.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnOffArd.Location = new System.Drawing.Point(6, 114);
            this.btnOffArd.Name = "btnOffArd";
            this.btnOffArd.Size = new System.Drawing.Size(208, 23);
            this.btnOffArd.TabIndex = 3;
            this.btnOffArd.Text = "Turn off Arduino";
            this.btnOffArd.UseVisualStyleBackColor = true;
            this.btnOffArd.Click += new System.EventHandler(this.button_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearData.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnClearData.Location = new System.Drawing.Point(6, 356);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(208, 23);
            this.btnClearData.TabIndex = 2;
            this.btnClearData.Text = "Clear Data do Arduino";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.button_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(54, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ping com Arduino : 0 ms";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnForm
            // 
            this.btnForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForm.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnForm.Location = new System.Drawing.Point(6, 85);
            this.btnForm.Name = "btnForm";
            this.btnForm.Size = new System.Drawing.Size(208, 23);
            this.btnForm.TabIndex = 0;
            this.btnForm.Text = "New Form with data";
            this.btnForm.UseVisualStyleBackColor = true;
            this.btnForm.Click += new System.EventHandler(this.button_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(217)))), ((int)(((byte)(188)))));
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.btnImport);
            this.panel4.Controls.Add(this.txtData);
            this.panel4.Location = new System.Drawing.Point(500, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 392);
            this.panel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(228)))), ((int)(((byte)(223)))));
            this.panel6.Controls.Add(this.lblSound);
            this.panel6.Controls.Add(this.lblHumidade);
            this.panel6.Controls.Add(this.lblTemp);
            this.panel6.Controls.Add(this.lblFlame);
            this.panel6.Controls.Add(this.lblUSonic);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(6, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(291, 179);
            this.panel6.TabIndex = 3;
            // 
            // lblSound
            // 
            this.lblSound.AutoSize = true;
            this.lblSound.Location = new System.Drawing.Point(9, 146);
            this.lblSound.Name = "lblSound";
            this.lblSound.Size = new System.Drawing.Size(35, 13);
            this.lblSound.TabIndex = 5;
            this.lblSound.Tag = "0";
            this.lblSound.Text = "label9";
            // 
            // lblHumidade
            // 
            this.lblHumidade.AutoSize = true;
            this.lblHumidade.Location = new System.Drawing.Point(9, 122);
            this.lblHumidade.Name = "lblHumidade";
            this.lblHumidade.Size = new System.Drawing.Size(35, 13);
            this.lblHumidade.TabIndex = 4;
            this.lblHumidade.Tag = "0";
            this.lblHumidade.Text = "label8";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(9, 98);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(35, 13);
            this.lblTemp.TabIndex = 3;
            this.lblTemp.Tag = "0";
            this.lblTemp.Text = "label7";
            // 
            // lblFlame
            // 
            this.lblFlame.AutoSize = true;
            this.lblFlame.Location = new System.Drawing.Point(9, 74);
            this.lblFlame.Name = "lblFlame";
            this.lblFlame.Size = new System.Drawing.Size(35, 13);
            this.lblFlame.TabIndex = 2;
            this.lblFlame.Tag = "0";
            this.lblFlame.Text = "label6";
            // 
            // lblUSonic
            // 
            this.lblUSonic.AutoSize = true;
            this.lblUSonic.Location = new System.Drawing.Point(9, 50);
            this.lblUSonic.Name = "lblUSonic";
            this.lblUSonic.Size = new System.Drawing.Size(35, 13);
            this.lblUSonic.TabIndex = 1;
            this.lblUSonic.Tag = "0";
            this.lblUSonic.Text = "label5";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data do Arduino";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnImport.Location = new System.Drawing.Point(18, 366);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(270, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.button_Click);
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(228)))), ((int)(((byte)(223)))));
            this.txtData.Location = new System.Drawing.Point(6, 191);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(291, 174);
            this.txtData.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(217)))), ((int)(((byte)(188)))));
            this.panel3.Controls.Add(this.btnInput);
            this.panel3.Controls.Add(this.btnCopy);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.txtInput);
            this.panel3.Controls.Add(this.pctDirectionalPad);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 392);
            this.panel3.TabIndex = 0;
            // 
            // btnInput
            // 
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInput.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnInput.Location = new System.Drawing.Point(197, 357);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(70, 23);
            this.btnInput.TabIndex = 4;
            this.btnInput.TabStop = false;
            this.btnInput.Tag = "";
            this.btnInput.Text = "Input ON";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.button_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnCopy.Location = new System.Drawing.Point(104, 357);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(70, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.button_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnClear.Location = new System.Drawing.Point(12, 356);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(228)))), ((int)(((byte)(223)))));
            this.txtInput.Location = new System.Drawing.Point(12, 215);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(255, 135);
            this.txtInput.TabIndex = 1;
            this.txtInput.Tag = "WAIT";
            // 
            // pctDirectionalPad
            // 
            this.pctDirectionalPad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctDirectionalPad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(228)))), ((int)(((byte)(223)))));
            this.pctDirectionalPad.Image = global::ProjetoC_.Properties.Resources.directionalpad;
            this.pctDirectionalPad.Location = new System.Drawing.Point(12, 10);
            this.pctDirectionalPad.Name = "pctDirectionalPad";
            this.pctDirectionalPad.Size = new System.Drawing.Size(255, 194);
            this.pctDirectionalPad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctDirectionalPad.TabIndex = 0;
            this.pctDirectionalPad.TabStop = false;
            // 
            // bgwStart
            // 
            this.bgwStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgwStart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 650;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmsData
            // 
            this.cmsData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.protobufdatToolStripMenuItem,
            this.jsonjsonToolStripMenuItem,
            this.excelxlsxToolStripMenuItem,
            this.textFiletxtToolStripMenuItem});
            this.cmsData.Name = "cmsData";
            this.cmsData.Size = new System.Drawing.Size(158, 92);
            // 
            // protobufdatToolStripMenuItem
            // 
            this.protobufdatToolStripMenuItem.Name = "protobufdatToolStripMenuItem";
            this.protobufdatToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.protobufdatToolStripMenuItem.Tag = "0";
            this.protobufdatToolStripMenuItem.Text = "Protobuf (*.dat)";
            this.protobufdatToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // jsonjsonToolStripMenuItem
            // 
            this.jsonjsonToolStripMenuItem.Name = "jsonjsonToolStripMenuItem";
            this.jsonjsonToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.jsonjsonToolStripMenuItem.Tag = "1";
            this.jsonjsonToolStripMenuItem.Text = "Json (*.json)";
            this.jsonjsonToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // excelxlsxToolStripMenuItem
            // 
            this.excelxlsxToolStripMenuItem.Name = "excelxlsxToolStripMenuItem";
            this.excelxlsxToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.excelxlsxToolStripMenuItem.Tag = "2";
            this.excelxlsxToolStripMenuItem.Text = "Excel (*.xlsx)";
            this.excelxlsxToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // textFiletxtToolStripMenuItem
            // 
            this.textFiletxtToolStripMenuItem.Name = "textFiletxtToolStripMenuItem";
            this.textFiletxtToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.textFiletxtToolStripMenuItem.Tag = "3";
            this.textFiletxtToolStripMenuItem.Text = "Text File (*.txt)";
            this.textFiletxtToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(196)))), ((int)(((byte)(151)))));
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1500, 750);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S.T.A.R";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctIPV4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctDirectionalPad)).EndInit();
            this.cmsData.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.PictureBox pctIPV4;
		private System.Windows.Forms.Label label1;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		public System.Windows.Forms.PictureBox pctDirectionalPad;
		public System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnCopy;
		public System.Windows.Forms.Button btnInput;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnForm;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.BackgroundWorker bgwStart;
		private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnOffArd;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Button btnOnArd;
        private System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.ContextMenuStrip cmsData;
        private System.Windows.Forms.ToolStripMenuItem protobufdatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jsonjsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelxlsxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFiletxtToolStripMenuItem;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblUSonic;
        private System.Windows.Forms.Label lblHumidade;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblFlame;
        private System.Windows.Forms.Label lblSound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnIA;
    }
}

