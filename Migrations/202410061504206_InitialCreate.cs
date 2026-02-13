namespace yaz1lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Malzemes",
                c => new
                    {
                        MalzemeID = c.Int(nullable: false, identity: true),
                        MalzemeAdi = c.String(),
                        ToplamMiktar = c.String(),
                        MalzemeBirim = c.String(),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MalzemeID);
            
            CreateTable(
                "dbo.TarifMalzemes",
                c => new
                    {
                        TarifID = c.Int(nullable: false),
                        MalzemeID = c.Int(nullable: false),
                        MalzemeMiktar = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.TarifID, t.MalzemeID })
                .ForeignKey("dbo.Malzemes", t => t.MalzemeID, cascadeDelete: true)
                .ForeignKey("dbo.Tarifs", t => t.TarifID, cascadeDelete: true)
                .Index(t => t.TarifID)
                .Index(t => t.MalzemeID);
            
            CreateTable(
                "dbo.Tarifs",
                c => new
                    {
                        TarifID = c.Int(nullable: false, identity: true),
                        TarifAdi = c.String(),
                        Kategori = c.String(),
                        HazirlamaSuresi = c.Int(nullable: false),
                        Talimatlar = c.String(),
                    })
                .PrimaryKey(t => t.TarifID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TarifMalzemes", "TarifID", "dbo.Tarifs");
            DropForeignKey("dbo.TarifMalzemes", "MalzemeID", "dbo.Malzemes");
            DropIndex("dbo.TarifMalzemes", new[] { "MalzemeID" });
            DropIndex("dbo.TarifMalzemes", new[] { "TarifID" });
            DropTable("dbo.Tarifs");
            DropTable("dbo.TarifMalzemes");
            DropTable("dbo.Malzemes");
        }
    }
}
