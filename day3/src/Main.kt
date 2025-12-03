import java.io.File


fun getNumbers(str: String): MutableList<Int> {
    val nums: MutableList<Int> = mutableListOf()
    for (c in str) {
        nums.add(c - '0')
    }
    return nums
}



fun main() {
    var solution: Int = 0

    File("/home/aljaz/projects/adventofcode/day3/src/input.txt").forEachLine {
        val nums: MutableList<Int> = getNumbers(it)
        var max: Int = 0;
        var secondMax: Int = 0
        var maxIndex: Int = 0

        for (i in 0..<nums.size-1) {
            if(nums[i] > max) {
                max = nums[i]
                maxIndex = i
            }
        }

        for(i in maxIndex+1..<nums.size) {
            if(nums[i] > secondMax) {
                secondMax = nums[i]
            }
        }
        solution += max*10+secondMax;
    }
    println(solution)
}