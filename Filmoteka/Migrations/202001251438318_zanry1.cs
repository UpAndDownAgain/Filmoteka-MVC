namespace Filmoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zanry1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "genreFK", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "genre_id", c => c.Int());
            CreateIndex("dbo.Movies", "genre_id");
            AddForeignKey("dbo.Movies", "genre_id", "dbo.Genres", "id");
            DropColumn("dbo.Movies", "genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "genre", c => c.String());
            DropForeignKey("dbo.Movies", "genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_id" });
            DropColumn("dbo.Movies", "genre_id");
            DropColumn("dbo.Movies", "genreFK");
        }
    }
}
