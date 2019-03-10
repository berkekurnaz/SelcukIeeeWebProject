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
    [Route("api/AEtkinlikFotograf")]
    public class AEtkinlikFotografController : Controller
    {

        /* Butun Fotograflarin Listesi      : www.selcukieee.com/api/AEtkinlikFotograf   */
        /* Berlirli Bir Fotografin Getirmek : www.selcukieee.com/api/AEtkinlikFotograf/2 */

        EtkinlikFotografOperations etkinlikFotografOperations = new EtkinlikFotografOperations();

        [HttpGet]
        public IEnumerable<EtkinlikFotografs> Get()
        {
            var query = etkinlikFotografOperations.GetAll();
            return query;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = etkinlikFotografOperations.GetById(id);
            if (query == null)
            {
                return NotFound();
            }
            return new ObjectResult(query);
        }

    }
}