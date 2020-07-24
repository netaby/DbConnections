using DbConnections.DAL;
using DbConnections.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbConnections.Controllers
{
    [Route("api/[controller]")]
    public class NalaController : Controller
    {
        private readonly ToysCollection _toysCollection;
        private readonly WalksCollection _walksCollection;

        public NalaController(ToysCollection toysCollection, WalksCollection walksCollection) 
        {
            _toysCollection = toysCollection;
            _walksCollection = walksCollection;
        }

        [HttpGet]
        public ActionResult<List<Toy>> Get() =>
           _toysCollection.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Toy> Get(string id)
        {
            var toy = _toysCollection.GetByIg(id);

            if (toy == null)
            {
                return NotFound();
            }

            return toy;
        }

        [HttpPost]
        public ActionResult<Toy> Create(Toy toy)
        {
            _toysCollection.Create(toy);

            return CreatedAtRoute("GetToy", new { id = toy.Id.ToString() }, toy);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Toy toyIn)
        {
            var toy = _toysCollection.GetByIg(id);

            if (toy == null)
            {
                return NotFound();
            }

            _toysCollection.Update(id, toyIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var toy = _toysCollection.GetByIg(id);

            if (toy == null)
            {
                return NotFound();
            }

            _toysCollection.Remove(toy);

            return NoContent();
        }
    
    }
}
