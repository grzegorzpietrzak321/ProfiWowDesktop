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
        


        private string GetProfessions(CProfession profession)
        {
            return "";
        }

        private string PostItem(CItem item)
        {
            return "";
        }

        public ApiConnector()
        {

        }
        
        public string GetRespGET(string url, string requestHeader)
        {
            // 1. create request
            WebRequest request = WebRequest.Create(API_SERV_URL + url);

            // 2. set credentialis if required
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 15000;

            // 4. other stuff
            request.ContentType = "application/json; charset=UTF-8";

            using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
            {

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
            return "";
        }

        //public string GetRespPUT ()
        //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

    }
}
