using System;

namespace Observer
{
    class Program
    {

        static void Main(string[] args)
        {

            Calculator C1 = new Calculator();
            Calculator C2 = new Calculator();
            C1.CalculateSomething();
            C2.CalculateSomething();

        }
    }


    public delegate void ReportProgressMethod(int progress);
    public class Calculator
    {
        int k = 10;

        public event ReportProgressMethod ProgressMethod = ProgressReport;
        


        public static void ProgressReport(int progress)
        {
            Console.WriteLine(progress);
        }
  

        public void CalculateSomething()
        {

            for (int i = 0; i <= 8; i++)
            {
                if (i == 4)
                {
                    ProgressMethod(50);
                }

                for (int j = 0; j <= 5; j++)
                {
                    if (j == 5)
                    {
                        ProgressMethod(k);
                        k += 10;
                    }

                }

            }
            ProgressMethod(100);
        }

    }
}
