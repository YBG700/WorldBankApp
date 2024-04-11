using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WorldBankApp.LogicData
{
    public class Bank
    {
        // Account Data
        static List<Account> bankDatabase = new List<Account>();

        // Deal Data
        static List<Deals> dealDatabase = new List<Deals>();

        // Loged In Account
        Account? activeAccount = null;

        // JSON Filepath
        string filePath;

        public void InitialLoad()
        {
            // Gets filepath for LogicData folder
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;

            // Assigns file path for JSON file
            filePath = Path.Combine(directoryPath, "DealDatabase.json");

            // Open and Read JSON Data
            try
            {
                if (File.Exists(filePath))
                {
                    // Load JSON
                    LoadJSON();
                }
                else
                {
                    // If File does not exist, create basic objects

                    // Basic Deal Object
                    Deals deal1 = new Deals("Student Savings", "Special offer for students. No monthly fees for the duration of their academic term.", 48, DealEnum.StudentSavings);
                    dealDatabase.Add(deal1);

                    // Save JSON
                    SaveJSON();
                }

                Account acc1 = new Account(10000, 1111, "John Doe", 1112223333, "johndoe@test.com", 15.50, null);
                SavingsAccount acc2 = new SavingsAccount(1000, 10001, 1234, "Jane Doe", 9059451111, "doeJane@tester.ca", 10.99, null);

                bankDatabase.Add(acc1);
                bankDatabase.Add(acc2);

                // Sorts the list by account number
                bankDatabase.Sort((x, y) => x.AccNum.CompareTo(y.AccNum));

                // Applies monthly fees and interest
                foreach (Account acc in bankDatabase)
                {
                    ChargeFee(acc);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Load JSON
        public void LoadJSON()
        {
            try
            {
                // Reads the Json File
                string jsonString = File.ReadAllText(filePath);

                // Assigns it to a list
                dealDatabase = JsonSerializer.Deserialize<List<Deals>>(jsonString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred during initialization: {ex.Message}");
            }
        }

        // Save JSON
        public void SaveJSON()
        {
            try
            {
                if (!File.Exists(filePath))
                { 
                    // Create file if it doesn't exist
                    File.Create(filePath).Close();
                }

                // Assigns new Serializer Options
                var options = new JsonSerializerOptions
                {
                    // Indents the JSON file for better readability
                    WriteIndented = true
                };

                // Converts the list into a string
                string jsonString = JsonSerializer.Serialize(dealDatabase, options);

                // Writes the string to the JSON file
                File.WriteAllText(filePath, jsonString);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred during saving: {ex.Message}");
            }
        }

        // Create Account
        public void CreateAccount(int accNum, int accPin, string holderName, long phoneNum, string email, double fee, Deals? deal)
        {
            Account acc = new Account(accNum, accPin, holderName, phoneNum, email, fee, deal);
            bankDatabase.Add(acc);
        }
        public void CreateSavingsAccount(int minBal, int accNum, int accPin, string holderName, long phoneNum, string email, double fee, Deals? deal)
        {
            SavingsAccount acc = new SavingsAccount(minBal, accNum, accPin, holderName, phoneNum, email, fee, deal);
            bankDatabase.Add(acc);
        }
        public void CreateChequingAccount(int overDraftLimit, int accNum, int accPin, string holderName, long phoneNum, string email, double fee, Deals? deal)
        {
            ChequingAccount acc = new ChequingAccount(overDraftLimit, accNum, accPin, holderName, phoneNum, email, fee, deal);
            bankDatabase.Add(acc);
        }

        // Log into Account
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
                        throw new ArgumentException("Incorrect Pin.");
                    }
                }
                else
                {
                    // No Account with Number Found
                    throw new ArgumentException("No Account Found.");
                }
            }
        }

        // Log out
        public void LogOut()
        {
            activeAccount = null;
        }

        // Find Account
        public static Account? FindAccount(int accNum)
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

        // Get an unused Account Number
        public int GetNewAccountNumber()
        {
            // If there are no other accounts, return first acc num
            if (bankDatabase == null || bankDatabase.Count == 0)
            {
                return 10000;
            }

            // Sort the list by acc num
            bankDatabase.Sort((x, y) => x.AccNum.CompareTo(y.AccNum));

            int num = 10000;

            // Searches for the first free account number
            foreach (Account acc in bankDatabase)
            {
                if (num != acc.AccNum)
                {
                    return num;
                }
                num++;
            }
            return num;
        }

        // Edit Account
        public void EditAccount()
        {
            // Either Save all information at the same time, or use switch case to save one entry at a time
        }

        // Deposit
        public void Deposit(double deposit)
        {
            if (activeAccount != null)
            {
                activeAccount.CurrBal += deposit;
            }
        }

        // Withdraw
        public void Withdraw(double withdraw)
        {
            if (activeAccount != null)
            {
                // Savings Acount
                if (activeAccount is SavingsAccount)
                {
                    // Checks if the current balance is greater than the required minium and if the withdraw does not go below the minimum.
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
                    if (activeAccount.CurrBal > (0 - activeAccount.OverdraftLimit) && (activeAccount.CurrBal - withdraw) > (0 - activeAccount.OverdraftLimit))
                    {
                        activeAccount.CurrBal -= withdraw;
                    }
                    else
                    {
                        throw new ArgumentException("Not enough funds, surpassed Overdraft Limit.");
                    }
                }

                // Base Account
                else if (activeAccount is Account)
                {
                    // Checks if the current balance is greater than 0, and the withdraw does not go below zero.
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
        }

        // Charge Monthly Fee
        public void ChargeFee(Account acc)
        {
            DateTime currentDate = DateTime.Now;

            // Checks if its a new month
            if (currentDate.Month != acc.LastFeeDate.Month)
            {
                // Checks if Account has deal which reduces or removes monthly fee OR adds interest
                if (acc.ActiveDeal != null)
                {
                    if (acc.ActiveDeal.type == DealEnum.StudentSavings)
                    {
                        // If account has StudentSavings deal
                        acc.LastFeeDate = DateTime.Now;
                    }
                    else if (acc.ActiveDeal.type == DealEnum.CreditPlus)
                    {
                        // If account has CreditPlus deal
                        acc.CurrBal -= (acc.MonthlyFee / 2);
                        acc.LastFeeDate = currentDate;
                    }
                    else if (acc.ActiveDeal.type == DealEnum.Interest555)
                    {
                        // If account has Interest555 deal
                        acc.CurrBal -= acc.MonthlyFee;
                        acc.LastFeeDate = currentDate;

                        AddInterest(acc);
                    }
                }
                else
                {
                    // If account has no active deal
                    if (acc is SavingsAccount)
                    {
                        // If account is a Savings Account
                        acc.CurrBal -= acc.MonthlyFee;
                        acc.LastFeeDate = currentDate;

                        AddInterest(acc);
                    }
                    else
                    {
                        // If not savings account
                        acc.CurrBal -= acc.MonthlyFee;
                        acc.LastFeeDate = currentDate;
                    }
                }
            }
        }

        // Add Monthly Interest
        public void AddInterest(Account acc)
        {
            // Checks if Active Deal is Interest555
            if (acc.ActiveDeal != null && acc.ActiveDeal.type == DealEnum.Interest555)
            {
                // Adds 5.55% interest to current balance
                acc.CurrBal += (acc.CurrBal * (5.55 / 100));
            }
            else
            {
                // Adds base 2% interest to current balance
                acc.CurrBal += (acc.CurrBal * (2 / 100));
            }
        }

        // Display Deal
        public List<Deals>? CheckDeals()
        {
            // Shows the deals to the user;

            // Two Approaches:
            // 1. Show all deals
            // 2. Show only valid deals to specific user

            return null;
        }

        // Get Active Deal for Account
        public Deals? GetActiveDeal()
        {
            if (activeAccount != null)
            {
                return activeAccount.ActiveDeal;
            }
            return null;
        }
    }
}