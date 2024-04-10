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
        private double _currBal;
        private double _monthlyFee;
        private DateTime _lastFeeDate;
        private Deals? _activeDeal;

        // Constructor
        public Account(int accNum, int accPin, string holderName, long phoneNum, string email, double fee, Deals? activeDeal)
        {
            _accNum = accNum;
            _accPin = accPin;
            _accHolderName = holderName;
            _accPhoneNum = phoneNum;
            _accEmail = email;
            _currBal = 0;
            _monthlyFee = fee;
            _activeDeal = activeDeal;
            _lastFeeDate = DateTime.Now;
        }

        // Parameterless constructor for deserialization
        public Account()
        {
            _accNum = 0;
            _accPin = 0;
            _accHolderName = "";
            _accPhoneNum = 0;
            _accEmail = "";
            _currBal = 0;
            _monthlyFee = 0;
            _activeDeal = null;
            _lastFeeDate = DateTime.MinValue;
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

        public double CurrBal
        {
            get { return _currBal; }
            set { _currBal = value; }
        }

        public double MonthlyFee
        {
            get { return _monthlyFee; }
            set { _monthlyFee = value; }
        }

        public DateTime LastFeeDate
        {
            get { return _lastFeeDate; }
            set { _lastFeeDate = value; }
        }

        public Deals? ActiveDeal
        {
            get { return _activeDeal; }
            set { _activeDeal = value; }
        }

        // Check PIN
        public bool CheckPIN(int inputPin)
        {
            return _accPin == inputPin;
        }

        // Virtual Methods
        public virtual double MinBal 
        { 
            get { return 0; }
            set { }
        }

        public virtual double OverdraftLimit
        {
            get { return 0; }
            set { }
        }
    }

    public class SavingsAccount : Account
    {
        // Savings Account
        private double _minBal;

        // Constructor
        public SavingsAccount(int minBal, int accNum, int accPin, string holderName, long phoneNum, string email, double fee, Deals? activeDeal)
            : base(accNum, accPin, holderName, phoneNum, email, fee, activeDeal)
        {
            _minBal = minBal;
        }

        // Getters - Setters
        public override double MinBal
        {
            get { return _minBal; }
            set { _minBal = value; }
        }
    }

    public class ChequingAccount : Account
    {
        // Chequing Account
        private double _overDraftLimit;

        // Constructor
        public ChequingAccount(int overDraftLimit, int accNum, int accPin, string holderName, long phoneNum, string email, double fee, Deals? activeDeal)
            : base(accNum, accPin, holderName, phoneNum, email, fee, activeDeal)
        {
            _overDraftLimit = overDraftLimit;
        }

        // Getters - Setters
        public override double OverdraftLimit
        {
            get { return _overDraftLimit; }
            set { _overDraftLimit = value; }
        }
    }
}
