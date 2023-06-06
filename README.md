# MillionAndUp

## requisitos previos

- .NET 6 SDK (o más reciente).
- Un editor de código .NET.
- Sql Server (Para la rama main).
- Docker (Opcional para la rama task/Docker).

## Clonar repositorio:
```sh
git clone https://github.com/duvansuo/MillionAndUp.git
```

## Pasos de ejecución con Docker desde la rama (task/Docker)
```sh
cd .\MillionAndUp
git checkout remotes/origin/task/Docker
docker-compose up
```
- URL de la api: http://localhost:8080/

## Pasos de ejecución local
```sh
 - Abrir la solución en visual studio.
 - Ir al proyecto MillionAndUp.API
 - Ir a la sección de appsettings.json
 - dentro del archivo .json el actualizar el valor de la llave "ConnectionStrings:Default", con tu string de conexión local (Server, user, password)
 - por último selecciona el launch sobre el cual desea correr el proyecto (ISS, MillionAndUp.API), ejecuta el proyecto.
```
- URL de la api: http://localhost:{Port}/swagger/index.html
