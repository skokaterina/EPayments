namespace EPayments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredURL : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sites", "URL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sites", "URL", c => c.String());
        }
    }
}
