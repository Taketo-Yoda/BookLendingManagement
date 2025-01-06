using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace WebApi.Domain.Value;
public class UnitOfAmount
{
    public decimal Value { get; }

    public UnitOfAmount(decimal Value)
    {
        if (Value < 0)
        {
            throw new InvalidOperationException("Value is negative");
        }
        if (Value > 1000)
        {
            throw new InvalidOperationException("Value is too big");
        }
        this.Value = Value;
    }

    public UnitOfAmount Add(UnitOfAmount any)
    {
        return new(Value + any.Value);
    }

    public UnitOfAmount Minus(UnitOfAmount any)
    {
        return new(Value + any.Value);
    }

    public static UnitOfAmount operator +(UnitOfAmount a, UnitOfAmount b)
    {
        return a.Add(b);
    }

    public static UnitOfAmount operator -(UnitOfAmount a, UnitOfAmount b)
    {
        return a.Minus(b);
    }
}