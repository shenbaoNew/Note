using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimerDemo {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private object _lockObject = new object();

        int i = 0;

        private void button1_Click(object sender, EventArgs e) {
            System.Threading.Timer _timer = new System.Threading.Timer(AsyncSearchCore, null, 1000, 1000);
        }

        void AsyncSearchCore(object state) {
            if (i < 100) {
                i += 10;
            }
            EventHandler eventHander = delegate {
                Show(i);
            };

            this.Invoke(eventHander, new object[] { i });
        }

        void Show(int x) {
            this.progressBar1.Value = i;
        }
    }
}
