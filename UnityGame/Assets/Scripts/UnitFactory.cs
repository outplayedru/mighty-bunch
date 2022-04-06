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
{
	public override IUnit Create()
	{
		return new Kamenuka();
	}
}

class TumbleweedCreator : UnitFactory
{
	public override IUnit Create()
	{
		return new Tumbleweed();
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
		if (id == 4)
        {
			uintFactory = new TumbleweedCreator();
		}
		if (id == 13)
        {
			uintFactory = new KamenukaCreator();
		}
		return uintFactory.CreateUnit();
	}
}
