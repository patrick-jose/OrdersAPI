# OrdersAPI

.NET Web API to offer informations about customers' orders

## System Architecture

```mermaid
graph LR
A[OrderAPI .NET 7] --> C(Postgres Database)
B((RabbitMQ)) -- " 📨" --> D[OrderService .NET 7]
D --> C
```

### Database model diagram
<img width="1053" alt="Captura de Tela 2023-02-28 às 20 00 39" src="https://user-images.githubusercontent.com/21955255/222002087-af02d36a-845d-4364-994e-0e4f3acfa1e0.png">

### Docker Hub Postgres Repository
https://hub.docker.com/repository/docker/patrickamaral/orders_postgres/general

### Database populate script
https://github.com/patrick-jose/OrderService/blob/master/DataBaseBackup.sql
