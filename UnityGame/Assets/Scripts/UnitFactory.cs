using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitFactory
{
	public IUnit CreateUnit()
	{
		IUnit unit = Create();
		// ����� ��� ��������������� ������������
		return unit;
	}

	public abstract IUnit Create();
}

// ������ ���������� ��������� ��� ������� ������
class TestUnitCreator :UnitFactory
{
	public override IUnit Create()
	{
		return new TestUnit();
	}
}

<<<<<<< HEAD
class WizardCreator : UnitFactory
=======
class WariorCreator :UnitFactory
{
	public override IUnit Create()
	{
		return new Warior();
	}
}

class ArcherCreator :UnitFactory
{
	public override IUnit Create()
	{
		return new Archer();
	}
}

class KinghtCreator :UnitFactory
{
	public override IUnit Create()
	{
		return new Kinght();
	}
}

class HealerCreator :UnitFactory
{
	public override IUnit Create()
	{
		return new Healer();
	}
}

class MusketeerCreator :UnitFactory
{
	public override IUnit Create()
	{
		return new Musketeer();
	}
}

class KamenukaCreator : UnitFactory
>>>>>>> d56e42984a30816e2a0b66ca0e9d188aca0e68d0
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
	// ������ ��������� ����
	// �� �� ��� ��� �������� (�)������
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
