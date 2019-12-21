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

            IWriteRangeUI userInterface = new WriteRangeUI();
            IRange range =  new FibonacciRange();
            var app = new WriteRangeApplication(userInterface, range);
            int from;
            int upTo;

            if (args.Length > 2)
            {
                if(int.TryParse(args[0], out from) && int.TryParse(args[1], out upTo))
                {
                    app.WriteFibonacciNumbers(from, upTo);
                }
                else
                {
                    Log.Logger.Error($"Can't parse user args{args[0]} {args[1]}");
                    userInterface.ShowMessage(TextMessages.CANT_READ_ARGS);
                }
            }
            else
            {
                from = userInterface.GetUserNumber(TextMessages.FROM);
                upTo = userInterface.GetUserNumber(TextMessages.UP_TO);

                app.WriteFibonacciNumbers(from, upTo);
            }

            userInterface.Delay();
        }

    }
}
