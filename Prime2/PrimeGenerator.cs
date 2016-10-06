using System.Collections.Generic;

namespace Prime2
{
    /// <summary>
    ///     Class that uses to generate prime numbers from 2 to given
    /// </summary>
    internal static class PrimeGenerator
    {
        /// <summary>
        ///     Methods that generate primes that less than given number
        /// </summary>
        /// <param name="n">Upper limit</param>
        /// <returns>Array of primes below limit</returns>
        public static int[] GeneratePrimes(int n)
        {
            var primes = new List<NumWithFlags> {new NumWithFlags(2)};
            for (var i = 3; i < n; i += 2)
                primes.Add(new NumWithFlags(i));
            for (var i = 1; i < primes.Count; i++)
            {
                var num = primes[i].Num;
                for (var j = i*(num + 1); (j < primes.Count) && (j > 0); j += num)
                    primes[j].Flag = true;
            }
            var ans = new List<int>();
            foreach (var numWithFlagse in primes)
                if (!numWithFlagse.Flag)
                    ans.Add(numWithFlagse.Num);
            return ans.ToArray();
        }

        /// <summary>
        ///     Class that presntes pair of number and boolean flag
        /// </summary>
        private class NumWithFlags
        {
            public NumWithFlags(int n)
            {
                Num = n;
                Flag = false;
            }

            public int Num { get; }

            /// <summary>
            ///     Flag used markup number, in this project to mark is prime or not
            /// </summary>
            public bool Flag { get; set; }
        }
    }
}