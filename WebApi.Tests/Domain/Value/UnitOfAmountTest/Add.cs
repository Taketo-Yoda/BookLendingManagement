using WebApi.Domain.Value;

namespace WebApi.Test.Domain.Value.UnitOfAmountTest;

public class Add
{
    [Fact]
    public void decimal型の加算_引数が境界値未満()
    {
        UnitOfAmount uom = new(1);
        UnitOfAmount bef = uom;

        // 例外の確認
        var exception = Assert.Throws<InvalidOperationException>(() => uom.Add(-1));
        // エラーメッセージの確認
        Assert.Equal("Value is negative", exception.Message);
        // イミュータブルであることの確認
        Assert.Equal(1, uom.Value);
        Assert.Equal(bef, uom);
    }

    [Fact]
    public void decimal型の加算_引数が境界値と等価()
    {
        UnitOfAmount uom = new(1);
        UnitOfAmount bef = uom;
        UnitOfAmount ans = uom.Add(0);

        // イミュータブルであることの確認
        Assert.Equal(1, uom.Value);
        Assert.Equal(bef, uom);
        // 演算結果の確認
        Assert.Equal(1, ans.Value);
    }

    [Fact]
    public void decimal型の加算_引数が境界値を超過()
    {
        UnitOfAmount uom = new(1);
        UnitOfAmount bef = uom;
        UnitOfAmount ans = uom.Add(1);

        // イミュータブルであることの確認
        Assert.Equal(1, uom.Value);
        Assert.Equal(bef, uom);
        // 演算結果の確認
        Assert.Equal(2, ans.Value);
    }

    [Fact]
    public void decimal型の加算_和が境界値未満()
    {
        UnitOfAmount uom = new(998);
        UnitOfAmount bef = uom;
        UnitOfAmount ans = uom.Add(1);

        // イミュータブルであることの確認
        Assert.Equal(998, uom.Value);
        Assert.Equal(bef, uom);
        // 演算結果の確認
        Assert.Equal(999, ans.Value);
    }

    [Fact]
    public void decimal型の加算_和が境界値と等価()
    {
        UnitOfAmount uom = new(998);
        UnitOfAmount bef = uom;
        UnitOfAmount ans = uom.Add(2);

        // イミュータブルであることの確認
        Assert.Equal(998, uom.Value);
        Assert.Equal(bef, uom);
        // 演算結果の確認
        Assert.Equal(1000, ans.Value);
    }

    [Fact]
    public void decimal型の加算_和が境界値を超過()
    {
        UnitOfAmount uom = new(998);
        UnitOfAmount bef = uom;

        // 例外の確認
        var exception = Assert.Throws<InvalidOperationException>(() => uom.Add(3));
        // エラーメッセージの確認
        Assert.Equal("Value is too big", exception.Message);
        // イミュータブルであることの確認
        Assert.Equal(998, uom.Value);
        Assert.Equal(bef, uom);
    }

}
