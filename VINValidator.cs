//Algorithm taken from the wikipedia page https://en.wikipedia.org/wiki/Vehicle_identification_number#Check-digit_calculation
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
	        string vin = "1VWBP7A37DC046870";
	        //string vin = "12345678901234567";

	        Console.WriteLine($"VIN Provided: {vin}");
	        char checkDigit = getCheckDigit(vin);
	        Console.WriteLine($"Check digit: {checkDigit}");
	        Console.WriteLine($"Is valid VIN: {validate(vin)}");
	        Console.ReadLine();
        }

	    private static int transliterate(char c)
	    {
		    return "0123456789.ABCDEFGH..JKLMN.P.R..STUVWXYZ".IndexOf(c) % 10;
	    }

	    private static char getCheckDigit(String vin)
	    {
		    String map = "0123456789X";
		    String weights = "8765432X098765432";
		    int sum = 0;
		    for (int i = 0; i < 17; ++i)
		    {
			    sum += transliterate(vin[i]) * map.IndexOf(weights[i]);
		    }
		    return map[sum % 11];
	    }

	    private static bool validate(String vin)
	    {
		    if (vin.Length != 17) return false;
		    return getCheckDigit(vin) == vin[8];
	    }
	}
}
