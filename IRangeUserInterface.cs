namespace WriteFibonacciRange
{
    public interface IRangeUserInterface
    {
        int GetUserNumber(string name);
        void ShowMessage(string result);
        void ShowResult(string result);
        void Delay();
        void ShowHelp();
    }
}