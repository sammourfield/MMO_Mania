namespace MMO_Mania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leaderboard2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaderboard", "GameTitle", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leaderboard", "GameTitle");
        }
    }
}
