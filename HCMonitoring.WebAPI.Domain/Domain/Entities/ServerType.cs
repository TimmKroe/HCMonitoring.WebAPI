using System;
using System.Collections.Generic;
using System.Text;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    class ServerType
    {
        public Guid Id { get; set; }
        public int HetznerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cores { get; set; }
        public int Memory { get; set; }
        public int Disk { get; set; }

    }
}
