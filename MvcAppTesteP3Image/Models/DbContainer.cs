using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcAppTesteP3Image.Models
{
    public interface IP3ImageDbContainer
    {
        IEnumerable<Categoria> GetCategorias();

        Categoria GetCategoria(int id);

        void CreateCategoria(Categoria categoria);

        void UpdateCategoria(Categoria categoria);

        void DeleteCategoria(Categoria categoria);

        IEnumerable<Campo> GetCampos();

        Campo GetCampo(int id);

        void CreateCampo(Campo campo);

        void UpdateCampo(Campo campo);

        void DeleteCampo(Campo campo);

        void Dispose();
    }

    public class P3ImageEFDbContainer : IP3ImageDbContainer
    {
        private P3ImageContext db;

        public P3ImageEFDbContainer()
        {
            db = new P3ImageContext();
        }

        public P3ImageEFDbContainer(String connectionString)
        {
            db = new P3ImageContext(connectionString);
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return db.Categorias.Include("Campos");
        }

        public Categoria GetCategoria(int id)
        {
            return db.Categorias.Where(cat => cat.Id == id).FirstOrDefault();
        }

        public void CreateCategoria(Categoria categoria)
        {
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        public void UpdateCategoria(Categoria categoria)
        {
            db.Entry(categoria).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCategoria(Categoria categoria)
        {
            db.Categorias.Remove(categoria);
            db.SaveChanges();
        }

        public IEnumerable<Campo> GetCampos()
        {
            return db.Campos;
        }

        public Campo GetCampo(int id)
        {
            return db.Campos.Where(c => c.Id == id).FirstOrDefault();
        }

        public void CreateCampo(Campo campo)
        {
            db.Campos.Add(campo);
            db.SaveChanges();
        }

        public void UpdateCampo(Campo campo)
        {
            db.Entry(campo).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCampo(Campo campo)
        {
            db.Campos.Remove(campo);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

    public class P3ImageStubContainer : IP3ImageDbContainer
    {
        private List<Categoria> Categorias { get; set; }

        public P3ImageStubContainer()
        {
            Categorias = new List<Categoria>();
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return Categorias;
        }

        public Categoria GetCategoria(int id)
        {
            return Categorias.Where(cat => cat.Id == id).FirstOrDefault();
        }

        public void CreateCategoria(Categoria categoria)
        {
            Categorias.Add(categoria);
        }

        public void UpdateCategoria(Categoria categoria)
        {
        }

        public void DeleteCategoria(Categoria categoria)
        {
            Categorias.Remove(categoria);
        }

        public IEnumerable<Campo> GetCampos()
        {
            throw new NotImplementedException();
        }

        public Campo GetCampo(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateCampo(Campo campo)
        {
            throw new NotImplementedException();
        }

        public void UpdateCampo(Campo campo)
        {
            throw new NotImplementedException();
        }

        public void DeleteCampo(Campo campo)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }

}