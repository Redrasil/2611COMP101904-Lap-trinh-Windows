namespace ShopManagerMini.Forms
{
    partial class FrmAbout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblInstructor = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.lblDesc);
            this.pnlCard.Controls.Add(this.lblDate);
            this.pnlCard.Controls.Add(this.lblInstructor);
            this.pnlCard.Controls.Add(this.lblSubject);
            this.pnlCard.Controls.Add(this.lblClass);
            this.pnlCard.Controls.Add(this.lblStudentId);
            this.pnlCard.Controls.Add(this.lblStudentName);
            this.pnlCard.Controls.Add(this.lblVersion);
            this.pnlCard.Controls.Add(this.lblAppTitle);
            this.pnlCard.Location = new System.Drawing.Point(20, 20);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCard.Size = new System.Drawing.Size(460, 310);
            this.pnlCard.TabIndex = 0;
            // 
            // lblDesc
            // 
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDesc.Location = new System.Drawing.Point(20, 248);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(420, 48);
            this.lblDesc.TabIndex = 8;
            this.lblDesc.Text = "Ứng dụng minh họa kiến trúc MDI Parent - Child, quản lý phiên làm việc đa người d" +
    "ùng và thao tác dữ liệu WinForms trong bộ nhớ.";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 218);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(206, 20);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Thời gian thực hiện: 10/2026";
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInstructor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblInstructor.Location = new System.Drawing.Point(20, 190);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(262, 20);
            this.lblInstructor.TabIndex = 6;
            this.lblInstructor.Text = "Giảng viên HD: ThS. Lê Thanh Thoại";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(20, 162);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(298, 20);
            this.lblSubject.TabIndex = 5;
            this.lblSubject.Text = "Học phần: COMP1019 - Lập trình trên Windows";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(20, 134);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(204, 20);
            this.lblClass.TabIndex = 4;
            this.lblClass.Text = "Lớp: 49.01.TOAN.SN - Nhóm 11";
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStudentId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblStudentId.Location = new System.Drawing.Point(20, 106);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(165, 21);
            this.lblStudentId.TabIndex = 3;
            this.lblStudentId.Text = "MSSV: 49.01.101.075";
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblStudentName.Location = new System.Drawing.Point(20, 76);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(331, 25);
            this.lblStudentName.TabIndex = 2;
            this.lblStudentName.Text = "Sinh viên: Hoàng Dương Phúc Quang";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVersion.Location = new System.Drawing.Point(20, 48);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(306, 20);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Phiên bản: 1.0.0 (MDI WinForms Architecture)";
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblAppTitle.Location = new System.Drawing.Point(18, 15);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(262, 32);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "ShopManagerMini";
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(380, 340);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 35);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.btnDong;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(502, 390);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.pnlCard);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Giới thiệu ứng dụng";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblInstructor;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnDong;
    }
}
