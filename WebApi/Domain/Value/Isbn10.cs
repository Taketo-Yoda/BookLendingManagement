namespace WebApi.Domain.Value;
public record Isbn10
{
    public string Value { get; init; }

    public Isbn10(string value)
    {
        if ("".Equals(value))
        {
            throw new InvalidDataException("Value is required.");
        }
        if (value.Length > 10)
        {
            throw new InvalidDataException("Value is too long.");
        }
        // TODO 正規表現チェック
        Value = value;
    }
}