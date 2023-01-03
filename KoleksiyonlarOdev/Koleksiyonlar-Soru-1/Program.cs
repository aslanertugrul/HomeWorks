/*
List<int> prime = new List<int>() { };
List<int> notPrime = new List<int>() { };
List<int> arr = new List<int>() { };

while(arr.Count < 20)
{
	try
	{
		Console.Write("Sayi giriniz: ");
        int number = Convert.ToInt32(Console.ReadLine());
		if(number < 0)
		{
			Console.WriteLine("Pozitif tam sayı giriniz.");
		}
		else
		{
            arr.Add(number);
		}
    }
	catch (Exception)
	{
		Console.WriteLine("Sayi formatinda bir değer giriniz.");
	}
}

foreach (var item in arr)
{
    int n = 0;
    for (int i = 2; i < item; i++)
    {

        if (item % i == 0)
        {
            n++;
        }
    }

        if (n == 0)
        {
        prime.Add(item);
        }
        else
        {
        notPrime.Add(item);
        }
}

prime.Sort();
prime.Reverse();
notPrime.Sort();
notPrime.Reverse();

double primeTotal=0;
double notPrimeTotal=0;

Console.WriteLine("Asal sayılar : ");
foreach (var item in prime)
{
    Console.Write(item);
    Console.Write(" - ");
    primeTotal += item;
}

Console.WriteLine("");

Console.WriteLine("Asal olmayan sayılar : ");
foreach (var item in notPrime)
{
    Console.Write(item);
    Console.Write(" - ");
    notPrimeTotal += item;
}

Console.WriteLine("");
Console.WriteLine($"Asal olan {prime.Count} adet sayi vardir. Ortalamaları {primeTotal/prime.Count} 'dur");
Console.WriteLine($"Asal olmayna olan {notPrime.Count} adet sayi vardir. Ortalamaları {notPrimeTotal/notPrime.Count} 'dur");
*/