using System;
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

namespace ProjetoC_.Cerebro
{
    public class Comunicacao
    {
        MqttClient client;
        private Form1 frm;
        public void StartMQQT(string IPV4, string Path, Form1 frm)
        {
            // create client instance 
#pragma warning disable CS0618 // Type or member is obsolete
            client = new MqttClient(brokerIpAddress: (IPAddress.Parse(IPV4)));
#pragma warning restore CS0618 // Type or member is obsolete

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
			client.Subscribe(new string[] { Path }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
			client.Connect(clientId);
            this.frm = frm;
		}

        public void StopMQQT(string Path)
        {
            _ = client.CleanSession;
            client.Unsubscribe(new string[] { Path });
            client.Disconnect();
        }


        public void CollectDataMQQT(string Path, string Message)
        {
            client.Publish(Path, Encoding.UTF8.GetBytes(Message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string data = ""+ System.Text.Encoding.Default.GetString(e.Message);
            Console.WriteLine("message=" + data);
            switch (data)
            {
                case "GreenLight":
                    frm.pctIPV4.Image = Properties.Resources.On;
                    frm.pctIPV4.Tag = "1";
                    break;
                case string a when a.Contains("Data"):
                    
                    break;
                default:
                    break;

            }
        }
    }
}
