# CoreInventory — AGENTS.md

## Project state

Monorepo with:
- **API**: ASP.NET Core 9 Web API (controller-based). Built with `dotnet new webapi --use-controllers`. 
- **Frontend**: Blazor WebAssembly (net10.0) in `src/CoreInventory.Web/`.
- Git remote: `https://github.com/Emanuelvera/CoreInventory.git`.

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

### API (`CoreInventory.csproj` — port 5254)
- `Controllers/StatusController.cs` — `GET /Status/ping` → `"pong"`
- `Controllers/ProductsController.cs` — CRUD completo (GET / GET:id / POST / PUT / DELETE)
- `Models/Product.cs` — `Id`, `Name`, `Code`, `Stock`
- `Services/InMemoryProductService.cs` — CRUD completo con 3 productos mockeados
- `Program.cs` — registra `InMemoryProductService` como Singleton, CORS configurado para localhost:5246, Scalar OpenAPI
- `bruno/CoreInventory/` — colección Bruno con 6 requests (Ping, GetAll, GetById, Create, Update, Delete)

### Frontend (`src/CoreInventory.Web/` — port 5246)
- Blazor WASM standalone
- `Models/Product.cs` — modelo con validación (Required, Range)
- `Services/ApiService.cs` — HttpClient wrapper para consumir la API
- Pages:
  - `/products` — tabla con listado, botones Edit/Delete
  - `/products/create` — formulario de creación
  - `/products/edit/{id}` — formulario de edición precargado
  - `/products/delete/{id}` — confirmación de borrado
- `NavMenu.razor` — link a Products

## Solution structure

```
CoreInventory/
├── CoreInventory.slnx
├── CoreInventory.csproj          ← API (.NET 9)
├── Program.cs, Controllers/, Models/, Services/
├── bruno/                        ← colección de pruebas
└── src/
    └── CoreInventory.Web/        ← Blazor WASM (.NET 10)
        ├── Program.cs, Models/, Services/, Pages/
        └── Layout/, wwwroot/
```

## Conventions

- API namespaces: `CoreInventory.Controllers`, `CoreInventory.Models`, `CoreInventory.Services`
- Blazor namespaces: `CoreInventory.Web.Models`, `CoreInventory.Web.Services`
- Controllers: `[ApiController]`, `[Route("[controller]")]`, inherit `ControllerBase`

## Commands

```powershell
dotnet build                          # compile all
dotnet run                            # start API only (port 5254)
dotnet run --project src/CoreInventory.Web/CoreInventory.Web.csproj   # start Blazor (port 5246)
```
