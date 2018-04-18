using System;
using System.IO;
using System.Collections.Generic;

namespace ABC086A
{
    public class Program
    {
        void Solve(StreamScanner ss, StreamWriter sw)
        {
            //---------------------------------
            var A = ss.Next(int.Parse);
            var B = ss.Next(int.Parse);
            sw.WriteLine((A * B) % 2 == 0 ? "Even" : "Odd");
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