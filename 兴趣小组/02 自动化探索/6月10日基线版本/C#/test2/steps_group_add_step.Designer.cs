namespace test2
{
    partial class steps_group_add_step
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
            this.sysname_name_label = new System.Windows.Forms.Label();
            this.check_point_name_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.select_cancel_button = new System.Windows.Forms.Button();
            this.page_name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step_button = new System.Windows.Forms.Button();
            this.choose_Inverse_button = new System.Windows.Forms.Button();
            this.choose_Column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.select_all_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.page_textBox = new System.Windows.Forms.TextBox();
            this.query_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sysname_name_label
            // 
            this.sysname_name_label.AutoSize = true;
            this.sysname_name_label.Location = new System.Drawing.Point(100, 4);
            this.sysname_name_label.Name = "sysname_name_label";
            this.sysname_name_label.Size = new System.Drawing.Size(0, 12);
            this.sysname_name_label.TabIndex = 53;
            // 
            // check_point_name_label
            // 
            this.check_point_name_label.AutoSize = true;
            this.check_point_name_label.Location = new System.Drawing.Point(271, 4);
            this.check_point_name_label.Name = "check_point_name_label";
            this.check_point_name_label.Size = new System.Drawing.Size(0, 12);
            this.check_point_name_label.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 51;
            this.label2.Text = "步骤组名称：";
            // 
            // select_cancel_button
            // 
            this.select_cancel_button.Location = new System.Drawing.Point(101, 47);
            this.select_cancel_button.Name = "select_cancel_button";
            this.select_cancel_button.Size = new System.Drawing.Size(75, 23);
            this.select_cancel_button.TabIndex = 48;
            this.select_cancel_button.Text = "取消";
            this.select_cancel_button.UseVisualStyleBackColor = true;
            this.select_cancel_button.Click += new System.EventHandler(this.select_cancel_button_Click);
            // 
            // page_name_Column
            // 
            this.page_name_Column.DataPropertyName = "页面名称";
            this.page_name_Column.HeaderText = "页面名称";
            this.page_name_Column.Name = "page_name_Column";
            // 
            // step_button
            // 
            this.step_button.Location = new System.Drawing.Point(263, 46);
            this.step_button.Name = "step_button";
            this.step_button.Size = new System.Drawing.Size(75, 23);
            this.step_button.TabIndex = 50;
            this.step_button.Text = "下一步";
            this.step_button.UseVisualStyleBackColor = true;
            this.step_button.Click += new System.EventHandler(this.step_button_Click);
            // 
            // choose_Inverse_button
            // 
            this.choose_Inverse_button.Location = new System.Drawing.Point(182, 47);
            this.choose_Inverse_button.Name = "choose_Inverse_button";
            this.choose_Inverse_button.Size = new System.Drawing.Size(75, 23);
            this.choose_Inverse_button.TabIndex = 49;
            this.choose_Inverse_button.Text = "反选";
            this.choose_Inverse_button.UseVisualStyleBackColor = true;
            this.choose_Inverse_button.Click += new System.EventHandler(this.choose_Inverse_button_Click);
            // 
            // choose_Column
            // 
            this.choose_Column.HeaderText = "选择";
            this.choose_Column.Name = "choose_Column";
            this.choose_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.choose_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // select_all_button
            // 
            this.select_all_button.Location = new System.Drawing.Point(20, 47);
            this.select_all_button.Name = "select_all_button";
            this.select_all_button.Size = new System.Drawing.Size(75, 23);
            this.select_all_button.TabIndex = 47;
            this.select_all_button.Text = "全选";
            this.select_all_button.UseVisualStyleBackColor = true;
            this.select_all_button.Click += new System.EventHandler(this.select_all_button_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
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
            this.dataGridView1.Size = new System.Drawing.Size(351, 489);
            this.dataGridView1.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "被测系统名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "页面名称：";
            // 
            // page_textBox
            // 
            this.page_textBox.Location = new System.Drawing.Point(101, 18);
            this.page_textBox.Name = "page_textBox";
            this.page_textBox.Size = new System.Drawing.Size(156, 21);
            this.page_textBox.TabIndex = 55;
            // 
            // query_button
            // 
            this.query_button.Location = new System.Drawing.Point(263, 18);
            this.query_button.Name = "query_button";
            this.query_button.Size = new System.Drawing.Size(75, 23);
            this.query_button.TabIndex = 56;
            this.query_button.Text = "查询";
            this.query_button.UseVisualStyleBackColor = true;
            this.query_button.Click += new System.EventHandler(this.query_button_Click);
            // 
            // steps_group_add_step
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 565);
            this.Controls.Add(this.query_button);
            this.Controls.Add(this.page_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sysname_name_label);
            this.Controls.Add(this.check_point_name_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.select_cancel_button);
            this.Controls.Add(this.step_button);
            this.Controls.Add(this.choose_Inverse_button);
            this.Controls.Add(this.select_all_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "steps_group_add_step";
            this.Text = "增加步骤组步骤";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sysname_name_label;
        private System.Windows.Forms.Label check_point_name_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button select_cancel_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn page_name_Column;
        private System.Windows.Forms.Button step_button;
        private System.Windows.Forms.Button choose_Inverse_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn choose_Column;
        private System.Windows.Forms.Button select_all_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox page_textBox;
        private System.Windows.Forms.Button query_button;
    }
}