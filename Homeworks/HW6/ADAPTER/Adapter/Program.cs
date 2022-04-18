using System;

namespace task6
{
    interface Irifle
    {
        void ShootBurst();
    }

    interface Ibow
    {
        void ShootArrow();
    }

    class Gun : Irifle
    {
        int BurstLen = 3;

        public void ShootBurst()
        {
            for (int i = 0; i < BurstLen; i++)
                Console.WriteLine("*Bang*");
        }
    }

    class Bow : Ibow
    {
        public void ShootArrow()
        {
            Console.WriteLine("*Свист стрелы*");
        }
    }

    class Shooting
    {
        public void Shoot(Irifle rifle)
        {
            rifle.ShootBurst();
        }
    }

    class AdapterBowToRifle : Irifle
    {
        Bow bow;
        public AdapterBowToRifle(Bow a)
        {
            bow = a;
        }

        public void ShootBurst()
        {
            bow.ShootArrow();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Shooting shooting = new Shooting();
            Gun gun = new Gun();
            Bow bow = new Bow();
            Irifle bowToGun = new AdapterBowToRifle(bow);
            shooting.Shoot(gun);
            shooting.Shoot(bowToGun);
        }
    }
}

