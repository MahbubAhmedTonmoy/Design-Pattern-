using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Behavioral.Strategy
{
    public class StrategyTest
    {
        private FlatRateDiscountStratigy flatRateDiscountStratigy;
        private PercentageDiscountStrategy percentageDiscountStrategy;
        private PercentageLimitDiscountStrategy percentageLimitDiscountStrategy;

        public StrategyTest()
        {

        }
        [Fact]
        public void ShouldDiscountFixedAmount()
        {
            long price = 1000;
            flatRateDiscountStratigy = new FlatRateDiscountStratigy(price);
            long discount = flatRateDiscountStratigy.Discount();
            Assert.Equal(700, discount);
        }

        [Fact]
        public void ShouldDiscountPercentage()
        {
            long price = 1000;
            percentageDiscountStrategy = new PercentageDiscountStrategy(price);
            long discount = percentageDiscountStrategy.Discount();
            Assert.Equal(150, discount);
        }

        [Fact]
        public void ShouldDiscountPercentageLimitPolicy()
        {
            long price = 10000;
            percentageLimitDiscountStrategy = new PercentageLimitDiscountStrategy(price);
            long discount = percentageLimitDiscountStrategy.Discount();
            Assert.Equal(300, discount);
        }
    }
}
