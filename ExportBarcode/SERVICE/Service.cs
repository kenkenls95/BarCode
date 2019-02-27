using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using ExportBarcode.Common;
using ExportBarcode.MODEL;
using ExportBarcode.DAO;
using CodeBetter.Json;

namespace ExportBarcode.SERVICE
{
   

    public class Service
    {

        public static string SendAPI(object obj, string method, string url)
        {
            try
            {
                var resp_result = "";
                string json_emp = Converter.Serialize(obj);
                //string json_emp = Convert.SerializeObject(obj);
                WebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                json_emp = json_emp.Replace("<", string.Empty).Replace(">k__BackingField", string.Empty);
                byte[] byteArray = Encoding.UTF8.GetBytes(json_emp);
                request.ContentType = "application/json";
                if (method != "GET")
                {
                    request.ContentLength = byteArray.Length;
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(json_emp);
                    }
                }

                WebResponse response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    resp_result = streamReader.ReadToEnd();
                }
                response.Close();
                return resp_result;
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        public static string getData(Integer packingDetailsId, Integer packingId) {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                SyncPOJO t = new SyncPOJO();
                t.packingDetailsId = packingDetailsId;
                t.packingId = packingId;
                // fake date
                t.andOnPackingDate = DateTime.Now.ToString("yyyy-MM-dd");

                return SendAPI(t, "PUT", "http://" + Constant.Constant.HOST + "/tmv/progress-screen");
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string sendData(){
            try {
                DataTable dt = PackingDAO.getDB();
                Meta rs = new Meta();
                if (dt == null) return "chưa có bản ghi nào";
                else
                {
                    List<PackingUpdate> list = new List<PackingUpdate>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PackingUpdate t = new PackingUpdate();
                        t.packingId = Int32.Parse(dt.Rows[i]["PACKINGID"].ToString());
                        t.moduleNo = dt.Rows[i]["MODULENO"].ToString();
                        t.beginActualPacking = dt.Rows[i]["BEGINACTUALPACKING"].ToString();
                        t.endActualPacking = dt.Rows[i]["ENDACTUALPACKING"].ToString();
                        // fake date
                        t.packingDate = DateTime.Now.ToString("yyyy-MM-dd");
                        // pending default is not
                        t.pending = 0;
                        list.Add(t);
                    }

                    rs = Converter.Deserialize<Meta>(SendAPI(list, "POST", "http://" + Constant.Constant.HOST + "/tmv/progress-screen"));
                    if (rs.status_code.Equals(Constant.Constant.SUCCESS)) return "OK";
                    else return "Fail";
                }
            }catch(Exception e){
                return e.Message;
            }
        }

        public static string updateCase(String caseNo, String packingId, DateTime begin, DateTime end)
        {
            try {
                List<PackingUpdate> list = new List<PackingUpdate>();
                PackingUpdate t = new PackingUpdate();
                t.packingId = Int32.Parse(packingId);
                t.moduleNo = caseNo;
                t.beginActualPacking = begin.ToString("yyyy-MM-dd HH:mm:ss");
                t.endActualPacking = end.ToString("yyyy-MM-dd HH:mm:ss");
                t.pending = 0;
                // fake date
                t.packingDate = DateTime.Now.ToString("yyyy-MM-dd");
                list.Add(t);

                //Meta rs = JsonConvert.DeserializeObject<Meta>(SendAPI(list, "POST", "http://" + Constant.Constant.HOST + "/tmv/progress-screen"));
                MetaData rs = Converter.Deserialize<MetaData>(SendAPI(list, "POST", "http://" + Constant.Constant.HOST + "/tmv/progress-screen"));
                if (rs.meta.status_code.Equals(Constant.Constant.SUCCESS)) return "OK";
                else return "Fail";
            }catch (Exception e){
                return e.Message;
            }

        }

        public static String updateBoxActual(PackingDetailsUpdate p) {
            try
            {
                List<PackingDetailsUpdate> list = new List<PackingDetailsUpdate>();
                list.Add(p);
                MetaData rs = Converter.Deserialize<MetaData>(SendAPI(list, "PUT", "http://" + Constant.Constant.HOST + "/tmv/progress-screen/box"));
                if (rs.meta.status_code.Equals(Constant.Constant.SUCCESS))
                    return "OK";
                else return "Fail";
            }catch(Exception e){
                return e.Message;
            }
        }

        public static Boolean skip(String caseNo) {
            IList<PackingUpdate> list = new List<PackingUpdate>();
            PackingUpdate t = new PackingUpdate();
            DataTable dt = PackingDAO.getById(caseNo);
            t.packingId = Int32.Parse(dt.Rows[0]["PACKINGID"].ToString());
            t.moduleNo = caseNo;
            t.beginActualPacking = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            t.endActualPacking = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            t.pending = 1;
            t.packingDate = DateTime.Now.ToString("yyyy-MM-dd");
            list.Add(t);

            //Meta rs = JsonConvert.DeserializeObject<Meta>(SendAPI(list, "POST", "http://" + Constant.Constant.HOST + "/tmv/progress-screen"));
            SendAPI(list, "POST", "http://" + Constant.Constant.HOST + "/tmv/progress-screen");
            return true;
            
        }

        public static Boolean syncDB() {
            try
            {
                Integer packingId = PackingDAO.checkPacking();
                Integer packingDetailsId = PackingDetailsDAO.checkPackingDetails();
                String respon = Service.getData(packingId, packingDetailsId);
                if (respon == null) return false;
                else
                {
                    //Sync packing = JsonConvert.DeserializeObject<Sync>(respon);
                    Sync packing = Converter.Deserialize<Sync>(respon);
                    if (packingId == null) packingId = 0;
                    if (packingDetailsId == null) packingDetailsId = 0;
                    if (packingId != null && packingDetailsId != null)
                    {
                        List<Packing> listPacking = packing.packing;
                        List<PackingDetails> listPackingDetails = packing.packingDetails;
                        if (listPacking.Count != 0 || listPackingDetails.Count != 0)
                        {
                            if (packingId < Int32.Parse(listPacking[0].packingId.ToString()))
                            {
                                for (int i = 0; i < listPacking.Count; i++)
                                {
                                    PackingDAO.insert(listPacking[i]);
                                }
                            }
                            if (packingDetailsId < Int32.Parse(listPackingDetails[0].packingDetailsId.ToString()))
                            {
                                for (int i = 0; i < listPackingDetails.Count; i++)
                                {
                                    PackingDetailsDAO.insert(listPackingDetails[i]);
                                }
                            }
                        }
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        public static void test() {
            //String respon = Service.SendAPI(null, "GET", "http://localhost:8080/tmv/box");
            String respon = "{\"<boxId>k__BackingField\":\"4632\",\"<code>k__BackingField\":\"DEV15\",\"<description>k__BackingField\":\"abc\",\"<height>k__BackingField\":\"100000.0\",\"<length>k__BackingField\":\"10000.0\",\"<width>k__BackingField\":\"12000.0\",\"<weight>k__BackingField\":\"12.12\",\"<cubic>k__BackingField\":\"12000.0\",\"<boxSize>k__BackingField\":\"10000x12000x100000\"}";
            test t = Converter.Deserialize<test>(respon);
        }

        public static Boolean delete()
        {
            try
            {
                PackingDetailsDAO.deletePackingDetals();
                PackingDAO.deletePacking();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
