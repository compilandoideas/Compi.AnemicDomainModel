using Compi.AnemicDomailModel.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.AnemicDomailModel.ConsoleApp.Services
{
    public class ProjectService
    {
        public string IsOnTime(Project project)
        {
            string result = "en tiempo";

            if (project.EndDate > DateTimeOffset.Now)
            {
                result = "atrasado";
            }

            return result;
        }
    }
}
