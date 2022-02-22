package main

import (
	"fmt"
	"singleton/field"
)

func main() {
	fieldFirst := field.GetField()
	fmt.Println(fieldFirst)

	fieldSecond := field.GetField()
	fmt.Println(fieldSecond)

	fmt.Printf("\n%v and %v are equal: %t\n\n", fieldFirst, fieldSecond, (fieldFirst == fieldSecond))

	fieldFirst.Add("paladin")
	fmt.Println(fieldFirst)

	wizardId := fieldFirst.Find("wizard")
	fmt.Printf("Id of wizard is: %d", wizardId)

}
