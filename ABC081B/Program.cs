using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ABC081B
{
    public class Program
    {
        void Solve(StreamScanner ss, StreamWriter sw)
        {
            //---------------------------------
            var N = ss.Next(int.Parse);
            var A = ss.Next(int.Parse, N);

            var prime = new Prime(100000);
            sw.WriteLine(A.Min(a => prime.Factorize(a).Count(p => p == 2)));
            //---------------------------------
        }

        static void Main()
        {
            var ss = new StreamScanner(new StreamReader(Console.OpenStandardInput()));
            var sw = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            new Program().Solve(ss, sw);
            sw.Flush();
        }

        static readonly Func<string, string> String = s => s;
    }

    public class Prime
    {
        readonly List<int> primes;
        public IReadOnlyList<int> List { get { return primes; } }

        public Prime(int max)
        {
            primes = new List<int>();

            var sieve = new bool[max + 1];
            for (var i = 2; i <= max; i++)
            {
                if (sieve[i]) continue;
                primes.Add(i);
                for (var j = i * 2; j <= max; j += i) sieve[j] = true;
            }
        }

        public bool Is(int n)
        {
            return n > 1 && primes.TakeWhile(p => p * p <= n).All(p => n % p != 0);
        }

        public IEnumerable<int> Factorize(int n)
        {
            foreach (var p in primes.TakeWhile(p => p * p <= n))
            {
                while (n % p == 0)
                {
                    n /= p;
                    yield return p;
                }
            }
            if (n != 1) yield return n;
        }

        public int EulersTotient(int n)
        {
            return Factorize(n).Distinct().Aggregate(n, (ret, x) => ret / x * (x - 1));
        }
    }

    public class StreamScanner
    {
        static readonly char[] Sep = {' '};
        readonly Queue<string> buffer = new Queue<string>();
        readonly TextReader textReader;

        public StreamScanner(TextReader textReader)
        {
            this.textReader = textReader;
        }

        public T Next<T>(Func<string, T> parser)
        {
            if (buffer.Count != 0) return parser(buffer.Dequeue());
            var nextStrings = textReader.ReadLine().Split(Sep, StringSplitOptions.RemoveEmptyEntries);
            foreach (var nextString in nextStrings) buffer.Enqueue(nextString);
            return Next(parser);
        }

        public T[] Next<T>(Func<string, T> parser, int x)
        {
            var ret = new T[x];
            for (var i = 0; i < x; ++i) ret[i] = Next(parser);
            return ret;
        }

        public T[][] Next<T>(Func<string, T> parser, int x, int y)
        {
            var ret = new T[y][];
            for (var i = 0; i < y; ++i) ret[i] = Next(parser, x);
            return ret;
        }
    }
}