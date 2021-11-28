using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeProblems.Tests
{
    public class LT0002_Tests
    {
        // #2 https://leetcode.com/problems/add-two-numbers/
        [Test]
        [TestCase(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 7, 0, 8 })]
        [TestCase(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 9, 9, 9, 9, 9, 9, 9 }, new int[] { 9, 9, 9, 9 }, new int[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
        public void AddTwoNumbersTest(int[] numbers1, int[] numbers2, int[] expectedResult)
        {
            ListNode list1 = ConstructLinkedList(numbers1);
            ListNode list2 = ConstructLinkedList(numbers2);

            var result = AddTwoNumbers(list1, list2);

            result.Should().BeEquivalentTo(ConstructLinkedList(expectedResult));
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode currentNode = head;

            int carry = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                int currL1val = (l1 != null) ? l1.val : 0;
                int currL2val = (l2 != null) ? l2.val : 0;

                int newValue = (currL1val + currL2val + carry) % 10;
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



        private ListNode ConstructLinkedList(int[] numbers)
        {
            ListNode next = null;
            ListNode currentNode = null;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                currentNode = new ListNode(numbers[i], next);
                next = currentNode;
            }
            return currentNode;
        }

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}