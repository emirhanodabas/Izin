namespace İzin_Application.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateetme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblPersonel", "AnnelikIzinHak", c => c.Int(nullable: false));
            AddColumn("dbo.tblPersonel", "EvlilikIzinHak", c => c.Int(nullable: false));
            AddColumn("dbo.tblPersonel", "OlumIzinHak", c => c.Int(nullable: false));
            AddColumn("dbo.tblPersonel", "DogumIzinHak", c => c.Int(nullable: false));
            AddColumn("dbo.tblPersonel", "CenazeIzinHak", c => c.Int(nullable: false));
            AddColumn("dbo.tblPersonel", "UcretsizIzinHak", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblPersonel", "UcretsizIzinHak");
            DropColumn("dbo.tblPersonel", "CenazeIzinHak");
            DropColumn("dbo.tblPersonel", "DogumIzinHak");
            DropColumn("dbo.tblPersonel", "OlumIzinHak");
            DropColumn("dbo.tblPersonel", "EvlilikIzinHak");
            DropColumn("dbo.tblPersonel", "AnnelikIzinHak");
        }
    }
}
