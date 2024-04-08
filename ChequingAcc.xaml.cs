namespace WorldBankApp;

public partial class ChequingAcc : ContentPage
{
	public ChequingAcc()
	{
		InitializeComponent();
	}

    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }


}