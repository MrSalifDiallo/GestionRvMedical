namespace WindowsFormsApp1.View.GunaUi
{
    partial class frmTest
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaMediumCheckBox1 = new Guna.UI.WinForms.GunaMediumCheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl = new System.Windows.Forms.Label();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.lblIdentifiant = new System.Windows.Forms.Label();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtIdentifiant = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMotdePasse = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Location = new System.Drawing.Point(-97, -45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 541);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtMotdePasse);
            this.panel2.Controls.Add(this.txtIdentifiant);
            this.panel2.Controls.Add(this.gunaMediumCheckBox1);
            this.panel2.Controls.Add(this.lblMessage);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbl);
            this.panel2.Controls.Add(this.btnConnexion);
            this.panel2.Controls.Add(this.lblIdentifiant);
            this.panel2.Controls.Add(this.lblMotDePasse);
            this.panel2.Controls.Add(this.btnQuitter);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Location = new System.Drawing.Point(47, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 409);
            this.panel2.TabIndex = 10;
            // 
            // gunaMediumCheckBox1
            // 
            this.gunaMediumCheckBox1.BackColor = System.Drawing.Color.White;
            this.gunaMediumCheckBox1.BaseColor = System.Drawing.Color.White;
            this.gunaMediumCheckBox1.CheckedOffColor = System.Drawing.SystemColors.GrayText;
            this.gunaMediumCheckBox1.CheckedOnColor = System.Drawing.Color.Red;
            this.gunaMediumCheckBox1.FillColor = System.Drawing.Color.White;
            this.gunaMediumCheckBox1.Location = new System.Drawing.Point(558, 181);
            this.gunaMediumCheckBox1.Name = "gunaMediumCheckBox1";
            this.gunaMediumCheckBox1.Size = new System.Drawing.Size(20, 20);
            this.gunaMediumCheckBox1.TabIndex = 11;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Black;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(106, 347);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 25);
            this.lblMessage.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.WhatsApp_Image_2024_11_06_at_4_54_45_PM;
            this.pictureBox1.Location = new System.Drawing.Point(433, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 405);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Location = new System.Drawing.Point(60, 58);
            this.lbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(80, 13);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Authentification";
            // 
            // btnConnexion
            // 
            this.btnConnexion.BackColor = System.Drawing.Color.Black;
            this.btnConnexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnexion.FlatAppearance.BorderColor = System.Drawing.Color.BlueViolet;
            this.btnConnexion.FlatAppearance.BorderSize = 2;
            this.btnConnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnexion.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnexion.ForeColor = System.Drawing.Color.Lime;
            this.btnConnexion.Location = new System.Drawing.Point(249, 293);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(144, 37);
            this.btnConnexion.TabIndex = 6;
            this.btnConnexion.Text = "&Connexion";
            this.btnConnexion.UseVisualStyleBackColor = false;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // lblIdentifiant
            // 
            this.lblIdentifiant.AutoSize = true;
            this.lblIdentifiant.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentifiant.Location = new System.Drawing.Point(68, 129);
            this.lblIdentifiant.Name = "lblIdentifiant";
            this.lblIdentifiant.Size = new System.Drawing.Size(89, 21);
            this.lblIdentifiant.TabIndex = 1;
            this.lblIdentifiant.Text = "Identifiant";
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotDePasse.Location = new System.Drawing.Point(68, 206);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(113, 21);
            this.lblMotDePasse.TabIndex = 2;
            this.lblMotDePasse.Text = "Mot de passe";
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Black;
            this.btnQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btnQuitter.FlatAppearance.BorderSize = 2;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.ForeColor = System.Drawing.Color.Red;
            this.btnQuitter.Location = new System.Drawing.Point(68, 293);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(144, 37);
            this.btnQuitter.TabIndex = 5;
            this.btnQuitter.Text = "&Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Red;
            this.splitter2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(433, 405);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.LavenderBlush;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(482, 541);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.BorderRadius = 10;
            this.txtIdentifiant.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdentifiant.DefaultText = "";
            this.txtIdentifiant.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIdentifiant.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIdentifiant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdentifiant.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdentifiant.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIdentifiant.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdentifiant.ForeColor = System.Drawing.Color.Black;
            this.txtIdentifiant.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIdentifiant.Location = new System.Drawing.Point(68, 153);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtIdentifiant.PlaceholderText = "Identifiant\r\n";
            this.txtIdentifiant.SelectedText = "";
            this.txtIdentifiant.Size = new System.Drawing.Size(325, 36);
            this.txtIdentifiant.TabIndex = 12;
            // 
            // txtMotdePasse
            // 
            this.txtMotdePasse.BorderRadius = 10;
            this.txtMotdePasse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMotdePasse.DefaultText = "";
            this.txtMotdePasse.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMotdePasse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMotdePasse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMotdePasse.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMotdePasse.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMotdePasse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMotdePasse.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMotdePasse.Location = new System.Drawing.Point(68, 230);
            this.txtMotdePasse.Name = "txtMotdePasse";
            this.txtMotdePasse.PlaceholderText = "Mot de Passe\r\n";
            this.txtMotdePasse.SelectedText = "";
            this.txtMotdePasse.Size = new System.Drawing.Size(325, 36);
            this.txtMotdePasse.TabIndex = 13;
            this.txtMotdePasse.UseSystemPasswordChar = true;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaMediumCheckBox gunaMediumCheckBox1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.Label lblIdentifiant;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private Guna.UI2.WinForms.Guna2TextBox txtIdentifiant;
        private Guna.UI2.WinForms.Guna2TextBox txtMotdePasse;
    }
}