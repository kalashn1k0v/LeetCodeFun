using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0014_Tests
{
    // #14 https://leetcode.com/problems/longest-common-prefix/
    [Test]
    [TestCase(new[] { "flower", "flow", "flight" }, "fl")]
    [TestCase(new[] { "dog", "racecar", "car" }, "")]
    [TestCase(new[] { "dog" }, "dog")]
    [TestCase(new[] { "dog", "do" }, "do")]
    [TestCase(new[] { "" }, "")]
    [TestCase(new[] { "", "" }, "")]
    [TestCase(new[] { "", "b" }, "")]
    public void DoSmthTest(string[] strs, string expectedResult)
    {
        var result = LongestCommonPrefix(strs);

        result.Should().Be(expectedResult);
    }

    public static string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 1)
            return strs[0];

        var minLength = strs.Min(str => str.Length);

        if (minLength == 0)
            return "";

        var commonPrefixLength = 0;
        var allCharsSame = true;

        while (allCharsSame)
        {
            var currentChar = strs[0][commonPrefixLength];
            for (var i = 1; i < strs.Length; i++) allCharsSame &= strs[i][commonPrefixLength] == currentChar;

            if (!allCharsSame)
                break;

            commonPrefixLength++;

            if (commonPrefixLength >= minLength)
                break;
        }

        return strs[0].Substring(0, commonPrefixLength);
    }
}