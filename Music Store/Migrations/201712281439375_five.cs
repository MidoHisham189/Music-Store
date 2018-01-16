namespace Music_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Albums", "GenreId");
            AddForeignKey("dbo.Albums", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "GenreId", "dbo.Genres");
            DropIndex("dbo.Albums", new[] { "GenreId" });
        }
    }
}
