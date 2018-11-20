namespace OddJobsOnDemand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedIdentityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetails_Customer",
                c => new
                    {
                        CustomerAccountId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerAccountId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountDetails_Customer", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AccountDetails_Customer", new[] { "CustomerId" });
            DropTable("dbo.AccountDetails_Customer");
        }
    }
}
