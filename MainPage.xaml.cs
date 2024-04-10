using WorldBankApp.LogicData;

namespace WorldBankApp
{
    public partial class MainPage : ContentPage
    {
        Bank bankMgr = new Bank();

        public MainPage()
        {
            InitializeComponent();
            bankMgr.InitialLoad();
        }

        private async void AccountOpen(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new OpenAcc(bankMgr));//Navigates to the Open Account Page

        }

        private async void AccountSearch(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SearchAcc(bankMgr));//Navigates to Search Account Page

        }
    }
}
