namespace WorldBankApp.LogicData
{
    class Account
    {
        // Standard Account
        private int _accNum;
        private string _accHolderName;
        private int _accPhoneNum;
        private string _accEmail;
        private int _currBal;

        // Constructor
        public Account(int accNum, string holderName, int phoneNum, string email)
        {
            _accNum = accNum;
            _accHolderName = holderName;
            _accPhoneNum = phoneNum;
            _accEmail = email;
            _currBal = 0;
        }
    }

    class SavingsAccount : Account
    {
        // Savings Account
        private int _minBal;

        // Constructor
        public SavingsAccount(int minBal, int accNum, string holderName, int phoneNum, string email)
            : base(accNum, holderName, phoneNum, email)
        {
            _minBal = minBal;
        }
    }

    class ChequingAccount : Account
    {
        // Chequing Account
        private int _overDraftLimit;

        // Constructor
        public ChequingAccount(int overDraftLimit, int accNum, string holderName, int phoneNum, string email)
            : base(accNum, holderName, phoneNum, email)
        {
            _overDraftLimit = overDraftLimit;
        }
    }
}
