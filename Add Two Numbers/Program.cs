namespace Add_Two_Numbers
{
    /*You are given two non-empty linked lists representing two non-negative integers. 
     * The digits are stored in reverse order, and each of their nodes contains a single digit. 
     * Add the two numbers and return the sum as a linked list.
    You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    
    Constraint:
    The number of nodes in each linked list is in the range [1, 100].
    0 <= Node.val <= 9
    It is guaranteed that the list represents a number that does not have leading zeros.
    */
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = 100;
        private const int minValue = 0;
        private const int maxValue = 9;
        public static void Main()
        {
            List<int> list1;
            List<int> list2;
            List<string> errors;

            do
            {
                (list1, list2, errors) = GetValidInput("Enter two lists of numbers (format: list1;list2, e.g., 2,4,3;5,6,4): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var l1 = BuildLinkedList(list1);
            var l2 = BuildLinkedList(list2);
            var result = AddTwoNumbers(l1, l2);

            Console.WriteLine($"Result: [{LinkedListToString(result)}]");
            Console.ReadKey();
        }

        public static (List<int>, List<int>, List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] parts = input.Split(';');
            List<int> list1 = [];
            List<int> list2 = [];

            if (parts.Length != 2)
            {
                errors.Add("Input must contain two lists separated by ';'.");
                return (list1, list2, errors);
            }

            try
            {
                list1 = parts[0].Split(',').Select(int.Parse).ToList();
                list2 = parts[1].Split(',').Select(int.Parse).ToList();
            }
            catch
            {
                errors.Add("Each list must contain only numbers separated by ','.");
                return (list1, list2, errors);
            }

            if (list1.Count < minLength || list1.Count > maxLength || list2.Count < minLength || list2.Count > maxLength)
            {
                errors.Add($"The number of nodes in each linked list must be between {minLength} and {maxLength}.");
            }
            if (list1.Any(val => val < minValue || val > maxValue) || list2.Any(val => val < minValue || val > maxValue))
            {
                errors.Add($"Each node value must be between {minValue} and {maxValue}.");
            }
            if ((list1.Count > 1 && list1[0] == 0) || (list2.Count > 1 && list2[0] == 0))
            {
                errors.Add("The list represents a number that must not have leading zeros.");
            }
            
            return (list1, list2, errors);
        }

        public static ListNode? BuildLinkedList(List<int> numbers)
        {
            ListNode dummy = new();
            ListNode current = dummy;
            numbers.ForEach(num => {
                current.next = new ListNode(num);
                current = current.next;
            });
            return dummy.next;
        }

        public static ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            ListNode dummy = new();
            ListNode current = dummy;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
            }

            return dummy.next;
        }

        public static string LinkedListToString(ListNode? node)
        {
            List<int> result = [];
            while (node != null)
            {
                result.Add(node.val);
                node = node.next;
            }
            return string.Join(",", result);
        }
    }
}
