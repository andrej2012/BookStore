namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "ImageData");
            DropColumn("dbo.Books", "ImageMimeType");
            DropTable("dbo.Chapters");
            DropTable("dbo.Tags");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        tag = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        ChapterId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        NameChapter = c.String(nullable: false),
                        TextChapter = c.String(nullable: false),
                        ImageDataChapter = c.Binary(),
                        ImageMimeTypeChapter = c.String(),
                    })
                .PrimaryKey(t => t.ChapterId);
            
            AddColumn("dbo.Books", "ImageMimeType", c => c.String());
            AddColumn("dbo.Books", "ImageData", c => c.Binary());
        }
    }
}
