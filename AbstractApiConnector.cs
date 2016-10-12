using System;
using System.IO;
using System.Net;
using System.Windows;

namespace profiwowdektop
{
    public abstract class AbstractApiConnector
    {
        const string ApiServUrl = "http://profi-wow-api.sebrogala.com";
        public static string UserBearer;
        private object _responseFromServer;

        /// <summary>
        /// make a request for the specified URL, read response and return it's content
        /// throw a WebException if response is not 200
        /// </summary>
        public string GetRespPost(string url, string requestBody, string requestHeader = "")
        {
            try
            {
                // 1. create request
                WebRequest request = WebRequest.Create(ApiServUrl + url);

                // 2. set credentialis if required
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Timeout = 15000;

                // 3. set method
                request.Method = "POST";

                // 4. other stuff
                request.ContentType = "application/json; charset=UTF-8";

                // 5. do some body to send
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(requestBody);
                    streamWriter.Flush();
                    streamWriter.Close();
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

        public void GetRespGet(string url, string requestHeader)
        {
            // 1. create request
            WebRequest request = WebRequest.Create(ApiServUrl + url);

            // 2. set credentialis if required
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 15000;
            // 3. req method
            request.Method = "GET";
            // 4. add req headers
            request.Headers = new WebHeaderCollection();
            request.Headers.Clear();
            request.Headers.Add("Authorization", requestHeader);





            // 5. other stuff
            request.ContentType = "application/json; charset=UTF-8";

            // 6. get response
            WebResponse response = request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            if (dataStream != null)
            {
                StreamReader reader = new StreamReader(dataStream);

                // Read the content.
                _responseFromServer = reader.ReadToEnd();

                // Display the content.
                Console.WriteLine(_responseFromServer);

                // Clean up the streams and the response.
                reader.Close();
                response.Close();


            }
        }

    }
}
