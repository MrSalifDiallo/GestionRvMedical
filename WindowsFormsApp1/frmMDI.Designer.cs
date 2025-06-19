namespace WindowsFormsApp1
{
    partial class frmMDI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDI));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAjouter = new System.Windows.Forms.ToolStripDropDownButton();
            this.parientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docteursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rendezToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assistantMedecinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnModifier = new System.Windows.Forms.ToolStripDropDownButton();
            this.patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docteursToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rendezVousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assistantMedecinToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.side2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRechercher = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.assistantMedecinToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRendezVous = new System.Windows.Forms.ToolStripDropDownButton();
            this.rendezVousToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownApi = new System.Windows.Forms.ToolStripDropDownButton();
            this.withPhpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rendezVousToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.agendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creneauxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialitéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withApiRvMedicalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.medecinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.assistantMedecinToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.adminsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soinsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moyenPaiementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moyenPaimentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paiementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupeSanguinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creeneauxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupeSanguinsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moyenPaimentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.paiementsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rendezVousToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.soinsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.spécialitésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilisateursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.medecinsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.secrétairesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAjouter,
            this.btnModifier,
            this.side2,
            this.toolStripRechercher,
            this.btnRendezVous,
            this.toolStripDropDownApi,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(812, 31);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btnAjouter
            // 
            this.btnAjouter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parientsToolStripMenuItem,
            this.docteursToolStripMenuItem,
            this.rendezToolStripMenuItem,
            this.assistantMedecinToolStripMenuItem});
            this.btnAjouter.Image = ((System.Drawing.Image)(resources.GetObject("btnAjouter.Image")));
            this.btnAjouter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(83, 28);
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // parientsToolStripMenuItem
            // 
            this.parientsToolStripMenuItem.Name = "parientsToolStripMenuItem";
            this.parientsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parientsToolStripMenuItem.Text = "Patient";
            this.parientsToolStripMenuItem.Click += new System.EventHandler(this.patientsToolStripMenuItem_Click);
            // 
            // docteursToolStripMenuItem
            // 
            this.docteursToolStripMenuItem.Name = "docteursToolStripMenuItem";
            this.docteursToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.docteursToolStripMenuItem.Text = "Medecin";
            this.docteursToolStripMenuItem.Click += new System.EventHandler(this.docteursToolStripMenuItem_Click);
            // 
            // rendezToolStripMenuItem
            // 
            this.rendezToolStripMenuItem.Name = "rendezToolStripMenuItem";
            this.rendezToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rendezToolStripMenuItem.Text = "Rendez-Vous";
            this.rendezToolStripMenuItem.Click += new System.EventHandler(this.rendezToolStripMenuItem_Click);
            // 
            // assistantMedecinToolStripMenuItem
            // 
            this.assistantMedecinToolStripMenuItem.Name = "assistantMedecinToolStripMenuItem";
            this.assistantMedecinToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.assistantMedecinToolStripMenuItem.Text = "Assistant Medecin";
            // 
            // btnModifier
            // 
            this.btnModifier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientsToolStripMenuItem,
            this.docteursToolStripMenuItem1,
            this.rendezVousToolStripMenuItem,
            this.assistantMedecinToolStripMenuItem1});
            this.btnModifier.Image = ((System.Drawing.Image)(resources.GetObject("btnModifier.Image")));
            this.btnModifier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(89, 28);
            this.btnModifier.Text = "&Modifier";
            this.btnModifier.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.patientsToolStripMenuItem.Text = "Patient";
            // 
            // docteursToolStripMenuItem1
            // 
            this.docteursToolStripMenuItem1.Name = "docteursToolStripMenuItem1";
            this.docteursToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.docteursToolStripMenuItem1.Text = "Medecin";
            // 
            // rendezVousToolStripMenuItem
            // 
            this.rendezVousToolStripMenuItem.Name = "rendezVousToolStripMenuItem";
            this.rendezVousToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rendezVousToolStripMenuItem.Text = "Rendez-Vous";
            // 
            // assistantMedecinToolStripMenuItem1
            // 
            this.assistantMedecinToolStripMenuItem1.Name = "assistantMedecinToolStripMenuItem1";
            this.assistantMedecinToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.assistantMedecinToolStripMenuItem1.Text = "Assistant Medecin";
            // 
            // side2
            // 
            this.side2.Name = "side2";
            this.side2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripRechercher
            // 
            this.toolStripRechercher.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.assistantMedecinToolStripMenuItem2});
            this.toolStripRechercher.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRechercher.Image")));
            this.toolStripRechercher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRechercher.Name = "toolStripRechercher";
            this.toolStripRechercher.Size = new System.Drawing.Size(103, 28);
            this.toolStripRechercher.Text = "&Rechercher";
            this.toolStripRechercher.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Patients";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "Docteurs";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "Rendez-Vous";
            // 
            // assistantMedecinToolStripMenuItem2
            // 
            this.assistantMedecinToolStripMenuItem2.Name = "assistantMedecinToolStripMenuItem2";
            this.assistantMedecinToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.assistantMedecinToolStripMenuItem2.Text = "Assistant Medecin";
            // 
            // btnRendezVous
            // 
            this.btnRendezVous.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rendezVousToolStripMenuItem1});
            this.btnRendezVous.Image = global::WindowsFormsApp1.Properties.Resources.istockphoto_1278801008_612x612;
            this.btnRendezVous.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRendezVous.Name = "btnRendezVous";
            this.btnRendezVous.Size = new System.Drawing.Size(85, 28);
            this.btnRendezVous.Text = "&Agenda";
            this.btnRendezVous.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // rendezVousToolStripMenuItem1
            // 
            this.rendezVousToolStripMenuItem1.Name = "rendezVousToolStripMenuItem1";
            this.rendezVousToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.rendezVousToolStripMenuItem1.Text = "Rendez-Vous";
            this.rendezVousToolStripMenuItem1.Click += new System.EventHandler(this.rendezVousToolStripMenuItem1_Click);
            // 
            // toolStripDropDownApi
            // 
            this.toolStripDropDownApi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.withPhpToolStripMenuItem,
            this.withApiRvMedicalToolStripMenuItem});
            this.toolStripDropDownApi.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownApi.Image")));
            this.toolStripDropDownApi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownApi.Name = "toolStripDropDownApi";
            this.toolStripDropDownApi.Size = new System.Drawing.Size(62, 28);
            this.toolStripDropDownApi.Text = "&Api";
            this.toolStripDropDownApi.Click += new System.EventHandler(this.toolStripDropDownApi_Click);
            // 
            // withPhpToolStripMenuItem
            // 
            this.withPhpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendaToolStripMenuItem,
            this.creneauxToolStripMenuItem,
            this.groupeSanguinsToolStripMenuItem,
            this.moyenPaimentsToolStripMenuItem,
            this.paiementsToolStripMenuItem,
            this.rendezVousToolStripMenuItem2,
            this.rolesToolStripMenuItem,
            this.soinsToolStripMenuItem1,
            this.specialitéToolStripMenuItem,
            this.patientToolStripMenuItem,
            this.moyenPaiementsToolStripMenuItem});
            this.withPhpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("withPhpToolStripMenuItem.Image")));
            this.withPhpToolStripMenuItem.Name = "withPhpToolStripMenuItem";
            this.withPhpToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.withPhpToolStripMenuItem.Text = "WithPhp";
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminsToolStripMenuItem,
            this.medecinsToolStripMenuItem,
            this.assistantMedecinToolStripMenuItem4,
            this.patientsToolStripMenuItem1});
            this.patientToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("patientToolStripMenuItem.Image")));
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.patientToolStripMenuItem.Text = "Personnes";
            // 
            // rendezVousToolStripMenuItem2
            // 
            this.rendezVousToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("rendezVousToolStripMenuItem2.Image")));
            this.rendezVousToolStripMenuItem2.Name = "rendezVousToolStripMenuItem2";
            this.rendezVousToolStripMenuItem2.Size = new System.Drawing.Size(188, 30);
            this.rendezVousToolStripMenuItem2.Text = "Rendez-Vous";
            // 
            // agendaToolStripMenuItem
            // 
            this.agendaToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.istockphoto_1278801008_612x612;
            this.agendaToolStripMenuItem.Name = "agendaToolStripMenuItem";
            this.agendaToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.agendaToolStripMenuItem.Text = "Agendas";
            // 
            // creneauxToolStripMenuItem
            // 
            this.creneauxToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("creneauxToolStripMenuItem.Image")));
            this.creneauxToolStripMenuItem.Name = "creneauxToolStripMenuItem";
            this.creneauxToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.creneauxToolStripMenuItem.Text = "Creneaux";
            // 
            // specialitéToolStripMenuItem
            // 
            this.specialitéToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("specialitéToolStripMenuItem.Image")));
            this.specialitéToolStripMenuItem.Name = "specialitéToolStripMenuItem";
            this.specialitéToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.specialitéToolStripMenuItem.Text = "Specialités";
            // 
            // withApiRvMedicalToolStripMenuItem
            // 
            this.withApiRvMedicalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendasToolStripMenuItem,
            this.creeneauxToolStripMenuItem,
            this.groupeSanguinsToolStripMenuItem1,
            this.moyenPaimentsToolStripMenuItem1,
            this.paiementsToolStripMenuItem1,
            this.rendezVousToolStripMenuItem3,
            this.rolesToolStripMenuItem1,
            this.soinsToolStripMenuItem2,
            this.spécialitésToolStripMenuItem,
            this.utilisateursToolStripMenuItem});
            this.withApiRvMedicalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("withApiRvMedicalToolStripMenuItem.Image")));
            this.withApiRvMedicalToolStripMenuItem.Name = "withApiRvMedicalToolStripMenuItem";
            this.withApiRvMedicalToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.withApiRvMedicalToolStripMenuItem.Text = "WithApiRvMedical";
            // 
            // btn_close
            // 
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 28);
            this.btn_close.Text = "Fermer ";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WindowsFormsApp1.Properties.Resources.istockphoto_1278801008_612x612;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(43, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ButtonClick += new System.EventHandler(this.toolStripButton1_ButtonClick);
            // 
            // medecinsToolStripMenuItem
            // 
            this.medecinsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("medecinsToolStripMenuItem.Image")));
            this.medecinsToolStripMenuItem.Name = "medecinsToolStripMenuItem";
            this.medecinsToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.medecinsToolStripMenuItem.Text = "Medecins";
            // 
            // patientsToolStripMenuItem1
            // 
            this.patientsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("patientsToolStripMenuItem1.Image")));
            this.patientsToolStripMenuItem1.Name = "patientsToolStripMenuItem1";
            this.patientsToolStripMenuItem1.Size = new System.Drawing.Size(188, 30);
            this.patientsToolStripMenuItem1.Text = "Patients";
            // 
            // assistantMedecinToolStripMenuItem4
            // 
            this.assistantMedecinToolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("assistantMedecinToolStripMenuItem4.Image")));
            this.assistantMedecinToolStripMenuItem4.Name = "assistantMedecinToolStripMenuItem4";
            this.assistantMedecinToolStripMenuItem4.Size = new System.Drawing.Size(188, 30);
            this.assistantMedecinToolStripMenuItem4.Text = "Secrétaires";
            // 
            // adminsToolStripMenuItem
            // 
            this.adminsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adminsToolStripMenuItem.Image")));
            this.adminsToolStripMenuItem.Name = "adminsToolStripMenuItem";
            this.adminsToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.adminsToolStripMenuItem.Text = "Admins";
            // 
            // soinsToolStripMenuItem1
            // 
            this.soinsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("soinsToolStripMenuItem1.Image")));
            this.soinsToolStripMenuItem1.Name = "soinsToolStripMenuItem1";
            this.soinsToolStripMenuItem1.Size = new System.Drawing.Size(188, 30);
            this.soinsToolStripMenuItem1.Text = "Soins";
            this.soinsToolStripMenuItem1.Click += new System.EventHandler(this.soinsToolStripMenuItem1_Click);
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rolesToolStripMenuItem.Image")));
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.rolesToolStripMenuItem.Text = "Roles";
            // 
            // moyenPaiementsToolStripMenuItem
            // 
            this.moyenPaiementsToolStripMenuItem.Name = "moyenPaiementsToolStripMenuItem";
            this.moyenPaiementsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.moyenPaiementsToolStripMenuItem.Text = "Moyen Paiements";
            // 
            // moyenPaimentsToolStripMenuItem
            // 
            this.moyenPaimentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("moyenPaimentsToolStripMenuItem.Image")));
            this.moyenPaimentsToolStripMenuItem.Name = "moyenPaimentsToolStripMenuItem";
            this.moyenPaimentsToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.moyenPaimentsToolStripMenuItem.Text = "Moyen Paiments";
            // 
            // paiementsToolStripMenuItem
            // 
            this.paiementsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("paiementsToolStripMenuItem.Image")));
            this.paiementsToolStripMenuItem.Name = "paiementsToolStripMenuItem";
            this.paiementsToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.paiementsToolStripMenuItem.Text = "Paiements";
            // 
            // groupeSanguinsToolStripMenuItem
            // 
            this.groupeSanguinsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("groupeSanguinsToolStripMenuItem.Image")));
            this.groupeSanguinsToolStripMenuItem.Name = "groupeSanguinsToolStripMenuItem";
            this.groupeSanguinsToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.groupeSanguinsToolStripMenuItem.Text = "Groupe Sanguins";
            // 
            // agendasToolStripMenuItem
            // 
            this.agendasToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.istockphoto_1278801008_612x612;
            this.agendasToolStripMenuItem.Name = "agendasToolStripMenuItem";
            this.agendasToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.agendasToolStripMenuItem.Text = "Agendas";
            // 
            // creeneauxToolStripMenuItem
            // 
            this.creeneauxToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("creeneauxToolStripMenuItem.Image")));
            this.creeneauxToolStripMenuItem.Name = "creeneauxToolStripMenuItem";
            this.creeneauxToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.creeneauxToolStripMenuItem.Text = "Creneaux";
            // 
            // groupeSanguinsToolStripMenuItem1
            // 
            this.groupeSanguinsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("groupeSanguinsToolStripMenuItem1.Image")));
            this.groupeSanguinsToolStripMenuItem1.Name = "groupeSanguinsToolStripMenuItem1";
            this.groupeSanguinsToolStripMenuItem1.Size = new System.Drawing.Size(188, 30);
            this.groupeSanguinsToolStripMenuItem1.Text = "Groupe Sanguins";
            // 
            // moyenPaimentsToolStripMenuItem1
            // 
            this.moyenPaimentsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("moyenPaimentsToolStripMenuItem1.Image")));
            this.moyenPaimentsToolStripMenuItem1.Name = "moyenPaimentsToolStripMenuItem1";
            this.moyenPaimentsToolStripMenuItem1.Size = new System.Drawing.Size(188, 30);
            this.moyenPaimentsToolStripMenuItem1.Text = "Moyen Paiements";
            // 
            // paiementsToolStripMenuItem1
            // 
            this.paiementsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("paiementsToolStripMenuItem1.Image")));
            this.paiementsToolStripMenuItem1.Name = "paiementsToolStripMenuItem1";
            this.paiementsToolStripMenuItem1.Size = new System.Drawing.Size(188, 30);
            this.paiementsToolStripMenuItem1.Text = "Paiements";
            // 
            // rendezVousToolStripMenuItem3
            // 
            this.rendezVousToolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("rendezVousToolStripMenuItem3.Image")));
            this.rendezVousToolStripMenuItem3.Name = "rendezVousToolStripMenuItem3";
            this.rendezVousToolStripMenuItem3.Size = new System.Drawing.Size(188, 30);
            this.rendezVousToolStripMenuItem3.Text = "Rendez-Vous";
            // 
            // rolesToolStripMenuItem1
            // 
            this.rolesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("rolesToolStripMenuItem1.Image")));
            this.rolesToolStripMenuItem1.Name = "rolesToolStripMenuItem1";
            this.rolesToolStripMenuItem1.Size = new System.Drawing.Size(188, 30);
            this.rolesToolStripMenuItem1.Text = "Roles";
            // 
            // soinsToolStripMenuItem2
            // 
            this.soinsToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("soinsToolStripMenuItem2.Image")));
            this.soinsToolStripMenuItem2.Name = "soinsToolStripMenuItem2";
            this.soinsToolStripMenuItem2.Size = new System.Drawing.Size(188, 30);
            this.soinsToolStripMenuItem2.Text = "Soins";
            // 
            // spécialitésToolStripMenuItem
            // 
            this.spécialitésToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("spécialitésToolStripMenuItem.Image")));
            this.spécialitésToolStripMenuItem.Name = "spécialitésToolStripMenuItem";
            this.spécialitésToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.spécialitésToolStripMenuItem.Text = "Spécialités";
            // 
            // utilisateursToolStripMenuItem
            // 
            this.utilisateursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminsToolStripMenuItem1,
            this.medecinsToolStripMenuItem1,
            this.secrétairesToolStripMenuItem,
            this.patientsToolStripMenuItem2});
            this.utilisateursToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("utilisateursToolStripMenuItem.Image")));
            this.utilisateursToolStripMenuItem.Name = "utilisateursToolStripMenuItem";
            this.utilisateursToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.utilisateursToolStripMenuItem.Text = "Personnes";
            // 
            // adminsToolStripMenuItem1
            // 
            this.adminsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("adminsToolStripMenuItem1.Image")));
            this.adminsToolStripMenuItem1.Name = "adminsToolStripMenuItem1";
            this.adminsToolStripMenuItem1.Size = new System.Drawing.Size(188, 30);
            this.adminsToolStripMenuItem1.Text = "Admins";
            // 
            // medecinsToolStripMenuItem1
            // 
            this.medecinsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("medecinsToolStripMenuItem1.Image")));
            this.medecinsToolStripMenuItem1.Name = "medecinsToolStripMenuItem1";
            this.medecinsToolStripMenuItem1.Size = new System.Drawing.Size(188, 30);
            this.medecinsToolStripMenuItem1.Text = "Medecins";
            // 
            // secrétairesToolStripMenuItem
            // 
            this.secrétairesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("secrétairesToolStripMenuItem.Image")));
            this.secrétairesToolStripMenuItem.Name = "secrétairesToolStripMenuItem";
            this.secrétairesToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.secrétairesToolStripMenuItem.Text = "Secrétaires";
            // 
            // patientsToolStripMenuItem2
            // 
            this.patientsToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("patientsToolStripMenuItem2.Image")));
            this.patientsToolStripMenuItem2.Name = "patientsToolStripMenuItem2";
            this.patientsToolStripMenuItem2.Size = new System.Drawing.Size(188, 30);
            this.patientsToolStripMenuItem2.Text = "Patients";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.abstract_health_medical_science_healthcare_icon_digital_technology_science_concept_modern_innovation_treatment_medicine_on_hi_tech_future_blue_background_for_wallpaper_template_web_design_vec;
            this.ClientSize = new System.Drawing.Size(812, 652);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMDI";
            this.Text = "Gestion Rendez Vous";
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripRechercher;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripDropDownButton btnRendezVous;
        private System.Windows.Forms.ToolStripMenuItem rendezVousToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton btnAjouter;
        private System.Windows.Forms.ToolStripMenuItem parientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docteursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rendezToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton btnModifier;
        private System.Windows.Forms.ToolStripMenuItem patientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docteursToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rendezVousToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator side2;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.ToolStripMenuItem assistantMedecinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assistantMedecinToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem assistantMedecinToolStripMenuItem2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownApi;
        private System.Windows.Forms.ToolStripMenuItem withPhpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rendezVousToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem agendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withApiRvMedicalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creneauxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialitéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soinsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem adminsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medecinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assistantMedecinToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem patientsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moyenPaiementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupeSanguinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moyenPaimentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paiementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creeneauxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupeSanguinsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moyenPaimentsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem paiementsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rendezVousToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem soinsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem spécialitésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilisateursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem medecinsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem secrétairesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientsToolStripMenuItem2;
    }
}

