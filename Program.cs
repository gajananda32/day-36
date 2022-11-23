using System.Text;

namespace EmployeePayRoll
{
    public class program
    {
        public static void Main(string[] args)
        {
            string[] words = CreateWordArray(@"https://www.gutenberg.org/files/54700/54700-0.txt");
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Bengin first TASK...");
                GetLongestWord(words);
            },
            () =>
            {
                Console.WriteLine("Bengin Secon d task ...");
                GetMostCommonWords(words);
            },
                () =>
                {
                    Console.WriteLine("Bengin third task ");
                    GetCountForWord(words, "sleep");
                });
        }
        private static void GetCountForWord(string[] words,string term)
        {
            var findword = from word in words
                           where word.ToUpper().Contains(term.ToUpper())
                           select word;
            Console.WriteLine($@"Task 3 .... the word ""{term}""occurs{findword.Count()}times.");
        }
        private static string GetLongestWord(string[] words)
        {
            var longestWord = (from w in words
                               orderby w.Length descending
                               select w).First();
            Console.WriteLine($"Task 1 -- the longest word is {longestWord}.");
            return longestWord;
        }
        private static void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;
            var commonwords = frequencyOrder.Take(10);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task 2 -- The most common words are:");
            foreach (var v in commonwords)
            {
                sb.AppendLine(" "+v);
            }
            Console.WriteLine(sb.ToString());
        }
        static string[] CreateWordArray( string uri)
        {
            Console.WriteLine($"retriving from {uri}");
            string s = new System.Net.WebClient().DownloadString(uri);
            return s.Split(new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
