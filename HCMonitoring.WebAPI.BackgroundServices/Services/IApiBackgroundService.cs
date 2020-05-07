using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Services
{
    interface IApiBackgroundService
    {
        void RunApiBackgroundService();
        Task RunApiBackgroundServiceAsync();
    }
}
