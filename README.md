# MillionAndUp

## requisitos previos

- .NET 6 SDK (o más reciente).
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
