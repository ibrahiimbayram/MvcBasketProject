namespace DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LanguageTablesAddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Languages", "OrderCompleted", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Languages", "OrderCompleted");
        }
    }
}
