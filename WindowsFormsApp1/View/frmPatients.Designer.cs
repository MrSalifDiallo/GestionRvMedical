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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableEnteteLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tablePiedLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableContentLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.dgPatient = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlCentreAction = new System.Windows.Forms.Panel();
            this.btnChoisir = new Guna.UI2.WinForms.Guna2Button();
            this.lblCentreAction = new System.Windows.Forms.Label();
            this.btnRenitialiser = new Guna.UI2.WinForms.Guna2Button();
            this.btnValider = new Guna.UI2.WinForms.Guna2Button();
            this.txtTaille = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPoids = new System.Windows.Forms.TextBox();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.lblTaille = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPoids = new System.Windows.Forms.Label();
            this.lblAdresse = new System.Windows.Forms.Label();
            this.lblDateNaissance = new System.Windows.Forms.Label();
            this.lblGroupeSanguin = new System.Windows.Forms.Label();
            this.lblNomPrenom = new System.Windows.Forms.Label();
            this.dtDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.cbbGroupeSanguin = new System.Windows.Forms.ComboBox();
            this.txtNomPrenom = new System.Windows.Forms.TextBox();
            this.tableEnteteLayout.SuspendLayout();
            this.tableContentLayout.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.pnlCentreAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableEnteteLayout
            // 
            this.tableEnteteLayout.BackColor = System.Drawing.Color.Brown;
            this.tableEnteteLayout.ColumnCount = 5;
            this.tableEnteteLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableEnteteLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableEnteteLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableEnteteLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableEnteteLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableEnteteLayout.Controls.Add(this.lblTitle, 2, 1);
            this.tableEnteteLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableEnteteLayout.Location = new System.Drawing.Point(0, 0);
            this.tableEnteteLayout.Name = "tableEnteteLayout";
            this.tableEnteteLayout.RowCount = 2;
            this.tableEnteteLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableEnteteLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableEnteteLayout.Size = new System.Drawing.Size(1191, 79);
            this.tableEnteteLayout.TabIndex = 45;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableEnteteLayout.SetColumnSpan(this.lblTitle, 3);
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(478, 39);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(119, 25);
            this.lblTitle.TabIndex = 39;
            this.lblTitle.Text = "PATIENT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tablePiedLayout
            // 
            this.tablePiedLayout.BackColor = System.Drawing.Color.Brown;
            this.tablePiedLayout.ColumnCount = 2;
            this.tablePiedLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePiedLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePiedLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tablePiedLayout.Location = new System.Drawing.Point(0, 604);
            this.tablePiedLayout.Name = "tablePiedLayout";
            this.tablePiedLayout.RowCount = 2;
            this.tablePiedLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePiedLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePiedLayout.Size = new System.Drawing.Size(1191, 100);
            this.tablePiedLayout.TabIndex = 46;
            // 
            // tableContentLayout
            // 
            this.tableContentLayout.ColumnCount = 1;
            this.tableContentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContentLayout.Controls.Add(this.pnlForm, 0, 0);
            this.tableContentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableContentLayout.Location = new System.Drawing.Point(0, 79);
            this.tableContentLayout.Name = "tableContentLayout";
            this.tableContentLayout.RowCount = 1;
            this.tableContentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 525F));
            this.tableContentLayout.Size = new System.Drawing.Size(1191, 525);
            this.tableContentLayout.TabIndex = 47;
            // 
            // pnlForm
            // 
            this.pnlForm.AutoSize = true;
            this.pnlForm.BackColor = System.Drawing.SystemColors.Control;
            this.pnlForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlForm.Controls.Add(this.dgPatient);
            this.pnlForm.Controls.Add(this.pnlCentreAction);
            this.pnlForm.Controls.Add(this.txtTaille);
            this.pnlForm.Controls.Add(this.txtTelephone);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.txtPoids);
            this.pnlForm.Controls.Add(this.txtAdresse);
            this.pnlForm.Controls.Add(this.lblTelephone);
            this.pnlForm.Controls.Add(this.lblTaille);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.lblPoids);
            this.pnlForm.Controls.Add(this.lblAdresse);
            this.pnlForm.Controls.Add(this.lblDateNaissance);
            this.pnlForm.Controls.Add(this.lblGroupeSanguin);
            this.pnlForm.Controls.Add(this.lblNomPrenom);
            this.pnlForm.Controls.Add(this.dtDateNaissance);
            this.pnlForm.Controls.Add(this.cbbGroupeSanguin);
            this.pnlForm.Controls.Add(this.txtNomPrenom);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(2, 2);
            this.pnlForm.Margin = new System.Windows.Forms.Padding(2);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1187, 521);
            this.pnlForm.TabIndex = 46;
            this.pnlForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlForm_Paint);
            // 
            // dgPatient
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgPatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPatient.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Salmon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPatient.ColumnHeadersHeight = 4;
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPatient.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgPatient.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgPatient.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgPatient.Location = new System.Drawing.Point(607, 0);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.RowHeadersVisible = false;
            this.dgPatient.Size = new System.Drawing.Size(580, 521);
            this.dgPatient.TabIndex = 65;
            this.dgPatient.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgPatient.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgPatient.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgPatient.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgPatient.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgPatient.ThemeStyle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dgPatient.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgPatient.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgPatient.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgPatient.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPatient.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgPatient.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgPatient.ThemeStyle.HeaderStyle.Height = 4;
            this.dgPatient.ThemeStyle.ReadOnly = false;
            this.dgPatient.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgPatient.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgPatient.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPatient.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgPatient.ThemeStyle.RowsStyle.Height = 22;
            this.dgPatient.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgPatient.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlCentreAction
            // 
            this.pnlCentreAction.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlCentreAction.Controls.Add(this.btnChoisir);
            this.pnlCentreAction.Controls.Add(this.lblCentreAction);
            this.pnlCentreAction.Controls.Add(this.btnRenitialiser);
            this.pnlCentreAction.Controls.Add(this.btnValider);
            this.pnlCentreAction.Location = new System.Drawing.Point(230, 427);
            this.pnlCentreAction.Name = "pnlCentreAction";
            this.pnlCentreAction.Size = new System.Drawing.Size(358, 90);
            this.pnlCentreAction.TabIndex = 64;
            // 
            // btnChoisir
            // 
            this.btnChoisir.Animated = true;
            this.btnChoisir.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChoisir.BorderRadius = 7;
            this.btnChoisir.BorderThickness = 2;
            this.btnChoisir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChoisir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChoisir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChoisir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChoisir.FillColor = System.Drawing.Color.Cyan;
            this.btnChoisir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChoisir.ForeColor = System.Drawing.Color.White;
            this.btnChoisir.Location = new System.Drawing.Point(248, 42);
            this.btnChoisir.Name = "btnChoisir";
            this.btnChoisir.Size = new System.Drawing.Size(93, 35);
            this.btnChoisir.TabIndex = 11;
            this.btnChoisir.Text = "&Choisir";
            // 
            // lblCentreAction
            // 
            this.lblCentreAction.AutoSize = true;
            this.lblCentreAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentreAction.Location = new System.Drawing.Point(13, 18);
            this.lblCentreAction.Name = "lblCentreAction";
            this.lblCentreAction.Size = new System.Drawing.Size(104, 15);
            this.lblCentreAction.TabIndex = 26;
            this.lblCentreAction.Text = "Centre d\'action";
            // 
            // btnRenitialiser
            // 
            this.btnRenitialiser.Animated = true;
            this.btnRenitialiser.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRenitialiser.BorderRadius = 7;
            this.btnRenitialiser.BorderThickness = 2;
            this.btnRenitialiser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRenitialiser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRenitialiser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRenitialiser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRenitialiser.FillColor = System.Drawing.Color.Red;
            this.btnRenitialiser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRenitialiser.ForeColor = System.Drawing.Color.White;
            this.btnRenitialiser.Location = new System.Drawing.Point(128, 42);
            this.btnRenitialiser.Name = "btnRenitialiser";
            this.btnRenitialiser.Size = new System.Drawing.Size(93, 35);
            this.btnRenitialiser.TabIndex = 10;
            this.btnRenitialiser.Text = "&Renitialiser";
            this.btnRenitialiser.Click += new System.EventHandler(this.btnRenitialiser_Click);
            // 
            // btnValider
            // 
            this.btnValider.Animated = true;
            this.btnValider.BorderColor = System.Drawing.Color.DarkGray;
            this.btnValider.BorderRadius = 7;
            this.btnValider.BorderThickness = 3;
            this.btnValider.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnValider.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnValider.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnValider.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnValider.FillColor = System.Drawing.Color.Lime;
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.Location = new System.Drawing.Point(3, 42);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(93, 35);
            this.btnValider.TabIndex = 9;
            this.btnValider.Text = "&Valider";
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // txtTaille
            // 
            this.txtTaille.Location = new System.Drawing.Point(11, 337);
            this.txtTaille.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaille.Multiline = true;
            this.txtTaille.Name = "txtTaille";
            this.txtTaille.Size = new System.Drawing.Size(199, 21);
            this.txtTaille.TabIndex = 6;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(11, 449);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelephone.Multiline = true;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(199, 21);
            this.txtTelephone.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(9, 98);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(199, 21);
            this.txtEmail.TabIndex = 2;
            // 
            // txtPoids
            // 
            this.txtPoids.Location = new System.Drawing.Point(9, 392);
            this.txtPoids.Margin = new System.Windows.Forms.Padding(2);
            this.txtPoids.Multiline = true;
            this.txtPoids.Name = "txtPoids";
            this.txtPoids.Size = new System.Drawing.Size(199, 21);
            this.txtPoids.TabIndex = 7;
            // 
            // txtAdresse
            // 
            this.txtAdresse.Location = new System.Drawing.Point(9, 155);
            this.txtAdresse.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdresse.Multiline = true;
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(199, 21);
            this.txtAdresse.TabIndex = 3;
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelephone.Location = new System.Drawing.Point(10, 428);
            this.lblTelephone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(67, 13);
            this.lblTelephone.TabIndex = 54;
            this.lblTelephone.Text = "Telephone";
            // 
            // lblTaille
            // 
            this.lblTaille.AutoSize = true;
            this.lblTaille.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaille.Location = new System.Drawing.Point(10, 316);
            this.lblTaille.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaille.Name = "lblTaille";
            this.lblTaille.Size = new System.Drawing.Size(38, 13);
            this.lblTaille.TabIndex = 52;
            this.lblTaille.Text = "Taille";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(8, 77);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 13);
            this.lblEmail.TabIndex = 51;
            this.lblEmail.Text = "Email";
            // 
            // lblPoids
            // 
            this.lblPoids.AutoSize = true;
            this.lblPoids.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoids.Location = new System.Drawing.Point(8, 371);
            this.lblPoids.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoids.Name = "lblPoids";
            this.lblPoids.Size = new System.Drawing.Size(38, 13);
            this.lblPoids.TabIndex = 50;
            this.lblPoids.Text = "Poids";
            // 
            // lblAdresse
            // 
            this.lblAdresse.AutoSize = true;
            this.lblAdresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdresse.Location = new System.Drawing.Point(8, 134);
            this.lblAdresse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(52, 13);
            this.lblAdresse.TabIndex = 49;
            this.lblAdresse.Text = "Adresse";
            // 
            // lblDateNaissance
            // 
            this.lblDateNaissance.AutoSize = true;
            this.lblDateNaissance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateNaissance.Location = new System.Drawing.Point(8, 258);
            this.lblDateNaissance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateNaissance.Name = "lblDateNaissance";
            this.lblDateNaissance.Size = new System.Drawing.Size(113, 13);
            this.lblDateNaissance.TabIndex = 48;
            this.lblDateNaissance.Text = "Date de naissance";
            // 
            // lblGroupeSanguin
            // 
            this.lblGroupeSanguin.AutoSize = true;
            this.lblGroupeSanguin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupeSanguin.Location = new System.Drawing.Point(8, 188);
            this.lblGroupeSanguin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGroupeSanguin.Name = "lblGroupeSanguin";
            this.lblGroupeSanguin.Size = new System.Drawing.Size(98, 13);
            this.lblGroupeSanguin.TabIndex = 47;
            this.lblGroupeSanguin.Text = "Groupe Sanguin";
            // 
            // lblNomPrenom
            // 
            this.lblNomPrenom.AutoSize = true;
            this.lblNomPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomPrenom.Location = new System.Drawing.Point(8, 17);
            this.lblNomPrenom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomPrenom.Name = "lblNomPrenom";
            this.lblNomPrenom.Size = new System.Drawing.Size(78, 13);
            this.lblNomPrenom.TabIndex = 45;
            this.lblNomPrenom.Text = "Nom Prenom";
            // 
            // dtDateNaissance
            // 
            this.dtDateNaissance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateNaissance.Location = new System.Drawing.Point(11, 279);
            this.dtDateNaissance.Margin = new System.Windows.Forms.Padding(2);
            this.dtDateNaissance.Name = "dtDateNaissance";
            this.dtDateNaissance.Size = new System.Drawing.Size(199, 24);
            this.dtDateNaissance.TabIndex = 5;
            // 
            // cbbGroupeSanguin
            // 
            this.cbbGroupeSanguin.AutoCompleteCustomSource.AddRange(new string[] {
            "F"});
            this.cbbGroupeSanguin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbGroupeSanguin.FormattingEnabled = true;
            this.cbbGroupeSanguin.Items.AddRange(new object[] {
            "M"});
            this.cbbGroupeSanguin.Location = new System.Drawing.Point(9, 209);
            this.cbbGroupeSanguin.Margin = new System.Windows.Forms.Padding(2);
            this.cbbGroupeSanguin.Name = "cbbGroupeSanguin";
            this.cbbGroupeSanguin.Size = new System.Drawing.Size(199, 28);
            this.cbbGroupeSanguin.TabIndex = 4;
            // 
            // txtNomPrenom
            // 
            this.txtNomPrenom.Location = new System.Drawing.Point(9, 38);
            this.txtNomPrenom.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomPrenom.Multiline = true;
            this.txtNomPrenom.Name = "txtNomPrenom";
            this.txtNomPrenom.Size = new System.Drawing.Size(199, 21);
            this.txtNomPrenom.TabIndex = 1;
            // 
            // frmPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.abstract_health_medical_science_healthcare_icon_digital_technology_science_concept_modern_innovation_treatment_medicine_on_hi_tech_future_blue_background_for_wallpaper_template_web_design_vec;
            this.ClientSize = new System.Drawing.Size(1191, 704);
            this.ControlBox = false;
            this.Controls.Add(this.tableContentLayout);
            this.Controls.Add(this.tablePiedLayout);
            this.Controls.Add(this.tableEnteteLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPatients";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmPatients";
            this.Load += new System.EventHandler(this.frmPatients_Load);
            this.tableEnteteLayout.ResumeLayout(false);
            this.tableEnteteLayout.PerformLayout();
            this.tableContentLayout.ResumeLayout(false);
            this.tableContentLayout.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.pnlCentreAction.ResumeLayout(false);
            this.pnlCentreAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableEnteteLayout;
        private System.Windows.Forms.TableLayoutPanel tablePiedLayout;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableContentLayout;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.TextBox txtTaille;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPoids;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblTaille;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPoids;
        private System.Windows.Forms.Label lblAdresse;
        private System.Windows.Forms.Label lblDateNaissance;
        private System.Windows.Forms.Label lblGroupeSanguin;
        private System.Windows.Forms.Label lblNomPrenom;
        private System.Windows.Forms.DateTimePicker dtDateNaissance;
        private System.Windows.Forms.ComboBox cbbGroupeSanguin;
        private System.Windows.Forms.TextBox txtNomPrenom;
        private Guna.UI2.WinForms.Guna2Button btnValider;
        private System.Windows.Forms.Panel pnlCentreAction;
        private System.Windows.Forms.Label lblCentreAction;
        private Guna.UI2.WinForms.Guna2Button btnChoisir;
        private Guna.UI2.WinForms.Guna2Button btnRenitialiser;
        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private Guna.UI2.WinForms.Guna2DataGridView dgPatient;
    }
}