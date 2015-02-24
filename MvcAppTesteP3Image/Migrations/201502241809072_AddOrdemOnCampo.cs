namespace MvcAppTesteP3Image.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdemOnCampo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campos", "Ordem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campos", "Ordem");
        }
    }
}
