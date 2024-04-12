# users-crud-test

## Herramientas
* Frontend: Angular 16.0.6
* Backend: API RESTFUL en NET CORE 8
* Base: SQL SERVER 2022

## Base
* La creación de las tablas y registros se encuentran ubicados en la carpeta `data`

## Ejecutar el backend 
* Ubicarse en la ruta principal del projecto y dirigirse a  `backend`
* Abrir mediante VisualStudio el proyecto ejecutable
* Configurar la conexión a la Base de Datos local en el archivo raíz `appsettings.json`, en el parámetro `backendContext`
* Compilar y depurar el proyecto ejecutable

> Una vez ejecutado el backend, el puerto que se levante el servicio web, deberá ser agregado en el `app-config.json` del proyecto frontend.

## Ejecutar el frontend
* Ubicarse en la ruta principal del projecto y dirigirse a  `cd frontend`
* Instalar las librerías correspondientes `npm install`
* Agregar en el documento `assets/app-config.json`. La ip corresponde a la ruta del backend local para consumir los endpoints.
```
{
  "production": false,
  "ip": "http://localhost:port/"
}
```
* Ejecutar en la carpeta del proyecto `npm start`, esta se levantará en el puerto por defecto 4200. 
* Ubicarse en la ruta `http://localhost:4200/`


### Estructura del Front
* Se creó un Módulo llamado `Users`, el cual contiene su página principal y el componente `user` donde está el componente reutilizable para crear y editar usuario.

## Visualizacion del proyecto
* Las imágenes de la ejecución se ubican de la carpeta raíz, en el directorio `assets`