using System;
using System.Collections.Generic;
using System.Text;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    public class Protection
    {
        public Guid Id { get; set; }
        public bool Delete { get; set; }
        public bool Rebuild { get; set; }
    }
}
