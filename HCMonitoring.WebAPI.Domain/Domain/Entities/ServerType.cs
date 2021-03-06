﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    public class ServerType
    {
        public Guid Id { get; set; }
        public int HetznerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cores { get; set; }
        public double Memory { get; set; }
        public int Disk { get; set; }

    }
}
