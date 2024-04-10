using WorldBankApp.LogicData;

namespace WorldBankApp
{
    public partial class SearchAcc : ContentPage
    {
        Bank bankMgr;

        public SearchAcc(Bank bank)
        {
            InitializeComponent();
            bankMgr = bank;
        }

        private async void BtnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
        }

        public void SearchBtn(object sender, EventArgs e)
        {
            try
            {
                // Checks if the ID is not empty and parsable into an int
                if (IdEntry.Text != "" && int.TryParse(IdEntry.Text, out int accNum))
                {
                    // Checks if the PIN is not empty and parsable into an int
                    if (PinEntry.Text != "" && int.TryParse(PinEntry.Text, out int accPin))
                    {
                        bankMgr.LoginAccount(accNum, accPin);
                    }
                    else
                    {
                        DisplayAlert("Invalid PIN", "Enter a valid PIN.", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Invalid ID", "Enter a valid account number.", "OK");
                }
            }
            catch (ArgumentException ex)
            {
                // Displays Error messages from Bank.cs
                DisplayAlert("Warning", ex.Message, "OK");
            }
        }
    }
}
