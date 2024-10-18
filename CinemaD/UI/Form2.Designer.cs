namespace CinemaD.UI
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddKV = new System.Windows.Forms.Button();
            this.txtAddTenKV = new System.Windows.Forms.TextBox();
            this.txtAddMaKV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoatKV = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSuaKV = new System.Windows.Forms.Button();
            this.btnXoaKV = new System.Windows.Forms.Button();
            this.datagridKhuVuc = new System.Windows.Forms.DataGridView();
            this.MaKhuVucGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhuVucGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagridKhuVuc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Khu Vực";
            // 
            // btnAddKV
            // 
            this.btnAddKV.Location = new System.Drawing.Point(24, 463);
            this.btnAddKV.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddKV.Name = "btnAddKV";
            this.btnAddKV.Size = new System.Drawing.Size(61, 34);
            this.btnAddKV.TabIndex = 1;
            this.btnAddKV.Text = "Thêm";
            this.btnAddKV.UseVisualStyleBackColor = true;
            this.btnAddKV.Click += new System.EventHandler(this.btnAddKV_Click_1);
            // 
            // txtAddTenKV
            // 
            this.txtAddTenKV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddTenKV.Location = new System.Drawing.Point(186, 123);
            this.txtAddTenKV.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddTenKV.Name = "txtAddTenKV";
            this.txtAddTenKV.Size = new System.Drawing.Size(182, 27);
            this.txtAddTenKV.TabIndex = 2;
            // 
            // txtAddMaKV
            // 
            this.txtAddMaKV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddMaKV.Location = new System.Drawing.Point(186, 169);
            this.txtAddMaKV.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddMaKV.Name = "txtAddMaKV";
            this.txtAddMaKV.Size = new System.Drawing.Size(182, 27);
            this.txtAddMaKV.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Định Danh";
            // 
            // btnThoatKV
            // 
            this.btnThoatKV.Location = new System.Drawing.Point(271, 463);
            this.btnThoatKV.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoatKV.Name = "btnThoatKV";
            this.btnThoatKV.Size = new System.Drawing.Size(94, 34);
            this.btnThoatKV.TabIndex = 5;
            this.btnThoatKV.Text = "Thoát";
            this.btnThoatKV.UseVisualStyleBackColor = true;
            this.btnThoatKV.Click += new System.EventHandler(this.btnThoatKV_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quản Lý Khu Vực";
            // 
            // btnSuaKV
            // 
            this.btnSuaKV.Location = new System.Drawing.Point(108, 463);
            this.btnSuaKV.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaKV.Name = "btnSuaKV";
            this.btnSuaKV.Size = new System.Drawing.Size(58, 34);
            this.btnSuaKV.TabIndex = 8;
            this.btnSuaKV.Text = "Sửa";
            this.btnSuaKV.UseVisualStyleBackColor = true;
            this.btnSuaKV.Click += new System.EventHandler(this.btnSuaKV_Click_1);
            // 
            // btnXoaKV
            // 
            this.btnXoaKV.Location = new System.Drawing.Point(190, 463);
            this.btnXoaKV.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaKV.Name = "btnXoaKV";
            this.btnXoaKV.Size = new System.Drawing.Size(58, 34);
            this.btnXoaKV.TabIndex = 9;
            this.btnXoaKV.Text = "Xóa";
            this.btnXoaKV.UseVisualStyleBackColor = true;
            this.btnXoaKV.Click += new System.EventHandler(this.btnXoaKV_Click_1);
            // 
            // datagridKhuVuc
            // 
            this.datagridKhuVuc.AllowUserToAddRows = false;
            this.datagridKhuVuc.AllowUserToDeleteRows = false;
            this.datagridKhuVuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridKhuVuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKhuVucGrid,
            this.TenKhuVucGrid});
            this.datagridKhuVuc.Location = new System.Drawing.Point(54, 215);
            this.datagridKhuVuc.Name = "datagridKhuVuc";
            this.datagridKhuVuc.ReadOnly = true;
            this.datagridKhuVuc.RowHeadersWidth = 51;
            this.datagridKhuVuc.RowTemplate.Height = 24;
            this.datagridKhuVuc.Size = new System.Drawing.Size(371, 227);
            this.datagridKhuVuc.TabIndex = 10;
            this.datagridKhuVuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridKhuVuc_CellClick);
            // 
            // MaKhuVucGrid
            // 
            this.MaKhuVucGrid.HeaderText = "Mã Khu Vực";
            this.MaKhuVucGrid.MinimumWidth = 6;
            this.MaKhuVucGrid.Name = "MaKhuVucGrid";
            this.MaKhuVucGrid.ReadOnly = true;
            this.MaKhuVucGrid.Width = 125;
            // 
            // TenKhuVucGrid
            // 
            this.TenKhuVucGrid.HeaderText = "Tên Khu Vực";
            this.TenKhuVucGrid.MinimumWidth = 6;
            this.TenKhuVucGrid.Name = "TenKhuVucGrid";
            this.TenKhuVucGrid.ReadOnly = true;
            this.TenKhuVucGrid.Width = 125;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 688);
            this.Controls.Add(this.datagridKhuVuc);
            this.Controls.Add(this.btnXoaKV);
            this.Controls.Add(this.btnSuaKV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnThoatKV);
            this.Controls.Add(this.txtAddMaKV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddTenKV);
            this.Controls.Add(this.btnAddKV);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.datagridKhuVuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddKV;
        private System.Windows.Forms.TextBox txtAddTenKV;
        private System.Windows.Forms.TextBox txtAddMaKV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoatKV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSuaKV;
        private System.Windows.Forms.Button btnXoaKV;
        private System.Windows.Forms.DataGridView datagridKhuVuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhuVucGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhuVucGrid;
    }
}