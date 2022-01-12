using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0053_Tests
{
    // #53 https://leetcode.com/problems/maximum-subarray/
    [Test]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { 1, 2 }, 3)]
    [TestCase(new[] { -1 }, -1)]
    [TestCase(new[] { 1, -1 }, 1)]
    [TestCase(new[] { -1, -1 }, -1)]
    [TestCase(new[] { -1, 1 }, 1)]
    [TestCase(new[] { -5, -6, -3, -1, -7, -7 }, -1)]
    [TestCase(new[] { -5, -6, 0, -1, -7, -7 }, 0)]
    [TestCase(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
    [TestCase(new[] { 5, 4, -1, 7, 8 }, 23)]
    [TestCase(new[] { 8, -19, 5, -4, 20 }, 21)]
    public void MaxSubArrayTest(int[] nums, int expectedResult)
    {
        //var result = MaxSubArray(nums);
        var result = MaxSubArray2(nums);

        result.Should().Be(expectedResult);
    }

    public static int MaxSubArray(int[] nums)
    {
        var longestSum = int.MinValue;

        var currentNegSumWasSet = false;
        var currentNegSum = 0;

        var currentPosSumWasSet = false;
        var currentPosSum = 0;

        var i = 0;
        while (i < nums.Length)
        {
            if (nums[i] < 0)
            {
                currentNegSum = 0;
                while (nums[i] < 0)
                {
                    // case, when no positives occured before
                    if (longestSum < nums[i]) longestSum = nums[i];

                    currentNegSum += nums[i];
                    i++;
                    if (i == nums.Length)
                        break;
                }

                currentNegSumWasSet = true;
            }
            else
            {
                if (longestSum < 0)
                    longestSum = 0;

                var prevPosSum = currentPosSumWasSet ? currentPosSum : 0;

                currentPosSum = 0;
                while (nums[i] >= 0)
                {
                    currentPosSum += nums[i];
                    i++;
                    if (i == nums.Length)
                        break;
                }

                currentPosSumWasSet = true;

                if (!currentNegSumWasSet && currentPosSum > longestSum)
                    longestSum = currentPosSum;

                if (currentNegSumWasSet && prevPosSum + currentNegSum > 0)
                {
                    currentPosSum += prevPosSum + currentNegSum;
                    if (currentPosSum > longestSum)
                        longestSum = currentPosSum;
                }
            }

            if (currentPosSumWasSet && currentPosSum > longestSum)
                longestSum = currentPosSum;
        }

        return longestSum;
    }

    // I'm an idiot, it can be done mush easier =)
    public static int MaxSubArray2(int[] nums)
    {
        var length = nums.Length;
        var result = nums[0];
        var currentMax = nums[0];

        for (var i = 1; i < length; i++)
        {
            currentMax = Math.Max(nums[i], nums[i] + currentMax);
            result = Math.Max(result, currentMax);
        }

        return result;
    }
}