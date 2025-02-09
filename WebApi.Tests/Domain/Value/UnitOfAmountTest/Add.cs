using WebApi.Domain.Value;

namespace WebApi.Test.Domain.Value.UnitOfAmountTest;

public class Add
{
    [Fact]
    public void decimal型の加算_引数が境界値未満()
    {
        UnitOfAmount uom = new(1);
        UnitOfAmount bef = uom;

        UnitOfAmount result = uom.Add(-1);

        // 結果の確認
        Assert.Equal(0, result.Value);
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
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => uom.Add(3));
        // イミュータブルであることの確認
        Assert.Equal(998, uom.Value);
        Assert.Equal(bef, uom);
    }

    [Fact]
    public void UnitOfAmount型の加算_和が境界値未満()
    {
        UnitOfAmount uom1 = new(998);
        UnitOfAmount uom2 = new(1);
        UnitOfAmount bef1 = uom1;
        UnitOfAmount bef2 = uom2;

        UnitOfAmount ans = uom1.Add(uom2);

        // イミュータブルであることの確認
        Assert.Equal(998, uom1.Value);
        Assert.Equal(bef1, uom1);
        Assert.Equal(1, uom2.Value);
        Assert.Equal(bef2, uom2);
        // 演算結果の確認
        Assert.Equal(999, ans.Value);
    }

    [Fact]
    public void UnitOfAmount型の加算_和が境界値と等価()
    {
        UnitOfAmount uom1 = new(998);
        UnitOfAmount uom2 = new(2);
        UnitOfAmount bef1 = uom1;
        UnitOfAmount bef2 = uom2;

        UnitOfAmount ans = uom1.Add(uom2);

        // イミュータブルであることの確認
        Assert.Equal(998, uom1.Value);
        Assert.Equal(bef1, uom1);
        Assert.Equal(2, uom2.Value);
        Assert.Equal(bef2, uom2);
        // 演算結果の確認
        Assert.Equal(1000, ans.Value);
    }

    [Fact]
    public void UnitOfAmount型の加算_和が境界値を超過()
    {
        UnitOfAmount uom1 = new(998);
        UnitOfAmount uom2 = new(3);
        UnitOfAmount bef1 = uom1;
        UnitOfAmount bef2 = uom2;

        // 例外の確認
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => uom1.Add(uom2));
        // イミュータブルであることの確認
        Assert.Equal(998, uom1.Value);
        Assert.Equal(bef1, uom1);
        Assert.Equal(3, uom2.Value);
        Assert.Equal(bef2, uom2);
    }

}
