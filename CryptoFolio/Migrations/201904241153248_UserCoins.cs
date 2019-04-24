namespace CryptoFolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCoins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCoins",
                c => new
                    {
                        CoinID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CoinID, t.UserID })
                .ForeignKey("dbo.Coins", t => t.CoinID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.CoinID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCoins", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCoins", "CoinID", "dbo.Coins");
            DropIndex("dbo.UserCoins", new[] { "UserID" });
            DropIndex("dbo.UserCoins", new[] { "CoinID" });
            DropTable("dbo.UserCoins");
        }
    }
}
