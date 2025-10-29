# Controle de Estoque (Clean Architecture + DDD) - Projeto exemplo

## Estrutura
- `src/Domain` - Entidades do domínio (Product, Category)
- `src/Application` - ViewModels, interfaces e serviços de aplicação
- `src/Infrastructure` - DbContext (EF Core), repositórios
- `src/WebUI` - ASP.NET Core MVC (controllers + views)

## Requisitos
- .NET 8 SDK (ou ajuste TargetFramework)
- SQL Server (LocalDB is default in appsettings.json). Update connection string in `src/WebUI/appsettings.json`.

## Como rodar (resumido)
1. Abra um terminal na pasta `src/WebUI`.
2. Restaure: `dotnet restore`
3. Crie a database via migrations:
   - (Se não tiver o tools) `dotnet tool install --global dotnet-ef`
   - Do root da solução: `dotnet ef migrations add Initial --project src/Infrastructure --startup-project src/WebUI --output-dir Migrations`
   - Atualize o banco: `dotnet ef database update --project src/Infrastructure --startup-project src/WebUI`
4. Rode a aplicação: `dotnet run --project src/WebUI`
5. Acesse `https://localhost:5001` ou a porta exibida.

> Observação: este projeto é intencionalmente simples para fins acadêmicos. Siga as boas práticas e estenda conforme necessário.

## Entrega
Suba o repositório no GitHub e insira o link no campo da APS conforme regras da disciplina.