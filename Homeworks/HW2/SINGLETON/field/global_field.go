package field

import (
	"fmt"
	"sync"
)

type Fielder interface {
	Add(string)
	Find(string) int
}

// globalField – our singleton
var globalField Fielder = nil

// sync.Once – uses atomicity and an internal flag to guarantee a single function call
var once sync.Once

// Return globalField
func GetField() Fielder {
	once.Do(func() {
		fmt.Println("Creating field...")

		globalField = &basicField{
			data: []string{"knight", "wizard"},
		}
	})

	return globalField
}
