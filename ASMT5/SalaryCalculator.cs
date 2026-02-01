namespace SalaryCalculator
{
    public class Class1
    {
      public static double CalculateNetSalary(double basicSalary)
        {
            try
            {
                if(basicSalary < 0)
                {
                    throw new ArgumentException("Basic salary cannot be negative.");
                }

                double hra = 0.20 * basicSalary; 
                double da = 0.50 * basicSalary;
                double pf = 0;

                if (basicSalary >= 15000)
                {
                    pf = 0.12 * basicSalary;
                }

                double netSalary = basicSalary + hra + da - pf;
                return netSalary;

            } 
            catch (Exception ex)
            {
                throw new ApplicationException("Error in salary calculation: " + ex.Message);
            }

        }
    }
}
