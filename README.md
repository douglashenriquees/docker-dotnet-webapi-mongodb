## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new webapi -o solution_name.template_project --no-https true```
* ```dotnet sln solution_name.sln add ./solution_name.template_project/solution_name.template_project.csproj```
* ```dotnet new gitignore```

## Executando o Projto

* ```dotnet run --project solution_name.template_project```
* **Program.cs** ```app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); x.RoutePrefix = ""; });```
  * para redirecionar ao **swagger** ao acessar a url exposta pela api