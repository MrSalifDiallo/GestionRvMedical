namespace MetierRvMedical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUtilisateurModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnes", "NavigationRole_Id", c => c.Int());
            CreateIndex("dbo.Personnes", "NavigationRole_Id");
            AddForeignKey("dbo.Personnes", "NavigationRole_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnes", "NavigationRole_Id", "dbo.Roles");
            DropIndex("dbo.Personnes", new[] { "NavigationRole_Id" });
            DropColumn("dbo.Personnes", "NavigationRole_Id");
        }
    }
}
