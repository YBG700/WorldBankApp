namespace WorldBankApp;

public partial class OpenAcc : ContentPage
{
	public OpenAcc()
	{
		InitializeComponent();
	}

    //Navigates to ChequingAccount Creation Page
    private void ChequingAcc(Object sender, EventArgs e) 
    { 
    
        
    }

    //Navigates to SavingAccount Creation Page
    private void SavingAcc(Object sender, EventArgs e)
    {


    }


    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }

}