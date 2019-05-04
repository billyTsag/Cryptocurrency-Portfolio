namespace CryptoFolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coinmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Coins", "Symbol");
            DropColumn("dbo.Coins", "Price");
            DropColumn("dbo.Coins", "Supply");
            DropColumn("dbo.Coins", "Watch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coins", "Watch", c => c.Boolean(nullable: false));
            AddColumn("dbo.Coins", "Supply", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Coins", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Coins", "Symbol", c => c.String());
        }
    }
}
