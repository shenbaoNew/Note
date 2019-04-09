using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestfulServer;
using System.Net;
using System.Globalization;
using System.IO;

namespace RestfulClient {
    class Program {
        static void Main(string[] args) {
            //post
            string requestData = "{\"msg\":\"restfultest\",\"upwd\":\"admin\"}";
            byte[] data = Encoding.UTF8.GetBytes(requestData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(CultureInfo.CurrentCulture, "http://{0}:{1}/{2}/ShowMessage/restfultest", "127.0.0.1", "8023", "Restful"));
            request.Method = "POST";
            request.ContentType = "application/json";
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
