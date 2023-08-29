using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Mult");
            Console.WriteLine("3. Div");
            Console.WriteLine("4. Subst");

            selectedOperation = 1;

            Menu();

            ConsoleKeyInfo keyInfo;
            do
            {
                /* intercept-i ona göre true vermişemki klaviaturadan daxil edilen melumat
                ekrana çixmasin sadece oxunsun ve istifade edilsin*/
                keyInfo = Console.ReadKey(intercept: true); 

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        moveSelection(-1);
                        break;

                    case ConsoleKey.DownArrow:
                        moveSelection(1);
                        break;

                    case ConsoleKey.Enter:
                        if (Calculation())
                        {
                            Menu();
                        }
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        /* seçimi ona göre static yazırıqki program bitene qeder eyni deyere istenilen funksiyada 
         çatib, lazim gelerse global olaraq update ede bilmekdi*/
        static int selectedOperation;

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Calculator");
            for (int i = 1; i <= 4; i++)
            {
                if (i == selectedOperation)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"{i}. {GetOperationName(i)}");

                Console.ResetColor();
            }
        }
        //seçimler üzerinde oxun yuxari asagi hereket etmesi ucun funksiya
        static void moveSelection(int direction)
        {
            if (direction == -1) // -1 yuxari oxun hereketini bildirir
            {
                /* eger hal-hazirda secilen emeliyyat 1-dise 4-e beraber et, yəni ən üstdəki seçimə getsin,
                 eksi halda 1 defe azalt ondan evvelki seçime getsin*/
                selectedOperation = selectedOperation == 1 ? 4 : selectedOperation - 1; 
            }
            else if (direction == 1) // 1 asagi oxun hereketini bildirir
            {
                /* eger hal-hazirda secilen emeliyyat 4-düse 1-e beraber et, yəni ən altdakı seçimə getsin,
                eksi halda 1 defe artir ondan sonraki seçime getsin*/
                selectedOperation = selectedOperation == 4 ? 1 : selectedOperation + 1;
            }


            //secimlerin hazirki veziyyetini ekranda gostermek
            Menu();
        }

        //secilen emeliyyatin adini qebul edib prosesden önce text olaraq return etmek ucun get funksiyasi
        static string GetOperationName(int operation)
        {
            switch (operation)
            {
                case 1:
                    return "Add";
                case 2:
                    return "Mult";
                case 3:
                    return "Div";
                case 4:
                    return "Subst";
                default:
                    return "";
            }
        }

        static bool Calculation()
        {
            Console.Clear();
            Console.WriteLine($"Secilen emeliyyat: {GetOperationName(selectedOperation)}\n");

            Console.Write("Birinci ededi daxil edin: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("İkinci ededi daxil edin: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = 0;
            string operationSymbol = "";

            //hesablama prosesi
            switch (selectedOperation)
            {
                case 1:
                    result = num1 + num2;
                    operationSymbol = "+";
                    break;

                case 2:
                    result = num1 * num2;
                    operationSymbol = "*";
                    break;

                case 3:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        operationSymbol = "/";
                    }
                    else
                    {
                        Console.WriteLine("0-a bolmek olmaz!");
                        return false;
                    }
                    break;

                case 4:
                    result = num1 - num2;
                    operationSymbol = "-";
                    break;
            }

            //neticenin ekrana cixarilmasi
            Console.WriteLine($"Netice: {num1} {operationSymbol} {num2} = {result}");
            
            // neticeden sonraki mesaj
            Console.WriteLine("\nCixmaq esc-e basin, menuya qayitmaq ucun enter-a basin.");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            return true;
        }
    }
}
