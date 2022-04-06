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