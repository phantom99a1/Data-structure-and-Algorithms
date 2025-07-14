namespace Convert_Binary_Number_in_a_Linked_List_to_Integer
{

    public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }
     }

    public class Solution
    {
        public int GetDecimalValue(ListNode head)
        {
            int num = 0;
            while (head != null)
            {
                num = (num << 1) | head.val;
                head = head.next;
            }
            return num;
        }
    }
}
