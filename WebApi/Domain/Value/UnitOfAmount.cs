using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.OpenApi.Any;

namespace WebApi.Domain.Value;
public record UnitOfAmount
{
    public decimal Value { get; init; }

    public UnitOfAmount(decimal value)
    {
        Validate(value);
        Value = value;
    }

    private void Validate(decimal value)
    {
        if (value < 0)
        {
            throw new InvalidOperationException("Value is negative");
        }
        if (value > 1000)
        {
            throw new InvalidOperationException("Value is too big");
        }
    }

    public UnitOfAmount Add(decimal val)
    {
        Validate(val);
        return new(Value + val);
    }

    public UnitOfAmount Add(UnitOfAmount any)
    {
        return new(Value + any.Value);
    }

    public UnitOfAmount Minus(decimal val)
    {
        Validate(val);
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
}