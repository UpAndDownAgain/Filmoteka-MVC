namespace Filmoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class director : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "director", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "director");
        }
    }
}
