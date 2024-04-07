namespace WorldBankApp;

public partial class OpenAcc : ContentPage
{
	public OpenAcc()
	{
		InitializeComponent();
	}


    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }

}