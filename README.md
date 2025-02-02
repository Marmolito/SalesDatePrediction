
# Sales Date Prediction - Reto Recnico

Este repositorio contiene tres proyectos distintos:

-API en .NET

-Frontend en Angular 19

-Aplicación en JavaScript Vanilla


## API en .NET

### Descripción
Este proyecto es una API RESTfull desarrollada con .NET utilizando los principios SOLID, arquitectura limpia y pruebas unitarias con XUnit. El objetivo es proporcionar una API escalable, fácil de mantener y probada.

### Instalación y ejecución

1. Asegúrate de tener .NET 8 o superior instalado.
2. Asegúrate de tener la base de datos proporcionada para el reto instalada y actualiza el string de conexión a la base de datos en el archivo `appsettings.json`. El string de conexión predeterminado puede no ser el adecuado para tu entorno, por lo que es necesario adaptarlo a tu configuración.
3. Clona este repositorio:

```bash
  git clone https://github.com/Marmolito/SalesDatePrediction.git
```
4. Desde la raíz del repositorio, navega a la carpeta de la API:

```bash
  cd SalesDatePredictionAPI
```

5. Restaura las dependencias:

```bash
  dotnet restore
```

6. Ejecuta el proyecto:

```bash
  dotnet run
```

La API estará corriendo en http://localhost:5880 (puede variar dependiendo de la configuración).

### OpenAPI

Al ejecutar el comando dotnet run, se abrirá automáticamente la interfaz de OpenAPI en http://localhost:5880/swagger. Esta interfaz proporciona un acceso rápido a la documentación de los endpoints y permite realizar pruebas manuales directamente desde el navegador.

### Pruebas Unitarias

7. Para ejecutar las pruebas unitarias con XUnit, utiliza el siguiente comando:

```bash
  dotnet test
```

## Frontend en Angular 19

### Descripción

Este proyecto es un frontend desarrollado con Angular 19, utilizando Angular Material y siguiendo buenas prácticas para la segmentación de directorios y archivos. Es un frontend para interactuar con la API creada en el primer proyecto.\

### Instalación y ejecución

1. Asegúrate de tener Node.js y Angular CLI instalados.
2. Clona este repositorio:
3. Desde la raíz del repositorio, navega a la carpeta del frontend

```bash
  cd SalesDatePredictionAPP
```

4. Instala las dependencias:

```bash
  npm install
```

5. Ejecuta el servidor de desarrollo:

```bash
  ng serve
```

El frontend estará disponible en http://localhost:4200.

## Aplicación en JavaScript Vanilla con D3

### Descripción

Este proyecto es una aplicación sencilla en JavaScript Vanilla que utiliza la librería D3 para generar un gráfico de barras interactivo a partir de datos ingresados por el usuario.

### Instalación y ejecución

1. Desde la raíz del repositorio, navega a la carpeta del proyecto:

```bash
  cd GraphingWithD3
```

2. Abre el archivo index.html en tu navegador preferido.

El gráfico de barras se generará en el navegador una vez que ingreses los datos solicitados.

## Recursos

### Colección de Postman

Se ha incluido una colección de Postman que contiene todos los endpoints disponibles en la API. Puedes importar esta colección en Postman para realizar pruebas fácilmente, además de usar la interfaz de Swagger.

### Script SQL

Se ha incluido un script SQL que contiene las consultas necesarias para crear y poblar la base de datos en SQL Server. Esto permitirá configurar la base de datos antes de ejecutar la API.

Para acceder tanto a la colección de Postman como al script SQL, navega a la carpeta Resources ubicada en la raíz del repositorio.