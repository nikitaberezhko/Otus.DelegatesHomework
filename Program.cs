using System.Collections;

namespace Otus.DelegatesHomework;

static class Program
{
    static void Main()
    {
        // Пункт 1
        {
            List<string> list = new List<string>{ "1,0", "4,0", "2,0", "3,0" };
            
            Console.WriteLine(list.GetMax<string>(x => float.Parse(x))); // Пункт 5 - Вывод
            Console.ReadKey();
        }
        // Пункт 2,3
        {
            FileFinder fileFinder = new FileFinder();
            fileFinder.FileFound += (s, e) =>
            {
                // Пункт 4
                (s as FileFinder)!.CancelFinding();
                Console.WriteLine(e.Name); // Пункт 5 - Вывод
            };
            
            fileFinder.Find("./");
        }
    }
    
    
    static T? GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) 
        where T : class
    {
        try
        {
            var parsed = collection.OfType<T>().Select(convertToNumber);
            return collection.OfType<T>()
                .ToList()
                .ElementAt(parsed.ToList().IndexOf(parsed.Max()));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return default(T);
    }
}