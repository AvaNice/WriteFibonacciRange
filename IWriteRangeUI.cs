namespace WriteFibonacciRange
{
    public interface IWriteRangeUI
    {
        void Delay();

        int GetUserNumber(string name);

        void ShowHelp();

        void ShowMessage(string result);

        void ShowResult(string result);
    }
}