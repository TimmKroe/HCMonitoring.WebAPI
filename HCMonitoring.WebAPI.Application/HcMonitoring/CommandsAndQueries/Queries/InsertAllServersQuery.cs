using System;
using System.Collections.Generic;
using System.Text;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Domain.Domain.Aggregates;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.Queries
{
    public class InsertAllServersQuery
    {
        public List<ServerDto> servers { get; }

        public InsertAllServersQuery(List<ServerDto> servers)
        {
            this.servers = servers;
        }
    }
}
