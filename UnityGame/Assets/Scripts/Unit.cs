public interface IUnit
{
	// Публичные свойства
	public uint Id { get; }
	public string Name { get; }
	public int Health { get; }
	public uint Damage { get; }
	public uint Defense { get; }
	public uint AttackRange { get; }

	public uint Cost { get; }

	// ! Для реализации хранение вещей необходим интерфейс вещи
	// public IItem Equipment { get; set; }

	// Публичные методы
	public  void SpecialAbility();
	public void Hit(uint damageTaken);
	public void Heal(uint receivedHealing);
}

abstract public class Unit : IUnit
{
	protected uint _id;
	protected string _name;
	protected int _hp;
	protected uint _dmg;
	protected uint _def;
	protected uint _range;
	protected uint _cost;

	public uint Id => _id;
	public string Name => _name;
	public int Health => _hp;
	public uint Damage => _dmg;
	public uint Defense => _def;
	public uint AttackRange => _range;
	public uint Cost => _cost;

	public abstract void SpecialAbility();

	public void Hit(uint damageTaken)
	{
		//Прописть условие на смерть
		//Если смерть то отправить линии о мерти юнита
		//Удачи тарас)
	}

	public void Heal(uint receivedHealing)
	{

	}
}



// Тестовая реализация интерфейса IUnit
class TestUnit : Unit
{
	public TestUnit()
	{}

	public TestUnit(uint id, int hp, uint dmg, uint def, uint range, uint cost)
	{
		_id = id; // Последовательные значения id от 0 до max uint
		_name = "Название юнита";
		_hp = hp;
		_dmg = dmg;
		_def = def;
		_range = range;
		_cost = cost;
	}

	public override void SpecialAbility()
	{
		// Какое-то действие
	}
}