using System.Collections.Generic;
Dictionary<string, int> frequencies = new Dictionary<string, int>();

frequencies.Add("код", 2);
frequencies.Add("тест", 1);
frequencies["код"] = 3;
frequencies["план"] = 1;

System.Console.WriteLine(frequencies.Count);
System.Console.WriteLine(frequencies["код"]);

// Dictionary<string, int> repeated = new Dictionary<string, int>();
// repeated.Add["код", 1];
// repeated.Add["код", 2];


Dictionary<string, int> lookup = new Dictionary<string, int>
{
    {"код", 2},
     {"тест", 1}
};

System.Console.WriteLine(lookup.ContainsKey("код"));
System.Console.WriteLine(lookup.ContainsKey("план"));

if (lookup.TryGetValue("код", out int count))
{
    System.Console.WriteLine($"Найдено: {count}");
}
else
{
    System.Console.WriteLine("Слово не найдено");
}

void PrintFrequencies(Dictionary<string, int> frequencies)
{
    if (frequencies.Count == 0)
    {
        System.Console.WriteLine("Нет слов для анализа");
        return;
    }

    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        System.Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
}

PrintFrequencies(lookup);

Console.WriteLine(lookup.Remove("тест"));
Console.WriteLine(lookup.Remove("план"));
Console.WriteLine(lookup.Count);

lookup.Clear();
Console.WriteLine(lookup.Count);


Dictionary<string, int> checkedWords = new Dictionary<string, int>
{
    { "код", 2 }
};

if (checkedWords.TryGetValue("план", out int count1))
{
    Console.WriteLine($"Найдено: {count1}");
}
else
{
    Console.WriteLine("Слово не найдено");
}

if (checkedWords.TryGetValue("код", out int count2))
{
    Console.WriteLine($"Найдено: {count2}");
}
else
{
    Console.WriteLine("Слово не найдено");
}


HashSet<string> uniqueWords = new HashSet<string>();

Console.WriteLine(uniqueWords.Add("код"));
Console.WriteLine(uniqueWords.Add("тест"));
Console.WriteLine(uniqueWords.Add("код"));
Console.WriteLine(uniqueWords.Count);


Console.WriteLine(uniqueWords.Contains("код"));
Console.WriteLine(uniqueWords.Contains("план"));
Console.WriteLine(uniqueWords.Remove("тест"));
Console.WriteLine(uniqueWords.Remove("план"));
Console.WriteLine(uniqueWords.Count);

uniqueWords.Clear();
Console.WriteLine(uniqueWords.Count);

foreach (string word in uniqueWords)
{
    Console.WriteLine(word);
}


void AddWord(Dictionary<string, int> frequencies, string word)
{
    if (frequencies.TryGetValue(word, out int count))
    {
        frequencies[word] = count + 1;
    }
    else
    {
        frequencies.Add(word, 1);
    }
}


Dictionary<string, int> testFrequencies = new Dictionary<string, int>();

AddWord(testFrequencies, "код");
AddWord(testFrequencies, "тест");
AddWord(testFrequencies, "код");

PrintFrequencies(testFrequencies);
Console.WriteLine(testFrequencies.Count);


int SumFrequencies(Dictionary<string, int> frequencies)
{
    int sum = 0;
    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        sum += entry.Value;
    }
    
    return sum;
}