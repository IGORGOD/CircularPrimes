using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Prime2
{
    /// <summary>
    ///     Class that uses to find circular primes that are below given upper limit
    /// </summary>
    internal static class CircularPrime
    {
        /// <summary>
        ///     Method that find circular primes from primes that are below given upper limit
        /// </summary>
        /// <param name="n">Upper limit</param>
        /// <returns>Array of circular primes</returns>
        public static int[] FindCircularPrimes(int n)
        {
            var primes = new List<int>(PrimeGenerator.GeneratePrimes(n));
            var ans = new List<int>();
            for (var i = 0; i < primes.Count;)
            {
                var num = primes[i];
                var buf = new List<int> {num};
                var sp = num.ToString();
                var b = true;
                if (num > 10)
                {
                    if (!Regex.IsMatch(sp, "[024568]"))
                    {
                        var bufN = num;
                        for (var j = 0; j < sp.Length - 1; j++)
                        {
                            bufN = bufN/10 + bufN%10*(int) Math.Pow(10, sp.Length - 1);
                            if (!buf.Contains(bufN))
                                buf.Add(bufN);
                            if (!primes.Contains(bufN))
                            {
                                b = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        b = false;
                    }
                    foreach (var i1 in buf)
                    {
                        if (b)
                            ans.Add(i1);
                        primes.Remove(i1);
                    }
                }
                else
                {
                    ans.Add(primes[i]);
                    primes.RemoveAt(i);
                }
            }
            ans.Sort();
            return ans.ToArray();
        }
    }
}