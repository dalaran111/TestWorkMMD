namespace TestWorkMMD
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Название = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Код_страны = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Столица = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Площадь = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Население = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Регион = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDBDataSet = new TestWorkMMD.CountryDBDataSet();
            this.countryDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryDBDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Название,
            this.Код_страны,
            this.Столица,
            this.Площадь,
            this.Население,
            this.Регион});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(746, 271);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            // 
            // Название
            // 
            this.Название.HeaderText = "Название";
            this.Название.Name = "Название";
            // 
            // Код_страны
            // 
            this.Код_страны.HeaderText = "Код страны";
            this.Код_страны.Name = "Код_страны";
            // 
            // Столица
            // 
            this.Столица.HeaderText = "Столица";
            this.Столица.Name = "Столица";
            // 
            // Площадь
            // 
            this.Площадь.HeaderText = "Площадь";
            this.Площадь.Name = "Площадь";
            // 
            // Население
            // 
            this.Население.HeaderText = "Население";
            this.Население.Name = "Население";
            // 
            // Регион
            // 
            this.Регион.HeaderText = "Регион";
            this.Регион.Name = "Регион";
            // 
            // countryDBDataSet
            // 
            this.countryDBDataSet.DataSetName = "CountryDBDataSet";
            this.countryDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // countryDBDataSetBindingSource
            // 
            this.countryDBDataSetBindingSource.DataSource = this.countryDBDataSet;
            this.countryDBDataSetBindingSource.Position = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "Найти страну";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 289);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(655, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 371);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryDBDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Название;
        private System.Windows.Forms.DataGridViewTextBoxColumn Код_страны;
        private System.Windows.Forms.DataGridViewTextBoxColumn Столица;
        private System.Windows.Forms.DataGridViewTextBoxColumn Площадь;
        private System.Windows.Forms.DataGridViewTextBoxColumn Население;
        private System.Windows.Forms.DataGridViewTextBoxColumn Регион;
        private System.Windows.Forms.BindingSource countryDBDataSetBindingSource;
        private CountryDBDataSet countryDBDataSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}