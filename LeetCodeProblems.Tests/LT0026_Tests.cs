using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0026_Tests
{
    // #26 https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    [Test]
    [TestCase(new int[] { }, 0, new int[] { })]
    [TestCase(new[] { 1 }, 1, new[] { 1 })]
    [TestCase(new[] { 1, 1, 2 }, 2, new[] { 1, 2 })]
    [TestCase(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5, new[] { 0, 1, 2, 3, 4 })]
    public void DoSmthTest(int[] nums, int expectedLength, int[] expectedResult)
    {
        var resultLength = RemoveDuplicates(nums);

        resultLength.Should().Be(expectedLength);
        nums.Take(resultLength).Should().BeEquivalentTo(expectedResult);
    }

    public static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length < 2)
            return nums.Length;

        var iterSortedVals = 0;

        for (var i = 1; i < nums.Length; i++)
            if (nums[i] != nums[i - 1])
            {
                iterSortedVals++;
                nums[iterSortedVals] = nums[i];
            }

        return iterSortedVals + 1;
    }
}