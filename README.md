# Aplicación de Estado de Cuenta de Tarjeta de Crédito

Este repositorio contiene la solución completa para una aplicación de estado de cuenta de tarjeta de crédito desarrollada como parte de una prueba técnica. La solución está dividida en dos proyectos principales: una API y una aplicación web MVC. La API maneja la lógica de negocio y las interacciones con la base de datos, mientras que el proyecto MVC proporciona una interfaz fácil de usar.

## Estructura del Proyecto

- **Backend** (`Backend/`)
  - **Proyecto API** (`src/`)
    - Contiene el proyecto ASP.NET Web API que implementa la lógica de negocio, interactúa con la base de datos y expone endpoints para el frontend. El proyecto está construido usando **.NET 6** y sigue principios de **REST API**.
    - Utiliza **CQRS** (Segregación de Responsabilidades de Comando y Consulta) para manejar operaciones complejas de manera eficiente.
    - Implementa **AutoMapper** para el mapeo de objetos y **FluentValidation** para la validación de entradas.
    - Incluye **Swagger** para la documentación y prueba de la API.
    - Emplea **GlobalExceptions** para un manejo consistente y centralizado de excepciones a lo largo de la API.
    - Incorpora **Healthcheck** para monitorear el estado de la API y asegurarse de que funcione correctamente.

  - **Scripts de Base de Datos** (`db_scripts/`)
    - Scripts SQL Server para configurar el esquema de la base de datos, procedimientos almacenados y datos de ejemplo.

  - **Colecciones de Postman** (`postman_collections/`)
    - Colecciones de Postman para probar los endpoints de la API.

- **Frontend** (`Frontend/`)
  - **Proyecto MVC** (`src/`)
    - Contiene el proyecto ASP.NET MVC con vistas Razor, que maneja la interfaz de usuario y consume la API.
    - Construido utilizando **.NET 6**, el proyecto aprovecha **Razor** para la generación dinámica de vistas y **jQuery** para la programación del lado del cliente.
    - Sigue el patrón de diseño **MVC** para asegurar la separación de responsabilidades y la mantenibilidad.
    - Consume la API RESTful desarrollada en el proyecto Backend.

## Características Clave

- **API**:
  - API RESTful construida con ASP.NET Web API, utilizando **.NET 6**.
  - **Clean Architecture**: Implementación basada en los principios de Arquitectura Limpia, asegurando una separación clara de responsabilidades y facilitando la mantenibilidad.
  - Implementa patrones de **CQRS**, **AutoMapper**, **FluentValidation** y **UnitOfWork** para un código robusto y mantenible.
  - **Manejo global de excepciones** usando `GlobalExceptionMiddleware` y `ExceptionManager` para respuestas de error consistentes.
  - **Health checks** para monitorear el estado de la API.
  - Documentación con **Swagger** para facilitar la exploración y prueba de los endpoints de la API.
  - **Procesos Almacenados**: Interacción con SQL Server utilizando procedimientos almacenados (PL/SQL) para mejorar la eficiencia y seguridad en la ejecución de consultas.

- **Frontend MVC**:
  - Interfaz fácil de usar con ASP.NET MVC, **vistas Razor** y **jQuery**.
  - Formularios para agregar compras y pagos.
  - Visualización de estados de cuenta de tarjeta de crédito, incluyendo transacciones detalladas y cálculos.
  - Funcionalidad de exportación para generar informes PDF del estado de cuenta.

- **Base de Datos**:
  - Base de datos SQL Server con procedimientos almacenados para manejar transacciones y cálculos.
  - Manejo seguro de datos y consultas eficientes.

## Configuración e Instalación

1. **Clonar el Repositorio**:

## Configuración e Instalación

### Configurar la Base de Datos:

- Ejecuta los scripts SQL en `Backend/db_scripts` utilizando tu herramienta preferida de gestión de SQL Server, recomendadamente ejecutar en localdb de Visual Studio.

### Configurar los Proyectos:

- **Backend**: Actualiza la cadena de conexión en `appsettings.json` para que apunte a tu instancia de SQL Server.
- **Frontend**: Actualiza la URL base de la API en `appsettings.Development.json` para que coincida con la URL local de tu API o puedes apuntar a la api publicada en Azure. Para ello solo comenta y descomenta la de tu preferencia.
   ```bash
    "UriApi": "http://localhost:5151/api/v1/"
    //"UriApi": "https://prueba-api-tarjeta-credito-b9btb8dybxamazhv.eastus-01.azurewebsites.net/api/v1/"

### Ejecutar los Proyectos:

1. Abre la solución en Visual Studio.
2. Inicia el proyecto de la API.
3. Inicia el proyecto MVC.

### Probar la API:

- Importa las colecciones de Postman desde `Backend/postman_collections` para probar la API.
- Alternativamente, puedes usar **Swagger** para probar los endpoints de la API directamente desde tu navegador.

## Documentación

### Arquitectura:

- El proyecto API sigue los principios de **Arquitectura Limpia**, asegurando la separación de responsabilidades y la mantenibilidad.
- El proyecto MVC sigue el patrón tradicional de **ASP.NET MVC** con **vistas Razor**.

### Endpoints:

- Información detallada sobre los endpoints de la API está disponible en la **documentación de Swagger**.

### Pruebas:

- Utiliza las colecciones de Postman proporcionadas o **Swagger** para probar los endpoints de la API.
