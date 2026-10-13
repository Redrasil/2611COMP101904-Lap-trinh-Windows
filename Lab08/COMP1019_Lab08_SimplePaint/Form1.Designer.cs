namespace COMP1019_Lab08_SimplePaint;

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
        this.cboMode = new ComboBox();
        this.nudWidth = new NumericUpDown();
        this.btnColor = new Button();
        this.btnUndo = new Button();
        this.btnClear = new Button();
        this.canvas = new Panel();
        this.lblStatus = new Label();
        this.menuStrip1 = new MenuStrip();
        this.menuFile = new ToolStripMenuItem();
        this.menuSaveImage = new ToolStripMenuItem();
        this.menuOpenBackground = new ToolStripMenuItem();
        this.menuExit = new ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
        this.canvas.SuspendLayout();
        this.menuStrip1.SuspendLayout();
        this.SuspendLayout();
        //
        // cboMode
        //
        this.cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboMode.FormattingEnabled = true;
        this.cboMode.Items.AddRange(new object[] {
            "Pen",
            "Line",
            "Rectangle",
            "Ellipse"});
        this.cboMode.Location = new Point(12, 30);
        this.cboMode.Name = "cboMode";
        this.cboMode.Size = new Size(120, 23);
        this.cboMode.TabIndex = 0;
        this.cboMode.SelectedIndex = 0;
        //
        // nudWidth
        //
        this.nudWidth.Location = new Point(138, 30);
        this.nudWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
        this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.nudWidth.Name = "nudWidth";
        this.nudWidth.Size = new Size(80, 23);
        this.nudWidth.TabIndex = 1;
        this.nudWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
        //
        // btnColor
        //
        this.btnColor.BackColor = Color.Black;
        this.btnColor.Location = new Point(224, 30);
        this.btnColor.Name = "btnColor";
        this.btnColor.Size = new Size(80, 23);
        this.btnColor.TabIndex = 2;
        this.btnColor.Text = "Color";
        this.btnColor.UseVisualStyleBackColor = false;
        //
        // btnUndo
        //
        this.btnUndo.Location = new Point(310, 30);
        this.btnUndo.Name = "btnUndo";
        this.btnUndo.Size = new Size(80, 23);
        this.btnUndo.TabIndex = 3;
        this.btnUndo.Text = "Undo";
        this.btnUndo.UseVisualStyleBackColor = true;
        //
        // btnClear
        //
        this.btnClear.Location = new Point(396, 30);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new Size(80, 23);
        this.btnClear.TabIndex = 4;
        this.btnClear.Text = "Clear";
        this.btnClear.UseVisualStyleBackColor = true;
        //
        // canvas
        //
        this.canvas.BackColor = Color.White;
        this.canvas.BorderStyle = BorderStyle.FixedSingle;
        this.canvas.Location = new Point(12, 70);
        this.canvas.Name = "canvas";
        this.canvas.Size = new Size(760, 450);
        this.canvas.TabIndex = 5;
        this.canvas.Paint += new PaintEventHandler(this.canvas_Paint);
        this.canvas.MouseDown += new MouseEventHandler(this.canvas_MouseDown);
        this.canvas.MouseMove += new MouseEventHandler(this.canvas_MouseMove);
        this.canvas.MouseUp += new MouseEventHandler(this.canvas_MouseUp);
        //
        // lblStatus
        //
        this.lblStatus.AutoSize = true;
        this.lblStatus.Location = new Point(12, 535);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new Size(50, 15);
        this.lblStatus.TabIndex = 6;
        this.lblStatus.Text = "Status: ";
        //
        // menuStrip1
        //
        this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.menuFile});
        this.menuStrip1.Location = new Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new Size(784, 24);
        this.menuStrip1.TabIndex = 7;
        this.menuStrip1.Text = "menuStrip1";
        //
        // menuFile
        //
        this.menuFile.DropDownItems.AddRange(new ToolStripItem[] {
            this.menuSaveImage,
            this.menuOpenBackground,
            this.menuExit});
        this.menuFile.Name = "menuFile";
        this.menuFile.Size = new Size(37, 20);
        this.menuFile.Text = "File";
        //
        // menuSaveImage
        //
        this.menuSaveImage.Name = "menuSaveImage";
        this.menuSaveImage.Size = new Size(180, 22);
        this.menuSaveImage.Text = "Save Image as PNG";
        this.menuSaveImage.Click += new EventHandler(this.menuSaveImage_Click);
        //
        // menuOpenBackground
        //
        this.menuOpenBackground.Name = "menuOpenBackground";
        this.menuOpenBackground.Size = new Size(180, 22);
        this.menuOpenBackground.Text = "Open Background Image";
        this.menuOpenBackground.Click += new EventHandler(this.menuOpenBackground_Click);
        //
        // menuExit
        //
        this.menuExit.Name = "menuExit";
        this.menuExit.Size = new Size(180, 22);
        this.menuExit.Text = "Exit";
        this.menuExit.Click += new EventHandler(this.menuExit_Click);
        //
        // Form1
        //
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(784, 561);
        this.Controls.Add(this.menuStrip1);
        this.Controls.Add(this.lblStatus);
        this.Controls.Add(this.canvas);
        this.Controls.Add(this.btnClear);
        this.Controls.Add(this.btnUndo);
        this.Controls.Add(this.btnColor);
        this.Controls.Add(this.nudWidth);
        this.Controls.Add(this.cboMode);
        this.MainMenuStrip = this.menuStrip1;
        this.MinimumSize = new Size(800, 600);
        this.Name = "Form1";
        this.Text = "Simple Paint - Lab 08";
        this.KeyPreview = true;
        this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
        ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
        this.canvas.ResumeLayout(false);
        this.canvas.PerformLayout();
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private ComboBox cboMode;
    private NumericUpDown nudWidth;
    private Button btnColor;
    private Button btnUndo;
    private Button btnClear;
    private Panel canvas;
    private Label lblStatus;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem menuFile;
    private ToolStripMenuItem menuSaveImage;
    private ToolStripMenuItem menuOpenBackground;
    private ToolStripMenuItem menuExit;
}
