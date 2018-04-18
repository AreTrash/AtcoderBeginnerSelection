using System;
using System.IO;
using System.Collections.Generic;

namespace ABC049C
{
    public class Program
    {
        static readonly IEnumerable<string> Words = new[] {"dream", "dreamer", "erase", "eraser"};
        string S;

        void Solve(StreamScanner ss, StreamWriter sw)
        {
            //---------------------------------
            S = ss.Next(s => s);
            sw.WriteLine(Dfs(0) ? "YES" : "NO");
            //---------------------------------
        }

        bool Dfs(int index)
        {
            if (index == S.Length) return true;

            var ret = false;
            foreach (var word in Words)
            {
                if (index + word.Length > S.Length || S.Substring(index, word.Length) != word) continue;
                ret |= Dfs(index + word.Length);
            }
            return ret;
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