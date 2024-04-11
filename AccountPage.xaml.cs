using WorldBankApp.LogicData;

namespace WorldBankApp;

public partial class AccountPage : ContentPage
{
	Bank bankMgr;
    StackLayout DealsLayout;

    

    public AccountPage(Bank bank)
	{
		InitializeComponent();
		bankMgr = bank;
        DealsLayout = new StackLayout();

        AccountNum.Text = $"Account Number: {bankMgr.GetAccountNum()}";
        CurrentBal.Text = $"Current Balance: ${bankMgr.Getbalance()}";

        DisplayDeals();
	}


    private void DisplayDeals()
    {
        var deals = bankMgr.CheckDeals();
        if (deals != null)
        {
            foreach (var deal in deals)
            {

                LblDeals.Text = $"Deal: {deal.DealName}\nDescription: {deal.DealDesc}\nDuration: {deal.DealLength} months";
                
               
                DealsLayout.Children.Add(LblDeals);
            }
        }
        else
        {

            LblDeals.Text = "No deals available";

            
            DealsLayout.Children.Add(LblDeals);
        }
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