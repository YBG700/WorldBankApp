using Android.Views;
using System;
using System.IO;
using System.Text.Json;

namespace WorldBankApp.LogicData
{
    public class Bank
    {
        // Account Data
        static List<Account> bankDatabase;

        // Loged In Account
        Account activeAccount = null;

        public static void Main(string[] args)
        {

            // Open and Read JSON Data
            string filePath = "LogicData/BankDatabase.json";

            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Save JSON
        public void SaveJSON()
        {

        }

        // Create Account
        public void CreateAccount()
        {

        }

        // Log in Account
        public void LoginAccount(string accNum, int accPin)
        {

        }

        // Edit Account
        public void EditAccount()
        {

        }

        // Deposit
        public void Deposit()
        {

        }

        // Withdraw
        public void Withdraw()
        {

        }

        // Check deals
    }
}
