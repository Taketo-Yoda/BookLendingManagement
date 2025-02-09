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
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new UnitOfAmount(-1));
    }

    [Fact]
    public void TestThresholdValue001()
    {
        UnitOfAmount uom = new UnitOfAmount(999);
        Assert.Equal(999, uom.Value);
    }

    [Fact]
    public void TestThresholdValue002()
    {
        UnitOfAmount uom = new (1000);
        Assert.Equal(1000, uom.Value);
    }

    [Fact]
    public void TestThresholdValue003()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new UnitOfAmount(1001));
    }
}
