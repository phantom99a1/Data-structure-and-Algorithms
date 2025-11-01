namespace Delete_Nodes_From_Linked_List_Present_in_Array
{
    public class Solution
    {
        public ListNode ModifiedList(int[] nums, ListNode head)
        {
            HashSet<int> set = new HashSet<int>(nums);

            ListNode dummy = new ListNode(0, head);
            ListNode pointer = dummy;

            while (pointer.next != null)
            {
                if (set.Contains(pointer.next.val))
                {
                    pointer.next = pointer.next.next;
                }
                else
                {
                    pointer = pointer.next;
                }
            }
            return dummy.next;
        }
    }

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
