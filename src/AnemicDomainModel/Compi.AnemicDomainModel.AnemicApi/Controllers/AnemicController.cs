using Compi.AnemicDomainModel.AnemicConsoleApp.Domain;
using Compi.AnemicDomainModel.AnemicConsoleApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Compi.AnemicDomainModel.AnemicApi.Controllers
{
    public class AnemicController : Controller
    {


        private readonly ProjectService _projectService;
        private readonly ILogger<AnemicController> _logger;

        public AnemicController(ProjectService projectService, ILogger<AnemicController> logger)
        {

            _projectService = projectService ??
                throw new ArgumentNullException(nameof(projectService));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }


        [HttpPost]
        //Riesgo de seguridad si exponemos un objeto del dominino hacia el mundo exterior
        //podrían enviar una propiedad que no corresponde (por ejemplo estado del proyecto  en este caso)
        public async Task<ActionResult> AddProject(Project project)
        {
            project.Name = "Proyecto mejoras BioSign";
            project.StartDate = new DateTimeOffset(2022, 5, 1, 0, 0, 0, TimeSpan.Zero);

            //Acá se abre la posibilidad a un error por ejemplo: project.StartDate usar la variable
           //equivocada al usar el intellisense
            project.EndDate = project.StartDate.AddMonths(1);
            project.CreatedDate = DateTimeOffset.UtcNow;
            project.Status = Status.Pending;

            _projectService.Save(project);

          


            return await Task.FromResult(Ok(project));

        }

        [HttpGet]
        public async Task<ActionResult<string>> ProjectIsOnTime(Project project)
        {

            string result = "";


            result = $"Proyecto: {project.Name} está {_projectService.IsOnTime(project)}\n";

            //Error podría suceder al cambiar la variable por error después de usarla anteriormente.
            project.EndDate = DateTimeOffset.UtcNow.AddDays(30);




            return await Task.FromResult(Ok(result));
        }
    }
}
