# MiranteToDo
Teste técnico para a empresa Mirante Tecnologia
# MiranteToDo

API RESTful para gestão de tarefas (To‑Do) em ASP.NET Core 8 + EF Core.

## Requisitos

- .NET SDK 8.0+
- (Opc.) Docker 24+

## Rodando localmente

```bash
[git clone https://github.com/seu-usuario/TodoApi.git](https://github.com/MateusChagas/MiranteToDo.git)
cd Mirante
dotnet restore
dotnet ef database update   # cria o banco SqlServer 'MiranteDb.db'
dotnet run                  # rota base: https://localhost:5001
