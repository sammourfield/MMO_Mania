namespace MMO_Mania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "GameName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Character", "GameName");
        }
    }
}
