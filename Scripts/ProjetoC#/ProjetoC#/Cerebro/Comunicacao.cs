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

namespace ProjetoC_.Cerebro
{
    public class Comunicacao
    {
        MqttClient client;
        public void StartMQQT(string IPV4, int Port)
        {
            // create client instance 
            client = new MqttClient(brokerIpAddress: (IPAddress.Parse(IPV4)));
            
            // register to message received 
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
        }


        public async void CollectDataMQQT()
        {

            // subscribe to the topic "/home/temperature" with QoS 2 
            client.Subscribe(new string[] { "home/temperature" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            client.Publish("home/temperature", Encoding.UTF8.GetBytes("André é lindo!"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

        }

        private static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine("message=" + System.Text.Encoding.Default.GetString(e.Message));
        }
    }
}
