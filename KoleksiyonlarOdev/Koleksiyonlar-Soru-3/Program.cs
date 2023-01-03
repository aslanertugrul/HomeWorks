char[] vowels = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };
List<char> vowelArr = new List<char>(){ };
Console.Write("Cümle giriniz: ");

String sentence=Console.ReadLine().ToLower();

foreach (var character in sentence)
{
    foreach (var item in vowels)
    {
        if (character == item)
            vowelArr.Add(character);
    }
}

foreach (var item in vowelArr)
{
    Console.Write(item);
    Console.Write(" ");
}



