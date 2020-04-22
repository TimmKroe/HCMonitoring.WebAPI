using System;
using System.Collections.Generic;
using System.Text;

namespace HCMonitoring.WebAPI.Domain.Domain.Aggregates
{
    class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsPublic { get; set; }
    }
}
