package main

import (
	"fmt"

	"example.com/greetings"
)

func main() {
	message := greetings.Hello("Simon")
	fmt.Println(message)
}
