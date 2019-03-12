namespace EPayments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldURLadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sites", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sites", "URL");
        }
    }
}
