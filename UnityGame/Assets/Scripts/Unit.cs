using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//UnityEngine.Random.Range

public interface IUnit
{
	// ��������� ��������
	public uint Id { get; }
	public string Name { get; }
	public int Health { get; }
	public int MaxHP { get; }
	public uint Damage { get; }
	public uint Defense { get; }
	public uint AttackRange { get; }
	public float AbilityChance { get; }

	public uint Cost { get; }

	// ! ��� ���������� �������� ����� ��������� ��������� ����
	// public IItem Equipment { get; set; }

	// ��������� ������
	public void SpecialAbility(Line line, uint index, char friendly);
	public List<IUnit> GetFriendlyFront(char friendly, Line line);
	public List<IUnit> GetEnemyFront(char friendly, Line line);
	public void Hit(uint damageTaken);
	public bool IsAbility();
	public void Heal(uint receivedHealing);
}

abstract public class Unit : IUnit
{
	protected uint _id;
	protected string _name;
	protected int _hp;
	protected int _maxHP;
	protected uint _dmg;
	protected uint _def;
	protected uint _range;
	protected uint _cost;
	protected float _chance;

	public uint Id => _id;
	public string Name => _name;
	public int Health => _hp;
	public int MaxHP => _maxHP;
	public uint Damage => _dmg;
	public uint Defense => _def;
	public uint AttackRange => _range;
	public uint Cost => _cost;
	public float AbilityChance => _chance;

	public abstract void SpecialAbility(Line line, uint index, char friendly);

	public bool IsAbility()//����� ����������� �������� ������ ��� ���
    {
		float chance = UnityEngine.Random.Range(0.0f, 1.0f);
		if(_chance < chance)
        {
			return true;
        }
		return false;
    }

	public List<IUnit> GetFriendlyFront(char friendly, Line line)
    {
		if(friendly == 'l')
        {
			return line.leftFront;
        }
		return line.rightFront;
    }

	public List<IUnit> GetEnemyFront(char friendly, Line line)
    {
		if (friendly == 'r')
		{
			return line.leftFront;
		}
		return line.rightFront;
	}

	public void Hit(uint damageTaken)
	{
		//�������� ������� �� ������
		//���� ������ �� ��������� ����� � ����� �����
		//����� �����)
		_hp = (int)UnityEngine.Mathf.Max(_hp - damageTaken + _def, 0);
		if(_hp == 0)
        {
			//��������� ��������� ����� � ������ �����
        }
	}

	public void Heal(uint receivedHealing)
	{
		_hp = (int)UnityEngine.Mathf.Min(_hp + receivedHealing, _maxHP); 
	}
}

class Wizard : Unit
{
	public Wizard()
	{
		_id = 3;
		_name = "���";
		_hp = 4;
		_maxHP = 0;
		_dmg = 5;
		_def = 2;
		_range = 3;
		_cost = 10;
		_chance = 20;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		/*
		if(IsAbility())
        {
            if (frienly[(int)index - 1] != null)
            {
                uint newId = frienly[(int)index - 1].Id;

            }
        }
		*/
	}
}

class Tumbleweed : Unit
{
	public Tumbleweed()
    {
		_id = 4;
		_name = "��������-����";
		_hp = 15;
		_maxHP = 0;
		_dmg = 0;
		_def = 3;
		_range = 0;
		_cost = 15;
		_chance = 0;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
    {
		//������ �� ��������� �����
    }
}

class Kamenuka : Unit
{
	public Kamenuka()
	{
		_id = 13;
		_name = "��������";
		_hp = 15;
		_maxHP = 0;
		_dmg = 0;
		_def = 9;
		_range = 0;
		_cost = 15;
		_chance = 0;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		//������ �� ��������� �����
	}
}





// �������� ���������� ���������� IUnit
class TestUnit : Unit
{
	public TestUnit()
	{}

	public TestUnit(uint id, int hp, uint dmg, uint def, uint range, uint cost, float chance)
	{
		_id = id; // ���������������� �������� id �� 0 �� max uint
		_name = "�������� �����";
		_hp = hp;
		_dmg = dmg;
		_def = def;
		_range = range;
		_cost = cost;
		_chance = chance;
	}

	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		// �����-�� ��������
	}
}

