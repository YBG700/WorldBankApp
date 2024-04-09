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

        // Constructor
        public Deals(string name, string desc, int length, DealEnum dealType)
        {
            dealName = name;
            dealDesc = desc;
            dealLength = length;
            type = dealType;
        }
    }
}