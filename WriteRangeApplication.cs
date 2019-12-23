namespace WriteFibonacciRange
{
    public class WriteRangeApplication
    {
        private readonly IRange _range;
        private readonly IRangeUserInterface _userInterface;

        public WriteRangeApplication(IRangeUserInterface userInterface, IRange range)
        {
            _userInterface = userInterface;
            _range = range;
        }

        public void WriteRange(int from, int upTo)
        {
            bool isEmpty = true;
            int fibonacciNumber;
            int nextFibonacciNumber;

            if (from < upTo)
            {
                for (int index = 0; ; index++)
                {
                    fibonacciNumber = _range[index];
                    nextFibonacciNumber = _range[index + 1];

                    if (nextFibonacciNumber >= upTo)
                    {
                        if (fibonacciNumber > from)
                        {
                            isEmpty = false;

                            _userInterface
                                .ShowResult($"{fibonacciNumber}{TextMessages.AFTER_LAST}");
                        }

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
