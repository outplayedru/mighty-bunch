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

public class Unit
{
  public Race Race { get; set; }
	public Weapon Weapon { get; set; }
	public Armor Armor { get; set; }
}

abstract class UnitBuilder 
{
  public Unit Unit { get; set; }
  public void CreateUnit()
  {
      Unit = new Unit();
  }
  public abstract void SetRace();
  public abstract void SetWeapon();
  public abstract void SetArmor();
}

class Barracks
{
  public Unit Birth(UnitBuilder unitBilder)
  {
    unitBilder.CreateUnit()
    unitBilder.SetRace();
    unitBilder.SetWeapon();
    unitBilder.SetArmor();
    return unitBilder.Unit;
  }
}

class ArcherBilder : UnitBuilder
{
  public override void SetRace()
  {
    this.Unit.Race = new Race("Yellow", "Blue", new Body(80, 1.90))
  }
  public override void SetWeapon()
  {  
    this.Unit.Weapon = new Weapon(25, "Bow")
  }
  public override void SetArmor()
  {
    
  }  
}

class TankBilder : UnitBuilder
{
  public override void SetRace()
  {
    this.Unit.Race = new Race("Green", "Black", new Body(120, 1.60))
  }
  public override void SetWeapon()
  {  
    this.Unit.Weapon = new Weapon(15, "Plane")
  }
  public override void SetArmor()
  {
    this.Unit.Armor = new Armor(30, "Chain mail")
  }  
}