using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0001_Tests
{
    // #1 https://leetcode.com/problems/two-sum/
    [Test]
    [TestCase(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [TestCase(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [TestCase(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    public void TwoSumTest(int[] nums, int target, int[] expectedResult)
    {
        var result = TwoSum(nums, target);

        result.Should().BeEquivalentTo(expectedResult);
    }

    private static int[] TwoSum(int[] nums, int target)
    {
        var index1 = 0;
        var index2 = 1;

        var targetFound = false;


        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
                if (nums[i] + nums[j] == target)
                {
                    targetFound = true;
                    index1 = i;
                    index2 = j;
                    break;
                }

            if (targetFound)
                break;
        }

        return new[] { index1, index2 };
    }
}