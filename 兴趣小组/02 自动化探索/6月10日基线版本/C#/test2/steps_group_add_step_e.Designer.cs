namespace test2
{
    partial class steps_group_add_step_e
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
            this.select_a_button = new System.Windows.Forms.Button();
            this.select_c_button = new System.Windows.Forms.Button();
            this.select_all_button = new System.Windows.Forms.Button();
            this.check_step_a_button = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.choose_Column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.page_name_e_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.element_name_e_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysname_e_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // select_a_button
            // 
            this.select_a_button.Location = new System.Drawing.Point(173, 7);
            this.select_a_button.Name = "select_a_button";
            this.select_a_button.Size = new System.Drawing.Size(75, 23);
            this.select_a_button.TabIndex = 57;
            this.select_a_button.Text = "反选";
            this.select_a_button.UseVisualStyleBackColor = true;
            this.select_a_button.Click += new System.EventHandler(this.select_a_button_Click);
            // 
            // select_c_button
            // 
            this.select_c_button.Location = new System.Drawing.Point(92, 7);
            this.select_c_button.Name = "select_c_button";
            this.select_c_button.Size = new System.Drawing.Size(75, 23);
            this.select_c_button.TabIndex = 56;
            this.select_c_button.Text = "取消";
            this.select_c_button.UseVisualStyleBackColor = true;
            this.select_c_button.Click += new System.EventHandler(this.select_c_button_Click);
            // 
            // select_all_button
            // 
            this.select_all_button.Location = new System.Drawing.Point(11, 7);
            this.select_all_button.Name = "select_all_button";
            this.select_all_button.Size = new System.Drawing.Size(75, 23);
            this.select_all_button.TabIndex = 55;
            this.select_all_button.Text = "全选";
            this.select_all_button.UseVisualStyleBackColor = true;
            this.select_all_button.Click += new System.EventHandler(this.select_all_button_Click);
            // 
            // check_step_a_button
            // 
            this.check_step_a_button.Location = new System.Drawing.Point(254, 7);
            this.check_step_a_button.Name = "check_step_a_button";
            this.check_step_a_button.Size = new System.Drawing.Size(75, 23);
            this.check_step_a_button.TabIndex = 54;
            this.check_step_a_button.Text = "增加";
            this.check_step_a_button.UseVisualStyleBackColor = true;
            this.check_step_a_button.Click += new System.EventHandler(this.check_step_a_button_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.choose_Column,
            this.page_name_e_Column,
            this.element_name_e_Column,
            this.sysname_e_Column});
            this.dataGridView2.Location = new System.Drawing.Point(12, 33);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(497, 400);
            this.dataGridView2.TabIndex = 53;
            // 
            // choose_Column
            // 
            this.choose_Column.DataPropertyName = "选择";
            this.choose_Column.HeaderText = "选择";
            this.choose_Column.Name = "choose_Column";
            this.choose_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.choose_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.choose_Column.Width = 55;
            // 
            // page_name_e_Column
            // 
            this.page_name_e_Column.DataPropertyName = "页面名称";
            this.page_name_e_Column.HeaderText = "页面名称";
            this.page_name_e_Column.Name = "page_name_e_Column";
            // 
            // element_name_e_Column
            // 
            this.element_name_e_Column.DataPropertyName = "元素名称";
            this.element_name_e_Column.HeaderText = "元素名称";
            this.element_name_e_Column.Name = "element_name_e_Column";
            this.element_name_e_Column.Width = 150;
            // 
            // sysname_e_Column
            // 
            this.sysname_e_Column.DataPropertyName = "被测系统名称";
            this.sysname_e_Column.HeaderText = "被测系统名称";
            this.sysname_e_Column.Name = "sysname_e_Column";
            this.sysname_e_Column.Width = 120;
            // 
            // steps_group_add_step_e
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 442);
            this.Controls.Add(this.select_a_button);
            this.Controls.Add(this.select_c_button);
            this.Controls.Add(this.select_all_button);
            this.Controls.Add(this.check_step_a_button);
            this.Controls.Add(this.dataGridView2);
            this.Name = "steps_group_add_step_e";
            this.Text = "steps_group_e";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button select_a_button;
        private System.Windows.Forms.Button select_c_button;
        private System.Windows.Forms.Button select_all_button;
        private System.Windows.Forms.Button check_step_a_button;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn choose_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn page_name_e_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn element_name_e_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn sysname_e_Column;
    }
}