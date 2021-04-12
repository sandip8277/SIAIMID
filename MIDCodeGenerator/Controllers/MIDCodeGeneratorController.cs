using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIDCodeGenerator.Helper;
using MIDCodeGenerator.Models;
using MIDCodeGenerator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MIDCodeGenerator.Controllers
{
    [Route("api/MIDCodeGenerator")]
    [ApiController]
    public class MIDCodeGeneratorController : ControllerBase
    {
        private readonly IMIDCodeGeneratorRepository _MIDCodeGeneratorRepository;

        public MIDCodeGeneratorController(IMIDCodeGeneratorRepository MIDCodeGeneratorRepository)
        {
            this._MIDCodeGeneratorRepository = MIDCodeGeneratorRepository;
        }
        //Here add controller action
        [HttpPost]
        [Route("GenerateCodes")]
        public async Task<IActionResult> GenerateCodes([FromBody] MIDCodeCreatorRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string xmlString = XmlHelper.ConvertObjectToXML(model);
                    XElement xElement = XElement.Parse(xmlString);
                    MIDCodeDetails details = await _MIDCodeGeneratorRepository.GenerareMIDCodes(xElement.ToString());
                    if (details != null)
                    {
                        return Ok(details);
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
    }
}
