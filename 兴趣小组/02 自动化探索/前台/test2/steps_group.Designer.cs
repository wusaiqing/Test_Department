namespace test2
{
    partial class steps_group
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
            this.steps_sysname_comboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.add_button = new System.Windows.Forms.Button();
            this.all_edit_button = new System.Windows.Forms.Button();
            this.query_button = new System.Windows.Forms.Button();
            this.element_name_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.page_name_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.steps_name_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.select_cancel_button = new System.Windows.Forms.Button();
            this.all_del_button = new System.Windows.Forms.Button();
            this.choose_Inverse_button = new System.Windows.Forms.Button();
            this.choose_all_button = new System.Windows.Forms.Button();
            this.export_button = new System.Windows.Forms.Button();
            this.import_button = new System.Windows.Forms.Button();
            this.select_Column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.steps_order_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.steps_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.page_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.element_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysname_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_Column = new System.Windows.Forms.DataGridViewButtonColumn();
            this.del_Column = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // steps_sysname_comboBox
            // 
            this.steps_sysname_comboBox.FormattingEnabled = true;
            this.steps_sysname_comboBox.Items.AddRange(new object[] {
            "请选择",
            "YES",
            "NO"});
            this.steps_sysname_comboBox.Location = new System.Drawing.Point(128, 6);
            this.steps_sysname_comboBox.Name = "steps_sysname_comboBox";
            this.steps_sysname_comboBox.Size = new System.Drawing.Size(136, 20);
            this.steps_sysname_comboBox.TabIndex = 51;
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
            this.steps_order_Column,
            this.steps_name_Column,
            this.page_name_Column,
            this.element_name_Column,
            this.sysname_Column,
            this.edit_Column,
            this.del_Column});
            this.dataGridView1.Location = new System.Drawing.Point(12, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(790, 325);
            this.dataGridView1.TabIndex = 50;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(493, 84);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 49;
            this.add_button.Text = "增加";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // all_edit_button
            // 
            this.all_edit_button.Location = new System.Drawing.Point(411, 84);
            this.all_edit_button.Name = "all_edit_button";
            this.all_edit_button.Size = new System.Drawing.Size(75, 23);
            this.all_edit_button.TabIndex = 48;
            this.all_edit_button.Text = "批量修改";
            this.all_edit_button.UseVisualStyleBackColor = true;
            this.all_edit_button.Click += new System.EventHandler(this.all_edit_button_Click);
            // 
            // query_button
            // 
            this.query_button.Location = new System.Drawing.Point(330, 84);
            this.query_button.Name = "query_button";
            this.query_button.Size = new System.Drawing.Size(75, 23);
            this.query_button.TabIndex = 47;
            this.query_button.Text = "查询";
            this.query_button.UseVisualStyleBackColor = true;
            this.query_button.Click += new System.EventHandler(this.query_button_Click);
            // 
            // element_name_textBox
            // 
            this.element_name_textBox.Location = new System.Drawing.Point(404, 39);
            this.element_name_textBox.Name = "element_name_textBox";
            this.element_name_textBox.Size = new System.Drawing.Size(136, 21);
            this.element_name_textBox.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 45;
            this.label4.Text = "元素名称：";
            // 
            // page_name_textBox
            // 
            this.page_name_textBox.Location = new System.Drawing.Point(128, 39);
            this.page_name_textBox.Name = "page_name_textBox";
            this.page_name_textBox.Size = new System.Drawing.Size(136, 21);
            this.page_name_textBox.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "页面名称：";
            // 
            // steps_name_textBox
            // 
            this.steps_name_textBox.Location = new System.Drawing.Point(405, 4);
            this.steps_name_textBox.Name = "steps_name_textBox";
            this.steps_name_textBox.Size = new System.Drawing.Size(137, 21);
            this.steps_name_textBox.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "步骤组名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "被测系统名称：";
            // 
            // select_cancel_button
            // 
            this.select_cancel_button.Location = new System.Drawing.Point(90, 84);
            this.select_cancel_button.Name = "select_cancel_button";
            this.select_cancel_button.Size = new System.Drawing.Size(75, 23);
            this.select_cancel_button.TabIndex = 55;
            this.select_cancel_button.Text = "取消";
            this.select_cancel_button.UseVisualStyleBackColor = true;
            this.select_cancel_button.Click += new System.EventHandler(this.select_cancel_button_Click);
            // 
            // all_del_button
            // 
            this.all_del_button.Location = new System.Drawing.Point(248, 84);
            this.all_del_button.Name = "all_del_button";
            this.all_del_button.Size = new System.Drawing.Size(75, 23);
            this.all_del_button.TabIndex = 54;
            this.all_del_button.Text = "批量删除";
            this.all_del_button.UseVisualStyleBackColor = true;
            this.all_del_button.Click += new System.EventHandler(this.all_del_button_Click);
            // 
            // choose_Inverse_button
            // 
            this.choose_Inverse_button.Location = new System.Drawing.Point(169, 84);
            this.choose_Inverse_button.Name = "choose_Inverse_button";
            this.choose_Inverse_button.Size = new System.Drawing.Size(75, 23);
            this.choose_Inverse_button.TabIndex = 53;
            this.choose_Inverse_button.Text = "反选";
            this.choose_Inverse_button.UseVisualStyleBackColor = true;
            this.choose_Inverse_button.Click += new System.EventHandler(this.choose_Inverse_button_Click);
            // 
            // choose_all_button
            // 
            this.choose_all_button.Location = new System.Drawing.Point(11, 84);
            this.choose_all_button.Name = "choose_all_button";
            this.choose_all_button.Size = new System.Drawing.Size(75, 23);
            this.choose_all_button.TabIndex = 52;
            this.choose_all_button.Text = "全选";
            this.choose_all_button.UseVisualStyleBackColor = true;
            this.choose_all_button.Click += new System.EventHandler(this.choose_all_button_Click);
            // 
            // export_button
            // 
            this.export_button.Location = new System.Drawing.Point(572, 84);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(75, 23);
            this.export_button.TabIndex = 57;
            this.export_button.Text = "导出excel";
            this.export_button.UseVisualStyleBackColor = true;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // import_button
            // 
            this.import_button.Location = new System.Drawing.Point(654, 83);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(75, 23);
            this.import_button.TabIndex = 56;
            this.import_button.Text = "导入excel";
            this.import_button.UseVisualStyleBackColor = true;
            this.import_button.Click += new System.EventHandler(this.import_button_Click);
            // 
            // select_Column
            // 
            this.select_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.select_Column.HeaderText = "选择";
            this.select_Column.Name = "select_Column";
            this.select_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.select_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.select_Column.Width = 54;
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
            // steps_order_Column
            // 
            this.steps_order_Column.DataPropertyName = "执行顺序";
            this.steps_order_Column.HeaderText = "执行顺序";
            this.steps_order_Column.Name = "steps_order_Column";
            // 
            // steps_name_Column
            // 
            this.steps_name_Column.DataPropertyName = "步骤组名称";
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.steps_name_Column.DefaultCellStyle = dataGridViewCellStyle9;
            this.steps_name_Column.HeaderText = "步骤组名称";
            this.steps_name_Column.Name = "steps_name_Column";
            this.steps_name_Column.ReadOnly = true;
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
            // steps_group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 445);
            this.Controls.Add(this.export_button);
            this.Controls.Add(this.import_button);
            this.Controls.Add(this.select_cancel_button);
            this.Controls.Add(this.all_del_button);
            this.Controls.Add(this.choose_Inverse_button);
            this.Controls.Add(this.choose_all_button);
            this.Controls.Add(this.steps_sysname_comboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.all_edit_button);
            this.Controls.Add(this.query_button);
            this.Controls.Add(this.element_name_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.page_name_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.steps_name_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "steps_group";
            this.Text = "步骤组";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox steps_sysname_comboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button all_edit_button;
        private System.Windows.Forms.Button query_button;
        private System.Windows.Forms.TextBox element_name_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox page_name_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox steps_name_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button select_cancel_button;
        private System.Windows.Forms.Button all_del_button;
        private System.Windows.Forms.Button choose_Inverse_button;
        private System.Windows.Forms.Button choose_all_button;
        private System.Windows.Forms.Button export_button;
        private System.Windows.Forms.Button import_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn steps_order_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn steps_name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn page_name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn element_name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn sysname_Column;
        private System.Windows.Forms.DataGridViewButtonColumn edit_Column;
        private System.Windows.Forms.DataGridViewButtonColumn del_Column;
    }
}