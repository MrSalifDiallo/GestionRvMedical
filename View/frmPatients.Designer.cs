namespace WindowsFormsApp1.View
{
    partial class frmPatients
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
            this.cbbGroupeSanguin = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPoids = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTaille = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomPrenom = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.btnRenitialiser = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.lblDateNaissance = new System.Windows.Forms.Label();
            this.dtDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbGroupeSanguin
            // 
            this.cbbGroupeSanguin.FormattingEnabled = true;
            this.cbbGroupeSanguin.Location = new System.Drawing.Point(13, 242);
            this.cbbGroupeSanguin.Margin = new System.Windows.Forms.Padding(4);
            this.cbbGroupeSanguin.Name = "cbbGroupeSanguin";
            this.cbbGroupeSanguin.Size = new System.Drawing.Size(309, 24);
            this.cbbGroupeSanguin.TabIndex = 4;
            this.cbbGroupeSanguin.SelectedIndexChanged += new System.EventHandler(this.grpSanguin_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 334);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 67;
            this.label8.Text = "Poids";
            // 
            // txtPoids
            // 
            this.txtPoids.Location = new System.Drawing.Point(13, 360);
            this.txtPoids.Margin = new System.Windows.Forms.Padding(4);
            this.txtPoids.Name = "txtPoids";
            this.txtPoids.Size = new System.Drawing.Size(309, 22);
            this.txtPoids.TabIndex = 6;
            this.txtPoids.TextChanged += new System.EventHandler(this.txtPoids_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 276);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 65;
            this.label7.Text = "Taille";
            // 
            // txtTaille
            // 
            this.txtTaille.Location = new System.Drawing.Point(13, 302);
            this.txtTaille.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaille.Name = "txtTaille";
            this.txtTaille.Size = new System.Drawing.Size(309, 22);
            this.txtTaille.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 216);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 63;
            this.label6.Text = "Groupe Sanguin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 62;
            this.label5.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(13, 126);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(309, 22);
            this.txtEmail.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Adresse";
            // 
            // txtAdresse
            // 
            this.txtAdresse.Location = new System.Drawing.Point(13, 184);
            this.txtAdresse.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(309, 22);
            this.txtAdresse.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 58;
            this.label2.Text = "Ajout Patient";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 57;
            this.label3.Text = "Nom Prenom";
            // 
            // txtNomPrenom
            // 
            this.txtNomPrenom.Location = new System.Drawing.Point(13, 68);
            this.txtNomPrenom.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomPrenom.Name = "txtNomPrenom";
            this.txtNomPrenom.Size = new System.Drawing.Size(309, 22);
            this.txtNomPrenom.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtDateNaissance);
            this.panel1.Controls.Add(this.lblDateNaissance);
            this.panel1.Controls.Add(this.lblTelephone);
            this.panel1.Controls.Add(this.txtTelephone);
            this.panel1.Controls.Add(this.btnRenitialiser);
            this.panel1.Controls.Add(this.btnValider);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNomPrenom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAdresse);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbbGroupeSanguin);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPoids);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtTaille);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 572);
            this.panel1.TabIndex = 72;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(13, 450);
            this.lblTelephone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(73, 16);
            this.lblTelephone.TabIndex = 74;
            this.lblTelephone.Text = "Telephone";
            this.lblTelephone.Click += new System.EventHandler(this.lblTelephone_Click);
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(13, 476);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(309, 22);
            this.txtTelephone.TabIndex = 7;
            // 
            // btnRenitialiser
            // 
            this.btnRenitialiser.BackColor = System.Drawing.Color.Red;
            this.btnRenitialiser.Location = new System.Drawing.Point(183, 518);
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
            this.btnValider.Location = new System.Drawing.Point(26, 518);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(112, 32);
            this.btnValider.TabIndex = 8;
            this.btnValider.Text = "&Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // lblDateNaissance
            // 
            this.lblDateNaissance.AutoSize = true;
            this.lblDateNaissance.Location = new System.Drawing.Point(13, 392);
            this.lblDateNaissance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateNaissance.Name = "lblDateNaissance";
            this.lblDateNaissance.Size = new System.Drawing.Size(104, 16);
            this.lblDateNaissance.TabIndex = 76;
            this.lblDateNaissance.Text = "Date Naissance";
            // 
            // dtDateNaissance
            // 
            this.dtDateNaissance.Location = new System.Drawing.Point(13, 418);
            this.dtDateNaissance.Name = "dtDateNaissance";
            this.dtDateNaissance.Size = new System.Drawing.Size(309, 22);
            this.dtDateNaissance.TabIndex = 77;
            // 
            // frmPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.abstract_health_medical_science_healthcare_icon_digital_technology_science_concept_modern_innovation_treatment_medicine_on_hi_tech_future_blue_background_for_wallpaper_template_web_design_vec;
            this.ClientSize = new System.Drawing.Size(1137, 671);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPatients";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmPatients";
            this.Load += new System.EventHandler(this.frmPatients_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbbGroupeSanguin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPoids;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTaille;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomPrenom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnRenitialiser;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblDateNaissance;
        private System.Windows.Forms.DateTimePicker dtDateNaissance;
    }
}