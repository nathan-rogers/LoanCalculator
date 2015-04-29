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

        //    Amortization table1 = new Amortization(new SerialLoan(10000, 0.02, 10));
        //    Amortization table2 = new Amortization(new AnnuityLoan(10000, 0.02, 10));

        //    table1.Print();
        //    table2.Print();

        }
    }

 

    public interface ILoan {
        //defind the interface for a Loan here
    }


    public class SerialLoan
    {
        //implement the interface here for a Serial Loan
    }

    public class AnnuityLoan
    {
        //implement the interface here for an Annuity Loan
    }

   

    public class Amortization
    {
        private ILoan loan;
        public Amortization(ILoan loan)
        {
            this.loan = loan;
        }

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
