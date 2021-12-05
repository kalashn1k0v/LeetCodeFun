using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace LeetCodeProblems.Tests
{
    public class LT0027_Tests
    {
        // #27 https://leetcode.com/problems/remove-element/
        [Test]
        [TestCase(new int[] { }, 3, 0, new int[] { })]
        [TestCase(new int[] { 3 }, 3, 0, new int[] { })]
        [TestCase(new int[] { 1 }, 3, 1, new int[] { 1 })]
        [TestCase(new int[] { 3, 2, 2, 3 }, 3, 2, new int[] { 2, 2 })]
        [TestCase(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5, new int[] { 0, 1, 4, 0, 3 })]
        public void DoSmthTest(int[] nums, int val, int expectedLength, int[] expectedResult)
        {
            int[] collection = new[] { 1, 2, 5, 8 };
            collection.Should().BeEquivalentTo(new[] { 8, 2, 1, 5 });

            int resultLength = RemoveElement(nums, val);

            resultLength.Should().Be(expectedLength);
            nums.Take(resultLength).Should().BeEquivalentTo(expectedResult);
        }

        static public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;

            int resultIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                    continue;

                nums[resultIndex] = nums[i];
                resultIndex++;
            }

            return resultIndex;
        }
    }
}