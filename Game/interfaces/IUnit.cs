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
	public void SpecialAbility();
}

// Тестовая реализация интерфейса IUnit
class TestUnit : IUnit
{
	private uint _id;
	private string _name;
	private int _hp;
	private uint _dmg;
	private uint _def;
	private uint _range;
	private uint _cost;

	public uint Id => _id;
	public string Name => _name;
	public int Health => _hp;
	public uint Damage => _dmg;
	public uint Defense => _def;
	public uint AttackRange => _range;
	public uint Cost => _cost;

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

	public void SpecialAbility()
	{
		// Какое-то действие
	}
}