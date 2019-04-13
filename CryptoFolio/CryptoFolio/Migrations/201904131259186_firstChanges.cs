namespace CryptoFolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coins", "Supply", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Portfolios", "Name", c => c.String());
            AddColumn("dbo.Portfolios", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portfolios", "DateCreated");
            DropColumn("dbo.Portfolios", "Name");
            DropColumn("dbo.Coins", "Supply");
        }
    }
}
