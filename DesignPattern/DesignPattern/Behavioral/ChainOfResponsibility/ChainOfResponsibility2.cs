using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavioral.ChainOfResponsibility
{
    class ChainOfResponsibility2
    {
    }
    public abstract class Handler
    {
        public Handler nextrequesthandler;
        public void nextHandler(Handler resquestHandler)
        {
            this.nextrequesthandler = resquestHandler;
        }
        public abstract void DispatchTaka(long amount);
    }
    public class TwoThousandHandler : Handler
    {
        public override void DispatchTaka(long amount)
        {
            long numberofNotesToBeDispatched = amount / 2000;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand notes are dispatched by TwoThousandHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand note is dispatched by TwoThousandHandler");
                }
            }
            long pendingAmountToBeProcessed = amount % 2000;
            if (pendingAmountToBeProcessed > 0)
            {
                nextrequesthandler.DispatchTaka(pendingAmountToBeProcessed);
            }
        }
    }
    public class FiveHundredHandler : Handler
    {
        public override void DispatchTaka(long amount)
        {
            long numberofNotesToBeDispatched = amount / 500;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand notes are dispatched by TwoThousandHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand note is dispatched by TwoThousandHandler");
                }
            }
            long pendingAmountToBeProcessed = amount % 500;
            if (pendingAmountToBeProcessed > 0)
            {
                nextrequesthandler.DispatchTaka(pendingAmountToBeProcessed);
            }
        }
    }
    public class OneHundredHandler : Handler
    {
        public override void DispatchTaka(long amount)
        {
            long numberofNotesToBeDispatched = amount / 100;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand notes are dispatched by TwoThousandHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand note is dispatched by TwoThousandHandler");
                }
            }
            long pendingAmountToBeProcessed = amount % 100;
            if (pendingAmountToBeProcessed > 0)
            {
                nextrequesthandler.DispatchTaka(pendingAmountToBeProcessed);
            }
        }
    }

    public class ATM
    {
        private TwoThousandHandler twoThousandHandler = new TwoThousandHandler();
        private FiveHundredHandler fiveHundredHandler = new FiveHundredHandler();
        private OneHundredHandler hundredHandler = new OneHundredHandler();

        public ATM()
        {
            // Prepare the chain of Handlers
            twoThousandHandler.nextHandler(fiveHundredHandler);
            fiveHundredHandler.nextHandler(hundredHandler);
        }
        public void withdraw(long requestedAmount)
        {
            twoThousandHandler.DispatchTaka(requestedAmount);
        }
    }

    public class client
    {
        public void main()
        {
            ATM atm = new ATM();
            atm.withdraw(4600);
            Console.WriteLine("\n Requested Amount 1900");
            atm.withdraw(1900);
            Console.WriteLine("\n Requested Amount 600");
            atm.withdraw(600);
        }
    }
}
