namespace MvcAppTesteP3Image.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListaOnCampo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campos", "_Lista", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campos", "_Lista");
        }
    }
}