class Warior : Unit
{
	public Warior()
	{
		_id = 1; // ���������������� �������� id �� 0 �� max uint
		_name = "Воин";
		_hp = 5;
		_dmg = 1;
		_def = 1;
		_range = 1;
		_cost = 2;
		_chance = 0.3f;
	}

	private bool Dress(Kinght warior)
	{
		List<String> ups = new List<String> {"Шлем", "Щит", "Пика", "Коняшка"};
		foreach (var ammunition in warior.DressedAmmunitions)
		{
			ups.Remove(ammunition.Name);
		}

		if (ups.Count > 0)
		{
			int index = (int) (UnityEngine.Random.Range(0.0f, .99f) * ups.Count);
			switch (ups[index])
			{
				case "Шлем" : 
					warior.DressedAmmunitions.Add(new Hemlet());
					break; 
				case "Щит" : 
					warior.DressedAmmunitions.Add(new Shield());
					break; 
				case "Пика" : 
					warior.DressedAmmunitions.Add(new Peak());
					break; 
				case "Коняшка" : 
					warior.DressedAmmunitions.Add(new Horse());
					break;
				default : break;
			}
			return true;
		}

		return false;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		List<IUnit> friends = this.GetFriendlyFront(friendly, line);
		if (friends.Count > 1)
		{
			bool dressFlg = false;
			if (index > 0 && friends[(int) index - 1].Id == 5)
			{
				dressFlg = Dress((Kinght)friends[(int) index - 1]);
			}
			if (!dressFlg && index < friends.Count - 1 && friends[(int) index + 1].Id == 5)
			{
				Dress((Kinght)friends[(int) index + 1]);
			}
		}
	}
}

class Archer : Unit
{
	public Archer()
	{
		_id = 2; // ���������������� �������� id �� 0 �� max uint
		_name = "Лучник";
		_hp = 5;
		_dmg = 2;
		_def = 0;
		_range = 3;
		_cost = 4;
		_chance = 0.25f;
	}

	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if (IsAbility())
		{
			if (this.GetEnemyFront(friendly, line).Count >= 2)
			{
				this.GetEnemyFront(friendly, line)[1].Hit(_dmg);
			}
		}
	}
}

class Kinght : Unit
{
	public Kinght()
	{
		_id = 5; // ���������������� �������� id �� 0 �� max uint
		_name = "Рыцарь";
		_hp = 10;
		_maxHP = 10;
		_dmg = 4;
		_def = 1;
		_range = 1;
		_cost = 12;
		_chance = 0;
	}

	public List<IAmmunition> DressedAmmunitions { get; } = new List<IAmmunition>();
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		// �����-�� ��������
	}
}

class Musketeer : Unit
{
	public Musketeer()
	{
		_id = 7; // ���������������� �������� id �� 0 �� max uint
		_name = "Мушкетер";
		_hp = 12;
		_maxHP = 12;
		_dmg = 5;
		_def = 3;
		_range = 3;
		_cost = 6;
		_chance = 0.15f;
	}

	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if (IsAbility())
		{
			foreach (var unit in this.GetEnemyFront(friendly, line))
			{
				unit.Hit(_dmg);
			}
		}
	}
}

class Healer : Unit
{
	public Healer()
	{
		_id = 6; // ���������������� �������� id �� 0 �� max uint
		_name = "Целитель";
		_hp = 6;
		_maxHP = 6;
		_dmg = 1;
		_def = 2;
		_range = 1;
		_cost = 8;
		_chance = 0.33f;
	}

	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if (IsAbility())
		{
			List<IUnit> friends = this.GetFriendlyFront(friendly, line);
			IUnit friend = null;
			if (friends.Count > 1)
			{
				if (index > 0)
					friend = friends[(int)index - 1];
				if (index < friends.Count - 1 && (friend == null || friend.Health < friends[(int) index + 1].Health))
					friend = friends[(int) index + 1];
				
				if (friend != null)
					friend.Heal((uint)friend.Health);
			}
		}
	}
}