namespace MetierRvMedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class MakeRequiredformdpandidentifiant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Personnes", "NavigationRole_Id", "Roles");
            DropForeignKey("Personnes", "IdRole", "Roles");
            DropIndex("Personnes", new[] { "NavigationRole_Id" });
            AddForeignKey("Personnes", "IdRole", "Roles", "Id", cascadeDelete: true);
            DropColumn("Personnes", "NavigationRole_Id");
        }

        public override void Down()
        {
            AddColumn("Personnes", "NavigationRole_Id", c => c.Int());
            DropForeignKey("Personnes", "IdRole", "Roles");
            CreateIndex("Personnes", "NavigationRole_Id");
            AddForeignKey("Personnes", "IdRole", "Roles", "Id");
            AddForeignKey("Personnes", "NavigationRole_Id", "Roles", "Id");
        }
    }
}
