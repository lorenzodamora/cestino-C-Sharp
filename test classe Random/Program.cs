using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_classe_Random
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random(); // Crea un'istanza di Random fuori dal ciclo

			for(int i = 0; i < 10; i++)
			{
				int rndn = rnd.Next(100); // Genera un numero casuale utilizzando l'istanza di Random

				Console.WriteLine(rndn);
			}
		}
	}
}
