using Compi.AnemicDomainModel.AnemicConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.AnemicDomainModel.AnemicConsoleApp.Services
{
    public class ProjectService
    {
        public string IsOnTime(Project project)
        {
            //Duplicidad de validaciones (invariant)
            if (project.StartDate > project.EndDate)
                throw new Exception("La Fecha de inicio no puede ser mayor a la de fin");

            Console.WriteLine(project.StartDate);
            Console.WriteLine(project.EndDate);

            string result = "en tiempo";

            if (project.Status != Status.Complete && project.EndDate < DateTimeOffset.UtcNow)
            {
                result = "retrasado!!!";
            }



            return result;
        }



        public Project Save(Project project)
        {
            //Duplicidad de validaciones (invariant)
            if (project.StartDate > project.EndDate)
                throw new Exception("La Fecha de inicio no puede ser mayor a la de fin");

            //TODO: llamar al repositorio
            project.Id = new Random().Next();

            return project;
        }


        public Project Complete(Project project)
        {
            //Duplicidad de validaciones (invariant)
            if (project.StartDate > project.EndDate)
                throw new Exception("La Fecha de inicio no puede ser mayor a la de fin");

            //TODO: llamar al repositorio
            project.Status = Status.Complete;

            return project;
        }




    }
}
