using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class ServiceLog
    {
        public static string CARD_SERVICE = ConfigurationManager.AppSettings["card_service"].ToString();
        public static string HT_SERVICE = ConfigurationManager.AppSettings["ht_service"].ToString();
        public static string ES_SERVICE = ConfigurationManager.AppSettings["es_service"].ToString();
        public static string VC_SERVICE = ConfigurationManager.AppSettings["vc_service"].ToString();

        /// <summary>  
        /// 写入日志到文本文件  
        /// </summary>  
        /// <param name="action">动作</param>  
        /// <param name="strMessage">日志内容</param>  
        /// <param name="time">时间</param>  
        public static void WriteServiceLog(string serviceName, string action, string strMessage, DateTime time)
        {
            if (ConfigurationManager.AppSettings["IsLog"].ToString() == "true")
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"ServiceLog\" + serviceName + @"\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileFullPath = path + time.ToString("yyyy-MM-dd") + "_" + serviceName + ".txt";
                StringBuilder str = new StringBuilder();
                str.Append("时间:    " + time.ToString() + "\r\n");
                str.Append("操作:  " + action + "\r\n");
                str.Append("日志信息: " + strMessage + "\r\n");
                str.Append("-----------------------------------------------------------\r\n\r\n");
                StreamWriter sw;
                if (!File.Exists(fileFullPath))
                {
                    sw = File.CreateText(fileFullPath);
                }
                else
                {
                    sw = File.AppendText(fileFullPath);
                }
                sw.WriteLine(str.ToString());
                sw.Close();
            }
        }

        
    }

}
