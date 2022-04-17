/*3)Write a console Application for banking domain, having Account class with data members 
 * as account number, customer name, balance . It should have Withdraw and Deposit methods 
 * for performing banking transaction. It should also define UnderBalance, BalanceZero events.
 * These events would be raised when balance of account is less than certain amount and equal to zero respectively.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public delegate void Notify();
    class Account
    {
        public int Account_Number;
        public string Customer_Name;
        public int Balance;
        public int Amount;
        public event Notify ZeroBal;
        public event Notify UnderBal;
        public void Deposit()
        {
            Console.WriteLine("enter account number");
            Account_Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter customer name");
            Customer_Name = Console.ReadLine();
            Console.WriteLine("enter amount to disposit");
            Balance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("balance amount is" + ":" + Balance);
        }
        public virtual void WithDraw()
        {
            Console.WriteLine("enter amount to withdrawl");
            Amount = Convert.ToInt32(Console.ReadLine());
            Balance = Balance - Amount;
            if (Balance == 0)
            {
                OnZeroBal();
            }
            if (Balance < 1000)
            {
                Onunderbal();
            }
            else if (Balance > 1000)
            {
                Console.WriteLine("your balance is" + ":" + Balance);
            }

        }
        protected virtual void OnZeroBal()
        {
            ZeroBal?.Invoke();
        }
        protected virtual void Onunderbal()
        {
            UnderBal?.Invoke();
        }
    }

    class client
    {
        public static void Main()
        {
            Account account = new Account();
            account.ZeroBal += ZeroBalance;
            account.UnderBal += underbalace;
            account.Deposit();
            account.WithDraw();
            Console.ReadKey();
        }
        public static void ZeroBalance()
        {
            Console.WriteLine("Balance is zero");
        }
        public static void underbalace()
        {
            Console.WriteLine("Now you have Underbalance");
        }
    }
}
