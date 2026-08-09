# Gentil Pedro - Template API SOLID (.NET 10)

Template `dotnet new` de uma Web API .NET 10 em camadas enxutas (`Controllers` / `Services` / `Repositories` / `Domain`), aplicando os 5 princípios SOLID sem a cerimônia tática de DDD. Estrutura espelha o padrão real usado nos projetos do autor (ex: EscolaSystemApi).

Inclui, já configurados e funcionando ponta a ponta com uma entidade de exemplo (`Product`, CRUD completo):

- AutoMapper
- FluentValidation + FluentValidation.AspNetCore
- Autenticação JWT (`Microsoft.AspNetCore.Authentication.JwtBearer`) + hashing de senha com BCrypt.Net-Next
- Entity Framework Core + Npgsql (PostgreSQL)
- Serilog (console + arquivo)
- Scalar (UI de OpenAPI, no lugar do Swagger UI)

## Como criar um projeto novo

**1. Configure o GitHub Packages como fonte NuGet** (uma vez só, nesta máquina — precisa de um token seu com escopo `read:packages`):

```
dotnet nuget add source https://nuget.pkg.github.com/gentilpedro/index.json -n github-gentilpedro -u gentilpedro -p <SEU_TOKEN> --store-password-in-clear-text
```

**2. Instale o template:**

```
dotnet new install GentilPedro.Templates.ApiSolid
```

**3. Crie o projeto:**

```
dotnet new api-solid -n MeuApp
```

Isso gera um projeto `MeuApp` com o namespace já ajustado, pronto para `dotnet build` / `dotnet run` (configure a connection string do Postgres e o segredo do JWT em `appsettings.json` ou `appsettings.Development.json` antes de rodar).

### Atualizar para a versão mais nova

Cada push na `main` deste repositório republica o pacote (versão `1.0.<run_number>`). Não precisa reinstalar manualmente:

```
dotnet new update
```
