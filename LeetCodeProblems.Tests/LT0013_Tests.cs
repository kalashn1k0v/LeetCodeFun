using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests
{
    public class LT0013_Tests
    {
        // #13 https://leetcode.com/problems/roman-to-integer/
        [Test]
        [TestCase("L", 50)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void DoSmthTest(string s, int expectedResult)
        {
            int result = RomanToInt(s);

            result.Should().Be(expectedResult);
        }

        static public int RomanToInt(string s)
        {
            int result = 0;
            int index = 0;

            while (index < s.Length)
            {
                char currentSymbol = s[index];
                char nextSymbol = index + 1 < s.Length ? s[index + 1] : '.';

                switch (currentSymbol)
                {
                    case 'M':
                        result += 1000;
                        break;
                    case 'D':
                        result += 500;
                        break;
                    case 'C':
                        if (nextSymbol == 'D')
                        {
                            result += 400;
                            index++;
                        }
                        else if (nextSymbol == 'M')
                        {
                            result += 900;
                            index++;
                        }
                        else
                            result += 100;
                        break;
                    case 'L':
                        result += 50;
                        break;
                    case 'X':
                        if (nextSymbol == 'L')
                        {
                            result += 40;
                            index++;
                        }
                        else if (nextSymbol == 'C')
                        {
                            result += 90;
                            index++;
                        }
                        else 
                            result += 10;
                        break;
                    case 'V':
                            result += 5;
                        break;
                    case 'I':
                        if (nextSymbol == 'V')
                        {
                            result += 4;
                            index++;
                        }
                        else if (nextSymbol == 'X')
                        {
                            result += 9;
                            index++;
                        }
                        else
                            result++;
                        break;
                }

                index++;
            }

            return result;
        }
    }
}