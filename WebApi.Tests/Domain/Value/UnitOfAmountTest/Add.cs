using WebApi.Domain.Value;

namespace WebApi.Test.Domain.Value.UnitOfAmountTest;

public class Add
{
    [Fact]
    public void TestAddDecimalAtMinusVal()
    {
        UnitOfAmount uom = new(1);
        var exception = Assert.Throws<InvalidOperationException>(() => uom.Add(-1));
        Assert.Equal("Value is negative", exception.Message);
    }

    [Fact]
    public void TestAddDecimalAtZeroVal()
    {
        UnitOfAmount uom = new(1);
        UnitOfAmount ans = uom.Add(0);

        Assert.Equal(1, uom.Value);
        Assert.Equal(1, ans.Value);
    }

    [Fact]
    public void TestAddDecimalAtOne()
    {
        UnitOfAmount uom = new(1);
        UnitOfAmount ans = uom.Add(1);

        Assert.Equal(1, uom.Value);
        Assert.Equal(2, ans.Value);
    }

}
