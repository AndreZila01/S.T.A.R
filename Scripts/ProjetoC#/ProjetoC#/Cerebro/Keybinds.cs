using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoC_.Cerebro
{
	internal class Keybinds
	{
		private static Form1 frm;
		private static LowLevelKeyboardProc _proc = HookCallback;
		private static IntPtr _hookID = IntPtr.Zero;
		private static HashSet<Keys> teclasPressionadas = new HashSet<Keys>(); // Armazena teclas ativas

		private static IntPtr SetHook(LowLevelKeyboardProc proc)
		{
			using (Process curProcess = Process.GetCurrentProcess())
			using (ProcessModule curModule = curProcess.MainModule)
			{
				return SetWindowsHookEx(13, proc, GetModuleHandle(curModule.ModuleName), 0);
			}
		}

		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
            if (nCode >= 0)
			{
				Keys tecla = (Keys)Marshal.ReadInt32(lParam);
				string teclaStr = tecla.ToString();
				if (wParam == (IntPtr)0x100 || wParam == (IntPtr)0x104)
				{
					teclasPressionadas.Add(tecla);
					Console.WriteLine($"Tecla Pressionada: {teclaStr}");

                    if ("" + Form.ActiveForm != "ProjetoC_.Form1, Text: Form1")
                        if (teclaStr == "A" || teclaStr == "S" || teclaStr == "D" || teclaStr == "W")
                            if (teclasPressionadas.Count < 2)
                            {
                                frm.ChangeDirectionalPad(teclasPressionadas.ToArray()[0].ToString());
                            }
                            else
                            {
                                frm.ChangeDirectionalPad($"{teclasPressionadas.ToArray()[0].ToString()}{teclasPressionadas.ToArray()[1].ToString()}");
                            }
                }
				else if (wParam == (IntPtr)0x101 || wParam == (IntPtr)0x105)
				{
					teclasPressionadas.Remove(tecla);
					Console.WriteLine($"Tecla Solta: {teclaStr}");

					if (teclasPressionadas.Count == 0)
					{
						Console.WriteLine("Nenhuma tecla pressionada!");
						frm.ChangeDirectionalPad("");
					}
				}
			}
			return CallNextHookEx(_hookID, nCode, wParam, lParam);
		}

		public void Background_Keybinds(Form1 m)
		{
			frm = m;
			_hookID = SetHook(_proc);
			while (true)
			{
				Application.DoEvents(); // Processa eventos do sistema
				System.Threading.Thread.Sleep(10); // Pequena pausa para evitar uso excessivo de CPU
			}
		}

		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll")]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);
	}
}
