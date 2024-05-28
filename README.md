# ProductAPI

Uma API para realizar o CRUD de Produtos, desenvolvida em .NET 8. Esta API permite criar, atualizar, deletar, listar e visualizar produtos específicos, além de ordenar e buscar produtos pelo nome.

## Funcionalidades

- **Criar um Produto**: O valor do produto não pode ser negativo.
- **Atualizar um Produto**
- **Deletar um Produto**
- **Listar Produtos**
- **Visualizar um Produto Específico**
- **Ordenar Produtos por Diferentes Campos**: Nome, Estoque, Valor.
- **Buscar Produto pelo Nome**

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server (LocalDB)
- GitHub Actions para CI/CD
- Testes Unitários e de Integração

## Estrutura do Projeto

O projeto está dividido nos seguintes diretórios:

- **src/ProductAPI**: Contém a API principal.
- **tests/ProductAPI.UnitTests**: Contém os testes unitários.
- **tests/ProductAPI.IntegrationTests**: Contém os testes de integração.

## Configuração Inicial

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB recomendado para desenvolvimento)
- [Git](https://git-scm.com/)

### Passos para Configuração

1. Clone o repositório:

    ```bash
    git clone https://github.com/seu-usuario/ProductAPI.git
    cd ProductAPI
    ```

2. Configure a string de conexão no `appsettings.json` em `src/ProductAPI`:

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProductAPIDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }
    ```

3. Certifique-se de que o Entity Framework Core está instalado:

    ```bash
    dotnet tool install --global dotnet-ef
    dotnet add src/ProductAPI package Microsoft.EntityFrameworkCore
    dotnet add src/ProductAPI package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add src/ProductAPI package Microsoft.EntityFrameworkCore.Design
    ```

4. Crie e aplique as migrações:

    ```bash
    dotnet ef migrations add InitialCreate --project src/ProductAPI --startup-project src/ProductAPI
    dotnet ef database update --project src/ProductAPI --startup-project src/ProductAPI
    ```

5. Execute a aplicação:

    ```bash
    dotnet run --project src/ProductAPI
    ```

    A API estará disponível em `https://localhost:5001/api/product`.

## Endpoints da API

### Produtos

- **GET** `/api/products`: Lista todos os produtos.
- **GET** `/api/products?name={name}`: Busca produtos pelo nome.
- **GET** `/api/products?sortBy={field}`: Ordena produtos por um campo específico (nome, estoque, valor).
- **GET** `/api/products/{id}`: Visualiza um produto específico.
- **POST** `/api/products`: Cria um novo produto.
- **PUT** `/api/products/{id}`: Atualiza um produto existente.
- **DELETE** `/api/products/{id}`: Deleta um produto.

## Estrutura da Entidade Produto

A entidade de produto contém os seguintes campos:

- `Id`: Identificador único do produto.
- `Name`: Nome do produto.
- `Stock`: Quantidade em estoque.
- `Price`: Valor do produto.

## Testes

### Testes Unitários

Os testes unitários estão localizados em `tests/ProductAPI.UnitTests`.

Para executar os testes unitários:

```bash
dotnet test tests/ProductAPI.UnitTests
```


### Testes de Integração

Os testes de integração estão localizados em `tests/ProductAPI.IntegrationTests`.

Para executar os testes unitários:

```bash
dotnet test tests/ProductAPI.IntegrationTests
```


## Padrões de Projeto Utilizados
- Repository Pattern: Para abstrair a lógica de acesso a dados.
- Service Layer: Para encapsular a lógica de negócios.


## GitHub Actions
Este projeto utiliza GitHub Actions para CI/CD. O arquivo de configuração está localizado em `.github/workflows/build.yml.`


## Configuração do GitHub Actions

```yaml
name: .NET

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v2
    - name: Set up .NET
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 8.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore
    - name: Run tests
      run: dotnet test --no-build --verbosity normal
```

