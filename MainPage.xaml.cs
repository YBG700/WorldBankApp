namespace WorldBankApp
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void AccountOpen(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new OpenAcc());//Navigates to the Open Account Page

        }

        private async void AccountSearch(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SearchAcc());//Navigates to Search Account Page

        }
    }

}
