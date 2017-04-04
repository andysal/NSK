namespace NskServicesClient
{
    partial class Form1
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
            this.btnCategorieSoap = new System.Windows.Forms.Button();
            this.btnCategorieRest = new System.Windows.Forms.Button();
            this.btnProductsByCategoryS = new System.Windows.Forms.Button();
            this.btnProductsByCategoryR = new System.Windows.Forms.Button();
            this.btnSearchS = new System.Windows.Forms.Button();
            this.btnSearchR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCategorieSoap
            // 
            this.btnCategorieSoap.Location = new System.Drawing.Point(13, 13);
            this.btnCategorieSoap.Name = "btnCategorieSoap";
            this.btnCategorieSoap.Size = new System.Drawing.Size(75, 23);
            this.btnCategorieSoap.TabIndex = 0;
            this.btnCategorieSoap.Text = "Categorie S";
            this.btnCategorieSoap.UseVisualStyleBackColor = true;
            this.btnCategorieSoap.Click += new System.EventHandler(this.btnCategorieSoap_Click);
            // 
            // btnCategorieRest
            // 
            this.btnCategorieRest.Location = new System.Drawing.Point(107, 13);
            this.btnCategorieRest.Name = "btnCategorieRest";
            this.btnCategorieRest.Size = new System.Drawing.Size(75, 23);
            this.btnCategorieRest.TabIndex = 1;
            this.btnCategorieRest.Text = "Categorie R";
            this.btnCategorieRest.UseVisualStyleBackColor = true;
            this.btnCategorieRest.Click += new System.EventHandler(this.btnCategorieRest_Click);
            // 
            // btnProductsByCategoryS
            // 
            this.btnProductsByCategoryS.Location = new System.Drawing.Point(13, 57);
            this.btnProductsByCategoryS.Name = "btnProductsByCategoryS";
            this.btnProductsByCategoryS.Size = new System.Drawing.Size(75, 23);
            this.btnProductsByCategoryS.TabIndex = 2;
            this.btnProductsByCategoryS.Text = "Prodotti S";
            this.btnProductsByCategoryS.UseVisualStyleBackColor = true;
            this.btnProductsByCategoryS.Click += new System.EventHandler(this.btnProductsByCategoryS_Click);
            // 
            // btnProductsByCategoryR
            // 
            this.btnProductsByCategoryR.Location = new System.Drawing.Point(107, 57);
            this.btnProductsByCategoryR.Name = "btnProductsByCategoryR";
            this.btnProductsByCategoryR.Size = new System.Drawing.Size(75, 23);
            this.btnProductsByCategoryR.TabIndex = 3;
            this.btnProductsByCategoryR.Text = "Prodotti R";
            this.btnProductsByCategoryR.UseVisualStyleBackColor = true;
            this.btnProductsByCategoryR.Click += new System.EventHandler(this.btnProductsByCategoryR_Click);
            // 
            // btnSearchS
            // 
            this.btnSearchS.Location = new System.Drawing.Point(13, 104);
            this.btnSearchS.Name = "btnSearchS";
            this.btnSearchS.Size = new System.Drawing.Size(75, 23);
            this.btnSearchS.TabIndex = 4;
            this.btnSearchS.Text = "Search S";
            this.btnSearchS.UseVisualStyleBackColor = true;
            this.btnSearchS.Click += new System.EventHandler(this.btnSearchS_Click);
            // 
            // btnSearchR
            // 
            this.btnSearchR.Location = new System.Drawing.Point(107, 103);
            this.btnSearchR.Name = "btnSearchR";
            this.btnSearchR.Size = new System.Drawing.Size(75, 23);
            this.btnSearchR.TabIndex = 5;
            this.btnSearchR.Text = "Search R";
            this.btnSearchR.UseVisualStyleBackColor = true;
            this.btnSearchR.Click += new System.EventHandler(this.btnSearchR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSearchR);
            this.Controls.Add(this.btnSearchS);
            this.Controls.Add(this.btnProductsByCategoryR);
            this.Controls.Add(this.btnProductsByCategoryS);
            this.Controls.Add(this.btnCategorieRest);
            this.Controls.Add(this.btnCategorieSoap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCategorieSoap;
        private System.Windows.Forms.Button btnCategorieRest;
        private System.Windows.Forms.Button btnProductsByCategoryS;
        private System.Windows.Forms.Button btnProductsByCategoryR;
        private System.Windows.Forms.Button btnSearchS;
        private System.Windows.Forms.Button btnSearchR;
    }
}

