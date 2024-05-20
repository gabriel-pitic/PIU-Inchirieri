namespace InchirieriForms
{
    partial class Masini
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridMasini = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbxSearch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCauta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMasini)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(118)))), ((int)(((byte)(28)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(24, 89);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(191, 50);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Actualizează";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(118)))), ((int)(((byte)(28)))));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(24, 203);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(191, 50);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Șterge";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(118)))), ((int)(((byte)(28)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(24, 30);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(191, 48);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Adaugă";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // dataGridMasini
            // 
            this.dataGridMasini.AllowUserToAddRows = false;
            this.dataGridMasini.AllowUserToDeleteRows = false;
            this.dataGridMasini.BackgroundColor = System.Drawing.Color.White;
            this.dataGridMasini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMasini.Location = new System.Drawing.Point(239, 130);
            this.dataGridMasini.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridMasini.Name = "dataGridMasini";
            this.dataGridMasini.ReadOnly = true;
            this.dataGridMasini.RowHeadersWidth = 51;
            this.dataGridMasini.RowTemplate.Height = 24;
            this.dataGridMasini.Size = new System.Drawing.Size(1251, 641);
            this.dataGridMasini.TabIndex = 12;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(118)))), ((int)(((byte)(28)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(24, 768);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(191, 50);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // cbxSearch
            // 
            this.cbxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSearch.FormattingEnabled = true;
            this.cbxSearch.Items.AddRange(new object[] {
            "Niciun criteriu",
            "Model",
            "Marca",
            "Transmisie",
            "Clasa",
            "Nr. inmatriculare",
            "Locuri",
            "Interval  pret",
            "Alimentare",
            "Culoare",
            "Disponibilitate"});
            this.cbxSearch.Location = new System.Drawing.Point(371, 92);
            this.cbxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSearch.Name = "cbxSearch";
            this.cbxSearch.Size = new System.Drawing.Size(212, 32);
            this.cbxSearch.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(185)))), ((int)(((byte)(65)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(239, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 32);
            this.label8.TabIndex = 40;
            this.label8.Text = "Caută:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCauta
            // 
            this.txtCauta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCauta.Location = new System.Drawing.Point(612, 92);
            this.txtCauta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.Size = new System.Drawing.Size(876, 30);
            this.txtCauta.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(118)))), ((int)(((byte)(28)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(240, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1249, 53);
            this.label2.TabIndex = 42;
            this.label2.Text = "Masini";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(118)))), ((int)(((byte)(28)))));
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.Location = new System.Drawing.Point(24, 148);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(191, 50);
            this.btnModify.TabIndex = 43;
            this.btnModify.Text = "Modifică";
            this.btnModify.UseVisualStyleBackColor = false;
            // 
            // Masini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(228)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(1581, 853);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCauta);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridMasini);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Masini";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masini";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMasini)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridMasini;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbxSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCauta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModify;
    }
}