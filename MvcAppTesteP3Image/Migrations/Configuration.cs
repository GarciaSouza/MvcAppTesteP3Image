namespace MvcAppTesteP3Image.Migrations
{
    using MvcAppTesteP3Image.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcAppTesteP3Image.Models.P3ImageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcAppTesteP3Image.Models.P3ImageContext context)
        {
            Categoria catPai = new Categoria() { Descricao = "Carros em geral", Slug = "auto" };

            context.Categorias.Add(catPai);
            context.SaveChanges();

            Categoria subCat1 = new Categoria() { Descricao = "Sedan", Slug = "sedan", CategoriaPai = catPai };

            context.Categorias.Add(subCat1);
            context.SaveChanges();

            Campo campo1 = new Campo() { Descricao = "Marca/Fab.", Ordem = 1, Tipo = "select", Categoria = subCat1, Lista = new string[] { "Fiat", "VW", "Ford", "BMW" } };
            Campo campo2 = new Campo() { Descricao = "Modelo", Ordem = 2, Tipo = "text", Categoria = subCat1 };
            Campo campo3 = new Campo() { Descricao = "Ano Fab.", Ordem = 3, Tipo = "text", Categoria = subCat1 };
            Campo campo4 = new Campo() { Descricao = "Ano Mod.", Ordem = 4, Tipo = "text", Categoria = subCat1 };
            Campo campo5 = new Campo() { Descricao = "KM", Ordem = 5, Tipo = "text", Categoria = subCat1 };

            context.Campos.Add(campo1);
            context.Campos.Add(campo2);
            context.Campos.Add(campo3);
            context.Campos.Add(campo4);
            context.Campos.Add(campo5);

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
