namespace DataBase.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Gadget : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dic.Device_Gadget",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dic.Device_Type", "DeviceGadgetID", c => c.Int(nullable: false));
            CreateIndex("dic.Device_Type", "DeviceGadgetID");
            AddForeignKey("dic.Device_Type", "DeviceGadgetID", "dic.Device_Gadget", "ID");
            DropColumn("dic.Device_Type", "GadgetName");
        }
        
        public override void Down()
        {
            AddColumn("dic.Device_Type", "GadgetName", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dic.Device_Type", "DeviceGadgetID", "dic.Device_Gadget");
            DropIndex("dic.Device_Type", new[] { "DeviceGadgetID" });
            DropColumn("dic.Device_Type", "DeviceGadgetID");
            DropTable("dic.Device_Gadget");
        }
    }
}
