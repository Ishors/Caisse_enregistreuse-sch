namespace CaisseEnregistreuse
{
    partial class Form1
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
            this.button_panier = new System.Windows.Forms.Button();
            this.textBox_prix = new System.Windows.Forms.TextBox();
            this.button_valider = new System.Windows.Forms.Button();
            this.button_vider = new System.Windows.Forms.Button();
            this.button_paiement = new System.Windows.Forms.Button();
            this.textBox_prixPanier = new System.Windows.Forms.TextBox();
            this.button_fichier = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.actualise = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button_panier
            // 
            this.button_panier.Location = new System.Drawing.Point(650, 27);
            this.button_panier.Name = "button_panier";
            this.button_panier.Size = new System.Drawing.Size(113, 85);
            this.button_panier.TabIndex = 1;
            this.button_panier.Text = "Panier";
            this.button_panier.UseVisualStyleBackColor = true;
            // 
            // textBox_prix
            // 
            this.textBox_prix.Location = new System.Drawing.Point(650, 156);
            this.textBox_prix.Name = "textBox_prix";
            this.textBox_prix.Size = new System.Drawing.Size(113, 22);
            this.textBox_prix.TabIndex = 2;
            // 
            // button_valider
            // 
            this.button_valider.Location = new System.Drawing.Point(650, 219);
            this.button_valider.Name = "button_valider";
            this.button_valider.Size = new System.Drawing.Size(112, 58);
            this.button_valider.TabIndex = 3;
            this.button_valider.Text = "Valider article";
            this.button_valider.UseVisualStyleBackColor = true;
            // 
            // button_vider
            // 
            this.button_vider.Location = new System.Drawing.Point(650, 314);
            this.button_vider.Name = "button_vider";
            this.button_vider.Size = new System.Drawing.Size(112, 27);
            this.button_vider.TabIndex = 4;
            this.button_vider.Text = "Vider article";
            this.button_vider.UseVisualStyleBackColor = true;
            // 
            // button_paiement
            // 
            this.button_paiement.Location = new System.Drawing.Point(631, 434);
            this.button_paiement.Name = "button_paiement";
            this.button_paiement.Size = new System.Drawing.Size(132, 95);
            this.button_paiement.TabIndex = 5;
            this.button_paiement.Text = "Paiement";
            this.button_paiement.UseVisualStyleBackColor = true;
            this.button_paiement.Click += new System.EventHandler(this.button_paiement_Click);
            // 
            // textBox_prixPanier
            // 
            this.textBox_prixPanier.Location = new System.Drawing.Point(12, 485);
            this.textBox_prixPanier.Name = "textBox_prixPanier";
            this.textBox_prixPanier.ReadOnly = true;
            this.textBox_prixPanier.Size = new System.Drawing.Size(231, 22);
            this.textBox_prixPanier.TabIndex = 6;
            // 
            // button_fichier
            // 
            this.button_fichier.Location = new System.Drawing.Point(280, 457);
            this.button_fichier.Name = "button_fichier";
            this.button_fichier.Size = new System.Drawing.Size(183, 36);
            this.button_fichier.TabIndex = 7;
            this.button_fichier.Text = "Fichier";
            this.button_fichier.UseVisualStyleBackColor = true;
            this.button_fichier.Click += new System.EventHandler(this.button_fichier_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Poids (kg)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Prix total (€)";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // actualise
            // 
            this.actualise.Location = new System.Drawing.Point(469, 446);
            this.actualise.Name = "actualise";
            this.actualise.Size = new System.Drawing.Size(121, 59);
            this.actualise.TabIndex = 10;
            this.actualise.Text = "Actualiser Fichier";
            this.actualise.UseVisualStyleBackColor = true;
            this.actualise.Click += new System.EventHandler(this.actualise_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(607, 418);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 599);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.actualise);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_fichier);
            this.Controls.Add(this.textBox_prixPanier);
            this.Controls.Add(this.button_paiement);
            this.Controls.Add(this.button_vider);
            this.Controls.Add(this.button_valider);
            this.Controls.Add(this.textBox_prix);
            this.Controls.Add(this.button_panier);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_panier;
        private System.Windows.Forms.TextBox textBox_prix;
        private System.Windows.Forms.Button button_valider;
        private System.Windows.Forms.Button button_vider;
        private System.Windows.Forms.Button button_paiement;
        private System.Windows.Forms.TextBox textBox_prixPanier;
        private System.Windows.Forms.Button button_fichier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button actualise;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

