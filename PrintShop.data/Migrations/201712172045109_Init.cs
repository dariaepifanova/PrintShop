namespace PrintShop.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lastname = c.String(),
                        Email = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        PrintItemId = c.Int(nullable: false),
                        ClothesSize = c.String(),
                        ClothesType = c.String(),
                        Quantity = c.Int(nullable: false),
                        AdoptionDate = c.DateTime(nullable: false),
                        ExportDate = c.DateTime(nullable: false),
                        Delivery = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.PrintItems", t => t.PrintItemId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.PrintItemId);
            
            CreateTable(
                "dbo.PrintItems",
                c => new
                    {
                        PrintItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.PrintItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PrintItemId", "dbo.PrintItems");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "PrintItemId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropTable("dbo.PrintItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
        }
    }
}
