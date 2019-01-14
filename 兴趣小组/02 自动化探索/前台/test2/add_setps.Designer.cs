namespace test2
{
    partial class add_setps
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
            this.setps_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sysname_comboBox = new System.Windows.Forms.ComboBox();
            this.steps_label = new System.Windows.Forms.Label();
            this.sysname_label = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.reset_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "被测系统名称：";
            // 
            // setps_textBox
            // 
            this.setps_textBox.Location = new System.Drawing.Point(370, 48);
            this.setps_textBox.Name = "setps_textBox";
            this.setps_textBox.Size = new System.Drawing.Size(100, 21);
            this.setps_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "步骤组名称：";
            // 
            // sysname_comboBox
            // 
            this.sysname_comboBox.FormattingEnabled = true;
            this.sysname_comboBox.Location = new System.Drawing.Point(103, 49);
            this.sysname_comboBox.Name = "sysname_comboBox";
            this.sysname_comboBox.Size = new System.Drawing.Size(121, 20);
            this.sysname_comboBox.TabIndex = 4;
            // 
            // steps_label
            // 
            this.steps_label.AutoSize = true;
            this.steps_label.ForeColor = System.Drawing.Color.Red;
            this.steps_label.Location = new System.Drawing.Point(477, 52);
            this.steps_label.Name = "steps_label";
            this.steps_label.Size = new System.Drawing.Size(53, 12);
            this.steps_label.TabIndex = 6;
            this.steps_label.Text = "不能为空";
            this.steps_label.Visible = false;
            // 
            // sysname_label
            // 
            this.sysname_label.AutoSize = true;
            this.sysname_label.ForeColor = System.Drawing.Color.Red;
            this.sysname_label.Location = new System.Drawing.Point(230, 53);
            this.sysname_label.Name = "sysname_label";
            this.sysname_label.Size = new System.Drawing.Size(53, 12);
            this.sysname_label.TabIndex = 7;
            this.sysname_label.Text = "不能为空";
            this.sysname_label.Visible = false;
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(172, 93);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 8;
            this.add_button.Text = "增加";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(282, 93);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(75, 23);
            this.reset_button.TabIndex = 9;
            this.reset_button.Text = "重置";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // add_setps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 156);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.sysname_label);
            this.Controls.Add(this.steps_label);
            this.Controls.Add(this.sysname_comboBox);
            this.Controls.Add(this.setps_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "add_setps";
            this.Text = "增加步骤组";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox setps_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sysname_comboBox;
        private System.Windows.Forms.Label steps_label;
        private System.Windows.Forms.Label sysname_label;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button reset_button;
    }
}