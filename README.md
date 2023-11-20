# ZabbixClient
C# Zabbix Api client to retrieve host data and and modify the configuration of Zabbix

## Overview

This is a fork of [HenriqueCaires/ZabbixApi](https://github.com/HenriqueCaires/ZabbixApi) with a fix to allow login after Zabbix changes the name of the username property.

Also updated the Newtonsoft.Json dependency to 12.0.3, updated Nuget license, readme and image links and a bump to dotnet 6.

We use the package internally and needed to fix this issue. We have not tested all the endpoints, but the login works and we can retrieve host data.

To allow publishing to NuGet I have renamed the package (and internal namespace) to ZabbixClient.

Todo
- [ ] Unit tests fail. This might be our test and prod server returning an empty array, enpoints Zabbix have removed or errors in this client.
- [ ] Warning 'WebClient.WebClient()' is obsolete: 'WebRequest, HttpWebRequest, ServicePoint, and WebClient are obsolete. Use HttpClient instead.'
- [ ] Test automation uses zabbix/zabbix-appliance docker image. This image has been discontinued. Use https://github.com/zabbix/zabbix-docker.git
---

This library allows you to make CRUD operations using Zabbix API.
You just need to instantiate the context and the service that you want and call the operation.Like that:

## Installing package

On the Package Manager Cosole type this to install:

```powershell
Install-Package ZabbixClient
```

## Using

Instantiate the context and the service that you want and call the operation:

```csharp
using(var context = new Context(url, user, password))
{
  var host = context.Hosts.GetByName("myHost");
}
```

You can make your own query too, like that:

```csharp
using(var context = new Context(url, user, password))
{
  var host = context.Hosts.Get(new {
      name = "myHost"
  });
}
```

Or that:

```csharp
using (var context = new Context(url, user, password))
{
    var host2 = context.Hosts.Get(new
    {
        hostid = "1"
    });
}
```

## Configuring via the `appsettings.json` file

Instead of specifying the configuration in the constructor the `appsettings.json` file can be used like that:

```json
{
  "ZabbixClient": {
    "url": "http://MyZabbixServer/zabbix/api_jsonrpc.php",
    "user": "Admin",
    "password": "zabbix"
  }
}

```

The empty constructor can then be used:

```csharp
using(var context = new Context())
{
  // ...
}
```
