using System;
using System.Collections;
using System.Linq;

namespace swap_in_an_array
{
	public static class Extension
	{
		public static string[] Shift(this string[] array, int startIndex, int length, int newIndex)
		{
			string[] items = array.Skip(startIndex).Take(length).ToArray();
			ArrayList arrayList = new ArrayList(array);
			arrayList.RemoveRange(startIndex, length);
			arrayList.InsertRange(newIndex, items);

			arrayList.CopyTo(array);
			return array;
		}
	}
	public class Program
	{
		private static void Main()
		{
			switch (Console.ReadLine())
			{ //funziona solo swap1
				case "1":
					Swap1();
					break;
				case "2":
					Swap2();
					break;
				case "3":
					Swap3();
					break;
			}
		}
		static void Swap1()
		{
			string[] array =
				{
		"line 0",
		"line 1",
		"line 2",
		"line 3",
		"line 4",
		"line 5",
		"line 6",
		"line 7",
		"line 8"
	};

			//array = array.Shift(5, 2, 1);
			//array = array.Shift(1+2, 3, 5-(3-2));

			int start1 = 1, start2 = 5, length1 = 3, length2 = 2;

			array = array.Shift(start2, length2, start1);
			array = array.Shift(start1+length2, length1, start2-(length1-length2));

			//foreach (string x in array) Console.WriteLine(x);
			Console.WriteLine(string.Join(" | ", array));
		}

		static void Swap2()
		{
			int start1 = 1, start2 = 5, length1 = 3, length2 = 2;
			int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			SwapGroups(array, start1, length1, start2, length2);
			Console.WriteLine(string.Join(" | ", array));
		}
		static int[] reverse(int[] array, int start, int end)
		{
			for (; start < end; start++, end--)
				(array[start], array[end]) = (array[end], array[start]);
			return array;
		}
		static int[] SwapGroups(int[] array, int start1, int length1, int start2, int length2)
		{
			int
				 end1 = start1 + length1,
				 end2 = start2 + length2;
			reverse(array, start1, end1);
			reverse(array, end1, start2);
			reverse(array, start2, end2);
			return reverse(array, start1, end2);
		}

		static void Swap3()
		{
			int start1 = 1, start2 = 5, length1 = 3, length2 = 2;
			int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			int[] array2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            System.Array.Copy(array,/* 0, */ array2,/* 0, */ start1);  // copy non-moved prefix
			System.Array.Copy(array, start2, array2, start1, length2);  // group 2
			Console.WriteLine(string.Join(" | ", array2));
		}

		/*
		static int[] Swap3Groups(int[] array, int start1, int length1, int start2, int length2)
		{
			if (start2 < start1)
			{  // if start2 is before to start1, swap
				(start1, length1, start2, length2) = (start2, length2, start1, length1);
			}
			int[] aux;
			int
				end1 = start1 + length1,
				end2 = start2 + length2;
			if (length1 <= length2)
			{
				aux = new int[length2];
				System.Array.Copy(array, start2, aux, 0, length2);
				System.Array.Copy(array, start1, array, end2 - length1, length1);
				System.Array.Copy(array, end1, array, start1 + length2, lengthBetween);
				System.Array.Copy(aux, 0, array, start1, length2);
			}
			else
			{
				aux = new int[length1];
				System.Array.Copy(array, start1, aux, 0, length1);
				System.Array.Copy(array, start2, array, start1, length2);
				System.Array.Copy(array, end1, array, start1 + length2, lengthBetween);
				System.Array.Copy(aux, 0, array, end2 - length1, length1);
			}
		}
		*/

		/*
		static void Swap4()
		{
			int start1 = 1, start2 = 5, length1 = 3, length2 = 2;
			int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			int[] array2 = new int[array.Length];
			int i;
			// copy non-moved prefix
			for (i = 0; i < start1; i++)
			{
				array2[i] = array[i];
			}
			// how much for print group 2?
			// start from start1, print nelem2 time
			for (int end = start1 + length2, offset = start2 - start1; i < end; i++)
			
				array2[i] = array[i + offset];  // copy 8 9
			
			// alternatively
			for (int end = start1 + length2, source = start2; i < end; i++, source++)
			
				array2[i] = array[source];  // copy 8 9
			
			Console.WriteLine(string.Join(" | ", array2));
		}
		*/
	}
}