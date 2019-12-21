namespace WriteFibonacciRange
{
    public interface IRange
    {
        int Length { get; }
        int this[int index] { get; }
    }
}