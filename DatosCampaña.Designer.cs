
namespace Control_Pagos.Presentacion
{
    partial class DatosCampaña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatosCampaña));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NOMBRE_CAMPAÑA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO_CAMPAÑA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASIGNADO_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOMBRE_CAMPAÑA,
            this.NUMERO_CAMPAÑA,
            this.ASIGNADO_A});
            this.dataGridView1.Location = new System.Drawing.Point(67, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(654, 253);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // NOMBRE_CAMPAÑA
            // 
            this.NOMBRE_CAMPAÑA.DataPropertyName = "NOMBRE_CAMPAÑA";
            this.NOMBRE_CAMPAÑA.HeaderText = "NOMBRE CAMPAÑA";
            this.NOMBRE_CAMPAÑA.Name = "NOMBRE_CAMPAÑA";
            // 
            // NUMERO_CAMPAÑA
            // 
            this.NUMERO_CAMPAÑA.DataPropertyName = "NUMERO_CAMPAÑA";
            this.NUMERO_CAMPAÑA.HeaderText = "NUMERO CAMPAÑA";
            this.NUMERO_CAMPAÑA.Name = "NUMERO_CAMPAÑA";
            // 
            // ASIGNADO_A
            // 
            this.ASIGNADO_A.DataPropertyName = "ASIGNADO_A";
            this.ASIGNADO_A.HeaderText = "ASIGNADO A";
            this.ASIGNADO_A.Name = "ASIGNADO_A";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(638, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 49);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Asignado A:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(73, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // DatosCampaña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DatosCampaña";
            this.Text = "DatosCampaña";
            this.Load += new System.EventHandler(this.DatosCampaña_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_CAMPAÑA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO_CAMPAÑA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASIGNADO_A;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}