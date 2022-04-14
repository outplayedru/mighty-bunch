using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//UnityEngine.Random.Range

public interface IUnit
{
	// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ
	public uint Id { get; }
	public string Name { get; }
	public int Health { get; }
	public int MaxHP { get; }
	public uint Damage { get; }
	public uint Defense { get; }
	public uint AttackRange { get; }
	public float AbilityChance { get; }

	public uint Cost { get; }

	// ! пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ
	// public IItem Equipment { get; set; }

	// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ
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

	public bool IsAbility()//пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅ
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

	public virtual void Hit(uint damageTaken)
	{
		//пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ
		//пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
		//пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ)
		_hp = (int)UnityEngine.Mathf.Max(_hp - damageTaken + _def, 0);
		if(_hp == 0)
        {
			//пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
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
		_name = "Wizard";
		_hp = 4;
		_maxHP = 0;
		_dmg = 5;
		_def = 2;
		_range = 3;
		_cost = 10;
		_chance = 0.2f;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if(IsAbility())
        {
			List<IUnit> friend = GetFriendlyFront(friendly, line);
			Barracks a = new Barracks();
			int newId = -1;

			if (index - 1 >= 0)
            {
                newId = (int)friend[(int)index - 1].Id;
            }
			else if (index + 1 < friend.Count)
			{
				newId = (int)friend[(int)index + 1].Id;
			}
			if (newId != -1)
            {
				if (friendly == 'l')
				{
					line.addLeft(a.Birth(newId));
				}
                else
                {
					line.addRight(a.Birth(newId));
				}
			}	
		}
	}
}

class Tumbleweed : Unit
{
	public Tumbleweed()
    {
		_id = 4;
		_name = "Tumbleweed";
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
		//пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
    }
}

class Skeleton : Unit
{
	public Skeleton()
	{
		_id = 8;
		_name = "Skeleton";
		_hp = 5;
		_maxHP = 5;
		_dmg = 1;
		_def = 1;
		_range = 1;
		_cost = 1;
		_chance = 0.2f;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		//Ничего не произошло хыыыы
	}
}

class Spearman : Unit
{
	public Spearman()
	{
		_id = 9;
		_name = "Spearman";
		_hp = 5;
		_maxHP = 5;
		_dmg = 5;
		_def = 0;
		_range = 2;
		_cost = 4;
		_chance = 0.2f;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if(IsAbility())
        {
			List<IUnit> enemy = GetEnemyFront(friendly, line);
			if (index == 0)
            {
				if (enemy.Count > 2)
				{
					enemy[2].Hit(15);
					enemy[0].Hit(4);
					enemy[1].Hit(4);
				}
				else if(enemy.Count == 2)
                {
					enemy[1].Hit(15);
					enemy[0].Hit(4);
				}
				else if(enemy.Count == 1)
                {
					enemy[0].Hit(15);
				}
			}
			else
				if(enemy.Count == 1)
					enemy[0].Hit(15);
		}
	}
}

class Necromancer : Unit
{
	public Necromancer()
	{
		_id = 10;
		_name = "Necromancer";
		_hp = 4;
		_maxHP = 4;
		_dmg = 5;
		_def = 1;
		_range = 1;
		_cost = 8;
		_chance = 0.1f;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if(IsAbility())
        {
			Barracks a = new Barracks();
			int summon = 0;
			if(friendly == 'l')
            {
				summon = line.leftDeath;
				for(int i = 0; i<summon; i++)
                {
					line.addLeft(a.Birth(8));
                }
            }
			else
            {
				summon = line.rightDeath;
				for (int i = 0; i < summon; i++)
				{
					line.addRight(a.Birth(8));
				}
			}
        }
	}
}

class Warlock : Unit
{
	int AbilityDuration = 0;
	public Warlock()
	{
		_id = 11;
		_name = "Warlock";
		_hp = 7;
		_maxHP = 0;
		_dmg = 6;
		_def = 9;
		_range = 3;
		_cost = 10;
		_chance = 0.15f;
		AbilityDuration = 0;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if(IsAbility() && AbilityDuration == 0)
        {
			_dmg += 4;
			_def += 8;
			AbilityDuration = 3;
        }
		else if(AbilityDuration == 1)
        {
			AbilityDuration = 0;
			_dmg -= 4;
			_def -= 8;
		}
		else if(AbilityDuration != 0)
        {
			AbilityDuration--;
        }
	}
}

class Demon : Unit
{
	int oldHp = 0;
	int AbilityDuration = 0;
	public Demon()
	{
		_id = 12;
		_name = "Demon";
		_hp = 10;
		_maxHP = 10;
		_dmg = 5;
		_def = 5;
		_range = 1;
		_cost = 12;
		_chance = 0.2f;
	}

	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if(_hp != _maxHP && IsAbility() && AbilityDuration == 0)
        {
			oldHp = _hp;
			_hp = 100;
			_dmg += 5;
			AbilityDuration = 4;
        }
		else if(AbilityDuration == 1)
        {
			_hp = oldHp - 100 + _hp;
			_dmg -= 5;
			AbilityDuration--;
        }
		else if(_hp != _maxHP)
        {
			AbilityDuration--;
		}
	}
}

