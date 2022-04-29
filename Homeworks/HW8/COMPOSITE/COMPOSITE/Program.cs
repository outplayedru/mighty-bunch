using System;
using System.Collections.Generic;

namespace COMPOSITE
{
    class Program
    {
        abstract class Component
        {
            protected string name;

            public Component(string name)
            {
                this.name = name;
            }

            public virtual void Add(Component component) { }
            public virtual void Remove(Component component) { }
            public virtual void Print() {Console.WriteLine(name);}
        }

        class Mammoths:Component
        {
            private List<Component> list = new List<Component>();
            public Mammoths(string name) : base(name){ }
            public override void Add(Component component)
            {
                list.Add(component);
            }
            public override void Remove(Component component)
            {
                list.Remove(component);
            }
            public override void Print()
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Print();
                }
            }
        }

        class Money : Component
        {
            public Money (string rubles) : base(rubles) { }
        }

        static void Main(string[] args)
        {
            
        }
    }
}
