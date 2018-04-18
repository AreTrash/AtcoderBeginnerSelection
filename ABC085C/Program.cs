using System;
using System.IO;
using System.Collections.Generic;

namespace ABC085C
{
    public class Program
    {
        void Solve(StreamScanner ss, StreamWriter sw)
        {
            //---------------------------------
            var N = ss.Next(int.Parse);
            var Y = ss.Next(int.Parse);

            for (var i = 0; i <= N; i++)
            {
                for (var j = 0; j <= N - i; j++)
                {
                    var k = N - i - j;
                    if (i * 10000 + j * 5000 + k * 1000 == Y)
                    {
                        sw.WriteLine($"{i} {j} {k}");
                        return;
                    }
                }
            }

            sw.WriteLine("-1 -1 -1");
            //---------------------------------
        }

        static void Main()
        {
            var ss = new StreamScanner(new StreamReader(Console.OpenStandardInput()));
            var sw = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            new Program().Solve(ss, sw);
            sw.Flush();
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
    }
}