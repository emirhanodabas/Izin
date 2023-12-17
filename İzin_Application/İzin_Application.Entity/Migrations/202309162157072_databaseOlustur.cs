namespace İzin_Application.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Departman",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Departman_Adi = c.String(maxLength: 30, unicode: false),
                        Aciklama = c.String(maxLength: 300, unicode: false),
                        Durumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblPersonel",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAdi = c.String(maxLength: 40, unicode: false),
                        PersonelSoyadi = c.String(maxLength: 40, unicode: false),
                        PersonelEmail = c.String(maxLength: 50, unicode: false),
                        DepartmanID = c.Int(nullable: false),
                        PersonelKAdi = c.String(maxLength: 30, unicode: false),
                        PersonelParola = c.String(maxLength: 30, unicode: false),
                        GirisTarihi = c.DateTime(nullable: false, storeType: "date"),
                        Telefon = c.String(maxLength: 15, unicode: false),
                        Adres = c.String(maxLength: 150, unicode: false),
                        TC = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        IzinHak = c.Int(nullable: false),
                        Durumu = c.Boolean(nullable: false),
                        YetkiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.Tbl_Departman", t => t.DepartmanID, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Yetki", t => t.YetkiId, cascadeDelete: true)
                .Index(t => t.DepartmanID)
                .Index(t => t.YetkiId);
            
            CreateTable(
                "dbo.Tbl_Izin",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonelID = c.Int(nullable: false),
                        IzinTurId = c.Int(nullable: false),
                        IzinBaslangic = c.DateTime(nullable: false, storeType: "date"),
                        IzinBitis = c.DateTime(nullable: false, storeType: "date"),
                        Aciklama = c.String(maxLength: 200, unicode: false),
                        tarih = c.DateTime(nullable: false, storeType: "date"),
                        Durumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_IzinTur", t => t.IzinTurId, cascadeDelete: true)
                .ForeignKey("dbo.tblPersonel", t => t.PersonelID, cascadeDelete: true)
                .Index(t => t.PersonelID)
                .Index(t => t.IzinTurId);
            
            CreateTable(
                "dbo.Tbl_IzinTur",
                c => new
                    {
                        IzinTurId = c.Int(nullable: false, identity: true),
                        IzinTuru = c.String(maxLength: 25, unicode: false),
                        IzinSure = c.String(maxLength: 10, unicode: false),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Durumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IzinTurId);
            
            CreateTable(
                "dbo.Tbl_Yetki",
                c => new
                    {
                        YetkiId = c.Int(nullable: false, identity: true),
                        YetkiAdi = c.String(maxLength: 15, unicode: false),
                        YetkiAciklama = c.String(),
                        YetkiDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YetkiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblPersonel", "YetkiId", "dbo.Tbl_Yetki");
            DropForeignKey("dbo.Tbl_Izin", "PersonelID", "dbo.tblPersonel");
            DropForeignKey("dbo.Tbl_Izin", "IzinTurId", "dbo.Tbl_IzinTur");
            DropForeignKey("dbo.tblPersonel", "DepartmanID", "dbo.Tbl_Departman");
            DropIndex("dbo.Tbl_Izin", new[] { "IzinTurId" });
            DropIndex("dbo.Tbl_Izin", new[] { "PersonelID" });
            DropIndex("dbo.tblPersonel", new[] { "YetkiId" });
            DropIndex("dbo.tblPersonel", new[] { "DepartmanID" });
            DropTable("dbo.Tbl_Yetki");
            DropTable("dbo.Tbl_IzinTur");
            DropTable("dbo.Tbl_Izin");
            DropTable("dbo.tblPersonel");
            DropTable("dbo.Tbl_Departman");
        }
    }
}
