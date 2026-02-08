using System.Security.Cryptography.X509Certificates;

namespace Requirement3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the registration no. to be validated:");
            string registrationNo = Console.ReadLine();
            if (ValidateRegistrationNo(registrationNo))
            {
                Console.WriteLine("Registration No. is valid");
            }
            else
            {
                               Console.WriteLine("Registration No. is invalid");
            }

        }

        public static bool ValidateRegistrationNo(string registrationNo)
        {
            if (string.IsNullOrEmpty(registrationNo))
            {
                return false;
            }
            string pattern = @"^[A-Z]{2}\s\d{1,2}\s[A-Z]{1,2}\s\d{4}$";
            return System.Text.RegularExpressions.Regex.IsMatch(registrationNo, pattern);




        }
    }
}

