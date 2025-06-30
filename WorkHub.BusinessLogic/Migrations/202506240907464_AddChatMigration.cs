namespace WorkHub.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChatMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatMessages", "IsNew", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatMessages", "IsNew");
        }
    }
}
