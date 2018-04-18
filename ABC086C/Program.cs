using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ABC086C
{
    public class Program
    {
        struct Point
        {
            public readonly int T;
            public readonly int X;
            public readonly int Y;

            public Point(int t, int x, int y)
            {
                T = t;
                X = x;
                Y = y;
            }
        }

        void Solve(StreamScanner ss, StreamWriter sw)
        {
            //---------------------------------
            var N = ss.Next(int.Parse);
            var TXY = ss.Next(int.Parse, 3, N).Select(a => new Point(a[0], a[1], a[2]));
            var points = new[] {new Point(0, 0, 0)}.Concat(TXY).OrderBy(p => p.T).ToArray();

            var ans = true;
            for (var i = 1; i <= N; i++) ans &= CanGo(points[i - 1], points[i]);
            sw.WriteLine(ans ? "Yes": "No");
            //---------------------------------
        }

        bool CanGo(Point bp, Point np)
        {
            var di = np.T - bp.T;
            var dist = Math.Abs(np.X - bp.X) + Math.Abs(np.Y - bp.Y);
            return dist <= di && (di - dist) % 2 == 0;
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