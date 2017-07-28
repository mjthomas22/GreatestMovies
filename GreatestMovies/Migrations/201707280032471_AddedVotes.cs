namespace GreatestMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "Votes", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Votes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Votes");
            DropColumn("dbo.Actors", "Votes");
        }
    }
}
