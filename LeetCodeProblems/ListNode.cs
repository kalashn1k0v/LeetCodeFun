namespace LeetCodeProblems
{
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

        public override string ToString()
        {

            return $"{val} -> {next?.ToString() ?? "null" }";
        }
    }

    public class Util
    {

        public static ListNode ToLinkedList(int[] numbers)
        {
            if (numbers == null)
                return null;

            ListNode next = null;
            ListNode currentNode = null;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                currentNode = new ListNode(numbers[i], next);
                next = currentNode;
            }
            return currentNode;
        }

    }
}