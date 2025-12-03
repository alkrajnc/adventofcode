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



fun getMaxes(nums: MutableList<Int>): MutableList<Max> {
    val maxes = mutableListOf<Max>()

    val indexed = mutableListOf<Max>()
    var i = 0
    for(num in nums) {
       indexed.add(Max(num, i))
        i++
    }
    indexed.sortWith(compareBy<Max> { it.value })


    for(num in  indexed.slice(0..12)) {
        maxes.add(num)
    }



    return maxes;
}



fun main() {
    var solution: BigInteger = BigInteger.ZERO

    File("/home/aljaz/projects/adventofcode/day3/src/input.txt").forEachLine {
        val nums: MutableList<Int> = getNumbers(it)
//        var max: Int = 0;
//        var secondMax: Int = 0
//        var maxIndex: Int = 0
//
//        for (i in 0..<nums.size-1) {
//            if(nums[i] > max) {
//                max = nums[i]
//                maxIndex = i
//            }
//        }
//
//        for(i in maxIndex+1..<nums.size) {
//            if(nums[i] > secondMax) {
//                secondMax = nums[i]
//            }
//        }
//        solution += max*10+secondMax;

//        var intermidiate: Long = 0
//        for(max in maxes) {
//            println("val: ${max.value} index: ${max.index}");
//            intermidiate+= max.value * Math.unsignedPowExact(10, maxIndex - max.index - 1)
//        }



        val maxes = getMaxes(nums)

        val maxIndex = 0
        


        var intermediate = BigInteger.ZERO;
        for(max in maxes) {
            println(max.toString())
            val powerOfTen: BigInteger = BigInteger.TEN.pow(maxIndex - max.index);
            intermediate = intermediate.add(
                BigInteger.valueOf(max.value.toLong()).multiply(powerOfTen)
            );
        }
        println(intermediate)
        solution+=intermediate
    }
    println(solution)
}