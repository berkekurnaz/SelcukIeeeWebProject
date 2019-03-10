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
    [Route("api/AEtkinlikler")]
    public class AEtkinliklerController : Controller
    {

        /* Butun Etkinliklerin Listesi    : www.selcukieee.com/api/AEtkinlikler   */
        /* Berlirli Bir Etkinlik Getirmek : www.selcukieee.com/api/AEtkinlikler/2 */

        EtkinlikOperations etkinlikOperations = new EtkinlikOperations();

        [HttpGet]
        public IEnumerable<Etkinliks> Get()
        {
            var query = etkinlikOperations.GetAll().OrderByDescending(x => x.Id);
            return query;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = etkinlikOperations.GetById(id);
            if (query == null)
            {
                return NotFound();
            }
            return new ObjectResult(query);
        }

    }
}