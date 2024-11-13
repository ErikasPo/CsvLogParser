using CsvLogParser.Model;
using Microsoft.VisualBasic.FileIO;

namespace CsvLogParser.Services
{
    public class CsvParser
    {
        public static List<CsvLog> ParseFileToList(string path)
        {
            StreamReader reader;
            var logList = new List<CsvLog>();

            if (File.Exists(path))
            {
                //Use the streamreader to open the file
                reader = new StreamReader(File.OpenRead(path));

                //Using textfieldparser to parse into array
                TextFieldParser fieldParser = new TextFieldParser(reader);
                fieldParser.SetDelimiters(",");
                var columnNames = fieldParser.ReadLine();

                //Reading each line of the file and mapping it
                while (!fieldParser.EndOfData)
                {
                    var log = new CsvLog();

                    try
                    {
                        String[] currentRow = fieldParser.ReadFields();

                        log.DeviceVendor = currentRow[0];
                        log.DeviceProduct = currentRow[1];
                        log.DeviceVersion = float.Parse(currentRow[2]);
                        log.SignatureId = currentRow[3];
                        log.Severity = Int32.Parse(currentRow[4]);
                        log.Name = currentRow[5];
                        log.Start = DateTime.Parse(currentRow[6]);
                        log.Rt = float.Parse(currentRow[7]);
                        log.Msg = currentRow[8];
                        log.Shost = currentRow[9];
                        log.Smac = currentRow[10];
                        log.Dhost = currentRow[11];
                        log.Dmac = currentRow[12];
                        log.Suser = currentRow[13];
                        log.SuId = currentRow[14];
                        log.ExternalId = Int32.Parse(currentRow[15]);
                        log.Cs1Label = currentRow[16];
                        log.Cs1 = currentRow[17];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Line {0} is not valid and will be skipped.", e);
                    }

                    logList.Add(log);
                }
            }
            else
            {
                Console.WriteLine("The file doesn't exist.");
            }

            return (logList);
        }
    }
}