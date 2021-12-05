namespace LeetCodeProblems
{
    public static class Util
    {
        public static ListNode ToLinkedList(this int[] numbers)
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