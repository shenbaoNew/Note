//https://www.cnblogs.com/canger/p/5938591.html
//委托的BeginInvoke和EndInvoke方法
//除了第4种采用回调函数的方式外，其他三种方式均会阻塞调用线程。
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace AsyncTest_Test {
    public delegate string AsyncDelegate(int callDuration, out int threadId);
    public delegate void ShowTextDelegate(string test);
    public partial class AsyncTest : Form {

        private ShowTextDelegate _delegate = null;
        public AsyncTest() {
            InitializeComponent();

            _delegate = new ShowTextDelegate(ShowText);
        }

        private void ShowText(string threadId) {
            this.button1.Text = threadId;
            this.button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e) {
        }

        private void button1_Click(object sender, EventArgs e) {
            this.button1.Enabled = false;
            Test3();
        }

        /// <summary>
        /// 使用 EndInvoke阻塞调用线程，直到异步调用结束
        /// </summary>
        private void Test() {
            //输出主线程ID
            Console.WriteLine("主线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            //创建委托
            AsyncDelegate asyncDel = new AsyncDelegate(TestMethod);
            int nThreadID = 0;

            //异步执行TestMethod方法
            IAsyncResult result = asyncDel.BeginInvoke(3000, out nThreadID, null, null);
            //阻塞调用线程
            asyncDel.EndInvoke(out nThreadID, result);

            this.BeginInvoke(_delegate, new object[] { nThreadID.ToString() });
        }

        /// <summary>
        /// 使用 WaitHandle 等待异步调用
        /// </summary>
        private void Test1() {
            //输出主线程ID
            Console.WriteLine("主线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            //创建委托
            AsyncDelegate asyncDel = new AsyncDelegate(TestMethod);
            int nThreadID = 0;

            //异步执行TestMethod方法
            IAsyncResult result = asyncDel.BeginInvoke(3000, out nThreadID, null, null);
            //阻塞调用线程
            WaitHandle handle = result.AsyncWaitHandle;
            handle.WaitOne();

            //其他操作

            //终止异步调用，通过返回值取得调用结果
            string returnValue = asyncDel.EndInvoke(out nThreadID, result);

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".",
                nThreadID, returnValue);
        }

        /// <summary>
        /// 轮询异步调用完成
        /// </summary>
        private void Test2() {
            //输出主线程ID
            Console.WriteLine("主线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            //创建委托
            AsyncDelegate asyncDel = new AsyncDelegate(TestMethod);
            int nThreadID = 0;

            //异步执行TestMethod方法
            IAsyncResult result = asyncDel.BeginInvoke(3000, out nThreadID, null, null);

            //轮询异步执行状态
            while (true) {
                if (result.IsCompleted) {
                    break;
                }
                Thread.Sleep(1000);
            }

            //终止异步调用，通过返回值取得调用结果
            string returnValue = asyncDel.EndInvoke(out nThreadID, result);

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".",
                nThreadID, returnValue);

        }

        /// <summary>
        /// 异步调用完成时执行回调方法
        /// 不会阻塞调用线程
        /// </summary>
        private void Test3() {
            //输出主线程ID
            Console.WriteLine("主线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            //创建委托
            AsyncDelegate asyncDel = new AsyncDelegate(TestMethod);
            int nThreadID = 0;

            //异步执行TestMethod方法,使用回调函数并传入state参数
            IAsyncResult result = asyncDel.BeginInvoke(3000, out nThreadID,
                new AsyncCallback(AsyncCallCompleted), "测试参数传递");
        }

        public void AsyncCallCompleted(IAsyncResult ar) {
            Console.WriteLine("AsyncCallCompleted执行线程ID：{0}", Thread.CurrentThread.ManagedThreadId);

            //获取委托对象
            System.Runtime.Remoting.Messaging.AsyncResult result = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
            AsyncDelegate asyncDel = (AsyncDelegate)result.AsyncDelegate;

            //获取BeginInvoke传入的的state参数
            string strState = (string)ar.AsyncState;
            Console.WriteLine("传入的字符串是{0}", strState);

            //结束异步调用
            int nThreadID;
            string strResult = asyncDel.EndInvoke(out nThreadID, ar);
            this.BeginInvoke(_delegate, new object[] { nThreadID.ToString() });

            Console.WriteLine("\nThe call executed on thread {0}, with return value \"{1}\".",
               nThreadID, strResult);
        }

        public string TestMethod(int callDuration, out int threadId) {
            Console.WriteLine("TestMethod方法的执行线程ID： {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }

    public class BatchContext:EventArgs {
        public string Text { get; set; }
    }
}
