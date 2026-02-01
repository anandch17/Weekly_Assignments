using System;


class ElectricityBill
{
    static void Main()
    {
        Console.Write("Customer ID        : ");
        string id = Console.ReadLine();

        Console.Write("Customer Name      : ");
        string name = Console.ReadLine();

        Console.Write("Address            : ");
        string address = Console.ReadLine();

        Console.Write("Phone Number       : ");
        string phone = Console.ReadLine();

        Console.Write("Email ID           : ");
        string email = Console.ReadLine();

        Console.Write("Connection Type    : ");
        string type = Console.ReadLine();

        Console.Write("Previous Reading   : ");
        int prev = Convert.ToInt32(Console.ReadLine());

        Console.Write("Current Reading    : ");
        int curr = Convert.ToInt32(Console.ReadLine());

        int units = curr - prev;
        double energyCharge = CalculateEnergyCharge(units);
        double meterRent = GetMeterRent(type);
        double totalAmount = energyCharge + meterRent;

        PrintBill(id, name, address, phone, email, type,
                  prev, curr, units, energyCharge, meterRent, totalAmount);
    }

    static double CalculateEnergyCharge(int units)
    {
        double amount = 0;

        if (units <= 100)
            amount = units * 1.5;
        else if (units <= 250)
            amount = 100 * 1.5 + (units - 100) * 2.5;
        else if (units <= 550)
            amount = 100 * 1.5 + 150 * 2.5 + (units - 250) * 4.5;
        else
            amount = 100 * 1.5 + 150 * 2.5 + 300 * 4.5 + (units - 550) * 7.5;

        return amount;
    }

    static double GetMeterRent(string type)
    {
        switch (type.ToLower())
        {
            case "industrial": return 2500;
            case "business": return 1500;
            case "domestic": return 1000;
            case "agricultural": return 0;
            default: return 0;
        }
    }

    static void PrintBill(string id, string name, string address,
                          string phone, string email, string type,
                          int prev, int curr, int units,
                          double energy, double rent, double total)
    {
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("|            ELECTRICITY BILL                  |");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine($"| Customer ID      : {id}|");
        Console.WriteLine($"| Name             : {name}|");
        Console.WriteLine($"| Address          : {address}|");
        Console.WriteLine($"| Phone            : {phone}|");
        Console.WriteLine($"| Email            : {email}|");
        Console.WriteLine($"| Connection Type  : {type}|");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine($"| Previous Reading : {prev}|");
        Console.WriteLine($"| Current Reading  : {curr}|");
        Console.WriteLine($"| Units Consumed   : {units}|");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine($"| Energy Charges   : ₹{energy}|");
        Console.WriteLine($"| Meter Rent       : ₹{rent}|");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine($"| TOTAL BILL       : ₹{total}|");
        Console.WriteLine("------------------------------------------------");


        
    
    }
}
