
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProtoBuf;
using ProtoBuf.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static ProjetoC_.Cerebro.Class;

namespace ProjetoC_.Cerebro
{
    internal class ExpImpData
    {
        string tempPath = Path.GetTempPath();
        public void ExcelData(string data)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            object misValue = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 1] = Properties.Resources.StringData;
            xlWorkSheet.Cells[1, 2] = Properties.Resources.StringUltraSonicSensor;
            xlWorkSheet.Cells[1, 3] = Properties.Resources.StringFlameSensor;
            xlWorkSheet.Cells[1, 4] = Properties.Resources.StringTemperature;
            xlWorkSheet.Cells[1, 5] = Properties.Resources.StringHumidity;
            xlWorkSheet.Cells[1, 6] = Properties.Resources.StringSound;

            List<DataArduino> lst = JsonConvert.DeserializeObject<List<DataArduino>>(data);// = //new List<DataArduino>();

            int l = 0;
            foreach (DataArduino dataArd in lst)//for (int l = 0; l < lst.Count(); l++)
            {
                xlWorkSheet.Cells[2 + l, 1] = dataArd.NumberPing;
                xlWorkSheet.Cells[2 + l, 2] = dataArd.UltraSonic_sensor;
                xlWorkSheet.Cells[2 + l, 3] = dataArd.Flame_sensor;
                xlWorkSheet.Cells[2 + l, 4] = dataArd.Temperatura;
                xlWorkSheet.Cells[2 + l, 5] = dataArd.Humidade;
                xlWorkSheet.Cells[2 + l, 6] = dataArd.Sound_sensor;
                l++;
            }

            xlWorkBook.SaveAs(Path.Combine(tempPath, "outputData.xlsx"), Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook,
                misValue, misValue, misValue, misValue,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close();
            xlApp.Quit();
        }

        public void JSONData(string data)
        {
            //List<DataArduino> lst = JsonConvert.DeserializeObject<List<DataArduino>>(data);
            File.WriteAllText(tempPath + "\\outputData.json", data);
        }

        public void TXTData(string data)
        {
            List<DataArduino> lst = JsonConvert.DeserializeObject<List<DataArduino>>(data);
            string info = "";
            foreach (DataArduino dataArd in lst)
                info += $"{Properties.Resources.StringData}{dataArd.NumberPing}; {Properties.Resources.StringUltraSonicSensor}{dataArd.UltraSonic_sensor}; {Properties.Resources.StringFlameSensor}{dataArd.Flame_sensor};{Properties.Resources.StringTemperature}{dataArd.Temperatura};{Properties.Resources.StringHumidity}{dataArd.Humidade};{Properties.Resources.StringSound}{dataArd.Sound_sensor} \n";
            File.WriteAllText(tempPath + "\\outputData.txt", info);
        }

        public void ProtobufData(string data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ping", typeof(int));
            dt.Columns.Add("Ultrasonic", typeof(float));
            dt.Columns.Add("Flame", typeof(int));
            dt.Columns.Add("Temp", typeof(float));
            dt.Columns.Add("Humidity", typeof(float));
            dt.Columns.Add("Sound", typeof(int));

            List<DataArduinoProto> lst = JsonConvert.DeserializeObject<List<DataArduinoProto>>(data);
            foreach (var item in lst)
            {
                dt.Rows.Add(item.NumberPing, item.UltraSonic_sensor, item.Flame_sensor,
                            item.Temperatura, item.Humidade, item.Sound_sensor);
            }

            byte[] bytes;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Serializer.Serialize(memoryStream, lst);
                bytes = memoryStream.ToArray();
            }

