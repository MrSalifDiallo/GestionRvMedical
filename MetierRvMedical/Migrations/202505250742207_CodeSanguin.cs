namespace MetierRvMedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeSanguin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agenda", "IdMedecin", "dbo.Personnes");
            DropIndex("dbo.Agenda", new[] { "IdMedecin" });
            AlterColumn("dbo.Agenda", "DatePlanifie", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Agenda", "HeureDebut", c => c.String(nullable: false, maxLength: 10, storeType: "nvarchar"));
            AlterColumn("dbo.Agenda", "HeureFin", c => c.String(nullable: false, maxLength: 10, storeType: "nvarchar"));
            AlterColumn("dbo.Agenda", "IdMedecin", c => c.Int(nullable: false));
            AlterColumn("dbo.GroupeSanguins", "NomGroupeSanguin", c => c.String(nullable: false, maxLength: 39, storeType: "nvarchar"));
            CreateIndex("dbo.Agenda", "IdMedecin");
            AddForeignKey("dbo.Agenda", "IdMedecin", "dbo.Personnes", "IdU", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "IdMedecin", "dbo.Personnes");
            DropIndex("dbo.Agenda", new[] { "IdMedecin" });
            AlterColumn("dbo.GroupeSanguins", "NomGroupeSanguin", c => c.String(nullable: false, maxLength: 25, storeType: "nvarchar"));
            AlterColumn("dbo.Agenda", "IdMedecin", c => c.Int());
            AlterColumn("dbo.Agenda", "HeureFin", c => c.String(maxLength: 10, storeType: "nvarchar"));
            AlterColumn("dbo.Agenda", "HeureDebut", c => c.String(maxLength: 10, storeType: "nvarchar"));
            AlterColumn("dbo.Agenda", "DatePlanifie", c => c.DateTime(precision: 0));
            CreateIndex("dbo.Agenda", "IdMedecin");
            AddForeignKey("dbo.Agenda", "IdMedecin", "dbo.Personnes", "IdU");
        }
    }
}
