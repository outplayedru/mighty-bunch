public class Body
{
  public unit Weight { get; set; }
  public float Height { get; set; }
}

public class Race
{
  public string SkinColor { get; set; }
  public string EyeColor { get; set; }
  public Body Body { get; set; }
}

public class Weapon
{
  public uint Damage { get; set; }
  public string Name { get; set; }
}

public class Armor
{
  public uint Defence { get; set; }
  public string Name { get; set; }
}

interface IUnitClone
{
  object Clone();
}

interface IUnitDeepClone
{
  object DeepClone();
}

public class Unit : IUnitClone, IUnitDeepClone, ICloneable
{
  public Race Race { get; set; }
	public Weapon Weapon { get; set; }
	public Armor Armor { get; set; }
  public object ICloneable.Clone()
  {
      return this.DeepClone();
  }
  public object Clone()
  {
    return this.MemberwiseClone();
  }
  public object DeepClone()
  {
    Race race = new Race(Race.SkinColor, Race.EyeColor, new Body(Race.Body.Weight, Race.Body.Height);
    Weapon weapon = new Weapon(Weapon.Damage, Weapon.Name);
    Armor armor = new Armor(Armor.Defence, Armor.Name);
    return new Unit(Race, Weapon, Armor);
  }
}

