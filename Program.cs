using Serilog;

namespace WriteFibonacciRange
{
    public class Program
    {
        private const int COUNT_OF_REQUIRED_PARAMETERS = 2;

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
               .WriteTo.File("log.txt").CreateLogger();

            IRangeUserInterface userInterface = new WriteRangeUserInterface();
            IRange range =  new FibonacciSequence();
            var app = new WriteFibonacciRangeApplication(userInterface, range);
            int from;
            int upTo;

            if (args.Length > COUNT_OF_REQUIRED_PARAMETERS)
            {
                if(int.TryParse(args[0], out from) && int.TryParse(args[1], out upTo))
                {
                    app.WriteFibonacciRange(from, upTo);
                }
                else
                {
                    Log.Logger.Error($"Can't parse args {args[0]} {args[1]}");
                    userInterface.ShowMessage(TextMessages.CANT_READ_ARGS);
                }
            }
            else
            {
                userInterface.ShowHelp();

                from = userInterface.GetUserNumber(TextMessages.FROM);
                upTo = userInterface.GetUserNumber(TextMessages.UP_TO);

                app.WriteFibonacciRange(from, upTo);
            }

            userInterface.Delay();
        }

    }
}
