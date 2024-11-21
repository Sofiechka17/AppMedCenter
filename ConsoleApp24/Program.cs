namespace ConsoleApp24
{
    public delegate void BankAccountHandler(string message);
    internal class BankAccount
    {
        public int Id { get; set; }
        public int Summ { get; private set; }
        public BankAccount(int summ) =>
            this.Summ = summ;
        public void Put(int summ)
        {
            this.Summ += summ;
            AccountNotify?.Invoke($"на счет поступило {summ}");
        }

        public void Take(int summ)
        {
            if (this.Summ > summ)
            {
                Summ -= summ;
                AccountNotify?.Invoke($"со счета снято {summ}");
            }
            else
            {
                if (AccountNotify != null)
                    AccountNotify.Invoke($"недостаточно средств для снятия");
            }
        }
        public event BankAccountHandler AccountNotify;
    }
    class AccountEventArgs : EventArgs
    {
        public string Message;
        public AccountEventArgs(string text) =>
            Message = text;
    }
}
