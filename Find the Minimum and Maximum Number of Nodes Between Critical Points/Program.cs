namespace Find_the_Minimum_and_Maximum_Number_of_Nodes_Between_Critical_Points
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
        public int[] NodesBetweenCriticalPoints(ListNode head)
        {
            var pointer = head;

            while (pointer.next != null)
            {
                if ((pointer.next?.val > pointer.val && pointer.next?.val > pointer.next?.next?.val) ||
                    (pointer.next?.val < pointer.val && pointer.next?.val < pointer.next?.next?.val))
                    break;

                pointer = pointer.next;
            }

            if (pointer == null) return [-1, -1];

            var max = 0;
            var min = int.MaxValue;

            var currentMin = 0;
            var step = 0;

            while (pointer.next != null)
            {
                if ((pointer.next?.val > pointer.val && pointer.next?.val > pointer.next?.next?.val) ||
                    (pointer.next?.val < pointer.val && pointer.next?.val < pointer.next?.next?.val))
                {
                    max = step;
                    if (currentMin > 0)
                    {
                        min = Math.Min(currentMin, min);
                        currentMin = 0;
                    }
                }

                pointer = pointer.next;
                step++;
                currentMin++;
            }

            if (max == 0 || min == int.MaxValue) return [-1, -1];

            return [min, max];
        }
    }
}
