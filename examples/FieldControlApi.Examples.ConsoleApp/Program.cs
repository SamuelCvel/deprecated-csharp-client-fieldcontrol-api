using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldControlApi;
using FieldControlApi.Configuration;
using FieldControlApi.Resources;
using FieldControlApi.Requests;
using FieldControlApi.Requests.Activities;
using FieldControlApi.Requests.Customers;
using Newtonsoft.Json;

namespace FieldControlApi.Examples.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = CreateAuthenticatedClient();

            CreateNewCustomer(client);
            GetCustomerById(client);
            SearchCustomersByName(client);

            CreateNewActivity(client);
            GetActivityById(client);

            OptimizeRoutes(client);

            Console.Read();
        }

        private static void CreateNewActivity(Client client)
        {
            PrintSeparator();
            PrintHeader("Creating a new activity: ");

            var activity = new Activity()
            {
                Identifier = Guid.NewGuid().ToString(),
                ScheduledTo = new DateTime(2016, 3, 22),
                CustomerId = 1,
                ServiceId = 1,
                EmployeeId = null,
                Archived = false,
                Duration = 60,
                Status = "0",
                ZipCode = "15015000",
                Street = "Avenida Doutor Alberto Andaló",
                Number = "4075",
                City = "São José do Rio Preto",
                State = "São Paulo",
                Description = "Activity from csharp client",
                TimeFixed = false,
                FixedStartTime = null,
                Latitude = -20.798035m,
                Longitude = -49.359166m
            };

            var savedActivity = client.Execute(new CreateActivityRequest(activity));
            PrintObject(savedActivity);
        }

        private static void GetActivityById(Client client)
        {
            PrintSeparator();
            PrintHeader("Getting a activity by id: ");

            var activity = client.Execute(new GetActivityRequest("1"));
            PrintObject(activity);
        }

        private static void CreateNewCustomer(Client client)
        {
            PrintSeparator();
            PrintHeader("Creating a new customer: ");

            var customer = new Customer()
            {
                Name = "Luiz Freneda",
                Email = "lfreneda@gmail.com",
                Phone = "11963427199",
                ZipCode = "05422010",
                Street = "Rua dos Pinheiros",
                Number = "383",
                City = "São Paulo",
                State = "São Paulo",
                Latitude = -23.566413m,
                Longitude = -46.679770m
            };

            var savedCustomer = client.Execute(new CreateCustomerRequest(customer));
            PrintObject(savedCustomer);
        }

        private static void GetCustomerById(Client client)
        {
            PrintSeparator();
            PrintHeader("Getting a customer by id: ");

            var customer = client.Execute(new GetCustomerRequest("1"));
            PrintObject(customer);
        }

        private static void SearchCustomersByName(Client client)
        {
            PrintSeparator();
            PrintHeader("Searching customers by name: ");

            var customers = client.Execute(new GetCustomersRequest("Shopping"));
            PrintObject(customers);
        }

        public static Client CreateAuthenticatedClient()
        {
            PrintSeparator();
            PrintHeader("Creating authenticated client: ");

            var client = new Client(new Configuration.Configuration
            {
                BaseUrl = "http://api.fieldcontrol.com.br/"
            });

            client.Authenticate("email@example.com", "password-secret");

            PrintObject(new { Token = client.AuthenticationToken });
            return client;
        }

        private static void OptimizeRoutes(Client client)
        {
            PrintSeparator();
            PrintHeader("Optimizing activities for given date: ");

            var routeOptimization = new RouteOptimization() {
                Date = new DateTime(2016, 3, 23)
            };
            var optimizationResult = client.Execute(new RouteOptimizationRequest(routeOptimization));

            PrintObject(optimizationResult);
        }

        private static void PrintObject(object obj)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void PrintHeader(string sectionName)
        {
            Console.WriteLine(sectionName);
        }

        private static void PrintSeparator()
        {
            Console.WriteLine("################################################");
        }
    }
}
