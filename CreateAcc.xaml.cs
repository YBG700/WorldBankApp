using WorldBankApp.LogicData;

namespace WorldBankApp;

public partial class CreateAcc : ContentPage
{
    Bank bankMgr;

    private string name;
    private string pin;
    private string email;
    private string phone;
    string accountType;
    private string selectedDate;

    public CreateAcc(Bank bank, string choice)
	{
		InitializeComponent();
        bankMgr = bank;

        DecisionLabel.Text = choice;
        accountType = choice;
	}

    private async void BtnSubmit1(object sender, EventArgs e) 
    {
        name = Name.Text;
        pin = PIN.Text;
        email = Email.Text;
        phone = PhoneNumber.Text;
        selectedDate = datePicker.Date.ToString();


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

        if (email.Contains("@") == false) 
        {
            await DisplayAlert("EMAIL", "MUST BE A VALID EMAIL!", "OK");
            return;
        }

        if (!int.TryParse(phone, out _) || phone.Length < 10)
        {
            await DisplayAlert("PHONE NUMBER", "HAVE ATLEAST 10 DIGITS!", "OK");
            return;
        }

        int accNum = bankMgr.GetNewAccountNumber();

        switch (accountType)
        {
            case "Basic Account":
                bankMgr.CreateAccount(accNum, int.Parse(pin), name, long.Parse(phone), email, 10.25, null);
                break;
            case "Chequings Account":
                bankMgr.CreateChequingAccount(500, accNum, int.Parse(pin), name, long.Parse(phone), email, 16.99, null);
                break;
            case "Savings Account":
                bankMgr.CreateSavingsAccount(500, accNum, int.Parse(pin), name, long.Parse(phone), email, 15.50, null);
                break;
        }

        bankMgr.LoginAccount(accNum, int.Parse(pin));
        OpenAccountPage();
    }

    private async void BtnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
    }

    public async void OpenAccountPage()
    {
        await Navigation.PushAsync(new AccountPage(bankMgr)); // Navigate to the AccountPage
    }
}