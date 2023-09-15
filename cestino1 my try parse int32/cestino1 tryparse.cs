using System;
using System.Threading.Tasks;
using static System.Console;

class cestino1
{
  static void Button(int left, string name)
  {
    int space = name.Length;

    CursorLeft = left;
    Write(new string(' ', space));

    CursorLeft = left;
    CursorTop++;
    //Write(name + CursorTop +  "  &  " + (CursorLeft + space));
    Write(name);

    CursorLeft = left;
    CursorTop++;
    Write(new string(' ', space));
  }
  static void TextBox()
  {
    BackgroundColor = ConsoleColor.White;
    ForegroundColor = ConsoleColor.Black;
    CursorTop = 30;
    Button(35, new string(' ', 52));
    CursorTop--;
    CursorLeft = 37;
  }

  static void Main()
  {
    /*
    while(true)
    {
      ConsoleKeyInfo keyInfo = Console.ReadKey();
      char keyPressed = keyInfo.KeyChar;

      // Stampa il carattere letto
      Console.Write(keyPressed);
    }
		*/

    // Il tuo codice della console app qui...
    Console.ReadKey();

    int fun;
    TextBox();
    //!(fun >= 0 && fun <= 4)
    while(!int.TryParse($"{ReadKey().KeyChar}", out fun) || fun < 0 || fun > 5)
    {//bad input
      Task.Delay(300).Wait();
      SetCursorPosition(38, 32);
      Write($"numero intero tra 0 e {5}");
      SetCursorPosition(37, 31);
      Write(" ");
      CursorLeft--;
    }
    Task.Delay(500).Wait();

    int fun2;
    TextBox();

    while(!MyTryParseInt32($"{ReadKey().KeyChar}", out fun2) || fun2 < 0 || fun2 > 5)
    {//bad input
      Task.Delay(300).Wait();
      SetCursorPosition(38, 32);
      Write($"numero intero tra 0 e {5}");
      SetCursorPosition(37, 31);
      Write(" ");
      CursorLeft--;
    }
    Task.Delay(500).Wait();

    Console.WriteLine("Premi un tasto per uscire.");
    Console.ReadKey();
  }

  static bool MyTryParseInt32(string s, out int result)
  {
    result = 0;
    bool isNegative = false;
    bool foundDigit = false;

    if(string.IsNullOrEmpty(s))
      return false;

    short startIndex = 0;
    if(s[0] == '-')
    {
      isNegative = true;
      startIndex = 1;
    }

    for(int i = startIndex; i < s.Length; i++)
      if(char.IsDigit(s[i]))
      {
        int digitValue = s[i] - '0';

        // Check for potential overflow before updating result
        if(result > (int.MaxValue - digitValue) / 10)
        {
          result = 0;
          return false;
        }

        result = result * 10 + digitValue;
        foundDigit = true;
      }
      else
      {
        result = 0;
        return false;
      }

    if(isNegative)
      result = -result;

    return foundDigit;
  }


}