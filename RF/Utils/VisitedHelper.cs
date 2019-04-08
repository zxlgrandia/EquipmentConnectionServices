using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
    /// <summary>
    /// 已访问的网址列表
    /// </summary>
    public class VisitedHelper
    {
        private static List<string> m_VisitedList = new List<string>();

        #region 判断是否已访问
        /// <summary>
        /// 判断是否已访问
        /// </summary>
        public static bool IsVisited(string url)
        {
            if (m_VisitedList.Exists(a => a == url))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 添加已访问
        /// <summary>
        /// 添加已访问
        /// </summary>
        public static void Add(string url)
        {
            m_VisitedList.Add(url);
        }
        #endregion

    }
}
