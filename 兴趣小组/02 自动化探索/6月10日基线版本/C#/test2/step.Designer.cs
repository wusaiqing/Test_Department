namespace test2
{
    partial class step
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.query_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.select_Column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.test_order_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.function_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.page_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.element_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysname_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_Column = new System.Windows.Forms.DataGridViewButtonColumn();
            this.del_Column = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.add_button = new System.Windows.Forms.Button();
            this.sysname_comboBox = new System.Windows.Forms.ComboBox();
            this.function_name_comboBox = new System.Windows.Forms.ComboBox();
            this.select_c_button = new System.Windows.Forms.Button();
            this.all_del_button = new System.Windows.Forms.Button();
            this.select_Inverse_button = new System.Windows.Forms.Button();
            this.select_all_button = new System.Windows.Forms.Button();
            this.export_button = new System.Windows.Forms.Button();
            this.import_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "被测系统名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "功能点名称：";
            // 
            // query_button
            // 
            this.query_button.Location = new System.Drawing.Point(333, 46);
            this.query_button.Name = "query_button";
            this.query_button.Size = new System.Drawing.Size(75, 23);
            this.query_button.TabIndex = 4;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select_Column,
            this.id_Column,
            this.test_order_Column,
            this.function_name_Column,
            this.page_name_Column,
            this.element_name_Column,
            this.sysname_Column,
            this.edit_Column,
            this.del_Column});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.Location = new System.Drawing.Point(1, 75);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(856, 331);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // select_Column
            // 
            this.select_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.select_Column.HeaderText = "选择";
            this.select_Column.Name = "select_Column";
            this.select_Column.Width = 32;
            // 
            // id_Column
            // 
            this.id_Column.DataPropertyName = "序号";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.id_Column.DefaultCellStyle = dataGridViewCellStyle2;
            this.id_Column.HeaderText = "序号";
            this.id_Column.Name = "id_Column";
            this.id_Column.ReadOnly = true;
            this.id_Column.Width = 55;
            // 
            // test_order_Column
            // 
            this.test_order_Column.DataPropertyName = "执行顺序";
            this.test_order_Column.HeaderText = "执行顺序";
            this.test_order_Column.Name = "test_order_Column";
            this.test_order_Column.Width = 90;
            // 
            // function_name_Column
            // 
            this.function_name_Column.DataPropertyName = "功能点名称";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.function_name_Column.DefaultCellStyle = dataGridViewCellStyle3;
            this.function_name_Column.HeaderText = "功能点名称";
            this.function_name_Column.Name = "function_name_Column";
            this.function_name_Column.ReadOnly = true;
            // 
            // page_name_Column
            // 
            this.page_name_Column.DataPropertyName = "页面名称";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.page_name_Column.DefaultCellStyle = dataGridViewCellStyle4;
            this.page_name_Column.HeaderText = "页面名称";
            this.page_name_Column.Name = "page_name_Column";
            this.page_name_Column.ReadOnly = true;
            // 
            // element_name_Column
            // 
            this.element_name_Column.DataPropertyName = "元素名称";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.element_name_Column.DefaultCellStyle = dataGridViewCellStyle5;
            this.element_name_Column.HeaderText = "元素名称";
            this.element_name_Column.Name = "element_name_Column";
            this.element_name_Column.ReadOnly = true;
            // 
            // sysname_Column
            // 
            this.sysname_Column.DataPropertyName = "被测系统名称";
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.sysname_Column.DefaultCellStyle = dataGridViewCellStyle6;
            this.sysname_Column.HeaderText = "被测系统名称";
            this.sysname_Column.Name = "sysname_Column";
            this.sysname_Column.ReadOnly = true;
            this.sysname_Column.Width = 120;
            // 
            // edit_Column
            // 
            this.edit_Column.DataPropertyName = "编辑";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.edit_Column.DefaultCellStyle = dataGridViewCellStyle7;
            this.edit_Column.HeaderText = "编辑";
            this.edit_Column.Name = "edit_Column";
            this.edit_Column.Width = 55;
            // 
            // del_Column
            // 
            this.del_Column.DataPropertyName = "删除";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.del_Column.DefaultCellStyle = dataGridViewCellStyle8;
            this.del_Column.HeaderText = "删除";
            this.del_Column.Name = "del_Column";
            this.del_Column.Width = 55;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "批量修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(495, 46);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 7;
            this.add_button.Text = "增加";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // sysname_comboBox
            // 
            this.sysname_comboBox.FormattingEnabled = true;
            this.sysname_comboBox.Items.AddRange(new object[] {
            "请选择",
            "YES",
            "NO"});
            this.sysname_comboBox.Location = new System.Drawing.Point(101, 10);
            this.sysname_comboBox.Name = "sysname_comboBox";
            this.sysname_comboBox.Size = new System.Drawing.Size(111, 20);
            this.sysname_comboBox.TabIndex = 38;
            this.sysname_comboBox.SelectedValueChanged += new System.EventHandler(this.sysname_comboBox_SelectedValueChanged);
            // 
            // function_name_comboBox
            // 
            this.function_name_comboBox.FormattingEnabled = true;
            this.function_name_comboBox.Location = new System.Drawing.Point(285, 10);
            this.function_name_comboBox.Name = "function_name_comboBox";
            this.function_name_comboBox.Size = new System.Drawing.Size(100, 20);
            this.function_name_comboBox.TabIndex = 37;
            // 
            // select_c_button
            // 
            this.select_c_button.Location = new System.Drawing.Point(85, 46);
            this.select_c_button.Name = "select_c_button";
            this.select_c_button.Size = new System.Drawing.Size(75, 23);
            this.select_c_button.TabIndex = 42;
            this.select_c_button.Text = "取消";
            this.select_c_button.UseVisualStyleBackColor = true;
            this.select_c_button.Click += new System.EventHandler(this.select_c_button_Click);
            // 
            // all_del_button
            // 
            this.all_del_button.Location = new System.Drawing.Point(248, 46);
            this.all_del_button.Name = "all_del_button";
            this.all_del_button.Size = new System.Drawing.Size(75, 23);
            this.all_del_button.TabIndex = 41;
            this.all_del_button.Text = "批量删除";
            this.all_del_button.UseVisualStyleBackColor = true;
            this.all_del_button.Click += new System.EventHandler(this.all_del_button_Click);
            // 
            // select_Inverse_button
            // 
            this.select_Inverse_button.Location = new System.Drawing.Point(165, 46);
            this.select_Inverse_button.Name = "select_Inverse_button";
            this.select_Inverse_button.Size = new System.Drawing.Size(75, 23);
            this.select_Inverse_button.TabIndex = 40;
            this.select_Inverse_button.Text = "反选";
            this.select_Inverse_button.UseVisualStyleBackColor = true;
            this.select_Inverse_button.Click += new System.EventHandler(this.select_Inverse_button_Click);
            // 
            // select_all_button
            // 
            this.select_all_button.Location = new System.Drawing.Point(6, 46);
            this.select_all_button.Name = "select_all_button";
            this.select_all_button.Size = new System.Drawing.Size(75, 23);
            this.select_all_button.TabIndex = 39;
            this.select_all_button.Text = "全选";
            this.select_all_button.UseVisualStyleBackColor = true;
            this.select_all_button.Click += new System.EventHandler(this.select_all_button_Click);
            // 
            // export_button
            // 
            this.export_button.Location = new System.Drawing.Point(576, 46);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(75, 23);
            this.export_button.TabIndex = 59;
            this.export_button.Text = "导出excel";
            this.export_button.UseVisualStyleBackColor = true;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // import_button
            // 
            this.import_button.Location = new System.Drawing.Point(658, 45);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(75, 23);
            this.import_button.TabIndex = 58;
            this.import_button.Text = "导入excel";
            this.import_button.UseVisualStyleBackColor = true;
            this.import_button.Click += new System.EventHandler(this.import_button_Click);
            // 
            // step
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 412);
            this.Controls.Add(this.export_button);
            this.Controls.Add(this.import_button);
            this.Controls.Add(this.select_c_button);
            this.Controls.Add(this.all_del_button);
            this.Controls.Add(this.select_Inverse_button);
            this.Controls.Add(this.select_all_button);
            this.Controls.Add(this.sysname_comboBox);
            this.Controls.Add(this.function_name_comboBox);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.query_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "step";
            this.Text = "组装测试步骤";
            this.Load += new System.EventHandler(this.step_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button query_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.ComboBox sysname_comboBox;
        private System.Windows.Forms.ComboBox function_name_comboBox;
        private System.Windows.Forms.Button select_c_button;
        private System.Windows.Forms.Button all_del_button;
        private System.Windows.Forms.Button select_Inverse_button;
        private System.Windows.Forms.Button select_all_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn test_order_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn function_name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn page_name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn element_name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn sysname_Column;
        private System.Windows.Forms.DataGridViewButtonColumn edit_Column;
        private System.Windows.Forms.DataGridViewButtonColumn del_Column;
        private System.Windows.Forms.Button export_button;
        private System.Windows.Forms.Button import_button;
    }
}