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
            this.components = new System.ComponentModel.Container();
            this.pnlRv = new System.Windows.Forms.Panel();
            this.pnlListeCreneau = new System.Windows.Forms.Panel();
            this.lblTabMessage = new System.Windows.Forms.Label();
            this.lblMessageCreneaux = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pnlActionPaiement = new System.Windows.Forms.Panel();
            this.pnlPaiement = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnPrevisualisez = new Guna.UI2.WinForms.Guna2Button();
            this.btnValidezRv = new Guna.UI2.WinForms.Guna2Button();
            this.label17 = new System.Windows.Forms.Label();
            this.pnlAllImpression = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.pnlimpression = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.pnlDetailsRv = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtRendezVous = new System.Windows.Forms.DateTimePicker();
            this.txtSoin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSoin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbSoins = new System.Windows.Forms.ComboBox();
            this.cbbDureeCreneaux = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbCreneauHoraire = new System.Windows.Forms.ComboBox();
            this.cbbMedecin = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPatient = new System.Windows.Forms.Panel();
            this.dtDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.lblDateNaissance = new System.Windows.Forms.Label();
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.pnlRv.SuspendLayout();
            this.pnlListeCreneau.SuspendLayout();
            this.pnlActionPaiement.SuspendLayout();
            this.pnlPaiement.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.pnlAllImpression.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlimpression.SuspendLayout();
            this.pnlDetailsRv.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlPatient.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRv
            // 
            this.pnlRv.AutoSize = true;
            this.pnlRv.BackColor = System.Drawing.Color.Gray;
            this.pnlRv.Controls.Add(this.pnlListeCreneau);
            this.pnlRv.Controls.Add(this.pnlActionPaiement);
            this.pnlRv.Controls.Add(this.pnlAllImpression);
            this.pnlRv.Controls.Add(this.pnlDetailsRv);
            this.pnlRv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRv.Location = new System.Drawing.Point(312, 2);
            this.pnlRv.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRv.Name = "pnlRv";
            this.pnlRv.Size = new System.Drawing.Size(828, 507);
            this.pnlRv.TabIndex = 94;
            // 
            // pnlListeCreneau
            // 
            this.pnlListeCreneau.AutoSize = true;
            this.pnlListeCreneau.BackColor = System.Drawing.Color.Transparent;
            this.pnlListeCreneau.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlListeCreneau.CausesValidation = false;
            this.pnlListeCreneau.Controls.Add(this.lblTabMessage);
            this.pnlListeCreneau.Controls.Add(this.lblMessageCreneaux);
            this.pnlListeCreneau.Controls.Add(this.listView1);
            this.pnlListeCreneau.Location = new System.Drawing.Point(5, 216);
            this.pnlListeCreneau.Margin = new System.Windows.Forms.Padding(2);
            this.pnlListeCreneau.Name = "pnlListeCreneau";
            this.pnlListeCreneau.Size = new System.Drawing.Size(426, 272);
            this.pnlListeCreneau.TabIndex = 96;
            // 
            // lblTabMessage
            // 
            this.lblTabMessage.AutoSize = true;
            this.lblTabMessage.BackColor = System.Drawing.Color.White;
            this.lblTabMessage.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabMessage.Location = new System.Drawing.Point(27, 115);
            this.lblTabMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTabMessage.Name = "lblTabMessage";
            this.lblTabMessage.Size = new System.Drawing.Size(0, 21);
            this.lblTabMessage.TabIndex = 97;
            // 
            // lblMessageCreneaux
            // 
            this.lblMessageCreneaux.AutoSize = true;
            this.lblMessageCreneaux.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageCreneaux.Location = new System.Drawing.Point(2, 4);
            this.lblMessageCreneaux.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessageCreneaux.Name = "lblMessageCreneaux";
            this.lblMessageCreneaux.Size = new System.Drawing.Size(0, 21);
            this.lblMessageCreneaux.TabIndex = 91;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(-2, 30);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(422, 236);
            this.listView1.TabIndex = 96;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // pnlActionPaiement
            // 
            this.pnlActionPaiement.AutoSize = true;
            this.pnlActionPaiement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlActionPaiement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlActionPaiement.Controls.Add(this.pnlPaiement);
            this.pnlActionPaiement.Controls.Add(this.pnlAction);
            this.pnlActionPaiement.Location = new System.Drawing.Point(481, 216);
            this.pnlActionPaiement.Margin = new System.Windows.Forms.Padding(2);
            this.pnlActionPaiement.Name = "pnlActionPaiement";
            this.pnlActionPaiement.Size = new System.Drawing.Size(324, 268);
            this.pnlActionPaiement.TabIndex = 99;
            // 
            // pnlPaiement
            // 
            this.pnlPaiement.AutoSize = true;
            this.pnlPaiement.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlPaiement.Controls.Add(this.comboBox1);
            this.pnlPaiement.Controls.Add(this.label9);
            this.pnlPaiement.Controls.Add(this.label11);
            this.pnlPaiement.Location = new System.Drawing.Point(3, 3);
            this.pnlPaiement.Name = "pnlPaiement";
            this.pnlPaiement.Size = new System.Drawing.Size(251, 98);
            this.pnlPaiement.TabIndex = 98;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 21);
            this.comboBox1.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Selectionnez un mode paiement";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 15);
            this.label11.TabIndex = 30;
            this.label11.Text = "Mode de paiement";
            // 
            // pnlAction
            // 
            this.pnlAction.AutoSize = true;
            this.pnlAction.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlAction.Controls.Add(this.btnPrevisualisez);
            this.pnlAction.Controls.Add(this.btnValidezRv);
            this.pnlAction.Controls.Add(this.label17);
            this.pnlAction.Location = new System.Drawing.Point(3, 148);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(314, 90);
            this.pnlAction.TabIndex = 99;
            // 
            // btnPrevisualisez
            // 
            this.btnPrevisualisez.Animated = true;
            this.btnPrevisualisez.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevisualisez.BorderRadius = 7;
            this.btnPrevisualisez.BorderThickness = 3;
            this.btnPrevisualisez.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevisualisez.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevisualisez.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrevisualisez.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrevisualisez.FillColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPrevisualisez.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrevisualisez.ForeColor = System.Drawing.Color.Black;
            this.btnPrevisualisez.Location = new System.Drawing.Point(168, 51);
            this.btnPrevisualisez.Name = "btnPrevisualisez";
            this.btnPrevisualisez.Size = new System.Drawing.Size(134, 27);
            this.btnPrevisualisez.TabIndex = 30;
            this.btnPrevisualisez.Text = "Prévisualisez";
            this.btnPrevisualisez.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnValidezRv
            // 
            this.btnValidezRv.Animated = true;
            this.btnValidezRv.BackColor = System.Drawing.Color.Transparent;
            this.btnValidezRv.BorderRadius = 7;
            this.btnValidezRv.BorderThickness = 3;
            this.btnValidezRv.DefaultAutoSize = true;
            this.btnValidezRv.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnValidezRv.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnValidezRv.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnValidezRv.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnValidezRv.FillColor = System.Drawing.Color.Lime;
            this.btnValidezRv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnValidezRv.ForeColor = System.Drawing.Color.Black;
            this.btnValidezRv.Location = new System.Drawing.Point(3, 51);
            this.btnValidezRv.Name = "btnValidezRv";
            this.btnValidezRv.Size = new System.Drawing.Size(159, 27);
            this.btnValidezRv.TabIndex = 29;
            this.btnValidezRv.Text = "Valider le rendez-vous";
            this.btnValidezRv.Click += new System.EventHandler(this.btnValidezRv_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 15);
            this.label17.TabIndex = 26;
            this.label17.Text = "Centre d\'action";
            // 
            // pnlAllImpression
            // 
            this.pnlAllImpression.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlAllImpression.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAllImpression.Controls.Add(this.panel1);
            this.pnlAllImpression.Controls.Add(this.pnlimpression);
            this.pnlAllImpression.Location = new System.Drawing.Point(481, 8);
            this.pnlAllImpression.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAllImpression.Name = "pnlAllImpression";
            this.pnlAllImpression.Size = new System.Drawing.Size(324, 197);
            this.pnlAllImpression.TabIndex = 97;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.gunaLabel1);
            this.panel1.Location = new System.Drawing.Point(13, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 100);
            this.panel1.TabIndex = 100;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(3, 21);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(68, 15);
            this.gunaLabel1.TabIndex = 0;
            this.gunaLabel1.Text = "gunaLabel1";
            // 
            // pnlimpression
            // 
            this.pnlimpression.Controls.Add(this.label4);
            this.pnlimpression.Controls.Add(this.button3);
            this.pnlimpression.Location = new System.Drawing.Point(92, 59);
            this.pnlimpression.Margin = new System.Windows.Forms.Padding(2);
            this.pnlimpression.Name = "pnlimpression";
            this.pnlimpression.Size = new System.Drawing.Size(150, 81);
            this.pnlimpression.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 91;
            this.label4.Text = "Impression";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(19, 34);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 26);
            this.button3.TabIndex = 91;
            this.button3.Text = "&Impression";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnImpression_Click);
            // 
            // pnlDetailsRv
            // 
            this.pnlDetailsRv.AutoSize = true;
            this.pnlDetailsRv.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetailsRv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDetailsRv.CausesValidation = false;
            this.pnlDetailsRv.Controls.Add(this.label8);
            this.pnlDetailsRv.Controls.Add(this.label10);
            this.pnlDetailsRv.Controls.Add(this.dtRendezVous);
            this.pnlDetailsRv.Controls.Add(this.txtSoin);
            this.pnlDetailsRv.Controls.Add(this.label1);
            this.pnlDetailsRv.Controls.Add(this.label6);
            this.pnlDetailsRv.Controls.Add(this.lblSoin);
            this.pnlDetailsRv.Controls.Add(this.label5);
            this.pnlDetailsRv.Controls.Add(this.cbbSoins);
            this.pnlDetailsRv.Controls.Add(this.cbbDureeCreneaux);
            this.pnlDetailsRv.Controls.Add(this.label7);
            this.pnlDetailsRv.Controls.Add(this.cbbCreneauHoraire);
            this.pnlDetailsRv.Controls.Add(this.cbbMedecin);
            this.pnlDetailsRv.Location = new System.Drawing.Point(5, 4);
            this.pnlDetailsRv.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDetailsRv.Name = "pnlDetailsRv";
            this.pnlDetailsRv.Size = new System.Drawing.Size(422, 197);
            this.pnlDetailsRv.TabIndex = 95;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "Prix";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 2);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Détails Rendez-Vous";
            // 
            // dtRendezVous
            // 
            this.dtRendezVous.Location = new System.Drawing.Point(6, 52);
            this.dtRendezVous.Margin = new System.Windows.Forms.Padding(2);
            this.dtRendezVous.Name = "dtRendezVous";
            this.dtRendezVous.Size = new System.Drawing.Size(172, 20);
            this.dtRendezVous.TabIndex = 83;
            this.dtRendezVous.ValueChanged += new System.EventHandler(this.dtRendezVous_ValueChanged);
            // 
            // txtSoin
            // 
            this.txtSoin.Location = new System.Drawing.Point(224, 151);
            this.txtSoin.Name = "txtSoin";
            this.txtSoin.Size = new System.Drawing.Size(172, 20);
            this.txtSoin.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Date Rendez-Vous";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "Créneau Horaire";
            // 
            // lblSoin
            // 
            this.lblSoin.AutoSize = true;
            this.lblSoin.Location = new System.Drawing.Point(4, 133);
            this.lblSoin.Name = "lblSoin";
            this.lblSoin.Size = new System.Drawing.Size(28, 13);
            this.lblSoin.TabIndex = 89;
            this.lblSoin.Text = "Soin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "Durée Créneau";
            // 
            // cbbSoins
            // 
            this.cbbSoins.FormattingEnabled = true;
            this.cbbSoins.Location = new System.Drawing.Point(6, 150);
            this.cbbSoins.Name = "cbbSoins";
            this.cbbSoins.Size = new System.Drawing.Size(172, 21);
            this.cbbSoins.TabIndex = 88;
            this.cbbSoins.SelectedIndexChanged += new System.EventHandler(this.cbbSoins_SelectedIndexChanged);
            // 
            // cbbDureeCreneaux
            // 
            this.cbbDureeCreneaux.FormattingEnabled = true;
            this.cbbDureeCreneaux.Location = new System.Drawing.Point(224, 50);
            this.cbbDureeCreneaux.Name = "cbbDureeCreneaux";
            this.cbbDureeCreneaux.Size = new System.Drawing.Size(172, 21);
            this.cbbDureeCreneaux.TabIndex = 83;
            this.cbbDureeCreneaux.SelectedIndexChanged += new System.EventHandler(this.cbbDureeCreneaux_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Medecin";
            // 
            // cbbCreneauHoraire
            // 
            this.cbbCreneauHoraire.FormattingEnabled = true;
            this.cbbCreneauHoraire.Location = new System.Drawing.Point(224, 105);
            this.cbbCreneauHoraire.Name = "cbbCreneauHoraire";
            this.cbbCreneauHoraire.Size = new System.Drawing.Size(172, 21);
            this.cbbCreneauHoraire.TabIndex = 84;
            this.cbbCreneauHoraire.SelectedIndexChanged += new System.EventHandler(this.cbbCreneauHoraire_SelectedIndexChanged);
            // 
            // cbbMedecin
            // 
            this.cbbMedecin.FormattingEnabled = true;
            this.cbbMedecin.Location = new System.Drawing.Point(6, 105);
            this.cbbMedecin.Name = "cbbMedecin";
            this.cbbMedecin.Size = new System.Drawing.Size(172, 21);
            this.cbbMedecin.TabIndex = 86;
            this.cbbMedecin.SelectedIndexChanged += new System.EventHandler(this.cbbMedecin_SelectedIndexChanged);
            this.cbbMedecin.TextChanged += new System.EventHandler(this.cbbMedecin_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.19298F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.80701F));
            this.tableLayoutPanel1.Controls.Add(this.pnlPatient, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlRv, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1142, 511);
            this.tableLayoutPanel1.TabIndex = 95;
            // 
            // pnlPatient
            // 
            this.pnlPatient.AutoSize = true;
            this.pnlPatient.BackColor = System.Drawing.Color.Gray;
            this.pnlPatient.Controls.Add(this.dtDateNaissance);
            this.pnlPatient.Controls.Add(this.lblDateNaissance);
            this.pnlPatient.Controls.Add(this.label3);
            this.pnlPatient.Controls.Add(this.label2);
            this.pnlPatient.Controls.Add(this.lblNomPrenom);
            this.pnlPatient.Controls.Add(this.txtNomPrenom);
            this.pnlPatient.Controls.Add(this.txtAdresse);
            this.pnlPatient.Controls.Add(this.lblAdresse);
            this.pnlPatient.Controls.Add(this.cbbGroupeSanguin);
            this.pnlPatient.Controls.Add(this.txtEmail);
            this.pnlPatient.Controls.Add(this.lblPoids);
            this.pnlPatient.Controls.Add(this.lblEmail);
            this.pnlPatient.Controls.Add(this.txtPoids);
            this.pnlPatient.Controls.Add(this.lblGroupeeSanguin);
            this.pnlPatient.Controls.Add(this.lblTaille);
            this.pnlPatient.Controls.Add(this.txtTaille);
            this.pnlPatient.Controls.Add(this.cbbTelephone);
            this.pnlPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPatient.Location = new System.Drawing.Point(2, 2);
            this.pnlPatient.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Size = new System.Drawing.Size(306, 507);
            this.pnlPatient.TabIndex = 72;
            // 
            // dtDateNaissance
            // 
            this.dtDateNaissance.Location = new System.Drawing.Point(11, 196);
            this.dtDateNaissance.Margin = new System.Windows.Forms.Padding(2);
            this.dtDateNaissance.Name = "dtDateNaissance";
            this.dtDateNaissance.Size = new System.Drawing.Size(278, 20);
            this.dtDateNaissance.TabIndex = 84;
            // 
            // lblDateNaissance
            // 
            this.lblDateNaissance.AutoSize = true;
            this.lblDateNaissance.Location = new System.Drawing.Point(11, 168);
            this.lblDateNaissance.Name = "lblDateNaissance";
            this.lblDateNaissance.Size = new System.Drawing.Size(83, 13);
            this.lblDateNaissance.TabIndex = 83;
            this.lblDateNaissance.Text = "Date Naissance";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Telephone";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 23);
            this.label2.TabIndex = 81;
            this.label2.Text = "Informations Patient";
            // 
            // lblNomPrenom
            // 
            this.lblNomPrenom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNomPrenom.AutoSize = true;
            this.lblNomPrenom.Location = new System.Drawing.Point(11, 105);
            this.lblNomPrenom.Name = "lblNomPrenom";
            this.lblNomPrenom.Size = new System.Drawing.Size(68, 13);
            this.lblNomPrenom.TabIndex = 80;
            this.lblNomPrenom.Text = "Nom Prenom";
            // 
            // txtNomPrenom
            // 
            this.txtNomPrenom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNomPrenom.Location = new System.Drawing.Point(11, 133);
            this.txtNomPrenom.Name = "txtNomPrenom";
            this.txtNomPrenom.Size = new System.Drawing.Size(278, 20);
            this.txtNomPrenom.TabIndex = 2;
            // 
            // txtAdresse
            // 
            this.txtAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAdresse.Location = new System.Drawing.Point(11, 322);
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(278, 20);
            this.txtAdresse.TabIndex = 4;
            // 
            // lblAdresse
            // 
            this.lblAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdresse.AutoSize = true;
            this.lblAdresse.Location = new System.Drawing.Point(11, 294);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(45, 13);
            this.lblAdresse.TabIndex = 74;
            this.lblAdresse.Text = "Adresse";
            // 
            // cbbGroupeSanguin
            // 
            this.cbbGroupeSanguin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbbGroupeSanguin.FormattingEnabled = true;
            this.cbbGroupeSanguin.Location = new System.Drawing.Point(11, 385);
            this.cbbGroupeSanguin.Name = "cbbGroupeSanguin";
            this.cbbGroupeSanguin.Size = new System.Drawing.Size(278, 21);
            this.cbbGroupeSanguin.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(11, 259);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // lblPoids
            // 
            this.lblPoids.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoids.AutoSize = true;
            this.lblPoids.Location = new System.Drawing.Point(162, 431);
            this.lblPoids.Name = "lblPoids";
            this.lblPoids.Size = new System.Drawing.Size(33, 13);
            this.lblPoids.TabIndex = 78;
            this.lblPoids.Text = "Poids";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(11, 231);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 75;
            this.lblEmail.Text = "Email";
            // 
            // txtPoids
            // 
            this.txtPoids.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPoids.Location = new System.Drawing.Point(165, 447);
            this.txtPoids.Name = "txtPoids";
            this.txtPoids.Size = new System.Drawing.Size(126, 20);
            this.txtPoids.TabIndex = 7;
            // 
            // lblGroupeeSanguin
            // 
            this.lblGroupeeSanguin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGroupeeSanguin.AutoSize = true;
            this.lblGroupeeSanguin.Location = new System.Drawing.Point(11, 357);
            this.lblGroupeeSanguin.Name = "lblGroupeeSanguin";
            this.lblGroupeeSanguin.Size = new System.Drawing.Size(84, 13);
            this.lblGroupeeSanguin.TabIndex = 76;
            this.lblGroupeeSanguin.Text = "Groupe Sanguin";
            // 
            // lblTaille
            // 
            this.lblTaille.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTaille.AutoSize = true;
            this.lblTaille.Location = new System.Drawing.Point(12, 431);
            this.lblTaille.Name = "lblTaille";
            this.lblTaille.Size = new System.Drawing.Size(32, 13);
            this.lblTaille.TabIndex = 77;
            this.lblTaille.Text = "Taille";
            // 
            // txtTaille
            // 
            this.txtTaille.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTaille.Location = new System.Drawing.Point(12, 447);
            this.txtTaille.Name = "txtTaille";
            this.txtTaille.Size = new System.Drawing.Size(126, 20);
            this.txtTaille.TabIndex = 6;
            // 
            // cbbTelephone
            // 
            this.cbbTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbbTelephone.FormattingEnabled = true;
            this.cbbTelephone.Location = new System.Drawing.Point(11, 56);
            this.cbbTelephone.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTelephone.Name = "cbbTelephone";
            this.cbbTelephone.Size = new System.Drawing.Size(278, 21);
            this.cbbTelephone.TabIndex = 1;
            this.cbbTelephone.SelectionChangeCommitted += new System.EventHandler(this.cbbTelephone_SelectionChangeCommitted);
            this.cbbTelephone.TextChanged += new System.EventHandler(this.cbbTelephone_TextChanged);
            this.cbbTelephone.Leave += new System.EventHandler(this.cbbTelephone_Leave);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(8, 16, 8, 16);
            this.panel3.Size = new System.Drawing.Size(1160, 545);
            this.panel3.TabIndex = 94;
            // 
            // guna2HtmlToolTip1
            // 
            this.guna2HtmlToolTip1.AllowLinksHandling = true;
            this.guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gunaLabel2);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 100);
            this.panel2.TabIndex = 101;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.Location = new System.Drawing.Point(3, 21);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(68, 15);
            this.gunaLabel2.TabIndex = 0;
            this.gunaLabel2.Text = "gunaLabel2";
            // 
            // frmRendezVous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.abstract_health_medical_science_healthcare_icon_digital_technology_science_concept_modern_innovation_treatment_medicine_on_hi_tech_future_blue_background_for_wallpaper_template_web_design_vec;
            this.ClientSize = new System.Drawing.Size(1160, 545);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmRendezVous";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmPatients";
            this.Load += new System.EventHandler(this.frmRendezVous_Load);
            this.pnlRv.ResumeLayout(false);
            this.pnlRv.PerformLayout();
            this.pnlListeCreneau.ResumeLayout(false);
            this.pnlListeCreneau.PerformLayout();
            this.pnlActionPaiement.ResumeLayout(false);
            this.pnlActionPaiement.PerformLayout();
            this.pnlPaiement.ResumeLayout(false);
            this.pnlPaiement.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            this.pnlAllImpression.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlimpression.ResumeLayout(false);
            this.pnlimpression.PerformLayout();
            this.pnlDetailsRv.ResumeLayout(false);
            this.pnlDetailsRv.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlPatient.ResumeLayout(false);
            this.pnlPatient.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlRv;
        private System.Windows.Forms.Panel pnlListeCreneau;
        private System.Windows.Forms.Label lblTabMessage;
        private System.Windows.Forms.Label lblMessageCreneaux;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel pnlActionPaiement;
        private System.Windows.Forms.Panel pnlPaiement;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel pnlAllImpression;
        private System.Windows.Forms.Panel pnlimpression;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel pnlDetailsRv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtRendezVous;
        private System.Windows.Forms.TextBox txtSoin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSoin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbSoins;
        private System.Windows.Forms.ComboBox cbbDureeCreneaux;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbCreneauHoraire;
        private System.Windows.Forms.ComboBox cbbMedecin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlPatient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNomPrenom;
        private System.Windows.Forms.TextBox txtNomPrenom;
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
        private System.Windows.Forms.ComboBox cbbTelephone;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtDateNaissance;
        private System.Windows.Forms.Label lblDateNaissance;
        private Guna.UI2.WinForms.Guna2Button btnValidezRv;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI2.WinForms.Guna2HtmlToolTip guna2HtmlToolTip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2Button btnPrevisualisez;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
    }
}