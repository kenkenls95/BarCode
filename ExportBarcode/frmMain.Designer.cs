namespace HelloWord
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.btnSkip = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblCaseNo = new System.Windows.Forms.Label();
            this.lblSupplierPart = new System.Windows.Forms.Label();
            this.lblTMVPart = new System.Windows.Forms.Label();
            this.lblActual = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.lblPopup = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnScan.Location = new System.Drawing.Point(120, 266);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(88, 35);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Quét";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(129, 228);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(184, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 30);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(264, 6);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 20);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.Text = "Thoát";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(38, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.Text = "EXPORT BARCODE";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.Text = "Step:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.Text = "Case No:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.Text = "Supplier Part:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.Text = "TMV Part:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.Text = "Actual:";
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Title.Location = new System.Drawing.Point(11, 231);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(114, 20);
            this.Title.Text = "START MODULE";
            // 
            // btnSkip
            // 
            this.btnSkip.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSkip.ForeColor = System.Drawing.Color.Red;
            this.btnSkip.Location = new System.Drawing.Point(129, 313);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(79, 20);
            this.btnSkip.TabIndex = 14;
            this.btnSkip.Text = "Bỏ qua";
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(11, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 18);
            this.label8.Text = "Scan thông tin barcode";
            // 
            // lblStep
            // 
            this.lblStep.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep.Location = new System.Drawing.Point(52, 43);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(242, 20);
            // 
            // lblCaseNo
            // 
            this.lblCaseNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaseNo.Location = new System.Drawing.Point(72, 76);
            this.lblCaseNo.Name = "lblCaseNo";
            this.lblCaseNo.Size = new System.Drawing.Size(228, 20);
            // 
            // lblSupplierPart
            // 
            this.lblSupplierPart.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblSupplierPart.Location = new System.Drawing.Point(98, 109);
            this.lblSupplierPart.Name = "lblSupplierPart";
            this.lblSupplierPart.Size = new System.Drawing.Size(209, 20);
            // 
            // lblTMVPart
            // 
            this.lblTMVPart.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTMVPart.Location = new System.Drawing.Point(78, 142);
            this.lblTMVPart.Name = "lblTMVPart";
            this.lblTMVPart.Size = new System.Drawing.Size(231, 20);
            // 
            // lblActual
            // 
            this.lblActual.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblActual.Location = new System.Drawing.Point(60, 175);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(242, 20);
            // 
            // lblPopup
            // 
            this.lblPopup.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPopup.ForeColor = System.Drawing.Color.Red;
            this.lblPopup.Location = new System.Drawing.Point(98, 345);
            this.lblPopup.Name = "lblPopup";
            this.lblPopup.Size = new System.Drawing.Size(215, 20);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(15, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.Text = "Thông báo:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(225, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 24;
            this.button1.Text = "Xóa";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(15, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 35);
            this.button2.TabIndex = 25;
            this.button2.Text = "Đồng bộ";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClean
            // 
            this.btnClean.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnClean.Location = new System.Drawing.Point(15, 378);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(88, 35);
            this.btnClean.TabIndex = 41;
            this.btnClean.Text = "Xóa Dữ liệu";
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSetting.Location = new System.Drawing.Point(225, 378);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(88, 35);
            this.btnSetting.TabIndex = 57;
            this.btnSetting.Text = "Cài đặt";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPopup);
            this.Controls.Add(this.lblActual);
            this.Controls.Add(this.lblTMVPart);
            this.Controls.Add(this.lblSupplierPart);
            this.Controls.Add(this.lblCaseNo);
            this.Controls.Add(this.lblStep);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnScan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "EXPORT BARCODE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.LinkLabel btnSkip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label lblCaseNo;
        private System.Windows.Forms.Label lblSupplierPart;
        private System.Windows.Forms.Label lblTMVPart;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPopup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnSetting;
    }
}

