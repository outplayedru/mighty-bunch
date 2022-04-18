using System;

namespace LazyInit
{

    class xy
    {
        int x;
        int y;

        public xy()
        {
            x = 0;
            y = 0;
        }
    }

    class Test
    {
        private xy zeroCord = null;
        private int initCount = 0;
        public xy ZeroPoint
        {
            get 
            { 
                if (zeroCord == null) 
                { 
                    zeroCord = new xy();
                    initCount++; 
                } 
                return zeroCord; 
            }
        }
        public int getCount{get { return initCount; }}
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Test();
            var b = new xy();
            Console.WriteLine(a.getCount);
            Console.WriteLine("Вызов функции нулевой координаты");
            b = a.ZeroPoint;
            Console.WriteLine(a.getCount);
            Console.WriteLine("Повторный вызов фурнкции нулевой координаты");
            b = a.ZeroPoint;
            Console.WriteLine(a.getCount);
        }
    }
}
