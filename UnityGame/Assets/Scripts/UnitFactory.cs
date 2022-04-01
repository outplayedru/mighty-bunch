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
		return uintFactory.CreateUnit();
	}
}
