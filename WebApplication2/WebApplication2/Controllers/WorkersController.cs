using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2;

namespace WebApplication2.Controllers
{
    /// <summary>
    /// API CRUD controller for Worker
    /// </summary>
    /// 
    [RoutePrefix("api/workers")]
    public class WorkersController : ApiController
    {
        private readonly Factory db = new Factory();

        // GET: api/Workers
        /// <summary>
        /// Get info about all workers
        /// </summary>
        /// <returns>All workers info</returns>
        ///
        [HttpGet]
        [Route("ReadAllWorkersInfo")]
        public IQueryable<Worker> GetWorkers()
        {
            return db.Workers;
        }


        // GET: api/Workers/5
        /// <summary>
        /// Get worker by known id
        /// </summary>
        /// <param name="id">Worker id to find</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [ResponseType(typeof(Worker))]
        [Route("ReadWorkerById/{id}")]
        public IHttpActionResult GetWorker(int id)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        // PUT: api/Workers/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("UpdateWorker/{id}")]
        public IHttpActionResult PutWorker([FromUri]int id, [FromBody]Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worker.Id)
            {
                return BadRequest();
            }

            db.Entry(worker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Workers
        [HttpPost]
        [ResponseType(typeof(Worker))]
        [Route("CreateWorker")]
        public IHttpActionResult PostWorker(Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workers.Add(worker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = worker.Id }, worker);
        }

        // DELETE: api/Workers/5
        /// <summary>
        /// Delete worker by known id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Worker))]
        [HttpDelete]
        [Route("DeleteWorkerById/{id}")]
        public IHttpActionResult DeleteWorker(int id)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            db.Workers.Remove(worker);
            db.SaveChanges();

            return Ok(worker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkerExists(int id)
        {
            return db.Workers.Count(e => e.Id == id) > 0;
        }
    }
}