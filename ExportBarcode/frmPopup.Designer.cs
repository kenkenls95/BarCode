namespace ExportBarcode
{
    partial class frmPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPopup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPalletNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPackingMonth = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.tblData = new System.Windows.Forms.DataGrid();
            this.lbl = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
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
            // lblPalletNo
            // 
            this.lblPalletNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblPalletNo.Location = new System.Drawing.Point(78, 62);
            this.lblPalletNo.Name = "lblPalletNo";
            this.lblPalletNo.Size = new System.Drawing.Size(220, 22);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 22);
            this.label2.Text = "PalletNo :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 22);
            this.label3.Text = "PackingMonth  :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 22);
            this.label4.Text = "SupplierCode  :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 22);
            this.label5.Text = "ReceivingDate Plan  :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 22);
            this.label6.Text = "Part List";
            // 
            // lblPackingMonth
            // 
            this.lblPackingMonth.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblPackingMonth.Location = new System.Drawing.Point(100, 97);
            this.lblPackingMonth.Name = "lblPackingMonth";
            this.lblPackingMonth.Size = new System.Drawing.Size(198, 22);
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblSupplierCode.Location = new System.Drawing.Point(100, 132);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(198, 22);
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(139, 167);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(159, 22);
            // 
            // tblData
            // 
            this.tblData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tblData.Location = new System.Drawing.Point(3, 227);
            this.tblData.Name = "tblData";
            this.tblData.Size = new System.Drawing.Size(310, 175);
            this.tblData.TabIndex = 17;
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(3, 420);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(69, 22);
            this.lbl.Text = "Quét :";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(78, 419);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(204, 23);
            this.txtCode.TabIndex = 28;
            // 
            // frmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(625, 455);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.tblData);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSupplierCode);
            this.Controls.Add(this.lblPackingMonth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPalletNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPopup";
            this.Text = "Popup";
            this.Load += new System.EventHandler(this.frmPopup_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPalletNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPackingMonth;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGrid tblData;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtCode;
    }
}