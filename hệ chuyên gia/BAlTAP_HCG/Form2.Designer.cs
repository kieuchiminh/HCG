namespace BTL_HCG_Nhom8
{
    partial class Form2
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
            this.lstNode = new System.Windows.Forms.ListBox();
            this.btnxoanut = new System.Windows.Forms.Button();
            this.btnthemnut = new System.Windows.Forms.Button();
            this.txtNode = new System.Windows.Forms.TextBox();
            this.lstRule = new System.Windows.Forms.ListBox();
            this.btnxoaluat = new System.Windows.Forms.Button();
            this.btnthemluat = new System.Windows.Forms.Button();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnsua = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnedit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstNode
            // 
            this.lstNode.FormattingEnabled = true;
            this.lstNode.ItemHeight = 16;
            this.lstNode.Location = new System.Drawing.Point(8, 66);
            this.lstNode.Name = "lstNode";
            this.lstNode.Size = new System.Drawing.Size(542, 164);
            this.lstNode.TabIndex = 5;
            this.lstNode.SelectedIndexChanged += new System.EventHandler(this.lstNode_SelectedIndexChanged);
            // 
            // btnxoanut
            // 
            this.btnxoanut.BackColor = System.Drawing.Color.DeepPink;
            this.btnxoanut.Location = new System.Drawing.Point(475, 22);
            this.btnxoanut.Name = "btnxoanut";
            this.btnxoanut.Size = new System.Drawing.Size(75, 23);
            this.btnxoanut.TabIndex = 4;
            this.btnxoanut.Text = "Xóa";
            this.btnxoanut.UseVisualStyleBackColor = false;
            this.btnxoanut.Click += new System.EventHandler(this.btnxoanut_Click);
            // 
            // btnthemnut
            // 
            this.btnthemnut.BackColor = System.Drawing.Color.Coral;
            this.btnthemnut.Location = new System.Drawing.Point(313, 22);
            this.btnthemnut.Name = "btnthemnut";
            this.btnthemnut.Size = new System.Drawing.Size(75, 23);
            this.btnthemnut.TabIndex = 3;
            this.btnthemnut.Text = "Thêm";
            this.btnthemnut.UseVisualStyleBackColor = false;
            this.btnthemnut.Click += new System.EventHandler(this.btnthemnut_Click);
            // 
            // txtNode
            // 
            this.txtNode.Location = new System.Drawing.Point(8, 22);
            this.txtNode.Name = "txtNode";
            this.txtNode.Size = new System.Drawing.Size(276, 22);
            this.txtNode.TabIndex = 2;
            // 
            // lstRule
            // 
            this.lstRule.FormattingEnabled = true;
            this.lstRule.ItemHeight = 16;
            this.lstRule.Location = new System.Drawing.Point(6, 66);
            this.lstRule.Name = "lstRule";
            this.lstRule.Size = new System.Drawing.Size(544, 164);
            this.lstRule.TabIndex = 6;
            // 
            // btnxoaluat
            // 
            this.btnxoaluat.Location = new System.Drawing.Point(475, 24);
            this.btnxoaluat.Name = "btnxoaluat";
            this.btnxoaluat.Size = new System.Drawing.Size(75, 23);
            this.btnxoaluat.TabIndex = 4;
            this.btnxoaluat.Text = "Xóa";
            this.btnxoaluat.UseVisualStyleBackColor = true;
            this.btnxoaluat.Click += new System.EventHandler(this.btnxoaluat_Click);
            // 
            // btnthemluat
            // 
            this.btnthemluat.Location = new System.Drawing.Point(313, 24);
            this.btnthemluat.Name = "btnthemluat";
            this.btnthemluat.Size = new System.Drawing.Size(75, 23);
            this.btnthemluat.TabIndex = 3;
            this.btnthemluat.Text = "Thêm";
            this.btnthemluat.UseVisualStyleBackColor = true;
            this.btnthemluat.Click += new System.EventHandler(this.btnthemluat_Click);
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(6, 25);
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(265, 22);
            this.txtRule.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(564, 262);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnsua);
            this.tabPage1.Controls.Add(this.lstNode);
            this.tabPage1.Controls.Add(this.btnxoanut);
            this.tabPage1.Controls.Add(this.txtNode);
            this.tabPage1.Controls.Add(this.btnthemnut);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(556, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý Nút";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.Color.PaleGreen;
            this.btnsua.Location = new System.Drawing.Point(394, 21);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(75, 23);
            this.btnsua.TabIndex = 6;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnedit);
            this.tabPage2.Controls.Add(this.lstRule);
            this.tabPage2.Controls.Add(this.txtRule);
            this.tabPage2.Controls.Add(this.btnthemluat);
            this.tabPage2.Controls.Add(this.btnxoaluat);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(556, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản lý Luật";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(394, 24);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 23);
            this.btnedit.TabIndex = 7;
            this.btnedit.Text = "Sửa";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 286);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Quan ly Luat";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnxoanut;
        private System.Windows.Forms.Button btnthemnut;
        private System.Windows.Forms.TextBox txtNode;
        private System.Windows.Forms.Button btnxoaluat;
        private System.Windows.Forms.Button btnthemluat;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.ListBox lstNode;
        private System.Windows.Forms.ListBox lstRule;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnedit;
    }
}