class Kamenuka : Unit
{
	public Kamenuka()
	{
		_id = 13;
		_name = "Kamenuka";
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
		//пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
	}
}

class Kotopulka : Unit
{
	public Kotopulka()
	{
		_id = 13;
		_name = "Kotopulka";
		_hp = 9;
		_maxHP = 0;
		_dmg = 8;
		_def = 0;
		_range = 3;
		_cost = 10;
		_chance = 0.15f;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if(IsAbility())
        {
			List<IUnit> enemy = GetEnemyFront(friendly, line);

			if (enemy.Count > 2)
			{
				enemy[2].Hit(4);
				enemy[0].Hit(4);
				enemy[1].Hit(4);
			}
			else if (enemy.Count == 2)
			{
				enemy[1].Hit(4);
				enemy[0].Hit(4);
			}
			else if (enemy.Count == 1)
			{
				enemy[0].Hit(4);
			}
			//добавить линию сверху и снизу
		}
	}
}

class PolitePerson : Unit
{
	public PolitePerson()
	{
		_id = 15;
		_name = "PolitePerson";
		_hp = 15;
		_maxHP = 15;
		_dmg = 10;
		_def = 15;
		_range = 3;
		_cost = 2;
		_chance = 0.05f;
	}
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		if(IsAbility())
        {
			List<IUnit> enemy = GetEnemyFront(friendly, line);
			for(int i = 0; i < enemy.Count; i++)
            {
				enemy[i].Hit(99);
            }
        }
	}
}



// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ IUnit
class TestUnit : Unit
{
	public TestUnit()
	{}

	public TestUnit(uint id, int hp, uint dmg, uint def, uint range, uint cost, float chance)
	{
		_id = id; // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ id пїЅпїЅ 0 пїЅпїЅ max uint
		_name = "TestUnit";
		_hp = hp;
		_dmg = dmg;
		_def = def;
		_range = range;
		_cost = cost;
		_chance = chance;
	}

	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		// пїЅпїЅпїЅпїЅпїЅ-пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ
	}
}

class Warior : Unit
{
	public Warior()
	{
		_id = 1; // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ id пїЅпїЅ 0 пїЅпїЅ max uint
		_name = "Warior";
		_hp = 5;
		_dmg = 1;
		_def = 1;
		_range = 1;
		_cost = 2;
		_chance = 0.3f;
	}

	private bool Dress(Kinght warior)
	{
		List<String> ups = new List<String> {"РЁР»РµРј", "Р©РёС‚", "РџРёРєР°", "РљРѕРЅСЏС€РєР°"};
		foreach (var ammunition in warior.DressedAmmunitions)
		{
			ups.Remove(ammunition.Name);
		}

		if (ups.Count > 0)
		{
			int index = (int) (UnityEngine.Random.Range(0.0f, .99f) * ups.Count);
			switch (ups[index])
			{
				case "РЁР»РµРј" : 
					warior.DressedAmmunitions.Add(new Hemlet());
					break; 
				case "Р©РёС‚" : 
					warior.DressedAmmunitions.Add(new Shield());
					break; 
				case "РџРёРєР°" : 
					warior.DressedAmmunitions.Add(new Peak());
					break; 
				case "РљРѕРЅСЏС€РєР°" : 
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
		_id = 2; // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ id пїЅпїЅ 0 пїЅпїЅ max uint
		_name = "Archer";
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
		_id = 5; // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ id пїЅпїЅ 0 пїЅпїЅ max uint
		_name = "Kinght";
		_hp = 10;
		_maxHP = 10;
		_dmg = 4;
		_def = 1;
		_range = 1;
		_cost = 12;
		_chance = 0.15f;
	}

	public List<IAmmunition> DressedAmmunitions { get; } = new List<IAmmunition>();
	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		// пїЅпїЅпїЅпїЅпїЅ-пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ
	}


	public override void Hit(uint damageTaken)
	{
		// Get hit from enemy.
		base.Hit(damageTaken);
		
		// May lose one of dressed ammunition.
		if (IsAbility())
		{
			var idx = DressedAmmunitions.Count - 1;

			if (idx >= 0)
			{
				 DressedAmmunitions.RemoveAt(idx);
			}
		}
	}
}

class Musketeer : Unit
{
	public Musketeer()
	{
		_id = 7; // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ id пїЅпїЅ 0 пїЅпїЅ max uint
		_name = "Musketeer";
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
		_id = 6; // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ id пїЅпїЅ 0 пїЅпїЅ max uint
		_name = "Healer";
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