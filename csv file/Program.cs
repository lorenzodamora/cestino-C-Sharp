using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
namespace csv_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Remove(path.Length - 10); //altrimenti mettere il path è  ...\bin\debug
            path += "\\csv"; //aggiungi il folder
            Directory.CreateDirectory(path);//crea il folder se non esiste
            path += "\\Test.csv";
            Console.WriteLine(path);

            string[] lines = { "test,wy7g,winfe", "uhf,efer,erfre" };
            File.WriteAllLines(path, lines);
            //File.AppendAllLines(path, lines);

            StreamWriter wcsv = new StreamWriter(path, true);
            string first = "roba,";
            string second = "altra";
            string line = string.Format("{0},{1}", first, second);
            wcsv.WriteLine(line);
            wcsv.WriteLine(line);
            wcsv.Write(line);

            wcsv.Close();

            //

            var contents = File.ReadAllText(path).Split('\n');
            var csv = from linee in contents
                      select linee.Split(',').ToArray();


            //Console.WriteLine(contents);

            int headerRows = 5;
            foreach (string[] row in csv.Skip(headerRows)
                .TakeWhile(r => r.Length > 1 && r.Last().Trim().Length > 0))
            {
                string zerothColumnValue = row[0]; // leftmost column
                var firstColumnValue = row[1];
            }

        }
    }
}