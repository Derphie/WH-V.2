namespace WorkHub.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChatTables1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chats", "Topic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chats", "Topic");
        }
    }
}
