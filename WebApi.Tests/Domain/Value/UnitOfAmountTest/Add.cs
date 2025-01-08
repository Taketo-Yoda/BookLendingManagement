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
        UnitOfAmount bef = uom;
        UnitOfAmount ans = uom.Add(0);

        Assert.Equal(1, uom.Value);
        Assert.Equal(bef, uom);
        Assert.Equal(1, ans.Value);
    }

    [Fact]
    public void TestAddDecimalAtOne()
    {
        UnitOfAmount uom = new(1);
        UnitOfAmount bef = uom;
        UnitOfAmount ans = uom.Add(1);

        Assert.Equal(1, uom.Value);
        Assert.Equal(bef, uom);
        Assert.Equal(2, ans.Value);
    }

    [Fact]
    public void TestAddDecimalToResultMaximum001()
    {
        UnitOfAmount uom = new(998);
        UnitOfAmount bef = uom;
        UnitOfAmount ans = uom.Add(1);

        Assert.Equal(998, uom.Value);
        Assert.Equal(bef, uom);
        Assert.Equal(999, ans.Value);
    }

    [Fact]
    public void TestAddDecimalToResultMaximum002()
    {
        UnitOfAmount uom = new(998);
        UnitOfAmount bef = uom;
        UnitOfAmount ans = uom.Add(2);

        Assert.Equal(998, uom.Value);
        Assert.Equal(bef, uom);
        Assert.Equal(1000, ans.Value);
    }

    [Fact]
    public void TestAddDecimalToResultMaximum003()
    {
        UnitOfAmount uom = new(998);
        var exception = Assert.Throws<InvalidOperationException>(() => uom.Add(3));
        Assert.Equal("Value is too big", exception.Message);
    }

}
