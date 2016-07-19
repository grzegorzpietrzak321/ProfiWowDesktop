using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace profiwowdektop
{
    public abstract class AbstractApiConnector
    {
        const string API_SERV_URL = "http://profi-wow-api.sebrogala.com";
        public static string userBearer;

        /// <summary>
        /// make a request for the specified URL, read response and return it's content
        /// throw a WebException if response is not 200
        /// </summary>
        public string GetRespPOST(string url, string requestBody, string requestHeader = "")
        {
            try
            {
                // 1. create request
                WebRequest request = WebRequest.Create(API_SERV_URL + url);

                // 2. set credentialis if required
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Timeout = 15000;

                // 3. set method
                request.Method = "POST";

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

                // Clean up the streams and the response.
                reader.Close();
                response.Close();

                return responseFromServer;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Some error ;(");
                throw;
            }

        }

    }
}
