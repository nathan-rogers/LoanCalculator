using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //    When complete, uncommenting these lines should result in two tables being displayed to the console.
            //creates new tables for any type of loan created
            Amortization table1 = new Amortization(new SerialLoan(10000, 0.02, 10));
            Amortization table2 = new Amortization(new AnnuityLoan(10000, 0.02, 10));
            //calls print function in amortization
            table1.Print();
            table2.Print();
            

        }
    }


    //Creates a template for interfacing with different kinds of loans
    public interface ILoan
    {
        //define the interface for a Loan here
        //Principal of loan
        double Principal { get; set; }
        //rate of interest
        double Rate { get; set; }
        //number of periods to pay
        int Periods { get; set; }

        //payment number
        double Payment(int n);
        //calculates interest on loan
        double Interest(int n);
        //calculates outstanding balance
        double Outstanding(int n);
        double Repayment(int n);
    }

    /// <summary>
    /// Creates serial loan class
    /// </summary>
    public class SerialLoan : ILoan
    {
      
        public double Principal { get; set; }
        public double Rate { get; set; }
        public int Periods { get; set; }
        //implement the interface here for a Serial Loan.
        //constructor
        public SerialLoan(double principalAmount, double rate, int periods)
        {
            this.Principal = principalAmount;
            this.Rate = rate;
            this.Periods = periods;

        }
        //calculates this payment
        public double Payment(int n)
        {
            return Repayment(n) + Interest(n);
        }

        //calculate interest based on current total
        public double Interest(int n)
        {
            return Outstanding(n - 1) * Rate;
        }
        //remaining balance
        public double Outstanding(int n)
        {
            return Repayment(0) * (Periods - n);
        }
        public double Repayment(int n)
        {
            return Principal / Periods;
        }





    }
    //logic for annuity loan
    public class AnnuityLoan: ILoan
    {
        public double Principal { get; set; }
        public double Rate { get; set; }
        public int Periods { get; set; }

       
        //implement the interface here for an Annuity Loan
        //constructor
        public AnnuityLoan(double principal, double rate, int period)
        {
            this.Principal = principal;
            this.Rate = rate;
            this.Periods = period;

        }
        //calculate payment
        public double Payment(int n)
        {
            return Principal * Rate / (1 - Math.Pow(1 + Rate, -Periods));
        }
        //calculate current interest based on total
        public double Interest(int n)
        {
            return Outstanding(n-1) * Rate;
        }
        //calculate remaining balance
        public double Outstanding(int n){
            return Principal * Math.Pow(1 + Rate, n) - Payment(0) * (Math.Pow(1 + Rate, n) - 1) / Rate;
        }
        public double Repayment(int n)
        {
            return Payment(n) + Interest(n);
        }
    }


    //Display calculations
    public class Amortization
    {
        //instance of ILoan
        private ILoan loan;
        public Amortization(ILoan loan)
        {
            this.loan = loan;
        }
        //print results
        public void Print()
        {
            Console.WriteLine("Principal: {0, 18:F}", loan.Principal);
            Console.WriteLine("Rate of interest: {0, 10:F}%", loan.Rate * 100);
            Console.WriteLine("Number of periods: {0, 10:D}\n", loan.Periods);
            Console.WriteLine("{0, 7}{1, 15}{2, 15}{3, 15}{4, 15}", "Periods", "Payment", "Repayment", "Interest", "Outstanding");
            for (int n = 1; n <= loan.Periods; ++n)
            {
                Console.WriteLine("{0, 7:D}{1, 15:F}{2, 15:F}{3, 15:F}{4, 15:F}", n, loan.Payment(n), loan.Repayment(n), loan.Interest(n), loan.Outstanding(n));
            }
        }
    }


}
