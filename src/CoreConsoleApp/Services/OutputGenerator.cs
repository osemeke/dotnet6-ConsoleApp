using CoreConsoleApp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleApp.Services
{
    internal class OutputGenerator
    {
        private readonly ILogger<OutputGenerator> _logger;
        private readonly AppSettings _settings;

        public OutputGenerator(ILogger<OutputGenerator> logger, IOptions<AppSettings> settings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        public void RunJobs() 
        {
            Console.WriteLine(_settings.BatchSize);
            Console.WriteLine(_settings.BasePath);
            Console.WriteLine("OK");
            _logger.LogInformation("Finished!");

        }
    }
}
