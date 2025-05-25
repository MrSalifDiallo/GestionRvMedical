namespace MetierRvMedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            // Modification des colonnes
            AlterColumn("agenda", "DatePlanifie", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("agenda", "HeureDebut", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("agenda", "HeureFin", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("agenda", "IdMedecin", c => c.Int(nullable: false));
            AlterColumn("groupesanguins", "NomGroupeSanguin", c => c.String(nullable: false, maxLength: 39));

            // Création d'index et FK uniquement si nécessaire
            CreateIndex("agenda", "IdMedecin");
            AddForeignKey("agenda", "IdMedecin", "personnes", "IdU", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("agenda", "IdMedecin", "personnes");
            DropIndex("agenda", new[] { "IdMedecin" });

            AlterColumn("groupesanguins", "NomGroupeSanguin", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("agenda", "IdMedecin", c => c.Int());
            AlterColumn("agenda", "HeureFin", c => c.String(maxLength: 10));
            AlterColumn("agenda", "HeureDebut", c => c.String(maxLength: 10));
            AlterColumn("agenda", "DatePlanifie", c => c.DateTime(precision: 0));

            CreateIndex("agenda", "IdMedecin");
            AddForeignKey("agenda", "IdMedecin", "personnes", "IdU");
        }
    }
}
