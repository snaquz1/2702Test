namespace Seleznev2702Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefinedDefaultValueForAvatarField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "AvatarPath", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "AvatarPath", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
