using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ExportBarcode.DAO;
using ExportBarcode.SERVICE;
using ExportBarcode.MODEL;
using ExportBarcode.Common;



namespace HelloWord
{


    public partial class frmMain : Form
    {
        private static IList<PartDetail> moduleDetails = new List<PartDetail>();
        private static bool isScanBox = false;
        private static string caseNo = null; 
        private static Int32 total = 0;
        private static DateTime begin;
        private static DateTime end;
        private static Boolean scanSup = false;
        private static Boolean scanTMV = false;
        private static String partCheck = null;
        private static String qrSup = null;
        private static String qrTMV = null;
        private static Int32 actual = 0;


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                txtCode.Focus();
                lblPopup.Text = "Mời scan Module No";
            }
            catch
            { }
        }

        private void bindInfo()
        {
            lblStep.Text = "";
            lblCaseNo.Text = "";
            lblSupplierPart.Text = "";
            lblTMVPart.Text = "";
            lblActual.Text = "";
        }



        private string scanModule(String moduleNo)
        {
            DataTable dt = PackingDetailsDAO.LoadScreen(moduleNo);
            DataTable dtPacking = PackingDAO.LoadScreen(moduleNo);
            if (dt.Rows.Count > 0 && dtPacking == null)
            {
                caseNo = dt.Rows[0]["MODULENO"].ToString();
                lblStep.Text = "Scan QrCode Supplier";
                lblCaseNo.Text = caseNo;
                lblSupplierPart.Text = "";
                lblTMVPart.Text = "";
                lblActual.Text = "";
                lblPopup.Text = "";

                begin = DateTime.Now;
                isScanBox = true;
                Title.Text = "BOX";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PARTNO"] == null) break;
                    PartDetail p = new PartDetail();
                    p.box = dt.Rows[i]["BOX"].ToString();
                    p.partId = dt.Rows[i]["PARTID"].ToString();
                    p.partNo = dt.Rows[i]["PARTNO"].ToString();
                    p.qtyPerBox = dt.Rows[i]["QTYPERBOX"].ToString();
                    p.moduleNo = caseNo;
                    p.actual = 0;
                    p.actualTmv = 0;
                    moduleDetails.Add(p);
                    total += Int32.Parse(p.box) * Int32.Parse(p.qtyPerBox);
                }
                
                txtCode.Text = "";
                return "OK";
            }
            else if (dtPacking.Rows.Count > 0) return "Module đã hoàn thành đóng";
            else return "ModuleNo không tồn tại";
        }

        private string scanBoxSupplier(String partNo, String color, String minorCode)
        {
            partCheck = partNo;
            lblStep.Text = "Scan QrCode TMV";
            lblCaseNo.Text = caseNo;
            lblTMVPart.Text = partNo;
            lblSupplierPart.Text = "";
            lblPopup.Text = "";

            Integer index = null;
            for (int i = 0; i < moduleDetails.Count; i++)
            {
                if (partNo.Equals(moduleDetails[i].partNo))
                {
                    if (Int32.Parse(moduleDetails[i].box) == moduleDetails[i].actual)
                    {
                        txtCode.Text = "";
                        lblPopup.Text = "Part đã được scan đủ";
                        break;
                    }
                    moduleDetails[i].actual += 1;
                    scanSup = true;
                    txtCode.Text = "";
                    index = i;
                    break;
                }
            }

            if (index == null) {
                lblPopup.Text = "Part không tồn tại";
                return ""; 
            }
            else return partNo + color + minorCode;
        }

        private string scanBoxTmv(String partNo, String color, String minorCode)
        {
            if (!partCheck.Equals(partNo))
            {
                return "Part TMV không trùng với Supplier";
            }
            partCheck = null;
            lblStep.Text = "Scan QrCode Supplier";
            lblCaseNo.Text = caseNo;
            lblTMVPart.Text = partNo;

            Integer index = null;
            for (int i = 0; i < moduleDetails.Count; i++)
            {
                if (partNo.Equals(moduleDetails[i].partNo))
                {
                    moduleDetails[i].actualTmv += 1;
                    scanTMV = true;
                    txtCode.Text = "";
                    index = i;
                    break;
                }
            }
            actual = 0;
            for (int i = 0; i < moduleDetails.Count; i++)
            {
                actual += moduleDetails[i].actualTmv * Int32.Parse(moduleDetails[i].qtyPerBox.ToString());
            }

            lblActual.Text = actual.ToString() + "/" + total.ToString();

            if (index == null) {
                lblPopup.Text = "Part không tồn tại";
                return "";
            }
            else
            {
                PackingDetailsUpdate p = new PackingDetailsUpdate();
                p.moduleNo = caseNo;
                p.partNo = moduleDetails[index].partNo;
                if (moduleDetails[index].actual >= moduleDetails[index].actualTmv) p.boxActual = moduleDetails[index].actualTmv.ToString(); else p.boxActual = moduleDetails[index].actual.ToString();
                PackingDetailsDAO.updateBoxActual(p);
                Service.updateBoxActual(p);
                return partNo + color + minorCode;
            }
        }

        private Boolean checkModule(String scanCaseNo)
        {
            List<int> check = new List<int>();
            String partMissing = "";
            for (int i = 0; i < moduleDetails.Count; i++)
            {
                if (moduleDetails[i].actual != moduleDetails[i].actualTmv)
                {
                    check.Add(i);
                    partMissing += moduleDetails[i].partNo + ";";
                }
            }
            if (check.Count == 0 && scanCaseNo.Equals(caseNo))
            {
                DataTable dt = PackingDAO.getPackingByModuleNo(caseNo);
                end = DateTime.Now;
                PackingDAO.update(begin, end, caseNo, dt.Rows[0]["PACKINGID"].ToString());
                //MessageBox.Show(caseNo + "-" + dt.Rows[0]["PACKINGID"].ToString() + "-" + begin.ToString("yyyy-MM-dd HH:mm:ss") + "-" + end.ToString("yyyy-MM-dd HH:mm:ss"));
                Service.updateCase(caseNo, dt.Rows[0]["PACKINGID"].ToString(), begin, end);
                lblStep.Text = "";
                lblCaseNo.Text = "";
                lblSupplierPart.Text = "";
                lblTMVPart.Text = "";
                lblActual.Text = "";
                Title.Text = "START MODULE";
                isScanBox = false;
                caseNo = null;
                lblPopup.Text = "Hoàn thành";
                txtCode.Text = "";
                actual = 0;
                total = 0;
                moduleDetails.Clear();
                return true;
            }
            else if (check.Count == 0 && !scanCaseNo.Equals(caseNo))
            {
                lblPopup.Text = "QrCode không trùng";
                return false;
            }
            else
            {
                lblPopup.Text = "Chưa quét đủ Part. Part thiếu :" + partMissing;
                return false;
            }
        }



        private void txtCode_keypress(object sender, KeyPressEventArgs e)
        {


        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                string text = txtCode.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (!isScanBox) lblPopup.Text = scanModule(text);
                    else
                    {
                        if (!scanSup && !scanTMV && !actual.Equals(total))
                        {
                            string[] qr = text.Split('-');
                            qrSup = null;
                            qrSup = scanBoxSupplier(qr[0], qr[1], qr[2]);
                        }
                        else if (scanSup && !scanTMV && !actual.Equals(total))
                        {
                            string[] qr = text.Split('-');
                            qrTMV = null;
                            qrTMV = scanBoxTmv(qr[0], qr[1], qr[2]);
                            scanSup = false;
                            scanTMV = false;
                        }
                        else if (actual.Equals(total) && !scanSup && !scanTMV)
                        {
                            if (checkModule(text)) lblPopup.Text = "Hoàn thành Module";
                            else lblPopup.Text = "ModuleNo không trùng";
                        }
                        else if (actual > total) lblPopup.Text = "Vượt quá số lượng Part";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    try
                    {
                        string text = txtCode.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            if (!isScanBox) lblPopup.Text = scanModule(text);
                            else
                            {
                                if (!scanSup && !scanTMV && !actual.Equals(total))
                                {
                                    string[] qr = text.Split('-');
                                    qrSup = null;
                                    qrSup = scanBoxSupplier(qr[0], qr[1], qr[2]);
                                }
                                else if (scanSup && !scanTMV && !actual.Equals(total))
                                {
                                    string[] qr = text.Split('-');
                                    qrTMV = null;
                                    qrTMV = scanBoxTmv(qr[0], qr[1], qr[2]);
                                    scanSup = false;
                                    scanTMV = false;
                                }
                                else if (actual.Equals(total) && !scanSup && !scanTMV)
                                {
                                    if (checkModule(text)) lblPopup.Text = "Hoàn thành Module";
                                    else lblPopup.Text = "ModuleNo không trùng";
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            if (caseNo == null)
            {
                lblPopup.Text = "Mời quét Module No";
            }
            else {
                bindInfo();
                lblStep.Text = "";
                scanSup = false;
                scanTMV = false;
                isScanBox = false;
                actual = 0;
                total = 0;
                lblPopup.Text = "Bỏ qua thành công";
                Title.Text = "START MODULE";
                PackingDAO.skipCase(begin, end, caseNo, 1);
                Service.skip(caseNo);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                Service.syncDB();
                Service.sendData();
                lblPopup.Text = "Đồng bộ thành công";
            }catch(Exception ex){
                lblPopup.Text = ex.Message.ToString();
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (Service.delete())
                lblPopup.Text = "Xóa dữ liệu thành công";
            else lblPopup.Text = "Xóa dữ liệu không thành công";
        }
    }
}