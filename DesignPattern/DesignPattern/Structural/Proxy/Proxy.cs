using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Proxy
{
    class Proxy
    {
    }

    public interface IBank
    {
        double Withdraw(double ammount);
    }

    public class BankService : IBank
    {
        public double Withdraw(double ammount)
        {
            return ammount;
        }

        
    }

    public class ATMService : IBank
    {
        private readonly IBank bank = new BankService();

        public double Withdraw(double ammount)
        {
            if(ammount > 25000)
            {
                bank.Withdraw(ammount);
            }
            return ammount;
        }
    }
}
