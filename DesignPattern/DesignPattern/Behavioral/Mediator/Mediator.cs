using FluentAssertions.Equivalency;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Behavioral.Mediator
{
    /// <summary>
    /// Colleague
    /// </summary>
    public interface IFamilyExpenseProvider
    {
        int ProvideAmmount();
    }

    public class Father : IFamilyExpenseProvider
    {
        public int ProvideAmmount()
        {
            return 100;
        }
    }
    public class GrandFather : IFamilyExpenseProvider
    {
        public int ProvideAmmount()
        {
            return 200;
        }
    }

    /// <summary>
    /// Mediator
    /// </summary>
    public interface IMediator
    {
        int Collector();
    }

    public class Mother : IMediator
    {
        private readonly List<IFamilyExpenseProvider> familyExpenseProvider  = new List<IFamilyExpenseProvider>();
        public Mother()
        {
            familyExpenseProvider.Add(new Father());
            familyExpenseProvider.Add(new GrandFather());
        }
        public int Collector()
        {
            int total = 0;
            foreach(var i in familyExpenseProvider)
            {
                total += i.ProvideAmmount();
            }
            return total;
        }
    }
}
