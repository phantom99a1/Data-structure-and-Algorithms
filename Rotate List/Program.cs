namespace Rotate_List
{
    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
    public class Solution
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null) return head;
            if (k == 0) return head;
            var (count, lastItem) = GetAuxData(head);
            if (count == 1 || k % count == 0) return head;
            var limit = count - (k % count) - 1;
            var last = head;
            for (int i = 0; i < limit; i++)
            {
                last = last.next;
            }
            var rs = last.next;
            last.next = null;
            lastItem.next = head;
            return rs;
        }
        private (int count, ListNode lastItem) GetAuxData(ListNode head)
        {
            var count = 1;
            var curr = head;
            while (curr.next != null)
            {
                count++;
                curr = curr.next;
            }
            return (count, curr);
        }
    }
}
