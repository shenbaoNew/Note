using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace IPAddress {
    public partial class IPAddress : Form {
        public IPAddress() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            bool isflag = IsIpAddress("192.168.1.204");
        }

        private static bool IsIpAddress(string ipAddress) {
            if (!Regex.IsMatch(ipAddress, @"^([1-9]|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.([0-9]|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.([0-9]|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.([0-9]|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])$")) {
                return false;
            }
            return true;
        }
    }
}
