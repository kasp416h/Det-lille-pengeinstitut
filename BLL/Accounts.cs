using DAL;

namespace BLL
{
    public class Accounts
    {
        private JsonHandler _JsonHandler;
        public Accounts(JsonHandler jsonHandler)
        {
            _JsonHandler = jsonHandler;
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
            List<Account> accounts = _JsonHandler.Read<Account>();

            int fullBalance = accounts.Sum(account => account.balance);

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
