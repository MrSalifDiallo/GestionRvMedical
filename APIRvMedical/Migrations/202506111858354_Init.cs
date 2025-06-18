namespace APIRvMedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        IdAgenda = c.Int(nullable: false, identity: true),
                        DatePlanifie = c.DateTime(nullable: false, precision: 0),
                        Titre = c.String(maxLength: 100, storeType: "nvarchar"),
                        HeureDebut = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        HeureFin = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Creneau = c.Int(nullable: false),
                        Lieu = c.String(maxLength: 100, storeType: "nvarchar"),
                        statut = c.String(maxLength: 50, storeType: "nvarchar"),
                        IdMedecin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAgenda)
                .ForeignKey("dbo.Personnes", t => t.IdMedecin, cascadeDelete: true)
                .Index(t => t.IdMedecin);
            
            CreateTable(
                "dbo.Creneaux",
                c => new
                    {
                        IdCreneau = c.Int(nullable: false, identity: true),
                        IdAgenda = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        HeureDebut = c.String(maxLength: 25, storeType: "nvarchar"),
                        HeureFin = c.String(maxLength: 25, storeType: "nvarchar"),
                        Disponible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdCreneau)
                .ForeignKey("dbo.Agenda", t => t.IdAgenda, cascadeDelete: true)
                .Index(t => t.IdAgenda);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        IdU = c.Int(nullable: false, identity: true),
                        NomPrenom = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Email = c.String(nullable: false, unicode: false),
                        Adresse = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        TEL = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        identifiant = c.String(maxLength: 50, storeType: "nvarchar"),
                        MotDePasse = c.String(maxLength: 100, storeType: "nvarchar"),
                        statut = c.Boolean(),
                        IdRole = c.Int(),
                        IdSpecialite = c.Int(),
                        NumeroOrdre = c.String(maxLength: 100, storeType: "nvarchar"),
                        IdGroupeSanguin = c.Int(),
                        Poids = c.Single(),
                        Taille = c.Single(),
                        DateNaissance = c.DateTime(precision: 0),
                        TelephoneFixe = c.String(maxLength: 15, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdU)
                .ForeignKey("dbo.Specialites", t => t.IdSpecialite)
                .ForeignKey("dbo.GroupeSanguins", t => t.IdGroupeSanguin, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.IdRole, cascadeDelete: true)
                .Index(t => t.IdRole)
                .Index(t => t.IdSpecialite)
                .Index(t => t.IdGroupeSanguin);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50, storeType: "nvarchar"),
                        Description = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeSpecialite = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        NomSpecialite = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RendezVous",
                c => new
                    {
                        IdRv = c.Int(nullable: false, identity: true),
                        DateRv = c.DateTime(nullable: false, precision: 0),
                        Statut = c.String(maxLength: 10, storeType: "nvarchar"),
                        IdSoin = c.Int(),
                        IdPatient = c.Int(),
                        IdMedecin = c.Int(),
                        IdCreneau = c.Int(),
                        Agenda_IdAgenda = c.Int(),
                    })
                .PrimaryKey(t => t.IdRv)
                .ForeignKey("dbo.Creneaux", t => t.IdCreneau)
                .ForeignKey("dbo.Personnes", t => t.IdMedecin)
                .ForeignKey("dbo.Personnes", t => t.IdPatient)
                .ForeignKey("dbo.Soins", t => t.IdSoin)
                .ForeignKey("dbo.Agenda", t => t.Agenda_IdAgenda)
                .Index(t => t.IdSoin)
                .Index(t => t.IdPatient)
                .Index(t => t.IdMedecin)
                .Index(t => t.IdCreneau)
                .Index(t => t.Agenda_IdAgenda);
            
            CreateTable(
                "dbo.GroupeSanguins",
                c => new
                    {
                        IdGroupeSanguin = c.Int(nullable: false, identity: true),
                        CodeGroupeSanguin = c.String(nullable: false, maxLength: 3, storeType: "nvarchar"),
                        NomGroupeSanguin = c.String(nullable: false, maxLength: 39, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdGroupeSanguin);
            
            CreateTable(
                "dbo.Soins",
                c => new
                    {
                        IdSoin = c.Int(nullable: false, identity: true),
                        NameSoin = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Duration = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Price = c.Int(nullable: false),
                        Category = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdSoin);
            
            CreateTable(
                "dbo.MoyenPayments",
                c => new
                    {
                        IdModePayment = c.Int(nullable: false, identity: true),
                        CodePayment = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Libelle = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Reference = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdModePayment);
            
            CreateTable(
                "dbo.Paiements",
                c => new
                    {
                        IdPayment = c.Int(nullable: false, identity: true),
                        CodePay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPayment);
            
            CreateTable(
                "dbo.Td_Erreur",
                c => new
                    {
                        Id_Erreur = c.Int(nullable: false, identity: true),
                        DateErreur = c.DateTime(nullable: false, precision: 0),
                        TitreErreur = c.String(maxLength: 200, storeType: "nvarchar"),
                        DescriptionErreur = c.String(maxLength: 2000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id_Erreur);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnes", "IdRole", "dbo.Roles");
            DropForeignKey("dbo.RendezVous", "Agenda_IdAgenda", "dbo.Agenda");
            DropForeignKey("dbo.RendezVous", "IdSoin", "dbo.Soins");
            DropForeignKey("dbo.RendezVous", "IdPatient", "dbo.Personnes");
            DropForeignKey("dbo.Personnes", "IdGroupeSanguin", "dbo.GroupeSanguins");
            DropForeignKey("dbo.RendezVous", "IdMedecin", "dbo.Personnes");
            DropForeignKey("dbo.RendezVous", "IdCreneau", "dbo.Creneaux");
            DropForeignKey("dbo.Personnes", "IdSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.Agenda", "IdMedecin", "dbo.Personnes");
            DropForeignKey("dbo.Creneaux", "IdAgenda", "dbo.Agenda");
            DropIndex("dbo.RendezVous", new[] { "Agenda_IdAgenda" });
            DropIndex("dbo.RendezVous", new[] { "IdCreneau" });
            DropIndex("dbo.RendezVous", new[] { "IdMedecin" });
            DropIndex("dbo.RendezVous", new[] { "IdPatient" });
            DropIndex("dbo.RendezVous", new[] { "IdSoin" });
            DropIndex("dbo.Personnes", new[] { "IdGroupeSanguin" });
            DropIndex("dbo.Personnes", new[] { "IdSpecialite" });
            DropIndex("dbo.Personnes", new[] { "IdRole" });
            DropIndex("dbo.Creneaux", new[] { "IdAgenda" });
            DropIndex("dbo.Agenda", new[] { "IdMedecin" });
            DropTable("dbo.Td_Erreur");
            DropTable("dbo.Paiements");
            DropTable("dbo.MoyenPayments");
            DropTable("dbo.Soins");
            DropTable("dbo.GroupeSanguins");
            DropTable("dbo.RendezVous");
            DropTable("dbo.Specialites");
            DropTable("dbo.Roles");
            DropTable("dbo.Personnes");
            DropTable("dbo.Creneaux");
            DropTable("dbo.Agenda");
        }
    }
}
