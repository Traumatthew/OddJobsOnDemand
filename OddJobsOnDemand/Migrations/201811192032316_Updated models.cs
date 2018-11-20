namespace OddJobsOnDemand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        ContractorId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        ContractorName = c.String(),
                        ContractorPhone = c.String(),
                        AreaOfExpertise = c.String(),
                        ContractorEmail = c.String(),
                        ContractorStreet = c.String(),
                        ContractorState = c.String(),
                        ContractorCity = c.String(),
                        ContractorZip = c.String(),
                        lat = c.String(),
                        lng = c.String(),
                    })
                .PrimaryKey(t => t.ContractorId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        lat = c.String(),
                        lng = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.GeoLocations",
                c => new
                    {
                        GeoID = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Lat = c.String(),
                        Long = c.String(),
                    })
                .PrimaryKey(t => t.GeoID)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.JobRequests",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Time = c.String(nullable: false),
                        Estimate = c.Double(nullable: false),
                        Complete = c.Boolean(nullable: false),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            AddColumn("dbo.AspNetUsers", "ContractorName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Street", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "State", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Zip", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "AccountType", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobRequests", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.GeoLocations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contractors", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.JobRequests", new[] { "CustomerId" });
            DropIndex("dbo.GeoLocations", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "ApplicationUserId" });
            DropIndex("dbo.Contractors", new[] { "ApplicationUserId" });
            DropColumn("dbo.AspNetUsers", "AccountType");
            DropColumn("dbo.AspNetUsers", "Zip");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "ContractorName");
            DropTable("dbo.JobRequests");
            DropTable("dbo.GeoLocations");
            DropTable("dbo.Customers");
            DropTable("dbo.Contractors");
        }
    }
}
