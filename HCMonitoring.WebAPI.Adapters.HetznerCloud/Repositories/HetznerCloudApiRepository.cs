using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Application.HcMonitoring.Ports;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HCMonitoring.WebAPI.Adapters.HetznerCloud.Repositories
{
    public class HetznerCloudApiRepository : IHcapi
    {
        private readonly HttpClient Client = new HttpClient();
        private readonly string ApiKey;

        public HetznerCloudApiRepository(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Get all Servers associated to the given API Key
        /// </summary>
        /// <returns></returns>
        public async Task<List<ServerDto>> GetAllServers()
        {
            WebRequest request = WebRequest.Create("https://api.hetzner.cloud/v1/servers");
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + ApiKey);
            request.ContentType = "application/json";

            WebResponse response = await request.GetResponseAsync();
            Stream responseStream = response.GetResponseStream();
            if (responseStream == null)
            {
                return null;
            }

            StreamReader responseStreamReader = new StreamReader(responseStream, Encoding.Default);
            string jsonResponse = await responseStreamReader.ReadToEndAsync();


            var servers = JsonSerializer.Deserialize<ServerObjectDto>(jsonResponse);

            // after read operation need to be closed
            response.Close();

            return servers.Servers;
        }

        /// <summary>
        /// Get all Snapshots to the associated API Key
        /// </summary>
        /// <returns></returns>
        public async Task<List<ImageDto>> GetAllSnapshots()
        {
            Stream rawJsonStream = await Client.GetStreamAsync("https://api.hetzner.cloud/v1/images?type=snapshot");

            List<ImageDto> snapshots = await JsonSerializer.DeserializeAsync<List<ImageDto>>(rawJsonStream);

            return snapshots;
        }

        /// <summary>
        /// Get all Backups to the associated API Key
        /// </summary>
        /// <returns></returns>
        public async Task<List<ImageDto>> GetAllBackups()
        {
            Stream rawJsonStream = await Client.GetStreamAsync("https://api.hetzner.cloud/v1/images?type=backup");

            List<ImageDto> backups = await JsonSerializer.DeserializeAsync<List<ImageDto>>(rawJsonStream);

            return backups;
        }

        /// <summary>
        /// Get a specific Server by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServerDto> GetServerById(int id)
        {
            Stream rawJsonStream = await Client.GetStreamAsync("https://api.hetzner.cloud/v1/servers/" + id);

            ServerDto server = await JsonSerializer.DeserializeAsync<ServerDto>(rawJsonStream);

            return server;
        }
    }
}