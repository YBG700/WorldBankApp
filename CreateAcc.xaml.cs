namespace WorldBankApp;

public partial class CreateAcc : ContentPage
{
	public CreateAcc(string choice)
	{
		InitializeComponent();
        DecisionLabel.Text += choice;
	}

    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }

    
}