namespace ferrari_win_form3
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.labelgp = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxPrezzo = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelPrezzo = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonMod = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelNewPrice = new System.Windows.Forms.Label();
            this.labelNewName = new System.Windows.Forms.Label();
            this.textBoxNewPrice = new System.Windows.Forms.TextBox();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            this.buttonComp = new System.Windows.Forms.Button();
            this.buttonRec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.Color.DodgerBlue;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(465, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(324, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // labelgp
            // 
            this.labelgp.AutoSize = true;
            this.labelgp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelgp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelgp.Location = new System.Drawing.Point(32, 12);
            this.labelgp.Name = "labelgp";
            this.labelgp.Size = new System.Drawing.Size(269, 38);
            this.labelgp.TabIndex = 1;
            this.labelgp.Text = "Gestione Prodotti";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(19, 92);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(101, 20);
            this.textBoxNome.TabIndex = 2;
            // 
            // textBoxPrezzo
            // 
            this.textBoxPrezzo.Location = new System.Drawing.Point(233, 92);
            this.textBoxPrezzo.Name = "textBoxPrezzo";
            this.textBoxPrezzo.Size = new System.Drawing.Size(101, 20);
            this.textBoxPrezzo.TabIndex = 3;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.ForeColor = System.Drawing.Color.Black;
            this.labelNome.Location = new System.Drawing.Point(15, 65);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(70, 25);
            this.labelNome.TabIndex = 4;
            this.labelNome.Text = "Nome:";
            // 
            // labelPrezzo
            // 
            this.labelPrezzo.AutoSize = true;
            this.labelPrezzo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrezzo.ForeColor = System.Drawing.Color.Black;
            this.labelPrezzo.Location = new System.Drawing.Point(229, 65);
            this.labelPrezzo.Name = "labelPrezzo";
            this.labelPrezzo.Size = new System.Drawing.Size(79, 25);
            this.labelPrezzo.TabIndex = 5;
            this.labelPrezzo.Text = "Prezzo:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonAdd.Location = new System.Drawing.Point(19, 136);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(101, 30);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Aggiungi";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonDel.Location = new System.Drawing.Point(340, 136);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(101, 30);
            this.buttonDel.TabIndex = 7;
            this.buttonDel.Text = "Cancella";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonMod
            // 
            this.buttonMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMod.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonMod.Location = new System.Drawing.Point(233, 136);
            this.buttonMod.Name = "buttonMod";
            this.buttonMod.Size = new System.Drawing.Size(101, 30);
            this.buttonMod.TabIndex = 8;
            this.buttonMod.Text = "Modifica";
            this.buttonMod.UseVisualStyleBackColor = true;
            this.buttonMod.Click += new System.EventHandler(this.buttonMod_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFind.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonFind.Location = new System.Drawing.Point(126, 136);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(101, 30);
            this.buttonFind.TabIndex = 9;
            this.buttonFind.Text = "Ricerca";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonExit.Location = new System.Drawing.Point(179, 408);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(101, 30);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Uscita";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelNewPrice
            // 
            this.labelNewPrice.AutoSize = true;
            this.labelNewPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewPrice.ForeColor = System.Drawing.Color.Black;
            this.labelNewPrice.Location = new System.Drawing.Point(336, 196);
            this.labelNewPrice.Name = "labelNewPrice";
            this.labelNewPrice.Size = new System.Drawing.Size(111, 20);
            this.labelNewPrice.TabIndex = 15;
            this.labelNewPrice.Text = "Nuovo Prezzo:";
            // 
            // labelNewName
            // 
            this.labelNewName.AutoSize = true;
            this.labelNewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewName.ForeColor = System.Drawing.Color.Black;
            this.labelNewName.Location = new System.Drawing.Point(230, 196);
            this.labelNewName.Name = "labelNewName";
            this.labelNewName.Size = new System.Drawing.Size(104, 20);
            this.labelNewName.TabIndex = 14;
            this.labelNewName.Text = "Nuovo Nome:";
            // 
            // textBoxNewPrice
            // 
            this.textBoxNewPrice.Location = new System.Drawing.Point(340, 223);
            this.textBoxNewPrice.Name = "textBoxNewPrice";
            this.textBoxNewPrice.Size = new System.Drawing.Size(101, 20);
            this.textBoxNewPrice.TabIndex = 13;
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.Location = new System.Drawing.Point(234, 223);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewName.TabIndex = 12;
            // 
            // buttonComp
            // 
            this.buttonComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonComp.Location = new System.Drawing.Point(126, 213);
            this.buttonComp.Name = "buttonComp";
            this.buttonComp.Size = new System.Drawing.Size(101, 30);
            this.buttonComp.TabIndex = 16;
            this.buttonComp.Text = "Ricompatta";
            this.buttonComp.UseVisualStyleBackColor = true;
            this.buttonComp.Click += new System.EventHandler(this.buttonComp_Click);
            // 
            // buttonRec
            // 
            this.buttonRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRec.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonRec.Location = new System.Drawing.Point(19, 213);
            this.buttonRec.Name = "buttonRec";
            this.buttonRec.Size = new System.Drawing.Size(101, 30);
            this.buttonRec.TabIndex = 17;
            this.buttonRec.Text = "Recupera";
            this.buttonRec.UseVisualStyleBackColor = true;
            this.buttonRec.Click += new System.EventHandler(this.buttonRec_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRec);
            this.Controls.Add(this.buttonComp);
            this.Controls.Add(this.labelNewPrice);
            this.Controls.Add(this.labelNewName);
            this.Controls.Add(this.textBoxNewPrice);
            this.Controls.Add(this.textBoxNewName);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.buttonMod);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelPrezzo);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.textBoxPrezzo);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelgp);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label labelgp;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxPrezzo;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelPrezzo;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonMod;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelNewPrice;
        private System.Windows.Forms.Label labelNewName;
        private System.Windows.Forms.TextBox textBoxNewPrice;
        private System.Windows.Forms.TextBox textBoxNewName;
        private System.Windows.Forms.Button buttonComp;
        private System.Windows.Forms.Button buttonRec;
    }
}

