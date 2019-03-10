using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelcukIeeeWebProject.DataAccessLayer;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/AIletisim")]
    public class AIletisimController : Controller
    {

        IletisimOperations iletisimOperations = new IletisimOperations();

        [HttpPost]
        public int Post(Iletisims iletisim)
        {
            iletisimOperations.Add(iletisim);
            return 0;
        }
        
    }
}