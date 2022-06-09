using System;
using System.Collections.Generic;

namespace COMPOSITE
{
    class Program
    {
        abstract class MMM
        {
            protected string name;

            public MMM(string name)
            {
                this.name = name;
            }

            public virtual void Add(MMM component) { }
            public virtual void Remove(MMM component) { }
            public virtual void Print() {Console.WriteLine(name);}
        }

        class Mammoths:MMM
        {
            private List<MMM> list = new List<MMM>();
            public Mammoths(string name) : base(name){ }
            public override void Add(MMM component)
            {
                list.Add(component);
            }
            public override void Remove(MMM component)
            {
                list.Remove(component);
            }
            public override void Print()
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(name);
                    list[i].Print();
                    Console.WriteLine();
                }
            }
        }

        class Money : MMM
        {
            public Money (string rubles) : base(rubles) { }
        }

        static void Main(string[] args)
        {
            MMM Piramida = new Mammoths("Пирамида");
            MMM LeonidGolubkov = new Mammoths("Первый участник пирамиды");
            MMM Ivan = new Mammoths("Друг Леонида");
            MMM Oleg = new Mammoths("Брат Ивана");
            MMM LeonidMoney = new Money("100000");
            MMM IvanMoney = new Money("77777");
            MMM OlegMoney = new Money("194821");
            Oleg.Add(OlegMoney);
            Ivan.Add(Oleg);
            Ivan.Add(IvanMoney);
            LeonidGolubkov.Add(Ivan);
            LeonidGolubkov.Add(LeonidMoney);
            Piramida.Add(LeonidGolubkov);
            Piramida.Print();

        }
    }
}
