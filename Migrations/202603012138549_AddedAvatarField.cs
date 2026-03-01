namespace Seleznev2702Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAvatarField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AvatarPath", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AvatarPath");
        }
    }
}
