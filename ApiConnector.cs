using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace profiwowdektop
{
    public class ApiConnector
    {
        const string API_SERV_URL = "http://profi-wow-api.sebrogala.com";
        public string userBearer { get; set; }

        /// <summary>
        /// Occurs when ApiConnector instance begins a web request.
        /// </summary>
        public event EventHandler BeginRequest;

        /// <summary>
        /// Occurs when ApiConnector instance ends previously started web request.
        /// </summary>
        public event EventHandler EndRequest;

        /// <summary>
        /// OKAPI installation which the ApiConnector uses for method calls.
        /// </summary>

        public ApiConnector()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Login(CUser user)
        {
            string serializowanyuser = JsonConvert.SerializeObject(user);

            string postData = serializowanyuser;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData.ToString());


            string response = GetResponse("/user/login", byte1);
            return "";
        }
        
        /// <summary>
        /// read a WebResponse and return content as string
        /// </summary>
        public static string ReadResponse(WebResponse response)
        {
            if (response == null)
                return "";
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var r = reader.ReadToEnd();
            return r;
        }
        
        /// <summary>
        /// make a request for the specified URL, read response and return it's content
        /// throw a WebException if response is not 200
        /// </summary>
        public string GetResponse(string url, byte [] requestBody)
        {
            //this.BeginRequest(this, null);
            try
            {

                WebRequest request = WebRequest.Create(API_SERV_URL + url);
                request.Timeout = 15000;
                request.Proxy = null;
                                      
                request.Method = "POST";
                //request.Headers.Add("Authorization", "Authorization: Bearer " + userBearer);
                request.GetRequestStream().Write(requestBody, 0, requestBody.Length);

                //TODO make more humanable how to create body req


                using (WebResponse response = request.GetResponse())
                {
                    return ReadResponse(response);
                }
            }
            catch (WebException e)
            {
                MessageBoxResult result = MessageBox.Show(e.Response.ToString());

                //TODO how to catch body responde

                //Stream receiveStream = e.GetResponseStream();
                //StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                //txtBlock.Text = readStream.ReadToEnd();


                throw;
            }
            finally
            {
                //this.EndRequest(this, null);
            }
        }
    }
}
