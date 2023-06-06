namespace GumaxWorkshop.Domain.ValueObjects;

public class NIP
{
    private readonly string _value;

    public NIP(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("NIP cannot be empty.", nameof(value));

        if (!IsValidNIP(value))
            throw new ArgumentException("Invalid NIP format.", nameof(value));

        _value = value;
    }

    public override string ToString() => _value;

    public override bool Equals(object? obj)
    {
        if (obj is NIP otherNIP)
        {
            return _value == otherNIP._value;
        }

        return false;
    }

    protected bool Equals(NIP other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    private bool IsValidNIP(string value) 
        => value.Length == 10 && value.All(char.IsDigit);
}
