package main

// DRY & YAGNI

// BAD

type UnitBad struct {
	health   uint
	hardMode bool
}

func NewUnit(hard bool) *UnitBad {
	return &UnitBad{
		hardMode: hard,
	}
}

func (u *UnitBad) Init() {
	if u.hardMode {
		u.health = 50
		return
	}

	u.health = 100
}

func (u *UnitBad) resetHealth() {
	if u.hardMode {
		u.health = 50
		return
	}

	u.health = 100
}

// ! If unit can heal himself in future
func (u *UnitGood) HealSelf() {
	if u.hardMode {
		u.health = 50
		return
	}

	u.health = 100
}
