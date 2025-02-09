using WebApi.Domain.Value;

namespace WebApi.Test.Domain.Value.UnitOfAmountTest;

public class Minus
{
    [Fact]
    public void decimal型の減算_引数が境界値未満()
    {
        UnitOfAmount uom = new(5);
        UnitOfAmount bef = uom;

        UnitOfAmount result = uom.Minus(-1);

        // 結果の確認
        Assert.Equal(6, result.Value);
        // イミュータブルであることの確認
        Assert.Equal(5, uom.Value);
        Assert.Equal(bef, uom);
    }

    [Fact]
    public void decimal型の減算_引数が境界値と等価()
    {
        UnitOfAmount uom = new(5);
        UnitOfAmount bef = uom;

        UnitOfAmount ans = uom.Minus(0);

        // イミュータブルであることの確認
        Assert.Equal(5, uom.Value);
        Assert.Equal(bef, uom);
        // 演算結果の確認
        Assert.Equal(5, ans.Value);
    }

    [Fact]
    public void decimal型の減算_引数が境界値を超過()
    {
        UnitOfAmount uom = new(5);
        UnitOfAmount bef = uom;

        UnitOfAmount ans = uom.Minus(1);

        // イミュータブルであることの確認
        Assert.Equal(5, uom.Value);
        Assert.Equal(bef, uom);
        // 演算結果の確認
        Assert.Equal(4, ans.Value);
    }

    [Fact]
    public void decimal型の減算_差が境界値未満()
    {
        UnitOfAmount uom = new(998);
        UnitOfAmount bef = uom;

        UnitOfAmount ans = uom.Minus(997);

        // イミュータブルであることの確認
        Assert.Equal(998, uom.Value);
        Assert.Equal(bef, uom);
        // 演算結果の確認
        Assert.Equal(1, ans.Value);
    }

    [Fact]
    public void decimal型の減算_差が境界値と等価()
    {
        UnitOfAmount uom = new(998);
        UnitOfAmount bef = uom;

        UnitOfAmount ans = uom.Minus(998);

        // イミュータブルであることの確認
        Assert.Equal(998, uom.Value);
        Assert.Equal(bef, uom);
        // 演算結果の確認
        Assert.Equal(0, ans.Value);
    }

    [Fact]
    public void decimal型の減算_差が境界値を超過()
    {
        UnitOfAmount uom = new(998);
        UnitOfAmount bef = uom;

        // 例外の確認
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => uom.Minus(999));
        // イミュータブルであることの確認
        Assert.Equal(998, uom.Value);
        Assert.Equal(bef, uom);
    }

    [Fact]
    public void UnitOfAmount型の減算_差が境界値未満()
    {
        UnitOfAmount uom1 = new(998);
        UnitOfAmount uom2 = new(997);
        UnitOfAmount bef1 = uom1;
        UnitOfAmount bef2 = uom2;

        UnitOfAmount ans = uom1.Minus(uom2);

        // イミュータブルであることの確認
        Assert.Equal(998, uom1.Value);
        Assert.Equal(bef1, uom1);
        Assert.Equal(997, uom2.Value);
        Assert.Equal(bef2, uom2);
        // 演算結果の確認
        Assert.Equal(1, ans.Value);
    }

    [Fact]
    public void UnitOfAmount型の減算_差が境界値と等価()
    {
        UnitOfAmount uom1 = new(998);
        UnitOfAmount uom2 = new(998);
        UnitOfAmount bef1 = uom1;
        UnitOfAmount bef2 = uom2;

        UnitOfAmount ans = uom1.Minus(uom2);

        // イミュータブルであることの確認
        Assert.Equal(998, uom1.Value);
        Assert.Equal(bef1, uom1);
        Assert.Equal(998, uom2.Value);
        Assert.Equal(bef2, uom2);
        // 演算結果の確認
        Assert.Equal(0, ans.Value);
    }

    [Fact]
    public void UnitOfAmount型の減算_差が境界値を超過()
    {
        UnitOfAmount uom1 = new(998);
        UnitOfAmount uom2 = new(999);
        UnitOfAmount bef1 = uom1;
        UnitOfAmount bef2 = uom2;

        // 例外の確認
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => uom1.Minus(uom2));
        // イミュータブルであることの確認
        Assert.Equal(998, uom1.Value);
        Assert.Equal(bef1, uom1);
        Assert.Equal(999, uom2.Value);
        Assert.Equal(bef2, uom2);
    }

}
