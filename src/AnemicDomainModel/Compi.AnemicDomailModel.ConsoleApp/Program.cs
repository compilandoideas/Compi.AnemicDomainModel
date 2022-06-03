// See https://aka.ms/new-console-template for more information
using Compi.AnemicDomailModel.ConsoleApp.Domain;
using Compi.AnemicDomailModel.ConsoleApp.Services;




var projectService = new ProjectService();

var project = new Project();

project.Id = 1;
project.Name = "Proyecto mejoras BioSign";
project.StartDate = new DateTimeOffset(2022, 5, 1, 0, 0, 0, TimeSpan.Zero);
//Acá se abre la posibilidad a un error por ejemplo: project.StartDate usar la variable equivocada al usar el intellisense
project.EndDate = project.StartDate.AddMonths(1);  


Console.WriteLine($"Proyecto: {project.Name} está {projectService.IsOnTime(project)}");

//Otro error podría suceder al cambiar la variable por error después de usarla anteriormente.
project.EndDate = DateTimeOffset.Now.AddDays(30);

Console.WriteLine($"Proyecto: {project.Name} está {projectService.IsOnTime(project)}");

