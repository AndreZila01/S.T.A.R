
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            foreach(DataArduino dataArd in lst)//for (int l = 0; l < lst.Count(); l++)
            {
                xlWorkSheet.Cells[2 + l, 1] = dataArd.data;
                xlWorkSheet.Cells[2 + l, 2] = dataArd.UltraSonic_sensor;
                xlWorkSheet.Cells[2 + l, 3] = dataArd.Flame_sensor;
                xlWorkSheet.Cells[2 + l, 4] = dataArd.Temperatura;
                xlWorkSheet.Cells[2 + l, 5] = dataArd.Humidade;
                xlWorkSheet.Cells[2 + l, 6] = dataArd.Sound_sensor;
                l++;
            }

            xlWorkBook.SaveAs(tempPath+"\\outputData.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue,
            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

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
                info += $"{Properties.Resources.StringData}{dataArd.data}; {Properties.Resources.StringUltraSonicSensor}{dataArd.UltraSonic_sensor}; {Properties.Resources.StringFlameSensor}{dataArd.Flame_sensor};{Properties.Resources.StringTemperature}{dataArd.Temperatura};{Properties.Resources.StringHumidity}{dataArd.Humidade};{Properties.Resources.StringSound}{dataArd.Sound_sensor}\n";
            File.WriteAllText(tempPath + "\\outputData.txt", info);
        }

        public void ProtobufData(string data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(Properties.Resources.StringData, typeof(DateTime));
            dt.Columns.Add(Properties.Resources.StringUltraSonicSensor, typeof(float));
            dt.Columns.Add(Properties.Resources.StringFlameSensor, typeof(int));
            dt.Columns.Add(Properties.Resources.StringTemperature, typeof(float));
            dt.Columns.Add(Properties.Resources.StringHumidity, typeof(float));
            dt.Columns.Add(Properties.Resources.StringSound, typeof(int));

            List<DataArduino> lst = JsonConvert.DeserializeObject<List<DataArduino>>(data);
            foreach (DataArduino dataArd in lst)
                dt.Rows.Add(dataArd.data, dataArd.UltraSonic_sensor, dataArd.Flame_sensor, dataArd.Temperatura, dataArd.Humidade, dataArd.Sound_sensor);
            

            using (Stream stream = File.OpenWrite(tempPath + "\\outputData.dat"))
            using (IDataReader reader = dt.CreateDataReader())
            {
                DataSerializer.Serialize(stream, reader);
            }

            //Thread.Sleep(1000);

            //dt = new DataTable();

            //using (Stream stream = File.OpenRead("C:\\Users\\teste\\Desktop\\foo.dat"))
            //using (IDataReader reader = DataSerializer.Deserialize(stream))
            //{
            //    dt.Load(reader);
            //}

        }

        public string ImportData(string Path, int tipo)
        {
            switch(tipo)
            {
                case 0:
                    return ExcelImport(Path);
                    break;
                case 1:
                    return TXTImport(Path);
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

            StringBuilder sb = new StringBuilder();
            // Cabeçalho
            sb.AppendLine("Data,UltraSonic_sensor,Flame_sensor,Temperatura,Humidade,Sound_sensor");

            // Leitura linha por linha
            while (xlWorkSheet.Cells[row, 1].Value2 != null)
            {
                string data = xlWorkSheet.Cells[row, 1].Value2.ToString();
                string ultrasonic = xlWorkSheet.Cells[row, 2].Value2.ToString();
                string flame = xlWorkSheet.Cells[row, 3].Value2.ToString();
                string temperatura = xlWorkSheet.Cells[row, 4].Value2.ToString();
                string humidade = xlWorkSheet.Cells[row, 5].Value2.ToString();
                string sound = xlWorkSheet.Cells[row, 6].Value2.ToString();

                sb.AppendLine($"{data},{ultrasonic},{flame},{temperatura},{humidade},{sound}");
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

            return JsonConvert.SerializeObject(sb.ToString(), Formatting.Indented);
            
        }

        private string TXTImport(string Path)
        {
            return File.ReadAllText(Path);
        }

        private string DartImport(string Path)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add(Properties.Resources.StringData, typeof(DateTime));
            dt.Columns.Add(Properties.Resources.StringUltraSonicSensor, typeof(float));
            dt.Columns.Add(Properties.Resources.StringFlameSensor, typeof(int));
            dt.Columns.Add(Properties.Resources.StringTemperature, typeof(float));
            dt.Columns.Add(Properties.Resources.StringHumidity, typeof(float));
            dt.Columns.Add(Properties.Resources.StringSound, typeof(int));

            dt = new DataTable();

            using (Stream stream = File.OpenRead(Path))
            using (IDataReader reader = DataSerializer.Deserialize(stream))
            {
                dt.Load(reader);
                return reader.ToString();
            }

        }
    }
}
