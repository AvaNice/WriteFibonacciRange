using Serilog;
using System;
using System.Collections.Generic;

namespace WriteFibonacciRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
               .WriteTo.File("log.txt").CreateLogger();

            var userInterface = new WriteFibonacciUI();
            var app = new FibonacciRangeApp(userInterface);
            IEnumerable<int> fibonacciRange;
            int from;
            int upTo;

            if (args.Length > 1)
            {
                try
                {
                    from = Convert.ToInt32(args[0]);
                    upTo = Convert.ToInt32(args[1]);

                    fibonacciRange = app.GetRange(from, upTo);
                    userInterface.ShowResult(fibonacciRange);
                }
                catch (FormatException ex)
                {
                    Log.Logger.Error($"{ex.Message}");
                    userInterface.ShowResult(TextMessages.CANT_READ_ARGS);
                }
                catch (OverflowException ex)
                {
                    Log.Logger.Error($"{ex.Message}");
                    userInterface.ShowResult(TextMessages.CANT_READ_ARGS);
                }
                catch (NullReferenceException ex)
                {
                    Log.Logger.Error($"{ex.Message}");
                    userInterface.ShowResult(TextMessages.CANT_READ_ARGS);
                }
            }
            else
            {
                from = userInterface.GetUserNumber(TextMessages.FROM);
                upTo = userInterface.GetUserNumber(TextMessages.UP_TO);

                //fibonacciRange = app.GetRange(from, upTo);
                //userInterface.ShowResult(fibonacciRange);

                app.WriteFibonacciNumber(from, upTo);
            }

            userInterface.Delay();
        }

    }
}
