package main

// BETTER

const (
	DefaultUnitHealth  = 100
	HardModeUnitHealth = 50
)

type UnitBetter struct {
	health   uint
	hardMode bool
}

func NewUnitBetter(hard bool) *UnitBetter {
	return &UnitBetter{
		hardMode: hard,
	}
}

func (u *UnitBetter) Init() {
	if u.hardMode {
		u.health = HardModeUnitHealth
		return
	}

	u.health = DefaultUnitHealth
}

func (u *UnitBetter) resetHealth() {
	if u.hardMode {
		u.health = HardModeUnitHealth
		return
	}

	u.health = DefaultUnitHealth
}
