namespace ProiectCuEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeopleAndBooksTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AuthorId = c.Int(nullable: false),
                        Publisher = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.People");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.People");
            DropTable("dbo.Books");
        }
    }
}
