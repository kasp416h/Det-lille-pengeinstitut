using DAL;

namespace BLL
{
    public class Customers
    {
        private JsonHandler _JsonHandler;
        public Customers()
        {
            _JsonHandler = new JsonHandler("C:\\Users\\HFGF\\source\\repos\\Frontend\\DAL\\Customers.json");
        }
        public void CreateCustomer(string customerCPR, string customerName)
        {
            List<Customer> customers = _JsonHandler.Read<Customer>();

            Customer newCustomer = new Customer { CPR = customerCPR, name = customerName };

            customers.Add(newCustomer);

            _JsonHandler.Write(customers);
        }
        public Customer DeleteCustomer(string customerCPR)
        {
            List<Customer> customers = _JsonHandler.Read<Customer>();

            Customer? customer = customers.FirstOrDefault(customer => customer.CPR == customerCPR);

            customers.Remove(customer);

            _JsonHandler.Write(customers);

            return customer;
        }
    }
}