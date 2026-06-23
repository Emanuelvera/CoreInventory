# CoreInventory

Sistema de gestión de inventario con API REST + Frontend Blazor WebAssembly.

## Requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) o superior
- [Bruno](https://www.usebruno.com/downloads) (opcional, para probar endpoints)

## Estructura del proyecto

```
CoreInventory/
├── CoreInventory.slnx              ← Solución
├── CoreInventory.csproj            ← API (.NET 9)
├── Program.cs                      ← Configuración de la API
├── Controllers/
│   ├── StatusController.cs         ← GET /Status/ping → "pong"
│   └── ProductsController.cs       ← CRUD /Products
├── Models/
│   └── Product.cs                  ← Entidad Product
├── Services/
│   └── InMemoryProductService.cs   ← CRUD en memoria
├── bruno/CoreInventory/            ← Colección Bruno
└── src/
    └── CoreInventory.Web/          ← Blazor WASM (.NET 10)
        ├── Program.cs
        ├── Models/Product.cs
        ├── Services/ApiService.cs
        ├── Pages/
        │   ├── Products.razor          ← GET /products
        │   ├── ProductCreate.razor     ← POST /products/create
        │   ├── ProductEdit.razor       ← PUT /products/edit/{id}
        │   └── ProductDelete.razor     ← DELETE /products/delete/{id}
        └── Layout/NavMenu.razor
```

## Cómo iniciar

### 1. Iniciar la API

```powershell
dotnet run
```

La API arranca en `http://localhost:5254`.

| Endpoint | Método | Descripción |
|---|---|---|
| `/Status/ping` | GET | Health check → `"pong"` |
| `/Products` | GET | Lista todos los productos |
| `/Products/{id}` | GET | Obtiene un producto por ID |
| `/Products` | POST | Crea un nuevo producto |
| `/Products/{id}` | PUT | Actualiza un producto |
| `/Products/{id}` | DELETE | Elimina un producto |

Documentación interactiva en `http://localhost:5254/scalar/v1`.

### 2. Iniciar el Frontend (Blazor)

En otra terminal:

```powershell
dotnet run --project src/CoreInventory.Web/CoreInventory.Web.csproj
```

El frontend arranca en `http://localhost:5147`.

Abrí `http://localhost:5147/products` en el navegador.

### 3. Probar con Bruno (opcional)

1. Abrí Bruno
2. File → Open Collection → seleccioná `bruno/CoreInventory/`
3. Ejecutá cada request contra `http://localhost:5254`
