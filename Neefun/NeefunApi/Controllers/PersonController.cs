using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using NeefunApi.Models;
using Microsoft.Data.OData;
using NeefunApi;

namespace NeefunApi.Controllers
{
    public class PersonController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Person
        public async Task<IHttpActionResult> GetPerson(ODataQueryOptions<Person> queryOptions)
        {
            IEnumerable<Person> people = null;
            try
            {
                queryOptions.Validate(_validationSettings);
                people = await Mongo.GetPersonAsync(queryOptions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<IEnumerable<Person>>(people);
        }

        // GET: odata/Person(5)
        public async Task<IHttpActionResult> GetPerson([FromODataUri] System.Guid key, ODataQueryOptions<Person> queryOptions)
        {
            Person person = null;
            try
            {
                queryOptions.Validate(_validationSettings);
                var col = await Mongo.GetPersonAsync(queryOptions);
                person = col.FirstOrDefault<Person>(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<Person>(person);
        }

        // PUT: odata/Person(5)
        public async Task<IHttpActionResult> Put([FromODataUri] System.Guid key, Delta<Person> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var p = new Person();
            await Mongo.CreatePersonAsync(p);

            // TODO: Get the entity here.

            // delta.Put(person);

            // TODO: Save the patched entity.

            // return Updated(person);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Person
        public async Task<IHttpActionResult> Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.
            var p = new Person();
            p.Name = "peng";
            p.CreatedDate = DateTimeOffset.Now;
            p.Id = Guid.NewGuid();
            await Mongo.CreatePersonAsync(p);

            return Created(person);
        }

        // PATCH: odata/Person(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] System.Guid key, Delta<Person> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(person);

            // TODO: Save the patched entity.
            var person = new Person();
            await Mongo.CreatePersonAsync(person);

            return Updated(person);
        }

        // DELETE: odata/Person(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] System.Guid key)
        {
            var p = new Person();
            await Mongo.CreatePersonAsync(p);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
