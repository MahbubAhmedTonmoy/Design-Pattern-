using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Structural.Adapter
{
    public interface IClientTarget
    {
        int Sum(int[] numbers);
    }

    public class Adapter: IClientTarget
    {
        private readonly IAdaptee adaptee;
        public Adapter(IAdaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public int Sum(int[] numbers)
        {
            return adaptee.Sum(numbers.ToList());
        }
    }

    public interface IAdaptee
    {
        int Sum(List<int> numbers);
    }
    public class Adaptee : IAdaptee
    {
        public int Sum(List<int> numbers)
        {
            var ans = 0;
            foreach (int i in numbers)
            {
                ans += i;
            }
            return ans;
        }
    }
}
