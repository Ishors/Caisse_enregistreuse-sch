﻿namespace CaisseEnregistreuse
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
            this.textBox_poids = new System.Windows.Forms.TextBox();
            this.button_valider = new System.Windows.Forms.Button();
            this.button_vider = new System.Windows.Forms.Button();
            this.button_paiement = new System.Windows.Forms.Button();
            this.textBox_prixPanier = new System.Windows.Forms.TextBox();
            this.button_fichier = new System.Windows.Forms.Button();
            this.actualise = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lastTicket = new System.Windows.Forms.Button();
            this.allTickets = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_panier
            // 
            this.button_panier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_panier.Enabled = false;
            this.button_panier.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_panier.Location = new System.Drawing.Point(885, 12);
            this.button_panier.Name = "button_panier";
            this.button_panier.Size = new System.Drawing.Size(171, 108);
            this.button_panier.TabIndex = 1;
            this.button_panier.Text = "Panier";
            this.button_panier.UseVisualStyleBackColor = false;
            this.button_panier.Click += new System.EventHandler(this.button_panier_Click);
            // 
            // textBox_poids
            // 
            this.textBox_poids.BackColor = System.Drawing.Color.White;
            this.textBox_poids.Enabled = false;
            this.textBox_poids.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_poids.Location = new System.Drawing.Point(885, 222);
            this.textBox_poids.Name = "textBox_poids";
            this.textBox_poids.Size = new System.Drawing.Size(157, 34);
            this.textBox_poids.TabIndex = 2;
            // 
            // button_valider
            // 
            this.button_valider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_valider.Enabled = false;
            this.button_valider.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_valider.Location = new System.Drawing.Point(885, 302);
            this.button_valider.Name = "button_valider";
            this.button_valider.Size = new System.Drawing.Size(171, 52);
            this.button_valider.TabIndex = 3;
            this.button_valider.Text = "Valider article";
            this.button_valider.UseVisualStyleBackColor = false;
            this.button_valider.Click += new System.EventHandler(this.button_valider_Click);
            // 
            // button_vider
            // 
            this.button_vider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_vider.Enabled = false;
            this.button_vider.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vider.Location = new System.Drawing.Point(885, 403);
            this.button_vider.Name = "button_vider";
            this.button_vider.Size = new System.Drawing.Size(171, 55);
            this.button_vider.TabIndex = 4;
            this.button_vider.Text = "Vider article";
            this.button_vider.UseVisualStyleBackColor = false;
            this.button_vider.Click += new System.EventHandler(this.button_vider_Click);
            // 
            // button_paiement
            // 
            this.button_paiement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_paiement.Enabled = false;
            this.button_paiement.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_paiement.Location = new System.Drawing.Point(885, 498);
            this.button_paiement.Name = "button_paiement";
            this.button_paiement.Size = new System.Drawing.Size(171, 139);
            this.button_paiement.TabIndex = 5;
            this.button_paiement.Text = "Paiement";
            this.button_paiement.UseVisualStyleBackColor = false;
            this.button_paiement.Click += new System.EventHandler(this.button_paiement_Click);
            // 
            // textBox_prixPanier
            // 
            this.textBox_prixPanier.BackColor = System.Drawing.Color.White;
            this.textBox_prixPanier.Enabled = false;
            this.textBox_prixPanier.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_prixPanier.Location = new System.Drawing.Point(746, 599);
            this.textBox_prixPanier.Name = "textBox_prixPanier";
            this.textBox_prixPanier.ReadOnly = true;
            this.textBox_prixPanier.Size = new System.Drawing.Size(94, 38);
            this.textBox_prixPanier.TabIndex = 6;
            // 
            // button_fichier
            // 
            this.button_fichier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_fichier.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fichier.Location = new System.Drawing.Point(76, 535);
            this.button_fichier.Name = "button_fichier";
            this.button_fichier.Size = new System.Drawing.Size(139, 65);
            this.button_fichier.TabIndex = 7;
            this.button_fichier.Text = "Ouvrir Fichier";
            this.button_fichier.UseVisualStyleBackColor = false;
            this.button_fichier.Click += new System.EventHandler(this.button_fichier_Click);
            // 
            // actualise
            // 
            this.actualise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.actualise.Enabled = false;
            this.actualise.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualise.Location = new System.Drawing.Point(267, 535);
            this.actualise.Name = "actualise";
            this.actualise.Size = new System.Drawing.Size(139, 65);
            this.actualise.TabIndex = 10;
            this.actualise.Text = "Charger Fichier";
            this.actualise.UseVisualStyleBackColor = false;
            this.actualise.Click += new System.EventHandler(this.actualise_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 12);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(846, 373);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(543, 391);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(318, 193);
            this.flowLayoutPanel2.TabIndex = 12;
            // 
            // lastTicket
            // 
            this.lastTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lastTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastTicket.Location = new System.Drawing.Point(267, 424);
            this.lastTicket.Name = "lastTicket";
            this.lastTicket.Size = new System.Drawing.Size(139, 65);
            this.lastTicket.TabIndex = 13;
            this.lastTicket.Text = "Imprimer dernier ticket";
            this.lastTicket.UseVisualStyleBackColor = false;
            this.lastTicket.Click += new System.EventHandler(this.lastTicket_Click);
            // 
            // allTickets
            // 
            this.allTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.allTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allTickets.Location = new System.Drawing.Point(76, 424);
            this.allTickets.Name = "allTickets";
            this.allTickets.Size = new System.Drawing.Size(139, 65);
            this.allTickets.TabIndex = 14;
            this.allTickets.Text = "Imprimer tous les tickets";
            this.allTickets.UseVisualStyleBackColor = false;
            this.allTickets.Click += new System.EventHandler(this.allTickets_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(907, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Poids (kg) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(564, 602);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 32);
            this.label2.TabIndex = 16;
            this.label2.Text = "Prix TTC (€) :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1105, 685);
            this.Controls.Add(this.textBox_poids);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allTickets);
            this.Controls.Add(this.lastTicket);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.actualise);
            this.Controls.Add(this.button_fichier);
            this.Controls.Add(this.textBox_prixPanier);
            this.Controls.Add(this.button_paiement);
            this.Controls.Add(this.button_vider);
            this.Controls.Add(this.button_valider);
            this.Controls.Add(this.button_panier);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caisse Automatique";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_panier;
        private System.Windows.Forms.TextBox textBox_poids;
        private System.Windows.Forms.Button button_valider;
        private System.Windows.Forms.Button button_vider;
        private System.Windows.Forms.Button button_paiement;
        private System.Windows.Forms.TextBox textBox_prixPanier;
        private System.Windows.Forms.Button button_fichier;
        private System.Windows.Forms.Button actualise;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button lastTicket;
        private System.Windows.Forms.Button allTickets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

