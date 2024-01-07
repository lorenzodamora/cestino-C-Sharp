using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Cestino0 //Program
{
	static void Main()
	{
		string path = Path.GetFullPath("..\\..\\..\\onclick.txt");
		StreamWriter sw = new StreamWriter(path,false);
		for(int i = 0; i < 50000; i++)
			sw.Write(i + ";");
		sw.Close();
	}
}
