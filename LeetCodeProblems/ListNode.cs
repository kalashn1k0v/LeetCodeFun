namespace LeetCodeProblems
{
    /// <summary>
    /// Definition for singly-linked list from LeetCode
    /// </summary>
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
}