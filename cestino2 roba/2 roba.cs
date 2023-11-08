using System;
using System.IO;
using static System.Console;

internal class _2_Roba
{
	static void Main()
	{
		string main = "testo a caso";
		string sub = "o a c";
		WriteLine(Str_Contains(main, sub));
		// Il tuo codice della console app qui...

		Console.WriteLine("Premi un tasto per uscire.");
		Console.ReadKey();
	}

	static bool Str_Contains(string str, string subs)
	{
		if(str.Length < subs.Length)
			return false;

		for(int i = 0, j; i <= str.Length - subs.Length; i++)
		{
			for(j = 0; j < subs.Length; j++)
				if(str[i + j] != subs[j])
					break;
			if(j == subs.Length)
				return true;
		}
		return false;
	}

	static public void Modifica(string a1, string a2, string a3, string path)
	{
		string a = a1;
		string[] ele = new string[1000];
		int dim = 0;
		int control = 0;
		using(StreamReader sw = new StreamReader(path))
		{
			string b = sw.ReadLine();
			while(b != null)
			{
				ele[dim] = b;
				string[] campi = ele[dim].Split(';');
				for(int i = 0; i < campi.Length; i++)
					if(campi[i] == a)
						control = dim;
				dim++;
				b = sw.ReadLine();
			}
		}
		using(StreamWriter sw = new StreamWriter(path))
		{
			dim = 0;
			string r = "";
			while(ele[dim] != null)
			{
				if(dim == control)
				{
					string[] campi2 = ele[dim].Split(';');
					if(a2 != null)
					{
						r = r + a2;
					}
					else
					{
						string[] campi3 = ele[dim].Split(';');
						r = r + campi3[dim];
					}
					if(a3 != null)
					{
						r = r + ";" + a3;
					}
					else
					{
						string[] campi4 = ele[dim].Split(';');
						r = r + ";" + campi4[dim];
					}

					sw.WriteLine(r);
				}
				else
				{
					sw.WriteLine(ele[dim]);
				}
				dim++;
			}
		}
	}

}
