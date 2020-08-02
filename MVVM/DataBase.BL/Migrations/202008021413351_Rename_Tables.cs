namespace DataBase.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_Tables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dic.Location", newName: "Device_Location");
            RenameTable(name: "dic.Type", newName: "Device_Type");
            RenameTable(name: "dic.Sp_Si", newName: "Device_Sp_Si");
            DropForeignKey("dic.Model", "TypeID", "dic.Type");
            DropIndex("dic.Model", new[] { "TypeID" });
            CreateTable(
                "dic.Device_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DeviceTypeID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dic.Device_Type", t => t.DeviceTypeID)
                .Index(t => t.DeviceTypeID);
            
            DropTable("dic.Model");
        }
        
        public override void Down()
        {
            CreateTable(
                "dic.Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TypeID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dic.Device_Model", "DeviceTypeID", "dic.Device_Type");
            DropIndex("dic.Device_Model", new[] { "DeviceTypeID" });
            DropTable("dic.Device_Model");
            CreateIndex("dic.Model", "TypeID");
            AddForeignKey("dic.Model", "TypeID", "dic.Type", "ID");
            RenameTable(name: "dic.Device_Sp_Si", newName: "Sp_Si");
            RenameTable(name: "dic.Device_Type", newName: "Type");
            RenameTable(name: "dic.Device_Location", newName: "Location");
        }
    }
}
