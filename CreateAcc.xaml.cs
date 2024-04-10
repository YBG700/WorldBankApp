using WorldBankApp.LogicData;

namespace WorldBankApp;

public partial class CreateAcc : ContentPage
{
    Bank bankMgr;

    private string name;
    private string pin;
    private string email;
    private string phone;
    private int balance;
    private int accNumber;

    Random random = new Random();
    public CreateAcc(Bank bank, string choice)
	{
		InitializeComponent();
        bankMgr = bank;

        DecisionLabel.Text += choice;
        string _account = DecisionLabel.Text;
	}

    private async void BtnSubmit1(object sender, EventArgs e) 
    {
        name = Name.Text;
        pin = PIN.Text;
        email = Email.Text;
        phone = PhoneNumber.Text;

        
        if (string.IsNullOrEmpty(name))
        {
            await DisplayAlert("NAME", "PLEASE ENTER YOUR NAME", "OK");
            return; 
        }

        
        if (string.IsNullOrEmpty(pin))
        {
            await DisplayAlert("PIN", "PLEASE ENTER A PIN NUMBER!", "OK");
            return; 
        }

        if (string.IsNullOrEmpty(email))
        {
            await DisplayAlert("EMAIL", "PLEASE ENTER A Valid EMAIL", "OK");
            return;
        }


        if (!int.TryParse(pin, out _) || pin.Length != 4)
        {
            await DisplayAlert("PIN", "PIN MUST BE A 4-DIGIT NUMBER!", "OK");
            return; 
        }

        if(email.Contains("@") == false) 
        {
            await DisplayAlert("EMAIL", "MUST BE A VALID EMAIL!", "OK");
            return;
        }

        if (!int.TryParse(phone, out _) || phone.Length < 10)
        {
            await DisplayAlert("PHONE NUMBER", "HAVE ATLEAST 10 DIGITS!", "OK");
            return;
        }


        SubmitBtn.IsEnabled = false;
        balance = random.Next(0, 1001);
        accNumber = random.Next(100000, 1000000);

        Button newButton = new Button
        {
            Text = $"Your Account Number:{accNumber} \n Your balance: {balance}",
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.Center


        };

        // Set up event handler for button click
        newButton.Clicked += newButtonClicked;


        // Add the button to the content of the page
        Content = newButton;

    }



    private async void newButtonClicked(object sender, EventArgs e) 
    {

        await Navigation.PushAsync(new MainPage());

    }
    
    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }

    
}