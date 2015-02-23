namespace MvcAppTesteP3Image.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Slug = c.String(nullable: false),
                        CategoriaPaiId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaPaiId)
                .Index(t => t.CategoriaPaiId);
            
            CreateTable(
                "dbo.Campos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Tipo = c.String(),
                        CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categorias", "CategoriaPaiId", "dbo.Categorias");
            DropForeignKey("dbo.Campos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Campos", new[] { "CategoriaId" });
            DropIndex("dbo.Categorias", new[] { "CategoriaPaiId" });
            DropTable("dbo.Campos");
            DropTable("dbo.Categorias");
        }
    }
}
