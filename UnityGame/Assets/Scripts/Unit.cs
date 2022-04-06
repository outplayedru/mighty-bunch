using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//UnityEngine.Random.Range

public interface IUnit
{
	// Публичные свойства
	public uint Id { get; }
	public string Name { get; }
	public int Health { get; }
	public int MaxHP { get; }
	public uint Damage { get; }
	public uint Defense { get; }
	public uint AttackRange { get; }
	public float AbilityChance { get; }

	public uint Cost { get; }

	// ! Для реализации хранение вещей необходим интерфейс вещи
	// public IItem Equipment { get; set; }

	// Публичные методы
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

	public bool IsAbility()//метод определения прокнула абилка или нет
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
		//Прописть условие на смерть
		//Если смерть то отправить линии о мерти юнита
		//Удачи тарас)
		_hp = (int)UnityEngine.Mathf.Max(_hp - damageTaken + _def, 0);
		if(_hp == 0)
        {
			//Отправить сообщение линии о смерти юнита
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
		_name = "Маг";
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

			if (friend[(int)index - 1] != null)
            {
                newId = (int)friend[(int)index - 1].Id;
            }
			else if (friend[(int)index + 1] != null)
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
		_name = "Перекати-поле";
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
		//Ничего не произошло хыыыы
    }
}

class Skeleton : Unit
{
	public Skeleton()
	{
		_id = 8;
		_name = "Скелет";
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
		_name = "Копейщик";
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
			List<IUnit> friend = GetFriendlyFront(friendly, line);
			List<IUnit> enemy = GetEnemyFront(friendly, line);
			if (index == 0)
            {
				enemy[2].Hit(15);
				enemy[0].Hit(4);
				enemy[1].Hit(4);
			}
			else
				enemy[0].Hit(15);
		}
	}
}

class Necromancer : Unit
{
	public Necromancer()
	{
		_id = 10;
		_name = "Некромант";
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
		_name = "Чернокнижник";
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
		else
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
		_name = "Демон";
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
		_name = "Камэнюка";
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
		//Ничего не произошло хыыыы
	}
}

class Kotopulka : Unit
{
	public Kotopulka()
	{
		_id = 13;
		_name = "Котопулька";
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
			enemy[0].Hit(4);
			enemy[1].Hit(4);
			enemy[2].Hit(4);

			//добавить линию сверху и снизу
		}
	}
}

class PolitePerson : Unit
{
	public PolitePerson()
	{
		_id = 15;
		_name = "Вежливый человек";
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





// Тестовая реализация интерфейса IUnit
class TestUnit : Unit
{
	public TestUnit()
	{}

	public TestUnit(uint id, int hp, uint dmg, uint def, uint range, uint cost, float chance)
	{
		_id = id; // Последовательные значения id от 0 до max uint
		_name = "Название юнита";
		_hp = hp;
		_dmg = dmg;
		_def = def;
		_range = range;
		_cost = cost;
		_chance = chance;
	}

	public override void SpecialAbility(Line line, uint index, char friendly)
	{
		// Какое-то действие
	}
}