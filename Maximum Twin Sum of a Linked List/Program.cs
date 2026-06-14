namespace Maximum_Twin_Sum_of_a_Linked_List
{
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
    public class Solution
    {
        public int PairSum(ListNode head)
        {
            ListNode slow = head, fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode prev = null;

            while (slow != null)
            {
                ListNode next = slow.next;
                slow.next = prev;
                prev = slow;
                slow = next;
            }

            int ans = 0;

            while (prev != null)
            {
                ans = Math.Max(ans, head.val + prev.val);
                head = head.next;
                prev = prev.next;
            }

            return ans;
        }
    }
}
