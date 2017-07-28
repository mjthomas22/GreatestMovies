namespace GreatestMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorID = c.Int(nullable: false, identity: true),
                        ActorName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Nationality = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.ActorID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        BoxOfficeGross = c.Double(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreType = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_MovieID = c.Int(nullable: false),
                        Actor_ActorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieID, t.Actor_ActorID })
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_ActorID, cascadeDelete: true)
                .Index(t => t.Movie_MovieID)
                .Index(t => t.Actor_ActorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.MovieActors", "Actor_ActorID", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "Movie_MovieID", "dbo.Movies");
            DropIndex("dbo.MovieActors", new[] { "Actor_ActorID" });
            DropIndex("dbo.MovieActors", new[] { "Movie_MovieID" });
            DropIndex("dbo.Movies", new[] { "GenreID" });
            DropTable("dbo.MovieActors");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
