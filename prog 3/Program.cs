using System;

public class TimeConverter
{
    static void Main(string[] args)
    {
        double value;
        string unitFrom, unitTo;

        
        Console.Write("Enter a time value: ");
        value = double.Parse(Console.ReadLine());

        Console.Write("Enter the unit of the time value (seconds, minutes, hours, days): ");
        unitFrom = Console.ReadLine().ToLower();

        Console.Write("Enter the unit to convert to (seconds, minutes, hours, days, months [approximate]): ");
        unitTo = Console.ReadLine().ToLower();

        
        double convertedValue = Convert(value, unitFrom, unitTo);

     
        if (convertedValue.ToString() == "Infinity")
        {
            Console.WriteLine("Invalid conversion between {0} and {1}.", unitFrom, unitTo);
        }
        else
        {
            if (unitTo == "months")
            {
                Console.WriteLine("Important note: Month conversion is approximate based on a 30-day month.");
            }
            Console.WriteLine("{0} {1} is equivalent to {2:##.##} {3}", value, unitFrom, convertedValue, unitTo);
        }
    }

    static double Convert(double value, string fromUnit, string toUnit)
    {
        
        var conversionFactors = new Dictionary<string, Dictionary<string, double>>()
        {
            { "seconds", new Dictionary<string, double>() { { "minutes", 1.0 / 60 }, { "hours", 1.0 / 3600 }, { "days", 1.0 / 86400 } } },
            { "minutes", new Dictionary<string, double>() { { "seconds", 60.0 }, { "hours", 1.0 / 60 }, { "days", 1.0 / 1440 } } },
            { "hours", new Dictionary<string, double>() { { "seconds", 3600.0 }, { "minutes", 60.0 }, { "days", 1.0 / 24 } } },
            { "days", new Dictionary<string, double>() { { "seconds", 86400.0 }, { "minutes", 1440.0 }, { "hours", 24.0 }, { "months", 1.0 / 30.0 } } }, // Added month conversion
        };

        
        if (!conversionFactors.ContainsKey(fromUnit) || !conversionFactors[fromUnit].ContainsKey(toUnit))
        {
            return double.NaN;
        }

        // Perform the conversion
        return value * conversionFactors[fromUnit][toUnit];
    }
}


