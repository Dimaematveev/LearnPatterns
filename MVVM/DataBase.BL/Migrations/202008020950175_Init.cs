namespace DataBase.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelDevice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeDeviceID = c.Int(nullable: false),
                        Name = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TypeDevice", t => t.TypeDeviceID)
                .Index(t => t.TypeDeviceID);
            
            CreateTable(
                "dbo.TypeDevice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelDevice", "TypeDeviceID", "dbo.TypeDevice");
            DropIndex("dbo.ModelDevice", new[] { "TypeDeviceID" });
            DropTable("dbo.TypeDevice");
            DropTable("dbo.ModelDevice");
        }
    }
}
