using WorldBankApp.LogicData;

namespace WorldBankApp;

public partial class OpenAcc : ContentPage
{
    Bank bankMgr;

    public OpenAcc(Bank bank)
	{
		InitializeComponent();
        bankMgr = bank;
	}

    //Navigates to ChequingAccount Creation Page
    private async void ChequingAcc(Object sender, EventArgs e) 
    {

        await Navigation.PushAsync(new CreateAcc(bankMgr, "Chequings Account"));//Navigates to Create Account Page

    }

    //Navigates to SavingAccount Creation Page
    private async void SavingAcc(Object sender, EventArgs e)
    {

        await Navigation.PushAsync(new CreateAcc(bankMgr, "Savings Account"));//Navigates to Create Account

    }


    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }

}