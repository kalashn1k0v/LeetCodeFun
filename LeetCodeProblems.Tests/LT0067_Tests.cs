using FluentAssertions;
using NUnit.Framework;
using System;
using System.Text;

namespace LeetCodeProblems.Tests;

public class LT0067_Tests
{
    // #67 https://leetcode.com/problems/add-binary/
    [Test]
    [TestCase("11", "1", "100")]
    [TestCase("1", "11", "100")]
    [TestCase("1010", "1011", "10101")]
    public void AddBinary_Test(string a, string b, string expectedResult)
    {
        var result = AddBinary(a, b);

        result.Should().Be(expectedResult);
    }

    public static string AddBinary(string a, string b)
    {
        var sb = new StringBuilder(Math.Max(a.Length, b.Length) + 1);
        sb.Length = sb.Capacity;

        int minLength = Math.Min(a.Length, b.Length);

        int carryover = 0;
        for (int i = 0; i < minLength; i++)
        {
            int d1 = a[^(i + 1)] == '0' ? 0 : 1;
            int d2 = b[^(i + 1)] == '0' ? 0 : 1;

            int sum = d1 + d2 + carryover;
            carryover = sum / 2;

            sb[^(i + 1)] = sum % 2 == 0 ? '0' : '1';
        }

        if (carryover > 0)
        {
            sb[0] = '1';
            return sb.ToString();
        }

        return sb.ToString(1, sb.MaxCapacity - 1);
    }
}