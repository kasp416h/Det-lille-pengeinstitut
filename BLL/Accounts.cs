namespace BLL
{
    public static class Accounts
    {
        public static void CreateAccount()
        {
            Console.WriteLine("Konti navn");
            string accountName = Console.ReadLine();

            Console.WriteLine("Kunde id");
            string customerId = Console.ReadLine();

            DAL.Accounts.CreateAccount(accountName, customerId);

            Console.WriteLine($"Ny konti oprettede for {accountName}");
        }
        public static void GetAccounts()
        {
            List<DAL.Account> accounts = DAL.Accounts.GetAccounts();

            foreach (DAL.Account account in accounts)
            {
                Console.WriteLine($"Konti navn: {account.name}, Konti id: {account.accountId}, Konti ejer id: {account.customerRelation}, Saldo: {account.balance}");
                Console.WriteLine();
            }
        }
        public static void FullBalance()
        {
            Console.WriteLine(DAL.Accounts.FullBalance());
        }
        public static void DeleteAccount(string accountId)
        {
            DAL.Accounts.DeleteAccount(accountId);
        }
        public static void InsertMoney(string accountId, int money)
        {
            DAL.Accounts.InsertMoney(accountId, money);
        }
    }
}
