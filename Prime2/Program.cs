using static System.Console;

namespace Prime2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteLine("Input upper limit of circular prime to be found:");
            var f = false;
            int n;
            do
            {
                f = int.TryParse(ReadLine() ?? "", out n) && (n > 0);
                if (!f)
                    WriteLine("Wrong input! Try again.");
            } while (!f);
            var cp = CircularPrime.FindCircularPrimes(n);
            foreach (var i in cp)
                Write($"{i} ");
            WriteLine($"\n{cp.Length}");
            ReadKey();
        }
    }
}