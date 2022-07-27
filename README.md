## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new webapi -o solution_name.template_project --no-https true```
* ```dotnet sln solution_name.sln add ./solution_name.template_project/solution_name.template_project.csproj```
* ```dotnet new gitignore```

## Executando o Projeto

* ```dotnet run --project solution_name.template_project```
* ```app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); x.RoutePrefix = ""; });```
  * modificação na classe **Program.cs** para redirecionar ao **swagger** acessando a url exposta na api

<hr>

* para executar o projeto em modo **debug** via container:
  * opção executar e depurar
  * docker debug in container
  * adicionar os arquivos sugeridos pelo vs studio code: **Dockerfile** e **docker-compose.yml**
  * executar e depudar, opção **docker .net core launch**