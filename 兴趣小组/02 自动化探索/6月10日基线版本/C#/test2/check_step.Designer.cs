namespace test2
{
    partial class check_step
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.check_name_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.page_name_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.element_name_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.all_edit_button = new System.Windows.Forms.Button();
            this.query_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.select_Column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_order_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_point_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.page_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.element_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysname_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_Column = new System.Windows.Forms.DataGridViewButtonColumn();
            this.del_Column = new System.Windows.Forms.DataGridViewButtonColumn();
            this.check_sysname_comboBox = new System.Windows.Forms.ComboBox();
            this.select_cancel_button = new System.Windows.Forms.Button();
            this.choose_Inverse_button = new System.Windows.Forms.Button();
            this.choose_all_button = new System.Windows.Forms.Button();
            this.export_button = new System.Windows.Forms.Button();
            this.import_button = new System.Windows.Forms.Button();
            this.all_del_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "被测系统名称：";
            // 
            // check_name_textBox
            // 
            this.check_name_textBox.Location = new System.Drawing.Point(392, 9);
            this.check_name_textBox.Name = "check_name_textBox";
            this.check_name_textBox.Size = new System.Drawing.Size(137, 21);
            this.check_name_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "检查点名称：";
            // 
            // page_name_textBox
            // 
            this.page_name_textBox.Location = new System.Drawing.Point(115, 44);
            this.page_name_textBox.Name = "page_name_textBox";
            this.page_name_textBox.Size = new System.Drawing.Size(136, 21);
            this.page_name_textBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "页面名称：";
            // 
            // element_name_textBox
            // 
            this.element_name_textBox.Location = new System.Drawing.Point(391, 44);
            this.element_name_textBox.Name = "element_name_textBox";
            this.element_name_textBox.Size = new System.Drawing.Size(136, 21);
            this.element_name_textBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "元素名称：";
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(484, 89);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 10;
            this.add_button.Text = "增加";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // all_edit_button
            // 
            this.all_edit_button.Location = new System.Drawing.Point(404, 89);
            this.all_edit_button.Name = "all_edit_button";
            this.all_edit_button.Size = new System.Drawing.Size(75, 23);
            this.all_edit_button.TabIndex = 9;
            this.all_edit_button.Text = "批量修改";
            this.all_edit_button.UseVisualStyleBackColor = true;
            this.all_edit_button.Click += new System.EventHandler(this.all_edit_button_Click);
            // 
            // query_button
            // 
            this.query_button.Location = new System.Drawing.Point(324, 89);
            this.query_button.Name = "query_button";
            this.query_button.Size = new System.Drawing.Size(75, 23);
            this.query_button.TabIndex = 8;
            this.query_button.Text = "查询";
            this.query_button.UseVisualStyleBackColor = true;
            this.query_button.Click += new System.EventHandler(this.query_button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select_Column,
            this.id_Column,
            this.check_order_Column,
            this.check_point_name_Column,
            this.page_name_Column,
            this.element_name_Column,
            this.sysname_Column,
            this.edit_Column,
            this.del_Column});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(770, 325);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // select_Column
            // 
            this.select_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.select_Column.HeaderText = "选择";
            this.select_Column.Name = "select_Column";
            this.select_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.select_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.select_Column.Width = 51;
            // 
            // id_Column
            // 
            this.id_Column.DataPropertyName = "序号";
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.id_Column.DefaultCellStyle = dataGridViewCellStyle8;
            this.id_Column.HeaderText = "序号";
            this.id_Column.Name = "id_Column";
            this.id_Column.ReadOnly = true;
            this.id_Column.Width = 55;
            // 
            // check_order_Column
            // 
            this.check_order_Column.DataPropertyName = "执行顺序";
            this.check_order_Column.HeaderText = "执行顺序";
            this.check_order_Column.Name = "check_order_Column";
            // 
            // check_point_name_Column
            // 
            this.check_point_name_Column.DataPropertyName = "检查点名称";
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.check_point_name_Column.DefaultCellStyle = dataGridViewCellStyle9;
            this.check_point_name_Column.HeaderText = "检查点名称";
            this.check_point_name_Column.Name = "check_point_name_Column";
            this.check_point_name_Column.ReadOnly = true;
            // 
            // page_name_Column
            // 
            this.page_name_Column.DataPropertyName = "页面名称";
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.page_name_Column.DefaultCellStyle = dataGridViewCellStyle10;
            this.page_name_Column.HeaderText = "页面名称";
            this.page_name_Column.Name = "page_name_Column";
            this.page_name_Column.ReadOnly = true;
            // 
            // element_name_Column
            // 
            this.element_name_Column.DataPropertyName = "元素名称";
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.element_name_Column.DefaultCellStyle = dataGridViewCellStyle11;
            this.element_name_Column.HeaderText = "元素名称";
            this.element_name_Column.Name = "element_name_Column";
            this.element_name_Column.ReadOnly = true;
            // 
            // sysname_Column
            // 
            this.sysname_Column.DataPropertyName = "被测系统名称";
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.sysname_Column.DefaultCellStyle = dataGridViewCellStyle12;
            this.sysname_Column.HeaderText = "被测系统名称";
            this.sysname_Column.Name = "sysname_Column";
            this.sysname_Column.ReadOnly = true;
            this.sysname_Column.Width = 110;
            // 
            // edit_Column
            // 
            this.edit_Column.DataPropertyName = "编辑";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.edit_Column.DefaultCellStyle = dataGridViewCellStyle13;
            this.edit_Column.HeaderText = "编辑";
            this.edit_Column.Name = "edit_Column";
            this.edit_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit_Column.Width = 55;
            // 
            // del_Column
            // 
            this.del_Column.DataPropertyName = "删除";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.del_Column.DefaultCellStyle = dataGridViewCellStyle14;
            this.del_Column.HeaderText = "删除";
            this.del_Column.Name = "del_Column";
            this.del_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.del_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.del_Column.Width = 55;
            // 
            // check_sysname_comboBox
            // 
            this.check_sysname_comboBox.FormattingEnabled = true;
            this.check_sysname_comboBox.Items.AddRange(new object[] {
            "请选择",
            "YES",
            "NO"});
            this.check_sysname_comboBox.Location = new System.Drawing.Point(115, 11);
            this.check_sysname_comboBox.Name = "check_sysname_comboBox";
            this.check_sysname_comboBox.Size = new System.Drawing.Size(136, 20);
            this.check_sysname_comboBox.TabIndex = 39;
            // 
            // select_cancel_button
            // 
            this.select_cancel_button.Location = new System.Drawing.Point(82, 89);
            this.select_cancel_button.Name = "select_cancel_button";
            this.select_cancel_button.Size = new System.Drawing.Size(75, 23);
            this.select_cancel_button.TabIndex = 42;
            this.select_cancel_button.Text = "取消";
            this.select_cancel_button.UseVisualStyleBackColor = true;
            this.select_cancel_button.Click += new System.EventHandler(this.select_cancel_button_Click);
            // 
            // choose_Inverse_button
            // 
            this.choose_Inverse_button.Location = new System.Drawing.Point(161, 89);
            this.choose_Inverse_button.Name = "choose_Inverse_button";
            this.choose_Inverse_button.Size = new System.Drawing.Size(75, 23);
            this.choose_Inverse_button.TabIndex = 41;
            this.choose_Inverse_button.Text = "反选";
            this.choose_Inverse_button.UseVisualStyleBackColor = true;
            this.choose_Inverse_button.Click += new System.EventHandler(this.choose_Inverse_button_Click);
            // 
            // choose_all_button
            // 
            this.choose_all_button.Location = new System.Drawing.Point(3, 89);
            this.choose_all_button.Name = "choose_all_button";
            this.choose_all_button.Size = new System.Drawing.Size(75, 23);
            this.choose_all_button.TabIndex = 40;
            this.choose_all_button.Text = "全选";
            this.choose_all_button.UseVisualStyleBackColor = true;
            this.choose_all_button.Click += new System.EventHandler(this.choose_all_button_Click);
            // 
            // export_button
            // 
            this.export_button.Location = new System.Drawing.Point(565, 88);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(75, 23);
            this.export_button.TabIndex = 59;
            this.export_button.Text = "导出excel";
            this.export_button.UseVisualStyleBackColor = true;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // import_button
            // 
            this.import_button.Location = new System.Drawing.Point(646, 88);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(75, 23);
            this.import_button.TabIndex = 58;
            this.import_button.Text = "导入excel";
            this.import_button.UseVisualStyleBackColor = true;
            this.import_button.Click += new System.EventHandler(this.import_button_Click);
            // 
            // all_del_button
            // 
            this.all_del_button.Location = new System.Drawing.Point(242, 89);
            this.all_del_button.Name = "all_del_button";
            this.all_del_button.Size = new System.Drawing.Size(75, 23);
            this.all_del_button.TabIndex = 60;
            this.all_del_button.Text = "批量删除";
            this.all_del_button.UseVisualStyleBackColor = true;
            this.all_del_button.Click += new System.EventHandler(this.all_del_button_Click);
            // 
            // check_step
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 443);
            this.Controls.Add(this.all_del_button);
            this.Controls.Add(this.export_button);
            this.Controls.Add(this.import_button);
            this.Controls.Add(this.select_cancel_button);
            this.Controls.Add(this.choose_Inverse_button);
            this.Controls.Add(this.choose_all_button);
            this.Controls.Add(this.check_sysname_comboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.all_edit_button);
            this.Controls.Add(this.query_button);
            this.Controls.Add(this.element_name_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.page_name_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.check_name_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "check_step";
            this.Text = "检查点步骤";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox check_name_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox page_name_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox element_name_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button all_edit_button;
        private System.Windows.Forms.Button query_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox check_sysname_comboBox;
        private System.Windows.Forms.Button select_cancel_button;
        private System.Windows.Forms.Button choose_Inverse_button;
        private System.Windows.Forms.Button choose_all_button;
        private System.Windows.Forms.Button export_button;
        private System.Windows.Forms.Button import_button;
        private System.Windows.Forms.Button all_del_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_order_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_point_name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn page_name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn element_name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn sysname_Column;
        private System.Windows.Forms.DataGridViewButtonColumn edit_Column;
        private System.Windows.Forms.DataGridViewButtonColumn del_Column;
    }
}