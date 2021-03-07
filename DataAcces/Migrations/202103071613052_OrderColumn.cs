namespace DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBaskets", "Order", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBaskets", "Order");
        }
    }
}
