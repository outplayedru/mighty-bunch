package main

import "fmt"

func main() {
	field := GetField()
	fmt.Println(field)

	fieldSecond := GetField()
	fmt.Println(fieldSecond)

	fmt.Printf("\n%v and %v are equal: %t\n\n", field, fieldSecond, (field == fieldSecond))

	field.Add("paladin")
	fmt.Println(field)

	wizardId := field.Find("wizard")
	fmt.Printf("Id of wizard is: %d", wizardId)

}
