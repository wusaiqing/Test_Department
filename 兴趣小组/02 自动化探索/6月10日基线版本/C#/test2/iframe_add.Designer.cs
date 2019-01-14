namespace test2
{
    partial class iframe_add
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
            this.iframe_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.iframe_label = new System.Windows.Forms.Label();
            this.sysname_label = new System.Windows.Forms.Label();
            this.iframe_query_button = new System.Windows.Forms.Button();
            this.iframe_regest_button = new System.Windows.Forms.Button();
            this.syname_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ifram名称：";
            // 
            // iframe_textBox
            // 
            this.iframe_textBox.Location = new System.Drawing.Point(80, 68);
            this.iframe_textBox.Name = "iframe_textBox";
            this.iframe_textBox.Size = new System.Drawing.Size(100, 21);
            this.iframe_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "被测系统名称：";
            // 
            // iframe_label
            // 
            this.iframe_label.AutoSize = true;
            this.iframe_label.ForeColor = System.Drawing.Color.Red;
            this.iframe_label.Location = new System.Drawing.Point(186, 74);
            this.iframe_label.Name = "iframe_label";
            this.iframe_label.Size = new System.Drawing.Size(53, 12);
            this.iframe_label.TabIndex = 4;
            this.iframe_label.Text = "不能为空";
            this.iframe_label.Visible = false;
            // 
            // sysname_label
            // 
            this.sysname_label.AutoSize = true;
            this.sysname_label.ForeColor = System.Drawing.Color.Red;
            this.sysname_label.Location = new System.Drawing.Point(445, 73);
            this.sysname_label.Name = "sysname_label";
            this.sysname_label.Size = new System.Drawing.Size(53, 12);
            this.sysname_label.TabIndex = 5;
            this.sysname_label.Text = "不能为空";
            this.sysname_label.Visible = false;
            // 
            // iframe_query_button
            // 
            this.iframe_query_button.Location = new System.Drawing.Point(114, 137);
            this.iframe_query_button.Name = "iframe_query_button";
            this.iframe_query_button.Size = new System.Drawing.Size(75, 23);
            this.iframe_query_button.TabIndex = 6;
            this.iframe_query_button.Text = "增加";
            this.iframe_query_button.UseVisualStyleBackColor = true;
            this.iframe_query_button.Click += new System.EventHandler(this.iframe_query_button_Click);
            // 
            // iframe_regest_button
            // 
            this.iframe_regest_button.Location = new System.Drawing.Point(227, 137);
            this.iframe_regest_button.Name = "iframe_regest_button";
            this.iframe_regest_button.Size = new System.Drawing.Size(75, 23);
            this.iframe_regest_button.TabIndex = 7;
            this.iframe_regest_button.Text = "重置";
            this.iframe_regest_button.UseVisualStyleBackColor = true;
            this.iframe_regest_button.Click += new System.EventHandler(this.iframe_regest_button_Click);
            // 
            // syname_comboBox
            // 
            this.syname_comboBox.FormattingEnabled = true;
            this.syname_comboBox.Location = new System.Drawing.Point(323, 68);
            this.syname_comboBox.Name = "syname_comboBox";
            this.syname_comboBox.Size = new System.Drawing.Size(121, 20);
            this.syname_comboBox.TabIndex = 8;
            // 
            // iframe_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 273);
            this.Controls.Add(this.syname_comboBox);
            this.Controls.Add(this.iframe_regest_button);
            this.Controls.Add(this.iframe_query_button);
            this.Controls.Add(this.sysname_label);
            this.Controls.Add(this.iframe_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iframe_textBox);
            this.Controls.Add(this.label1);
            this.Name = "iframe_add";
            this.Text = "增加iframe表数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox iframe_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label iframe_label;
        private System.Windows.Forms.Label sysname_label;
        private System.Windows.Forms.Button iframe_query_button;
        private System.Windows.Forms.Button iframe_regest_button;
        private System.Windows.Forms.ComboBox syname_comboBox;
    }
}