using System;
using System.Dynamic;
using System.IO;
using System.Text;

namespace test_filestream
{
	internal class Program
	{
		static void Main()
		{
			switch(Console.ReadLine())
			{
				case "1":
					Test1();
					break;
				case "2":
					Test2();
					break;
			}
		}
		static void Test1()
		{
			string path = Path.GetFullPath("..\\..\\filestream\\fs.txt");
			//Directory.CreateDirectory(Path.GetDirectoryName(path));
			//File.Create(path);

			//scrive nel file
			string str = "a\nb\nc\nd\nend\n";
			Byte[] info = new UTF8Encoding(true).GetBytes(str);
			FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();
			fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Write(info, 0, info.Length);
			int[] error = { 0, 1 };
			//error[6] = 6;
			fs.Close();

			path = Path.GetDirectoryName(path) + "\\fs1.txt";
			using(fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))//using fa in modo che il file venga salvato in caso di errore
			{
				fs.Write(info, 0, info.Length);
				//error[6] = 6;
			}
		}
		static void Test2()
		{
			string path = Path.GetFullPath("..\\..\\filestream\\fs2.txt");

			//scrive nel file
			string str = "12\n3\n456\n789\n10";
			Byte[] info = new UTF8Encoding(true).GetBytes(str);
			FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();

			byte[] b = new byte[1024];
			fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.None); //se è truncate read rimarrà vuoto
			for(int l; (l = fs.Read(b, 0, b.Length)) > 0;)
				fs.Write(b, 0, l);
			fs.Write(info, 0, info.Length);
			fs.Close();
		}
	}
}
