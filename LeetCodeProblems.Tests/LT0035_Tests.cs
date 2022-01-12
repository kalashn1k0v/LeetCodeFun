using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0035_Tests
{
    // #35 https://leetcode.com/problems/search-insert-position/
    [Test]
    [TestCase(new[] { 1, 3, 5, 6 }, 5, 2)]
    [TestCase(new[] { 1, 3, 5, 6 }, 2, 1)]
    [TestCase(new[] { 1, 3, 5, 6 }, 7, 4)]
    [TestCase(new[] { 1, 3, 5, 6 }, 0, 0)]
    [TestCase(new[] { 1 }, 0, 0)]
    [TestCase(new[] { 1, 3, 5, 5, 5, 5, 6 }, 5, 2)]
    public void SearchInsertTest(int[] nums, int target, int expectedResult)
    {
        //var result = SearchInsert(nums, target);
        //var result = SearchInsert2(nums, target);
        var result = SearchInsert3(nums, target);

        result.Should().Be(expectedResult);
    }

    // This version is an algorithm with O(n) runtime complexity.
    // It was accepted by LeetCode, but it shouldn't...
    public static int SearchInsert(int[] nums, int target)
    {
        if (target <= nums[0])
            return 0;

        if (target > nums[^1])
            return nums.Length;

        var index = 0;
        while (target > nums[index]) index++;

        return index;
    }

    // This version is an algorithm with O(log n) runtime complexity.
    // As required by the task
    // Also it covers cases with non distinct arrays (not part of the task)
    public static int SearchInsert2(int[] nums, int target)
    {
        if (target <= nums[0])
            return 0;

        if (target > nums[^1])
            return nums.Length;

        var beginIndex = 0;
        var endIndex = nums.Length - 1;

        var index = 0;

        while (beginIndex < endIndex)
        {
            index = (endIndex - beginIndex) / 2 + beginIndex;
            if (target > nums[index])
                beginIndex = index + 1;
            else
                endIndex = index;

            if (beginIndex == endIndex)
                index = beginIndex;
        }

        return index;
    }

    // This version is an algorithm with O(log n) runtime complexity.
    // As required by the task.
    // Also it covers cases with non distinct arrays (not part of the task)
    // This version uses bit shifting instead of division. Shouyld be slightly faster.
    // Just for fun
    public static int SearchInsert3(int[] nums, int target)
    {
        if (target <= nums[0])
            return 0;

        if (target > nums[^1])
            return nums.Length;

        var beginIndex = 0;
        var endIndex = nums.Length - 1;

        var index = 0;

        while (beginIndex < endIndex)
        {
            index = ((endIndex - beginIndex) >> 1) + beginIndex;
            if (target > nums[index])
                beginIndex = index + 1;
            else
                endIndex = index;

            if (beginIndex == endIndex)
                index = beginIndex;
        }

        return index;
    }
}