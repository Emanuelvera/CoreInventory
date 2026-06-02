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

## Current code

- `Controllers/StatusController.cs` — `GET /Status/ping` → `"pong"`
- `feature/product` adds `Models/Product.cs` (`Id`, `Name`, `Code`, `Stock`)

## Conventions

- Namespaces: `CoreInventory.Controllers`, `CoreInventory.Models`
- Controllers: `[ApiController]`, `[Route("[controller]")]`, inherit `ControllerBase`

## Commands

```powershell
dotnet build          # compile
dotnet run            # start dev server
dotnet watch run      # hot reload
```
