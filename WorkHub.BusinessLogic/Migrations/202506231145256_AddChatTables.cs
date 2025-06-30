namespace WorkHub.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChatTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatRoomId = c.Int(nullable: false),
                        Sender = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        SentAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.ChatRoomId, cascadeDelete: true)
                .Index(t => t.ChatRoomId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChatMessages", "ChatRoomId", "dbo.Chats");
            DropIndex("dbo.ChatMessages", new[] { "ChatRoomId" });
            DropTable("dbo.Chats");
            DropTable("dbo.ChatMessages");
        }
    }
}
