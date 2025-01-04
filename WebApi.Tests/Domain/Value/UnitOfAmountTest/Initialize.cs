using WebApi.Domain.Value;

namespace WebApi.Test.Domain.Value.UnitOfAmountTest;

public class Initialize
{
    [Fact]
    public void TestIntPositiveValue()
    {
        UnitOfAmount uom = new(1);
        Assert.Equal(1, uom.Value);
    }

    [Fact]
    public void TestIntZeroValue()
    {
        UnitOfAmount uom = new(0);
        Assert.Equal(0, uom.Value);
    }

    [Fact]
    public void TestIntNegativeValue()
    {
        var exception = Assert.Throws<InvalidOperationException>(() => new UnitOfAmount(-1));
        Assert.Equal("Value is negative", exception.Message);
    }
}
