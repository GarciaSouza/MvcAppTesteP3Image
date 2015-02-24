namespace MvcAppTesteP3Image.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampoRequires : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Campos", new[] { "CategoriaId" });
            AlterColumn("dbo.Campos", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Campos", "Tipo", c => c.String(nullable: false));
            AlterColumn("dbo.Campos", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Campos", "CategoriaId");
            AddForeignKey("dbo.Campos", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Campos", new[] { "CategoriaId" });
            AlterColumn("dbo.Campos", "CategoriaId", c => c.Int());
            AlterColumn("dbo.Campos", "Tipo", c => c.String());
            AlterColumn("dbo.Campos", "Descricao", c => c.String());
            CreateIndex("dbo.Campos", "CategoriaId");
            AddForeignKey("dbo.Campos", "CategoriaId", "dbo.Categorias", "Id");
        }
    }
}
