using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIDCodeGenerator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIDCodeGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MIDCodeGeneratorController : ControllerBase
    {
        private readonly IMIDCodeGeneratorRepository _MIDCodeGeneratorRepository;

        //Here add controller action
    }
}
