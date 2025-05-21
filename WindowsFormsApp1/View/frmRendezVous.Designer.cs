namespace WindowsFormsApp1.View
{
    partial class frmRendezVous
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNomPrenom = new System.Windows.Forms.Label();
            this.txtNomPrenom = new System.Windows.Forms.TextBox();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.lblAdresse = new System.Windows.Forms.Label();
            this.cbbGroupeSanguin = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPoids = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPoids = new System.Windows.Forms.TextBox();
            this.lblGroupeeSanguin = new System.Windows.Forms.Label();
            this.lblTaille = new System.Windows.Forms.Label();
            this.txtTaille = new System.Windows.Forms.TextBox();
            this.cbbTelephone = new System.Windows.Forms.ComboBox();
            this.btnRenitialiser = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoin = new System.Windows.Forms.TextBox();
            this.lblSoin = new System.Windows.Forms.Label();
            this.cbbSoins = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbMedecin = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbCreneauHoraire = new System.Windows.Forms.ComboBox();
            this.cbbDureeCreneaux = new System.Windows.Forms.ComboBox();
            this.dtRendezVous = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnImpression = new System.Windows.Forms.Button();
            this.pnlimpression = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlimpression.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblNomPrenom);
            this.panel1.Controls.Add(this.txtNomPrenom);
            this.panel1.Controls.Add(this.txtAdresse);
            this.panel1.Controls.Add(this.lblAdresse);
            this.panel1.Controls.Add(this.cbbGroupeSanguin);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.lblPoids);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.txtPoids);
            this.panel1.Controls.Add(this.lblGroupeeSanguin);
            this.panel1.Controls.Add(this.lblTaille);
            this.panel1.Controls.Add(this.txtTaille);
            this.panel1.Controls.Add(this.cbbTelephone);
            this.panel1.Controls.Add(this.btnRenitialiser);
            this.panel1.Controls.Add(this.btnValider);
            this.panel1.Location = new System.Drawing.Point(35, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 572);
            this.panel1.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 82;
            this.label3.Text = "Telephone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 18);
            this.label2.TabIndex = 81;
            this.label2.Text = "Informations Patient";
            // 
            // lblNomPrenom
            // 
            this.lblNomPrenom.AutoSize = true;
            this.lblNomPrenom.Location = new System.Drawing.Point(13, 104);
            this.lblNomPrenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomPrenom.Name = "lblNomPrenom";
            this.lblNomPrenom.Size = new System.Drawing.Size(86, 16);
            this.lblNomPrenom.TabIndex = 80;
            this.lblNomPrenom.Text = "Nom Prenom";
            // 
            // txtNomPrenom
            // 
            this.txtNomPrenom.Location = new System.Drawing.Point(16, 124);
            this.txtNomPrenom.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomPrenom.Name = "txtNomPrenom";
            this.txtNomPrenom.Size = new System.Drawing.Size(309, 22);
            this.txtNomPrenom.TabIndex = 2;
            // 
            // txtAdresse
            // 
            this.txtAdresse.Location = new System.Drawing.Point(13, 251);
            this.txtAdresse.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(309, 22);
            this.txtAdresse.TabIndex = 4;
            // 
            // lblAdresse
            // 
            this.lblAdresse.AutoSize = true;
            this.lblAdresse.Location = new System.Drawing.Point(13, 224);
            this.lblAdresse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(58, 16);
            this.lblAdresse.TabIndex = 74;
            this.lblAdresse.Text = "Adresse";
            // 
            // cbbGroupeSanguin
            // 
            this.cbbGroupeSanguin.FormattingEnabled = true;
            this.cbbGroupeSanguin.Location = new System.Drawing.Point(13, 311);
            this.cbbGroupeSanguin.Margin = new System.Windows.Forms.Padding(4);
            this.cbbGroupeSanguin.Name = "cbbGroupeSanguin";
            this.cbbGroupeSanguin.Size = new System.Drawing.Size(309, 24);
            this.cbbGroupeSanguin.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(13, 191);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(309, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // lblPoids
            // 
            this.lblPoids.AutoSize = true;
            this.lblPoids.Location = new System.Drawing.Point(13, 406);
            this.lblPoids.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPoids.Name = "lblPoids";
            this.lblPoids.Size = new System.Drawing.Size(42, 16);
            this.lblPoids.TabIndex = 78;
            this.lblPoids.Text = "Poids";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(13, 164);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 75;
            this.lblEmail.Text = "Email";
            // 
            // txtPoids
            // 
            this.txtPoids.Location = new System.Drawing.Point(13, 433);
            this.txtPoids.Margin = new System.Windows.Forms.Padding(4);
            this.txtPoids.Name = "txtPoids";
            this.txtPoids.Size = new System.Drawing.Size(309, 22);
            this.txtPoids.TabIndex = 7;
            // 
            // lblGroupeeSanguin
            // 
            this.lblGroupeeSanguin.AutoSize = true;
            this.lblGroupeeSanguin.Location = new System.Drawing.Point(13, 284);
            this.lblGroupeeSanguin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupeeSanguin.Name = "lblGroupeeSanguin";
            this.lblGroupeeSanguin.Size = new System.Drawing.Size(104, 16);
            this.lblGroupeeSanguin.TabIndex = 76;
            this.lblGroupeeSanguin.Text = "Groupe Sanguin";
            // 
            // lblTaille
            // 
            this.lblTaille.AutoSize = true;
            this.lblTaille.Location = new System.Drawing.Point(13, 346);
            this.lblTaille.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaille.Name = "lblTaille";
            this.lblTaille.Size = new System.Drawing.Size(41, 16);
            this.lblTaille.TabIndex = 77;
            this.lblTaille.Text = "Taille";
            // 
            // txtTaille
            // 
            this.txtTaille.Location = new System.Drawing.Point(13, 373);
            this.txtTaille.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaille.Name = "txtTaille";
            this.txtTaille.Size = new System.Drawing.Size(309, 22);
            this.txtTaille.TabIndex = 6;
            // 
            // cbbTelephone
            // 
            this.cbbTelephone.FormattingEnabled = true;
            this.cbbTelephone.Location = new System.Drawing.Point(16, 69);
            this.cbbTelephone.Name = "cbbTelephone";
            this.cbbTelephone.Size = new System.Drawing.Size(309, 24);
            this.cbbTelephone.TabIndex = 1;
            this.cbbTelephone.TextChanged += new System.EventHandler(this.cbbTelephone_TextChanged);
            this.cbbTelephone.Leave += new System.EventHandler(this.cbbTelephone_Leave);
            // 
            // btnRenitialiser
            // 
            this.btnRenitialiser.BackColor = System.Drawing.Color.Red;
            this.btnRenitialiser.Location = new System.Drawing.Point(183, 519);
            this.btnRenitialiser.Name = "btnRenitialiser";
            this.btnRenitialiser.Size = new System.Drawing.Size(112, 32);
            this.btnRenitialiser.TabIndex = 9;
            this.btnRenitialiser.Text = "&Renitialiser";
            this.btnRenitialiser.UseVisualStyleBackColor = false;
            this.btnRenitialiser.Click += new System.EventHandler(this.btnRenitialiser_Click);
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.Lime;
            this.btnValider.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnValider.Location = new System.Drawing.Point(38, 519);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(112, 32);
            this.btnValider.TabIndex = 8;
            this.btnValider.Text = "&Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtSoin);
            this.panel2.Controls.Add(this.lblSoin);
            this.panel2.Controls.Add(this.cbbSoins);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbbMedecin);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbbCreneauHoraire);
            this.panel2.Controls.Add(this.cbbDureeCreneaux);
            this.panel2.Controls.Add(this.dtRendezVous);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(478, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 572);
            this.panel2.TabIndex = 83;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 291);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 90;
            this.label8.Text = "Prix";
            // 
            // txtSoin
            // 
            this.txtSoin.Location = new System.Drawing.Point(16, 311);
            this.txtSoin.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoin.Name = "txtSoin";
            this.txtSoin.Size = new System.Drawing.Size(233, 22);
            this.txtSoin.TabIndex = 83;
            this.txtSoin.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblSoin
            // 
            this.lblSoin.AutoSize = true;
            this.lblSoin.Location = new System.Drawing.Point(13, 231);
            this.lblSoin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoin.Name = "lblSoin";
            this.lblSoin.Size = new System.Drawing.Size(34, 16);
            this.lblSoin.TabIndex = 89;
            this.lblSoin.Text = "Soin";
            // 
            // cbbSoins
            // 
            this.cbbSoins.FormattingEnabled = true;
            this.cbbSoins.Location = new System.Drawing.Point(13, 251);
            this.cbbSoins.Margin = new System.Windows.Forms.Padding(4);
            this.cbbSoins.Name = "cbbSoins";
            this.cbbSoins.Size = new System.Drawing.Size(236, 24);
            this.cbbSoins.TabIndex = 88;
            this.cbbSoins.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 351);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 87;
            this.label7.Text = "Medecin";
            // 
            // cbbMedecin
            // 
            this.cbbMedecin.FormattingEnabled = true;
            this.cbbMedecin.Location = new System.Drawing.Point(13, 371);
            this.cbbMedecin.Margin = new System.Windows.Forms.Padding(4);
            this.cbbMedecin.Name = "cbbMedecin";
            this.cbbMedecin.Size = new System.Drawing.Size(236, 24);
            this.cbbMedecin.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 164);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 16);
            this.label6.TabIndex = 85;
            this.label6.Text = "Créneau Horaire";
            // 
            // cbbCreneauHoraire
            // 
            this.cbbCreneauHoraire.FormattingEnabled = true;
            this.cbbCreneauHoraire.Location = new System.Drawing.Point(13, 184);
            this.cbbCreneauHoraire.Margin = new System.Windows.Forms.Padding(4);
            this.cbbCreneauHoraire.Name = "cbbCreneauHoraire";
            this.cbbCreneauHoraire.Size = new System.Drawing.Size(236, 24);
            this.cbbCreneauHoraire.TabIndex = 84;
            // 
            // cbbDureeCreneaux
            // 
            this.cbbDureeCreneaux.FormattingEnabled = true;
            this.cbbDureeCreneaux.Location = new System.Drawing.Point(13, 133);
            this.cbbDureeCreneaux.Margin = new System.Windows.Forms.Padding(4);
            this.cbbDureeCreneaux.Name = "cbbDureeCreneaux";
            this.cbbDureeCreneaux.Size = new System.Drawing.Size(236, 24);
            this.cbbDureeCreneaux.TabIndex = 83;
            // 
            // dtRendezVous
            // 
            this.dtRendezVous.Location = new System.Drawing.Point(13, 71);
            this.dtRendezVous.Name = "dtRendezVous";
            this.dtRendezVous.Size = new System.Drawing.Size(236, 22);
            this.dtRendezVous.TabIndex = 83;
            this.dtRendezVous.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 82;
            this.label1.Text = "Date Rendez-Vous";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 18);
            this.label4.TabIndex = 81;
            this.label4.Text = "Informations Rendez Vous";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "Durée Créneau";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(183, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "&Renitialiser";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lime;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(38, 519);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 32);
            this.button2.TabIndex = 8;
            this.button2.Text = "&Valider";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnImpression
            // 
            this.btnImpression.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnImpression.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImpression.Location = new System.Drawing.Point(25, 42);
            this.btnImpression.Name = "btnImpression";
            this.btnImpression.Size = new System.Drawing.Size(152, 32);
            this.btnImpression.TabIndex = 91;
            this.btnImpression.Text = "&Impression";
            this.btnImpression.UseVisualStyleBackColor = false;
            this.btnImpression.Click += new System.EventHandler(this.btnImpression_Click);
            // 
            // pnlimpression
            // 
            this.pnlimpression.Controls.Add(this.label9);
            this.pnlimpression.Controls.Add(this.btnImpression);
            this.pnlimpression.Location = new System.Drawing.Point(904, 22);
            this.pnlimpression.Name = "pnlimpression";
            this.pnlimpression.Size = new System.Drawing.Size(200, 100);
            this.pnlimpression.TabIndex = 92;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 18);
            this.label9.TabIndex = 91;
            this.label9.Text = "Impression";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmRendezVous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.abstract_health_medical_science_healthcare_icon_digital_technology_science_concept_modern_innovation_treatment_medicine_on_hi_tech_future_blue_background_for_wallpaper_template_web_design_vec;
            this.ClientSize = new System.Drawing.Size(1278, 671);
            this.ControlBox = false;
            this.Controls.Add(this.pnlimpression);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRendezVous";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmPatients";
            this.Load += new System.EventHandler(this.frmRendezVous_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlimpression.ResumeLayout(false);
            this.pnlimpression.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnRenitialiser;
        private System.Windows.Forms.ComboBox cbbTelephone;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Label lblAdresse;
        private System.Windows.Forms.ComboBox cbbGroupeSanguin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPoids;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPoids;
        private System.Windows.Forms.Label lblGroupeeSanguin;
        private System.Windows.Forms.Label lblTaille;
        private System.Windows.Forms.TextBox txtTaille;
        private System.Windows.Forms.Label lblNomPrenom;
        private System.Windows.Forms.TextBox txtNomPrenom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtRendezVous;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDureeCreneaux;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbCreneauHoraire;
        private System.Windows.Forms.Label lblSoin;
        private System.Windows.Forms.ComboBox cbbSoins;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbMedecin;
        private System.Windows.Forms.TextBox txtSoin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnImpression;
        private System.Windows.Forms.Panel pnlimpression;
        private System.Windows.Forms.Label label9;
    }
}