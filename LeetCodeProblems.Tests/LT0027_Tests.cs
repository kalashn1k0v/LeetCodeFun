using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0027_Tests
{
    // #27 https://leetcode.com/problems/remove-element/
    [Test]
    [TestCase(new int[] { }, 3, 0, new int[] { })]
    [TestCase(new[] { 3 }, 3, 0, new int[] { })]
    [TestCase(new[] { 1 }, 3, 1, new[] { 1 })]
    [TestCase(new[] { 3, 2, 2, 3 }, 3, 2, new[] { 2, 2 })]
    [TestCase(new[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5, new[] { 0, 1, 4, 0, 3 })]
    public void DoSmthTest(int[] nums, int val, int expectedLength, int[] expectedResult)
    {
        int[] collection = { 1, 2, 5, 8 };
        collection.Should().BeEquivalentTo(new[] { 8, 2, 1, 5 });

        var resultLength = RemoveElement(nums, val);

        resultLength.Should().Be(expectedLength);
        nums.Take(resultLength).Should().BeEquivalentTo(expectedResult);
    }

    public static int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0)
            return 0;

        var resultIndex = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
                continue;

            nums[resultIndex] = nums[i];
            resultIndex++;
        }

        return resultIndex;
    }
}