using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Application.HcMonitoring.Ports;
using Dapper;
using HCMonitoring.WebAPI.Domain.Domain.Aggregates;
using Microsoft.Extensions.Configuration;

namespace HCMonitoring.WebAPI.Adapters.SQLServer.MonitoringSqlServer.Repositories
{
    public class ServerRepository : IServerRepository
    {
        public IConfiguration Configuration { get; }
        private string ConnectionString { get; }
        public ServerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }
        
        public async Task<List<ServerDto>> GetAllServersAsync()
        {
            var sql = "SELECT * FROM SERVERS";
            var result = new List<ServerDto>();

            await using (var connection = new SqlConnection(ConnectionString))
            {
                result = await connection.QueryFirstOrDefaultAsync<List<ServerDto>>(sql);
            }

            return result;
        }

        public async Task<ServerDto> GetServerAsync(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id,  DbType.Guid);

            var sql = "SELECT * FROM SERVERS WHERE Id = @Id";
            var result = new ServerDto();

            await using (var connection = new SqlConnection(ConnectionString))
            {
                result = await connection.QueryFirstOrDefaultAsync<ServerDto>(sql, parameters);
            }

            return result;
        }

        public async Task InsertServersAsync(List<ServerDto> servers)
        {
            // loop servers
            servers.ForEach(async server =>
            {
                var existingServer = await CheckForExistingServer(server);

                if (existingServer == null)
                    return;
            });
            // check if server exists
            // insert server

        }

        public async Task InsertServerAsync(ServerDto serverDto)
        {
            var existingServer = await CheckForExistingServer(serverDto);

            if (existingServer == null)
                return;

            // insert server
            var sql = "INSERT INTO ...";
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.QueryAsync(sql);
            }
        }

        public async Task UpdateServerAsync(ServerDto serverDto)
        {
            var existingServer = await CheckForExistingServer(serverDto);

            if (existingServer == null)
                return;

            // update
            existingServer.Update(serverDto);
            
            // write to Database
            var sql = "ALTER TABLE ...";
            using (var connection = new SqlConnection(sql))
            {
                await connection.QueryAsync(sql);
            }
        }

        public Task DeleteServerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServerDto> CheckForExistingServer(ServerDto dto)
        {
            var allServers = await this.GetAllServersAsync();
            
            var existingServer = allServers.Find(server => server.Equals(dto));
            // return
            return existingServer;
        }
    }
}
