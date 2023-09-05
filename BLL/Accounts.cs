using DAL;

namespace BLL
{
    public class Accounts
    {
        private JsonHandler _JsonHandler;
        public Accounts()
        {
            _JsonHandler = new JsonHandler("C:\\Users\\HFGF\\source\\repos\\Frontend\\DAL\\Accounts.json");
        }
        public void CreateAccount(string accountName, string customerId)
        {
            Account newAccount = new Account { name = accountName, accountId = Guid.NewGuid().ToString(), customerRelation = customerId, balance = 0 };

            List<Account> accounts = _JsonHandler.Read<Account>();
            
            accounts.Add(newAccount);

            _JsonHandler.Write(accounts);
        }
        public List<Account> GetAccounts()
        {
            List<Account> accounts = _JsonHandler.Read<Account>();

            return accounts;
        }
        public int FullBalance()
        {
            int fullBalance = 0;

            List<Account> accounts = _JsonHandler.Read<Account>();

            foreach (Account account in accounts)
            {
                fullBalance += account.balance;
            }

            return fullBalance;
        }
        public Account DeleteAccount(string accountId)
        {
            List<Account> accounts = _JsonHandler.Read<Account>();

            Account? account = accounts.FirstOrDefault(account => account.accountId == accountId);

            accounts.Remove(account);

            _JsonHandler.Write(accounts);

            return account;
        }
        public Account InsertMoney(string accountId, int money)
        {
            List<Account> accounts = _JsonHandler.Read<Account>();

            Account? account = accounts.FirstOrDefault(account => account.accountId == accountId);

            account.balance += money;

            _JsonHandler.Write(accounts);

            return account;
        }
    }
}
