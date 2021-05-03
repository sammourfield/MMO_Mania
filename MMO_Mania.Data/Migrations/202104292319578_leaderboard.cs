namespace MMO_Mania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leaderboard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leaderboard",
                c => new
                    {
                        Ranking = c.Int(nullable: false, identity: true),
                        Char_Id = c.Int(nullable: false),
                        Char_Name = c.String(),
                        Level = c.Int(nullable: false),
                        Achievements = c.String(),
                    })
                .PrimaryKey(t => t.Ranking);
            
            AddColumn("dbo.Character", "Ranking", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Character", "Ranking");
            DropTable("dbo.Leaderboard");
        }
    }
}
