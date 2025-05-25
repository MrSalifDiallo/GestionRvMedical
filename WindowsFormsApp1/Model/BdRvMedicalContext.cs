using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using WindowsFormsApp1.Model;
using MySql.Data.MySqlClient;
using MySql.Data.EntityFramework; // Nécessaire pour MySqlEFConfiguration
namespace WindowsFormsApp1.Model
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class BdRvMedicalContext : DbContext
    {
        public BdRvMedicalContext() : base("bdRvMedicalContext") { }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Patient> Patients { get; set; }


        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public DbSet<Medecin> Medecins { get; set; }

        public DbSet<Secretaire> Secretaires { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<RendezVous> AllRendezvous { get; set; }

        public DbSet<GroupeSanguin> GroupeSanguins { get; set; }

        public DbSet<Soin> Soins { get; set; }
        public DbSet<MoyenPayment> MoyenPayments { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Creneau> Creneaux { get; set; }

        public DbSet<Td_Erreur> td_Erreurs { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Role> Roles { get; set; }



    }
}
