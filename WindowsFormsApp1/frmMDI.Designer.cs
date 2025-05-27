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
            this.btnModifier = new System.Windows.Forms.ToolStripDropDownButton();
            this.patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docteursToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rendezVousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.side2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRechercher = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRendezVous = new System.Windows.Forms.ToolStripDropDownButton();
            this.rendezVousToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.lblUserBienvenue = new System.Windows.Forms.Label();
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
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1082, 31);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btnAjouter
            // 
            this.btnAjouter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parientsToolStripMenuItem,
            this.docteursToolStripMenuItem,
            this.rendezToolStripMenuItem});
            this.btnAjouter.Image = ((System.Drawing.Image)(resources.GetObject("btnAjouter.Image")));
            this.btnAjouter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(96, 28);
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // parientsToolStripMenuItem
            // 
            this.parientsToolStripMenuItem.Name = "parientsToolStripMenuItem";
            this.parientsToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.parientsToolStripMenuItem.Text = "Patient";
            this.parientsToolStripMenuItem.Click += new System.EventHandler(this.patientsToolStripMenuItem_Click);
            // 
            // docteursToolStripMenuItem
            // 
            this.docteursToolStripMenuItem.Name = "docteursToolStripMenuItem";
            this.docteursToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.docteursToolStripMenuItem.Text = "Medecin";
            this.docteursToolStripMenuItem.Click += new System.EventHandler(this.docteursToolStripMenuItem_Click);
            // 
            // rendezToolStripMenuItem
            // 
            this.rendezToolStripMenuItem.Name = "rendezToolStripMenuItem";
            this.rendezToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.rendezToolStripMenuItem.Text = "Rendez-Vous";
            this.rendezToolStripMenuItem.Click += new System.EventHandler(this.rendezToolStripMenuItem_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientsToolStripMenuItem,
            this.docteursToolStripMenuItem1,
            this.rendezVousToolStripMenuItem});
            this.btnModifier.Image = ((System.Drawing.Image)(resources.GetObject("btnModifier.Image")));
            this.btnModifier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(104, 28);
            this.btnModifier.Text = "&Modifier";
            this.btnModifier.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.patientsToolStripMenuItem.Text = "Patient";
            // 
            // docteursToolStripMenuItem1
            // 
            this.docteursToolStripMenuItem1.Name = "docteursToolStripMenuItem1";
            this.docteursToolStripMenuItem1.Size = new System.Drawing.Size(178, 26);
            this.docteursToolStripMenuItem1.Text = "Medecin";
            // 
            // rendezVousToolStripMenuItem
            // 
            this.rendezVousToolStripMenuItem.Name = "rendezVousToolStripMenuItem";
            this.rendezVousToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.rendezVousToolStripMenuItem.Text = "Rendez-Vous";
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
            this.toolStripMenuItem3});
            this.toolStripRechercher.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRechercher.Image")));
            this.toolStripRechercher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRechercher.Name = "toolStripRechercher";
            this.toolStripRechercher.Size = new System.Drawing.Size(120, 28);
            this.toolStripRechercher.Text = "&Rechercher";
            this.toolStripRechercher.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 26);
            this.toolStripMenuItem1.Text = "Patients";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 26);
            this.toolStripMenuItem2.Text = "Docteurs";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(178, 26);
            this.toolStripMenuItem3.Text = "Rendez-Vous";
            // 
            // btnRendezVous
            // 
            this.btnRendezVous.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rendezVousToolStripMenuItem1});
            this.btnRendezVous.Image = global::WindowsFormsApp1.Properties.Resources.istockphoto_1278801008_612x612;
            this.btnRendezVous.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRendezVous.Name = "btnRendezVous";
            this.btnRendezVous.Size = new System.Drawing.Size(99, 28);
            this.btnRendezVous.Text = "&Agenda";
            this.btnRendezVous.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // rendezVousToolStripMenuItem1
            // 
            this.rendezVousToolStripMenuItem1.Name = "rendezVousToolStripMenuItem1";
            this.rendezVousToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.rendezVousToolStripMenuItem1.Text = "Rendez-Vous";
            this.rendezVousToolStripMenuItem1.Click += new System.EventHandler(this.rendezVousToolStripMenuItem1_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(87, 28);
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
            // lblUserBienvenue
            // 
            this.lblUserBienvenue.AutoEllipsis = true;
            this.lblUserBienvenue.Location = new System.Drawing.Point(12, 53);
            this.lblUserBienvenue.Name = "lblUserBienvenue";
            this.lblUserBienvenue.Size = new System.Drawing.Size(156, 47);
            this.lblUserBienvenue.TabIndex = 32;
            this.lblUserBienvenue.Text = "Bienvenue";
            this.lblUserBienvenue.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.abstract_health_medical_science_healthcare_icon_digital_technology_science_concept_modern_innovation_treatment_medicine_on_hi_tech_future_blue_background_for_wallpaper_template_web_design_vec;
            this.ClientSize = new System.Drawing.Size(1082, 803);
            this.ControlBox = false;
            this.Controls.Add(this.lblUserBienvenue);
            this.Controls.Add(this.toolStrip1);
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
        private System.Windows.Forms.Label lblUserBienvenue;
    }
}

