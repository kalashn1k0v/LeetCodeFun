using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0066_Tests
{
    // #66 https://leetcode.com/problems/plus-one/
    [Test]
    [TestCase(new[]{ 1, 2, 3 }, new[] { 1, 2, 4 })]
    [TestCase(new[]{ 4, 3, 2, 1 }, new[] { 4, 3, 2, 2 })]
    [TestCase(new[]{ 9 }, new[] { 1, 0 })]
    public void PlusOne_Test(int[] digits, int[] expectedResult)
    {
        var result = PlusOne(digits);

        result.Should().BeEquivalentTo(expectedResult);
    }

    public static int[] PlusOne(int[] digits)
    {
        int carryover = 1;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            var sum = digits[i] + carryover;
            carryover = sum / 10;
            digits[i] = sum % 10;

            if (carryover == 0)
                break;
        }

        if (carryover == 0)
            return digits;

        var newDigitsArray = new int[digits.Length+1];
        digits[0] = carryover;
        Array.Copy(digits, newDigitsArray, digits.Length);

        return newDigitsArray;
    }
}