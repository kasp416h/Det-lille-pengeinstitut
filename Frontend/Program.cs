using BLL;

namespace Frontend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hvad skal vi så i dag?");

            Console.WriteLine("1. Oprette en kunde?");
            Console.WriteLine("2. Oprette en konti?");
            Console.WriteLine("3. Vise alle kundernes konti?");
            Console.WriteLine("4. Giv samlede kapital på alle konti?");
            Console.WriteLine("5. Slette en kunde / konti?");
            Console.WriteLine("6. Indsætte penge på en konti?");

            int option = int.Parse(Console.ReadLine());

            Accounts Accounts = new Accounts();
            Customers Customers = new Customers();
            
            switch (option)
            {
                case 1:
                    Console.WriteLine("Kunde CPR");
                    string customerCPR = Console.ReadLine();

                    Console.WriteLine("Kunde navn");
                    string customerName = Console.ReadLine();

                    Customers.CreateCustomer(customerCPR, customerName);

                    Console.WriteLine($"Ny konti oprettede for {customerName}");
                    break;
                case 2:
                    Console.WriteLine("Konti navn");
                    string accountName = Console.ReadLine();

                    Console.WriteLine("Kunde id");
                    string customerId = Console.ReadLine();

                    Accounts.CreateAccount(accountName, customerId);

                    Console.WriteLine($"Ny konti oprettede for {accountName}");
                    break;
                case 3:
                    List<Account> accounts = Accounts.GetAccounts();

                    foreach (Account getAccount in accounts)
                    {
                        Console.WriteLine($"Konti navn: {getAccount.name}, Konti id: {getAccount.accountId}, Konti ejer id: {getAccount.customerRelation}, Saldo: {getAccount.balance}");
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    int fullBalance = Accounts.FullBalance();

                    Console.WriteLine($"Samlede saldo af alle kontier er {fullBalance}kr.");
                    break;
                case 5:
                    Console.WriteLine("Hvad vil du slette? 1 for kunde, 2 for konti");
                    int delOption = int.Parse(Console.ReadLine());

                    if (delOption == 1)
                    {
                        Console.WriteLine("Kunde CPR");
                        string delCustomerCPR = Console.ReadLine();

                        Customer customer = Customers.DeleteCustomer(delCustomerCPR);

                        Console.WriteLine($"Konti {customer.name} er blevet slettet");
                    } else if (delOption == 2)
                    {
                        Console.WriteLine("Konti id");
                        string delAccountId = Console.ReadLine();

                        Account delAccount = Accounts.DeleteAccount(delAccountId);

                        Console.WriteLine($"Konti {delAccount.name} er blevet slettet");
                    } else
                    {
                        Console.WriteLine("EHHH forkert");
                    }
                    break;
                case 6:
                    Console.WriteLine("Konti id");
                    string accountId = Console.ReadLine();

                    Console.WriteLine("Antal penge");
                    int money = int.Parse(Console.ReadLine());

                    Account account = Accounts.InsertMoney(accountId, money);

                    Console.WriteLine($"Ny saldo {account.balance}");
                    break;
                default: 
                    Console.WriteLine("forkert svar");
                    break;
            }
        }
    }
}