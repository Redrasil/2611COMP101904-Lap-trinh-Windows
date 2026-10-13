using System.Drawing.Printing;

namespace COMP1019_Lab09_StudentCard;

partial class FrmStudentCard
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
        this.grpInput = new GroupBox();
        this.lblFaculty = new Label();
        this.lblCourse = new Label();
        this.lblDateOfBirth = new Label();
        this.lblGender = new Label();
        this.lblClass = new Label();
        this.lblFullName = new Label();
        this.lblStudentId = new Label();
        this.cboFaculty = new ComboBox();
        this.cboCourse = new ComboBox();
        this.cboClass = new ComboBox();
        this.dtpDateOfBirth = new DateTimePicker();
        this.cboGender = new ComboBox();
        this.txtFullName = new TextBox();
        this.txtStudentId = new TextBox();
        this.picPhoto = new PictureBox();
        this.btnSelectPhoto = new Button();
        this.grpPreview = new GroupBox();
        this.pnlPreview = new Panel();
        this.btnPrintPreview = new Button();
        this.btnPrint = new Button();
        this.btnRefresh = new Button();
        this.lblPhoto = new Label();
        this.grpInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
        this.grpPreview.SuspendLayout();
        this.SuspendLayout();
        //
        // grpInput
        //
        this.grpInput.Controls.Add(this.lblFaculty);
        this.grpInput.Controls.Add(this.lblCourse);
        this.grpInput.Controls.Add(this.lblDateOfBirth);
        this.grpInput.Controls.Add(this.lblGender);
        this.grpInput.Controls.Add(this.lblClass);
        this.grpInput.Controls.Add(this.lblFullName);
        this.grpInput.Controls.Add(this.lblStudentId);
        this.grpInput.Controls.Add(this.cboFaculty);
        this.grpInput.Controls.Add(this.cboCourse);
        this.grpInput.Controls.Add(this.cboClass);
        this.grpInput.Controls.Add(this.dtpDateOfBirth);
        this.grpInput.Controls.Add(this.cboGender);
        this.grpInput.Controls.Add(this.txtFullName);
        this.grpInput.Controls.Add(this.txtStudentId);
        this.grpInput.Controls.Add(this.picPhoto);
        this.grpInput.Controls.Add(this.btnSelectPhoto);
        this.grpInput.Controls.Add(this.lblPhoto);
        this.grpInput.Location = new Point(12, 12);
        this.grpInput.Name = "grpInput";
        this.grpInput.Size = new Size(350, 450);
        this.grpInput.TabIndex = 0;
        this.grpInput.TabStop = false;
        this.grpInput.Text = "Thông tin sinh viên";
        //
        // lblFaculty
        //
        this.lblFaculty.AutoSize = true;
        this.lblFaculty.Location = new Point(10, 200);
        this.lblFaculty.Name = "lblFaculty";
        this.lblFaculty.Size = new Size(52, 15);
        this.lblFaculty.TabIndex = 15;
        this.lblFaculty.Text = "Khoa:";
        //
        // lblCourse
        //
        this.lblCourse.AutoSize = true;
        this.lblCourse.Location = new Point(10, 230);
        this.lblCourse.Name = "lblCourse";
        this.lblCourse.Size = new Size(56, 15);
        this.lblCourse.TabIndex = 14;
        this.lblCourse.Text = "Khóa học:";
        //
        // lblDateOfBirth
        //
        this.lblDateOfBirth.AutoSize = true;
        this.lblDateOfBirth.Location = new Point(10, 260);
        this.lblDateOfBirth.Name = "lblDateOfBirth";
        this.lblDateOfBirth.Size = new Size(66, 15);
        this.lblDateOfBirth.TabIndex = 13;
        this.lblDateOfBirth.Text = "Ngày sinh:";
        //
        // lblGender
        //
        this.lblGender.AutoSize = true;
        this.lblGender.Location = new Point(10, 290);
        this.lblGender.Name = "lblGender";
        this.lblGender.Size = new Size(60, 15);
        this.lblGender.TabIndex = 12;
        this.lblGender.Text = "Giới tính:";
        //
        // lblClass
        //
        this.lblClass.AutoSize = true;
        this.lblClass.Location = new Point(10, 170);
        this.lblClass.Name = "lblClass";
        this.lblClass.Size = new Size(33, 15);
        this.lblClass.TabIndex = 11;
        this.lblClass.Text = "Lớp:";
        //
        // lblFullName
        //
        this.lblFullName.AutoSize = true;
        this.lblFullName.Location = new Point(10, 140);
        this.lblFullName.Name = "lblFullName";
        this.lblFullName.Size = new Size(51, 15);
        this.lblFullName.TabIndex = 10;
        this.lblFullName.Text = "Họ tên:";
        //
        // lblStudentId
        //
        this.lblStudentId.AutoSize = true;
        this.lblStudentId.Location = new Point(10, 110);
        this.lblStudentId.Name = "lblStudentId";
        this.lblStudentId.Size = new Size(57, 15);
        this.lblStudentId.TabIndex = 9;
        this.lblStudentId.Text = "Mã SV:";
        //
        // cboFaculty
        //
        this.cboFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboFaculty.FormattingEnabled = true;
        this.cboFaculty.Items.AddRange(new object[] {
            "Công nghệ thông tin",
            "Khoa học máy tính",
            "Kỹ thuật phần mềm",
            "Hệ thống thông tin"});
        this.cboFaculty.Location = new Point(90, 197);
        this.cboFaculty.Name = "cboFaculty";
        this.cboFaculty.Size = new Size(240, 23);
        this.cboFaculty.TabIndex = 7;
        //
        // cboCourse
        //
        this.cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboCourse.FormattingEnabled = true;
        this.cboCourse.Items.AddRange(new object[] {
            "K49",
            "K50",
            "K51",
            "K52"});
        this.cboCourse.Location = new Point(90, 227);
        this.cboCourse.Name = "cboCourse";
        this.cboCourse.Size = new Size(240, 23);
        this.cboCourse.TabIndex = 6;
        //
        // cboClass
        //
        this.cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboClass.FormattingEnabled = true;
        this.cboClass.Items.AddRange(new object[] {
            "49.01.TOAN.SN",
            "49.01.VAN.SN",
            "49.01.LY.SN",
            "49.01.HOA.SN"});
        this.cboClass.Location = new Point(90, 167);
        this.cboClass.Name = "cboClass";
        this.cboClass.Size = new Size(240, 23);
        this.cboClass.TabIndex = 5;
        //
        // dtpDateOfBirth
        //
        this.dtpDateOfBirth.Location = new Point(90, 257);
        this.dtpDateOfBirth.Name = "dtpDateOfBirth";
        this.dtpDateOfBirth.Size = new Size(240, 23);
        this.dtpDateOfBirth.TabIndex = 4;
        //
        // cboGender
        //
        this.cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboGender.FormattingEnabled = true;
        this.cboGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
        this.cboGender.Location = new Point(90, 287);
        this.cboGender.Name = "cboGender";
        this.cboGender.Size = new Size(240, 23);
        this.cboGender.TabIndex = 3;
        //
        // txtFullName
        //
        this.txtFullName.Location = new Point(90, 137);
        this.txtFullName.Name = "txtFullName";
        this.txtFullName.Size = new Size(240, 23);
        this.txtFullName.TabIndex = 2;
        //
        // txtStudentId
        //
        this.txtStudentId.Location = new Point(90, 107);
        this.txtStudentId.Name = "txtStudentId";
        this.txtStudentId.Size = new Size(240, 23);
        this.txtStudentId.TabIndex = 1;
        //
        // picPhoto
        //
        this.picPhoto.BorderStyle = BorderStyle.FixedSingle;
        this.picPhoto.Location = new Point(90, 20);
        this.picPhoto.Name = "picPhoto";
        this.picPhoto.Size = new Size(150, 80);
        this.picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        this.picPhoto.TabIndex = 0;
        this.picPhoto.TabStop = false;
        //
        // btnSelectPhoto
        //
        this.btnSelectPhoto.Location = new Point(10, 320);
        this.btnSelectPhoto.Name = "btnSelectPhoto";
        this.btnSelectPhoto.Size = new Size(130, 30);
        this.btnSelectPhoto.TabIndex = 8;
        this.btnSelectPhoto.Text = "Chọn ảnh (F1)";
        this.btnSelectPhoto.UseVisualStyleBackColor = true;
        this.btnSelectPhoto.Click += new EventHandler(this.btnSelectPhoto_Click);
        //
        // grpPreview
        //
        this.grpPreview.Controls.Add(this.pnlPreview);
        this.grpPreview.Controls.Add(this.btnPrintPreview);
        this.grpPreview.Controls.Add(this.btnPrint);
        this.grpPreview.Controls.Add(this.btnRefresh);
        this.grpPreview.Location = new Point(380, 12);
        this.grpPreview.Name = "grpPreview";
        this.grpPreview.Size = new Size(420, 450);
        this.grpPreview.TabIndex = 1;
        this.grpPreview.TabStop = false;
        this.grpPreview.Text = "Preview thẻ sinh viên";
        //
        // pnlPreview
        //
        this.pnlPreview.BackColor = Color.White;
        this.pnlPreview.BorderStyle = BorderStyle.FixedSingle;
        this.pnlPreview.Location = new Point(10, 20);
        this.pnlPreview.Name = "pnlPreview";
        this.pnlPreview.Size = new Size(400, 300);
        this.pnlPreview.TabIndex = 0;
        this.pnlPreview.Paint += new PaintEventHandler(this.pnlPreview_Paint);
        //
        // btnPrintPreview
        //
        this.btnPrintPreview.Location = new Point(10, 340);
        this.btnPrintPreview.Name = "btnPrintPreview";
        this.btnPrintPreview.Size = new Size(130, 30);
        this.btnPrintPreview.TabIndex = 2;
        this.btnPrintPreview.Text = "Xem trước in (F4)";
        this.btnPrintPreview.UseVisualStyleBackColor = true;
        this.btnPrintPreview.Click += new EventHandler(this.btnPrintPreview_Click);
        //
        // btnPrint
        //
        this.btnPrint.Location = new Point(150, 340);
        this.btnPrint.Name = "btnPrint";
        this.btnPrint.Size = new Size(130, 30);
        this.btnPrint.TabIndex = 3;
        this.btnPrint.Text = "In (F5)";
        this.btnPrint.UseVisualStyleBackColor = true;
        this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
        //
        // btnRefresh
        //
        this.btnRefresh.Location = new Point(290, 340);
        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.Size = new Size(120, 30);
        this.btnRefresh.TabIndex = 4;
        this.btnRefresh.Text = "Làm mới (F6)";
        this.btnRefresh.UseVisualStyleBackColor = true;
        this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
        //
        // lblPhoto
        //
        this.lblPhoto.AutoSize = true;
        this.lblPhoto.Location = new Point(10, 20);
        this.lblPhoto.Name = "lblPhoto";
        this.lblPhoto.Size = new Size(59, 15);
        this.lblPhoto.TabIndex = 16;
        this.lblPhoto.Text = "Ảnh đại diện:";
        //
        // FrmStudentCard
        //
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(820, 480);
        this.Controls.Add(this.grpPreview);
        this.Controls.Add(this.grpInput);
        this.KeyPreview = true;
        this.MinimumSize = new Size(840, 520);
        this.Name = "FrmStudentCard";
        this.Text = "Thẻ Sinh Viên - Lab 09";
        this.KeyDown += new KeyEventHandler(this.FrmStudentCard_KeyDown);
        this.grpInput.ResumeLayout(false);
        this.grpInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
        this.grpPreview.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion

    private GroupBox grpInput;
    private Label lblFaculty;
    private Label lblCourse;
    private Label lblDateOfBirth;
    private Label lblGender;
    private Label lblClass;
    private Label lblFullName;
    private Label lblStudentId;
    private ComboBox cboFaculty;
    private ComboBox cboCourse;
    private ComboBox cboClass;
    private DateTimePicker dtpDateOfBirth;
    private ComboBox cboGender;
    private TextBox txtFullName;
    private TextBox txtStudentId;
    private PictureBox picPhoto;
    private Button btnSelectPhoto;
    private GroupBox grpPreview;
    private Panel pnlPreview;
    private Button btnPrintPreview;
    private Button btnPrint;
    private Button btnRefresh;
    private Label lblPhoto;
    private PrintDocument printDocument;
    private PrintPreviewDialog printPreviewDialog;
    private PrintDialog printDialog;
}
