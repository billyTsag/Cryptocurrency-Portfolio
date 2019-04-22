namespace CryptoFolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buysell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Buy", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Buy");
        }
    }
}
