import java.io.File
import java.math.BigInteger


fun getNumbers(str: String): MutableList<Int> {
    val nums: MutableList<Int> = mutableListOf()
    for (c in str) {
        nums.add(c - '0')
    }
    return nums
}


class Max(var value: Int, var index: Int): Comparable<Max> {
    override fun compareTo(other: Max): Int {
        return index.compareTo(other.index)
    }

    override fun toString(): String {
        return "val: ${value}, index: ${index}"
    }
}

fun getMaxTwoJoltage(nums: MutableList<Int>): Long {
    val firstMax = getFirstMaxInRange(nums, 0, nums.size-2)
    val secondMax = getFirstMaxInRange(nums, firstMax.index+1, nums.size-1)

    return (firstMax.value*10+secondMax.value).toLong()
}


fun getMaxTwelweJoltage(nums: MutableList<Int>): Long {
    var left = 0
    var result = 0L
    for(i in 0 until 12) {
        var remainingDigits = 11 - i
        var safeRightIndex = nums.size - 1 - remainingDigits
        val max = getFirstMaxInRange(nums,left, safeRightIndex)
        result = 10*result + max.value
        left = max.index + 1
    }
    return result
}


fun getFirstMaxInRange(nums: MutableList<Int>, start: Int, end: Int): Max {
    var max = Max(0, 0)
    for (i in start..end) {
        if(nums[i] > max.value) {
            max.value = nums[i]
            max.index = i
        }
    }
    return max
}



fun main() {
    var partOne: Long = 0L
    var partTwo: Long = 0L

    File("input.txt").forEachLine {
        val nums: MutableList<Int> = getNumbers(it)

        partOne+=getMaxTwoJoltage(nums)
        partTwo+=getMaxTwelweJoltage(nums)
    }
    println("$partOne, $partTwo")
}