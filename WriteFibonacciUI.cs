using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WriteFibonacciRange
{
    public class WriteFibonacciUI
    {
        public int GetUserNumber(string name)
        {
            string input;
            int result;

            Console.Write($"{name} = ");

            input = Console.ReadLine();

            try
            {
                result = Convert.ToInt32(input);

                return result;
            }
            catch (FormatException ex)
            {
                Log.Logger.Error($"{ex.Message}");
                ShowResult(TextMessages.INCORRECT_INPUT_FORMAT);
            }
            catch (OverflowException ex)
            {
                Log.Logger.Error($"{ex.Message}");
                ShowResult(TextMessages.INCORRECT_INPUT_TO_BIG);
            }

            return GetUserNumber(name);
        }

        public void ShowHelp()
        {

        }

        public void ShowResult(string result)
        {
            Console.WriteLine(result);
        }

        public void ShowResult(IEnumerable<int> result)
        {
            int count = result.Count();

            if (count != 0)
            {
                int buff = 0;
                foreach (int number in result)
                {
                    if (buff < count-1)
                    {
                        Console.Write($"{number}, ");
                    }
                    else
                    {
                        Console.Write($"{number}.");
                    }
                    buff++;
                }

            }
            else
            {
                Console.WriteLine(TextMessages.EMPTY);
            }
        }

        public void Delay()
        {
            Console.ReadKey();
        }
    }
}
