using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.Tests
{
    public class LT0014_Tests
    {
        // #14 https://leetcode.com/problems/longest-common-prefix/
        [Test]
        [TestCase(new string[] { "flower", "flow", "flight" }, "fl")]
        [TestCase(new string[] { "dog", "racecar", "car" }, "")]
        [TestCase(new string[] { "dog" }, "dog")]
        [TestCase(new string[] { "dog", "do" }, "do")]
        [TestCase(new string[] { "" }, "")]
        [TestCase(new string[] { "", "" }, "")]
        [TestCase(new string[] { "", "b" }, "")]
        public void DoSmthTest(string[] strs, string expectedResult)
        {
            string result = LongestCommonPrefix(strs);

            result.Should().Be(expectedResult);
        }

        static public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1)
                return strs[0];

            int minLength = strs.Min(str => str.Length);

            if (minLength == 0)
                return "";

            int commonPrefixLength = 0;
            bool allCharsSame = true;

            while (allCharsSame)
            {
                char currentChar = strs[0][commonPrefixLength];
                for (int i = 1; i < strs.Length; i++)
                {
                    allCharsSame &= strs[i][commonPrefixLength] == currentChar;
                }

                if (!allCharsSame)
                    break;

                commonPrefixLength++;

                if (commonPrefixLength >= minLength)
                    break;
            }

            return strs[0].Substring(0,commonPrefixLength);
        }
    }

}