namespace P03.Ferrari
{
    public interface ICar
    {
        string Model { get; }

        string Driver { get; }

        string PushBrakes();

        string PushGas();
    }
}
