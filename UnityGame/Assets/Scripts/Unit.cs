public interface IUnit
{
	// ��������� ��������
	public uint Id { get; }
	public string Name { get; }
	public int Health { get; }
	public uint Damage { get; }
	public uint Defense { get; }
	public uint AttackRange { get; }

	public uint Cost { get; }

	// ! ��� ���������� �������� ����� ��������� ��������� ����
	// public IItem Equipment { get; set; }

	// ��������� ������
	public void SpecialAbility();
}

// �������� ���������� ���������� IUnit
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

	public TestUnit()
	{}

	public TestUnit(uint id, int hp, uint dmg, uint def, uint range, uint cost)
	{
		_id = id; // ���������������� �������� id �� 0 �� max uint
		_name = "�������� �����";
		_hp = hp;
		_dmg = dmg;
		_def = def;
		_range = range;
		_cost = cost;
	}

	public void SpecialAbility()
	{
		// �����-�� ��������
	}
}