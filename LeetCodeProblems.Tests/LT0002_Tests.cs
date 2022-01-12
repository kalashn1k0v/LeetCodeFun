using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests;

public class LT0002_Tests
{
    // #2 https://leetcode.com/problems/add-two-numbers/
    [Test]
    [TestCase(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [TestCase(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [TestCase(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void AddTwoNumbersTest(int[] numbers1, int[] numbers2, int[] expectedResult)
    {
        var list1 = numbers1.ToLinkedList();
        var list2 = numbers2.ToLinkedList();

        var result = AddTwoNumbers(list1, list2);

        result.Should().BeEquivalentTo(expectedResult.ToLinkedList());
    }

    private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode head = null;
        var currentNode = head;

        var carry = 0;
        while (l1 != null || l2 != null || carry != 0)
        {
            var currL1val = l1 != null ? l1.val : 0;
            var currL2val = l2 != null ? l2.val : 0;

            var newValue = (currL1val + currL2val + carry) % 10;
            carry = (currL1val + currL2val + carry) / 10;

            if (head == null)
            {
                head = new ListNode(newValue);
                currentNode = head;
            }
            else
            {
                currentNode.next = new ListNode(newValue);
                currentNode = currentNode.next;
            }

            if (l1 != null)
                l1 = l1.next;
            if (l2 != null)
                l2 = l2.next;
        }

        return head;
    }
}