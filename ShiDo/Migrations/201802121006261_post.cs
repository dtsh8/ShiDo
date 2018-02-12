namespace ShiDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class post : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.Pictures", new[] { "GalleryId" });
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(),
                        PostText = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
            DropTable("dbo.Galleries");
            DropTable("dbo.Pictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        Name = c.String(),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PictureId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        GalleryName = c.String(),
                    })
                .PrimaryKey(t => t.GalleryId);
            
            DropTable("dbo.Posts");
            CreateIndex("dbo.Pictures", "GalleryId");
            AddForeignKey("dbo.Pictures", "GalleryId", "dbo.Galleries", "GalleryId", cascadeDelete: true);
        }
    }
}
