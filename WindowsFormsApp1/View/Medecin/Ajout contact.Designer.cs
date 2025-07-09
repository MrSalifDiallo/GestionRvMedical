namespace WindowsFormsApp1.View.Medecin
{
    partial class Ajout_contact
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
            this.txtnom = new System.Windows.Forms.Label();
            this.txtaddresse = new System.Windows.Forms.Label();
            this.txttelephone = new System.Windows.Forms.Label();
            this.btnconfirmer = new System.Windows.Forms.Button();
            this.btnannuler = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnannuler);
            this.panel1.Controls.Add(this.btnconfirmer);
            this.panel1.Controls.Add(this.txttelephone);
            this.panel1.Controls.Add(this.txtaddresse);
            this.panel1.Controls.Add(this.txtnom);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 240);
            this.panel1.TabIndex = 0;
            // 
            // txtnom
            // 
            this.txtnom.AutoSize = true;
            this.txtnom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnom.Location = new System.Drawing.Point(31, 36);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(54, 20);
            this.txtnom.TabIndex = 1;
            this.txtnom.Text = "Nom :";
            // 
            // txtaddresse
            // 
            this.txtaddresse.AutoSize = true;
            this.txtaddresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddresse.Location = new System.Drawing.Point(31, 94);
            this.txtaddresse.Name = "txtaddresse";
            this.txtaddresse.Size = new System.Drawing.Size(90, 20);
            this.txtaddresse.TabIndex = 3;
            this.txtaddresse.Text = "Addresse :";
            // 
            // txttelephone
            // 
            this.txttelephone.AutoSize = true;
            this.txttelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelephone.Location = new System.Drawing.Point(31, 149);
            this.txttelephone.Name = "txttelephone";
            this.txttelephone.Size = new System.Drawing.Size(96, 20);
            this.txttelephone.TabIndex = 5;
            this.txttelephone.Text = "Telephone :";
            // 
            // btnconfirmer
            // 
            this.btnconfirmer.Location = new System.Drawing.Point(155, 192);
            this.btnconfirmer.Name = "btnconfirmer";
            this.btnconfirmer.Size = new System.Drawing.Size(123, 28);
            this.btnconfirmer.TabIndex = 6;
            this.btnconfirmer.Text = "Confirmer";
            this.btnconfirmer.UseVisualStyleBackColor = true;
            // 
            // btnannuler
            // 
            this.btnannuler.Location = new System.Drawing.Point(313, 192);
            this.btnannuler.Name = "btnannuler";
            this.btnannuler.Size = new System.Drawing.Size(120, 28);
            this.btnannuler.TabIndex = 7;
            this.btnannuler.Text = "Annuler";
            this.btnannuler.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 147);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 22);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(155, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(278, 22);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(155, 92);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(278, 22);
            this.textBox3.TabIndex = 10;
            // 
            // Ajout_contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 264);
            this.Controls.Add(this.panel1);
            this.Name = "Ajout_contact";
            this.Text = "Ajout_contact";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtnom;
        private System.Windows.Forms.Button btnannuler;
        private System.Windows.Forms.Button btnconfirmer;
        private System.Windows.Forms.Label txttelephone;
        private System.Windows.Forms.Label txtaddresse;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}