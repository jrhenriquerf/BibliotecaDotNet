# dotNET_2020

Repositório da disciplina .NET Avançado - MBA Engenharia de Software - FIB Bauru

## Estrutura de Entidades
![](/imagens/Estrutura.PNG)


## Alguns comandos
### Criar um projeto de api
```
dotnet new webapi
```
#### Templates:
- webapi
- classlib
### Rodar projeto
```
dotnet run -watch
```
### Referenciar dois projetos para utilizar classes separadas:
```
dotnet add reference ..\ProjBiblio.Domain\
```
### Criar migrations
```
dotnet ef migrations add CreateColumnNotaProduto -c BibliotecaDbContext -s ../ProjBiblio.WebApi/
```
### Atualizar o banco a partir das migrations
```
dotnet ef database update -c BibliotecaDbContext -s ../ProjBiblio.WebApi/
```
### Rodar o projeto
```
dotnet run -p .\ProjBiblio.WebApi
```
### Versionamento e documentação Swagger
```
dotnet add package Swashbuckle.AspNetCore
```

