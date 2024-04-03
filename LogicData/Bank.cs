using Microsoft.Maui.ApplicationModel.Communication;
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
                Account acc1 = new Account(10000, 1111, "John Doe", 1112223333, "johndoe@test.com");
                SavingsAccount acc2 = new SavingsAccount(1000, 10001, 1234, "Jane Doe", 9059451111, "doeJane@tester.ca");

                bankDatabase.Add(acc1);
                bankDatabase.Add(acc2);
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
        public void CreateAccount(int accNum, int accPin, string holderName, long phoneNum, string email)
        {
            Account acc = new Account(accNum, accPin, holderName, phoneNum, email);
            bankDatabase.Add(acc);
        }
        public void CreateSavingsAccount(int minBal, int accNum, int accPin, string holderName, long phoneNum, string email)
        {
            SavingsAccount acc = new SavingsAccount(minBal, accNum, accPin, holderName, phoneNum, email);
            bankDatabase.Add(acc);
        }
        public void CreateChequingAccount(int overDraftLimit, int accNum, int accPin, string holderName, long phoneNum, string email)
        {
            ChequingAccount acc = new ChequingAccount(overDraftLimit, accNum, accPin, holderName, phoneNum, email);
            bankDatabase.Add(acc);
        }

        // Log in Account
        public void LoginAccount(int accNum, int accPin)
        {
            if (activeAccount == null)
            {
                var acc = FindAccount(accNum);

                if (acc != null)
                {
                    if (acc.CheckPIN(accPin))
                    {
                        // Pin is Valid
                        activeAccount = acc;
                    }
                    else
                    {
                        // Pin is Invalid
                    }
                }
                else
                {
                    // No Account with Number Found
                }
            }
        }

        // Log out
        public void LogOut()
        {
            activeAccount = null;
        }

        // Find Account
        public static Account FindAccount(int accNum)
        {
            foreach (var acc in bankDatabase)
            {
                if (acc.AccNum == accNum)
                {
                    return acc;
                }
            }
            return null;
        }

        // Edit Account
        public void EditAccount()
        {
            // Either Save all information at the same time, or use switch case to save one entry at a time
        }

        // Deposit
        public void Deposit(int deposit)
        {
            activeAccount.CurrBal += deposit;
        }

        // Withdraw
        public void Withdraw(int withdraw)
        {
            // Savings Acount
            if (activeAccount is SavingsAccount)
            {
                // Checks if the current balance is greator than the required minium and if the withdraw does not go below the minimum.
                if (activeAccount.CurrBal > activeAccount.MinBal && (activeAccount.CurrBal - withdraw) >= activeAccount.MinBal)
                {
                    activeAccount.CurrBal -= withdraw;
                }
                else
                {
                    throw new ArgumentException("Not enough funds, going below required Minimum Balance.");
                }
            }

            // Chequing Account
            else if (activeAccount is ChequingAccount)
            {
                if (activeAccount.CurrBal < 0)
                {

                }
                else
                {
                    throw new ArgumentException("Not enough funds, surpassed Overdraft Limit.");
                }
            }

            // Base Account
            else if (activeAccount is Account)
            {
                // Checks if the current balance is greator than 0, and the withdraw does not go below zero.
                if (activeAccount.CurrBal > 0 && (activeAccount.CurrBal - withdraw) >= 0)
                {
                    activeAccount.CurrBal -= withdraw;
                }
                else
                {
                    throw new ArgumentException("Not enough funds.");
                }
            }

            // Unknown Account Type
            else
            {
                throw new ArgumentException("An Error has Occurred.");
            }
        }

        // Check deals
    }
}
