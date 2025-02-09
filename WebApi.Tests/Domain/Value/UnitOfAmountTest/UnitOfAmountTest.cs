using System;
using WebApi.Domain.Value;
using Xunit;

namespace WebApi.Tests.Domain.Value.UnitOfAmountTest
{
    public class UnitOfAmountTest
    {
        [Fact]
        public void コンストラクタ_正常値()
        {
            var unit = new UnitOfAmount(500);
            Assert.Equal(500, unit.Value);
        }

        [Fact]
        public void コンストラクタ_境界値_0()
        {
            var unit = new UnitOfAmount(0);
            Assert.Equal(0, unit.Value);
        }

        [Fact]
        public void コンストラクタ_境界値_1000()
        {
            var unit = new UnitOfAmount(1000);
            Assert.Equal(1000, unit.Value);
        }

        [Fact]
        public void コンストラクタ_異常値_マイナス()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new UnitOfAmount(-1));
        }

        [Fact]
        public void コンストラクタ_異常値_1001()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new UnitOfAmount(1001));
        }

        [Fact]
        public void 加算メソッド_正常値()
        {
            var unit = new UnitOfAmount(500);
            var result = unit.Add(200);
            Assert.Equal(700, result.Value);
        }

        [Fact]
        public void 加算メソッド_オーバーロード_正常値()
        {
            var unit1 = new UnitOfAmount(500);
            var unit2 = new UnitOfAmount(200);
            var result = unit1.Add(unit2);
            Assert.Equal(700, result.Value);
        }

        [Fact]
        public void 減算メソッド_正常値()
        {
            var unit = new UnitOfAmount(500);
            var result = unit.Minus(200);
            Assert.Equal(300, result.Value);
        }

        [Fact]
        public void 減算メソッド_オーバーロード_正常値()
        {
            var unit1 = new UnitOfAmount(500);
            var unit2 = new UnitOfAmount(200);
            var result = unit1.Minus(unit2);
            Assert.Equal(300, result.Value);
        }

        [Fact]
        public void 加算オペラント_正常値()
        {
            var unit1 = new UnitOfAmount(500);
            var unit2 = new UnitOfAmount(200);
            var result = unit1 + unit2;
            Assert.Equal(700, result.Value);
        }

        [Fact]
        public void 減算オペラント_正常値()
        {
            var unit1 = new UnitOfAmount(500);
            var unit2 = new UnitOfAmount(200);
            var result = unit1 - unit2;
            Assert.Equal(300, result.Value);
        }

        [Fact]
        public void 比較演算子_大なり_正常値()
        {
            var unit1 = new UnitOfAmount(500);
            var unit2 = new UnitOfAmount(200);
            Assert.True(unit1 > unit2);
        }

        [Fact]
        public void 比較演算子_大なり_異常値()
        {
            var unit1 = new UnitOfAmount(200);
            var unit2 = new UnitOfAmount(500);
            Assert.False(unit1 > unit2);
        }

        [Fact]
        public void 比較演算子_小なり_正常値()
        {
            var unit1 = new UnitOfAmount(200);
            var unit2 = new UnitOfAmount(500);
            Assert.True(unit1 < unit2);
        }

        [Fact]
        public void 比較演算子_小なり_異常値()
        {
            var unit1 = new UnitOfAmount(500);
            var unit2 = new UnitOfAmount(200);
            Assert.False(unit1 < unit2);
        }

        [Fact]
        public void 比較演算子_大なりイコール_正常値()
        {
            var unit1 = new UnitOfAmount(500);
            var unit2 = new UnitOfAmount(500);
            Assert.True(unit1 >= unit2);
        }

        [Fact]
        public void 比較演算子_大なりイコール_異常値()
        {
            var unit1 = new UnitOfAmount(200);
            var unit2 = new UnitOfAmount(500);
            Assert.False(unit1 >= unit2);
        }

        [Fact]
        public void 比較演算子_小なりイコール_正常値()
        {
            var unit1 = new UnitOfAmount(500);
            var unit2 = new UnitOfAmount(500);
            Assert.True(unit1 <= unit2);
        }

        [Fact]
        public void 比較演算子_小なりイコール_異常値()
        {
            var unit1 = new UnitOfAmount(500);
            var unit2 = new UnitOfAmount(200);
            Assert.False(unit1 <= unit2);
        }
    }
}