using Serilog;
using System;

namespace WriteFibonacciRange
{
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
               .WriteTo.File("log.txt").CreateLogger();

            var userInterface = new WriteRangeUI();
            var range =  new FibonacciRange();
            var app = new WriteRangeApp(userInterface, range);
            int from;
            int upTo;

            if (args.Length > 1)
            {
                try
                {
                    from = Convert.ToInt32(args[0]);
                    upTo = Convert.ToInt32(args[1]);

                    app.WriteFibonacciNumber(from, upTo);
                }
                catch (FormatException ex)
                {
                    Log.Logger.Error($"{ex.Message}");
                    userInterface.ShowMessage(TextMessages.CANT_READ_ARGS);
                }
                catch (OverflowException ex)
                {
                    Log.Logger.Error($"{ex.Message}");
                    userInterface.ShowMessage(TextMessages.CANT_READ_ARGS);
                }
                catch (NullReferenceException ex)
                {
                    Log.Logger.Error($"{ex.Message}");
                    userInterface.ShowMessage(TextMessages.CANT_READ_ARGS);
                }
            }
            else
            {
                from = userInterface.GetUserNumber(TextMessages.FROM);
                upTo = userInterface.GetUserNumber(TextMessages.UP_TO);

                app.WriteFibonacciNumber(from, upTo);
            }

            userInterface.Delay();
        }

    }
}
