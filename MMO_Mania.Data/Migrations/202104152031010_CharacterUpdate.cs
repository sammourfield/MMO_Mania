namespace MMO_Mania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "GameTitle", c => c.Int());
            DropColumn("dbo.Character", "Game");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Character", "Game", c => c.String(nullable: false));
            DropColumn("dbo.Character", "GameTitle");
        }
    }
}
