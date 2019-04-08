using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
    /// <summary>
    /// HTTP请求工具类
    /// </summary>
    public class HttpRequestUtil
    {
        /// <summary>
        /// 获取页面html
        /// </summary>
        public static string GetPageHtml(string url)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)";
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            return content;
        }

        /// <summary>
        /// Http下载文件
        /// </summary>
        public static void HttpDownloadFile(string url, int minWidth, int minHeight)
        {
            int pos = url.LastIndexOf("/") + 1;
            string fileName = url.Substring(pos);
            string path = Application.StartupPath + "\\download";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePathName = path + "\\" + fileName;
            if (File.Exists(filePathName)) return;

            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)";
            request.Proxy = null;
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();

            MemoryStream memoryStream = new MemoryStream();
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                memoryStream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            Image tempImage = System.Drawing.Image.FromStream(memoryStream, true);
            int imageHeight = tempImage.Height;
            int imageWidth = tempImage.Width;
            if (imageHeight >= minHeight && imageWidth >= minWidth)
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                size = memoryStream.Read(bArr, 0, (int)bArr.Length);
                FileStream fs = new FileStream(filePathName, FileMode.Create);
                while (size > 0)
                {
                    fs.Write(bArr, 0, size);
                    size = memoryStream.Read(bArr, 0, (int)bArr.Length);
                }
                fs.Close();
            }
            memoryStream.Close();
            responseStream.Close();
        }
    }
}