namespace test2
{
    partial class check_add
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
            this.label2 = new System.Windows.Forms.Label();
            this.check_name_textBox = new System.Windows.Forms.TextBox();
            this.sysname_label = new System.Windows.Forms.Label();
            this.check_name_label = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.iframe_regest_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "被测系统名称：";
            // 
            // sysname_comboBox
            // 
            this.sysname_comboBox.FormattingEnabled = true;
            this.sysname_comboBox.Location = new System.Drawing.Point(99, 44);
            this.sysname_comboBox.Name = "sysname_comboBox";
            this.sysname_comboBox.Size = new System.Drawing.Size(121, 20);
            this.sysname_comboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "检查点名称：";
            // 
            // check_name_textBox
            // 
            this.check_name_textBox.Location = new System.Drawing.Point(373, 42);
            this.check_name_textBox.Name = "check_name_textBox";
            this.check_name_textBox.Size = new System.Drawing.Size(133, 21);
            this.check_name_textBox.TabIndex = 4;
            // 
            // sysname_label
            // 
            this.sysname_label.AutoSize = true;
            this.sysname_label.ForeColor = System.Drawing.Color.Red;
            this.sysname_label.Location = new System.Drawing.Point(226, 47);
            this.sysname_label.Name = "sysname_label";
            this.sysname_label.Size = new System.Drawing.Size(53, 12);
            this.sysname_label.TabIndex = 5;
            this.sysname_label.Text = "不能为空";
            this.sysname_label.Visible = false;
            // 
            // check_name_label
            // 
            this.check_name_label.AutoSize = true;
            this.check_name_label.ForeColor = System.Drawing.Color.Red;
            this.check_name_label.Location = new System.Drawing.Point(514, 46);
            this.check_name_label.Name = "check_name_label";
            this.check_name_label.Size = new System.Drawing.Size(53, 12);
            this.check_name_label.TabIndex = 6;
            this.check_name_label.Text = "不能为空";
            this.check_name_label.Visible = false;
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(170, 99);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 7;
            this.add_button.Text = "增加";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // iframe_regest_button
            // 
            this.iframe_regest_button.Location = new System.Drawing.Point(285, 98);
            this.iframe_regest_button.Name = "iframe_regest_button";
            this.iframe_regest_button.Size = new System.Drawing.Size(75, 23);
            this.iframe_regest_button.TabIndex = 8;
            this.iframe_regest_button.Text = "重置";
            this.iframe_regest_button.UseVisualStyleBackColor = true;
            this.iframe_regest_button.Click += new System.EventHandler(this.iframe_regest_button_Click);
            // 
            // check_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 273);
            this.Controls.Add(this.iframe_regest_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.check_name_label);
            this.Controls.Add(this.sysname_label);
            this.Controls.Add(this.check_name_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sysname_comboBox);
            this.Controls.Add(this.label1);
            this.Name = "check_add";
            this.Text = "增加检查点页面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sysname_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox check_name_textBox;
        private System.Windows.Forms.Label sysname_label;
        private System.Windows.Forms.Label check_name_label;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button iframe_regest_button;
    }
}