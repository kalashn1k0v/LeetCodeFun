using FluentAssertions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeProblems.Tests
{
    public class LT0020_Tests
    {
        // #20 https://leetcode.com/problems/valid-parentheses/
        [Test]
        [TestCase("()", true)]
        [TestCase("()[]{}", true)]
        [TestCase("(]", false)]
        [TestCase("([)]", false)]
        [TestCase("{[]}", true)]
        [TestCase("]", false)]
        public void ValidParenthesesTest(string input, bool expectedResult)
        {
            bool result = IsValid(input);

            result.Should().Be(expectedResult);
        }

        static public bool IsValid(string s)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] is '(' or '{' or '[')
                    stack.Push(s[i]);
                else
                {
                    if (!stack.Any())
                        return false;

                    char prevOpeningBracket = stack.Pop();
                    bool result = (prevOpeningBracket, s[i]) switch
                    {
                        ('[', not ']') => false,
                        ('{', not '}') => false,
                        ('(', not ')') => false,
                        _ => true,
                    };

                    if (!result)
                        return result;
                }
            }

            return !stack.Any();
        }
    }
}