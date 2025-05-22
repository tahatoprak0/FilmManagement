namespace FilmYonetimSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        filmId = c.Int(nullable: false, identity: true),
                        filmAdi = c.String(),
                        yapimYili = c.String(),
                        yonetmenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.filmId)
                .ForeignKey("dbo.Yonetmen", t => t.yonetmenId, cascadeDelete: true)
                .Index(t => t.yonetmenId);
            
            CreateTable(
                "dbo.Yonetmen",
                c => new
                    {
                        yonetmenId = c.Int(nullable: false, identity: true),
                        yonetmenAdi = c.String(),
                        yonetmenSoyadi = c.String(),
                        dogumYili = c.String(),
                    })
                .PrimaryKey(t => t.yonetmenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "yonetmenId", "dbo.Yonetmen");
            DropIndex("dbo.Films", new[] { "yonetmenId" });
            DropTable("dbo.Yonetmen");
            DropTable("dbo.Films");
        }
    }
}