            using (var fs = File.OpenWrite(tempPath + "\\outputData.dat"))
            {
                fs.SetLength(0); // TRUNCA para zero antes de escrever
                Serializer.Serialize(fs, lst);
            }

        }

        public string ImportData(string Path, int tipo)
        {
            switch (tipo)
            {
                case 0:
                    return ExcelImport(Path);
                    break;
                case 1:
                    return JSONImport(Path);
                    break;
                case 2:
                    return TXTImport(Path);
                    break;
                case 3:
                    return DartImport(Path);
                    break;
                default:
                    return "";
                    break;
            }
        }

        private string ExcelImport(string Path)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            object misValue = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(Path);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets[1];

            int row = 2; // Começa na segunda linha (dados)


            string texto = "[";
            // Leitura linha por linha
            while (xlWorkSheet.Cells[row, 1].Value2 != null)
            {
                string data = xlWorkSheet.Cells[row, 1].Value2.ToString();
                string ultrasonic = xlWorkSheet.Cells[row, 2].Value2.ToString();
                string flame = xlWorkSheet.Cells[row, 3].Value2.ToString();
                string temperatura = xlWorkSheet.Cells[row, 4].Value2.ToString();
                string humidade = xlWorkSheet.Cells[row, 5].Value2.ToString();
                string sound = xlWorkSheet.Cells[row, 6].Value2.ToString();

                //sb.AppendLine($"{data},{ultrasonic},{flame},{temperatura},{humidade},{sound}");
                texto = "{\"NumberPing\":\"" + data + ",\"UltraSonic_sensor\":\"" + ultrasonic + ",\"Flame_sensor\":\"" + flame + ",\"Temperatura\":\"" + temperatura + ",\"Humidade\":\"" + humidade + ",\"Sound_sensor\":\"" + sound + "},";
                row++;
            }

            // Fechar Excel
            xlWorkBook.Close(false, misValue, misValue);
            xlApp.Quit();

            // Libertar recursos
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            // Retornar o texto

            return texto.Substring(0, texto.Length - 1);

        }

        private string JSONImport(string Path)
        {
            return (File.ReadAllText(Path)).Replace("]", ",");
        }

        private string TXTImport(string Path)
        {
            string texto = File.ReadAllText(Path).Replace("[", "").Replace("]", "").Replace("\n", "");

            //JsonConvert.DeserializeObject(new DataArduino{Flame_sensor = 0, Humidade = 10, NumberPing = 1, Sound_sensor = 2, Temperatura = 1, UltraSonic_sensor = 1 });
            string[] ad = texto.Split(new string[] { ";" }, StringSplitOptions.None);
            ad = ad.Select(i =>
            {
                return i.Split(new string[] { ":" }, StringSplitOptions.None)[1];
            }).ToArray();

            texto = "[";
            for (int i = 0; i < ad.Length - 1; i += 5)
            {
                texto += "{\"NumberPing\":\"" + ad[0 + i] + ",\"UltraSonic_sensor\":\"" + ad[1 + i] + ",\"Flame_sensor\":\"" + ad[2 + i] + ",\"Temperatura\":\"" + ad[3 + i] + ",\"Humidade\":\"" + ad[4 + i] + ",\"Sound_sensor\":\"" + ad[5 + i] + "},";
            }
            return texto.Substring(0, texto.Length - 1);
        }

        private string DartImport(string Path)
        {

            //DataTable dt = new DataTable();
            //dt.Columns.Add(Properties.Resources.StringData, typeof(int));
            //dt.Columns.Add(Properties.Resources.StringUltraSonicSensor, typeof(float));
            //dt.Columns.Add(Properties.Resources.StringFlameSensor, typeof(int));
            //dt.Columns.Add(Properties.Resources.StringTemperature, typeof(float));
            //dt.Columns.Add(Properties.Resources.StringHumidity, typeof(float));
            //dt.Columns.Add(Properties.Resources.StringSound, typeof(int));

            //dt = new DataTable();

            ////TODO: acabar isto
            //using (Stream stream = File.OpenRead(Path))
            //using (IDataReader reader = DataSerializer.Deserialize(stream))
            //{
            //    dt.Load(reader);
            //    return reader.ToString();
            //}

            string ad = "[";
            using (var fs = File.OpenRead(Path))
            {
                var obj = Serializer.Deserialize<List<DataArduinoProto>>(fs);
                foreach (var recebid in obj)
                    ad += "{\"NumberPing\":\"" + recebid.NumberPing + ",\"UltraSonic_sensor\":\"" + recebid.UltraSonic_sensor + ",\"Flame_sensor\":\"" + recebid.Flame_sensor + ",\"Temperatura\":\"" + recebid.Temperatura + ",\"Humidade\":\"" + recebid.Humidade + ",\"Sound_sensor\":\"" + recebid.Sound_sensor + "},";
            }

            return ad.ToString().Substring(0, ad.Length - 1);
        }
    }
}
