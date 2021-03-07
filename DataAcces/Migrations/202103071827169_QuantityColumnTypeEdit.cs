namespace DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuantityColumnTypeEdit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserBaskets", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserBaskets", "Quantity", c => c.String(nullable: false));
        }
    }
}
