namespace Seleznev2702Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        NamePosition = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.NamePosition)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        NameRole = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.NameRole)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Surname = c.String(nullable: false, maxLength: 50, unicode: false),
                        Patronymic = c.String(nullable: false, maxLength: 50, unicode: false),
                        Age = c.Int(nullable: false),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Gender = c.String(),
                        PositionName = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionName, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleName, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.PositionName)
                .Index(t => t.RoleName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleName", "dbo.Roles");
            DropForeignKey("dbo.Users", "PositionName", "dbo.Positions");
            DropIndex("dbo.Users", new[] { "RoleName" });
            DropIndex("dbo.Users", new[] { "PositionName" });
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.Roles", new[] { "Id" });
            DropIndex("dbo.Positions", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Positions");
        }
    }
}
