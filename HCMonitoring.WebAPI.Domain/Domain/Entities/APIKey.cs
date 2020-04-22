using System;
using System.Collections.Generic;
using System.Text;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    class APIKey
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
    }
}
