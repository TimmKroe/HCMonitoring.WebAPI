using System;
using System.Collections.Generic;
using System.Text;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Domain.Domain.Aggregates
{
    class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsPublic { get; set; }

        // API Keys
        public List<ApiKey> ApiKeys { get; set; }
    }
}
