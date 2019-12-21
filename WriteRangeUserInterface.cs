using Serilog;
using System;

namespace WriteFibonacciRange
{
    public class WriteRangeUserInterface : IRangeUserInterface
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
                ShowMessage(TextMessages.INCORRECT_INPUT_FORMAT);
            }
            catch (OverflowException ex)
            {
                Log.Logger.Error($"{ex.Message}");
                ShowMessage(TextMessages.INCORRECT_INPUT_TO_BIG);
            }

            return GetUserNumber(name);
        }

        public void ShowHelp()
        {
            Console.WriteLine(TextMessages.HELP);
        }

        public void ShowMessage(string result)
        {
            Console.WriteLine(result);
        }

        public void ShowResult(string result)
        {
            Console.Write(result);
        }

        public void Delay()
        {
            Console.ReadKey();
        }
    }
}
