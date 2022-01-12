using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace LeetCodeProblems.Tests
{
    public class LT0058_Tests
    {
        // #58 https://leetcode.com/problems/length-of-last-word/
        [Test]
        [TestCase("Hello World", 5)]
        [TestCase("   fly me   to   the moon  ", 4)]
        [TestCase("luffy is still joyboy", 6)]
        public void DoSmthTest(string s, int expectedResult)
        {
            var result = LengthOfLastWord(s);

            result.Should().Be(expectedResult);
        }

        public static int LengthOfLastWord(string s)
        {
            const char separator = ' ';
            return s
                .Trim(separator)
                .Split(separator, StringSplitOptions.RemoveEmptyEntries |
                                  StringSplitOptions.TrimEntries)
                .Last()
                .Length;
        }
    }
}