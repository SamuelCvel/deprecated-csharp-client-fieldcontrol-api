## csharp-fieldcontrol
C# client provider for Field Control API (https://app.fieldcontrol.com.br/)

### Criando o client

```c#
var client = new Client(new Configuration.Configuration {
    BaseUrl = "http://api.fieldcontrol.com.br/"
});
```

### Autenticação

```c#
client.Authenticate("email@exemplo.com", "password");
```

### Atividades

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

### Otimização de Rotas

```c#
var routeOptimization = new RouteOptimization() {
    Date = new DateTime(2016, 3, 23)
};
var optimizationResult = client.Execute(new RouteOptimizationRequest(routeOptimization));
```
