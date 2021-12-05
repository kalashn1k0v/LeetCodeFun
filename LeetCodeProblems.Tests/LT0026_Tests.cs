using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests
{
    public class LT0026_Tests
    {
        // #26 https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        [Test]
        [TestCase(new int[] { }, 0, new int[] { })]
        [TestCase(new int[] { 1 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 1, 1, 2 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5, new int[] { 0, 1, 2, 3, 4 })]
        public void DoSmthTest(int[] nums, int expectedLength, int[] expectedResult)
        {
            var resultLength = RemoveDuplicates(nums);

            resultLength.Should().Be(expectedLength);

            for (int i = 0; i < resultLength; i++)
            {
                nums[i].Should().Be(expectedResult[i]);
            }
        }

        static public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;

            int iterSortedVals = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    iterSortedVals++;
                    nums[iterSortedVals] = nums[i];
                }
            }

            return iterSortedVals + 1;
        }
    }
}