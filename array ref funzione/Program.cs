using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array_ref_funzione
{
	internal class Program
	{
		static void Main()
		{
			int[] a = { 1, 2, 3, 4, 5 };
			Resize(ref a, 6);
			Console.WriteLine(string.Join(" | ", a));
		}
		static void Resize(ref int[] array, int newSize)
		{
			if(array.Length != newSize)
			{
				int[] array2 = new int[newSize];
				if(array.Length < newSize) //se newsize è più grande, copia fino ad array.length e il resto rimane default
					for(int i = 0; i < array.Length; i++)
						array2[i] = array[i];
				else //se newsize è più piccolo copia fino a newsize
					for(int i = 0; i < newSize; i++)
						array2[i] = array[i];
				array = array2;
			}
		}
	}
}
