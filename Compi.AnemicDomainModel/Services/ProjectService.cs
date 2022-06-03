using Compi.AnemicDomainModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.AnemicDomainModel.Services
{
    public class ProjectService
    {
        public bool IsOnTime(Project project)
        {
            bool result = true;

            if(project.EndDate > DateTimeOffset.Now)
            {
                result = false;
            }

            return result;
        }
    }
}
