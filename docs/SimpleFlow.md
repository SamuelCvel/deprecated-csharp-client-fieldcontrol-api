## Fluxo de integração com o Field Control

#### 1. Instalar os seguintes pacotes Nuget

```c#
Install-Package FieldControlApi
Install-Package Geocoding.net
```

#### 2. Exemplo de fluxo para criação de atividades (com clientes existentes / novos clientes)

```c#
using FieldControlApi;
using FieldControlApi.Configuration;
using FieldControlApi.Requests;
using FieldControlApi.Requests.Activities;
using FieldControlApi.Requests.Customers;
using FieldControlApi.Resources;
using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FieldControl.Integracao.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client(new Configuration {
                BaseUrl = "http://api.fieldcontrol.com.br/"
            });

            client.Authenticate("email@gmail.com", "secret-appKey");
            //autenticar o cliente com email e appkey fornecidos

            /*
                ##########################################
                ########### Criando atividades ###########
                ##########################################
            */

            //buscando o cliente por nome
            var customers = client.Execute(new GetCustomersRequest(nameLike: "Luiz Freneda"));
            var customer = customers.FirstOrDefault();

            //caso o cliente nao exista, é necessario criar um novo
            //caso exista, usaremos o cliente retornado na busca
            if (customer == null)
            {
                customer = new Customer()
                {
                    Name = "Luiz Freneda",
                    Email = "lfreneda@gmail.com",
                    Phone = "11963427199",
                    ZipCode = "05422010",
                    Street = "Rua dos Pinheiros",
                    Number = "383",
                    City = "São Paulo",
                    State = "São Paulo"
                };

                //usaremos o Geoconding.net para obter a latitude/longitude pelo endereco
                //necessario criar uma key para usar o geo coding ( https://console.developers.google.com/ )
                IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "" };
                IEnumerable<Address> addresses = geocoder.Geocode(
                    string.Format("{0}, {1} - {2}, {3} - {4}",
                    customer.Street,
                    customer.Number,
                    customer.City,
                    customer.State,
                    customer.ZipCode
                ));

                customer.Latitude  = Convert.ToDecimal(addresses.First().Coordinates.Latitude);
                customer.Longitude = Convert.ToDecimal(addresses.First().Coordinates.Longitude);

                customer = client.Execute(new CreateCustomerRequest(customer));
            }

            //atividade é criada com os dados do cliente (customer)
            var activity = new Activity(customer)
            {
                Identifier = Guid.NewGuid().ToString(), // Identificador OS no sistema de origem
                Status = ActivityStatus.Scheduled,
                ScheduledTo = new DateTime(2016, 3, 22),
                ServiceId = ConvertServiceToFieldControl(serviceId: 1234),
                Duration = 60, // Em minutos
                Description = "Descrição da atividade",
            };

            var createdActivity = client.Execute(new CreateActivityRequest(activity));
            //TODO: Salvar id da atividade

            /*
                #############################################################
                ########### Buscando atividades por identificador ###########
                #############################################################
            */

            var savedActivity = client.Execute(new GetActivityRequest(createdActivity.Id.ToString()));
        }

        private static int ConvertServiceToFieldControl(int serviceId) {

            var services = new Dictionary<int, int>()
            {
                { /* service id */ 1234, /* matching field control service id */ 1 },
                { /* service id */ 6542, /* matching field control service id */ 2 },
                { /* service id */ 2345, /* matching field control service id */ 3 },

                //TODO: Fazer conversoes do codigo de servicos do sistema de origem para o codigo de tipos de atividades do Field Control
            };

            return services[serviceId];
        }
    }
}
```
