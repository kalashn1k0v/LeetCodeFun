using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests
{
    public class LT0021_Tests
    {
        // #21 https://leetcode.com/problems/merge-two-sorted-lists/
        [Test]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { }, new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 0 }, new int[] { }, new int[] { 0 })]
        [TestCase(new int[] { -1 }, new int[] { }, new int[] { -1 })]
        [TestCase(new int[] { 0 }, new int[] { 0 }, new int[] { 0, 0 })]
        [TestCase(new int[] { -1 }, new int[] { -2 }, new int[] { -2, -1 })]
        [TestCase(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 4 }, new int[] { 1, 3 }, new int[] { 1, 1, 2, 3, 4 })]
        public void MergeTwoListsTest(int[] numbers1, int[] numbers2, int[] expectedResult)
        {
            ListNode list1 = Util.ToLinkedList(numbers1);
            ListNode list2 = Util.ToLinkedList(numbers2);

            var result = MergeTwoLists(list1, list2);

            result.Should().BeEquivalentTo(Util.ToLinkedList(expectedResult));
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode lastResultNode = null;
            ListNode head = null;

            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;

            while (list1 != null && list2 != null)
            {
                int nextValue;
                if (list1.val < list2.val)
                {
                    nextValue = list1.val;
                    list1 = list1.next;
                }
                else
                {
                    nextValue = list2.val;
                    list2 = list2.next;
                }

                var newNode = new ListNode(nextValue);

                if (lastResultNode == null)
                {
                    lastResultNode = newNode;
                    head = lastResultNode;
                }
                else
                {
                    lastResultNode.next = newNode;
                    lastResultNode = lastResultNode.next;
                }
            }

            if (list1 == null)
                lastResultNode.next = list2;
            else
                lastResultNode.next = list1;

            return head;
        }

    }
}