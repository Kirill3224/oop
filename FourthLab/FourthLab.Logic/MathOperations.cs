namespace FourthLab.Logic;

public class MathOperations
{
    public event EventHandler<IntegerDivisionEventArgs> DivisionPerformed;

    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;

    public int IntegerDivide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Дільник не може бути рівен нулю.");
        }

        int result = a / b;

        OnDivisionPerformed(new IntegerDivisionEventArgs(a, b, result));

        return result;
    }

    protected virtual void OnDivisionPerformed(IntegerDivisionEventArgs e)
    {
        EventHandler<IntegerDivisionEventArgs> handler = DivisionPerformed;
        handler?.Invoke(this, e);
    }
}
