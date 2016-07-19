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
        /// <summary>
        /// constant adres to serv
        /// </summary>
        const string API_SERV_URL = "http://profi-wow-api.sebrogala.com";
        public string userBearer { get; set; }

        private string UserRegister(CUserRegister userregister)
        {

            return "";
        }
            
        private string Login(CUser user)
        {
            string serializowanyuser = JsonConvert.SerializeObject(user);

            string postData = serializowanyuser;
            byte[] byte1 = Encoding.ASCII.GetBytes(postData);

            string response = GetResponse("/user/login", byte1);
            return "";
        }

        private string GetProfessions(CProfession profession)
        {

            return "";
        }

        private string PostItem(CItem item)
        {

            return "";
        }
        /// <summary>
        /// 
        /// </summary>

        public ApiConnector()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        
        /// <summary>
        /// read a WebResponse and return content as string
        /// </summary>
        public static string ReadResponse(WebResponse response)
        {
            if (response == null)
                return "";
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var r = reader.ReadToEnd().Trim();
            return r;
        }
        
        /// <summary>
        /// make a request for the specified URL, read response and return it's content
        /// throw a WebException if response is not 200
        /// </summary>
        public string GetResponse(string url, byte[] requestBody)
        {
            //this.BeginRequest(this, null);
            

                WebRequest request = WebRequest.Create(API_SERV_URL + url);
                request.Timeout = 15000;
                request.Proxy = null;
                                      
                request.Method = "POST";
                //request.Headers.Add("Authorization", "Authorization: Bearer " + userBearer);
                Stream str = request.GetRequestStream();
                str.Write(requestBody, 0, requestBody.Length);
                str.Close();
            //TODO make more humanable how to create body req

            ReadResponse(str);

        }
    }
}
