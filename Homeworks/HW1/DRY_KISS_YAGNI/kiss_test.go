package main

import "testing"

func BenchmarkGetMonth(b *testing.B) {
	for i := 1; i < b.N; i++ {
		getMonth(uint(i))
	}
}

func BenchmarkGetMonthBetterWay(b *testing.B) {
	for i := 1; i < b.N; i++ {
		getMonthBetterWay(uint(i))
	}
}

func BenchmarkGetMonthGoodWay(b *testing.B) {
	for i := 1; i < b.N; i++ {
		getMonthGoodWay(uint(i))
	}
}
