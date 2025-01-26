using WebApi.Domain.Value;

namespace WebApi.Test.Domain.Value.Isbn10Test;

public class Initialize
{
    [Fact]
    public void TestEmptyName()
    {
        var exception = Assert.Throws<InvalidDataException>(() => new Isbn10(""));
        Assert.Equal("Value is required.", exception.Message);
    }

    [Fact]
    public void TestLessThanLimitByValue()
    {
        Isbn10 result = new Isbn10("123456789");
        Assert.Equal("123456789", result.Value);
    }

    [Fact]
    public void TestLimitByValue()
    {
        Isbn10 result = new Isbn10("1234567890");
        Assert.Equal("1234567890", result.Value);
    }

    [Fact]
    public void TestOverLimitByValue()
    {
        var exception = Assert.Throws<InvalidDataException>(() => new Isbn10("12345678901"));
        Assert.Equal("Value is too long.", exception.Message);
    }
}