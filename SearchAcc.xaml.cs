using WorldBankApp.LogicData;

namespace WorldBankApp
{
    public partial class SearchAcc : ContentPage
    {
        Bank bankMgr;

        public SearchAcc(Bank bank)
        {
            InitializeComponent();
            bankMgr = bank;
        }

        private async void BtnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
        }

        public void SearchBtn(object sender, EventArgs e)
        {

        }
    }
}
