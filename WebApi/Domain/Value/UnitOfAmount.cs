namespace WebApi.Domain.Value;

/// <summary>
/// 数量を表す値オブジェクト.
/// </summary>
public record UnitOfAmount
{
    /// <summary>
    /// 数量.
    /// </summary>
    public decimal Value { get; init; }

    /// <summary>
    /// コンストラクタ.
    /// </summary>
    /// <param name="value">値</param>
    /// <exception cref="ArgumentOutOfRangeException">0未満または1000を超える場合</exception>
    public UnitOfAmount(decimal value)
    {
        if (value < 0 || value > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }
        Value = value;
    }

    public UnitOfAmount Add(decimal val)
    {
        return new(Value + val);
    }

    public UnitOfAmount Add(UnitOfAmount any)
    {
        return new(Value + any.Value);
    }

    public UnitOfAmount Minus(decimal val)
    {
        return new(Value - val);
    }

    public UnitOfAmount Minus(UnitOfAmount any)
    {
        return new(Value - any.Value);
    }

    public static UnitOfAmount operator +(UnitOfAmount a, UnitOfAmount b)
    {
        return a.Add(b);
    }

    public static UnitOfAmount operator -(UnitOfAmount a, UnitOfAmount b)
    {
        return a.Minus(b);
    }

    public static UnitOfAmount operator +(UnitOfAmount a, decimal b)
    {
        return a.Add(b);
    }

    public static UnitOfAmount operator -(UnitOfAmount a, decimal b)
    {
        return a.Minus(b);
    }

    public static bool operator >(UnitOfAmount a, UnitOfAmount b)
    {
        return a.Value > b.Value;
    }

    public static bool operator <(UnitOfAmount a, UnitOfAmount b)
    {
        return a.Value < b.Value;
    }

    public static bool operator >(UnitOfAmount a, decimal b)
    {
        return a.Value > b;
    }

    public static bool operator <(UnitOfAmount a, decimal b)
    {
        return a.Value < b;
    }

    public static bool operator >=(UnitOfAmount a, UnitOfAmount b)
    {
        return a.Value >= b.Value;
    }

    public static bool operator <=(UnitOfAmount a, UnitOfAmount b)
    {
        return a.Value <= b.Value;
    }

    public static bool operator >=(UnitOfAmount a, decimal b)
    {
        return a.Value >= b;
    }

    public static bool operator <=(UnitOfAmount a, decimal b)
    {
        return a.Value <= b;
    }
}