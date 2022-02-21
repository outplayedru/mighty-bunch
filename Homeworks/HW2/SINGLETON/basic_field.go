package main

import (
	"fmt"
	"strings"
)

type BasicField struct {
	data []string
}

func (b *BasicField) Find(s string) int {
	for i := range b.data {
		if b.data[i] == s {
			return i
		}
	}

	return -1
}

func (b *BasicField) Add(s string) {
	if b.Find(s) != -1 {
		fmt.Printf("%s already at the field\n", s)
		return
	}

	b.data = append(b.data, s)
}

func (b *BasicField) String() string {
	return strings.Join(b.data, ", ")
}
