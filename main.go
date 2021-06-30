package main

import (
	"fmt"
	"time"
)

type person struct {
	ID         int
	GivenName  string
	FamilyName string
	StartDate  time.Time
	Rating     int
}

func getPerson(id int) (person, error) {
	url := fmt.Sprintf("https://jsonplaceholder.typicode.com/users/%d", id)

}

func main() {
	ids := [9]int{1, 2, 3, 4, 5, 6, 7, 8, 9}
	fmt.Println(ids)
}
