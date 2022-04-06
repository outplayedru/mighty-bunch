using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitFactory
{
	public IUnit CreateUnit()
	{
		IUnit unit = Create();
		// Место для дополнительного функционтала
		return unit;
	}

	public abstract IUnit Create();
}

// Пример обьявления создателя для тестого класса
class TestUnitCreator :UnitFactory
{
	public override IUnit Create()
	{
		return new TestUnit();
	}
}

class WizardCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Wizard();
	}
}

class TumbleweedCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Tumbleweed();
	}
}

class SkeletonCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Skeleton();
	}
}

class SpearmanCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Spearman();
	}
}

class NecromancerCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Necromancer();
	}
}

class WarlockCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Warlock();
	}
}

class DemonCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Demon();
	}
}

class KamenukaCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Kamenuka();
	}
}

class KotopulkaCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Kotopulka();
	}
}

class PolitePersonCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new PolitePerson();
	}
}


class Barracks
{
	// Просто проходите мимо
	// Не на что тут смотреть (с)Полина
	//public delegate IUnit CreateDelegate();
	//public static Dictionary<uint, CreateDelegate> CreateDictionary = 
	//	new Dictionary<uint, CreateDelegate> 
	//	{ 
	//		{1,new CreateDelegate } 
	//	};

	UnitFactory uintFactory;

	public IUnit Birth(int id)
	{
		if (id == 0)
		{
			uintFactory = new TestUnitCreator();
		}
		if (id == 3)
		{
			uintFactory = new WizardCreator();
		}
		if (id == 4)
        {
			uintFactory = new TumbleweedCreator();
		}
		if(id == 8)
        {
			uintFactory = new SkeletonCreator();
		}
		if(id == 9)
        {
			uintFactory = new SpearmanCreator();
        }
        if (id == 10)
        {
            uintFactory = new NecromancerCreator();
        }
		if (id == 11)
		{
			uintFactory = new WarlockCreator();
		}
		if (id == 12)
		{
			uintFactory = new DemonCreator();
		}
		if (id == 13)
        {
			uintFactory = new KamenukaCreator();
		}
		if (id == 14)
		{
			uintFactory = new KotopulkaCreator();
		}
		if (id == 15)
		{
			uintFactory = new PolitePersonCreator();
		}
		return uintFactory.CreateUnit();
		
	}
}
