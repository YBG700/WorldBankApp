using WorldBankApp.LogicData;

namespace WorldBankApp;

public partial class AccountPage : ContentPage
{
	Bank bankMgr;

	public AccountPage(Bank bank)
	{
		InitializeComponent();
		bankMgr = bank;
	}

	private async void BtnWithdraw(object sender, EventArgs e) 
	{


        await Navigation.PushAsync(new Withdraw(bankMgr));

    }

    private async void BtnDeposit(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new Deposit(bankMgr));

    }

    private async void BtnLogout(object sender, EventArgs e)
    {

		bankMgr.LogOut();
		await Navigation.PushAsync(new MainPage());//Return to title Screen

    }

    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }
}