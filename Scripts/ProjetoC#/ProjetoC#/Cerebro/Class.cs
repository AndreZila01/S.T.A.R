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
			public string Tecla { get; set; }
			public int Quantidade { get; set; }
		}
		internal class DataArduino
		{
			public int NumberPing {  get; set; }
			public float UltraSonic_sensor {  get; set; }
			public int Flame_sensor {  get; set; }
			public float Temperatura {  get; set; }
			public float Humidade {  get; set; }
			public int Sound_sensor {  get; set; }
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
