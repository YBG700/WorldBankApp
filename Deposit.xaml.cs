
using System.Net.NetworkInformation;
using System.Xml.Serialization;
using WorldBankApp.LogicData;

namespace WorldBankApp;

public partial class Deposit : ContentPage
{

    Bank bankMgr;

    private string money;

	public Deposit(Bank bank)
	{
		InitializeComponent();
        bankMgr = bank;

    }

	private async void DepositBtn(object sender, EventArgs e)
	{

		money = DepositAmount.Text;

		if (!double.TryParse(money, out double amount) || amount < 0 || string.IsNullOrEmpty(money))
        {

           await DisplayAlert("Amount!", "Please enter an amount", "OK");
			return;

        }

		bankMgr.Deposit(double.Parse(money));

		double newAmount = bankMgr.Getbalance();

		MoneyDeposit.Text = $"New Amount: {newAmount}";


	
	
	}

    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }

}