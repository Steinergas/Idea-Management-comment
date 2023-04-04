namespace Idea_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.posts",
                c => new
                    {
                        post_id = c.Int(nullable: false, identity: true),
                        post_text = c.String(),
                        post_date = c.DateTime(nullable: false),
                        post_like = c.Int(nullable: false),
                        post_dislike = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.post_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.posts");
        }
    }
}
