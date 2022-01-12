using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0021_Tests
{
    // #21 https://leetcode.com/problems/merge-two-sorted-lists/
    [Test]
    [TestCase(new int[] { }, new int[] { }, new int[] { })]
    [TestCase(new int[] { }, new[] { 0 }, new[] { 0 })]
    [TestCase(new[] { 0 }, new int[] { }, new[] { 0 })]
    [TestCase(new[] { -1 }, new int[] { }, new[] { -1 })]
    [TestCase(new[] { 0 }, new[] { 0 }, new[] { 0, 0 })]
    [TestCase(new[] { -1 }, new[] { -2 }, new[] { -2, -1 })]
    [TestCase(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
    [TestCase(new[] { 1, 2 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4 })]
    [TestCase(new[] { 1, 2, 4 }, new[] { 1, 3 }, new[] { 1, 1, 2, 3, 4 })]
    public void MergeTwoListsTest(int[] numbers1, int[] numbers2, int[] expectedResult)
    {
        var list1 = numbers1.ToLinkedList();
        var list2 = numbers2.ToLinkedList();

        var result = MergeTwoLists(list1, list2);

        result.Should().BeEquivalentTo(expectedResult.ToLinkedList());
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