namespace test2
{
    partial class add_step_e
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
            this.add_button = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.choose_Column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.page_name_e_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.element_name_e_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysname_e_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choose_Inverse_button = new System.Windows.Forms.Button();
            this.select_cancel_button = new System.Windows.Forms.Button();
            this.choose_all_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(253, 11);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 38;
            this.add_button.Text = "增加";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
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
            this.dataGridView2.Location = new System.Drawing.Point(1, 37);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(559, 400);
            this.dataGridView2.TabIndex = 37;
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
            // choose_Inverse_button
            // 
            this.choose_Inverse_button.Location = new System.Drawing.Point(172, 11);
            this.choose_Inverse_button.Name = "choose_Inverse_button";
            this.choose_Inverse_button.Size = new System.Drawing.Size(75, 23);
            this.choose_Inverse_button.TabIndex = 42;
            this.choose_Inverse_button.Text = "反选";
            this.choose_Inverse_button.UseVisualStyleBackColor = true;
            this.choose_Inverse_button.Click += new System.EventHandler(this.choose_Inverse_button_Click);
            // 
            // select_cancel_button
            // 
            this.select_cancel_button.Location = new System.Drawing.Point(91, 11);
            this.select_cancel_button.Name = "select_cancel_button";
            this.select_cancel_button.Size = new System.Drawing.Size(75, 23);
            this.select_cancel_button.TabIndex = 41;
            this.select_cancel_button.Text = "取消";
            this.select_cancel_button.UseVisualStyleBackColor = true;
            this.select_cancel_button.Click += new System.EventHandler(this.select_cancel_button_Click);
            // 
            // choose_all_button
            // 
            this.choose_all_button.Location = new System.Drawing.Point(10, 11);
            this.choose_all_button.Name = "choose_all_button";
            this.choose_all_button.Size = new System.Drawing.Size(75, 23);
            this.choose_all_button.TabIndex = 40;
            this.choose_all_button.Text = "全选";
            this.choose_all_button.UseVisualStyleBackColor = true;
            this.choose_all_button.Click += new System.EventHandler(this.choose_all_button_Click);
            // 
            // add_step_e
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 436);
            this.Controls.Add(this.choose_Inverse_button);
            this.Controls.Add(this.select_cancel_button);
            this.Controls.Add(this.choose_all_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.dataGridView2);
            this.Name = "add_step_e";
            this.Text = "add_step_e";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button choose_Inverse_button;
        private System.Windows.Forms.Button select_cancel_button;
        private System.Windows.Forms.Button choose_all_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn choose_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn page_name_e_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn element_name_e_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn sysname_e_Column;
    }
}