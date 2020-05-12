using System.Threading.Tasks;

namespace HCMonitoring.WebAPI.BackgroundServices.Services
{
    public interface IApiBackgroundService
    {
        Task RunApiBackgroundServiceAsync();
    }
}
