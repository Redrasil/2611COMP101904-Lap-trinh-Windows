namespace Lab_14_09
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblThongtin = new Label();
            txtSoluong = new TextBox();
            lblSoluong = new Label();
            SuspendLayout();
            // 
            // lblThongtin
            // 
            lblThongtin.AutoSize = true;
            lblThongtin.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThongtin.Location = new Point(193, 30);
            lblThongtin.Name = "lblThongtin";
            lblThongtin.Size = new Size(301, 38);
            lblThongtin.TabIndex = 0;
            lblThongtin.Text = "Quản lý điểm sinh viên";
            // 
            // txtSoluong
            // 
            txtSoluong.Location = new Point(240, 99);
            txtSoluong.Name = "txtSoluong";
            txtSoluong.Size = new Size(125, 27);
            txtSoluong.TabIndex = 1;
            // 
            // lblSoluong
            // 
            lblSoluong.AutoSize = true;
            lblSoluong.Location = new Point(63, 106);
            lblSoluong.Name = "lblSoluong";
            lblSoluong.Size = new Size(171, 20);
            lblSoluong.TabIndex = 2;
            lblSoluong.Text = "Nhập số lượng sinh viên:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSoluong);
            Controls.Add(txtSoluong);
            Controls.Add(lblThongtin);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblThongtin;
        private TextBox txtSoluong;
        private Label lblSoluong;
    }
}
