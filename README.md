## csharp-client-fieldcontrol-api
Cliente para a API REST do [FieldControl](https://www.fieldcontrol.com.br)

### Criando o client

```c#
var client = new Client(new Configuration.Configuration {
    BaseUrl = "http://api.fieldcontrol.com.br/"
});
```

### Autenticação

Antes de invocar os métodos é necessário que o client esteja autenticado, para isso basta invocar o método ```Authenticate```

```c#
client.Authenticate("email@exemplo.com", "password");
```

É necessário fornecer um e-mail e um appKey, solicite pelo e-mail: _integracoes@fieldcontrol.com.br_

### Usando o client

Para cada ação disponível existe uma classe de ```Request```, por exemplo:

* ```CreateCustomerRequest```
* ```GetCustomerRequest```
* ```GetCustomersRequest```
* ```CreateActivityRequest```
* ```GetActivityRequest```

É necessário fornecer um ```Request``` com a ação desejada no método Execute do Client

```c#
var activity = new Activity()
{
    Identifier = "20160322144157703",
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

var createdActivity = client.Execute(new CreateActivityRequest(activity));
```

### Exemplo de fluxo disponível [aqui](https://github.com/FieldControl/csharp-client-fieldcontrol-api/blob/master/docs/SimpleFlow.md)

