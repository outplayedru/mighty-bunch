using System;

namespace AbstarctFactory
{
    
    public interface IFactory
    {
        IAbstractSofa CreateSofa();

        IAbstractTable CreateTable();
    }

    public interface IAbstractSofa
    {
        string SitOnSofa();
    }

    public interface IAbstractTable
    {

        string PutAnyOnTable();

        string Combination(IAbstractSofa combine);
    }

    class ModernFactory : IFactory
    {
        public IAbstractSofa CreateSofa()
        {
            return new ModernSofa();
        }

        public IAbstractTable CreateTable()
        {
            return new ModernTable();
        }
    }

    
    class VictorianFactory : IFactory
    {
        public IAbstractSofa CreateSofa()
        {
            return new VictorianSofa();
        }

        public IAbstractTable CreateTable()
        {
            return new VictorianTable();
        }
    }

    //Делаем диваны
    
    class ModernSofa : IAbstractSofa
    {
        public string SitOnSofa()
        {
            return "Посидел на модерн диване.";
        }
    }

    class VictorianSofa : IAbstractSofa
    {
        public string SitOnSofa()
        {
            return "Посидел на викторианском диване.";
        }
    }

    //Делаем столы
    
    class ModernTable : IAbstractTable
    {
        public string PutAnyOnTable()
        {
            return "Положил что-то на модерн стол.";
        }

        
        public string Combination(IAbstractSofa combine)
        {
            string ret = "Положил что-то на модерн стол когда : " + combine.SitOnSofa();

            return ret;
        }
    }

    class VictorianTable : IAbstractTable
    {
        public string PutAnyOnTable()
        {
            return "Положил что-то на викторианский стол";
        }

        public string Combination(IAbstractSofa combine)
        {
            string ret = "Положил что-то на викторианский стол когда : " + combine.SitOnSofa();

            return ret;
        }
    }

    class Test
    {
        public void TestModern()
        {
            Console.WriteLine("Проверка первого типа");
            FactoryCall(new ModernFactory());
            Console.WriteLine();
        }

        public void TestVictorian()
        {
            Console.WriteLine("Проверка второго типа");
            FactoryCall(new VictorianFactory());
            Console.WriteLine();
        }

        public void FactoryCall(IFactory factory)
        {
            var a = factory.CreateSofa();
            var b = factory.CreateTable();

            Console.WriteLine(b.PutAnyOnTable());
            Console.WriteLine(b.Combination(a));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Test().TestModern();
            new Test().TestVictorian();
        }
    }
}
