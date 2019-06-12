using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Classes;

namespace WebApi.Controllers
{
    public class ExpertSystemController : ApiController
    {
        [HttpGet]
        [ActionName("GetActualSystems")]
        public List<string> GetActualSystems()
        {
            return EsFilesHelper.GetActualSystems();
        }

        [HttpPost]
        [ActionName("GoConsult")]
        public ConsultResultDto GoConsult([FromBody]StartEsArgs args)
        {
            return new EsConsultStarter().LoadAndStartConsult(args);
        }

        [HttpGet]
        [ActionName("GetQueriedVariables")]
        public List<VariableDto> GetQueriedVariables(string esName)
        {
            return new EsConsultStarter().GetQueriedVariables(esName);
        }

    }
}
