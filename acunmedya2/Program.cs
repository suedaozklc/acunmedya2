using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine(SumOfDigits(123));
        Console.WriteLine(GetValidNumber());
        Console.WriteLine(GetAgeCategory(25));
        Console.WriteLine(string.Join(", ", FindDuplicates(new int[] { 1, 2, 3, 2, 4, 5, 5 })));
        Console.WriteLine(FindLongestAndShortestWords(new string[] { "apple", "banana", "kiwi" }));
        Console.WriteLine(string.Join(", ", SortSentence("merhaba dünya bu bir test")));

        string[] arr = { "one", "two" };
        ExpandStringArray(ref arr, "three");
        Console.WriteLine(string.Join(", ", arr));

        ReverseWords();
        RandomNumbersList();

        List<int> nums = new List<int> { 5, 15, 8, 20 };
        Console.WriteLine(string.Join(", ", RemoveSmallNumbers(nums)));

        List<int> grades = new List<int> { 45, 70, 30, 90 };
        Console.WriteLine(string.Join(", ", AdjustGrades(grades)));
    }

    static int SumOfDigits(int number)
    {
        int sum = 0;
        for (; number > 0; number /= 10)
        {
            sum += number % 10;
        }
        return sum;
    }

    static int GetValidNumber()
    {
        int number;
        do
        {
            Console.Write("10 ile 100 arasında bir sayı girin: ");
            number = int.Parse(Console.ReadLine());
        } while (number < 10 || number > 100);
        return number;
    }

    static string GetAgeCategory(int age)
    {
        return age switch
        {
            <= 12 => "Çocuk",
            <= 19 => "Genç",
            <= 64 => "Yetişkin",
            _ => "Yaşlı"
        };
    }

    static List<int> FindDuplicates(int[] arr)
    {
        return arr.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
    }

    static (string, string) FindLongestAndShortestWords(string[] words)
    {
        return (words.OrderByDescending(w => w.Length).First(), words.OrderBy(w => w.Length).First());
    }

    static string[] SortSentence(string sentence)
    {
        return sentence.Split(' ').OrderBy(w => w).ToArray();
    }

    static void ExpandStringArray(ref string[] arr, string newElement)
    {
        Array.Resize(ref arr, arr.Length + 1);
        arr[^1] = newElement;
    }

    static void ReverseWords()
    {
        List<string> words = new();
        string input;
        Console.WriteLine("Kelimeleri girin (boş bırakınca durur):");
        while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
        {
            words.Add(input);
        }
        words.Reverse();
        Console.WriteLine(string.Join(" ", words));
    }

    static void RandomNumbersList()
    {
        List<int> numbers = new();
        Console.WriteLine("Sayıları girin (geçersiz giriş bitirir):");
        int num;
        while (int.TryParse(Console.ReadLine(), out num))
        {
            numbers.Add(num);
        }
        numbers.Sort();
        Console.WriteLine($"Ortalama: {numbers.Average()}\nSıralı: {string.Join(", ", numbers)}");
    }

    static List<int> RemoveSmallNumbers(List<int> numbers)
    {
        numbers.RemoveAll(n => n < 10);
        return numbers;
    }

    static List<int> AdjustGrades(List<int> grades)
    {
        return grades.Select(g => g < 50 ? 50 : g).ToList();
    }
}


        // 12-15. Metotlar hakkında açıklamalar
        /*
        * Metot (Fonksiyon) Nedir? 
        * - Bir işlemi gerçekleştiren kod bloklarıdır.
        * Metotları Neden Kullanırız?
        * - Tekrarı önlemek, kodun düzenini ve okunabilirliğini artırmak için.
        * Geriye Değer Döndüren Metot ile Void Metot Farkı
        * - return kullanan metot bir değer döndürür, void metot ise sadece işlem yapar.
        * Metot Parametreleri Nasıl Çalışır?
        * - Değer (value) ve referans (ref, out) türünde olabilir.
        */
    