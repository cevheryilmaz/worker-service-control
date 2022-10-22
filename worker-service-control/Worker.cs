using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace worker_service_control
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private string serviceName = "ServiceName"; //you should change service name parameter
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public async Task InitialServiceStart()
        {
            try
            {
                ServiceController service = new ServiceController(serviceName, Environment.MachineName);
                if (service.Status.ToString() == "Stopped")
                {
                    service.Start();
                }
            }
            catch (Exception ex)
            {

                StackTrace stackTrace = new StackTrace(ex, fNeedFileInfo: true);
                StackFrame frame = stackTrace.GetFrame(0);
                int fileLineNumber = frame.GetFileLineNumber();
                _logger.LogError($"Error at InitialiazeNotification. Exception:{ex.Message}'\n'{stackTrace}'\n'{fileLineNumber}'\n' {fileLineNumber}");
            }

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await InitialServiceStart();
                    await Task.Delay(5000, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error while Initialize Notifications Ex:" + ex.Message);
                }
            }
        }
    }
}
