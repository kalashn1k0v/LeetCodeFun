using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests
{
    public class LT1_Tests
    {
        // #1 https://leetcode.com/problems/two-sum/
        [Test]
        [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [TestCase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
        [TestCase(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        public void TwoSumTest(int[] nums, int target, int[] expectedResult)
        {
            int[] result = TwoSum(nums, target);

            result.Should().BeEquivalentTo(expectedResult);

        }

        static int[] TwoSum(int[] nums, int target)
        {
            int index1 = 0;
            int index2 = 1;

            bool targetFound = false;


            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        targetFound = true;
                        index1 = i;
                        index2 = j;
                        break;
                    }
                }

                if (targetFound)
                    break;
            }

            return new[] { index1, index2 };
        }
    }
}