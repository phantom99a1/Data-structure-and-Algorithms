namespace Simple_Bank_System
{
    public class Bank
    {
        private long[] balance;

        public Bank(long[] balance)
        {
            this.balance = balance;
        }

        private bool IsValid(int account)
        {
            return account >= 1 && account <= balance.Length;
        }

        public bool Transfer(int account1, int account2, long money)
        {
            if (!IsValid(account1) || !IsValid(account2)) return false;
            if (balance[account1 - 1] < money) return false;
            balance[account1 - 1] -= money;
            balance[account2 - 1] += money;
            return true;
        }

        public bool Deposit(int account, long money)
        {
            if (!IsValid(account)) return false;
            balance[account - 1] += money;
            return true;
        }

        public bool Withdraw(int account, long money)
        {
            if (!IsValid(account)) return false;
            if (balance[account - 1] < money) return false;
            balance[account - 1] -= money;
            return true;
        }
    }
}
