namespace COMP1019_Lab11_ClassManager;

partial class FrmClassManager
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

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.lblMaLop = new Label();
        this.txtMaLop = new TextBox();
        this.lblTenLop = new Label();
        this.txtTenLop = new TextBox();
        this.lblTimKiem = new Label();
        this.txtTimKiem = new TextBox();
        this.dgvLop = new DataGridView();
        this.btnThem = new Button();
        this.btnSua = new Button();
        this.btnXoa = new Button();
        this.btnLamMoi = new Button();
        this.btnTimKiem = new Button();
        this.grpInput = new GroupBox();
        this.grpList = new GroupBox();
        this.grpInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
        this.grpList.SuspendLayout();
        this.SuspendLayout();
        //
        // grpInput
        //
        this.grpInput.Controls.Add(this.lblTimKiem);
        this.grpInput.Controls.Add(this.txtTimKiem);
        this.grpInput.Controls.Add(this.btnTimKiem);
        this.grpInput.Controls.Add(this.lblMaLop);
        this.grpInput.Controls.Add(this.txtMaLop);
        this.grpInput.Controls.Add(this.lblTenLop);
        this.grpInput.Controls.Add(this.txtTenLop);
        this.grpInput.Controls.Add(this.btnThem);
        this.grpInput.Controls.Add(this.btnSua);
        this.grpInput.Controls.Add(this.btnXoa);
        this.grpInput.Controls.Add(this.btnLamMoi);
        this.grpInput.Location = new Point(12, 12);
        this.grpInput.Name = "grpInput";
        this.grpInput.Size = new Size(400, 280);
        this.grpInput.TabIndex = 0;
        this.grpInput.TabStop = false;
        this.grpInput.Text = "Thông tin lớp học";
        //
        // lblMaLop
        //
        this.lblMaLop.AutoSize = true;
        this.lblMaLop.Location = new Point(20, 30);
        this.lblMaLop.Name = "lblMaLop";
        this.lblMaLop.Size = new Size(52, 15);
        this.lblMaLop.TabIndex = 0;
        this.lblMaLop.Text = "Mã lớp:";
        //
        // txtMaLop
        //
        this.txtMaLop.Location = new Point(120, 27);
        this.txtMaLop.Name = "txtMaLop";
        this.txtMaLop.Size = new Size(250, 23);
        this.txtMaLop.TabIndex = 1;
        //
        // lblTenLop
        //
        this.lblTenLop.AutoSize = true;
        this.lblTenLop.Location = new Point(20, 70);
        this.lblTenLop.Name = "lblTenLop";
        this.lblTenLop.Size = new Size(51, 15);
        this.lblTenLop.TabIndex = 2;
        this.lblTenLop.Text = "Tên lớp:";
        //
        // txtTenLop
        //
        this.txtTenLop.Location = new Point(120, 67);
        this.txtTenLop.Name = "txtTenLop";
        this.txtTenLop.Size = new Size(250, 23);
        this.txtTenLop.TabIndex = 3;
        //
        // lblTimKiem
        //
        this.lblTimKiem.AutoSize = true;
        this.lblTimKiem.Location = new Point(20, 110);
        this.lblTimKiem.Name = "lblTimKiem";
        this.lblTimKiem.Size = new Size(65, 15);
        this.lblTimKiem.TabIndex = 4;
        this.lblTimKiem.Text = "Tìm kiếm:";
        //
        // txtTimKiem
        //
        this.txtTimKiem.Location = new Point(120, 107);
        this.txtTimKiem.Name = "txtTimKiem";
        this.txtTimKiem.Size = new Size(180, 23);
        this.txtTimKiem.TabIndex = 5;
        //
        // btnTimKiem
        //
        this.btnTimKiem.Location = new Point(306, 105);
        this.btnTimKiem.Name = "btnTimKiem";
        this.btnTimKiem.Size = new Size(64, 25);
        this.btnTimKiem.TabIndex = 6;
        this.btnTimKiem.Text = "Tìm (F6)";
        this.btnTimKiem.UseVisualStyleBackColor = true;
        this.btnTimKiem.Click += new EventHandler(this.btnTimKiem_Click);
        //
        // btnThem
        //
        this.btnThem.Location = new Point(20, 150);
        this.btnThem.Name = "btnThem";
        this.btnThem.Size = new Size(110, 30);
        this.btnThem.TabIndex = 7;
        this.btnThem.Text = "Thêm (F3)";
        this.btnThem.UseVisualStyleBackColor = true;
        this.btnThem.Click += new EventHandler(this.btnThem_Click);
        //
        // btnSua
        //
        this.btnSua.Location = new Point(145, 150);
        this.btnSua.Name = "btnSua";
        this.btnSua.Size = new Size(110, 30);
        this.btnSua.TabIndex = 8;
        this.btnSua.Text = "Sửa (F4)";
        this.btnSua.UseVisualStyleBackColor = true;
        this.btnSua.Click += new EventHandler(this.btnSua_Click);
        //
        // btnXoa
        //
        this.btnXoa.Location = new Point(270, 150);
        this.btnXoa.Name = "btnXoa";
        this.btnXoa.Size = new Size(100, 30);
        this.btnXoa.TabIndex = 9;
        this.btnXoa.Text = "Xóa (F5)";
        this.btnXoa.UseVisualStyleBackColor = true;
        this.btnXoa.Click += new EventHandler(this.btnXoa_Click);
        //
        // btnLamMoi
        //
        this.btnLamMoi.Location = new Point(20, 200);
        this.btnLamMoi.Name = "btnLamMoi";
        this.btnLamMoi.Size = new Size(350, 30);
        this.btnLamMoi.TabIndex = 10;
        this.btnLamMoi.Text = "Làm mới (F7)";
        this.btnLamMoi.UseVisualStyleBackColor = true;
        this.btnLamMoi.Click += new EventHandler(this.btnLamMoi_Click);
        //
        // grpList
        //
        this.grpList.Controls.Add(this.dgvLop);
        this.grpList.Location = new Point(12, 310);
        this.grpList.Name = "grpList";
        this.grpList.Size = new Size(760, 280);
        this.grpList.TabIndex = 1;
        this.grpList.TabStop = false;
        this.grpList.Text = "Danh sách lớp";
        //
        // dgvLop
        //
        this.dgvLop.AllowUserToAddRows = false;
        this.dgvLop.AllowUserToDeleteRows = false;
        this.dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvLop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvLop.Dock = DockStyle.Fill;
        this.dgvLop.Location = new Point(3, 20);
        this.dgvLop.Name = "dgvLop";
        this.dgvLop.ReadOnly = true;
        this.dgvLop.RowHeadersVisible = false;
        this.dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvLop.Size = new Size(754, 257);
        this.dgvLop.TabIndex = 0;
        this.dgvLop.CellClick += new DataGridViewCellEventHandler(this.dgvLop_CellClick);
        //
        // FrmClassManager
        //
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(784, 611);
        this.Controls.Add(this.grpList);
        this.Controls.Add(this.grpInput);
        this.KeyPreview = true;
        this.MinimumSize = new Size(800, 650);
        this.Name = "FrmClassManager";
        this.Text = "Quản Lý Lớp Học - Lab 11";
        this.Load += new EventHandler(this.FrmClassManager_Load);
        this.KeyDown += new KeyEventHandler(this.FrmClassManager_KeyDown);
        this.grpInput.ResumeLayout(false);
        this.grpInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
        this.grpList.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion

    private Label lblMaLop;
    private TextBox txtMaLop;
    private Label lblTenLop;
    private TextBox txtTenLop;
    private Label lblTimKiem;
    private TextBox txtTimKiem;
    private DataGridView dgvLop;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;
    private Button btnTimKiem;
    private GroupBox grpInput;
    private GroupBox grpList;
}
