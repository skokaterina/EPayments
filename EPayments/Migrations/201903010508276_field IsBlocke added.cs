namespace EPayments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldIsBlockeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sites", "IsBlocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sites", "IsBlocked");
        }
    }
}
