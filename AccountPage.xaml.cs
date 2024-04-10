using WorldBankApp.LogicData;

namespace WorldBankApp;

public partial class AccountPage : ContentPage
{
	Bank bankMgr;

	public AccountPage(Bank bank)
	{
		InitializeComponent();
		bankMgr = bank;
	}
}