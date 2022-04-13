using System;

namespace TicketSale.Console
{
    public class ConsoleController
    {
        public static int ChooseFromList<T>(T[] items, string title)
        {
            System.Console.WriteLine($"Here are {title}:");
            System.Console.WriteLine();
            for (int intIndex = 0; intIndex < items.Length; intIndex++)
            {
                System.Console.WriteLine($"{Convert.ToString(intIndex + 1).PadLeft(6, ' ')}. {items[intIndex]}");
            }
            System.Console.WriteLine();
            System.Console.Write("Input number to choose: ");
            string input = System.Console.ReadLine();
            while (!ValidInputForListItem(input, items.Length))
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"Invalid Input! Here are {title}:");
                System.Console.WriteLine();
                for (int intIndex = 0; intIndex < items.Length; intIndex++)
                {
                    System.Console.WriteLine($"{Convert.ToString(intIndex + 1).PadLeft(6, ' ')}. {items[intIndex]}");
                }
                System.Console.WriteLine();
                System.Console.Write("Input number to choose: ");
                input = System.Console.ReadLine();
            }
            return Convert.ToInt32(input) - 1;
        }

        public static bool ConfirmationYN(string title)
        {
            System.Console.Write($"{title} (y/n): ");
            string input = System.Console.ReadLine();
            bool confirmed = false;
            while (!ValidYNConfirmation(input, out confirmed))
            {
                System.Console.WriteLine();
                System.Console.Write($"Invalid Input! {title} (y/n): ");
                input = System.Console.ReadLine();
                confirmed = false;
            }
            return confirmed;
        }

        public static void QuitApplication()
        {
            System.Console.WriteLine();
            System.Console.Write("Press any keys to quit: ");
            System.Console.ReadKey();
        }

        private static bool ValidInputForListItem(string input, int items)
        {
            int intInput = 0;
            if (int.TryParse(input, out intInput))
            {
                if ((intInput < 1) || (intInput > items))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private static bool ValidYNConfirmation(string input, out bool confirmed)
        {
            confirmed = false;
            if (String.Compare(input, "Y", true) == 0)
            {
                confirmed = true;
                return true;
            }
            else if (String.Compare(input, "N", true) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
