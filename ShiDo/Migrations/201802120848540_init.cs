namespace ShiDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        GalleryName = c.String(),
                    })
                .PrimaryKey(t => t.GalleryId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        Name = c.String(),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.Pictures", new[] { "GalleryId" });
            DropTable("dbo.Pictures");
            DropTable("dbo.Galleries");
        }
    }
}
