namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersAndCheckout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "PruductName", c => c.String());
            DropColumn("dbo.OrderItems", "PrudctName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "PrudctName", c => c.String());
            DropColumn("dbo.OrderItems", "PruductName");
        }
    }
}
