using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.AnemicDomainModel.AnemicConsoleApp.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        List<Person> Persons = new();

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        Pending = 0,
        InProgress = 1,
        Complete = 2,
        Delayed = 3

    }
}
