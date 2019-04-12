using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyClassLib;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DisposeTest {
    class Program {
        static void Main(string[] args) {
            string str = "aa";
            IntPtr init = Marshal.StringToHGlobalAnsi(str);
            DisposeDemo demo = new DisposeDemo(init);
            demo.Dispose();

            Console.ReadKey();
        }
    }

    public class DisposeDemo : IDisposable {
        private Component com = new Component();
        private IntPtr handle;

        public DisposeDemo(IntPtr i) {
            this.handle = i;
        }

        #region IDisposable 成员
        private bool _dispose = false;
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool dispose) {
            if (!_dispose) {
                lock (this) {
                    if (dispose) {
                        com.Dispose();
                    }

                    CloseHandle(handle);
                    handle = IntPtr.Zero;

                    _dispose = true;
                }
            }
        }

        ~DisposeDemo() {
            Dispose(false);
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        #endregion
    }

}
