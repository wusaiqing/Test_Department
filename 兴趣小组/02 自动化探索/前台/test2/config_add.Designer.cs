namespace test2
{
    partial class config_add
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
            this.function_name_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.config_add_button = new System.Windows.Forms.Button();
            this.reset_button = new System.Windows.Forms.Button();
            this.finish_yes_no_label = new System.Windows.Forms.Label();
            this.sysname_label = new System.Windows.Forms.Label();
            this.action_yes_no_label = new System.Windows.Forms.Label();
            this.function_name_label1 = new System.Windows.Forms.Label();
            this.action_yes_no_comboBox = new System.Windows.Forms.ComboBox();
            this.finish_yes_no_comboBox = new System.Windows.Forms.ComboBox();
            this.sysname_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // function_name_textBox
            // 
            this.function_name_textBox.Location = new System.Drawing.Point(118, 37);
            this.function_name_textBox.Name = "function_name_textBox";
            this.function_name_textBox.Size = new System.Drawing.Size(117, 21);
            this.function_name_textBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "功能点名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "是否执行：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "被测系统名称：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "是否执行完毕：";
            // 
            // config_add_button
            // 
            this.config_add_button.Location = new System.Drawing.Point(128, 173);
            this.config_add_button.Name = "config_add_button";
            this.config_add_button.Size = new System.Drawing.Size(75, 23);
            this.config_add_button.TabIndex = 13;
            this.config_add_button.Text = "增加";
            this.config_add_button.UseVisualStyleBackColor = true;
            this.config_add_button.Click += new System.EventHandler(this.config_add_button_Click);
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(245, 173);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(75, 23);
            this.reset_button.TabIndex = 14;
            this.reset_button.Text = "重置";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // finish_yes_no_label
            // 
            this.finish_yes_no_label.AutoSize = true;
            this.finish_yes_no_label.ForeColor = System.Drawing.Color.Red;
            this.finish_yes_no_label.Location = new System.Drawing.Point(244, 100);
            this.finish_yes_no_label.Name = "finish_yes_no_label";
            this.finish_yes_no_label.Size = new System.Drawing.Size(53, 12);
            this.finish_yes_no_label.TabIndex = 17;
            this.finish_yes_no_label.Text = "必须选择";
            this.finish_yes_no_label.Visible = false;
            // 
            // sysname_label
            // 
            this.sysname_label.AutoSize = true;
            this.sysname_label.ForeColor = System.Drawing.Color.Red;
            this.sysname_label.Location = new System.Drawing.Point(510, 100);
            this.sysname_label.Name = "sysname_label";
            this.sysname_label.Size = new System.Drawing.Size(53, 12);
            this.sysname_label.TabIndex = 20;
            this.sysname_label.Text = "必须选择";
            this.sysname_label.Visible = false;
            // 
            // action_yes_no_label
            // 
            this.action_yes_no_label.AutoSize = true;
            this.action_yes_no_label.ForeColor = System.Drawing.Color.Red;
            this.action_yes_no_label.Location = new System.Drawing.Point(507, 41);
            this.action_yes_no_label.Name = "action_yes_no_label";
            this.action_yes_no_label.Size = new System.Drawing.Size(53, 12);
            this.action_yes_no_label.TabIndex = 19;
            this.action_yes_no_label.Text = "必须选择";
            this.action_yes_no_label.Visible = false;
            // 
            // function_name_label1
            // 
            this.function_name_label1.AutoSize = true;
            this.function_name_label1.ForeColor = System.Drawing.Color.Red;
            this.function_name_label1.Location = new System.Drawing.Point(241, 41);
            this.function_name_label1.Name = "function_name_label1";
            this.function_name_label1.Size = new System.Drawing.Size(53, 12);
            this.function_name_label1.TabIndex = 18;
            this.function_name_label1.Text = "不能为空";
            this.function_name_label1.Visible = false;
            // 
            // action_yes_no_comboBox
            // 
            this.action_yes_no_comboBox.FormattingEnabled = true;
            this.action_yes_no_comboBox.Items.AddRange(new object[] {
            "请选择",
            "YES",
            "NO"});
            this.action_yes_no_comboBox.Location = new System.Drawing.Point(383, 35);
            this.action_yes_no_comboBox.Name = "action_yes_no_comboBox";
            this.action_yes_no_comboBox.Size = new System.Drawing.Size(121, 20);
            this.action_yes_no_comboBox.TabIndex = 21;
            // 
            // finish_yes_no_comboBox
            // 
            this.finish_yes_no_comboBox.FormattingEnabled = true;
            this.finish_yes_no_comboBox.Items.AddRange(new object[] {
            "请选择",
            "YES",
            "NO"});
            this.finish_yes_no_comboBox.Location = new System.Drawing.Point(118, 95);
            this.finish_yes_no_comboBox.Name = "finish_yes_no_comboBox";
            this.finish_yes_no_comboBox.Size = new System.Drawing.Size(121, 20);
            this.finish_yes_no_comboBox.TabIndex = 22;
            // 
            // sysname_comboBox
            // 
            this.sysname_comboBox.FormattingEnabled = true;
            this.sysname_comboBox.Location = new System.Drawing.Point(383, 96);
            this.sysname_comboBox.Name = "sysname_comboBox";
            this.sysname_comboBox.Size = new System.Drawing.Size(121, 20);
            this.sysname_comboBox.TabIndex = 23;
            // 
            // config_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 273);
            this.Controls.Add(this.sysname_comboBox);
            this.Controls.Add(this.finish_yes_no_comboBox);
            this.Controls.Add(this.action_yes_no_comboBox);
            this.Controls.Add(this.sysname_label);
            this.Controls.Add(this.action_yes_no_label);
            this.Controls.Add(this.function_name_label1);
            this.Controls.Add(this.finish_yes_no_label);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.config_add_button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.function_name_textBox);
            this.Controls.Add(this.label3);
            this.Name = "config_add";
            this.Text = "增加config表数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox function_name_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button config_add_button;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Label finish_yes_no_label;
        private System.Windows.Forms.Label sysname_label;
        private System.Windows.Forms.Label action_yes_no_label;
        private System.Windows.Forms.Label function_name_label1;
        private System.Windows.Forms.ComboBox action_yes_no_comboBox;
        private System.Windows.Forms.ComboBox finish_yes_no_comboBox;
        private System.Windows.Forms.ComboBox sysname_comboBox;
    }
}