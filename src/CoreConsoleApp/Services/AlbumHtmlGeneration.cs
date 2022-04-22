using CoreConsoleApp.Data;
using CoreConsoleApp.Entities;
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
    internal class AlbumHtmlGeneration : IGenerator
    {
        private readonly ILogger<AlbumHtmlGeneration> _logger;
        private readonly AppSettings _settings;
        private readonly SQLiteDbContext _db;
        private readonly WaecDbContext _waec;

        public AlbumHtmlGeneration(
            ILogger<AlbumHtmlGeneration> logger,
            SQLiteDbContext db,
            WaecDbContext waec,
            IOptions<AppSettings> settings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _waec = waec ?? throw new ArgumentNullException(nameof(waec));
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        public void Run(Job pending)
        {

            var count = _waec.Candidates.Count();
            Console.WriteLine("Candidate Count is " + count.ToString());

        }

    }
}
