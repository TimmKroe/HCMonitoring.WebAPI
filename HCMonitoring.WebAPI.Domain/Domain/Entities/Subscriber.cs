using System;
using System.Collections.Generic;
using System.Text;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    public class Subscriber
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int TimesSent { get; set; }
    }
}
