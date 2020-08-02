namespace DataBase.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dic.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dic.Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TypeID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dic.Type", t => t.TypeID)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dic.Type",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GadgetName = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dic.Sp_Si",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegisterNumber = c.String(nullable: false, maxLength: 150),
                        Deal = c.String(maxLength: 50),
                        Page = c.String(maxLength: 10),
                        IsSp = c.Boolean(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dic.Model", "TypeID", "dic.Type");
            DropIndex("dic.Model", new[] { "TypeID" });
            DropTable("dic.Sp_Si");
            DropTable("dic.Type");
            DropTable("dic.Model");
            DropTable("dic.Location");
        }
    }
}
