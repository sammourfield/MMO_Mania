namespace MMO_Mania.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MMO_Mania.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MMO_Mania.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            
                context.Games.AddOrUpdate(
                 p => p.GameName,
                  new Games { GameName = "World Of Warcraft", GameID = 1, Desc = "Set in the fictional world of Azeroth, WoW allows players to create avatar-style characters and explore a sprawling universe while interacting with nonreal players—called nonplayer characters (NPCs)—and other real-world players (PCs). Various quests, battles, and missions are completed alone or in guilds, and the rewards for success include gold, weapons, and valuable items, which are used to improve one’s character." }, 
                  new Games { GameName = "RuneScape", GameID = 2, Desc = "RuneScape is a point - and - click game set in a fantasy world called Gielinor where players can interact with each other.What players do is entirely up to them, as everything is optional.Every player decides their own fate and can choose to do as they please, whether they want to train a skill, fight monsters, partake in a quest, play a mini-game, or socialize with others." },
                  new Games { GameName = "ElderScrolls Online", GameID = 3, Desc = "The Elder Scrolls is a series of action role-playing video games primarily developed by Bethesda Game Studios and published by Bethesda Softworks. The series focuses on free-form gameplay in a detailed open world. Morrowind, Oblivion and Skyrim all won Game of the Year awards from multiple outlets." }
                );
            
        }
    }
}
