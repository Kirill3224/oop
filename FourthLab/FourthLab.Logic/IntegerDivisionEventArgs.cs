namespace FourthLab.Logic;

public class IntegerDivisionEventArgs : EventArgs
{
    public int Dividend { get; }
    public int Divisor { get; }
    public int Result { get; }

    public IntegerDivisionEventArgs(int dividend, int divisor, int result)
    {
        Dividend = dividend;
        Divisor = divisor;
        Result = result;
    }
}
