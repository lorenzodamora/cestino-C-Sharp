using System;
using System.Runtime.InteropServices;

class Program
{
	#region Dll Import
	[DllImport("user32.dll")]
	private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetConsoleWindow();
	#endregion

	static void Main()
	{
		//int SW_SHOWMAXIMIZED = 3;
		IntPtr hWnd = GetConsoleWindow();
		if(hWnd != IntPtr.Zero) ShowWindow(hWnd, 3);

		// Il tuo codice della console app qui...

		Console.WriteLine("Premi un tasto per uscire.");
		Console.ReadKey();
	}
}

//questo codice mette solo full screen
//https://stackoverflow.com/a/77069782/21002052