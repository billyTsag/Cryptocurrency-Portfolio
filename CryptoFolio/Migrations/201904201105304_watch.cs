namespace CryptoFolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class watch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Watch", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Watch");
        }
    }
}
