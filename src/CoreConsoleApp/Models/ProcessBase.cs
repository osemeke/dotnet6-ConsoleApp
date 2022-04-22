using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleApp.Models
{
    internal class ProcessBase
    {
        public string? Name { get; set; }

        public string? OutputDirectory { get; set; }

        public List<string> Status { get; set; } = new List<string>();

        public void Run()
        {

        }
    }
}
