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
using MvcAppTesteP3Image.Models;

namespace MvcAppTesteP3Image.Controllers
{
    public class CategoriasController : ApiController
    {
        private IP3ImageDbContainer db;

        public CategoriasController()
        {
            P3ImageEFDbContainer container = new P3ImageEFDbContainer();
            db = container;
        }

        public CategoriasController(String connectionString)
        {
            P3ImageEFDbContainer container = new P3ImageEFDbContainer(connectionString);
            db = container;
        }

        public CategoriasController(IP3ImageDbContainer container)
        {
            db = container;
        }

        // GET: api/Categorias
        public IEnumerable<Categoria> GetCategorias()
        {
            return db.GetCategorias();
        }

        // GET: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult GetCategoria(int id)
        {
            Categoria categoria = db.GetCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: api/Categorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.Id)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateCategoria(categoria);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categorias
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateCategoria(categoria);

            return CreatedAtRoute("DefaultApi", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult DeleteCategoria(int id)
        {
            Categoria categoria = db.GetCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }

            db.DeleteCategoria(categoria);

            return Ok(categoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaExists(int id)
        {
            return db.GetCategoria(id) != null;
        }
    }
}