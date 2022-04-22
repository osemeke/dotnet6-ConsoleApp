using CoreConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleApp.Services
{
    internal interface IGenerator
    {
        public void Run(Job pending);
    }
}
