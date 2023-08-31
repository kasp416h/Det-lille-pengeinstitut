using Newtonsoft.Json;

namespace DAL
{
    public static class Accounts
    {
        private static string accountfilePath = "C:\\Users\\HFGF\\source\\repos\\Frontend\\DAL\\Accounts.json";
        public static void CreateAccount(string accountName, string customerId)
        { 
            string fileContent = File.ReadAllText(accountfilePath);

            List<Account>? accounts = JsonConvert.DeserializeObject<List<Account>>(fileContent);

            Account newAccount = new Account { name = accountName, accountId = Guid.NewGuid().ToString(), customerRelation = customerId, balance = 0 };

            accounts.Add(newAccount);

            string updatedFileContent = JsonConvert.SerializeObject(accounts, Formatting.Indented);

            File.WriteAllText(accountfilePath, updatedFileContent);
        }
        public static List<Account> GetAccounts()
        {
            string fileContent = File.ReadAllText(accountfilePath);

            List<Account>? accounts = JsonConvert.DeserializeObject<List<Account>>(fileContent);

            return accounts;
        }
        public static int FullBalance()
        {
            int result = 0;

            string fileContent = File.ReadAllText(accountfilePath);

            List<Account>? accounts = JsonConvert.DeserializeObject<List<Account>>(fileContent);

            foreach (Account account in accounts)
            {
                result += account.balance;
            }

            return result;
        }
        public static void DeleteAccount(string accountId)
        {
            string fileContent = File.ReadAllText(accountfilePath);

            List<Account>? accounts = JsonConvert.DeserializeObject<List<Account>>(fileContent);

            Account? account = accounts.FirstOrDefault(account => account.accountId == accountId);

            accounts.Remove(account);

            string updatedFileContent = JsonConvert.SerializeObject(accounts, Formatting.Indented);

            File.WriteAllText(accountfilePath, updatedFileContent);

            Console.WriteLine($"Konti {account.name} er blevet slettet");
        }
        public static void InsertMoney(string accountId, int money)
        {
            string fileContent = File.ReadAllText(accountfilePath);

            List<Account>? accounts = JsonConvert.DeserializeObject<List<Account>>(fileContent);

            Account? account = accounts.FirstOrDefault(account => account.accountId == accountId);

            account.balance += money;

            string updatedFileContent = JsonConvert.SerializeObject(accounts, Formatting.Indented);

            File.WriteAllText(accountfilePath, updatedFileContent);

            Console.WriteLine($"Ny saldo {account.balance}");
        }
    }
}