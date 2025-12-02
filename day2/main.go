package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

type Range struct {
	lower string
	upper string
}

func getRange(line string) Range {
	var values []string = strings.Split(line, "-")
	return Range{values[0], values[1]}
}

func split(pos int, str string) []string {
	var result []string
	result = append(result, str[0:pos])
	result = append(result, str[pos:])
	return result
}

func isInvalidId(id int) bool {

	var strRep = strconv.Itoa(id)
	var length = len(strRep)

	if length%2 != 0 {
		return false
	}

	var splitStr = split(length/2, strRep)

	if splitStr[0] == splitStr[1] {
		return true
	}
	return false
}

func main() {
	file, err := os.Open("ids.txt")
	if err != nil {
		log.Fatalf("failed to open file: %s", err)
	}

	reader := bufio.NewReader(file)

	var solution int64 = 0
	var solution2 int64 = 0

	for {
		line, err := reader.ReadString(',')
		if err != nil {
			if err.Error() == "EOF" {
				break
			}
			log.Fatalf("error reading file: %s", err)
		}

		idRange := getRange(line[:len(line)-1])

		upperLimit, err := strconv.Atoi(idRange.upper)
		if err != nil {
			fmt.Printf("\nCannot convert %s\n", idRange.lower)
			os.Exit(1)
		}

		lowerLimit, err := strconv.Atoi(idRange.lower)
		if err != nil {
			fmt.Printf("\nCannot convert %s\n", idRange.upper)
			os.Exit(1)
		}

		for i := int64(lowerLimit); i <= int64(upperLimit); i++ {
			if isInvalidId(int(i)) {
				solution += i
			}
		}

	}

	fmt.Printf("\nSolution: %d, Solution2: %d", solution, solution2)

}
