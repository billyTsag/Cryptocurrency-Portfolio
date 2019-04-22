namespace CryptoFolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class watchadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coins", "Watch", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coins", "Watch");
        }
    }
}
