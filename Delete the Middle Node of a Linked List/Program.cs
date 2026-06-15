namespace Delete_the_Middle_Node_of_a_Linked_List
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
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head.next == null) { return head.next; }
            ListNode f = head, d = head;
            while (d.next != null && d.next.next != null && d.next.next.next != null)
            {
                d = d.next.next;
                f = f.next;
            }
            f.next = f.next.next;
            return head;
        }
    }
}
