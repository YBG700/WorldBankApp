namespace WorldBankApp.LogicData
{
    // Enum
    public enum DealEnum
    {
        StudentSavings,
        CreditPlus,
        Interest555
    }

    public class Deals
    {
        public string dealName;
        public string dealDesc;
        public int dealLength; // Months
        public DealEnum type;

        // Parameterless constructor for serialization
        public Deals() { }

        // Constructor
        public Deals(string name, string desc, int length, DealEnum dealType)
        {
            dealName = name;
            dealDesc = desc;
            dealLength = length;
            type = dealType;
        }

        // Getters - Setters
        public string DealName 
        {
            get { return dealName; }
            set { dealName = value; }
        }

        public string DealDesc 
        { 
            get { return dealDesc; } 
            set { dealDesc = value; }
        }

        public int DealLength 
        { 
            get { return dealLength; }
            set { dealLength = value; }
        }

        public DealEnum Type 
        { 
            get { return type; }
            set {  type = value; }
        }
    }
}