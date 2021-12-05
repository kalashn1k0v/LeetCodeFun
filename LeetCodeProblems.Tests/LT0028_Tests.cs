using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests
{
    public class LT0028_Tests
    {
        // #28 https://leetcode.com/problems/implement-strstr/
        [Test]
        [TestCase("hello", "ll", 2)]
        [TestCase("aaaaa", "bba", -1)]
        [TestCase("", "", 0)]
        [TestCase("asd", "", 0)]
        [TestCase("hello", "lloaaa", -1)]
        public void StrStrTest(string haystack, string needle, int expectedResult)
        {
            var result = StrStr(haystack, needle);

            result.Should().Be(expectedResult);
        }

        static public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
                return 0;

            int result = -1;

            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                bool match = true;

                for (int j = 0; j < needle.Length; j++)
                {
                    match &= haystack[i + j] == needle[j];
                    if (!match)
                        break;
                }

                if (match)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}