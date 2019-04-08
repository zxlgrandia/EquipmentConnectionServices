using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Utils;

namespace WindowsFormsApplication1
{
    public partial class SensorForm : Form
    {
        public SensorForm()
        {
            InitializeComponent();
        }

        private void bt_star_Click(object sender, EventArgs e)
        {
            list_m.Items.Add("启动");
            Crawling(textBox1.Text,null);
        }

        /// <summary>
        /// 爬取
        /// </summary>
        private void Crawling(string url, string host)
        {
        //    if (!VisitedHelper.IsVisited(url))
         //   {
        //        VisitedHelper.Add(url);

                if (host == null)
                {
                    host = GetHost(url);
                }

                string pageHtml = HttpRequestUtil.GetPageHtml(url);
               // list_m.Items.Add(pageHtml);
                textBox2.Text = pageHtml;
                         //< input name = "P8" type = "text" size = "22" maxlength = "22" value = "湿度:%46.8  温度:+19.6C" >
                         // Regex regInput_1 = new Regex(@"<input[\s]+[^<>]*name=", RegexOptions.IgnoreCase);
                Regex regA = new Regex(@"<a[\s]+[^<>]*href=(?:""|')([^<>""']+)(?:""|')[^<>]*>[^<>]+</a>", RegexOptions.IgnoreCase);
                Regex regImg = new Regex(@"<img[\s]+[^<>]*src=(?:""|')([^<>""']+(?:jpg|jpeg|png|gif))(?:""|')[^<>]*>", RegexOptions.IgnoreCase);

                //MatchCollection mcImg = regImg.Matches(pageHtml);
                //foreach (Match mImg in mcImg)
                //{
                //    string imageUrl = mImg.Groups[1].Value;
                //    try
                //    {
                //        int imageWidth = GetImageWidthOrHeight(mImg.Value, true);
                //        int imageHeight = GetImageWidthOrHeight(imageUrl, false);
                //        if (imageWidth >= m_MinWidth && imageHeight >= m_MinHeight)
                //        {
                //            if (imageUrl.IndexOf("javascript") == -1)
                //            {
                //                if (imageUrl.IndexOf("http") == 0)
                //                {
                //                    HttpRequestUtil.HttpDownloadFile(imageUrl, m_MinWidth, m_MinHeight);
                //                }
                //                else
                //                {
                //                    HttpRequestUtil.HttpDownloadFile(host + imageUrl, m_MinWidth, m_MinHeight);
                //                }
                //            }
                //        }
                //    }
                //    catch { }
                //}
                
          //  }
        } //end Crawling方法

        /// <summary>
        /// 获取主机
        /// </summary>
        private string GetHost(string url)
        {
            Regex regHost = new Regex(@"(?:http|https)://[a-z0-9\-\.:]+", RegexOptions.IgnoreCase);
            Match mHost = regHost.Match(url);
            return mHost.Value + "/";
        }


        /// <summary>
        /// 跨线程访问控件的委托
        /// </summary>
        public delegate void InvokeDelegate();


    }
}
