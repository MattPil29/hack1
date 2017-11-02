namespace MoodUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moods : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        mood = c.Double(nullable: false),
                        timestamp = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moods", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Moods", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Moods");
        }
    }
}
