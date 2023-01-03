/*
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

arr.Sort();
double lowerAvg=0;
double higherAvg=0;

for (int i=0;i<=2;i++) {
    lowerAvg += (arr[i]/3);
}
arr.Reverse();
for (int i=0;i<=2;i++) {
    higherAvg += (arr[i]/3);
}

Console.WriteLine($"En büyük sayıların ortalaması {higherAvg} 'dir.");
Console.WriteLine($"En küçük sayıların ortalaması {lowerAvg} 'dir.");
Console.WriteLine($"Ortalamaların toplamı {higherAvg+lowerAvg} 'dir.");
*/