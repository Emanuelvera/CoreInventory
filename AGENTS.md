# CoreInventory — AGENTS.md

## Project state

ASP.NET Core 9 Web API (controller-based). Built with `dotnet new webapi --use-controllers`. Git remote: `https://github.com/Emanuelvera/CoreInventory.git`.

## Branches

| Branch | Purpose |
|---|---|
| `main` | stable |
| `development` | integration |
| `qa` | pre-release QA |
| `feature/*` | feature work |

## Remote feature branches (merged)

| Branch | What it added |
|---|---|
| `feature/product` | `Models/Product.cs` (Id, Name, Code, Stock) |
| `feature/createStatus` | `Controllers/StatusController.cs` + Web API scaffold |
| `feature/inyeccion-servicio` | `Services/InMemoryProductService.cs` |

## Current code (development)

- `Controllers/StatusController.cs` — `GET /Status/ping` → `"pong"`
- `Models/Product.cs` — `Id`, `Name`, `Code`, `Stock`
- `Services/InMemoryProductService.cs` — `GetAll()` returns 3 hardcoded products (Mouse, Teclado, Monitor)

## Next steps (pending)

- Register `InMemoryProductService` as Singleton in `Program.cs`
- Create `Controllers/ProductsController.cs` with `GET /Products`

## Conventions

- Namespaces: `CoreInventory.Controllers`, `CoreInventory.Models`, `CoreInventory.Services`
- Controllers: `[ApiController]`, `[Route("[controller]")]`, inherit `ControllerBase`

## Commands

```powershell
dotnet build          # compile
dotnet run            # start dev server
dotnet watch run      # hot reload
```
