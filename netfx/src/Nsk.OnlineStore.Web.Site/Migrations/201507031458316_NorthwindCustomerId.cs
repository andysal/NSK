namespace Nsk.OnlineStore.Web.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NorthwindCustomerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CustomerId", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CustomerId");
        }
    }
}
