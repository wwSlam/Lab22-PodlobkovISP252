using System.Collections.Generic;

Console.WriteLine(">>> Анализ слов <<<");
Console.WriteLine();

HashSet<string> excludedWords = new HashSet<string> { "и", "в", "на" };

Console.Write("Слово для добавления в исключения: ");
string addWord = Console.ReadLine()!.Trim().ToLowerInvariant();
if (excludedWords.Add(addWord))
    Console.WriteLine("Исключение добавлено");
else
    Console.WriteLine("Такое исключение уже есть");

Console.Write("Слово для удаления из исключений: ");
string removeWord = Console.ReadLine()!.Trim().ToLowerInvariant();
if (excludedWords.Remove(removeWord))
    Console.WriteLine("Исключение удалено");
else
    Console.WriteLine("Такого исключения нет");
Console.WriteLine($"Количество исключений: {excludedWords.Count}");

Console.Write("Введите текст: ");
string text = Console.ReadLine() ?? "";

string[] words = text.ToLowerInvariant()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> frequencies = new Dictionary<string, int>();
foreach (string word in words)
{
    if (excludedWords.Contains(word))
        continue;
    AddWord(frequencies, word);
}

int total = words.Length;
int accounted = SumFrequencies(frequencies);
int skipped = total - accounted;

Console.WriteLine();
Console.WriteLine($"Исходная строка: [{text}]");
Console.WriteLine($"Всего слов: {total}");
Console.WriteLine($"Пропущено слов: {skipped}");
Console.WriteLine($"Учтено слов: {accounted}");
Console.WriteLine($"Разных учтённых слов: {frequencies.Count}");
Console.WriteLine();
Console.WriteLine("Частоты слов:");
PrintFrequencies(frequencies);

Console.Write("Слово для поиска: ");
string searchWord = Console.ReadLine()!.Trim().ToLowerInvariant();
if (frequencies.TryGetValue(searchWord, out int found))
    Console.WriteLine($"Количество вхождений: {found}");
else
    Console.WriteLine("Слово не найдено");


void AddWord(Dictionary<string, int> frequencies, string word)
{
    if (frequencies.TryGetValue(word, out int count))
        frequencies[word] = count + 1;
    else
        frequencies.Add(word, 1);
}

int SumFrequencies(Dictionary<string, int> frequencies)
{
    int sum = 0;
    foreach (KeyValuePair<string, int> entry in frequencies)
        sum += entry.Value;
    return sum;
}

void PrintFrequencies(Dictionary<string, int> frequencies)
{
    if (frequencies.Count == 0)
    {
        Console.WriteLine("Нет слов для анализа");
        return;
    }

    foreach (KeyValuePair<string, int> entry in frequencies)
        Console.WriteLine($"{entry.Key}: {entry.Value}");
}

int CountFrequentWords(Dictionary<string, int> frequencies, int limit)
{
    int count = 0;
    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        if (entry.Value >= limit)
            count++;
    }
    return count;
}

System.Console.WriteLine();
System.Console.WriteLine("вариант 1");

Console.Write("Введите limit (1–100): ");
int limit = int.Parse(Console.ReadLine()!);

int frequentCount = CountFrequentWords(frequencies, limit);
Console.WriteLine($"Слов с частотой не меньше {limit}: {frequentCount}");

