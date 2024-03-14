namespace WorldBankApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void AccountSearch(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SearchAcc());

        }
    }

}
