using CoreConsoleApp.Data;
using CoreConsoleApp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreConsoleApp.Services
{
    internal class OutputGenerator
    {
        private readonly ILogger<OutputGenerator> _logger;
        private readonly AppSettings _settings;
        private readonly SQLiteDbContext _db;
        private readonly IGenerator _generator;

        public OutputGenerator(
            ILogger<OutputGenerator> logger,
            SQLiteDbContext db,
            IGenerator generator,
            IOptions<AppSettings> settings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        public void RunJobs()
        {

            var pending = _db.Jobs.Where(x => x.Status == "pending").FirstOrDefault();

            if (pending != null)
            {
                _generator.Run(pending);
            }

            Console.WriteLine(_settings.BatchSize);
            Console.WriteLine(_settings.BasePath);
            Console.WriteLine("OK");
            _logger.LogInformation("Finished!");

        }
    }
}
