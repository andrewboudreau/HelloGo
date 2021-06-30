package main

import (
	"encoding/json"
	"fmt"
	"net/http"
	"time"
)

type person struct {
	Id         int
	GivenName  string
	FamilyName string
	StartDate  time.Time
	Rating     int
}

func (p person) String() string {
	return fmt.Sprintf("%s %s", p.GivenName, p.FamilyName)
}

func getPerson(id int) (person, error) {
	url := fmt.Sprintf("http://localhost/users/%d", id)
	resp, err := http.Get(url)
	if err != nil {
		return person{}, err
	}

	var p person
	err = json.NewDecoder(resp.Body).Decode(&p)
	if err != nil {
		return person{}, err
	}

	return p, nil
}

func main() {
	ids := [3]int{1, 2, 3}
	fmt.Println(ids)

	p, err := getPerson(1)
	if err != nil {
		fmt.Printf("error: %v \n", err)
	}

	fmt.Printf("%d: %v \n", p.Id, p)
}
