namespace test2
{
    partial class test_case_add
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
            this.sysname_comboBox = new System.Windows.Forms.ComboBox();
            this.function_name_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.test_id_textBox = new System.Windows.Forms.TextBox();
            this.hope_result_way_comboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.compary_way_comboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sysname_label = new System.Windows.Forms.Label();
            this.function_name_label = new System.Windows.Forms.Label();
            this.hope_result_way_label = new System.Windows.Forms.Label();
            this.compay_way_label = new System.Windows.Forms.Label();
            this.test_id_label = new System.Windows.Forms.Label();
            this.add_test_step_button = new System.Windows.Forms.Button();
            this.instruction_label = new System.Windows.Forms.Label();
            this.add_test_button = new System.Windows.Forms.Button();
            this.hope_result_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "被测系统名称：";
            // 
            // sysname_comboBox
            // 
            this.sysname_comboBox.FormattingEnabled = true;
            this.sysname_comboBox.Location = new System.Drawing.Point(95, 17);
            this.sysname_comboBox.Name = "sysname_comboBox";
            this.sysname_comboBox.Size = new System.Drawing.Size(245, 20);
            this.sysname_comboBox.TabIndex = 2;
            // 
            // function_name_comboBox
            // 
            this.function_name_comboBox.FormattingEnabled = true;
            this.function_name_comboBox.Location = new System.Drawing.Point(521, 17);
            this.function_name_comboBox.Name = "function_name_comboBox";
            this.function_name_comboBox.Size = new System.Drawing.Size(252, 20);
            this.function_name_comboBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "功能点名称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "用例名称前缀：";
            // 
            // test_id_textBox
            // 
            this.test_id_textBox.Location = new System.Drawing.Point(95, 52);
            this.test_id_textBox.Name = "test_id_textBox";
            this.test_id_textBox.Size = new System.Drawing.Size(245, 21);
            this.test_id_textBox.TabIndex = 6;
            // 
            // hope_result_way_comboBox
            // 
            this.hope_result_way_comboBox.FormattingEnabled = true;
            this.hope_result_way_comboBox.Items.AddRange(new object[] {
            "请选择",
            "手工",
            "数据库"});
            this.hope_result_way_comboBox.Location = new System.Drawing.Point(521, 93);
            this.hope_result_way_comboBox.Name = "hope_result_way_comboBox";
            this.hope_result_way_comboBox.Size = new System.Drawing.Size(252, 20);
            this.hope_result_way_comboBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "期望结果输出方式：";
            // 
            // compary_way_comboBox
            // 
            this.compary_way_comboBox.FormattingEnabled = true;
            this.compary_way_comboBox.Items.AddRange(new object[] {
            "请选择",
            "等于",
            "不等于",
            "运行包含期望",
            "运行被包含期望",
            "运行>期望",
            "运行>=期望",
            "运行<期望",
            "运行<=期望"});
            this.compary_way_comboBox.Location = new System.Drawing.Point(520, 50);
            this.compary_way_comboBox.Name = "compary_way_comboBox";
            this.compary_way_comboBox.Size = new System.Drawing.Size(253, 20);
            this.compary_way_comboBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(458, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "对比方式：";
            // 
            // sysname_label
            // 
            this.sysname_label.AutoSize = true;
            this.sysname_label.ForeColor = System.Drawing.Color.Red;
            this.sysname_label.Location = new System.Drawing.Point(346, 22);
            this.sysname_label.Name = "sysname_label";
            this.sysname_label.Size = new System.Drawing.Size(53, 12);
            this.sysname_label.TabIndex = 13;
            this.sysname_label.Text = "必须选择";
            this.sysname_label.Visible = false;
            // 
            // function_name_label
            // 
            this.function_name_label.AutoSize = true;
            this.function_name_label.ForeColor = System.Drawing.Color.Red;
            this.function_name_label.Location = new System.Drawing.Point(779, 20);
            this.function_name_label.Name = "function_name_label";
            this.function_name_label.Size = new System.Drawing.Size(53, 12);
            this.function_name_label.TabIndex = 14;
            this.function_name_label.Text = "必须选择";
            this.function_name_label.Visible = false;
            // 
            // hope_result_way_label
            // 
            this.hope_result_way_label.AutoSize = true;
            this.hope_result_way_label.ForeColor = System.Drawing.Color.Red;
            this.hope_result_way_label.Location = new System.Drawing.Point(779, 96);
            this.hope_result_way_label.Name = "hope_result_way_label";
            this.hope_result_way_label.Size = new System.Drawing.Size(53, 12);
            this.hope_result_way_label.TabIndex = 16;
            this.hope_result_way_label.Text = "必须选择";
            this.hope_result_way_label.Visible = false;
            // 
            // compay_way_label
            // 
            this.compay_way_label.AutoSize = true;
            this.compay_way_label.ForeColor = System.Drawing.Color.Red;
            this.compay_way_label.Location = new System.Drawing.Point(772, 56);
            this.compay_way_label.Name = "compay_way_label";
            this.compay_way_label.Size = new System.Drawing.Size(53, 12);
            this.compay_way_label.TabIndex = 17;
            this.compay_way_label.Text = "必须选择";
            this.compay_way_label.Visible = false;
            // 
            // test_id_label
            // 
            this.test_id_label.AutoSize = true;
            this.test_id_label.ForeColor = System.Drawing.Color.Red;
            this.test_id_label.Location = new System.Drawing.Point(346, 55);
            this.test_id_label.Name = "test_id_label";
            this.test_id_label.Size = new System.Drawing.Size(41, 12);
            this.test_id_label.TabIndex = 18;
            this.test_id_label.Text = "请输入";
            this.test_id_label.Visible = false;
            // 
            // add_test_step_button
            // 
            this.add_test_step_button.Location = new System.Drawing.Point(300, 121);
            this.add_test_step_button.Name = "add_test_step_button";
            this.add_test_step_button.Size = new System.Drawing.Size(93, 23);
            this.add_test_step_button.TabIndex = 19;
            this.add_test_step_button.Text = "增加测试步骤";
            this.add_test_step_button.UseVisualStyleBackColor = true;
            this.add_test_step_button.Click += new System.EventHandler(this.add_test_step_button_click);
            // 
            // instruction_label
            // 
            this.instruction_label.AutoSize = true;
            this.instruction_label.ForeColor = System.Drawing.Color.Red;
            this.instruction_label.Location = new System.Drawing.Point(501, 127);
            this.instruction_label.Name = "instruction_label";
            this.instruction_label.Size = new System.Drawing.Size(197, 12);
            this.instruction_label.TabIndex = 21;
            this.instruction_label.Text = "以下输入框可输多个值，以；为分割";
            this.instruction_label.Visible = false;
            // 
            // add_test_button
            // 
            this.add_test_button.Location = new System.Drawing.Point(399, 121);
            this.add_test_button.Name = "add_test_button";
            this.add_test_button.Size = new System.Drawing.Size(75, 23);
            this.add_test_button.TabIndex = 22;
            this.add_test_button.Text = "增加";
            this.add_test_button.UseVisualStyleBackColor = true;
            this.add_test_button.Visible = false;
            this.add_test_button.Click += new System.EventHandler(this.add_test_button_Click);
            // 
            // hope_result_textBox
            // 
            this.hope_result_textBox.Location = new System.Drawing.Point(95, 88);
            this.hope_result_textBox.Name = "hope_result_textBox";
            this.hope_result_textBox.Size = new System.Drawing.Size(245, 21);
            this.hope_result_textBox.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "期望结果：";
            // 
            // test_case_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(855, 262);
            this.Controls.Add(this.hope_result_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.add_test_button);
            this.Controls.Add(this.instruction_label);
            this.Controls.Add(this.add_test_step_button);
            this.Controls.Add(this.test_id_label);
            this.Controls.Add(this.compay_way_label);
            this.Controls.Add(this.hope_result_way_label);
            this.Controls.Add(this.function_name_label);
            this.Controls.Add(this.sysname_label);
            this.Controls.Add(this.hope_result_way_comboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.compary_way_comboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.test_id_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.function_name_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sysname_comboBox);
            this.Controls.Add(this.label1);
            this.Name = "test_case_add";
            this.Text = "test_case_add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sysname_comboBox;
        private System.Windows.Forms.ComboBox function_name_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox test_id_textBox;
        private System.Windows.Forms.ComboBox hope_result_way_comboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox compary_way_comboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label sysname_label;
        private System.Windows.Forms.Label function_name_label;
        private System.Windows.Forms.Label hope_result_way_label;
        private System.Windows.Forms.Label compay_way_label;
        private System.Windows.Forms.Label test_id_label;
        private System.Windows.Forms.Button add_test_step_button;
        private System.Windows.Forms.Label instruction_label;
        private System.Windows.Forms.Button add_test_button;
        private System.Windows.Forms.TextBox hope_result_textBox;
        private System.Windows.Forms.Label label7;
    }
}