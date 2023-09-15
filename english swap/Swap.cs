using System;

namespace english_swap
{
	internal class Swap
	{
		static void Main()
		{
			//posi 0 1 2 3 4 5 6 7 8 9 10
			//resu 0 8 9 5 6 7 1 2 3 4 10
			//swap   1 2 3 4       8 9
			/* working example
			int nelem1 = 4; //number of element of group 1
			int start1 = 1; //start position of group 1

			int nelem2 = 2; //number of element of group 2
			int start2 = 8; //start position of group 2
			*/
			int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			Request(array, out int start1, out int nelem1, out int start2, out int nelem2);
			int[] array2 = new int[array.Length];

			if (start1 > start2) //if start2 is before to start1, swap variable
				(start1, start2, nelem1, nelem2) = (start2, start1, nelem2, nelem1);

			int i = 0;
			while (i < start1) //pos from 0 to 0 //here is where i write positions and values based on the values in the initial comment
			{
				array2[i] = array[i++]; //print 0
				//i++;
			}
			//how much for print group 2?
			//start from start1, print nelem2 time
			while (i < start1 + nelem2) //pos from 1 to 2
			{
				array2[i] = array[i + start2 - start1]; //print 8 9
														//now pos to i, i = start1; start 2 is start for print group 2
				i++;
			}
			//how much for print from end of group 2 and start of group 1?

			//start 2 + nelem2 is where is stop to print group 1, -nelem1 is where is start to print
			while (i < start2 + nelem2 - nelem1) //pos from 3 to 5
			{
				array2[i]=array[i + nelem1 - nelem2]; //print 5 6 7
													  //now pos to i, i = start1+nelem2; start1 + nelem 1 is where start the value to print, -nelem2 for the space is already used
				i++;
			}

			//start2 + nelem2 is end of print all variation
			while (i <  start2 + nelem2) //pos from 6 to 9 
			{
				array2[i]= array[i + start1 - start2 - nelem2 + nelem1];//print 1 2 3 4 
																	//now pos to i, print from start1, in the start of while i = -(-start2-nelem2 + nelem1)
				i++;
			}

			while (i< array.Length)
				array2[i] = array[i++]; //print the rest

			foreach (int x in array2) Console.Write(x + " | ");
			Console.WriteLine("\b\b ");
			//Console.WriteLine(string.Join(" | ", array2));
		}


		static void Request(int[] array, out int start1, out int length1, out int start2, out int length2)
		{
			Console.WriteLine("Questo è l'array:");
			Console.WriteLine(string.Join(" | ", array));

			Console.Write("inserisci l'inizio del primo gruppo da scambiare: ");
			start1 = int.Parse(Console.ReadLine());
			Console.Write("inserisci la lunghezza del primo gruppo da scambiare: ");
			length1= int.Parse(Console.ReadLine());
			Console.Write("inserisci l'inizio del secondo gruppo da scambiare: ");
			start2 = int.Parse(Console.ReadLine());
			Console.Write("inserisci la lunghezza del secondo gruppo da scambiare: ");
			length2 = int.Parse(Console.ReadLine());
		}
	}
}
