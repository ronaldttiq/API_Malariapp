# API MalariaApp

## Descripción

API REST desarrollada en .NET 10 para la gestión de información de la aplicación MalariaApp. La solución implementa una arquitectura por capas que permite la separación de responsabilidades entre la lógica de negocio, acceso a datos y exposición de servicios.

## Tecnologías Utilizadas

* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger/OpenAPI
* JWT Authentication

## Requisitos Previos

* .NET SDK 10.0 o superior
* SQL Server
* Visual Studio 2022 o Visual Studio Code
* Git

## Configuración

### 1. Clonar el repositorio

```bash
git clone <url-repositorio>
```

### 2. Configurar la cadena de conexión

Actualizar el archivo:

```text
appsettings.json
```

Ejemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SERVIDOR;Database=MalariaApp;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 3. Restaurar dependencias

```bash
dotnet restore
```

### 4. Ejecutar migraciones (si aplica)

```bash
dotnet ef database update
```

### 5. Ejecutar la aplicación

```bash
dotnet run
```

## Documentación API

Una vez iniciada la aplicación, la documentación estará disponible en:

```text
https://localhost:xxxx/swagger
```

## Autenticación

La API utiliza autenticación basada en JWT. Los endpoints protegidos requieren el envío del token en el encabezado:

```text
Authorization: Bearer {token}
```

## Estructura del Proyecto

* Controllers: Exposición de endpoints.
* Services: Reglas de negocio.
* Repositories: Acceso a datos.
* Entities/Models: Modelos de dominio.
* Data: Contexto de base de datos.

## Consideraciones

* La solución fue desarrollada como parte de una prueba técnica.
* Se recomienda utilizar variables de entorno para la gestión de credenciales en ambientes productivos.
* El proyecto puede ser ampliado mediante nuevas funcionalidades manteniendo la estructura actual.

## Autor

Ronald Tique
