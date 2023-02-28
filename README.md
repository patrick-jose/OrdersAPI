# OrdersAPI

.NET Web API to offer informations about customers' orders

## System Architecture

```mermaid
graph LR
A[OrderAPI .NET 7] --> C(Postgres Database)
B((RabbitMQ)) -- " 📨" --> D[OrderService]
D --> C
```

### Database model diagram
![Database Model](https://user-images.githubusercontent.com/21955255/221970585-fa950fc6-44ad-4ade-a0b7-5623fb5df484.png)

### Docker Hub Postgres Repository
https://hub.docker.com/repository/docker/patrickamaral/orders_postgres/general

### Database populate script
https://github.com/patrick-jose/OrderService/blob/master/DataBaseBackup.sql
