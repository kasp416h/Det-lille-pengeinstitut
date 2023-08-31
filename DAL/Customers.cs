using Newtonsoft.Json;
using System.Security.Principal;

namespace DAL
{
    public static class Customers
    {
        private static string customerFilePath = "C:\\Users\\HFGF\\source\\repos\\Frontend\\DAL\\Customers.json";
        public static void CreateCustomer(string customerCPR, string customerName)
        {
            string fileContent = File.ReadAllText(customerFilePath);

            List<Customer>? customers = JsonConvert.DeserializeObject<List<Customer>>(fileContent);

            Customer newCustomer = new Customer { CPR = customerCPR, name = customerName };

            customers.Add(newCustomer);

            string updatedFileContent = JsonConvert.SerializeObject(customers, Formatting.Indented);

            File.WriteAllText(customerFilePath, updatedFileContent);
        }
        public static void DeleteCustomer(string customerCPR)
        {
            string fileContent = File.ReadAllText(customerFilePath);

            List<Customer>? customers = JsonConvert.DeserializeObject<List<Customer>>(fileContent);

            Customer? customer = customers.FirstOrDefault(customer => customer.CPR == customerCPR);

            customers.Remove(customer);

            string updatedFileContent = JsonConvert.SerializeObject(customers, Formatting.Indented);

            File.WriteAllText(customerFilePath, updatedFileContent);

            Console.WriteLine($"Konti {customer.name} er blevet slettet");
        }
    }
}
