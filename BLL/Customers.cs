namespace BLL
{
    public static class Customers
    {
        public static void CreateCustomer()
        {
            Console.WriteLine("Kunde CPR");
            string customerCPR = Console.ReadLine();

            Console.WriteLine("Kunde navn");
            string customerName = Console.ReadLine();

            DAL.Customers.CreateCustomer(customerCPR, customerName);

            Console.WriteLine($"Ny konti oprettede for {customerName}");
        }
        public static void DeleteCustomer(string customerCPR)
        {
            DAL.Customers.DeleteCustomer(customerCPR);
        }
    }
}