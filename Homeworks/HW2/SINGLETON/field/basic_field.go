package field

import (
	"fmt"
	"strings"
)

type basicField struct {
	data []string
}

func (b *basicField) Find(s string) int {
	for i := range b.data {
		if b.data[i] == s {
			return i
		}
	}

	return -1
}

func (b *basicField) Add(s string) {
	if b.Find(s) != -1 {
		fmt.Printf("%s already at the field\n", s)
		return
	}

	b.data = append(b.data, s)
}

func (b *basicField) String() string {
	return strings.Join(b.data, ", ")
}
