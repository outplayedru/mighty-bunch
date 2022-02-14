package main

import "fmt"

// BAD
func getMonth(num uint) (string, error) {
	switch num {
	case 1:
		return "Jan", nil
	case 2:
		return "Feb", nil
	case 3:
		return "Mar", nil
	case 4:
		return "Apr", nil
	case 5:
		return "May", nil
	case 6:
		return "Jun", nil
	case 7:
		return "Jul", nil
	case 8:
		return "Aug", nil
	case 9:
		return "Sep", nil
	case 10:
		return "Oct", nil
	case 11:
		return "Nov", nil
	case 12:
		return "Dec", nil
	default:
		return "", fmt.Errorf("You entered unsupported month's number")
	}
}

// BETTER
var months = []string{"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

func getMonthBetterWay(num uint) (string, error) {

	if num > 12 {
		return "", fmt.Errorf("You entered unsupported month's number")
	}

	return months[num-1], nil
}

// GOOD
func getMonthGoodWay(num uint) (string, error) {

	if num > uint(len(months)) {
		return "", fmt.Errorf("You entered unsupported month's number")
	}

	return months[num-1], nil
}
