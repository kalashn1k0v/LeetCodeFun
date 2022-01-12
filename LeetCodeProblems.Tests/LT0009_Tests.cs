using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0009_Tests
{
    // #9 https://leetcode.com/problems/palindrome-number/
    [Test]
    [TestCase(1, true)]
    [TestCase(11, true)]
    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(10, false)]
    [TestCase(-101, false)]
    public void IsPalindromeTest(int x, bool expectedResult)
    {
        var result = IsPalindrome(x);

        result.Should().Be(expectedResult);
    }

    public static bool IsPalindrome(int x)
    {
        if (x < 0)
            return false;

        var xs = x.ToString();

        for (var i = 0; i < xs.Length / 2; i++)
            if (xs[i] != xs[^(i + 1)])
                return false;

        return true;
    }
}