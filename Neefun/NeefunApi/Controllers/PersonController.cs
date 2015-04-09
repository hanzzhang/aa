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
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
                await Mongo.GetPersonAsync(queryOptions);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<Person>>(people);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Person(5)
        public async Task<IHttpActionResult> GetPerson([FromODataUri] System.Guid key, ODataQueryOptions<Person> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
                await Mongo.GetPersonAsync(queryOptions);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Person>(person);
            return StatusCode(HttpStatusCode.NotImplemented);
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
            await Mongo.CreatePersonAsync(p);

            // return Created(person);
            return StatusCode(HttpStatusCode.NotImplemented);
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
            var p = new Person();
            await Mongo.CreatePersonAsync(p);

            // return Updated(person);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Person(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] System.Guid key)
        {
            // TODO: Add delete logic here.
            var p = new Person();
            await Mongo.CreatePersonAsync(p);

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
