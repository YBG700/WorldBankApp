namespace WorldBankApp.LogicData
{
    public class Account
    {
        // Standard Account
        private int _accNum;
        private int _accPin;
        private string _accHolderName;
        private long _accPhoneNum;
        private string _accEmail;
        private int _currBal;

        // Constructor
        public Account(int accNum, int accPin, string holderName, long phoneNum, string email)
        {
            _accNum = accNum;
            _accPin = accPin;
            _accHolderName = holderName;
            _accPhoneNum = phoneNum;
            _accEmail = email;
            _currBal = 0;
        }

        // Getters - Setters
        public int AccNum
        {
            get { return _accNum; }
            set { _accNum = value; }
        }

        public string AccHolderName
        {
            get { return _accHolderName; }
            set { _accHolderName = value; }
        }

        public long AccPhoneNum
        {
            get { return _accPhoneNum; }
            set { _accPhoneNum = value; }
        }

        public string AccEmail
        {
            get { return _accEmail; }
            set { _accEmail = value; }
        }

        public int CurrBal
        {
            get { return _currBal; }
            set { _currBal = value; }
        }

        // Check PIN
        public bool CheckPIN(int inputPin)
        {
            return _accPin == inputPin;
        }
    }

    public class SavingsAccount : Account
    {
        // Savings Account
        private int _minBal;

        // Constructor
        public SavingsAccount(int minBal, int accNum, int accPin, string holderName, long phoneNum, string email)
            : base(accNum, accPin, holderName, phoneNum, email)
        {
            _minBal = minBal;
        }

        // Getters - Setters
        public int MinBal
        {
            get { return _minBal; }
            set { _minBal = value; }
        }
    }

    public class ChequingAccount : Account
    {
        // Chequing Account
        private int _overDraftLimit;

        // Constructor
        public ChequingAccount(int overDraftLimit, int accNum, int accPin, string holderName, long phoneNum, string email)
            : base(accNum, accPin, holderName, phoneNum, email)
        {
            _overDraftLimit = overDraftLimit;
        }

        // Getters - Setters
        public int OverdraftLimit
        {
            get { return _overDraftLimit; }
            set { _overDraftLimit = value; }
        }
    }
}
