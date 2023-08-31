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
            
            switch (option)
            {
                case 1:
                    Customers.CreateCustomer();
                    break;
                case 2:
                    Accounts.CreateAccount();
                    break;
                case 3:
                    Accounts.GetAccounts();
                    break;
                case 4:
                    Accounts.FullBalance();
                    break;
                case 5:
                    Console.WriteLine("Hvad vil du slette? 1 for kunde, 2 for konti");
                    int delOption = int.Parse(Console.ReadLine());

                    if (delOption == 1)
                    {
                        Console.WriteLine("Kunde CPR");
                        string customerCPR = Console.ReadLine();

                        Customers.DeleteCustomer(customerCPR);
                    } else if (delOption == 2)
                    {
                        Console.WriteLine("Konti id");
                        string delAccountId = Console.ReadLine();

                        Accounts.DeleteAccount(delAccountId);
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

                    Accounts.InsertMoney(accountId, money);
                    break;
                default: 
                    Console.WriteLine("forkert svar idiot");
                    break;
            }
        }
    }
}