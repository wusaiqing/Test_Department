namespace test2
{
    partial class add_step
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.choose_Column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.page_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysname_label = new System.Windows.Forms.Label();
            this.function_name_label = new System.Windows.Forms.Label();
            this.choose_all_button = new System.Windows.Forms.Button();
            this.select_cancel_button = new System.Windows.Forms.Button();
            this.choose_Inverse_button = new System.Windows.Forms.Button();
            this.step_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.page_textBox = new System.Windows.Forms.TextBox();
            this.query_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "功能点名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "被测系统名称：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.choose_Column,
            this.page_name_Column});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(3, 87);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(400, 483);
            this.dataGridView1.TabIndex = 8;
            // 
            // choose_Column
            // 
            this.choose_Column.HeaderText = "选择";
            this.choose_Column.Name = "choose_Column";
            this.choose_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.choose_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // page_name_Column
            // 
            this.page_name_Column.DataPropertyName = "页面名称";
            this.page_name_Column.HeaderText = "页面名称";
            this.page_name_Column.Name = "page_name_Column";
            // 
            // sysname_label
            // 
            this.sysname_label.AutoSize = true;
            this.sysname_label.Location = new System.Drawing.Point(111, 17);
            this.sysname_label.Name = "sysname_label";
            this.sysname_label.Size = new System.Drawing.Size(0, 12);
            this.sysname_label.TabIndex = 9;
            // 
            // function_name_label
            // 
            this.function_name_label.AutoSize = true;
            this.function_name_label.Location = new System.Drawing.Point(297, 17);
            this.function_name_label.Name = "function_name_label";
            this.function_name_label.Size = new System.Drawing.Size(0, 12);
            this.function_name_label.TabIndex = 10;
            // 
            // choose_all_button
            // 
            this.choose_all_button.Location = new System.Drawing.Point(15, 60);
            this.choose_all_button.Name = "choose_all_button";
            this.choose_all_button.Size = new System.Drawing.Size(75, 23);
            this.choose_all_button.TabIndex = 22;
            this.choose_all_button.Text = "全选";
            this.choose_all_button.UseVisualStyleBackColor = true;
            this.choose_all_button.Click += new System.EventHandler(this.choose_all_button_Click);
            // 
            // select_cancel_button
            // 
            this.select_cancel_button.Location = new System.Drawing.Point(96, 60);
            this.select_cancel_button.Name = "select_cancel_button";
            this.select_cancel_button.Size = new System.Drawing.Size(75, 23);
            this.select_cancel_button.TabIndex = 32;
            this.select_cancel_button.Text = "取消";
            this.select_cancel_button.UseVisualStyleBackColor = true;
            this.select_cancel_button.Click += new System.EventHandler(this.select_cancel_button_Click);
            // 
            // choose_Inverse_button
            // 
            this.choose_Inverse_button.Location = new System.Drawing.Point(177, 60);
            this.choose_Inverse_button.Name = "choose_Inverse_button";
            this.choose_Inverse_button.Size = new System.Drawing.Size(75, 23);
            this.choose_Inverse_button.TabIndex = 33;
            this.choose_Inverse_button.Text = "反选";
            this.choose_Inverse_button.UseVisualStyleBackColor = true;
            this.choose_Inverse_button.Click += new System.EventHandler(this.choose_Inverse_button_Click);
            // 
            // step_button
            // 
            this.step_button.Location = new System.Drawing.Point(258, 59);
            this.step_button.Name = "step_button";
            this.step_button.Size = new System.Drawing.Size(75, 23);
            this.step_button.TabIndex = 35;
            this.step_button.Text = "下一步";
            this.step_button.UseVisualStyleBackColor = true;
            this.step_button.Click += new System.EventHandler(this.step_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "页面名称：";
            // 
            // page_textBox
            // 
            this.page_textBox.Location = new System.Drawing.Point(104, 33);
            this.page_textBox.Name = "page_textBox";
            this.page_textBox.Size = new System.Drawing.Size(148, 21);
            this.page_textBox.TabIndex = 37;
            // 
            // query_button
            // 
            this.query_button.Location = new System.Drawing.Point(258, 31);
            this.query_button.Name = "query_button";
            this.query_button.Size = new System.Drawing.Size(75, 23);
            this.query_button.TabIndex = 38;
            this.query_button.Text = "查询";
            this.query_button.UseVisualStyleBackColor = true;
            this.query_button.Click += new System.EventHandler(this.query_button_Click);
            // 
            // add_step
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 569);
            this.Controls.Add(this.query_button);
            this.Controls.Add(this.page_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.step_button);
            this.Controls.Add(this.choose_Inverse_button);
            this.Controls.Add(this.select_cancel_button);
            this.Controls.Add(this.choose_all_button);
            this.Controls.Add(this.function_name_label);
            this.Controls.Add(this.sysname_label);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "add_step";
            this.Text = "add_setp";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label sysname_label;
        private System.Windows.Forms.Label function_name_label;
        private System.Windows.Forms.DataGridViewCheckBoxColumn choose_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn page_name_Column;
        private System.Windows.Forms.Button choose_all_button;
        private System.Windows.Forms.Button select_cancel_button;
        private System.Windows.Forms.Button choose_Inverse_button;
        private System.Windows.Forms.Button step_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox page_textBox;
        private System.Windows.Forms.Button query_button;
    }
}