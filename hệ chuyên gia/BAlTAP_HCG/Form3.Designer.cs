namespace BTL_HCG_Nhom8
{
    partial class Form3
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
            this.txttuvan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txttuvan
            // 
            this.txttuvan.BackColor = System.Drawing.SystemColors.Window;
            this.txttuvan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttuvan.Location = new System.Drawing.Point(12, 12);
            this.txttuvan.Multiline = true;
            this.txttuvan.Name = "txttuvan";
            this.txttuvan.ReadOnly = true;
            this.txttuvan.Size = new System.Drawing.Size(268, 207);
            this.txttuvan.TabIndex = 0;
            this.txttuvan.TextChanged += new System.EventHandler(this.txttuvan_TextChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 231);
            this.Controls.Add(this.txttuvan);
            this.Name = "Form3";
            this.Text = "Giai thich Luat";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttuvan;

    }
}