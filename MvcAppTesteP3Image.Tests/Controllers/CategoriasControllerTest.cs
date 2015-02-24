using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcAppTesteP3Image.Controllers;
using MvcAppTesteP3Image.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace MvcAppTesteP3Image.Tests.Controllers
{
    [TestClass]
    public class CategoriasControllerTest
    {
        P3ImageStubContainer container = new P3ImageStubContainer();

        [TestInitialize]
        public void Initialize()
        {
            Categoria catPai = new Categoria();
            catPai.Id = 1;
            catPai.Descricao = "Computadores em geral";
            catPai.Slug = "computador";

            Categoria subcat1 = new Categoria();
            subcat1.Id = 2;
            subcat1.Descricao = "Desktop";
            subcat1.Slug = "desktop";
            subcat1.CategoriaPaiId = 1;
            subcat1.CategoriaPai = catPai;

            Categoria subcat2 = new Categoria();
            subcat2.Id = 3;
            subcat2.Descricao = "Laptop";
            subcat2.Slug = "laptop";
            subcat2.CategoriaPaiId = 1;
            subcat2.CategoriaPai = catPai;

            container.CreateCategoria(catPai);
            container.CreateCategoria(subcat1);
            container.CreateCategoria(subcat2);
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void Get()
        {
            CategoriasController controller = new CategoriasController(container);

            IEnumerable<Categoria> result = controller.GetCategorias();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(1, result.ElementAt(0).Id);
            Assert.AreEqual("computador", result.ElementAt(0).Slug);
            Assert.AreEqual(2, result.ElementAt(1).Id);
            Assert.AreEqual("desktop", result.ElementAt(1).Slug);
            Assert.AreEqual(3, result.ElementAt(2).Id);
            Assert.AreEqual("laptop", result.ElementAt(2).Slug);
        }

        [TestMethod]
        public void GetById()
        {
            CategoriasController controller = new CategoriasController(container);

            System.Web.Http.Results.OkNegotiatedContentResult<Categoria> result = (System.Web.Http.Results.OkNegotiatedContentResult<Categoria>)controller.GetCategoria(2);

            Assert.IsNotNull(result);
            Assert.AreEqual("desktop", result.Content.Slug);
        }

        [TestMethod]
        public void GetBySlug()
        {
            CategoriasController controller = new CategoriasController(container);

            System.Web.Http.Results.OkNegotiatedContentResult<Categoria> result = (System.Web.Http.Results.OkNegotiatedContentResult<Categoria>)controller.GetCategoria("computador", "laptop");

            Assert.IsNotNull(result);
            Assert.AreEqual("laptop", result.Content.Slug);
        }

        [TestMethod]
        public void Post()
        {
            CategoriasController controller = new CategoriasController(container);

            Categoria categoria = new Categoria();
            categoria.Id = 4;
            categoria.Descricao = "Mobile";
            categoria.Slug = "mobile";

            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Categoria> result = (System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Categoria>)controller.PostCategoria(categoria);

            Assert.IsNotNull(result);
            Assert.AreEqual("mobile", result.Content.Slug);
            Assert.IsNotNull(container.GetCategoria(4));
        }

        [TestMethod]
        public void Put()
        {
            CategoriasController controller = new CategoriasController(container);

            Categoria categoria = container.GetCategoria(2);
            categoria.Descricao = "Modified-Desktop";
            categoria.Slug = "modified-desktop";

            System.Web.Http.Results.StatusCodeResult result = (System.Web.Http.Results.StatusCodeResult)controller.PutCategoria(2, categoria);

            Assert.IsNotNull(result);
            Assert.AreEqual("Modified-Desktop", container.GetCategoria(2).Descricao);
            Assert.AreEqual("modified-desktop", container.GetCategoria(2).Slug);
        }

        [TestMethod]
        public void Delete()
        {
            CategoriasController controller = new CategoriasController(container);

            System.Web.Http.Results.OkNegotiatedContentResult<Categoria> result = (System.Web.Http.Results.OkNegotiatedContentResult<Categoria>)controller.DeleteCategoria(3);

            Assert.IsNull(container.GetCategoria(3));
        }
    }
}
