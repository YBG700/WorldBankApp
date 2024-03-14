namespace WorldBankApp
{
    public partial class SearchAcc : ContentPage
    {
        public SearchAcc()
        {
            InitializeComponent();
        }

        private async void BtnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Use PopAsync to navigate back to the previous page
        }
    }
}
