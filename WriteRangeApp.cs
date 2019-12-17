namespace WriteFibonacciRange
{
    public class WriteRangeApp
    {
        private readonly IRange _fibonacciRange;
        private readonly IWriteRangeUI _userInterface;

        public WriteRangeApp(IWriteRangeUI userInterface, IRange fibonacciRange)
        {
            _userInterface = userInterface;
            _fibonacciRange = fibonacciRange;
        }

        public void WriteFibonacciNumber(int from, int upTo)
        {
            bool isEmpty = true;
            int fibonacciNumber;
            int nextFibonacciNUmber;

            if (from != upTo)
            {
                for (int index = 0; ; index++)
                {
                    fibonacciNumber = _fibonacciRange.GetIteration(index);
                    nextFibonacciNUmber = _fibonacciRange.GetIteration(index + 1);

                    if (nextFibonacciNUmber > upTo)
                    {
                        _userInterface
                            .ShowResult($"{fibonacciNumber}{TextMessages.AFTER_LAST}");
                        break;
                    }

                    if (fibonacciNumber > from)
                    {
                        isEmpty = false;

                        _userInterface
                            .ShowResult($"{fibonacciNumber}{TextMessages.SPLITER}");
                    }
                }
            }

            if(isEmpty)
            {
                _userInterface.ShowMessage(TextMessages.EMPTY);
            }

        }
    }
}
