using WorldBankApp.LogicData;

namespace WorldBankApp;

public partial class Withdraw : ContentPage
{
    Bank bankMgr;

    private string money;

    public Withdraw(Bank bank)
	{
		InitializeComponent();
        bankMgr = bank;


	}

    private async void WithdrawlBtn(object sender, EventArgs e)
    {

        money = WithdrawAmount.Text;

        if (!double.TryParse(money, out double amount) || amount < 0 || string.IsNullOrEmpty(money))
        {

            await DisplayAlert("Amount!", "Please enter an amount", "OK");
            return;

        }

        try
        {
            bankMgr.Withdraw(double.Parse(money));

            double newAmount = bankMgr.Getbalance();

            MoneyWithdrawl.Text = $"New Balance: ${newAmount}";
        }
        catch (ArgumentException ex)
        {
            // Displays Error messages from Bank.cs
            await DisplayAlert("Warning", ex.Message, "OK");
        }
    }

    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }

}