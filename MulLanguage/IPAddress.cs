using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using IPAddressxx;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;

namespace IPAddress
{
    public partial class IPAddress : Form
    {
        private object _lockObj = new object();

        public IPAddress()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string threeLetterLanguageName = "CHS";
        private void button1_Click(object sender, EventArgs e)
        {
            //在中文和英文之间切换
            if (threeLetterLanguageName == "CHS")
            {
                threeLetterLanguageName = string.Empty;
            }
            else
            {
                threeLetterLanguageName = "CHS";
            }
            InitializeCultreInfo();
        }

        /// <summary>
        /// 初始化线程语言别
        /// </summary>
        private void InitializeCultreInfo()
        {
            CultureInfo newCultureInfo = new CultureInfo(GetCultureInfoName(threeLetterLanguageName));
            if (Thread.CurrentThread.CurrentUICulture.LCID != newCultureInfo.LCID)
            {
                Thread.CurrentThread.CurrentUICulture = newCultureInfo;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(IPAddress));

                resources.ApplyResources(button1, button1.Name);
                resources.ApplyResources(label1, label1.Name);
                resources.ApplyResources(this, "$this");
            }
        }

        /// <summary>
        /// 对当前语言别赋值
        /// </summary>
        /// <param name="threeLetterLanguageName"></param>
        /// <returns></returns>
        private static string GetCultureInfoName(string threeLetterLanguageName)
        {
            string name = "en-US";
            switch (threeLetterLanguageName)
            {
                case "CHS":
                    name = "zh-CN";
                    break;
                default:
                    break;
            }
            return name;
        }
    }
}