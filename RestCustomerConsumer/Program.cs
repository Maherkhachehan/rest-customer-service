using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestCustomerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            DoStuff();

            Console.ReadLine();
        }

        public static async void DoStuff()
        {
            Console.WriteLine("Customer List");

            var customerList = GetCustomersAsync().Result;

            foreach (var i in customerList)
            {
                Console.WriteLine(i.FirstName);
            }

            Console.WriteLine("\nSpecific Customer");

            Console.WriteLine(GetCustomerAsync(customerList.First().Id).Result.FirstName);

            Console.WriteLine("\nDeleting Specific Customer");

            await DeleteCustomerAsync(customerList.First().Id);

            Console.WriteLine("\nCustomer List After Delete");

            var customerListAfterDeletion = GetCustomersAsync().Result;

            foreach (var i in customerListAfterDeletion)
            {
                Console.WriteLine(i.FirstName);
            }

            Console.WriteLine("\nPut Customer");

            var customer = GetCustomersAsync().Result.First();

            customer.FirstName = "Edited Firstname";

            await PutCustomerAsync(customer);

            Console.WriteLine("\nCustomer List After Put");

            var customerListAfterEdited = GetCustomersAsync().Result;

            foreach (var i in customerListAfterEdited)
            {
                Console.WriteLine(i.FirstName);
            }

            Console.WriteLine("\nCustomer List After Post");

            Customer newCustomer = new Customer("Some FirstName", "Some LastName", 1999);

            await PostCustomerAsync(newCustomer);

            var customerListAfterPosted = GetCustomersAsync().Result;

            foreach (var i in customerListAfterPosted)
            {
                Console.WriteLine(i.FirstName);
            }
        }

        public static async Task<IList<Customer>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var content = await client.GetStringAsync(@"https://localhost:44300/api/customer");
                var customerList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return customerList;
            }
        }

        public static async Task<Customer> GetCustomerAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = await client.GetStringAsync(@"https://localhost:44300/api/customer/" + id);
                var customerList = JsonConvert.DeserializeObject<Customer>(content);
                return customerList;
            }
        }

        public static async Task PostCustomerAsync(Customer customer)
        {
            using (HttpClient client = new HttpClient())
            {
                var body = JsonConvert.SerializeObject(customer);

                var content = new StringContent(body, Encoding.UTF8, "application/json");

                var result = await client.PostAsync(@"https://localhost:44300/api/customer", content);
            }
        }

        public static async Task PutCustomerAsync(Customer customer)
        {
            using (HttpClient client = new HttpClient())
            {
                var body = JsonConvert.SerializeObject(customer);

                var content = new StringContent(body, Encoding.UTF8, "application/json");

                var result = await client.PutAsync(@"https://localhost:44300/api/customer/" + customer.Id, content);
            }
        }

        public static async Task DeleteCustomerAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = await client.DeleteAsync(@"https://localhost:44300/api/customer/" + id);
            }
        }
    }
}
