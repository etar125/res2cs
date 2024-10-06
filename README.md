# ReScript to C# converter
Это библиотека для конвертирования кода ReScript в код C#.
## Поддерживаемые команды
- Printline
- Pause

## Пример
```
	printline TEEEEEEEEEEST&&&$var&&&/$children
  Pause
	     printline Test2&^&$anothervar&^&/$not-a-var
	 pause
```
->
```cs
using System;
using System.Windows.Forms;
namespace App {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("TEEEEEEEEEEST" + var + "$children");
            Console.ReadKey(true);
            Console.WriteLine("Test2" + anothervar + "$not-a-var");
            Console.ReadKey(true);
        }
    }
}
```