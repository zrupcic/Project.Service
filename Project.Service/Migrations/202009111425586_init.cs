namespace Project.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abrv = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MakeID = c.Int(nullable: false),
                        Name = c.String(),
                        Abrv = c.String(),
                        VehicleMake_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehicleMakes", t => t.VehicleMake_ID)
                .Index(t => t.VehicleMake_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "VehicleMake_ID", "dbo.VehicleMakes");
            DropIndex("dbo.VehicleModels", new[] { "VehicleMake_ID" });
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleMakes");
        }
    }
}
