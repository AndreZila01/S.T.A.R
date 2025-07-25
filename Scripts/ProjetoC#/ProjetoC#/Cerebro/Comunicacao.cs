﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoC_.Cerebro
{
    public class Comunicacao
    {
        MqttClient client;
        private Form1 frm;
        private System.Windows.Forms.PictureBox pctIPV4;
        public void StartMQQT(string IPV4, string Path, Form1 frm)
        {
            try
            {
                // create client instance 
#pragma warning disable CS0618 // Type or member is obsolete
                client = new MqttClient(brokerIpAddress: (IPAddress.Parse(IPV4))); // cria uma comunicação, com o MQTT Broaker, como cliente!
#pragma warning restore CS0618 // Type or member is obsolete

                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; // cria um evento para quando receber dados entrar lá dentro

                string clientId = Guid.NewGuid().ToString(); // diz o clientID!
                client.Subscribe(new string[] { Path }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); // cria uma subscribe com o MQTT Cliente com o topic definido pelo cliente!
                client.Connect(clientId); // cria a ligação
                this.frm = frm;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void StopMQQT(string Path)
        {
            _ = client.CleanSession; // apagar a conecção
            client.Unsubscribe(new string[] { Path }); // unsubscribe o topico 
            client.Disconnect(); // e desliga-te do MQTT Broaker
        }


        public void SendDataMQQT(string Path, string Message)
        {
            if (client != null)
                client.Publish(Path, Encoding.UTF8.GetBytes(Message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false); // envia os dados que quer ao cliente, com o topico indicado
        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            //D_62 S_64 T_24 H_51 F_F
            //D em cm
            //S em Hz
            //T em Celsius
            //H em %
            //F em boolean
            string data = "" + System.Text.Encoding.Default.GetString(e.Message); // converte a mensagem de Binario para Texto em string
            Console.WriteLine("message=" + data);
            switch (data)
            {
                case "GreenLight": // se um dos valores for GreenLight 
                    frm.pctIPV4.Image = Properties.Resources.On; // muda a fotografia do pctIpv4 que está no Form1 para On
                    frm.pctIPV4.Tag = "1"; // e altera a sua tag, para sabermos que está ligado
                    break;
                case string a when a.Contains("D_") && a.Contains("S_"): // se a informação contiver Data
                    frm.dataArduino = System.Text.Encoding.Default.GetString(e.Message);
                    break;
                default:
                    break;

            }
        }
    }
}
