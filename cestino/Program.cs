using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cestino
{
	internal class Program
	{
		static void Main()
		{
			string sw = Console.ReadLine();
			switch (sw)
			{
				case "1":
					string path = "C:\\Users\\ldamo\\OneDrive\\Desktop\\blank.txt";
					string[] lines = File.ReadAllLines(path);
					Array.Sort(lines);
					File.WriteAllLines(path, lines);
					break;

				case "2":
					string path1 = "C:\\Users\\ldamo\\OneDrive\\Desktop\\visual studio\\c++\\esercitazioni-cpp-Arrigoni-D-Amora-Zappa\\pasticceria\\magazzino.txt";
					string path2 = "C:\\Users\\ldamo\\OneDrive\\Desktop\\blank.txt";
					string[] lines1 = File.ReadAllLines(path1);
					string[] lines2 = File.ReadAllLines(path2);
					string[] liness2 = new string[100];
					int c = 0;
					for (int j = 0; j < lines2.Length; j++)
					{
						string find = lines2[j].Substring(0, 3).ToLower();
						for (int i = 0; i < lines1.Length; i++)
							if (lines1[i].ToLower().Contains(find))
								liness2[c++] = $"\t\t\tconsumi[{i}] = {lines2[j]}; //{lines1[i]}";
					}
					string[] line2 = new string[c];
					int cc = 0;
					for (int i = 0; i <  liness2.Length; i++)
						if (!string.IsNullOrEmpty(liness2[i]))
							line2[cc++] = liness2[i];
					File.WriteAllLines("C:\\Users\\ldamo\\OneDrive\\Desktop\\blank2.txt", line2);
					break;
				case "10":
					string path10 = "C:\\Users\\ldamo\\OneDrive\\Desktop\\visual studio\\c++\\esercitazioni-cpp-Arrigoni-D-Amora-Zappa\\pasticceria\\spesa.txt";
					string[] spesa10 = File.ReadAllLines(path10);
					//string pathh10 = "C:\\Users\\ldamo\\OneDrive\\Desktop\\blank2.txt";
					string[] lines10 = File.ReadAllLines("C:\\Users\\ldamo\\OneDrive\\Desktop\\blank.txt");
					string[] line10 = new string[620];
					for (int i = 0, l = 0; i < lines10.Length; i++)
					{
						int ch = lines10[i].Length;
						while (true)
						{
							ch--;
							if (!int.TryParse(lines10[i][ch].ToString(), out _)) break;
						}
						//il fondo è sempre numero, al primo space stop
						//ingrediente 1 g|200, 2 è il char 16
						ch++;
						line10[l++] = $"\t\t//{lines10[i]}, il valore è in char {ch}";
						//qui = stoi(lines[1].substr(16));
						line10[l++] = $"\t\tqui = stoi(lines[{i+1}].substr({ch}));";
						//if (qui < 1000) \n { \n
						ch = spesa10[i+1].Length;
						string svv = "";
						while (true)
						{
							ch--;
							if (!int.TryParse(spesa10[i+1][ch].ToString(), out _)) break;
							svv = spesa10[i+1][ch] + svv;
						}
						int vv = int.Parse(svv);
						//il fondo è sempre numero, al primo space stop
						line10[l++] = $"\t\tif (qui < {vv})";
						line10[l++] = "\t\t{";
						//lista[1] = true;
						line10[l++] = $"\t\t\tlista[{i+1}] = true;";
						//qui += 1000;
						line10[l++] = $"\t\t\tqui += {vv};";
						line10[l++] = "\t\t}";
						//lines[1] = "ingrediente 1 g " + to_string(qui - consumi[1]) + "\n";
						line10[l++] = $"\t\tlines[{i + 1}] = \"{spesa10[i+1].Substring(0, ch)} \" + to_string(qui - consumi[{i + 1}]) + \"\\n\";";
						l++;
					}
					File.WriteAllLines("C:\\Users\\ldamo\\OneDrive\\Desktop\\blank2.txt", line10);
					break;
				case "3":
					if (!float.TryParse(",13", out float price))//bad input
						Console.WriteLine("false");
					else Console.WriteLine("true\n" + price);
					break;

				case "4":
					string str = "0123";
					str = "4" + str;
					str.Substring(0, 1);
					Console.WriteLine(str);
					break;
				case "5":
					string[] lines5 = File.ReadAllLines("C:\\Users\\ldamo\\OneDrive\\Desktop\\blank.txt");
					lines5[lines5.Length] = "test";
					Console.WriteLine(string.Join(" | ", lines5));
					break;
				case "6":
					string[] lines6 = { "10;22;45;78" };
					string line = lines6[0].Split(";".ToCharArray(), 2)[1];
					Console.WriteLine(line);
					break;
				case "7":
					string nome = "ciao; io";
					string nome2 = "ciao";
					bool test = nome.Contains(";");
					bool test2 = nome2.Contains(";");
					Console.WriteLine(test + " | " + test2);
					break;
				case "8":
					int[] lines8 = { 0, 1, 2, 3, 4, 5 };
					int seline8 = 4;
					int moveline8 = 1;

					int line8 = lines8[moveline8];
					lines8[moveline8] = lines8[seline8];
					if (seline8 < moveline8)
					{
						for (int i = seline8; i < moveline8-1; i++)
							lines8[i] = lines8[i+1];
						lines8[moveline8-1] = line8;
					}
					else
					{
						for (int i = seline8; i > moveline8+1; i--)
							lines8[i]=lines8[i-1];
						lines8[moveline8+1] = line8;
					}

					Console.WriteLine("\n\n"+string.Join("\n", lines8));
					break;
				case "9":
					Console.WriteLine(Path.GetFullPath("."));
					Console.WriteLine(Path.GetFullPath("\\"));
					Console.WriteLine(Path.GetFullPath(".\\"));
					Console.WriteLine(Path.GetFullPath(".."));
					Console.WriteLine(Path.GetFullPath("..\\.."));
					Console.WriteLine(Path.GetFullPath("..\\..\\.."));
					Console.WriteLine(Path.GetFullPath("..\\..\\..\\test"));
					Console.WriteLine(Path.GetFullPath("..\\..\\..\\test\\.."));
					Console.WriteLine(Path.GetFullPath("..\\..\\.\\test\\"));
					Console.WriteLine(Path.GetFullPath("..\\..\\.\\test"));
					Console.WriteLine(Path.GetFullPath(".\\.\\."));
					break;
				case "11":
					//bogosort
					//int[] arr = 
					break;
				case "12":
					string path12 = "C:\\Users\\ldamo\\source\\repos\\Relitti\\Relitti\\Azzolari.csv";
					string[] lines12 = File.ReadAllLines(path12);
					StreamWriter sw12 = new StreamWriter(path12);
					for (int i = 0; i < lines12.Length; i++)
					{
						string[] split = lines12[i].Split(',');
						sw12.WriteLine(string.Join(";", split));
					}
					sw12.Close();
					break;
			}

			//

			//string find = Console.ReadLine();
			//string path = "C:\\Users\\ldamo\\OneDrive\\Desktop";
			//for (int i = 1; i < 11; i++)
			//{
			//	string[] lines = File.ReadAllLines(path + $"\\libro delle ricette\\ricetta{i}.txt");
			//	for (int j = 0; j < lines.Length; j++)
			//		if (lines[j].ToLower().Contains(find)) Console.WriteLine(i);
			//}



			//string path = "C:\\Users\\ldamo\\OneDrive\\Desktop\\visual studio\\c++\\esercitazioni-cpp-Arrigoni-D-Amora-Zappa\\pasticceria\\lista.txt";
			//string[] lines = File.ReadAllLines(path);

			//for (int i = 1; i < lines.Length; i++)
			//{
			//    int cc = 0; //char count
			//    try
			//    {

			//        throw "";
			//    }
			//    catch (...)
			//    {

			//    }



		}
		static string GetPath()
		{
			string path = Path.GetFullPath(".");
			path = Path.GetDirectoryName(path);
			path = Path.GetDirectoryName(path);
			path += @"\vari test\testo";
			return path;
		}
	}
}