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

        bankMgr.Withdraw(double.Parse(money));

        MoneyWithdrawl.Text = $"New Amount: {money}";




    }

    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }

}