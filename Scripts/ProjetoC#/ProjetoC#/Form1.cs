using ProjetoC_.Cerebro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoC_
{
	public partial class Form1 : Form
	{
		static string Keybinds = "";
		private HashSet<Keys> teclasPressionadas = new HashSet<Keys>();

		private void button4_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Hello", "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.ActiveControl = null;
		}
		public Form1()
		{
			InitializeComponent();
			timer1.Start();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.ActiveControl = null;
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
            //Console.WriteLine(""+teclasPressionadas.Count());
            if (teclasPressionadas.Count() < 2)
			{
				teclasPressionadas.Add(e.KeyCode);
                Console.WriteLine(("" + Form.ActiveForm) == "ProjetoC_.Form1, Text: Form1");
                if (("" + Form.ActiveForm) == "ProjetoC_.Form1, Text: Form1")
					if (e.KeyData.ToString().ToLower() == "a" || e.KeyData.ToString().ToLower() == "s" || e.KeyData.ToString().ToLower() == "d" || e.KeyData.ToString().ToLower() == "w")
						ChangeDirectionalPad(e.KeyData.ToString());
			}
		}
		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			teclasPressionadas.Remove(e.KeyCode);
			if (teclasPressionadas.Count() > 0)
				ChangeDirectionalPad(teclasPressionadas.ToArray()[0].ToString());
			else
				ChangeDirectionalPad(e.KeyCode.ToString());
		}
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			//(new Keybinds()).Background_Keybinds();

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
            if (pctDirectionalPad.Image != Properties.Resources.directionalpad && teclasPressionadas.Count() == 0 && ("" + Form.ActiveForm) == "ProjetoC_.Form1, Text: Form1")
				pctDirectionalPad.Image = Properties.Resources.directionalpad;
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
					if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
					break;
			}
		}

		public void ChangeDirectionalPad(string tecla)
		{
            Console.WriteLine("1");
            if (tecla!="")
			Keybinds += tecla.ToString() + "\n";
			Console.WriteLine(Keybinds);
			Console.WriteLine("" + teclasPressionadas.Count() + " " + tecla);
			if (teclasPressionadas.Count > 1)
			{
				Console.WriteLine($"{teclasPressionadas.ToArray()[0]}{teclasPressionadas.ToArray()[1]}");
				switch ($"{teclasPressionadas.ToArray()[0]}{teclasPressionadas.ToArray()[1]}")
				{
					case "WD":
					case "DW":
						pctDirectionalPad.Image = Properties.Resources.DirectionalPad_CD;
						break;
					case "WA":
					case "AW":
						pctDirectionalPad.Image = Properties.Resources.DirectionalPad_CE;
						break;
					case "AS":
					case "SA":
						pctDirectionalPad.Image = Properties.Resources.DirectionalPad_BE;
						break;
					case "SD":
					case "DS":
						pctDirectionalPad.Image = Properties.Resources.DirectionalPad_BD;
						break;
				}
			}
			else if (teclasPressionadas.Count == 1 || tecla != "")
				switch (tecla)
				{
					case "A":
						pctDirectionalPad.Image = Properties.Resources.DirectionalPad_E;
						break;
					case "D":
						pctDirectionalPad.Image = Properties.Resources.DirectionalPad_D;
						break;
					case "S":
						pctDirectionalPad.Image = Properties.Resources.DirectionalPad_B;
						break;
					case "W":
						pctDirectionalPad.Image = Properties.Resources.DirectionalPad_C;
						break;
				}
			else
				pctDirectionalPad.Image = Properties.Resources.directionalpad;
		}

	}
}
