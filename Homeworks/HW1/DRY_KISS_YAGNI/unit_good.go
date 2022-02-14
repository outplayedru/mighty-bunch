package main

// BEST

type UnitGood struct {
	health   uint
	hardMode bool
}

func NewUnitGood(hard bool) *UnitGood {
	return &UnitGood{
		hardMode: hard,
	}
}

func (u *UnitGood) setHealth(h uint) {
	u.health = h
}

func (u *UnitGood) resetHealth() {
	if u.hardMode {
		u.setHealth(HardModeUnitHealth)
		return
	}

	u.setHealth(DefaultUnitHealth)
}

func (u *UnitGood) Init() {
	u.resetHealth()
}
