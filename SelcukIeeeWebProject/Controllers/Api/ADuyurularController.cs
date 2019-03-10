using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelcukIeeeWebProject.DataAccessLayer;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/ADuyurular")]
    public class ADuyurularController : Controller
    {

        /* Butun Duyuruların Listesi    : www.selcukieee.com/api/ADuyurular   */
        /* Berlirli Bir Duyuru Getirmek : www.selcukieee.com/api/ADuyurular/2 */

        DuyurularOperations duyurularOperations = new DuyurularOperations();

        [HttpGet]
        public IEnumerable<Duyurulars> Get()
        {
            var query = duyurularOperations.GetAll().OrderByDescending(x => x.Id);
            return query;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = duyurularOperations.GetById(id);
            if (query == null)
            {
                return NotFound();
            }
            return new ObjectResult(query);
        }

    }
}