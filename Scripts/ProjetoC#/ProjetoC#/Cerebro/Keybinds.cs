using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjetoC_.Cerebro.Class;

namespace ProjetoC_.Cerebro
{
    internal class Keybinds
    {
        private static Form1 frm;
        private static List<Keybind> lstLastKeyBinds = new List<Keybind>();
        private static HashSet<Keys> teclasPressionadas;

        #region Dont Touch KeybindsBackground!
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

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
                    //Console.WriteLine($"Tecla Pressionada: {teclaStr}");

                    //if ("" + Form.ActiveForm != "ProjetoC_.Form1, Text: Form1")
                    Console.WriteLine("" + teclaStr);
                    if (teclaStr == "A" || teclaStr == "S" || teclaStr == "D" || teclaStr == "W")
                    {
                        teclasPressionadas.Add(tecla);
                        frm.txtInput.Tag = "";
                        ChangeDirectionalPad();
                    }
                }
                else if (wParam == (IntPtr)0x101 || wParam == (IntPtr)0x105)
                {
                    if (teclaStr == "A" || teclaStr == "S" || teclaStr == "D" || teclaStr == "W")
                        teclasPressionadas.Remove(tecla);
                    Console.WriteLine($"Tecla Solta: {teclaStr}");

                    if (teclasPressionadas.Count == 0)
                    {
                        Console.WriteLine("Nenhuma tecla pressionada!");
                        if (frm.txtInput.Tag.ToString() != "WAIT")
                            frm.txtInput.Tag = "WAIT";
                    }

                    ChangeDirectionalPad();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public void Background_Keybinds(Form1 m)
        {
            frm = m;
            teclasPressionadas = new HashSet<Keys>();
            _hookID = SetHook(_proc);
            while (true)
            {
                if (frm.Keybinds == "PARAR")
                    break;

                Application.DoEvents(); // Processa eventos do sistema
                Task.Delay(100); // Pequena pausa para evitar uso excessivo de CPU
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion


        public static void ChangeDirectionalPad()
        {
            if (teclasPressionadas.Count > 0 && frm.btnInput.Text.Contains("ON"))
            {
                if (frm.txtInput.Tag.ToString() == "WAIT")
                {
                    lstLastKeyBinds.Add(new Keybind { Quantidade = 1, Tecla = "WAIT" });
                    frm.Keybinds += "Wait\n";
                    frm.txtInput.Text = frm.Keybinds.Replace("\n", Environment.NewLine);
                }

                string teclas = "";
                if (teclasPressionadas.Count() == 2)
                    teclas = $"{teclasPressionadas.ToArray()[0]}{teclasPressionadas.ToArray()[1]}";
                else
                    teclas = $"{teclasPressionadas.ToArray()[0]}";

                if (lstLastKeyBinds.Count() != 0)
                {
                    if (lstLastKeyBinds[lstLastKeyBinds.Count() - 1].Tecla == teclas)
                        lstLastKeyBinds[lstLastKeyBinds.Count() - 1].Quantidade++;
                    else
                        lstLastKeyBinds.Add(new Keybind { Tecla = teclas, Quantidade = 1 });
                }
                else
                    lstLastKeyBinds.Add(new Keybind { Tecla = teclas, Quantidade = 1 });

                int quantidade = lstLastKeyBinds[lstLastKeyBinds.Count() - 1].Quantidade;

                if (quantidade != 1)
                {
                    var temp = frm.Keybinds.Split(new string[] { "\n" }, StringSplitOptions.None);

                    if (quantidade % 10 == 0)
                        quantidade--;

                    int lenghremove = ($"\n ({quantidade})").Length + 1;

                    if (teclas.Length == 2 && quantidade > 1)
                        lenghremove++;

                    if (quantidade == 2)
                        lenghremove = (teclas + "\n").Length;
                    frm.Keybinds = frm.Keybinds.Remove(frm.Keybinds.Length - (lenghremove), lenghremove) + $"{teclas} ({lstLastKeyBinds[lstLastKeyBinds.Count() - 1].Quantidade})\n";
                }
                else
                    frm.Keybinds += teclas.ToString() + "\n";

                switch (teclas)
                {
                    case "WD":
                    case "DW":
                        ChangeImageGamePad(Properties.Resources.DirectionalPad_CD);
                        break;
                    case "WA":
                    case "AW":
                        ChangeImageGamePad(Properties.Resources.DirectionalPad_CE);
                        break;
                    case "AS":
                    case "SA":
                        ChangeImageGamePad(Properties.Resources.DirectionalPad_BE);
                        break;
                    case "SD":
                    case "DS":
                        ChangeImageGamePad(Properties.Resources.DirectionalPad_BD);
                        break;
                    case "A":
                        ChangeImageGamePad(Properties.Resources.DirectionalPad_E);
                        break;
                    case "D":
                        ChangeImageGamePad(Properties.Resources.DirectionalPad_D);
                        break;
                    case "S":
                        ChangeImageGamePad(Properties.Resources.DirectionalPad_B);
                        break;
                    case "W":
                        ChangeImageGamePad(Properties.Resources.DirectionalPad_C);
                        break;
                }
            }
            else
                ChangeImageGamePad(Properties.Resources.directionalpad);
        }

        private static void ChangeImageGamePad(System.Drawing.Bitmap bitmap)
        {
            frm.pctDirectionalPad.Image = bitmap;
        }
    }
}
