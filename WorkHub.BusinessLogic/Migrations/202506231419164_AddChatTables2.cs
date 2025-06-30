namespace WorkHub.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChatTables2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatMessages", "SenderRole", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatMessages", "SenderRole");
        }
    }
}
