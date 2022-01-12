using FluentAssertions;

namespace LeetCodeProblems.Tests;

public class LT0000_Tests
{
    // #0 https://leetcode.com/problems/xxx
    //[Test]
    public void DoSmthTest(int x, bool expectedResult)
    {
        var result = DoSmth(x);

        result.Should().Be(expectedResult);
    }

    public static bool DoSmth(int x)
    {
        return false;
    }
}