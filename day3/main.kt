



fun getNumbers(str: String): List<Int> {
    var nums: MutableList<Int> = mutableListOf()

    for (c in str) {
        nums.add(c.toInt())
    }

    return nums
}



fun main() {

    var solution: Int = 0

    var lines: MutableList<String> = mutableListOf() 
    File(fileName).forEachLine { 
        var nums: MutableList<Int> = getNumbers(it)
        var max: Int = 0;
        var secondMax: Int = 0
        var maxIndex: Int = 0

        var i  = 0
        for (value in nums) {
            if(value > max) {
                max = value
                maxIndex = i
            }
            i++
        }
        for (value in nums) {
            if(value > secondMax && maxIndex < i) {
                secondMax = value
            }
            i++
        }

        solution += max*10+secondMax;
    }
    printLn(solution)
}