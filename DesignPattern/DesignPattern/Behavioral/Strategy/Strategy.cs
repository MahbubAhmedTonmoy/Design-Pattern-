using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Behavioral.Strategy
{
    /// <summary>
    ///  রানটাইমে কোনও এলগরিদম অথবা কোনও অবজেক্টের কমন বিহেভিওর চেঞ্জ করতে এই প্যাটার্নের জুড়ি নেই ।
    /// </summary>
    public class Strategy
    {
    }
    public enum CouponCodes
    {
        FlatRateCode,
        PercentageCode,
        PercentageLimitCode
    }
   
    public interface IDiscountStrategyProvider
    {
        IDiscountStrategy CreateDiscountStratigy(int couponCode, long productPrice);
    }

    public class DiscountStrategyProvider : IDiscountStrategyProvider
    {
        public IDiscountStrategy CreateDiscountStratigy(int couponCode, long productPrice)
        {
            IDiscountStrategy stratigy;

            stratigy = couponCode switch
            {
                (int)CouponCodes.FlatRateCode => new FlatRateDiscountStratigy(productPrice),
                (int)CouponCodes.PercentageCode => new FlatRateDiscountStratigy(productPrice),
                (int)CouponCodes.PercentageLimitCode => new FlatRateDiscountStratigy(productPrice),
                _ => throw new NotImplementedException(),
            };
            return stratigy;
        }
    }
    public interface IDiscountStrategy
    {
        long Discount();
    }
    public class FlatRateDiscountStratigy : IDiscountStrategy
    {
        private const long FIXED_AMOUNT = 300;
        private readonly long _price;

        public FlatRateDiscountStratigy(long price)
        {
            _price = price;
        }

        public long Discount()
        {
            return _price - FIXED_AMOUNT;
        }
    }
    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly long _price;
        private const decimal PercentDiscountRate = 15; // 15%

        public PercentageDiscountStrategy(long price)
        {
            _price = price;
        }

        public long Discount()
        {
            decimal percent = PercentDiscountRate / 100;

            return Convert.ToInt64(_price * percent);
        }
    }
    public class PercentageLimitDiscountStrategy : IDiscountStrategy
    {
        private readonly long _price;
        private const long DiscountAmountLimit = 300;
        private const decimal DiscountRateInPercent = 15; //15%

        public PercentageLimitDiscountStrategy(long price)
        {
            _price = price;
        }

        public long Discount()
        {
            decimal discountPercent = DiscountRateInPercent / 100;

            long discountValue = Convert.ToInt64(_price * discountPercent);

            if (discountValue > DiscountAmountLimit)
            {
                return DiscountAmountLimit;
            }

            return discountValue;
        }
    }
}
