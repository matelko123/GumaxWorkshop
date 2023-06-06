namespace GumaxWorkshop.Domain.ValueObjects;

public class NIP
{
    public string Value { get; set; }

    public NIP(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("NIP cannot be empty.", nameof(value));

        if (!IsValidNIP(value))
            throw new ArgumentException("Invalid NIP format.", nameof(value));

        Value = value;
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
        if (obj is NIP otherNIP)
        {
            return Value == otherNIP.Value;
        }

        return false;
    }

    protected bool Equals(NIP other)
    {
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    private bool IsValidNIP(string value) 
        => value.Length == 10 && value.All(char.IsDigit);
}
