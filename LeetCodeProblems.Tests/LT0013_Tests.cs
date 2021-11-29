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
            //int result = RomanToInt(s);
            //int result = RomanToInt2(s);
            int result = RomanToInt3(s);

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

        /// <summary>
        /// Using new C# features
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static public int RomanToInt2(string s)
        {
            int result = 0;
            int index = 0;

            while (index < s.Length)
            {
                char currentSymbol = s[index];
                char nextSymbol = (index + 1 < s.Length) ? s[index + 1] : '.';


                switch ((currentSymbol, nextSymbol))
                {
                    case ('C', 'D'):
                        result += 400;
                        index++;
                        break;
                    case ('C', 'M'):
                        result += 900;
                        index++;
                        break;
                    case ('X', 'L'):
                        result += 40;
                        index++;
                        break;
                    case ('X', 'C'):
                        result += 90;
                        index++;
                        break;
                    case ('I', 'V'):
                        result += 4;
                        index++;
                        break;
                    case ('I', 'X'):
                        result += 9;
                        index++;
                        break;
                    case ('M', _):
                        result += 1000;
                        break;
                    case ('D', _):
                        result += 500;
                        break;
                    case ('C', _):
                        result += 100;
                        break;
                    case ('L', _):
                        result += 50;
                        break;
                    case ('X', _):
                        result += 10;
                        break;
                    case ('V', _):
                        result += 5;
                        break;
                    case ('I', _):
                        result++;
                        break;
                }

                index++;
            }

            return result;
        }


        /// <summary>
        /// Using new C# features
        /// Another variant
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static public int RomanToInt3(string s)
        {
            int result = 0;
            int index = 0;

            while (index < s.Length)
            {
                char currentSymbol = s[index];
                char nextSymbol = (index + 1 < s.Length) ? s[index + 1] : '.';

                (int value, int indexStep) = (currentSymbol, nextSymbol) switch
                {
                    ('C', 'M') => (900, 2),
                    ('C', 'D') => (400, 2),
                    ('X', 'C') => (90, 2),
                    ('X', 'L') => (40, 2),
                    ('I', 'X') => (9, 2),
                    ('I', 'V') => (4, 2),
                    ('M', _) => (1000, 1),
                    ('D', _) => (500, 1),
                    ('C', _) => (100, 1),
                    ('L', _) => (50, 1),
                    ('X', _) => (10, 1),
                    ('V', _) => (5, 1),
                    ('I', _) => (1, 1),
                };

                result += value;
                index += indexStep;
            }

            return result;
        }
    }
}