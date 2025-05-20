using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace ProjetoC_.Cerebro
{
    internal class Class
    {
        internal class Keybind
        {
            /// <summary>
            /// Tecla premida pelo cliente
            /// </summary>
            public string Tecla { get; set; }
            /// <summary>
            /// Quantas vezes o mesmo premiu a tecla!
            /// </summary>
            public int Quantidade { get; set; }
        }
        internal class DataArduino
        {
            /// <summary>
            /// O número do ping! Começa de 0 a 100000
            /// </summary>
			public int NumberPing { get; set; }
            /// <summary>
            /// Valor do ultrasonic! Valor em centimetros!
            /// </summary>
			public float UltraSonic_sensor { get; set; }
            /// <summary>
            /// Valor do FlameSensor em inteiro!
            /// </summary>
			public int Flame_sensor { get; set; }
            /// <summary>
            /// Valor da temperatura em ºC
            /// </summary>
			public float Temperatura { get; set; }
            /// <summary>
            /// Valor da Humidade em %
            /// </summary>
			public float Humidade { get; set; }
            /// <summary>
            /// Valor do som em HZ.
            /// </summary>
			public int Sound_sensor { get; set; }
        }
        [ProtoContract]
        internal class DataArduinoProto
        {
            [ProtoMember(1)]
            public int NumberPing { get; set; }
            [ProtoMember(2)]
            public float UltraSonic_sensor { get; set; }
            [ProtoMember(3)]
            public int Flame_sensor { get; set; }
            [ProtoMember(4)]
            public float Temperatura { get; set; }
            [ProtoMember(5)]
            public float Humidade { get; set; }
            [ProtoMember(6)]
            public int Sound_sensor { get; set; }
        }
    }
}
