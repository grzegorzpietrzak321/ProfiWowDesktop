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
            
        public string Login(CUser user)
        {
            string serializowanyuser = JsonConvert.SerializeObject(user);
            string postData = serializowanyuser;
            return postData;
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
        /// read a WebResponse and return content as string
        /// </summary>
        public static string ReadResponse(WebResponse response)
        {
            if (response == null)
                return "";
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var r = reader.ReadToEnd().Trim().ToString();
            return r;
        }
        
        /// <summary>
        /// make a request for the specified URL, read response and return it's content
        /// throw a WebException if response is not 200
        /// </summary>
        public string GetResp(string url, string method, string requestBody)
        {
            try
            {
                // 1. create request
                WebRequest request = WebRequest.Create(API_SERV_URL + url);

                // 2. set credentialis if required
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Timeout = 15000;

                // 3. set method
                request.Method = method;

                // 4. other stuff
                request.ContentType = "application/json; charset=UTF-8";

                // 5. do some body to send
                using (var StreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    StreamWriter.Write(requestBody);
                    StreamWriter.Flush();
                    StreamWriter.Close();
                }

                // 6. get response
                WebResponse response = request.GetResponse();
                               
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                // Read the content.
                string responseFromServer = reader.ReadToEnd();

                // Display the content.
                Console.WriteLine(responseFromServer);

                // Clean up the streams and the response.
                reader.Close();
                response.Close();
                
                return responseFromServer;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            
         }
    }
}
