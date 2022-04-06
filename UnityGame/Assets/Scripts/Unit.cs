using UnityEngine;

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
	public void SpecialAbility();
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

	public abstract void SpecialAbility();

	public bool IsAbility()//метод определения прокнула абилка или нет
    {
		float chance = UnityEngine.Random.Range(0.0f, 1.0f);
		if(_chance < chance)
        {
			return true;
        }
		return false;
    }

	public void Hit(uint damageTaken)
	{
		//Прописть условие на смерть
		//Если смерть то отправить линии о мерти юнита
		//Удачи тарас)
		_hp = (int)UnityEngine.Mathf.Max(_hp - damageTaken, 0);
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
		_chance = _chance;
	}

	public override void SpecialAbility()
	{
		// Какое-то действие
	}
}