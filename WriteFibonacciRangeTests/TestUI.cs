using System;

namespace WriteFibonacciRange
{
    public class TestUI : IRangeUserInterface
    {
        public string Output { get; private set; }

        public void ShowResult(string result)
        {
            Output += result;
        }

        public int GetUserNumber(string name)
        {
            throw new NotImplementedException();
        }

        public void Delay()
        {
            throw new NotImplementedException();
        }

        public void ShowHelp()
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string result)
        {
            Output += result;
        }
    }
}
