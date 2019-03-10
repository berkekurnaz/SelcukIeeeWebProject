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
    [Route("api/AEtkinlikFotograflar")]
    public class AEtkinlikFotograflarController : Controller
    {

        /* Belirli Bir Etkinlige Ait Butun Fotograflarin Listelenmesi : www.selcukieee.com/api/AEtkinlikFotograflar/3   */

        EtkinlikFotografOperations etkinlikFotografOperations = new EtkinlikFotografOperations();

        [HttpGet("{id}")]
        public IEnumerable<EtkinlikFotografs> Get(int id)
        {
            var query = etkinlikFotografOperations.GetAllByEtkinlik(id);
            return query;
        }

    }
}