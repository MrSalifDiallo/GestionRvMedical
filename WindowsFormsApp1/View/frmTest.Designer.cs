namespace WindowsFormsApp1.View
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
            this.components = new System.ComponentModel.Container();
            this.dgAgenda = new System.Windows.Forms.DataGridView();
            this.agendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.creneauDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datePlanifieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heureDebutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heureFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMedecinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lieuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medecinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAgenda
            // 
            this.dgAgenda.AutoGenerateColumns = false;
            this.dgAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAgenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.creneauDataGridViewTextBoxColumn,
            this.datePlanifieDataGridViewTextBoxColumn,
            this.heureDebutDataGridViewTextBoxColumn,
            this.heureFinDataGridViewTextBoxColumn,
            this.idAgendaDataGridViewTextBoxColumn,
            this.idMedecinDataGridViewTextBoxColumn,
            this.lieuDataGridViewTextBoxColumn,
            this.medecinDataGridViewTextBoxColumn,
            this.titreDataGridViewTextBoxColumn,
            this.statutDataGridViewTextBoxColumn});
            this.dgAgenda.DataSource = this.agendaBindingSource;
            this.dgAgenda.Location = new System.Drawing.Point(28, 68);
            this.dgAgenda.Name = "dgAgenda";
            this.dgAgenda.RowHeadersWidth = 51;
            this.dgAgenda.RowTemplate.Height = 24;
            this.dgAgenda.Size = new System.Drawing.Size(743, 321);
            this.dgAgenda.TabIndex = 0;
            this.dgAgenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAgenda_CellContentClick);
            // 
            // agendaBindingSource
            // 
            this.agendaBindingSource.DataSource = typeof(WindowsFormsApp1.ServiceMetierAgenda.Agenda);
            // 
            // creneauDataGridViewTextBoxColumn
            // 
            this.creneauDataGridViewTextBoxColumn.DataPropertyName = "Creneau";
            this.creneauDataGridViewTextBoxColumn.HeaderText = "Creneau";
            this.creneauDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.creneauDataGridViewTextBoxColumn.Name = "creneauDataGridViewTextBoxColumn";
            this.creneauDataGridViewTextBoxColumn.Width = 125;
            // 
            // datePlanifieDataGridViewTextBoxColumn
            // 
            this.datePlanifieDataGridViewTextBoxColumn.DataPropertyName = "DatePlanifie";
            this.datePlanifieDataGridViewTextBoxColumn.HeaderText = "DatePlanifie";
            this.datePlanifieDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.datePlanifieDataGridViewTextBoxColumn.Name = "datePlanifieDataGridViewTextBoxColumn";
            this.datePlanifieDataGridViewTextBoxColumn.Width = 125;
            // 
            // heureDebutDataGridViewTextBoxColumn
            // 
            this.heureDebutDataGridViewTextBoxColumn.DataPropertyName = "HeureDebut";
            this.heureDebutDataGridViewTextBoxColumn.HeaderText = "HeureDebut";
            this.heureDebutDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.heureDebutDataGridViewTextBoxColumn.Name = "heureDebutDataGridViewTextBoxColumn";
            this.heureDebutDataGridViewTextBoxColumn.Width = 125;
            // 
            // heureFinDataGridViewTextBoxColumn
            // 
            this.heureFinDataGridViewTextBoxColumn.DataPropertyName = "HeureFin";
            this.heureFinDataGridViewTextBoxColumn.HeaderText = "HeureFin";
            this.heureFinDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.heureFinDataGridViewTextBoxColumn.Name = "heureFinDataGridViewTextBoxColumn";
            this.heureFinDataGridViewTextBoxColumn.Width = 125;
            // 
            // idAgendaDataGridViewTextBoxColumn
            // 
            this.idAgendaDataGridViewTextBoxColumn.DataPropertyName = "IdAgenda";
            this.idAgendaDataGridViewTextBoxColumn.HeaderText = "IdAgenda";
            this.idAgendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idAgendaDataGridViewTextBoxColumn.Name = "idAgendaDataGridViewTextBoxColumn";
            this.idAgendaDataGridViewTextBoxColumn.Width = 125;
            // 
            // idMedecinDataGridViewTextBoxColumn
            // 
            this.idMedecinDataGridViewTextBoxColumn.DataPropertyName = "IdMedecin";
            this.idMedecinDataGridViewTextBoxColumn.HeaderText = "IdMedecin";
            this.idMedecinDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idMedecinDataGridViewTextBoxColumn.Name = "idMedecinDataGridViewTextBoxColumn";
            this.idMedecinDataGridViewTextBoxColumn.Width = 125;
            // 
            // lieuDataGridViewTextBoxColumn
            // 
            this.lieuDataGridViewTextBoxColumn.DataPropertyName = "Lieu";
            this.lieuDataGridViewTextBoxColumn.HeaderText = "Lieu";
            this.lieuDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lieuDataGridViewTextBoxColumn.Name = "lieuDataGridViewTextBoxColumn";
            this.lieuDataGridViewTextBoxColumn.Width = 125;
            // 
            // medecinDataGridViewTextBoxColumn
            // 
            this.medecinDataGridViewTextBoxColumn.DataPropertyName = "Medecin";
            this.medecinDataGridViewTextBoxColumn.HeaderText = "Medecin";
            this.medecinDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.medecinDataGridViewTextBoxColumn.Name = "medecinDataGridViewTextBoxColumn";
            this.medecinDataGridViewTextBoxColumn.Width = 125;
            // 
            // titreDataGridViewTextBoxColumn
            // 
            this.titreDataGridViewTextBoxColumn.DataPropertyName = "Titre";
            this.titreDataGridViewTextBoxColumn.HeaderText = "Titre";
            this.titreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.titreDataGridViewTextBoxColumn.Name = "titreDataGridViewTextBoxColumn";
            this.titreDataGridViewTextBoxColumn.Width = 125;
            // 
            // statutDataGridViewTextBoxColumn
            // 
            this.statutDataGridViewTextBoxColumn.DataPropertyName = "statut";
            this.statutDataGridViewTextBoxColumn.HeaderText = "statut";
            this.statutDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statutDataGridViewTextBoxColumn.Name = "statutDataGridViewTextBoxColumn";
            this.statutDataGridViewTextBoxColumn.Width = 125;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dgAgenda);
            this.Name = "frmTest";
            this.Text = "frmTest";
            ((System.ComponentModel.ISupportInitialize)(this.dgAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAgenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn creneauDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datePlanifieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heureDebutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heureFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMedecinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lieuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn medecinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statutDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource agendaBindingSource;
    }
}