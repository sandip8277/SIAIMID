using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIDCodeGenerator.Repository
{
    public class MIDCodeGeneratorRepository: IMIDCodeGeneratorRepository
    {
        private IConfiguration Configuration;
        private string _connectionString;
        public void GenerareMIDCodes()
        {
            _connectionString = this.Configuration.GetConnectionString("ConnectionString");
        }
    }
}
