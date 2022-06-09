using System;

namespace decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Ammo ammo1 = new RU7();
            ammo1 = new BP(ammo1); // 7.62 БП
            Console.WriteLine("Тип патрона:{0}", ammo1.Name);
            Console.WriteLine("Калибр:{0}\n", ammo1.GetCaliber());

            Ammo ammo2 = new RU7();
            ammo2 = new PS(ammo2); // 7.62 ПС
            Console.WriteLine("Тип патрона:{0}", ammo2.Name);
            Console.WriteLine("Калибр:{0}\n", ammo2.GetCaliber());

            Ammo ammo3 = new RU5();
            ammo3 = new BP(ammo3); // 5.45 БП
            Console.WriteLine("Тип патрона:{0}", ammo3.Name);
            Console.WriteLine("Калибр:{0}\n", ammo3.GetCaliber());

            Ammo ammo4 = new RU5();
            ammo4 = new PS(ammo4); // 5.45 ПС
            Console.WriteLine("Тип патрона:{0}", ammo4.Name);
            Console.WriteLine("Калибр:{0}\n", ammo4.GetCaliber());
        }

        abstract class Ammo
        {
            public Ammo(string n)
            {
                this.Name = n;
            }
            public string Name { get; protected set; }
            public abstract string GetCaliber();
              
        }
        
        class RU7 : Ammo
        { 
            public RU7() : base("7 ")
            {}
            public override string GetCaliber()
            {
                return "7.62x39";
            }
        }

        class RU5 : Ammo
        {
            public RU5() : base("5 ")
            { }
            public override string GetCaliber()
            {
                return "5.45x39";
            }
        }

        abstract class AmmoDecorator : Ammo
        {
            protected Ammo ammo;
            public AmmoDecorator(string n, Ammo ammo) : base(n)
            {
                this.ammo = ammo;
            }
        }

        class BP : AmmoDecorator
        {
            public BP(Ammo a):base(a.Name + "БП", a)
            {}
            public override string GetCaliber()
            {
                return ammo.GetCaliber();
            }
        }

        class PS : AmmoDecorator
        {
            public PS(Ammo a) : base(a.Name + "ПС", a)
            { }
            public override string GetCaliber()
            {
                return ammo.GetCaliber();
            }
        }
    }
}
