# O que é o projeto MagomesBank?
O objetivo do projeto é criar uma simulação de um sistema de controle de conta corrente bancária, processando solicitações de depósito, resgate e pagamento. O sistema também deve rentabilizar o dinheiro parado em conta de um dia para o outro.

## Como obter e executar uma cópia local

### Pré-requisitos 
Certifique-se que tenha instalado em sua máquina:
* [Docker](https://docs.docker.com/)
* [Git](https://git-scm.com/downloads)

### Clonando o projeto
``` bash
 $ git clone https://github.com/magomes-dev/magomesBank.git
```
### Docker Compose
No terminal, navegue até a raiz do projeto.
``` bash
 $ docker-compose up
```

### Observações
* O banco de dados é inicializado junto com a API, não é necessario executar as migrations manualmente.
* As tabelas são populadas na inicialização do banco de dados, permitindo testar todas as funcioanalidades do sistema logo após a execução. 

## Uso do sistema

### Acesso
http://localhost:4200

**Usuários para teste da aplicação**
* username: magomes </br>
  password: 123456 </br>
  (com saldo e movitações) </br>
  
* username: wabrasil </br>
  password: 1233456 </br>
  (sem saldo)

### Backend
* A autenticação com o backend é baseada em um token de segurança JWT.
* As rotas disponiveis podem ser consultadas e testadas em: https://localhost:5000/swagger/index.html. O suporte a JWT está habilitado no Swagger.
* No ASP.NET Core, backgrounds tasks podem ser implementadas como serviços hospedados (IHostedService). Utilizo esta estratégia para agendar um job a ser executado todos os dias às 00:01, este job é responsavel pela rentabilização diaria das contas correntes.

## Testes
No terminal, navegue até a raiz do projeto.
``` bash 
 $ dotnet test .\MagomesBank.Test\
```

## Arquitetura
* Arquitetura completa com separação de responsabilidades
* DDD – Domain Driven Design (Camadas e Domain Model Pattern)

## Tecnologias Utilizadas
* Angular 9
* .Net Core 3.1
* ASP.NET WebApi Core with JWT Bearer Authentication
* Entity Framework Core 3.1
* .NET Core Native DI
* AutoMapper
* Swagger UI com suporte a JWT
* XUnit
* SQL Server
* Docker/ Docker Compose

### Autor
**Matheus Gomes** - [LinkedIn](https://www.linkedin.com/in/matheusandradegomes/)


